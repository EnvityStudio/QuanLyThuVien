using QuanLyThuVien.DAL;
using QuanLyThuVien.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuanLyThuVien.Controllers
{
    public class BookController : Controller
    {
        private LibraryContext db = new LibraryContext();
        // GET: Book
        public ActionResult Index()
        {
            var books = db.Books.ToList();
            return View(books);
        }

        // GET: Book Create
        public ActionResult Create() {
            return View();
        }

        // POST: Book Create
        [HttpPost]
        public ActionResult Create(Book book) {
            if (ModelState.IsValid) {
                using (LibraryContext db = new LibraryContext()) {
                    db.Books.Add(book);
                    db.SaveChanges();
                }
                ModelState.Clear();
            }
            return RedirectToAction("Index", "Book");
        }

        // GET Book Edit
        public ActionResult Edit(int ?id) {
            var book = db.Books.Find(id);
            return View(book);
        }

        // POST Book edit
        [HttpPost]
        public ActionResult Edit(Book book) {
            if (ModelState.IsValid) {
                db.Entry(book).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(book);
        }

        // GET Book Delete
        public ActionResult Delete(int ?id) {
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

    }
}