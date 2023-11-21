using ManagementWebApp.Models;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using WebGrease.Css.Ast.Selectors;

namespace ManagementWebApp.Controllers
{
    public class AdminController : Controller
    {
        public ActionResult AdminValidator(Admindetails admindetails)
        {
            Admindetails admd = new Admindetails();
            try
            {
                
                using (BookMyEventDbEntities db = new BookMyEventDbEntities())
                {
                    admd = db.BME_tblAdminDetails.Where(w => admindetails.AdminName == w.AdminName && w.Password == admindetails.Password && w.IsActive==true).Select(s => new Admindetails
                    {
                        MailId=s.MailId,
                        PhoneNo=s.PhoneNo,
                        id=s.id
                    }).FirstOrDefault();
                    if (db.BME_tblAdminDetails.Any(x => x.AdminName == admindetails.AdminName && x.Password == admindetails.Password && x.IsActive==true))
                    {
                        
                        Session["AdminName"]=admindetails.AdminName;
                        Session["AdminId"] = admd.id;
                        

                        return RedirectToAction("AdminDashboardPage");
                    }
                    else
                    {
                        TempData["wrong"] = "Wrong Id/Password"; 
                        return RedirectToAction("AdminLoginPage", "Home");
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return View();
        }
        //Admin Dashboard method------------------------------------------------>
        public ActionResult AdminDashboardPage()
        {
            List<dashboardModels> dashboardmodels=new List<dashboardModels> ();
            try
            {
                using (BookMyEventDbEntities db = new BookMyEventDbEntities())
                {
                  


                    int x = db.BME_tblBookingDetailsDb.Count();
                    var y = db.BME_tblEventDb.Where(w=> w.IsActive==true).Count();
                    var z = db.BME_tblPropertyDb.Where(w => w.IsActive == true).Count();
                    var a = db.BME_tblUserDetails.Where(w => w.IsActive == true).Count();

                    dashboardmodels.Add(new dashboardModels
                    {
                        x = x,
                        y = y,
                        z = z,
                        a = a
                    });

                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return View(dashboardmodels);
        }
        

        //Property Methods-------------------------------------------------------->

        public ActionResult Property()
        {
            List<PropertyModels> properties = new List<PropertyModels>(); 
            try
                 {
                using (BookMyEventDbEntities db=new BookMyEventDbEntities())
                {
                    properties = db.BME_tblPropertyDb.Where(i => i.IsActive == true).Select(p => new PropertyModels
                    {
                        Id = p.Id,
                        PropertyName=p.PropertyName,
                        PropertyLocation=p.PropertyLocation,
                        PropertyAddress=p.PropertyAddress,
                        Price = p.Price,
                        NoOfSeats=p.NoOfSeats,
                        Time=p.Time,
                        CurrentEvent_Id=p.CurrentEvent_Id


                    }).ToList();
                }
            }
            catch (Exception x)
            {

                throw x;
            }

            return View(properties);
        }

        public ActionResult AddProperty()
        {
            return View();
        }

        public ActionResult AddNewProperty(BME_tblPropertyDb property)
        {
            try
            {
                using (BookMyEventDbEntities db = new BookMyEventDbEntities())
                {
                    property.CreatedOn = DateTime.Now;
                    property.CreatedBy = "Hardhik";
                    property.IsActive = true;
                    property.SeatNumber = "";
                    property.NoOfSeatsBooked="0";
                    db.BME_tblPropertyDb.Add(property);
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return View("AdminDashboardPage");
        }
        public ActionResult EditProperty(int id)
        {
            PropertyModels propertymodel = new PropertyModels();
            try
            {
                using (BookMyEventDbEntities db = new BookMyEventDbEntities())
                {
                    propertymodel = db.BME_tblPropertyDb.Where(w => w.IsActive == true && w.Id == id).Select(s => new PropertyModels
                    {
                        PropertyName = s.PropertyName,
                        PropertyLocation = s.PropertyLocation,
                        PropertyAddress = s.PropertyAddress,
                        Price = s.Price,
                        NoOfSeats = s.NoOfSeats,
                        Time = s.Time,
                        CurrentEvent_Id = s.CurrentEvent_Id

                    }).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return View(propertymodel);
        }

        [HttpPost]
        public ActionResult SetProperty(PropertyModels property)
        {
            try
            {
                using (BookMyEventDbEntities db = new BookMyEventDbEntities())
                {
                    var propertydetails = db.BME_tblPropertyDb.Where(w => w.IsActive == true && w.Id == property.Id).FirstOrDefault();
                    if (propertydetails != null)
                    {
                        propertydetails.PropertyName = property.PropertyName;
                        propertydetails.PropertyAddress=property.PropertyAddress;
                        propertydetails.Price = property.Price;
                        propertydetails.NoOfSeats = property.NoOfSeats;
                        propertydetails.CurrentEvent_Id = property.CurrentEvent_Id;
                        propertydetails.Time = property.Time;
                        propertydetails.PropertyLocation = property.PropertyLocation;
                        propertydetails.UpdatedBy = "Admin";
                        propertydetails.UpdatedOn = DateTime.Now;

                        db.SaveChanges();

                            
                    }
                }
            }
            catch (Exception es)
            {

                throw es;
            }
            return RedirectToAction("Property","Admin");
        }

       
        public ActionResult DeleteProperty(int id)
        {
            try
            {
                using (BookMyEventDbEntities db = new BookMyEventDbEntities())
                {
                    var propertydetails = db.BME_tblPropertyDb.Where(w => w.IsActive == true && w.Id == id).FirstOrDefault();

                    if (propertydetails != null)
                    {
                        propertydetails.IsActive = null;

                        
                        db.SaveChanges();
                    }
                }
                

            }
            catch (Exception ex)
            {

                throw ex;
            }

            return View("Property");
        }


        //Users Methods--------------------------------------------------------------->


        public ActionResult Users()
        {
            List<UserModels> usermodel = new List<UserModels>();
            try
            {
                using (BookMyEventDbEntities db = new BookMyEventDbEntities())
                {
                    usermodel = db.BME_tblUserDetails.Where(i => i.IsActive == true).Select(us => new UserModels
                    {
                        Id=us.Id,
                        Name=us.Name,
                        PhoneNo=us.PhoneNo,
                        MailId=us.MailId,
                        IsActive=us.IsActive,
                    }).ToList();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return View(usermodel);
        }

        //Events Methods--------------------------------------------------------------->

        public ActionResult Events()
        {
            List<EventModels> eventmodels = new List<EventModels>();

            using (BookMyEventDbEntities db = new BookMyEventDbEntities())
            {
                eventmodels = db.BME_tblEventDb.Where(w => w.IsActive == true).Select(s => new EventModels
                {
                    id=s.id,
                    EventName=s.EventName,
                    EventType=s.EventType,
                    Description=s.Description,
                    IsActive=s.IsActive,
                    CasteName=s.CasteName,
                    Duration=s.Duration,
                    Language=s.Language,
                    Image=s.Image
                }).ToList();
            }

            return View(eventmodels);
        }

        public ActionResult AddEventsView()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddEvents(BME_tblEventDb eventdetails, HttpPostedFileBase imageFile)
        {
           
            try
            {
                byte[] imageData;

                using (var binaryReader = new BinaryReader(imageFile.InputStream))
                {
                    imageData = binaryReader.ReadBytes(imageFile.ContentLength);
                }
                using (BookMyEventDbEntities db = new BookMyEventDbEntities())
                {

                    eventdetails.Image = imageData;

                    eventdetails.IsActive = true;
                    eventdetails.CreatedBy = "Admin";
                    eventdetails.CreatedOn = DateTime.Now;
                    db.BME_tblEventDb.Add(eventdetails);
                    db.SaveChanges();
                }
            }
            catch (Exception)
            {

                throw;
            }
            
            return RedirectToAction("AddEventsView","Admin");
        }
        
        public ActionResult EditEvent(int id)
        {
            EventModels eventmodels = new EventModels();
            try
            {
                using (BookMyEventDbEntities db = new BookMyEventDbEntities())
                {
                    eventmodels = db.BME_tblEventDb.Where(w => w.id == id).Select(s => new EventModels
                    {
                        id = s.id,
                        EventName=s.EventName,
                        CasteName=s.CasteName,
                        Language=s.Language,
                        Date=s.Date,
                        Duration=s.Duration,
                        Description=s.Description,
                        EventType=s.EventType,
                        Image=s.Image
                        
                    }).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return View(eventmodels);
        }
        [HttpPost]
        public ActionResult Setevents(BME_tblEventDb eventdetails,HttpPostedFileBase imageFile)
        {
            
            try
            {
                byte[] imageData;
                using (var binaryReader = new BinaryReader(imageFile.InputStream))
                {
                    imageData = binaryReader.ReadBytes(imageFile.ContentLength);
                }
                using (BookMyEventDbEntities db = new BookMyEventDbEntities())
                {
                    var eventmodels = db.BME_tblEventDb.Where(w => w.id == eventdetails.id && w.IsActive == true).FirstOrDefault();
                    if (eventdetails != null)
                    {
                 
                        eventmodels.EventName = eventdetails.EventName;
                        eventmodels.EventType = eventdetails.EventType;
                        eventmodels.Duration = eventdetails.Duration;
                        eventmodels.Description = eventdetails.Description;
                        eventmodels.CasteName = eventdetails.CasteName;
                        eventmodels.Date = eventdetails.Date;
                        eventmodels.Image = imageData;
                        eventmodels.UpdatedBy = Convert.ToString(Session["AdminName"]);
                        eventmodels.UpdatedOn = DateTime.Now;
                        db.SaveChanges();
                        return RedirectToAction("Events","Admin");
                    }
                   

                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return View("EditEvent");
        }

        public ActionResult DeleteEvent(int id)
        {
            try
            {
                using (BookMyEventDbEntities db = new BookMyEventDbEntities())
                {
                    var deleteEvent = db.BME_tblEventDb.Where(w => w.id == id && w.IsActive == true).FirstOrDefault();
                    if (deleteEvent != null)
                    {
                        deleteEvent.IsActive = false;
                        db.SaveChanges();
                        return RedirectToAction("Events","Admin");
                    }

                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return View();
        }

        //Booking Details-------------------------------------------------->

        public ActionResult BookingDetails()
        {

            List<bookingDetails> bookingdetails = new List<bookingDetails>();
            try
            {
              
                using (BookMyEventDbEntities db = new BookMyEventDbEntities())
                {
                    bookingdetails = db.BME_tblBookingDetailsDb.Join(db.BME_tblUserDetails, bd => bd.UserID, ud => ud.Id, (bd, ud) => new { bd, ud })
                        .Select(s => new bookingDetails
                        {
                 

                            Username = s.ud.Name,
                            EventName = s.bd.EventName,
                            PropertyName = s.bd.PropertyName,
                            UserID=s.ud.Id,
                            EventId=s.bd.EventId,
                            id = s.bd.id,
                            Location = s.bd.Location,
                            DateTime = s.bd.DateTime,
                            PropertyAddress = s.bd.PropertyAddress,
                            SeatsNumber = s.bd.SeatsNumber,
                            NumberOfSeats = s.bd.NumberOfSeats




                        }).ToList();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return View(bookingdetails);
        }

        //Add New Admin------------------------------------------------------------------------->

        public ActionResult AddNewAdmin()
        {
            return View();
        }
        public ActionResult DeleteAdmin(int id)
        {
            try
            {
                using (BookMyEventDbEntities db = new BookMyEventDbEntities())
                {
                    var admindetails = db.BME_tblAdminDetails.Where(w => w.IsActive == true && w.id == id).FirstOrDefault();

                    if (admindetails != null)
                    {
                        admindetails.IsActive = false;
                        db.SaveChanges();
                    }
                }
                return RedirectToAction("ShowAdminDetails","Admin");
            }
            catch (Exception ex)
            {

                throw ex;
            }
            
        }
        [HttpPost]
        public ActionResult setNewAdmin(BME_tblAdminDetails admin, HttpPostedFileBase adminImage)
        {
            try
            {
                byte[] imageData;
                using (var binaryReader = new BinaryReader(adminImage.InputStream))
                {
                    imageData = binaryReader.ReadBytes(adminImage.ContentLength);
                }
                using (BookMyEventDbEntities db = new BookMyEventDbEntities())
                {
                    admin.CreatedBy =Convert.ToString( Session["AdminName"]);
                    admin.CreatedOn = DateTime.Now;
                    admin.IsActive = true;
                    db.BME_tblAdminDetails.Add(admin);
                    var j=db.SaveChanges();

                    if (j > 0)
                    {
                        var admindata = db.BME_tblAdminDetails.Where(w => w.AdminName == admin.AdminName).FirstOrDefault();
                        db.BME_tblAdminImages.Add(new BME_tblAdminImages
                        {

                            Image = imageData,
                            UserID = admindata.id
                        }) ;
                        db.SaveChanges();
                        return RedirectToAction("AdminDashboardPage", "Admin");
                    }
                  
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return View();
            
        }
        
        public ActionResult EditAdminDetailsview( int id)
        {
            Admindetails admindetails = new Admindetails();
            try
            {
                using (BookMyEventDbEntities db = new BookMyEventDbEntities())
                {
                    admindetails = db.BME_tblAdminDetails.Join(db.BME_tblAdminImages, ad => ad.id, adi => adi.UserID, (ad, adi) => new { ad, adi })
                        .Where(w=> id==w.adi.UserID)
                 .Select(s => new Admindetails
                 {
                     AdminName=s.ad.AdminName,
                     Image=s.adi.Image,
                     id=s.ad.id,
                     MailId=s.ad.MailId,
                     PhoneNo=s.ad.PhoneNo,
                     Password=s.ad.Password

                 }).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return View(admindetails);
        }
        
        public ActionResult EditAdminDetails(BME_tblAdminDetails admin,HttpPostedFileBase imgFile)
            {
            byte[] img=null;
            try
            {
                
                if (imgFile != null)
                {
                    using (var binaryReader = new BinaryReader(imgFile.InputStream))
                    {
                        img = binaryReader.ReadBytes(imgFile.ContentLength);
                    }
                }
                
                
                using (BookMyEventDbEntities db = new BookMyEventDbEntities())
                {
                    var admindetails=db.BME_tblAdminDetails.Where(w=> w.AdminName==admin.AdminName && w.id==admin.id).FirstOrDefault();
                    admin.UpdatedBy = Convert.ToString(Session["AdminName"]);
                    admin.UpdatedOn = DateTime.Now;
                  
                    var j=db.SaveChanges();
                    
                        var adminimg = db.BME_tblAdminImages.Where(w => w.UserID == admindetails.id).FirstOrDefault();
                        adminimg.Image = img;
                        db.SaveChanges();
                        return RedirectToAction("AdminDashboardPage", "Admin");
                    
                    
                }
            }
            catch (Exception x)
            {

                throw x;
            }
            return View();
        }

        public ActionResult ShowAdminDetails()
        {
            List<AdminModels> adminmodel = new List<AdminModels>();
            try
            {
                using (BookMyEventDbEntities db = new BookMyEventDbEntities())
                {
                    adminmodel = db.BME_tblAdminDetails.Where(w=> w.IsActive==true).Select(s => new AdminModels
                    {
                        AdminName=s.AdminName,
                        id=s.id,
                        MailId=s.MailId,
                        PhoneNo=s.PhoneNo,
                        
                    }).ToList();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return View(adminmodel);
        }
        //Logout Admin------------------------------------------------------------------------->

        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("AdminLoginPage","Home");
        }
    }
    
}