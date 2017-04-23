using System.Collections.Generic;
using PersonalFinanceManager.Data.Models;

namespace PersonalFinanceManager.ViewModels.Books
{
    public class BooksViewModel
    {
        public BooksViewModel()
        {
            this.Book = new Book();
            this.Books = new List<Book>();
        }
        public Book Book { get; set; }
        public ICollection<Book> Books { get; set; }
    }
}