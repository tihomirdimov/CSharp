using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PersonalFinanceManager.Data.Data;
using PersonalFinanceManager.Data.Models;

namespace PersonalFinanceManager.Services.MoneyStreamsService
{
    public class MoneyStreamsService
    {
        public MoneyStreamsService(PfmDbContext context)
        {
            this.Context = context;
        }

        private PfmDbContext Context { get; set; }

        public bool CheckIfValidMoneyStream(int moneyStream, int book, string user)
        {
            var currentMoneystream = Context.MoneyStreams.FirstOrDefault(ms => ms.Id == moneyStream);
            var currentBook = Context.Books.FirstOrDefault(b => b.Id == book);
            if (currentMoneystream == null || currentBook == null)
            {
                return false;
            }
            if (currentMoneystream.Book.Id != currentBook.Id)
            {
                return false;
            }
            if (currentMoneystream.Owner.Id != user || currentBook.Owner.Id != user)
            {
                return false;
            }
            return true;
        }

        public MoneyStream GetMoneyStream(int moneyStream)
        {
            return Context.MoneyStreams.FirstOrDefault(ms => ms.Id == moneyStream);
        }

        public ICollection<MoneyStream> GetMoneyStreamsList(int book, string user)
        {
            return Context.MoneyStreams
                .Where(ms => ms.Owner.Id == user && ms.Book.Id == book && ms.IsDeleted == false)
                .OrderByDescending(ms => ms.Date).ToList();
        }

    }
}
