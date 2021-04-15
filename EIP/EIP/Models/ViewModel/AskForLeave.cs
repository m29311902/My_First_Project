using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EIP.Models.ViewModel
{
    public class AskForLeave
    {
        public int 申請表編號 { get; set; }
        public int EmployeeID { get; set; }
        public string 信箱 { get; set; }
        public string 部門 { get; set; }
        public Nullable<int> 假別ID { get; set; }
        public string 請假班別 { get; set; }
        public Nullable<int> 請假時數 { get; set; }
        public Nullable<System.DateTime> 開始日期 { get; set; }
        public Nullable<System.DateTime> 結束日期 { get; set; }
        public Nullable<System.DateTime> 申請日期 { get; set; }
        public string 代理人 { get; set; }
        public string 審核狀態 { get; set; }
        public string 中文姓名 { get; set; }
        public string 職稱 { get; set; }
        public string 假別1 { get; set; }

    }
}