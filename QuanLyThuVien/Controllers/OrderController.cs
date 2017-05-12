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
    public class OrderController : Controller
    {
        private LibraryContext db = new LibraryContext();
        // GET: Order
        public ActionResult Index()
        {

        }

        // GET Order Create
        public ActionResult Create() {
            
        }

        // POST Order Create
        [HttpPost]
        public ActionResult Create(Order order, FormCollection form) {
            
        }

        // GET Order Edit
        public ActionResult Edit(int? id) {
            var order = db.Orders.Find(id);
            IEnumerable<SelectListItem> users = db.Users.Select(
                    c => new SelectListItem { Value = c.ID.ToString(), Text = c.FirstName + " " + c.LastName});
            IEnumerable<SelectListItem> books = db.Books.Select(
                    b => new SelectListItem { Value = b.ID.ToString(), Text = b.Name});
            ViewBag.Users = users ;
            ViewBag.Books = books;
            return View(order);
        }

        // POST Book edit
        [HttpPost]
        public ActionResult Edit(Order order, FormCollection form) {
            if (ModelState.IsValid) {
                var UserID = Int32.Parse(form["Users"].ToString());
                var BookID = Int32.Parse(form["Books"].ToString());
                order.UserID = UserID;
                order.BookID = BookID;
                db.Entry(order).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(order);
        }

        // GET Delete
        public ActionResult Delete(int? id) {
            var order = db.Orders.Find(id);
            return View(order);
        }

        // POST Book Delete
        [HttpPost]
        public ActionResult Delete(int id) {
            var order = db.Orders.Find(id);
            db.Orders.Remove(order);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}