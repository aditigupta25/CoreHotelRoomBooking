using System.Linq;
using CoreHotelRoomBookingAdminPortal.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HotelRoomBooking.Controllers
{
    public class HotelRoomController : Controller

    {
        HotelDbContext context;
        public HotelRoomController(HotelDbContext _context)
        {
            context = _context;
        }

        public ViewResult Details(int id)
        {
            HotelRoom hotelroom = context.HotelRooms.Where(x => x.RoomId == id).SingleOrDefault();
            return View(hotelroom);
        }
        public IActionResult Index()
        {
            var hotelrooms = context.HotelRooms.ToList();

            return View(hotelrooms);
        }


        [HttpGet]
      
        public ViewResult Create()
        {
            ViewBag.hotels = new SelectList(context.Hotels, "HotelId", "HotelName");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("RoomType", "RoomDescription", "RoomPrice", "HotelId")]HotelRoom hr1)
        {
            if (ModelState.IsValid)
            {
                context.HotelRooms.Add(hr1);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(hr1);
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            HotelRoom hotelroom = context.HotelRooms.Find(id);
            ViewBag.hotels = new SelectList(context.Hotels, "HotelId", "HotelName", hotelroom.HotelId);
            return View(hotelroom);
        }
        [HttpPost]
        public ActionResult Delete(int id, HotelRoom hr1)
        {
            var hotelroom = context.HotelRooms.Where(x => x.RoomId == id).SingleOrDefault();
            context.HotelRooms.Remove(hotelroom);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Edit(int id)
        {
            HotelRoom hotelroom = context.HotelRooms.Where(x => x.RoomId == id).SingleOrDefault();
            ViewBag.hotels = new SelectList(context.Hotels, "HotelId", "HotelName", hotelroom.HotelId);
            return View(hotelroom);
        }
        [HttpPost]
        public ActionResult Edit(HotelRoom h1)
        {
            HotelRoom hotelroom = context.HotelRooms.Where(x => x.RoomId == h1.RoomId).SingleOrDefault();
            hotelroom.RoomId = h1.RoomId;
            hotelroom.RoomType = h1.RoomType;
            hotelroom.RoomPrice = h1.RoomPrice;
            hotelroom.RoomImage= h1.RoomImage;
            hotelroom.RoomDescription = h1.RoomDescription;
            hotelroom.HotelId = h1.HotelId;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}