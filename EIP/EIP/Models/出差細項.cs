//------------------------------------------------------------------------------
// <auto-generated>
//     這個程式碼是由範本產生。
//
//     對這個檔案進行手動變更可能導致您的應用程式產生未預期的行為。
//     如果重新產生程式碼，將會覆寫對這個檔案的手動變更。
// </auto-generated>
//------------------------------------------------------------------------------

namespace EIP.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class 出差細項
    {
        public int 出差表編號 { get; set; }
        public int EmployeeID { get; set; }
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
        public string 審核狀態 { get; set; }
    }
}
