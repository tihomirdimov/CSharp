using PersonalFinanceManager.Data.Data;

namespace PersonalFinanceManager.Services
{
    public class DbService
    {
        public DbService()
        {
            this.Context = new PfmDbContext();
        }
        public  PfmDbContext Context { get; set; }
    }
}