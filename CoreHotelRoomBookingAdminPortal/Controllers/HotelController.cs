using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreHotelRoomBookingAdminPortal.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CoreHotelRoomBookingAdminPortal.Controllers
{
    public class HotelController : Controller
    {
        HotelDbContext context;
        public HotelController(){
          }
        public HotelController(HotelDbContext _context)
        {
            context = _context;
        }

        public IActionResult Index()
        {
            var hotels = context.Hotels.ToList();

            return View(hotels);
        }

        public ViewResult Details(int id)
        {
           Hotel hotel = context.Hotels.Where(x => x.HotelId == id).SingleOrDefault();
            return View(hotel);
        }

        [HttpGet]
    
        public ViewResult Create()
        {
            ViewBag.hoteltypes = new SelectList(context.HotelTypes, "HotelTypeId", "HotelTypeName");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("HotelName", "HotelDescription", "HotelAddress", "District", "City", "State", "Country", "HotelEmailId", "HotelRating", "HotelContactNumber", "HotelTypeId")] Hotel h1)
        {
            if (ModelState.IsValid)
            {
                context.Hotels.Add(h1);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(h1);
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            Hotel hotel = context.Hotels.Find(id);
            ViewBag.hoteltypes = new SelectList(context.HotelTypes, "HotelTypeId", "HotelTypeName", hotel.HotelTypeId);
            return View(hotel);
        }
        [HttpPost]
        public ActionResult Delete(int id, Hotel h1)
        {
            var hotel = context.Hotels.Where(x => x.HotelId == id).SingleOrDefault();
            context.Hotels.Remove(hotel);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            Hotel hotel = context.Hotels.Where(x => x.HotelId == id).SingleOrDefault();
            ViewBag.hoteltypes = new SelectList(context.HotelTypes, "HotelTypeId", "HotelTypeName", hotel.HotelTypeId);
            return View(hotel);
        }
        [HttpPost]
        public ActionResult Edit(Hotel h1)
        {
            Hotel hotel = context.Hotels.Where(x => x.HotelId == h1.HotelId).SingleOrDefault();
            hotel.HotelId = h1.HotelId;
            hotel.HotelName = h1.HotelName;
            hotel.HotelAddress = h1.HotelAddress;
            hotel.HotelEmailId = h1.HotelEmailId;
            hotel.District = h1.District;
            hotel.City = h1.City;
            hotel.State = h1.State;
            hotel.Country = h1.Country;
            hotel.HotelContactNumber = h1.HotelContactNumber;
            hotel.HotelRating = h1.HotelRating;
            hotel.HotelImage = h1.HotelImage;
            hotel.HotelDescription = h1.HotelDescription;
            hotel.HotelTypeId = h1.HotelTypeId;    
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}