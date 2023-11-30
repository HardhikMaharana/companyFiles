using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ManagementWebApp.Models
{
    public class PropertyModels
    {
        public int Id { get; set; }
        public string PropertyName { get; set; }
        public string PropertyLocation { get; set; }
        public string PropertyAddress { get; set; }
        public string Price { get; set; }
        public string NoOfSeats { get; set; }
        public string Time { get; set; }
        public int CurrentEvent_Id { get; set; }
    }
    public class UserModels
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PhoneNo { get; set; }
        public string Role { get; set; }
        public string MailId { get; set; }
       
        public Nullable<bool> IsActive { get; set; }
    }

    public class EventModels
    {
        public int id { get; set; }
        public string EventName { get; set; }
        public string Description { get; set; }
        public string EventType { get; set; }
        public string Duration { get; set; }
        public Nullable<System.DateTime> Date { get; set; }
        public byte[] Image { get; set; }
        public string Language { get; set; }
        public string CasteName { get; set; }
        public Nullable<bool> IsActive { get; set; }
    }
    public class dashboardModels
    {
        public int x { get; set; }
        public int y { get; set; }
        public int z { get; set; }
        public int a { get; set; }
    }
    public  class movieBookingModels
    {
        public int eventid { get; set; }
        public string EventName { get; set; }
        public string Description { get; set; }
        public string EventType { get; set; }
        public string Duration { get; set; }
        public Nullable<System.DateTime> Date { get; set; }
        public byte[] Image { get; set; }
        public string Language { get; set; }
        public string CasteName { get; set; }
        public Nullable<bool> IsActive { get; set; }

        public int propertyId { get; set; }
        public string PropertyName { get; set; }
        public string PropertyLocation { get; set; }
        public string PropertyAddress { get; set; }
        public string Price { get; set; }
        public string NoOfSeats { get; set; }
        public string Time { get; set; }
        public int CurrentEvent_Id { get; set; }
        public string NoOfSeatsBooked { get; set; }
        public string SeatNumber { get; set; }

        public int UserId { get; set; }
        public string Name { get; set; }
        public string PhoneNo { get; set; }
        public string Role { get; set; }
        public string MailId { get; set; }

        public int Bookingid { get; set; }
        public string Username { get; set; }
        public string BookingPropertyName { get; set; }
        public string DateTime { get; set; }
        public string Location { get; set; }
        public string BookingEventName { get; set; }
        public int Event_Id { get; set; }
        public int NumberOfSeats { get; set; }
        public string SeatsNumber { get; set; }
    }
    public class TotalDataModel
    {

    }

    public class AdminModels
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
    }
}