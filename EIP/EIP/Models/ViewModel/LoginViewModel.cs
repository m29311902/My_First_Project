using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EIP.Models.ViewModel
{
    public class LoginViewModel
    {
        [DisplayName("員工帳號／信箱")]
        [Required(ErrorMessage = "請輸入員工帳號")]
        public string 信箱 { get; set; }

        [DisplayName("員工編號")]
        public int EmployeeID { get; set; }
        [DisplayName("員工密碼")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "請輸入員工密碼")]
        public string EmployeePW { get; set; }
        [DisplayName("記住我")]
        public bool RememberMe { get; set; }
    }
}