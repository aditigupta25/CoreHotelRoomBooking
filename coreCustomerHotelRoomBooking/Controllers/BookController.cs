using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using coreCustomerHotelRoomBooking.Helpers;
using coreCustomerHotelRoomBooking.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
namespace CustomerCoreHotel.Controllers
{
    [Route("book")]
    public class BookController : Controller
    {
        CoreHotelRoomBookingContext context = new CoreHotelRoomBookingContext();
        [Route("Index")]
        public IActionResult Index()
        {
            var book = SessionHelper.GetObjectFromJson<List<Item>>
                  (HttpContext.Session, "Book");
            
            ViewBag.book = book;
            if (ViewBag.book == null)
            {
                return RedirectToAction("EmptyBooking");
            }
            else
            {
                ViewBag.total = book.Sum(item => item.HotelRooms.RoomPrice * item.Quantity);
                ViewBag.totalitem = book.Count();
            }
            return View();
        }

        [Route("buy/{id}")]
        public IActionResult Buy(int id)
        {
            if (SessionHelper.GetObjectFromJson<List<Item>>
                (HttpContext.Session, "Book") == null)
            {
                List<Item> book = new List<Item>();
                book.Add(new Item
                {
                    HotelRooms = context.HotelRooms.Find(id),
                    Quantity = 1
                });
                SessionHelper.SetObjectAsJson(HttpContext.Session, "Book", book);
            }
            else
            {
                List<Item> book = SessionHelper.GetObjectFromJson<List<Item>>
                    (HttpContext.Session, "Book");
                int index = isExist(id);
                if (index != -1)
                {
                    book[index].Quantity++;
                }
                else
                {
                    book.Add(new Item
                    {
                        HotelRooms = context.HotelRooms.Find(id),
                        Quantity = 1
                    });
                    SessionHelper.SetObjectAsJson(HttpContext.Session, "Book", book);
                }

            }
            HotelRooms hotelrooms = context.HotelRooms.Where(x => x.RoomId == id).SingleOrDefault();
            ViewBag.HotelRoom = hotelrooms;
            int hid = ViewBag.HotelRoom.HotelId;
            Hotels hotels = context.Hotels.Where(x => x.HotelId == hid).SingleOrDefault();
            ViewBag.Hotel = hotels;
            return RedirectToAction("Details", "HotelRoom", new {@id=hid }); //Details action method
        }

        [Route("remove/{id}")]
        public IActionResult Remove(int id)
        {
            List<Item> book = SessionHelper.GetObjectFromJson<List<Item>>
                (HttpContext.Session, "Book");
            int index = isExist(id);
            book.RemoveAt(index);
            SessionHelper.SetObjectAsJson(HttpContext.Session, "Book", book);
            int count = 0;
            foreach (var item in book)
            {
                count++;
            }
            if (count != 0)
            {
                int j = int.Parse(HttpContext.Session.GetString("CartItem"));
                j--;
                HttpContext.Session.SetString("CartItem", j.ToString());
            }
            else
            {
                HttpContext.Session.Remove("CartItem");
                if (index == 0)
                {
                    return View("Empty Cart");
                }
            }

            return RedirectToAction("index");
        }
        private int isExist(int id)
        {
            List<Item> book = SessionHelper.GetObjectFromJson<List<Item>>
                (HttpContext.Session, "Book");
            for (int i = 0; i < book.Count; i++)
            {
                if (book[i].HotelRooms.RoomId.Equals(id))
                {
                    return i;
                }
            }
            return -1;
        }

        [Route("emptybooking")]
        public IActionResult EmptyBooking()
        {
            return View();
        }

        [HttpGet]
        public IActionResult CheckOut(int id)
        {
            var customers = context.Customers.Where(x => x.CustomerId == id).SingleOrDefault();
            //var bookings = context.Bookings.Where(x => x.CustomerId == id).SingleOrDefault();
            var book = SessionHelper.GetObjectFromJson<List<Item>>
                  (HttpContext.Session, "Book");
            ViewBag.book = book;
            ViewBag.total = book.Sum(item => item.HotelRooms.RoomPrice * item.Quantity);
            ViewBag.totalitem = book.Count();
            TempData["total"] = ViewBag.total;
            TempData["cid"] = customers.CustomerId;
            return View(customers);
         
        }
        
        [HttpPost]
        public IActionResult CheckOut(Customers customer)
        {
           
            var amount = TempData["total"];
            var cid = (TempData["cid"]).ToString();

            DateTime cin = DateTime.Parse(HttpContext.Session.GetString("CheckIn"));
            DateTime cout = DateTime.Parse(HttpContext.Session.GetString("CheckOut"));
            Bookings bookings = new Bookings()
            {
                BookingPrice = Convert.ToSingle(amount),
                BookingDate = DateTime.Now,
                CheckIn = cin,
                CheckOut = cout,
                CustomerId = int.Parse(cid)
            };

            ViewBag.Book = bookings;
            context.Bookings.Add(bookings);
            context.SaveChanges();


            var booking = SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "Book");
            List<BookingDetails> bookingDetails = new List<BookingDetails>();
            for (int i = 0; i < booking.Count; i++)
            {
                BookingDetails bookingdetail = new BookingDetails()
                {
                    BookingId = bookings.BookingId,
                    RoomId = booking[i].HotelRooms.RoomId,
                    Quantity = booking[i].Quantity
                };
                bookingDetails.Add(bookingdetail);

            }

            bookingDetails.ForEach(n => context.BookingDetails.Add(n));
            context.SaveChanges();
            TempData["cust"] = cid;
            ViewBag.booking = null;
            return RedirectToAction("Invoice");

        }

        [Route("invoice")]
        public IActionResult Invoice()
        {
            
            int CustId = int.Parse(TempData["cust"].ToString());
            Customers customers = context.Customers.Where(x => x.CustomerId == CustId).SingleOrDefault();
            ViewBag.Customers = customers;

            var book = SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "Book");      
            ViewBag.book = book;
            book = null;
            SessionHelper.SetObjectAsJson(HttpContext.Session, "Book", book);
            HttpContext.Session.Remove("CartItem");
            //ViewBag.total = book.Sum(item => item.HotelRooms.RoomPrice * item.Quantity);         
            return View();
           
        }

    }
}
