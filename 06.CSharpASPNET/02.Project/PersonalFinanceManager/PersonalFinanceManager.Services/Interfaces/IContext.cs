using System;

namespace PersonalFinanceManager.Services.Interfaces
{
    public interface IContext
    {
        IDisposable Context { get; set; }
    }
}
