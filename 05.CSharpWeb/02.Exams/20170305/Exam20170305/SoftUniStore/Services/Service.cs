namespace SoftUniStore.Services
{
    using SoftUniStore.Data;

    public class Service
    {
        protected Service()
        {
            this.Context = Data.Context;
        }

        protected SoftUniStoreContext Context { get; }
    }
}
