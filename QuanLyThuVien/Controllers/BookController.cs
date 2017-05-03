using QuanLyThuVien.DAL;
using QuanLyThuVien.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QuanLyThuVien.ViewModels;

namespace QuanLyThuVien.Controllers {
    public class BookController : Controller {
        private LibraryContext db = new LibraryContext();
        // GET: Book
        public ActionResult Index() {
            var books = db.Books.ToList();
            return View(books);
        }

        // GET: Book Create
        public ActionResult Create() {
            IEnumerable<SelectListItem> categories = db.Categories.Select(
                    c => new SelectListItem { Value = c.ID.ToString(), Text = c.Name});
            IEnumerable<SelectListItem> publishers = db.Publishers.Select(
                    p => new SelectListItem { Value = p.ID.ToString(), Text = p.Name});
            IEnumerable<SelectListItem> authors = db.Authors.Select(
                    a => new SelectListItem { Value = a.ID.ToString(), Text = a.FirstName + " " + a.LastName });
            ViewBag.categories = categories;
            ViewBag.publishers = publishers;
            ViewBag.authors = authors;
            return View();
        }

        // POST: Book Create
        [HttpPost]
        public ActionResult Create(Book book, FormCollection form) {
            if (ModelState.IsValid) {
                using (LibraryContext db = new LibraryContext()) {
                    var categoryID = Int32.Parse(form["categories"].ToString());
                    var publisherID = Int32.Parse(form["publishers"].ToString());
                    var authorID = Int32.Parse(form["authors"].ToString());
                    book.CategoryID = categoryID;
                    book.PublisherID = publisherID;
                    book.AuthorID = authorID;
                    db.Books.Add(book);
                    db.SaveChanges();
                }
                ModelState.Clear();
            }
            return RedirectToAction("Index", "Book");
        }

        // GET Book Edit
        public ActionResult Edit(int? id) {
            var book = db.Books.Find(id);
            IEnumerable<SelectListItem> categories = db.Categories.Select(
                    c => new SelectListItem { Value = c.ID.ToString(), Text = c.Name});
            IEnumerable<SelectListItem> publishers = db.Publishers.Select(
                    p => new SelectListItem { Value = p.ID.ToString(), Text = p.Name});
            IEnumerable<SelectListItem> authors = db.Authors.Select(
                    a => new SelectListItem { Value = a.ID.ToString(), Text = a.FirstName + " " + a.LastName });
            ViewBag.categories = categories;
            ViewBag.publishers = publishers;
            ViewBag.authors = authors;
            return View(book);
        }

        // POST Book edit
        [HttpPost]
        public ActionResult Edit(Book book, FormCollection form) {
            if (ModelState.IsValid) {
                var categoryID = Int32.Parse(form["categories"].ToString());
                var publisherID = Int32.Parse(form["publishers"].ToString());
                var authorID = Int32.Parse(form["authors"].ToString());
                book.CategoryID = categoryID;
                book.PublisherID = publisherID;
                book.AuthorID = authorID;
                db.Entry(book).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(book);
        }

        // GET Book Delete
        public ActionResult Delete(int? id) {
            var book = db.Books.Find(id);
            return View(book);
        }

        // POST Book Delete
        [HttpPost]
        public ActionResult Delete(int id) {
            var book = db.Books.Find(id);
            db.Books.Remove(book);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET Book Price Group
        public ActionResult About() {
            IQueryable<BookPriceGroup> data = from book in db.Books
                                              group book by book.Price into bookPrice
                                              select new BookPriceGroup() {
                                                  Price = bookPrice.Key,
                                                  PriceCount = bookPrice.Count()
                                              };
            return View(data.ToList());
        }
    }
}