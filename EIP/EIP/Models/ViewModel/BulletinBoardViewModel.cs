using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EIP.Models.ViewModel
{
    public class BulletinBoardViewModel
    {
        [DisplayName("布告欄編號")]
        public int 佈告欄ID { get; set; }

        [DisplayName("員工編號")]
        public int EmployeeID { get; set; }

        [DisplayName("發佈人姓名")]
        [Required(ErrorMessage = "請輸入發佈人姓名")]
        public string 中文姓名 { get; set; }

        [DisplayName("佈告欄標題")]
        [Required(ErrorMessage = "請輸入佈告欄標題")]
        public string 佈告欄標題 { get; set; }

        [DisplayName("佈告欄內容")]
        public string 佈告欄內容 { get; set; }

        [DisplayName("發佈日期")]
        [Required(ErrorMessage = "請輸入發布日期")]
        public System.DateTime 發布日期 { get; set; }

        [DisplayName("訊息重要度")]
        [Required(ErrorMessage = "請輸入訊息重要度")]
        public string 訊息重要度 { get; set; }
    }
}