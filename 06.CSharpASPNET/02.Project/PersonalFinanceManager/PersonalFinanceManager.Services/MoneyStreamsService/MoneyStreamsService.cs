using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PersonalFinanceManager.Data.Data;
using PersonalFinanceManager.Data.Models;

namespace PersonalFinanceManager.Services.MoneyStreamsService
{
    public class MoneyStreamsService : DbService
    {
        public bool CheckIfValidMoneyStream(int moneyStreamId, int bookId, string userId)
        {
            var currentMoneystream = Context.MoneyStreams.FirstOrDefault(ms => ms.Id == moneyStreamId);
            if (currentMoneystream == null)
            {
                return false;
            }
            if (currentMoneystream.Book.Id != bookId)
            {
                return false;
            }
            if (currentMoneystream.Owner.Id != userId)
            {
                return false;
            }
            return true;
        }

        public MoneyStream GetMoneyStream(int moneyStreamId, string userId)
        {
            return Context.MoneyStreams.FirstOrDefault(ms => ms.Id == moneyStreamId && ms.Owner.Id == userId);
        }

        public ICollection<MoneyStream> GetMoneyStreamsList(int bookId, string userId)
        {
            return Context.MoneyStreams
                .Where(ms => ms.Owner.Id == userId && ms.Book.Id == bookId && ms.IsDeleted == false)
                .OrderByDescending(ms => ms.Date).ToList();
        }

        public void SaveMoneyStream(MoneyStream moneyStream)
        {
            Context.MoneyStreams.Add(moneyStream);
            Context.SaveChanges();
        }

        public void DeleteMoneyStream(int moneyStreamId, string userId)
        {
            Context.MoneyStreams.FirstOrDefault(c => c.Id == moneyStreamId && c.Owner.Id == userId).IsDeleted = true;
            Context.SaveChanges();
        }

        public ICollection<MoneyStream> GetCurrentMonthExpenses(int bookId, DateTime monthDateTime)
        {
            DateTime from = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            return Context.MoneyStreams.Where(ms => ms.Book.Id == bookId && ms.Date >= from && ms.IsIncome == false && ms.IsDeleted == false).ToList();

        }

        public ICollection<MoneyStream> GetCurrentMonthIncomes(int bookId, DateTime monthDateTime)
        {
            DateTime from = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            return Context.MoneyStreams.Where(ms => ms.Book.Id == bookId && ms.Date >= from && ms.IsIncome == true && ms.IsDeleted == false).ToList();
        }
    }
}
