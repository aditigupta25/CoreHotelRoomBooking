using System;
using System.Collections.Generic;

namespace coreCustomerHotelRoomBooking.Models
{
    public partial class BookingDetails
    {
        public int BookingId { get; set; }
        public int RoomId { get; set; }
        public int Quantity { get; set; }

        public Bookings Booking { get; set; }
        public HotelRooms Room { get; set; }
    }
}
