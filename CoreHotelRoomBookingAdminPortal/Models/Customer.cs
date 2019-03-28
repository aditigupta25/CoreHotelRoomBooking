using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreHotelRoomBookingAdminPortal.Models
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public long ContactNumber { get; set; }
        public string Address { get; set; }
        public string EmailId { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
        public int zip { get; set; }
        public string Password { get; set; }
        public List<Bookings> Bookings { get; set; }
      

    }
}
