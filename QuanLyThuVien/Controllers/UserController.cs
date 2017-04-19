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
        public ActionResult Index()
        {
            var users = db.Users.ToList();
            return View(users);
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