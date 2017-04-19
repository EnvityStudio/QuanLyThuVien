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
    public class PublisherController : Controller
    {
        private LibraryContext db = new LibraryContext();
        // GET: Publisher
        public ActionResult Index()
        {
            var publishers = db.Publishers.ToList();
            return View(publishers);
        }

        // GET: Publisher Create
        public ActionResult Create() {
            return View();
        }

        // POST: Publisher Create
        [HttpPost]
        public ActionResult Create(Publisher publisher) {
            if (ModelState.IsValid) {
                using (LibraryContext db = new LibraryContext()) {
                    db.Publishers.Add(publisher);
                    db.SaveChanges();
                }
                ModelState.Clear();
            }
            return RedirectToAction("Index", "Publisher");
        }

        // GET Publisher Edit
        public ActionResult Edit(int ?id) {
            var publisher = db.Publishers.Find(id);
            return View(publisher);
        }

        // POST Publisher edit
        [HttpPost]
        public ActionResult Edit(Publisher publisher) {
            if (ModelState.IsValid) {
                db.Entry(publisher).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(publisher);
        }

        // GET Publisher Delete
        public ActionResult Delete(int ?id) {
            var publisher = db.Publishers.Find(id);
            return View(publisher);
        }

        // POST Publisher Delete
        [HttpPost]
        public ActionResult Delete(int id) {
            var publisher = db.Publishers.Find(id);
            db.Publishers.Remove(publisher);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}