using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ManagementWebApp.Models
{
    public class Admindetails
    {
        public int id { get; set; }
        public string AdminName { get; set; }
        public string Password { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedOn { get; set; }
        public string UpdatedBy { get; set; }
        public Nullable<System.DateTime> UpdatedOn { get; set; }
        public string PhoneNo { get; set; }
        public string MailId { get; set; }
        public byte[] Image { get; set; }
        public int UserID { get; set; }
        public Nullable<bool> IsActive { get; set; }
    }
}