﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CoreHotelRoomBookingAdminPortal.Models
{
    public class HotelRoom
    {
        [Key]
        [DatabaseGenerated((DatabaseGeneratedOption.Identity))]
        public int RoomId { get; set; }
        [Required]
        public string RoomType { get; set; }
        [Required]
        public string RoomDescription { get; set; }
        [Required]
        public int RoomPrice { get; set; }
        public int NoOfRooms { get; set; }
        public string RoomImage { get; set; }
        //[ForeignKey("HotelId")]
        [Required]
        public int HotelId { get; set; }
        public Hotel Hotel { get; set; }
        public RoomFacility RoomFacility { get; set; }
        public List<BookingDetail> BookingDetails { get; set; }
    }
}
