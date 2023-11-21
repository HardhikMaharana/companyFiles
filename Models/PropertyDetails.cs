using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ManagementWebApp.Models
{
    public class PropertyDetails
    {
        public int Id { get; set; }
        public string PropertyName { get; set; }
        public string PropertyLocation { get; set; }
        public string PropertyAddress { get; set; }
        public string Price { get; set; }
        public string NoOfSeats { get; set; }
        public string Time { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedOn { get; set; }
        public string UpdatedBy { get; set; }
        public Nullable<System.DateTime> UpdatedOn { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public  int CurrentEvent_Id { get; set; }
    }
}