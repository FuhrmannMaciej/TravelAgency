﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TravelAgencyAPI.Models;

namespace TravelAgencyAPI.Migrations
{
    [DbContext(typeof(TravelAgencyContext))]
    [Migration("20211226144518_fix")]
    partial class fix
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.12")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CityHotel", b =>
                {
                    b.Property<int>("CitiesID")
                        .HasColumnType("int");

                    b.Property<int>("HotelsID")
                        .HasColumnType("int");

                    b.HasKey("CitiesID", "HotelsID");

                    b.HasIndex("HotelsID");

                    b.ToTable("CityHotel");
                });

            modelBuilder.Entity("HotelOffer", b =>
                {
                    b.Property<int>("HotelsID")
                        .HasColumnType("int");

                    b.Property<int>("OffersID")
                        .HasColumnType("int");

                    b.HasKey("HotelsID", "OffersID");

                    b.HasIndex("OffersID");

                    b.ToTable("HotelOffer");
                });

            modelBuilder.Entity("HotelServiceRoomType", b =>
                {
                    b.Property<int>("HotelServicesID")
                        .HasColumnType("int");

                    b.Property<int>("RoomTypesID")
                        .HasColumnType("int");

                    b.HasKey("HotelServicesID", "RoomTypesID");

                    b.HasIndex("RoomTypesID");

                    b.ToTable("HotelServiceRoomType");
                });

            modelBuilder.Entity("OfferTransport", b =>
                {
                    b.Property<int>("OffersID")
                        .HasColumnType("int");

                    b.Property<int>("TransportsID")
                        .HasColumnType("int");

                    b.HasKey("OffersID", "TransportsID");

                    b.HasIndex("TransportsID");

                    b.ToTable("OfferTransport");
                });

            modelBuilder.Entity("TicketTypeTransport", b =>
                {
                    b.Property<int>("TicketTypesID")
                        .HasColumnType("int");

                    b.Property<int>("TransportsID")
                        .HasColumnType("int");

                    b.HasKey("TicketTypesID", "TransportsID");

                    b.HasIndex("TransportsID");

                    b.ToTable("TicketTypeTransport");
                });

            modelBuilder.Entity("TravelAgencyAPI.Models.Booking", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BookingStatusID")
                        .HasColumnType("int");

                    b.Property<int>("CustomerID")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("OfferID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("BookingStatusID");

                    b.HasIndex("CustomerID");

                    b.HasIndex("OfferID");

                    b.ToTable("Bookings");
                });

            modelBuilder.Entity("TravelAgencyAPI.Models.BookingStatus", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Status")
                        .HasColumnType("varchar(20)");

                    b.HasKey("ID");

                    b.ToTable("BookingStatuses");
                });

            modelBuilder.Entity("TravelAgencyAPI.Models.City", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CountryID")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("varchar(255)");

                    b.Property<int?>("TransportID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("CountryID");

                    b.HasIndex("TransportID");

                    b.ToTable("Cities");
                });

            modelBuilder.Entity("TravelAgencyAPI.Models.Country", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Code")
                        .HasColumnType("varchar(8)");

                    b.Property<string>("Name")
                        .HasColumnType("varchar(64)");

                    b.HasKey("ID");

                    b.ToTable("Countries");
                });

            modelBuilder.Entity("TravelAgencyAPI.Models.Customer", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .HasColumnType("varchar(255)");

                    b.Property<DateTime>("CustomerFrom")
                        .HasColumnType("datetime2");

                    b.Property<string>("Details")
                        .HasColumnType("text");

                    b.Property<string>("EmailAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("varchar(64)");

                    b.Property<string>("LastName")
                        .HasColumnType("varchar(64)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("TravelAgencyAPI.Models.Hotel", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .HasColumnType("varchar(255)");

                    b.Property<int>("CityID")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("varchar(255)");

                    b.Property<int>("StarRating")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.ToTable("Hotels");
                });

            modelBuilder.Entity("TravelAgencyAPI.Models.HotelService", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("HotelID")
                        .HasColumnType("int");

                    b.Property<int>("RoomTypeID")
                        .HasColumnType("int");

                    b.Property<decimal>("ServicePrice")
                        .HasColumnType("decimal(10,2)");

                    b.HasKey("ID");

                    b.HasIndex("HotelID");

                    b.ToTable("HotelServices");
                });

            modelBuilder.Entity("TravelAgencyAPI.Models.Offer", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("FromDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("HotelID")
                        .HasColumnType("int");

                    b.Property<int>("NumberOfPeople")
                        .HasColumnType("int");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.Property<DateTime>("ToDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("TransportID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.ToTable("Offers");
                });

            modelBuilder.Entity("TravelAgencyAPI.Models.RoomType", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("varchar(64)");

                    b.HasKey("ID");

                    b.ToTable("RoomTypes");
                });

            modelBuilder.Entity("TravelAgencyAPI.Models.TicketType", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("varchar(64)");

                    b.HasKey("ID");

                    b.ToTable("TicketTypes");
                });

            modelBuilder.Entity("TravelAgencyAPI.Models.Transport", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("varchar(255)");

                    b.Property<decimal>("ServicePrice")
                        .HasColumnType("decimal(10,2)");

                    b.Property<int>("TicketTypeID")
                        .HasColumnType("int");

                    b.Property<int>("ToCity")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.ToTable("Transports");
                });

            modelBuilder.Entity("CityHotel", b =>
                {
                    b.HasOne("TravelAgencyAPI.Models.City", null)
                        .WithMany()
                        .HasForeignKey("CitiesID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TravelAgencyAPI.Models.Hotel", null)
                        .WithMany()
                        .HasForeignKey("HotelsID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("HotelOffer", b =>
                {
                    b.HasOne("TravelAgencyAPI.Models.Hotel", null)
                        .WithMany()
                        .HasForeignKey("HotelsID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TravelAgencyAPI.Models.Offer", null)
                        .WithMany()
                        .HasForeignKey("OffersID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("HotelServiceRoomType", b =>
                {
                    b.HasOne("TravelAgencyAPI.Models.HotelService", null)
                        .WithMany()
                        .HasForeignKey("HotelServicesID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TravelAgencyAPI.Models.RoomType", null)
                        .WithMany()
                        .HasForeignKey("RoomTypesID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("OfferTransport", b =>
                {
                    b.HasOne("TravelAgencyAPI.Models.Offer", null)
                        .WithMany()
                        .HasForeignKey("OffersID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TravelAgencyAPI.Models.Transport", null)
                        .WithMany()
                        .HasForeignKey("TransportsID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TicketTypeTransport", b =>
                {
                    b.HasOne("TravelAgencyAPI.Models.TicketType", null)
                        .WithMany()
                        .HasForeignKey("TicketTypesID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TravelAgencyAPI.Models.Transport", null)
                        .WithMany()
                        .HasForeignKey("TransportsID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TravelAgencyAPI.Models.Booking", b =>
                {
                    b.HasOne("TravelAgencyAPI.Models.BookingStatus", "BookingStatus")
                        .WithMany("Bookings")
                        .HasForeignKey("BookingStatusID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TravelAgencyAPI.Models.Customer", "Customer")
                        .WithMany("Bookings")
                        .HasForeignKey("CustomerID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TravelAgencyAPI.Models.Offer", "Offer")
                        .WithMany("Bookings")
                        .HasForeignKey("OfferID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BookingStatus");

                    b.Navigation("Customer");

                    b.Navigation("Offer");
                });

            modelBuilder.Entity("TravelAgencyAPI.Models.City", b =>
                {
                    b.HasOne("TravelAgencyAPI.Models.Country", "Country")
                        .WithMany("Cities")
                        .HasForeignKey("CountryID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TravelAgencyAPI.Models.Transport", null)
                        .WithMany("Cities")
                        .HasForeignKey("TransportID");

                    b.Navigation("Country");
                });

            modelBuilder.Entity("TravelAgencyAPI.Models.HotelService", b =>
                {
                    b.HasOne("TravelAgencyAPI.Models.Hotel", "Hotel")
                        .WithMany("HotelServices")
                        .HasForeignKey("HotelID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Hotel");
                });

            modelBuilder.Entity("TravelAgencyAPI.Models.BookingStatus", b =>
                {
                    b.Navigation("Bookings");
                });

            modelBuilder.Entity("TravelAgencyAPI.Models.Country", b =>
                {
                    b.Navigation("Cities");
                });

            modelBuilder.Entity("TravelAgencyAPI.Models.Customer", b =>
                {
                    b.Navigation("Bookings");
                });

            modelBuilder.Entity("TravelAgencyAPI.Models.Hotel", b =>
                {
                    b.Navigation("HotelServices");
                });

            modelBuilder.Entity("TravelAgencyAPI.Models.Offer", b =>
                {
                    b.Navigation("Bookings");
                });

            modelBuilder.Entity("TravelAgencyAPI.Models.Transport", b =>
                {
                    b.Navigation("Cities");
                });
#pragma warning restore 612, 618
        }
    }
}