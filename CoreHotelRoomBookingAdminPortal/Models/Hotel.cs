using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CoreHotelRoomBookingAdminPortal.Models
{
    public class Hotel
    {
        [Key]
        [DatabaseGenerated((DatabaseGeneratedOption.Identity))]
        public int HotelId { get; set; }

        [Required]
        public string HotelName { get; set; }

        [Required]
        public string HotelDescription { get; set; }

        [Required]
        public string HotelAddress { get; set; }

        [Required]
        public string District { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string State { get; set; }
        [Required]
        public string Country { get; set; }
        [Required]
        public string HotelEmailId { get; set; }
        [Required]
        public string HotelRating { get; set; }
    
        public string HotelImage { get; set; }
        [Required]
        public long HotelContactNumber { get; set; }
        [Required]
        public int HotelTypeId { get; set; } //Foreign Key
        public List<HotelRoom> HotelRooms { get; set; }
        public HotelType HotelType { get; set; }
    }
}
