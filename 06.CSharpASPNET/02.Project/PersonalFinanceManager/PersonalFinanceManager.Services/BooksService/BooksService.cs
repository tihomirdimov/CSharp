using System.Collections.Generic;
using System.Linq;
using PersonalFinanceManager.Data.Models;

namespace PersonalFinanceManager.Services.BooksService
{
    public class BooksService : DbService
    {
        public Book GetBook(int bookId, string userId)
        {
            return this.Context.Books.FirstOrDefault(b => b.Id == bookId && b.Owner.Id == userId);
        }

        public ICollection<Book> GetBooks(string userId)
        {
            return this.Context.Books.Where(b => b.Owner.Id == userId && b.IsDeleted == false).OrderBy(b => b.Name).ToList();
        }

        public bool CheckIfValidBook(int bookId, string userId)
        {
            var currentBook = this.Context.Books.FirstOrDefault(b => b.Id == bookId);
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
            this.Context.SaveChanges();
        }

        public void SaveBook(Book book)
        {
            this.Context.Books.Add(book);
            this.Context.SaveChanges();
        }

        public void DeleteBook(int bookId, string userId)
        {
            this.Context.Books.FirstOrDefault(b => b.Id == bookId && b.Owner.Id == userId).IsDeleted = true;
            this.Context.SaveChanges();
        }
    }
}
