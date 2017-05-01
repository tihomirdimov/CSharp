using PersonalFinanceManager.Data.Data;

namespace PersonalFinanceManager.Services
{
    public abstract class DbService
    {
        protected DbService()
        {
            this.Context = new PfmDbContext();
        }
        protected  PfmDbContext Context { get; set; }
    }
}