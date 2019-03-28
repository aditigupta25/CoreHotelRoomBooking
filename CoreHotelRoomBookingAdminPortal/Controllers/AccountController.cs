using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CoreHotelRoomBookingAdminPortal.Controllers
{
    [Route("account")] //to change navigation name of account controller
    public class AccountController : Controller
    {
        [Route("")]            //Runs without writing Index in the URL
        [Route("index")]       //normal one
        [Route("~/")]          //Default route,runs without writing account in the URL.
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [Route("login")]
        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            if (username != null && password != null && username.Equals("admin") && password.Equals("123456"))
            {
                HttpContext.Session.SetString("uname",username);
                return View("Home");
            }
            else
            {
                ViewBag.Error = "Invalid Credentials";
                return View("Index");
            }               
        }

        [Route("logout")]
        [HttpGet]
        public IActionResult Logout()
        {
            HttpContext.Session.Remove("uname");
            return RedirectToAction("Index");
        }

    }
}