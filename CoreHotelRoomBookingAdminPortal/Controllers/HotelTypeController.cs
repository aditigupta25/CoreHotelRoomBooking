using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreHotelRoomBookingAdminPortal.Models;
using Microsoft.AspNetCore.Mvc;

namespace CoreHotelRoomBookingAdminPortal.Controllers
{
    public class HotelTypeController : Controller
    {
        HotelDbContext context;
        public HotelTypeController(HotelDbContext _context)
        {
            context = _context;
        }

        public ViewResult Details(int id)
        {
            HotelType hoteltype = context.HotelTypes.Where(x => x.HotelTypeId == id).SingleOrDefault();
            return View(hoteltype);
        }

        public IActionResult Index()
        {
            var hoteltype = context.HotelTypes.ToList();

            return View(hoteltype);
        }


        [HttpGet]
        public ViewResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("HotelTypeName","HotelTypeDescription")]HotelType ht1)
        {
            if (ModelState.IsValid)
            {
                context.HotelTypes.Add(ht1);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(ht1);
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            HotelType hoteltype = context.HotelTypes.Find(id);
            return View(hoteltype);
        }
        [HttpPost]
        public ActionResult Delete(int id, HotelType ht1)
        {
            var hoteltype = context.HotelTypes.Where(x => x.HotelTypeId == id).SingleOrDefault();
            context.HotelTypes.Remove(hoteltype);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Edit(int id)
        {
            HotelType hoteltype = context.HotelTypes.Where(x => x.HotelTypeId == id).SingleOrDefault();
            return View(hoteltype);
        }
        [HttpPost]
        public ActionResult Edit(HotelType ht1)
        {
            HotelType hoteltype = context.HotelTypes.Where(x => x.HotelTypeId == ht1.HotelTypeId).SingleOrDefault();
            hoteltype.HotelTypeId = ht1.HotelTypeId;
            hoteltype.HotelTypeName = ht1.HotelTypeName;
            hoteltype.HotelTypeDescription = ht1.HotelTypeDescription;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}