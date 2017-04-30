using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using PersonalFinanceManager.Data.Data;
using PersonalFinanceManager.Data.Models;
using PersonalFinanceManager.ViewModels.Books;

namespace PersonalFinanceManager.Controllers
{
    [Authorize]
    public class BooksController : Controller
    {
        private PfmDbContext db = new PfmDbContext();

        public ActionResult Index()
        {
            var current = User.Identity.GetUserId();
            BooksViewModel booksViewModel = new BooksViewModel();
            booksViewModel.Book = new Book();
            booksViewModel.Books = db.Books.Where(book => book.Owner.Id == current && book.isDeleted == false).ToList();
            return View(booksViewModel);
        }

        [ChildActionOnly]
        public ActionResult Details(int id)
        {
            if (db.Books.First(b => b.Id == id).Owner.Id != User.Identity.GetUserId())
            {
                return RedirectToAction("Index");
            }
            var current = User.Identity.GetUserId();
            BookDetailsViewModel model = new BookDetailsViewModel();
            model.Book = db.Books.First(b => b.Id == id);
            return View(model);
        }

        [ChildActionOnly]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Book book)
        {
            var current = User.Identity.GetUserId();
            if (db.Books.FirstOrDefault(b => b.Id == book.Id) != null)
            {
                db.Books.FirstOrDefault(b => b.Id == book.Id).Name = book.Name;
                db.Books.FirstOrDefault(b => b.Id == book.Id).Currency = book.Currency;
                db.SaveChanges();
            }
            else
            {
                var owner = db.Users.FirstOrDefault(user => user.Id == current);
                Book toAdd = new Book();
                toAdd.Name = book.Name;
                toAdd.Currency = book.Currency;
                toAdd.Owner = owner;
                db.Books.Add(toAdd);
                db.SaveChanges();
            }
            List<Book> model = db.Books.Where(b => b.Owner.Id == current && b.isDeleted == false).ToList();
            return this.PartialView("_BooksListPartial", model);
        }

        [ChildActionOnly]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id)
        {
            var current = User.Identity.GetUserId();
            Book model = db.Books.FirstOrDefault(cat => cat.Owner.Id == current && cat.Id == id);
            return this.PartialView("_BooksCreatePartial", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            db.Books.FirstOrDefault(b => b.Id == id).isDeleted = true;
            db.SaveChanges();
            var current = User.Identity.GetUserId();
            List<Book> model = db.Books.Where(b => b.Owner.Id == current && b.isDeleted == false).ToList();
            return this.PartialView("_BooksListPartial", model);
        }
    }
}
