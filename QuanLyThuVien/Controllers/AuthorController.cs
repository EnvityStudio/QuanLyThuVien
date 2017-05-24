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
    public class AuthorController : Controller
    {
        private LibraryContext db = new LibraryContext();
        // GET: Author
        public ActionResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {

            ViewBag.CurrentSort = sortOrder;
            ViewBag.FirstNameSortParm = String.IsNullOrEmpty(sortOrder) ? "firstname_desc" : "";
            ViewBag.LastNameSortParm = String.IsNullOrEmpty(sortOrder) ? "lastname_desc" : "";
            ViewBag.CountrySortParm = String.IsNullOrEmpty(sortOrder) ? "country_desc" : "";
            ViewBag.GenderSortParm = String.IsNullOrEmpty(sortOrder) ? "gender_desc" : "";
            ViewBag.UidSortParm = String.IsNullOrEmpty(sortOrder) ? "uid_desc" : "";
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
            var libs = from l in db.Authors
                       select l;

            /*
                This code below is searching for the result of text in search text box
             */
            if (!String.IsNullOrEmpty(searchString))
            {
                libs = libs.Where(
                    l =>l.FirstName.Contains(searchString)
                    || l.LastName.Contains(searchString)
                    || l.Country.Contains(searchString)
                    || l.Gender.Contains(searchString)
                );
            }

            switch (sortOrder)
            {
                case "firstname_desc":
                    libs = libs.OrderByDescending(l => l.FirstName);
                    break;
                case "lastname_desc":
                    libs = libs.OrderByDescending(l => l.LastName);
                    break;
                case "country_desc":
                    libs = libs.OrderByDescending(l => l.Country);
                    break;
                case "gender_desc":
                    libs = libs.OrderByDescending(l => l.Gender);
                    break;
                default:
                    libs = libs.OrderBy(l => l.LastName);
                    break;
            }

            int pageSize = 4;
            int pageNumber = (page ?? 1);
            return View(libs.ToPagedList(pageNumber, pageSize));
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