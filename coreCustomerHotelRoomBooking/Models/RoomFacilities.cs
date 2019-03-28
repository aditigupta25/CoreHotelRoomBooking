﻿using System;
using System.Collections.Generic;

namespace coreCustomerHotelRoomBooking.Models
{
    public partial class RoomFacilities
    {
        public int RoomFacilityId { get; set; }
        public bool IsAvailable { get; set; }
        public string RoomFacilityDescription { get; set; }
        public bool Wifi { get; set; }
        public bool AirConditioner { get; set; }
        public bool Ekettle { get; set; }
        public bool Refrigerator { get; set; }
        public int RoomId { get; set; }

        public HotelRooms Room { get; set; }
    }
}
