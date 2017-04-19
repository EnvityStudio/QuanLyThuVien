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
    public class CategoryController : Controller
    {
        private LibraryContext db = new LibraryContext();
        // GET: Category
        public ActionResult Index()
        {
            var categorys = db.Categories.ToList();
            return View(categorys);
        }

        // GET: Category Create
        public ActionResult Create() {
            return View();
        }

        // POST: Category Create
        [HttpPost]
        public ActionResult Create(Category category) {
            if (ModelState.IsValid) {
                using (LibraryContext db = new LibraryContext()) {
                    db.Categories.Add(category);
                    db.SaveChanges();
                }
                ModelState.Clear();
            }
            return RedirectToAction("Index", "Category");
        }

        // GET Category Edit
        public ActionResult Edit(int ?id) {
            var category = db.Categories.Find(id);
            return View(category);
        }

        // POST Category edit
        [HttpPost]
        public ActionResult Edit(Category category) {
            if (ModelState.IsValid) {
                db.Entry(category).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(category);
        }

        // GET Category Delete
        public ActionResult Delete(int ?id) {
            var category = db.Categories.Find(id);
            return View(category);
        }

        // POST Category Delete
        [HttpPost]
        public ActionResult Delete(int id) {
            var category = db.Categories.Find(id);
            db.Categories.Remove(category);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}