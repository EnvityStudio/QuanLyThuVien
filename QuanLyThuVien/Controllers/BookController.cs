using QuanLyThuVien.DAL;
using QuanLyThuVien.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QuanLyThuVien.ViewModels;
using PagedList;
using QuanLyThuVien.ViewModels.Book;

namespace QuanLyThuVien.Controllers {
    public class BookController : Controller {
        private LibraryContext db = new LibraryContext();
        // GET: Book
        public ActionResult Index(string sortOrder, string currentFilter, string searchString, int? page) {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.PublisherSortParm = String.IsNullOrEmpty(sortOrder) ? "publisher_desc" : "";
            ViewBag.categorySortParm = String.IsNullOrEmpty(sortOrder) ? "category_desc" : "";
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.NameAuthorSortParm = String.IsNullOrEmpty(sortOrder) ? "name_author_desc" : "";
            ViewBag.PriceSortParm = String.IsNullOrEmpty(sortOrder) ? "price_desc" : "";
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
            var libs = from l in db.Books
                       select l;

            /*
                This code below is searching for the result of text in search text box
             */
            if (!String.IsNullOrEmpty(searchString))
            {
                libs = libs.Where(
                    l => l.Name.Contains(searchString)
                    || l.Author.FirstName.Contains(searchString)
                    || l.Publisher.Name.Contains(searchString)
                    || l.Description.Contains(searchString)
                    || l.Category.Name.Contains(searchString)
                    || l.Price.ToString().Contains(searchString)
                );
            }

            switch (sortOrder)
            {
                case "publisher_desc":
                    libs = libs.OrderByDescending(l => l.Publisher.Name);
                    break;
                case "category_desc":
                    libs = libs.OrderByDescending(l => l.Category.Name);
                    break;
                case "name_desc":
                    libs = libs.OrderByDescending(l => l.Name);
                    break;
                case "price_desc":
                    libs = libs.OrderByDescending(l => l.Price);
                    break;
                case "name_author_desc":
                    libs = libs.OrderByDescending(l => l.Author.LastName);
                    break;
                default:
                    libs = libs.OrderBy(l => l.Name);
                    break;
            }

            int pageSize = 5;
            int pageNumber = (page ?? 1);
            return View(libs.ToPagedList(pageNumber, pageSize));
        }

        // GET: Book Create
        public ActionResult Create() {
            IEnumerable<SelectListItem> categories = db.Categories.Select(
                    c => new SelectListItem { Value = c.ID.ToString(), Text = c.Name});
            IEnumerable<SelectListItem> publishers = db.Publishers.Select(
                    p => new SelectListItem { Value = p.ID.ToString(), Text = p.Name});
            IEnumerable<SelectListItem> authors = db.Authors.Select(
                    a => new SelectListItem { Value = a.ID.ToString(), Text = a.FirstName + " " + a.LastName });
            ViewBag.categories = categories;
            ViewBag.publishers = publishers;
            ViewBag.authors = authors;
            return View();
        }

        // POST: Book Create
        [HttpPost]
        public ActionResult Create(Book book, FormCollection form) {
            if (ModelState.IsValid) {
                using (LibraryContext db = new LibraryContext()) {
                    var categoryID = Int32.Parse(form["categories"].ToString());
                    var publisherID = Int32.Parse(form["publishers"].ToString());
                    var authorID = Int32.Parse(form["authors"].ToString());
                    book.CategoryID = categoryID;
                    book.PublisherID = publisherID;
                    book.AuthorID = authorID;
                    db.Books.Add(book);
                    db.SaveChanges();
                }
                ModelState.Clear();
            }
            return RedirectToAction("Index", "Book");
        }
        // GET Book Edit from ViewModel
        public ActionResult EditViewModel(int? id) {
            var book = db.Books.Find(id);
            var categories = db.Categories.ToList();
            var categoriesModel = new BookViewModel {
                CategoryID = book.CategoryID,
                Categories = categories.Select(x => new SelectListItem {
                    Value = x.ID.ToString(),
                    Text = x.Name.ToString()
                })
            };
            ViewBag.categories = categoriesModel;
            return View(book);
        }

        // GET Book Edit
        public ActionResult Edit(int? id) {
            var book = db.Books.Find(id);

            var categories = db.Categories.ToList();
            var publishers = db.Publishers.ToList();
            var authors = db.Authors.ToList();

            var selectListCategory = new SelectList(categories, "Id", "Name", book.CategoryID); 
            var selectListPublisher = new SelectList(publishers, "Id", "Name", book.PublisherID); 
            var selectListAuthor = new SelectList(authors, "Id", "FirstName", book.AuthorID);

            ViewData["Category"] = selectListCategory;
            ViewData["Publisher"] = selectListPublisher;
            ViewData["Author"] = selectListAuthor;

            ViewBag.Category = selectListCategory;
            ViewBag.Publisher = selectListPublisher;
            ViewBag.Author = selectListAuthor;

            return View(book);
        }

        // POST Book edit
        [HttpPost]
        public ActionResult Edit(Book book, FormCollection form) {
            if (ModelState.IsValid) {
                var categoryID = Int32.Parse(form["CategoryClass"].ToString());
                var publisherID = Int32.Parse(form["PublisherClass"].ToString());
                var authorID = Int32.Parse(form["AuthorClass"].ToString());
                book.CategoryID = categoryID;
                book.PublisherID = publisherID;
                book.AuthorID = authorID;
                db.Entry(book).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(book);
        }

        // GET Book Delete
        public ActionResult Delete(int? id) {
            var book = db.Books.Find(id);
            return View(book);
        }

        // POST Book Delete
        [HttpPost]
        public ActionResult Delete(int id) {
            var book = db.Books.Find(id);
            db.Books.Remove(book);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET Book Price Group
        public ActionResult About() {
            IQueryable<BookPriceGroup> data = from book in db.Books
                                              group book by book.Price into bookPrice
                                              select new BookPriceGroup() {
                                                  Price = bookPrice.Key,
                                                  PriceCount = bookPrice.Count()
                                              };
            return View(data.ToList());
        }
    }
}