﻿// <auto-generated />
using CoreHotelRoomBookingAdminPortal.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CoreHotelRoomBookingAdminPortal.Migrations
{
    [DbContext(typeof(HotelDbContext))]
    [Migration("20190228034830_Hotel5")]
    partial class Hotel5
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.8-servicing-32085")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CoreHotelRoomBookingAdminPortal.Models.Hotel", b =>
                {
                    b.Property<int>("HotelId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("City");

                    b.Property<string>("Country");

                    b.Property<string>("District");

                    b.Property<string>("HotelAddress");

                    b.Property<long>("HotelContactNumber");

                    b.Property<string>("HotelDescription");

                    b.Property<string>("HotelEmailId");

                    b.Property<string>("HotelImage");

                    b.Property<string>("HotelName");

                    b.Property<string>("HotelRating");

                    b.Property<int>("HotelTypeId");

                    b.Property<string>("State");

                    b.HasKey("HotelId");

                    b.HasIndex("HotelTypeId");

                    b.ToTable("Hotels");
                });

            modelBuilder.Entity("CoreHotelRoomBookingAdminPortal.Models.HotelRoom", b =>
                {
                    b.Property<int>("RoomId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("HotelId");

                    b.Property<string>("RoomDescription");

                    b.Property<string>("RoomImage");

                    b.Property<int>("RoomPrice");

                    b.Property<string>("RoomType");

                    b.HasKey("RoomId");

                    b.HasIndex("HotelId");

                    b.ToTable("HotelRooms");
                });

            modelBuilder.Entity("CoreHotelRoomBookingAdminPortal.Models.HotelType", b =>
                {
                    b.Property<int>("HotelTypeId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("HotelTypeDescription");

                    b.Property<string>("HotelTypeName");

                    b.HasKey("HotelTypeId");

                    b.ToTable("HotelTypes");
                });

            modelBuilder.Entity("CoreHotelRoomBookingAdminPortal.Models.RoomFacility", b =>
                {
                    b.Property<int>("RoomFacilityId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("AirConditioner");

                    b.Property<bool>("Ekettle");

                    b.Property<bool>("IsAvailable");

                    b.Property<bool>("Refrigerator");

                    b.Property<string>("RoomFacilityDescription");

                    b.Property<int>("RoomId");

                    b.Property<bool>("Wifi");

                    b.HasKey("RoomFacilityId");

                    b.HasIndex("RoomId")
                        .IsUnique();

                    b.ToTable("RoomFacilities");
                });

            modelBuilder.Entity("CoreHotelRoomBookingAdminPortal.Models.Hotel", b =>
                {
                    b.HasOne("CoreHotelRoomBookingAdminPortal.Models.HotelType", "HotelType")
                        .WithMany("Hotels")
                        .HasForeignKey("HotelTypeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CoreHotelRoomBookingAdminPortal.Models.HotelRoom", b =>
                {
                    b.HasOne("CoreHotelRoomBookingAdminPortal.Models.Hotel", "Hotel")
                        .WithMany("HotelRooms")
                        .HasForeignKey("HotelId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CoreHotelRoomBookingAdminPortal.Models.RoomFacility", b =>
                {
                    b.HasOne("CoreHotelRoomBookingAdminPortal.Models.HotelRoom", "HotelRoom")
                        .WithOne("RoomFacility")
                        .HasForeignKey("CoreHotelRoomBookingAdminPortal.Models.RoomFacility", "RoomId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
