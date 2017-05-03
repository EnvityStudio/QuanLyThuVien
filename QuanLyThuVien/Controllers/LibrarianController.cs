using QuanLyThuVien.DAL;
using QuanLyThuVien.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PagedList;
using System.Data.Entity.Infrastructure;

namespace QuanLyThuVien.Controllers
{
    public class LibrarianController : Controller
    {
        private LibraryContext db = new LibraryContext();

        // GET: Librarian
        public ActionResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.FirstNameSortParm = String.IsNullOrEmpty(sortOrder) ? "firstname_desc" : "";
            ViewBag.LastNameSortParm = String.IsNullOrEmpty(sortOrder) ? "lastname_desc" : "";
            ViewBag.UidSortParm = String.IsNullOrEmpty(sortOrder) ? "uid_desc" : "";
            /*  
                If there are no texts to search, page number will set to one
             */
            if (searchString != null) {
                page = 1;
            } else {
                searchString = currentFilter;
            }
            ViewBag.CurrentFilter = searchString;
            /*  
                By using LINQ to select a list of librarians
             */
            var libs = from l in db.Librarians
                       select l;

            /*
                This code below is searching for the result of text in search text box
             */
            if (!String.IsNullOrEmpty(searchString)) {
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

            switch (sortOrder) {
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
            return View(libs.ToPagedList(pageNumber, pageSize));
        }

        // GET Librarian Create
        public ActionResult Register() {
            if (Session["ID"] == null) {
                return View();
            } else {
                return RedirectToAction("Index", "Home");
            }
        }

        // POST Librarian Create
        [HttpPost]
        public ActionResult Register(Librarian librarian) {
            if (ModelState.IsValid) {
                using (LibraryContext db = new LibraryContext()) {
                    db.Librarians.Add(librarian);
                    db.SaveChanges();
                }
                ModelState.Clear();
                ViewBag.Message = librarian.FirstName + " " + librarian.LastName + "successfully";
            }
            return RedirectToAction("Login");
        }

        // GET Login Librarian
        public ActionResult Login() {
            // Clear Username and Password textBox
            ModelState.Clear();
            return View();
        }

        // POST Login Librarian
        [HttpPost]
        public ActionResult Login(Librarian librarian) {
            using (LibraryContext db = new LibraryContext()) {
                try {
                    var user = db.Librarians.Single(u => u.UID == librarian.UID && u.Password == librarian.Password);
                    if (user != null) {
                        Session["ID"] = user.ID.ToString();
                        Session["UID"] = user.UID.ToString();
                        Session["Name"] = user.FirstName.ToString() + user.LastName.ToString();
                        return RedirectToAction("Index", "Home");
                    }
                    else {
                        ModelState.AddModelError("", "Username or Password is wrong");
                    }
                } catch(Exception e) {
                    ModelState.AddModelError("", e.Message);
                }
            }
            return View();
        }

        public ActionResult LoggedIn() {
            if (Session["ID"] != null) {
                return View();
            } else {
                return RedirectToAction("Login");
            }
        }

        public ActionResult Logout() {
            Session.Clear();
            return RedirectToAction("Index", "Home");
        }

        // GET: Librarian Create
        public ActionResult Create() {
            return View();
        }

        // POST: Librarian Create
        [HttpPost]
        public ActionResult Create(Librarian lib) {
            if (ModelState.IsValid) {
                using (LibraryContext db = new LibraryContext()) {
                    db.Librarians.Add(lib);
                    db.SaveChanges();
                }
                ModelState.Clear();
            }
            return RedirectToAction("Index", "Librarian");
        }

        // Edit Librarian
        public ActionResult Edit(int ?id) { 
            if (id == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Librarian libs = db.Librarians.Find(id);
            if (libs == null) {
                return HttpNotFound();
            }
            return View(libs);
        }

        [HttpPost]
        public ActionResult Edit(Librarian librarian) {
            if (ModelState.IsValid) {
                db.Entry(librarian).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(librarian);
        }

        //Delete librarian
        public ActionResult Delete(int ?id) {
            Librarian libs = db.Librarians.Find(id);
            return View(libs);
        }

        [HttpPost]
        public ActionResult Delete(Librarian librarian, int ?id) {
            Librarian libs = db.Librarians.Find(id);
            if (libs != null) {
                db.Librarians.Remove(libs);
                db.SaveChanges();
            } else {
                return HttpNotFound();
            }
            return RedirectToAction("Index", "Librarian");
        }
    }
}