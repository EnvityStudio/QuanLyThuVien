using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace QuanLyThuVien.Models {
    public class Author {
        [Key]
        public int ID { get; set; }

        [Required(ErrorMessage ="First Name is required.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage ="Last Name is required.")]
        public string LastName { get; set; }

        public string Gender { get; set; }

        public string Bio { get; set; }

        public string BirthDay { get; set; }

        public string Country { get; set; }

        [DefaultValue("~/Content/img/default-author-icon.png")]
        public string MdImage { get; set; }
    }
}