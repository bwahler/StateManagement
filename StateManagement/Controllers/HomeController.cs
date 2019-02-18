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
        List<Item> ItemList = new List<Item>
        {
           new Item("Hot Chocolate", "Milk, Cocoa, Sugar, Fat", 1.99),
           new Item("Latte",  "Milk, Coffee", 1.99),
           new Item("Coffee",  "Coffee, Water", 1.00),
           new Item("Tea", "Black Tea", 1.00),
           new Item("Frozen Lemonade",  "Lemon, Sugar, Ice", 1.99)
       };

        List<Item> ShoppingCart = new List<Item>();

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

        public ActionResult ValidLogin(User login)
        {
            List<User> users;
            if (Session["RegisteredUsers"] == null)
            {
                ViewBag.ErrorMessage = "No users available!";
                return View("Error");
            }
            else
            {
                users = (List<User>)Session["RegisteredUsers"];
                foreach (User user in users)
                {
                    if (user.Email == login.Email && user.Password == login.Password)
                    {
                        Session["CurrentUser"] = user;
                        return RedirectToAction("Index");
                    }
                }
            }
            ViewBag.ErrorMessage = "Your Email address and/or password are not valid!";
            return View("Error");
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
                    ViewBag.CurrentUser = account;
                    Session["CurrentUser"] = account;
                    if(Session["RegisteredUsers"] != null)
                    {
                        users = (List<User>)Session["RegisteredUsers"];
                    }                    
                    users.Add(account);
                    Session["RegisteredUsers"] = users;                    
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
            //ViewBag.RegisteredUsers = (User)Session["RegisteredUsers"];
            Session.Remove("CurrentUser");
            return View();
        }

        public ActionResult ListItems()
        {
            ViewBag.ItemsList = ItemList;
            return View();
        }
        
        public ActionResult AddItem(string itemName)
        {            
            if(Session["ShoppingCart"] != null)
            {
                ShoppingCart = (List<Item>)Session["ShoppingCart"];
            }
            foreach(Item item in ItemList)
            {
                if(item.ItemName == itemName)
                {
                    ShoppingCart.Add(item);
                }
            }
            Session["ShoppingCart"] = ShoppingCart;
            return RedirectToAction("ListItems");
        }

        public ActionResult DeleteItem(string itemName)
        {            
            if (Session["ShoppingCart"] != null)
            {
                ShoppingCart = (List<Item>)Session["ShoppingCart"];
            }
            int i = 0;
            foreach (Item item in ShoppingCart)
            {
                if (item.ItemName == itemName)
                {
                    break;
                }
                i++;
            }
            ShoppingCart.RemoveAt(i);

            Session["ShoppingCart"] = ShoppingCart;
            return RedirectToAction("Cart");
        }

        public ActionResult Cart()
        {
            ShoppingCart = (List<Item>)Session["ShoppingCart"];
            ViewBag.ShoppingCart = ShoppingCart;
            return View();
        }
    }
}