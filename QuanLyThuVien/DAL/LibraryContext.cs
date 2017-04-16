﻿using QuanLyThuVien.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace QuanLyThuVien.DAL {
    public class LibraryContext : DbContext {
        public LibraryContext() : base("LibraryContext") { }

        public DbSet<Librarian> Librarians { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder) {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}