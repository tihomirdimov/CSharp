using System;
using System.Collections.Generic;
using System.Linq;
using PersonalFinanceManager.Data.Data;
using PersonalFinanceManager.Data.Models;
using PersonalFinanceManager.Services.Interfaces;

namespace PersonalFinanceManager.Services.ControllerServices
{
    public class MoneyStreamsService : IMoneyStreamsService
    {
        private readonly PfmDbContext _context;

        public MoneyStreamsService()
        {
            _context = new PfmDbContext();
        }

        public bool CheckIfValidMoneyStream(int moneyStreamId, int bookId, string userId)
        {
            var currentMoneystream = _context.MoneyStreams.FirstOrDefault(ms => ms.Id == moneyStreamId);
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
            return _context.MoneyStreams.FirstOrDefault(ms => ms.Id == moneyStreamId && ms.Owner.Id == userId);
        }

        public ICollection<MoneyStream> GetMoneyStreamsList(int bookId, string userId)
        {
            return _context.MoneyStreams
                .Where(ms => ms.Owner.Id == userId && ms.Book.Id == bookId && ms.IsDeleted == false)
                .OrderByDescending(ms => ms.Date).ToList();
        }

        public void SaveMoneyStream(MoneyStream moneyStream)
        {
            _context.MoneyStreams.Add(moneyStream);
            _context.SaveChanges();
        }

        public void DeleteMoneyStream(int moneyStreamId, string userId)
        {
            _context.MoneyStreams.FirstOrDefault(c => c.Id == moneyStreamId && c.Owner.Id == userId).IsDeleted = true;
            _context.SaveChanges();
        }

        public decimal GetCurrentMonthDailyBudget(int bookId, string userId)
        {
            decimal expenses = _context.MoneyStreams.Where(ms => ms.Book.Id == bookId &&
                                                    ms.Owner.Id == userId &&
                                                    ms.IsIncome == false &&
                                                    ms.IsDeleted == false &&
                                                    ms.Date.Month == DateTime.Today.Month).Sum(ms => ms.Amount);
            decimal incomes = _context.MoneyStreams.Where(ms => ms.Book.Id == bookId &&
                                                    ms.Owner.Id == userId &&
                                                    ms.IsIncome == true &&
                                                    ms.IsDeleted == false &&
                                                    ms.Date.Month == DateTime.Today.Month).Sum(ms => ms.Amount);
            return (incomes-expenses)/30;
        }

    }
}
