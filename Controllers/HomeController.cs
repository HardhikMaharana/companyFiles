using ManagementWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ManagementWebApp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult UserRegistration()

        {
           
            try
            {

            }
            catch (Exception ex)
            {

                throw ex;
            }
            return View();
        }


        public ActionResult AdminLoginPage()
        {
            return View();
        }

        [HttpPost]
        public ActionResult UserRegistration(BME_tblUserDetails userDb)
        {
            try
            {
                using (BookMyEventDbEntities db=new BookMyEventDbEntities())
                {
                    userDb.Role = "User";
                    userDb.IsActive = true;
                    userDb.CreatedBy = userDb.Name;
                    userDb.CreatedOn = DateTime.Now;
                    db.BME_tblUserDetails.Add(userDb);
                    db.SaveChanges();
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