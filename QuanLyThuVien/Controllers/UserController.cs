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
    public class UserController : Controller
    {
        private LibraryContext db = new LibraryContext();
        // GET: User
        public ActionResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.FirstNameSortParm = String.IsNullOrEmpty(sortOrder) ? "firstname_desc" : "";
            ViewBag.LastNameSortParm = String.IsNullOrEmpty(sortOrder) ? "lastname_desc" : "";
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
            var libs = from l in db.Users
                       select l;
            if (!String.IsNullOrEmpty(searchString))
            {
                libs = libs.Where(
                    l => l.UID.Contains(searchString)
                    || l.FirstName.Contains(searchString)
                    || l.FirstName.Contains(searchString)
                    || l.LastName.Contains(searchString)
                    || l.Email.Contains(searchString)
                    || l.Address.Contains(searchString)
                    || l.Phone.Contains(searchString)
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
                case "uid_desc":
                    libs = libs.OrderByDescending(l => l.UID);
                    break;
                default:
                    libs = libs.OrderBy(l => l.LastName);
                    break;
            }


            int pageSize = 3;
            int pageNumber = (page ?? 1);

            var users = db.Users.ToList();
            return View(libs.ToPagedList(pageNumber, pageSize));
        }

        // GET: User Create
        public ActionResult Create() {
            return View();
        }

        // POST: User Create
        [HttpPost]
        public ActionResult Create(User user) {
            if (ModelState.IsValid) {
                using (LibraryContext db = new LibraryContext()) {
                    db.Users.Add(user);
                    db.SaveChanges();
                }
                ModelState.Clear();
                ViewBag.Message = user.FirstName+ " " + user.LastName + "successfully";
            }
            return RedirectToAction("Index", "User");
        }

        // GET User Edit
        public ActionResult Edit(int ?id) {
            var user = db.Users.Find(id);
            return View(user);
        }

        // POST User edit
        [HttpPost]
        public ActionResult Edit(User user) {
            if (ModelState.IsValid) {
                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(user);
        }

        // GET User Delete
        public ActionResult Delete(int ?id) {
            var user = db.Users.Find(id);
            return View(user);
        }

        // POST User Delete
        [HttpPost]
        public ActionResult Delete(int id) {
            var user = db.Users.Find(id);
            db.Users.Remove(user);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}