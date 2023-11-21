using ManagementWebApp.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;

namespace ManagementWebApp.Controllers
{
    public class WebpageHomeController : Controller
    {
        public ActionResult UserLoginPage()
        {
            return View();
        }

        public ActionResult UserLoginValidation(BME_tblUserDetails user)
        {
            List<movieBookingModels> userdetails = new List<movieBookingModels>();
            movieBookingModels userdata = new movieBookingModels();
            try
            {

                using (BookMyEventDbEntities db = new BookMyEventDbEntities())
                {
                    userdata = db.BME_tblUserDetails.Where(w => w.Name == user.Name && w.Password == user.Password).Select(s => new movieBookingModels
                    {
                        Name = s.Name,
                        UserId = s.Id,
                        MailId = s.MailId,
                        PhoneNo = s.PhoneNo

                    }).FirstOrDefault();

                    userdetails = db.BME_tblEventDb.Where(w => w.IsActive == true).Select(s => new movieBookingModels
                    {
                        eventid = s.id,
                        EventName = s.EventName,
                        EventType = s.EventType,
                        Duration = s.Duration,
                        CasteName = s.CasteName,
                        Description = s.Description,
                        Image = s.Image


                    }).ToList();

                    if (db.BME_tblUserDetails.Any(val => val.Name == user.Name && val.Password == user.Password))
                    {
                        Session["UserName"] = userdata.Name;
                        Session["Email"] = userdata.MailId;
                        Session["phoneno"] = userdata.PhoneNo;
                        Session["UserId"] = userdata.UserId;

                        return View(userdetails);
                    }
                    else
                    {
                        return View("UserLoginPage");
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }


        }
        // GET: WebpageHome
        public ActionResult LandingPage()
        {


            return View();
        }

        public ActionResult SelectSeats(int id)
        {
            List<movieBookingModels> seatList = new List<movieBookingModels>();
            try
            {
            
                using (BookMyEventDbEntities db = new BookMyEventDbEntities())
                {
                    if (Session["UserName"] != null)
                    {


                        seatList = db.BME_tblBookingDetailsDb.Join(db.BME_tblPropertyDb, bd => bd.PropertyId, pd => pd.Id, (bd, pd) => new { bd, pd })
                            .Join(db.BME_tblEventDb, bd_pd => bd_pd.bd.EventId, ed => ed.id, (bd_pd, ed) => new { bd_pd, ed })
                            .Where(w => w.bd_pd.pd.Id == id && w.bd_pd.bd.PropertyId == id).Select(s => new movieBookingModels
                            {
                                propertyId = s.bd_pd.pd.Id,
                                PropertyName = s.bd_pd.pd.PropertyName,
                                PropertyAddress = s.bd_pd.pd.PropertyAddress,
                                PropertyLocation = s.bd_pd.pd.PropertyLocation,
                                Price = s.bd_pd.pd.Price,
                                Time = s.bd_pd.pd.Time,
                                CasteName = s.ed.CasteName,
                                eventid = s.ed.id,
                                NoOfSeats = s.bd_pd.pd.NoOfSeats,
                                Duration = s.ed.Duration,
                                Description = s.ed.Description,
                                Image = s.ed.Image,
                                EventName = s.ed.EventName,
                                EventType = s.ed.EventType,
                                Language = s.ed.Language,
                                NoOfSeatsBooked = s.bd_pd.pd.NoOfSeatsBooked,
                                SeatNumber = s.bd_pd.pd.SeatNumber,
                                SeatsNumber = s.bd_pd.bd.SeatsNumber
                              
                            }).ToList();

                        if (seatList.Count() != 0  )
                        {
                            return View(seatList);
                        }
                        else
                        {
                            seatList = db.BME_tblPropertyDb.Join(db.BME_tblEventDb, pt => pt.CurrentEvent_Id, ev => ev.id, (pt, ev) => new { pt, ev }).Where(w => w.pt.IsActive == true && w.ev.IsActive == true && w.pt.Id == id).Select(s => new movieBookingModels
                            {
                                propertyId = s.pt.Id,
                                PropertyName = s.pt.PropertyName,
                                PropertyAddress = s.pt.PropertyAddress,
                                PropertyLocation = s.pt.PropertyLocation,
                                Price = s.pt.Price,
                                Time = s.pt.Time,
                                CasteName = s.ev.CasteName,
                                eventid = s.ev.id,
                                NoOfSeats = s.pt.NoOfSeats,
                                Duration = s.ev.Duration,
                                Description = s.ev.Description,
                                Image = s.ev.Image,
                                EventName = s.ev.EventName,
                                EventType = s.ev.EventType,
                                Language = s.ev.Language,
                                NoOfSeatsBooked = s.pt.NoOfSeatsBooked,
                                SeatNumber = s.pt.SeatNumber

                            }).ToList();
                            return View(seatList);
                        }


                    }
                    else
                    {
                        return RedirectToAction("UserRegistration", "Home");
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public ActionResult selectTheatres(int id)
        {
            List<movieBookingModels> propertyList = new List<movieBookingModels>();
            try
            {
                using (BookMyEventDbEntities db = new BookMyEventDbEntities())

                {

                    propertyList = db.BME_tblPropertyDb.Join(db.BME_tblEventDb, pt => pt.CurrentEvent_Id, ev => ev.id, (pt, ev) => new { pt, ev }).Where(w => w.pt.IsActive == true && w.ev.IsActive == true && w.pt.CurrentEvent_Id == id).Select(s => new movieBookingModels
                    {
                        propertyId = s.pt.Id,
                        PropertyName = s.pt.PropertyName,
                        PropertyAddress = s.pt.PropertyAddress,
                        PropertyLocation = s.pt.PropertyLocation,
                        Price = s.pt.Price,
                        Time = s.pt.Time,
                        CasteName = s.ev.CasteName,
                        eventid = s.ev.id,
                        NoOfSeats = s.pt.NoOfSeats,
                        Duration = s.ev.Duration,
                        Description = s.ev.Description,
                        Image = s.ev.Image,
                        EventName = s.ev.EventName,
                        EventType = s.ev.EventType,
                        Language = s.ev.Language,


                    }).ToList();
                    return View(propertyList);


                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public ActionResult editUserdetails(int id)
        {
            List<movieBookingModels> user = new List<movieBookingModels>();
            try
            {
                using (BookMyEventDbEntities db = new BookMyEventDbEntities())
                {
                    user = db.BME_tblUserDetails.Where(w => w.Id == id).Select(s => new movieBookingModels
                    {
                        Name = s.Name,
                        MailId = s.MailId,
                        PhoneNo = s.PhoneNo,


                    }).ToList();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return View(user);
        }
        public ActionResult showBookingDetails(int id)
        {

            List<movieBookingModels> userdetails = new List<movieBookingModels>();
            try
            {
                Random random = new Random();
                var bookingId = random.Next(10000, 99999);
                using (BookMyEventDbEntities db = new BookMyEventDbEntities())
                {
                    userdetails = db.BME_tblBookingDetailsDb.Join(db.BME_tblUserDetails, bd => bd.UserID, ud => ud.Id, (bd, ud) => new { bd, ud })
                        .Join(db.BME_tblPropertyDb, bd_ud => bd_ud.bd.PropertyId, pt => pt.Id, (bd_ud, pt) => new { bd_ud, pt })
                        .Where(w => w.bd_ud.bd.UserID == id && w.bd_ud.ud.Id == id && w.pt.Id == w.bd_ud.bd.PropertyId)
                        .Select(s => new movieBookingModels
                        {
                            propertyId = s.pt.Id,
                            //PropertyName = s.pt.PropertyName,
                            //PropertyAddress = s.pt.PropertyAddress,
                            //PropertyLocation = s.pt.PropertyLocation,
                            //Price = s.pt.Price,
                            //Time = s.pt.Time,
                            //CasteName = s.ev.CasteName,
                            //eventid = s.ev.id,
                            NoOfSeats = s.pt.NoOfSeats,
                            NoOfSeatsBooked = s.pt.NoOfSeatsBooked,
                            //Duration = s.ev.Duration,
                            //Description = s.ev.Description,
                            //Image = s.ev.Image,
                            //EventName = s.ev.EventName,
                            //EventType = s.ev.EventType,
                            //Language = s.ev.Language,

                            Username = s.bd_ud.ud.Name,
                            BookingEventName = s.bd_ud.bd.EventName,
                            BookingPropertyName = s.bd_ud.bd.PropertyName,
                            PropertyLocation = s.bd_ud.bd.Location,
                            Bookingid = s.bd_ud.bd.id,
                            Location = s.bd_ud.bd.Location,
                            DateTime = s.bd_ud.bd.DateTime,
                            PropertyAddress = s.bd_ud.bd.PropertyAddress,
                            SeatsNumber = s.bd_ud.bd.SeatsNumber,
                            NumberOfSeats = s.bd_ud.bd.NumberOfSeats




                        }).ToList();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return View(userdetails);
        }

        public ActionResult UserLogout()
        {
            Session.Clear();
            return RedirectToAction("LandingPage", "WebpageHome");
        }
        public JsonResult BookingConfirmation(movieBookingModels mbm)
        {
            bool success = false;
            try
            {
                using (BookMyEventDbEntities db = new BookMyEventDbEntities())
                {
                    var bookingdbdetails = db.BME_tblPropertyDb.Where(w => w.Id == mbm.propertyId && w.CurrentEvent_Id == mbm.eventid).FirstOrDefault();

                    if (bookingdbdetails != null)
                    {
                        bookingdbdetails.SeatNumber = mbm.SeatNumber;
                        db.SaveChanges();
                    }

                    db.BME_tblBookingDetailsDb.Add(new BME_tblBookingDetailsDb {

                        DateTime = mbm.DateTime,
                        NumberOfSeats = mbm.NumberOfSeats,
                        SeatsNumber = mbm.SeatsNumber,
                        EventId = mbm.eventid,
                        PropertyAddress = mbm.PropertyAddress,
                        EventName = mbm.BookingEventName,
                        PropertyId = mbm.propertyId,
                        Location = mbm.Location,
                        PropertyName = mbm.PropertyName,
                        UserID = mbm.UserId,
                        Username = mbm.Username
                    });
                    int j = db.SaveChanges();
                    if (j > 0)
                    {
                        TempData["SuccessMessage"] = "Congratulations Tickets Booked";
                        success = true;

                    }
                    else
                    {
                        TempData["ErrorMessage"] = "Sorry Something Went Wrong";
                        success = false;
                    }
                    var response = new
                    {
                        Success = success,
                        SuccessMessage = TempData["SuccessMessage"],
                        ErrorMessage = TempData["ErrorMessage"]
                    };
                    return Json(response);

                }
            }
            catch (Exception)
            {

                throw;
            }

            return Json(JsonRequestBehavior.AllowGet);
        }

        
        public ActionResult CancelBooking(int id)
        {
            try
            {
                using (BookMyEventDbEntities db = new BookMyEventDbEntities())
                {
                    var bookingdata = db.BME_tblBookingDetailsDb.Where(w => w.id == id).FirstOrDefault();

                    if(bookingdata != null)
                    {
                        db.BME_tblBookingDetailsDb.Remove(bookingdata);
                        db.SaveChanges();
                        return RedirectToAction("showBookingDetails", "WebpageHome");
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return View();
        }
    }

}