using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace QuanLyThuVien.Models {
    public class Order {
        [Key]
        public int ID { get; set; }

        [Required(ErrorMessage ="User is required.")]
        [DisplayName("User")]
        public int UserID { get; set; }

        [Required(ErrorMessage ="Book is required.")]
        [DisplayName("Book")]
        public int BookID { get; set; }

        [Required(ErrorMessage ="Borrowed Date is required.")]
        public DateTime BorrowedDate { get; set; }

        [Required(ErrorMessage ="Expired Date is required.")]
        public DateTime ExpiredDate { get; set; }

        [Required(ErrorMessage ="Number is required.")]
        public int Number { get; set; }

        public virtual User User { get; set; }

        public virtual Book Book{ get; set; }
    }
}