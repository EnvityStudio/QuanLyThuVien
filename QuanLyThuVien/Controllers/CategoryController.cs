using PagedList;
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
        public ActionResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            /*  
                If there are no texts to search, page number will set to one
             */
            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }
            ViewBag.CurrentFilter = searchString;
            /*  
                By using LINQ to select a list of librarians
             */
            var libs = from l in db.Categories
                       select l;

            /*
                This code below is searching for the result of text in search text box
             */
            if (!String.IsNullOrEmpty(searchString))
            {
                libs = libs.Where(
                    l => l.Name.Contains(searchString)
                    || l.Description.Contains(searchString)
                );
            }

            switch (sortOrder)
            {
                case "name_desc":
                    libs = libs.OrderByDescending(l => l.Name);
                    break;
                default:
                    libs = libs.OrderBy(l => l.Name);
                    break;
            }

            int pageSize = 5;
            int pageNumber = (page ?? 1);
            return View(libs.ToPagedList(pageNumber, pageSize));
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