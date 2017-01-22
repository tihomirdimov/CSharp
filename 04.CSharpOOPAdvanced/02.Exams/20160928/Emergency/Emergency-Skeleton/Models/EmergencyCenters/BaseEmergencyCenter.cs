using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emergency_Skeleton.Models
{
    public abstract class BaseEmergencyCenter
    {
        private string name;
        private int amountOfMaximumEmergencies;

        protected BaseEmergencyCenter(string name, int amountOfMaximumEmergencies)
        {
            this.Name = name;
            this.AmountOfMaximumEmergencies = amountOfMaximumEmergencies;
        }

        public string Name { get; protected set; }
        public int AmountOfMaximumEmergencies { get; protected set; }
        public abstract Boolean isForRetirement();
    }
}
