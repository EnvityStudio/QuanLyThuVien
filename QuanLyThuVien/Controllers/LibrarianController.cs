using QuanLyThuVien.DAL;
using QuanLyThuVien.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace QuanLyThuVien.Controllers
{
    public class LibrarianController : Controller
    {
        private LibraryContext db = new LibraryContext();
        // GET: Librarian
        public ActionResult Index()
        {
            if (Session["ID"] != null) {
                using (LibraryContext db = new LibraryContext()) {
                    return View(db.Librarians.ToList());
                }
            } else {
                return RedirectToAction("Login");
            }
        }

        public ActionResult Register() {
            return View();
        }

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

        //Login
        public ActionResult Login() {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Librarian librarian) {
            using (LibraryContext db = new LibraryContext()) {
                try {
                    var user = db.Librarians.Single(u => u.UID == librarian.UID && u.Password == librarian.Password);
                    if (user != null) {
                        Session["ID"] = user.ID.ToString();
                        Session["UID"] = user.UID.ToString();
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

        // Edit libraian
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

    }
}