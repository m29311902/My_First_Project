using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EIP.Models.ViewModel
{
    public class Fullcalender
    {
        public int EventID { get; set; }
        public string Subject { get; set; }
        public string Description { get; set; }
        public System.DateTime Start { get; set; }
        public Nullable<System.DateTime> End { get; set; }
        public string ThemeColor { get; set; }
        public bool IsFullDay { get; set; }
    }
}