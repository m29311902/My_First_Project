using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EIP.Models.ViewModel
{
    public class BusinessTripViewModel
    {
        public int 出差單編號 { get; set; }
        public Nullable<int> EmployeeID { get; set; }
        public string 中文姓名 { get; set; }
        public string 部門 { get; set; }
        public string 出差類型 { get; set; }
        public string 出差地點 { get; set; }
        public Nullable<System.DateTime> 開始日期 { get; set; }
        public Nullable<System.DateTime> 結束日期 { get; set; }
        public string 交通需求 { get; set; }
        public string 住宿需求 { get; set; }
        public Nullable<int> 預支費用 { get; set; }
        public string 備註 { get; set; }
    }
}