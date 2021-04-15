using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EIP.Models.ViewModel
{
    public class MemberViewModel
    {
        [DisplayName("員工編號")]
        public int EmployeeID { get; set; }
        [DisplayName("員工密碼")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "請輸入員工密碼")]
        public string EmployeePW { get; set; }
        [DisplayName("受雇日期")]
        public string 受雇日期 { get; set; }
        [DisplayName("中文姓名")]
        public string 中文姓名 { get; set; }
        [DisplayName("英文姓名")]
        public string 英文姓名 { get; set; }
        [DisplayName("員工職稱")]
        public string 職稱 { get; set; }
        public string 狀態 { get; set; }
        [DisplayName("部門")]
        public string 部門 { get; set; }
        [DisplayName("性別")]
        public string 性別 { get; set; }
        [DisplayName("出生年月日")]
        public string 出生年月日 { get; set; }
        [DisplayName("員工帳號／信箱")]
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "請輸入員工帳號")]
        public string 信箱 { get; set; }
        [DisplayName("電話")]
        public string 電話 { get; set; }
        [DisplayName("居住地")]
        public string 居住地 { get; set; }
        [DisplayName("婚姻狀況")]
        public string 婚姻狀況 { get; set; }
        [DisplayName("年資")]
        public string 年資 { get; set; }
        [DisplayName("薪資")]
        public string 薪資 { get; set; }
        [DisplayName("特休")]
        public string 特休 { get; set; }
        [DisplayName("權限")]
        public int 權限 { get; set; }
        public bool RememberMe { get; set; }
    }
}