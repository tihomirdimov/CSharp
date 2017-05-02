using System.Collections.Generic;
using PersonalFinanceManager.Data.Models;

namespace PersonalFinanceManager.ViewModels.Books
{
    public class BooksVM
    {
        public BooksVM()
        {
            this.BookFormVm = new BooksFormVM();
            this.Books = new List<Book>();
        }
        public BooksFormVM BookFormVm { get; set; }
        public ICollection<Book> Books { get; set; }
    }
}