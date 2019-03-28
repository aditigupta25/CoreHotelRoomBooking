using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreHotelRoomBookingAdminPortal.Models
{
    public class Bookings
    {
    
        public int BookingId { get; set; }
       
        public Double BookingPrice { get; set; }
    
        public DateTime BookingDate { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
        public Customer Customer { get; set; }
        public List<BookingDetail> BookingDetails { get; set; }

    }
}
