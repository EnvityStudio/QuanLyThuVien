using QuanLyThuVien.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QuanLyThuVien.Models;

namespace QuanLyThuVien.Controllers {
    public class HomeController : Controller {

        private LibraryContext db = new LibraryContext();


        public ActionResult Index() {
            if (Session["ID"] != null) {
                var userName = Session["name"];
                ViewBag.UserName = userName;
            }
            return View();
        }

        public ActionResult About() {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact() {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Login() {
            ViewBag.Message = "Login";
            return View();
        }

        [HttpPost]
        public ActionResult CheckAccount(string uid, string password)
        {
            /* 
             This try catch to catch external error of system when data is indexing
             */
            var librarians = db.Librarians.ToList();

            return View();
        }


    }
}