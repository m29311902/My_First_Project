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
    
    public partial class pjReport
    {
        public int pjDayReportId { get; set; }
        public Nullable<int> pjId { get; set; }
        public string pjMemberId { get; set; }
        public string pjMemberName { get; set; }
        public string pjTask { get; set; }
        public string pjReportContent { get; set; }
        public string pjIssuelog { get; set; }
        public string pjObjective { get; set; }
        public string pjReportPreview { get; set; }
        public string pjLag { get; set; }
        public Nullable<decimal> pjEstimation { get; set; }
        public string pjReportDate { get; set; }
    
        public virtual pjProject pjProject { get; set; }
    }
}