using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace EIP.Models.ViewModel
{
    public class AskForViewModel
    {
        [DisplayName("編號")]
        public int EmployeeID { get; set; }
        public string 信箱 { get; set; }
        public string 部門 { get; set; }
        public int 假別ID { get; set; }
        public string 假別 { get; set; }
        public int 請假時數 { get; set; }
        public string 請假班別 { get; set; }
        public string 開始日期 { get; set; }
        public string 開始時間 { get; set; }
        public string 結束日期 { get; set; }
        public string 結束時間 { get; set; }
        public string 申請日期 { get; set; }
        public string 申請時間 { get; set; }
        public string 代理人 { get; set; }
        public string 審核狀態 { get; set; }

    }
}