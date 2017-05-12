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
            
        }

        // POST Book edit
        [HttpPost]
        public ActionResult Edit(Order order, FormCollection form) {
            
        }

        // GET Delete
        public ActionResult Delete(int? id) {
            
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