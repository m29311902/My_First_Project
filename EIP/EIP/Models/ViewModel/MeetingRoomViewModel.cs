using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EIP.Models.ViewModel
{
    public class MeetingRoomViewModel
    {
        public int BookingId { get; set; }
        public DateTime BookingDate { get; set; }
        public DateTime BookingStartTime { get; set; }
        public DateTime BookingEndTime { get; set; }
        public string MeetingRemark { get; set; }
        public string MeetingSubject { get; set; }
        public string MeetingAttentee { get; set; }
        public int MeetingRoomId{get; set;}
        public string MeetingRoomName { get; set; }     
        public string Description { get; set; }
        public string 中文姓名 { get; set; }
        public int EmployeeID { get; set; }
        public bool IsAllDay { get; set; }
        public int Status { get; set; }

    }
}