using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using coreCustomerHotelRoomBooking.Models;
using coreCustomerHotelRoomBooking.Helpers;
using Microsoft.AspNetCore.Http;

namespace coreCustomerHotelRoomBooking.Controllers
{
    public class HomeController : Controller
    {
        CoreHotelRoomBookingContext context = new CoreHotelRoomBookingContext();
        public IActionResult Index()
        {

            var hotels = context.Hotels.ToList();
            List<Item> book = SessionHelper.GetObjectFromJson<List<Item>>
                (HttpContext.Session, "Book");
            int count = 0;
            if (book != null)
            {
                foreach (var item in book)
                {
                    count++;
                }
                if (count != 0)
                {
                    HttpContext.Session.SetString("CartItem", count.ToString());
                }
            }
            return View(hotels);

        }

        public ViewResult Details(int id)
        {
            Hotels hotels = context.Hotels.Where(x => x.HotelId == id).SingleOrDefault();
            ViewBag.Hotel = hotels;
            int htid = ViewBag.Hotel.HotelTypeId;
            HotelTypes hoteltypes = context.HotelTypes.Where(x => x.HotelTypeId == htid).SingleOrDefault();
            ViewBag.HotelType = hoteltypes;
            return View();
        }

        [Route("search")]
        [HttpGet]
        public IActionResult Search(string search , string checkIn,string checkOut)
        {
            HttpContext.Session.SetString("CheckIn", checkIn.ToString());
            HttpContext.Session.SetString("CheckOut", checkOut.ToString());
            //var home = SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session,"Home");
            ViewBag.Hotel = context.Hotels.Where(x => x.HotelName == search || x.City == search || x.State == search || search == null).ToList();
            return View(context.Hotels.Where(x => x.HotelName == search || search == null).ToList());
        }
    }
}
