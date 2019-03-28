using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using coreCustomerHotelRoomBooking.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace coreCustomerHotelRoomBooking.Controllers
{
    public class CustomerController : Controller
    {
        CoreHotelRoomBookingContext context = new CoreHotelRoomBookingContext();

        [Route("index")]
        public IActionResult Index()
        {
            return View();
        }


        [Route("mylogin")]
        [HttpPost]
        public IActionResult MyLogin(string username, string password)
        {
            var user = context.Customers.Where(x => x.EmailId == username).SingleOrDefault();
            var pass = context.Customers.Where(x => x.Password == password).SingleOrDefault();
            ViewBag.cust = user;
            ViewBag.cust1 = pass;
            if (user == null)
            {
                ViewBag.Error = "Invalid Credentials";
                return View("Index");
            }
            else
            {
                var userName = user.EmailId;
                var userPass= pass.Password;
                int custId = ViewBag.cust.CustomerId;
                var passWord = ViewBag.cust1.Password;
                if (username != null && password != null && username.Equals(userName) && password.Equals(passWord))
                {
                    HttpContext.Session.SetString("uname", username);
                    return RedirectToAction("CheckOut", "Book", new { @id = custId });
                }
                else
                {
                    ViewBag.Error = "Invalid Credentials";
                    return View("Index");
                }
            }
        }

        [Route("logout")]
        [HttpGet]
        public IActionResult Logout()
        {
            HttpContext.Session.Remove("uname");
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ViewResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Customers c1)
        {
          
            context.Customers.Add(c1);
            context.SaveChanges();
            return RedirectToAction("Index", "Customer");

        }
    }
}