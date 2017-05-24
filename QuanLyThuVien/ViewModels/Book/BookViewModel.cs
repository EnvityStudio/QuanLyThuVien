using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuanLyThuVien.ViewModels.Book {
    public class BookViewModel {
        public int ID { get; set; }

        public int PublisherID { get; set; }

        public int CategoryID { get; set; }

        public int AuthorID { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public string MdImage { get; set; }

        public IEnumerable<SelectListItem> Categories { get; set; } 
    }
}