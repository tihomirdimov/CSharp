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

        // GET: Books
        public ActionResult Index()
        {
            var current = User.Identity.GetUserId();
            BooksViewModel booksViewModel = new BooksViewModel();
            booksViewModel.Book = new Book();
            booksViewModel.Books = db.Books.Where(book => book.Owner.Id == current && book.isDeleted == false).ToList();
            return View(booksViewModel);
        }

        // GET: Books/Details/5
        public ActionResult Details(int id)
        {
            var current = User.Identity.GetUserId();
            Book book = db.Books.First(b => b.Id == id);
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            if (book == null)
            {
                return HttpNotFound();
            }
            if (book.Owner.Id != current)
            {
                return RedirectToAction("Index");
            }
            return View(book);
        }

        // POST: Books/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Book book)
        {
            var current = User.Identity.GetUserId();
            if (ModelState.IsValid)
            {
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
            List<Book> model2 = db.Books.Where(b => b.Owner.Id == current && b.isDeleted == false).ToList();
            return this.PartialView("_BooksListPartial", model2);
        }

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
