using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace QuanLyThuVien.Models {
    public class Book {
        [Key]
        public int ID { get; set; }

        [Required(ErrorMessage ="Publisher is required.")]
        [DisplayName("Publisher")]
        public int PublisherID { get; set; }

        [Required(ErrorMessage ="Category is required.")]
        [DisplayName("Category")]
        public int CategoryID { get; set; }

        [Required(ErrorMessage ="Author is required.")]
        [DisplayName("Author")]
        public int AuthorID { get; set; }

        [Required(ErrorMessage ="Name is required.")]
        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        [DefaultValue("~/Content/img/default-book-icon.png")]
        public string MdImage { get; set; }

        public virtual Publisher Publisher { get; set; }

        public virtual Category Category { get; set; }

        public virtual Author Author { get; set; }

        public virtual List<Order> Orders { get; set; }
    }
}