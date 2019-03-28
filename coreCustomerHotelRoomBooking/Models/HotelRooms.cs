using System;
using System.Collections.Generic;

namespace coreCustomerHotelRoomBooking.Models
{
    public partial class HotelRooms
    {
        public HotelRooms()
        {
            BookingDetails = new HashSet<BookingDetails>();
        }

        public int RoomId { get; set; }
        public string RoomType { get; set; }
        public string RoomDescription { get; set; }
        public int RoomPrice { get; set; }
        public int HotelId { get; set; }
        public string RoomImage { get; set; }
        public int NoOfRooms { get; set; }

        public Hotels Hotel { get; set; }
        public RoomFacilities RoomFacilities { get; set; }
        public ICollection<BookingDetails> BookingDetails { get; set; }
    }
}
