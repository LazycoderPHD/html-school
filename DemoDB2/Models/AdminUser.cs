using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DemoDB2.Models
{
    public partial class AdminUser
    {
        [Required(ErrorMessage = "ID không được để trống...")]
        [Display(Name = "Mã User")]
        public int ID { get; set; }

        [Required(ErrorMessage = "Name not empty...")]
        [Display(Name = "Tên User")]
        public string NameUser { get; set; }

        [Display(Name = "Vị trí")]
        public string RoleUser { get; set; }

        [Required(ErrorMessage = "Pass not empty...")]
        [DataType(DataType.Password)]
        [Display(Name = "Nhập Mật khẩu")]
        public string PasswordUser { get; set; }

        [NotMapped]
        [Compare("PasswordUser", ErrorMessage = "Mật khẩu xác nhận không khớp")]
        [DataType(DataType.Password)]
        [Display(Name = "Nhập lại mật khẩu")]
        public string ConfirmPass { get; set; }

        [NotMapped]
        public string ErrorLogin { get; set; }
    }
}