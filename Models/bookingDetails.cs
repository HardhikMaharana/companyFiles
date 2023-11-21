using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ManagementWebApp.Models
{
    public class bookingDetails
    {
        public int id { get; set; }
        public string Username { get; set; }
        public string PropertyName { get; set; }
        public string DateTime { get; set; }
        public string Location { get; set; }
        public string EventName { get; set; }
        public Nullable<int> UserID { get; set; }
        public Nullable<int> PropertyId { get; set; }
        public Nullable<int> EventId { get; set; }
        public string PropertyAddress { get; set; }
        public Nullable<int> NumberOfSeats { get; set; }
        public string SeatsNumber { get; set; }
    }
}