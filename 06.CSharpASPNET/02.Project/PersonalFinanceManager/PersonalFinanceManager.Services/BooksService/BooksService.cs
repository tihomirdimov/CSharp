using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PersonalFinanceManager.Data.Data;
using PersonalFinanceManager.Data.Models;

namespace PersonalFinanceManager.Services.BooksService
{
    public class BooksService
    {
        public BooksService(PfmDbContext context)
        {
            this.Context = context;
        }

        private PfmDbContext Context { get; set; }

        public bool CheckIfValidBook(int id, string user)
        {
            var currentBook = Context.Books.FirstOrDefault(b => b.Id == id);
            if (currentBook == null)
            {
                return false;
            }
            if (currentBook.Owner.Id != user)
            {
                return false;
            }
            return true;
        }

        public Book GetBook(int id)
        {
            return Context.Books.FirstOrDefault(b => b.Id == id);
        }
    }
}
