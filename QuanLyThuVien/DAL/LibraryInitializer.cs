using QuanLyThuVien.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuanLyThuVien.DAL {
    public class LibraryInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<LibraryContext>{
        protected override void Seed(LibraryContext context) {
            var librarians = new List<Librarian> {
                new Librarian {
                    UID = "admin", FirstName="Admin", LastName="Master", Gender="Male",
                    Password ="123", ConfirmPassword="123", Address="Cầu giấy", Email = "admin@gmail.com" },
                new Librarian {
                    UID = "huyenanh", FirstName="Huyền", LastName="Anh", Gender="Female",
                    Password ="123", ConfirmPassword="123", Address="Nghĩa Đô" , Email = "huyenanh@gmail.com"}
            };

            librarians.ForEach(libs => context.Librarians.Add(libs));

            context.SaveChanges();

            base.Seed(context);
        }
    }
}