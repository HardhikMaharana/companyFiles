using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ManagementWebApp.Models
{
    public  class BookMyEventDbEntities : DbContext
    {
        public BookMyEventDbEntities()
            : base("DbContext")
        {
        }
      
            public  DbSet<BME_tblUserDetails> BME_tblUserDetails { get; set; }
        public  DbSet<BME_tblAdminDetails> BME_tblAdminDetails { get; set; }
        public  DbSet<BME_tblEventDb> BME_tblEventDb { get; set; }
        public  DbSet<BME_tblPropertyDb> BME_tblPropertyDb { get; set; }
        public  DbSet<BME_tblBookingDetailsDb> BME_tblBookingDetailsDb { get; set; }
        public  DbSet<BME_tblAdminImages> BME_tblAdminImages { get; set; }
    }
 }
    




