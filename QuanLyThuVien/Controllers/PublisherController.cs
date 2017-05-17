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
    public class PublisherController : Controller
    {
        private LibraryContext db = new LibraryContext();
        // GET: Publisher
        public ActionResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {

            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.AddressSortParm = String.IsNullOrEmpty(sortOrder) ? "address_desc" : "";
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
            var libs = from l in db.Publishers
                       select l;

            /*
                This code below is searching for the result of text in search text box
             */
            if (!String.IsNullOrEmpty(searchString))
            {
                libs = libs.Where(
                    l => l.Name.Contains(searchString)
                    || l.Phone.Contains(searchString)
                    || l.Intro.Contains(searchString)
                    || l.Address.Contains(searchString)
                );
            }

            switch (sortOrder)
            {
                case "name_desc":
                    libs = libs.OrderByDescending(l => l.Name);
                    break;
                case "address_desc":
                    libs = libs.OrderByDescending(l => l.Address);
                    break;
                default:
                    libs = libs.OrderBy(l => l.Name);
                    break;
            }

            int pageSize = 5;
            int pageNumber = (page ?? 1);
            return View(libs.ToPagedList(pageNumber, pageSize));
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