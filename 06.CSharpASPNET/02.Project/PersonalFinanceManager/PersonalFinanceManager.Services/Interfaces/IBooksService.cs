using System.Collections.Generic;
using PersonalFinanceManager.Data.Models;

namespace PersonalFinanceManager.Services.Interfaces
{
    public interface IBooksService
    {
        Book GetBook(int bookId, string userId);

        ICollection<Book> GetBooks(string userId);

        bool CheckIfValidBook(int bookId, string userId);

        void SaveBook();

        void SaveBook(Book book);

        void DeleteBook(int bookId, string userId);
    }
}
