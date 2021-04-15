using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EIP.Models.ViewModel
{
    public class OverTimeViewModel
    {
        public int 加班表編號 { get; set; }
        public int EmployeeID { get; set; }
        public string 中文姓名 { get; set; }
        public string 部門 { get; set; }
        public Nullable<int> 加班ID { get; set; }
        public Nullable<int> 已用可用 { get; set; }
        public Nullable<System.DateTime> 開始日期 { get; set; }
        public Nullable<System.DateTime> 結束日期 { get; set; }
        public Nullable<int> 加班時數 { get; set; }
        public string 加班類別 { get; set; }
        public string 事由說明 { get; set; }
        public string 主管簽核 { get; set; }
    }
}