using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CoreHotelRoomBookingAdminPortal.Models
{
    public class RoomFacility
    {
        public int RoomFacilityId { get; set; }
        public bool IsAvailable{ get; set; }
        public string RoomFacilityDescription { get; set; }
        public bool Wifi { get; set; }
        public bool AirConditioner { get; set; }
        public bool Ekettle { get; set; }
        public bool Refrigerator { get; set; }
        [Required]
        public int RoomId { get; set; }
        public HotelRoom HotelRoom { get; set; }

    }
}
