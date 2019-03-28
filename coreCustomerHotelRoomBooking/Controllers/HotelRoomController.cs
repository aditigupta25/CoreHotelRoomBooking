using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using coreCustomerHotelRoomBooking.Models;
using Microsoft.AspNetCore.Mvc;

namespace coreCustomerHotelRoomBooking.Controllers
{
    public class HotelRoomController : Controller
    {
        CoreHotelRoomBookingContext context = new CoreHotelRoomBookingContext();
        public IActionResult Index()
        {
            var hotelrooms = context.HotelRooms.ToList();
            return View(hotelrooms);
        }

        public ViewResult ViewDetails(int id)
        {
            
            HotelRooms hotelrooms = context.HotelRooms.Where(x => x.RoomId == id).SingleOrDefault();
            ViewBag.HotelRoom = hotelrooms;
            int hid = ViewBag.HotelRoom.HotelId;
            Hotels hotels = context.Hotels.Where(x => x.HotelId ==hid).SingleOrDefault();
            ViewBag.Hotel = hotels;
            RoomFacilities roomfacilities =context.RoomFacilities.Where(x => x.RoomId == id).SingleOrDefault();
            ViewBag.RoomFacility = roomfacilities;
            return View();
            
        }
        public ViewResult Details(int id)
        {
            var hotelroom = context.HotelRooms.Where(x => x.HotelId == id).ToList();
            return View(hotelroom);
        }
    }
}