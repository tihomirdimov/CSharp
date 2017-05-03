using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using PersonalFinanceManager.Data.Data;
using PersonalFinanceManager.Data.Models;
using PersonalFinanceManager.Services.Interfaces;

namespace PersonalFinanceManager.Services.ControllerServices
{
    public class BooksService : IBooksService
    {
        private readonly PfmDbContext _context;

        public BooksService()
        {
            _context = new PfmDbContext();        
        }

        public Book GetBook(int bookId, string userId)
        {
            return _context.Books.FirstOrDefault(b => b.Id == bookId && b.Owner.Id == userId);
        }

        public ICollection<Book> GetBooks(string userId)
        {
            return _context.Books.Where(b => b.Owner.Id == userId && b.IsDeleted == false).OrderBy(b => b.Name).ToList();
        }

        public bool CheckIfValidBook(int bookId, string userId)
        {
            var currentBook = _context.Books.FirstOrDefault(b => b.Id == bookId);
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
            _context.SaveChanges();
        }

        public void SaveBook(Book book)
        {
            _context.Books.Add(book);
            _context.SaveChanges();
        }

        public void DeleteBook(int bookId, string userId)
        {
            _context.Books.FirstOrDefault(b => b.Id == bookId && b.Owner.Id == userId).IsDeleted = true;
            _context.SaveChanges();
        }
    }
}
