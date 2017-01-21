namespace RecyclingStation.WasteDisposal
{
    using System;
    using System.Collections.Generic;
    using RecyclingStation.WasteDisposal.Interfaces;
    using System.Linq;
    using System.Reflection;
    using RecyclingStation.WasteDisposal.Attributes;

    internal class StrategyHolder : IStrategyHolder
    {
        private readonly IDictionary<Type, IGarbageDisposalStrategy> strategies;

        public StrategyHolder()
        {
            this.strategies = new Dictionary<Type, IGarbageDisposalStrategy>();
        }

        public IReadOnlyDictionary<Type, IGarbageDisposalStrategy> GetDisposalStrategies
        {
            get {return (IReadOnlyDictionary<Type, IGarbageDisposalStrategy>)this.strategies; }
        }

        public bool AddStrategy(Type disposableAttribute, IGarbageDisposalStrategy strategy)
        {
            this.strategies.Add(disposableAttribute, strategy);
            return true;
        }

        public bool RemoveStrategy(Type disposableAttribute)
        {
            this.strategies.Remove(disposableAttribute);
            return true;
        }

        public void InitializeStrategies()
        {
            var currentStrategies = Assembly
                       .GetExecutingAssembly()
                       .GetTypes()
                       .Where(s => s.Namespace == "RecyclingStation.Models.GarbageDisposalStrategies" && !s.IsAbstract)
                       .Where(s => typeof(IGarbageDisposalStrategy).IsAssignableFrom(s))
                       .ToList();
            var currentAttributes = Assembly
                       .GetExecutingAssembly()
                       .GetTypes()
                       .Where(a => a.Namespace == "RecyclingStation.Attributes" && !a.IsAbstract)
                       .Where(a => typeof(DisposableAttribute).IsAssignableFrom(a))
                       .ToList();
            foreach (var attribute in currentAttributes)
            {
                string strategyName = attribute.Name.Replace("Attribute", "GarbageDisposalStrategy");
                var strategy = currentStrategies.FirstOrDefault(x => x.Name == strategyName);
                if (strategy != null)
                {
                    var startInstance = (IGarbageDisposalStrategy)Activator.CreateInstance(strategy);
                    this.AddStrategy(attribute, startInstance);
                }
            }
        }
    }
}
