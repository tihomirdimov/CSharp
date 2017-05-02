using System;
using PersonalFinanceManager.Data.Data;
using PersonalFinanceManager.Services.Interfaces;

namespace PersonalFinanceManager.Services.DbService
{
    public class DbContext : IContext
    {
        protected DbContext()
        {
            this.Context = new PfmDbContext();
        }

        public IDisposable Context { get; set; }
    }
}