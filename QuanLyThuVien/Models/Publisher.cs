using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace QuanLyThuVien.Models {
    public class Publisher {
        [Key]
        public int ID { get; set; }

        [Required(ErrorMessage ="Name is required.")]
        public string Name { get; set; }

        [Required(ErrorMessage ="Address is required.")]
        public string Address { get; set; }

        public string Phone { get; set; }

        public string Intro { get; set; }
    }
}