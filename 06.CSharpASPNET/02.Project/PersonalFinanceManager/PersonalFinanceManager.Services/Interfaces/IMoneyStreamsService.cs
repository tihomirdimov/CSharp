using System.Collections.Generic;
using PersonalFinanceManager.Data.Models;

namespace PersonalFinanceManager.Services.Interfaces
{
    public interface IMoneyStreamsService
    {
        bool CheckIfValidMoneyStream(int moneyStreamId, int bookId, string userId);

        MoneyStream GetMoneyStream(int moneyStreamId, string userId);

        ICollection<MoneyStream> GetMoneyStreamsList(int bookId, string userId);

        void SaveMoneyStream(MoneyStream moneyStream);

        void DeleteMoneyStream(int moneyStreamId, string userId);

        decimal GetCurrentMonthDailyBudget(int bookId, string userId);
    }
}
