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
    public class AuthorController : Controller
    {
        private LibraryContext db = new LibraryContext();
        // GET: Author
        public ActionResult Index()
        {
            var authors = db.Authors.ToList();
            return View(authors);
        }

        // GET: User Create
        public ActionResult Create() {
            return View();
        }

        // POST: User Create
        [HttpPost]
        public ActionResult Create(Author author) {
            if (ModelState.IsValid) {
                using (LibraryContext db = new LibraryContext()) {
                    db.Authors.Add(author);
                    db.SaveChanges();
                }
                ModelState.Clear();
                ViewBag.Message = author.FirstName+ " " + author.LastName + "successfully";
            }
            return RedirectToAction("Index", "Author");
        }

        // GET Author Edit
        public ActionResult Edit(int ?id) {
            var author = db.Authors.Find(id);
            return View(author);
        }

        // POST Author edit
        [HttpPost]
        public ActionResult Edit(Author author) {
            if (ModelState.IsValid) {
                db.Entry(author).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(author);
        }

        // GET Author Delete
        public ActionResult Delete(int ?id) {
            var author = db.Authors.Find(id);
            return View(author);
        }

        // POST Author Delete
        [HttpPost]
        public ActionResult Delete(int id) {
            var author = db.Authors.Find(id);
            db.Authors.Remove(author);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


    }
}