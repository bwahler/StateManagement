using StateManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StateManagement.Controllers
{
    public class HomeController : Controller
    {
        List<User> users = new List<User>();

        public ActionResult Index()
        {
            ViewBag.CurrentUser = (User)Session["CurrentUser"];
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Products we can be proud of!";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "We have Products!";

            return View();
        }

        public ActionResult Login()
        {
            return View();
        }
        
        public ActionResult RegisterUser()
        {
            return View();
        }

        public ActionResult UserDetails(User account)
        {
            if(Session["CurrentUser"] != null)
            {
                account = (User)Session["CurrentUser"];
                ViewBag.CurrentUser = account;
                return View();
            }
            else
            {
                if(ModelState.IsValid)
                {
                    users.Add(account);
                    ViewBag.CurrentUser = account;
                    Session["CurrentUser"] = account;
                    return RedirectToAction("UserDetails");
                }
                else
                {
                    ViewBag.ErrorMessage = "Registration Failed. Please try again";
                    return View("RegisterUser");
                }
            }
        }

        public ActionResult Logout()
        {
            ViewBag.CurrentUser = (User)Session["CurrentUser"];
            Session.Remove("CurrentUser");
            return View();
        }
    }
}