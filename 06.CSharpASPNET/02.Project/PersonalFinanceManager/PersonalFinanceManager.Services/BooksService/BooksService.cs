using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using PersonalFinanceManager.Data.Data;
using PersonalFinanceManager.Data.Models;

namespace PersonalFinanceManager.Services.BooksService
{
    public class BooksService : DbService
    {
        public Book GetBook(int bookId, string userId)
        {
            return Context.Books.FirstOrDefault(b => b.Id == bookId && b.Owner.Id == userId);
        }

        public ICollection<Book> GetBooks(string userId)
        {
            return Context.Books.Where(b => b.Owner.Id == userId && b.isDeleted == false).OrderBy(b=>b.Name).ToList();
        }

        public bool CheckIfValidBook(int bookId, string userId)
        {
            var currentBook = Context.Books.FirstOrDefault(b => b.Id == bookId);
            if (currentBook == null)
            {
                return false;
            }
            if (currentBook.Owner.Id != userId)
            {
                return false;
            }
            return true;
        }

        public void SaveBook()
        {
            Context.SaveChanges();
        }

        public void SaveBook(Book book)
        {
            Context.Books.Add(book);
            Context.SaveChanges();
        }

        public void DeleteBook(int bookId, string userId)
        {
            Context.Books.FirstOrDefault(b => b.Id == bookId && b.Owner.Id == userId).isDeleted = true;
            Context.SaveChanges();
        }
    }
}
