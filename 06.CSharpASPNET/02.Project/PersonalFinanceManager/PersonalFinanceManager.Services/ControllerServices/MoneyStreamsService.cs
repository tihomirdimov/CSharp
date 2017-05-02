using System;
using System.Collections.Generic;
using System.Linq;
using PersonalFinanceManager.Data.Data;
using PersonalFinanceManager.Data.Models;

namespace PersonalFinanceManager.Services.ControllerServices
{
    public class MoneyStreamsService
    {
        public bool CheckIfValidMoneyStream(PfmDbContext context, int moneyStreamId, int bookId, string userId)
        {
            var currentMoneystream = context.MoneyStreams.FirstOrDefault(ms => ms.Id == moneyStreamId);
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

        public MoneyStream GetMoneyStream(PfmDbContext context, int moneyStreamId, string userId)
        {
            return context.MoneyStreams.FirstOrDefault(ms => ms.Id == moneyStreamId && ms.Owner.Id == userId);
        }

        public ICollection<MoneyStream> GetMoneyStreamsList(PfmDbContext context, int bookId, string userId)
        {
            return context.MoneyStreams
                .Where(ms => ms.Owner.Id == userId && ms.Book.Id == bookId && ms.IsDeleted == false)
                .OrderByDescending(ms => ms.Date).ToList();
        }

        public void SaveMoneyStream(PfmDbContext context, MoneyStream moneyStream)
        {
            context.MoneyStreams.Add(moneyStream);
            context.SaveChanges();
        }

        public void DeleteMoneyStream(PfmDbContext context, int moneyStreamId, string userId)
        {
            context.MoneyStreams.FirstOrDefault(c => c.Id == moneyStreamId && c.Owner.Id == userId).IsDeleted = true;
            context.SaveChanges();
        }

        public decimal GetCurrentMonthDailyBudget(PfmDbContext context, int bookId, string userId)
        {
            decimal expenses = context.MoneyStreams.Where(ms => ms.Book.Id == bookId &&
                                                    ms.Owner.Id == userId &&
                                                    ms.IsIncome == false &&
                                                    ms.IsDeleted == false &&
                                                    ms.Date.Month == DateTime.Today.Month).Sum(ms => ms.Amount);
            decimal incomes = context.MoneyStreams.Where(ms => ms.Book.Id == bookId &&
                                                    ms.Owner.Id == userId &&
                                                    ms.IsIncome == true &&
                                                    ms.IsDeleted == false &&
                                                    ms.Date.Month == DateTime.Today.Month).Sum(ms => ms.Amount);
            return (incomes-expenses)/30;
        }

    }
}
