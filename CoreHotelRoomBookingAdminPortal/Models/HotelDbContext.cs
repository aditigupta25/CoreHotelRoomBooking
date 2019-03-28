using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreHotelRoomBookingAdminPortal.Models
{
    public class HotelDbContext :DbContext
    {
      
        public DbSet<HotelType> HotelTypes { get; set; }
        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<HotelRoom> HotelRooms { get; set; }
        public DbSet<RoomFacility> RoomFacilities { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Bookings> Bookings { get; set; }
        public DbSet<BookingDetail> BookingDetails { get; set; }

        public HotelDbContext(DbContextOptions<HotelDbContext> options) : base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer("Data Source=TRD-514;Initial Catalog=CoreHotelRoomBooking;Integrated Security=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        
            modelBuilder.Entity<BookingDetail>(build =>
            {
                build.HasKey(t => new { t.BookingId, t.RoomId });
            }

            );
        
        }
    }
}
