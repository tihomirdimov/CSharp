using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using PersonalFinanceManager.Data.Data;
using PersonalFinanceManager.Data.Models;

namespace PersonalFinanceManager.Services.ControllerServices
{
    public class BooksService
    {
        public Book GetBook(PfmDbContext context, int bookId, string userId)
        {
            return context.Books.FirstOrDefault(b => b.Id == bookId && b.Owner.Id == userId);
        }

        public ICollection<Book> GetBooks(PfmDbContext context, string userId)
        {
            return context.Books.Where(b => b.Owner.Id == userId && b.IsDeleted == false).OrderBy(b => b.Name).ToList();
        }

        public bool CheckIfValidBook(PfmDbContext context, int bookId, string userId)
        {
            var currentBook = context.Books.FirstOrDefault(b => b.Id == bookId);
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

        public void SaveBook(PfmDbContext context)
        {
            context.SaveChanges();
        }

        public void SaveBook(PfmDbContext context, Book book)
        {
            context.Books.Add(book);
            context.SaveChanges();
        }

        public void DeleteBook(PfmDbContext context, int bookId, string userId)
        {
            context.Books.FirstOrDefault(b => b.Id == bookId && b.Owner.Id == userId).IsDeleted = true;
            context.SaveChanges();
        }
    }
}
