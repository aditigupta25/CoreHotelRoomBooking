using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CoreHotelRoomBookingAdminPortal.Models
{
    public class HotelType
    {
    
        public int HotelTypeId { get; set; }
        [Required]
        public string HotelTypeName { get; set; }
        [Required]
        public string HotelTypeDescription { get; set; }
        public List<Hotel>Hotels{ get; set; }
    }
}
