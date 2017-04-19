using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace QuanLyThuVien.Models {
    public class Category {
        [Key]
        public int ID { get; set; }

        [Required(ErrorMessage ="Name is required.")]
        public string Name { get; set; }

        public string Description { get; set; }
    }
}