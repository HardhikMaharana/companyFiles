using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ManagementWebApp.Models
{
    [Table("BME_tblAdminDetails")]
    public class BME_tblAdminDetails { 
        public int id { get; set; }
        public string AdminName { get; set; }
        public string Password { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedOn { get; set; }
        public string UpdatedBy { get; set; }
        public Nullable<System.DateTime> UpdatedOn { get; set; }
        public string PhoneNo { get; set; }
        public string MailId { get; set; }
        public Nullable<bool> IsActive { get; set; }
    }
    [Table("BME_tblBookingDetailsDb")]
    public  class BME_tblBookingDetailsDb
    {
        public int id { get; set; }
        public string Username { get; set; }
        public string PropertyName { get; set; }
        public string DateTime { get; set; }
        public string Location { get; set; }
        public string EventName { get; set; }
        public int UserID { get; set; }
        public int PropertyId { get; set; }
        public int EventId { get; set; }
        public string PropertyAddress { get; set; }
        public int NumberOfSeats { get; set; }
        public string SeatsNumber { get; set; }
        public Nullable<bool> IsActive { get; set; }
    }
    [Table("BME_tblEventDb")]
    public  class BME_tblEventDb
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
    [Table("BME_tblPropertyDb")]
    public  class BME_tblPropertyDb
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
        public int CurrentEvent_Id { get; set; }
        public string NoOfSeatsBooked { get; set; }
        public string SeatNumber { get; set; }
    }
    [Table("BME_tblUserDetails")]
    public  class BME_tblUserDetails
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PhoneNo { get; set; }
        public string Role { get; set; }
        public string MailId { get; set; }
        public string Password { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedOn { get; set; }
        public string UpdatedBy { get; set; }
        public Nullable<System.DateTime> UpdatedOn { get; set; }
        public Nullable<bool> IsActive { get; set; }
    }
    [Table("BME_tblAdminImages")]
    public class BME_tblAdminImages
    {
        public int ID { get; set; }
        public byte[] Image { get; set; }
        public int UserID { get; set; }
    }
}