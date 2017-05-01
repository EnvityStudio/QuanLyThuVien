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

        [Required(ErrorMessage ="Name is required.")]
        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public virtual Publisher Publisher { get; set; }
    }
}