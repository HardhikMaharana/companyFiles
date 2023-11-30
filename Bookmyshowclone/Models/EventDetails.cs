using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ManagementWebApp.Models
{
    public class EventDetails
    {
        public int id { get; set; }
        public string EventName { get; set; }
        public string Description { get; set; }
        public string EventType { get; set; }
        public string Duration { get; set; }
        public Nullable<System.DateTime> Date { get; set; }
        public string Language { get; set; }
        public string CasteName { get; set; }
        public byte[] Image { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedOn { get; set; }
        public string UpdatedBy { get; set; }
        public Nullable<System.DateTime> UpdatedOn { get; set; }
        public Nullable<bool> IsActive { get; set; }
    }
}