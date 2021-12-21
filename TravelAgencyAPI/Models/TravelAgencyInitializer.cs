using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace TravelAgencyAPI.Models
{
    public static class TravelAgencyInitializer
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            Random random = new Random();

            using (var context = new TravelAgencyContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<TravelAgencyContext>>()))
            {
                /*                if (context.Offers.Any())
                                {
                                    return;
                                }*/

                context.Countries.AddRange(
                    new Country { ID = 1, Name = "Argentina", Code = "ARG" },
                    new Country { ID = 2, Name = "Canada", Code = "CAN" },
                    new Country { ID = 3, Name = "Cyprus", Code = "CYP" },
                    new Country { ID = 4, Name = "Egypt", Code = "EGY" },
                    new Country { ID = 5, Name = "France", Code = "FRA" },
                    new Country { ID = 6, Name = "Japan", Code = "JPN" },
                    new Country { ID = 7, Name = "Malta", Code = "MLT" },
                    new Country { ID = 8, Name = "New Zealand", Code = "NZL" },
                    new Country { ID = 9, Name = "Norway", Code = "NOR" },
                    new Country { ID = 10, Name = "Poland", Code = "POL" },
                    new Country { ID = 11, Name = "Russia", Code = "RUS" },
                    new Country { ID = 12, Name = "United Kingdom", Code = "GBR" },
                    new Country { ID = 13, Name = "United States", Code = "USA" }
                    );
                context.Database.OpenConnection();
                try
                {
                    context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.Countries ON");
                    context.SaveChanges();
                    context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.Countries OFF");
                }
                finally
                {
                    context.Database.CloseConnection();
                }


                context.Cities.AddRange(
                    new City { ID = 1, Name = "Buenos Aires", CountryID = 1 },
                    new City { ID = 2, Name = "La Plata", CountryID = 1 },
                    new City { ID = 3, Name = "Formosa", CountryID = 1 },
                    new City { ID = 4, Name = "Toronto", CountryID = 2 },
                    new City { ID = 5, Name = "Ottawa", CountryID = 2 },
                    new City { ID = 6, Name = "Larnaca", CountryID = 3 },
                    new City { ID = 7, Name = "Nicosia", CountryID = 3 },
                    new City { ID = 8, Name = "Alexandria", CountryID = 4 },
                    new City { ID = 9, Name = "Cairo", CountryID = 4 },
                    new City { ID = 10,Name = "Paris", CountryID = 5 },
                    new City { ID = 11,Name = "Lyon", CountryID = 5 },
                    new City { ID = 12,Name = "Nice", CountryID = 5 },
                    new City { ID = 13,Name = "Tokio", CountryID = 6 },
                    new City { ID = 14, Name = "Qormi", CountryID = 7 },
                    new City { ID = 15, Name = "Wellington", CountryID = 8 },
                    new City { ID = 16, Name = "Oslo", CountryID = 9 },
                    new City { ID = 17, Name = "Warsaw", CountryID = 10 },
                    new City { ID = 18, Name = "Cracow", CountryID = 10 },
                    new City { ID = 19, Name = "Gdansk", CountryID = 10 },
                    new City { ID = 20, Name = "Kielce", CountryID = 10 },
                    new City { ID = 21, Name = "Moscow", CountryID = 11 },
                    new City { ID = 22, Name = "Abaza", CountryID = 11 },
                    new City { ID = 23,Name = "London", CountryID = 12 },
                    new City { ID = 24,Name = "Liverpool", CountryID = 12 },
                    new City { ID = 25,Name = "New York", CountryID = 13 },
                    new City { ID = 26, Name = "Miami", CountryID = 13 }
                    );
                context.Database.OpenConnection();
                try
                {
                    context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.Cities ON");
                    context.SaveChanges();
                    context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.Cities OFF");
                }
                finally
                {
                    context.Database.CloseConnection();
                }


                context.BookingStatuses.AddRange(
                    new BookingStatus { Status = "Pending" },
                    new BookingStatus { Status = "Reserved" },
                    new BookingStatus { Status = "Paid" },
                    new BookingStatus { Status = "Cancelled" },
                    new BookingStatus { Status = "Archived" }
                    );
                context.SaveChanges();

                context.Customers.AddRange(
                    new Customer { 
                        FirstName = "John",
                        LastName = "Smith",
                        Address = "2033 Ocala Street, Orlando, Florida",
                        EmailAddress = "john.smith@gmail.com",
                        Phone = "407-384-9905",
                        Details = "Your real self - the 'I am I' - is master of this land",
                        CustomerFrom = DateTime.Parse("16/08/2017 12:19:03")
                    },
                    new Customer
                    {
                        FirstName = "Betty",
                        LastName = "Dean",
                        Address = "2731 Timber Oak Drive, Riverside, California",
                        EmailAddress = "betty2121@yahoo.com",
                        Phone = "805-917-9294",
                        Details = "This cop is not buying \"I need it to scratch areas on my back I can't reach\" as an excuse for carrying an AK-47.",
                        CustomerFrom = DateTime.Parse("30/10/2018 04:47:23")
                    },
                    new Customer
                    {
                        FirstName = "Michael",
                        LastName = "Lawson",
                        Address = "3159 Angus Road, New York, New York",
                        EmailAddress = "law12@gmail.com",
                        Phone = "212-470-8212",
                        Details = "Proud music maven. Prone to fits of apathy. Internet aficionado. Coffee specialist. Twitteraholic. Evil organizer.",
                        CustomerFrom = DateTime.Parse("08/03/2020 12:28:49")
                    }
                    );
                context.SaveChanges();

                context.Hotels.AddRange(
                    new Hotel {ID = 1, CityID = 1, Name = "Manoir Hovey", Address = "1850 Willow Oaks Lane", StarRating = 3},
                    new Hotel {ID = 2, CityID = 2, Name = "Grand Hotel", Address = "4086 Lyndon Street", StarRating = 4},
                    new Hotel {ID = 3, CityID = 3, Name = "Blue Hotel", Address = "1599 Quincy Street", StarRating = 2},
                    new Hotel {ID = 4, CityID = 4, Name = "Manoir Hovey", Address = "4525 Cityview Drive", StarRating = 3},
                    new Hotel {ID = 5, CityID = 5, Name = "The Opposite House", Address = "1850 Willow Oaks Lane", StarRating = 3},
                    new Hotel {ID = 6, CityID = 6, Name = "Hotel Felix", Address = "1850 Willow Oaks Lane", StarRating = 5},
                    new Hotel {ID = 7, CityID = 7, Name = "The Opposite House", Address = "1850 Willow Oaks Lane", StarRating = 5},
                    new Hotel {ID = 8, CityID = 8, Name = "Grand Hotel", Address = "867 Baker Avenue", StarRating = 3},
                    new Hotel {ID = 9, CityID = 9, Name = "Hotel Felix", Address = "1850 Willow Oaks Lane", StarRating = 4},
                    new Hotel {ID = 10, CityID = 10, Name = "Hotel Felix", Address = "4395 Yorkie Lane", StarRating = 5},
                    new Hotel {ID = 11, CityID = 11, Name = "Grace Hotel", Address = "91 Hillside Street", StarRating = 2},
                    new Hotel {ID = 12, CityID = 12, Name = "Hotel Felix", Address = "1794 Rockford Road", StarRating = 3},
                    new Hotel {ID = 13, CityID = 13, Name = "The Opposite House", Address = "1794 Rockford Road", StarRating = 1},
                    new Hotel {ID = 14, CityID = 14, Name = "Shangri-La the Shard", Address = "1850 Willow Oaks Lane", StarRating = 5},
                    new Hotel {ID = 15, CityID = 15, Name = "Hotel Felix", Address = "4395 Yorkie Lane", StarRating = 3},
                    new Hotel {ID = 16, CityID = 16, Name = "Grace Hotel", Address = "1850 Willow Oaks Lane", StarRating = 4},
                    new Hotel {ID = 17, CityID = 17, Name = "Shangri-La the Shard", Address = "1850 Willow Oaks Lane", StarRating = 5},
                    new Hotel {ID = 18, CityID = 18, Name = "Hotel Paracas", Address = "4525 Cityview Drive", StarRating = 3},
                    new Hotel {ID = 19, CityID = 19, Name = "Hotel Paracas", Address = "1850 Willow Oaks Lane", StarRating = 5},
                    new Hotel {ID = 20, CityID = 20, Name = "Hotel Felix", Address = "867 Baker Avenue", StarRating = 4},
                    new Hotel {ID = 21, CityID = 21, Name = "Grace Hotel", Address = "1850 Willow Oaks Lane", StarRating = 3},
                    new Hotel {ID = 22, CityID = 22, Name = "Hotel Felix", Address = "91 Hillside Street", StarRating = 4},
                    new Hotel {ID = 23, CityID = 23, Name = "Grand Hotel", Address = "3444 Drainer Avenue", StarRating = 3},
                    new Hotel {ID = 24, CityID = 24, Name = "Hotel Paracas", Address = "1850 Willow Oaks Lane", StarRating = 3},
                    new Hotel {ID = 25, CityID = 25, Name = "Grand Hotel", Address = "3444 Drainer Avenue", StarRating = 3},
                    new Hotel {ID = 26, CityID = 26, Name = "Taj Holiday Village Resort & Spa, Goa", Address = "4525 Cityview Drive", StarRating = 4},
                    new Hotel {ID = 27, CityID = 8, Name = "Taj Holiday Village Resort & Spa, Goa", Address = "1794 Rockford Road", StarRating = 3},
                    new Hotel {ID = 28, CityID = 2, Name = "Grand Hotel", Address = "91 Hillside Street", StarRating = 2}
                    );
                context.Database.OpenConnection();
                try
                {
                    context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.Hotels ON");
                    context.SaveChanges();
                    context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.Hotels OFF");
                }
                finally
                {
                    context.Database.CloseConnection();
                }

                context.RoomTypes.AddRange(
                    new RoomType { Name = "Single" },
                    new RoomType { Name = "Double" },
                    new RoomType { Name = "Triple" },
                    new RoomType { Name = "King" },
                    new RoomType { Name = "Apartment" }
                    );
                context.SaveChanges();

                context.TicketTypes.AddRange(
                    new TicketType { Name = "Normal" },
                    new TicketType { Name = "VIP" },
                    new TicketType { Name = "Student" },
                    new TicketType { Name = "Veteran" }
                    );
                context.SaveChanges();

                context.HotelServices.AddRange(
                    new HotelService { HotelID = 1, RoomTypeID = 1, ServicePrice = 122.78M},
                    new HotelService { HotelID = 2, RoomTypeID = 2, ServicePrice = 399.59M},
                    new HotelService { HotelID = 3, RoomTypeID = 3, ServicePrice = 870.40M },
                    new HotelService { HotelID = 4, RoomTypeID = 2, ServicePrice = 230.52M},
                    new HotelService { HotelID = 5, RoomTypeID = 4, ServicePrice = 691.32M},
                    new HotelService { HotelID = 6, RoomTypeID = 3, ServicePrice = 510.23M},
                    new HotelService { HotelID = 7, RoomTypeID = 5, ServicePrice = 835.31M},
                    new HotelService { HotelID = 8, RoomTypeID = 5, ServicePrice = 230.52M},
                    new HotelService { HotelID = 9, RoomTypeID = 2, ServicePrice = 230.52M},
                    new HotelService { HotelID = 10, RoomTypeID = 3, ServicePrice = 230.52M},
                    new HotelService { HotelID = 11, RoomTypeID = 5, ServicePrice = 617.59M},
                    new HotelService { HotelID = 12, RoomTypeID = 1, ServicePrice = 617.59M},
                    new HotelService { HotelID = 13, RoomTypeID = 3, ServicePrice = 510.23M},
                    new HotelService { HotelID = 14, RoomTypeID = 2, ServicePrice = 946.82M},
                    new HotelService { HotelID = 15, RoomTypeID = 3, ServicePrice = 946.82M},
                    new HotelService { HotelID = 16, RoomTypeID = 4, ServicePrice = 510.23M},
                    new HotelService { HotelID = 17, RoomTypeID = 5, ServicePrice = 617.59M},
                    new HotelService { HotelID = 18, RoomTypeID = 1, ServicePrice = 617.59M},
                    new HotelService { HotelID = 19, RoomTypeID = 1, ServicePrice = 946.82M},
                    new HotelService { HotelID = 20, RoomTypeID = 1, ServicePrice = 835.31M},
                    new HotelService { HotelID = 21, RoomTypeID = 5, ServicePrice = 617.59M},
                    new HotelService { HotelID = 22, RoomTypeID = 4, ServicePrice = 835.31M},
                    new HotelService { HotelID = 23, RoomTypeID = 2, ServicePrice = 835.31M},
                    new HotelService { HotelID = 24, RoomTypeID = 3, ServicePrice = 835.31M},
                    new HotelService { HotelID = 25, RoomTypeID = 1, ServicePrice = 617.59M},
                    new HotelService { HotelID = 26, RoomTypeID = 4, ServicePrice = 617.59M},
                    new HotelService { HotelID = 27, RoomTypeID = 4, ServicePrice = 617.59M},
                    new HotelService { HotelID = 28, RoomTypeID = 5, ServicePrice = 230.52M},
                    new HotelService { HotelID = 1, RoomTypeID = 1, ServicePrice = 122.78M },
                    new HotelService { HotelID = 2, RoomTypeID = 2, ServicePrice = 399.59M },
                    new HotelService { HotelID = 3, RoomTypeID = 3, ServicePrice = 870.40M },
                    new HotelService { HotelID = 4, RoomTypeID = 2, ServicePrice = 230.52M },
                    new HotelService { HotelID = 5, RoomTypeID = 4, ServicePrice = 691.32M },
                    new HotelService { HotelID = 6, RoomTypeID = 3, ServicePrice = 510.23M },
                    new HotelService { HotelID = 7, RoomTypeID = 5, ServicePrice = 835.31M },
                    new HotelService { HotelID = 8, RoomTypeID = 5, ServicePrice = 230.52M },
                    new HotelService { HotelID = 9, RoomTypeID = 2, ServicePrice = 230.52M },
                    new HotelService { HotelID = 10, RoomTypeID = 3, ServicePrice = 230.52M },
                    new HotelService { HotelID = 11, RoomTypeID = 5, ServicePrice = 617.59M },
                    new HotelService { HotelID = 2, RoomTypeID = 1, ServicePrice = 617.59M },
                    new HotelService { HotelID = 1, RoomTypeID = 3, ServicePrice = 510.23M },
                    new HotelService { HotelID = 1, RoomTypeID = 2, ServicePrice = 946.82M },
                    new HotelService { HotelID = 15, RoomTypeID = 3, ServicePrice = 946.82M },
                    new HotelService { HotelID = 16, RoomTypeID = 4, ServicePrice = 510.23M },
                    new HotelService { HotelID = 17, RoomTypeID = 5, ServicePrice = 617.59M },
                    new HotelService { HotelID = 18, RoomTypeID = 1, ServicePrice = 617.59M },
                    new HotelService { HotelID = 9, RoomTypeID = 1, ServicePrice = 946.82M },
                    new HotelService { HotelID = 2, RoomTypeID = 1, ServicePrice = 835.31M },
                    new HotelService { HotelID = 21, RoomTypeID = 5, ServicePrice = 617.59M },
                    new HotelService { HotelID = 22, RoomTypeID = 4, ServicePrice = 835.31M },
                    new HotelService { HotelID = 23, RoomTypeID = 2, ServicePrice = 835.31M },
                    new HotelService { HotelID = 4, RoomTypeID = 3, ServicePrice = 835.31M },
                    new HotelService { HotelID = 5, RoomTypeID = 1, ServicePrice = 617.59M },
                    new HotelService { HotelID = 6, RoomTypeID = 4, ServicePrice = 617.59M },
                    new HotelService { HotelID = 7, RoomTypeID = 4, ServicePrice = 617.59M },
                    new HotelService { HotelID = 28, RoomTypeID = 5, ServicePrice = 230.52M }
                    );

                context.Database.OpenConnection();
                try
                {
                    context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.HotelServices ON");
                    context.SaveChanges();
                    context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.HotelServices OFF");
                }
                finally
                {
                    context.Database.CloseConnection();
                }

                context.Transports.AddRange(
                    new Transport { Name = "Plane", TicketTypeID = random.Next(1,4), FromCity = random.Next(1,26), ToCity = random.Next(1, 26), ServicePrice = 95.20M},
                    new Transport { Name = "Train", TicketTypeID = random.Next(1,4), FromCity = random.Next(1, 26), ToCity = random.Next(1, 26), ServicePrice = 364.26M},
                    new Transport { Name = "Plane", TicketTypeID = random.Next(1,4), FromCity = random.Next(1, 26), ToCity = random.Next(1, 26), ServicePrice = 95.20M},
                    new Transport { Name = "Bus", TicketTypeID = random.Next(1,4), FromCity = random.Next(1, 26), ToCity = random.Next(1, 26), ServicePrice = 95.20M},
                    new Transport { Name = "Bus", TicketTypeID = random.Next(1,4), FromCity = random.Next(1, 26), ToCity = random.Next(1, 26), ServicePrice = 456.35M},
                    new Transport { Name = "Ship", TicketTypeID = random.Next(1,4), FromCity = random.Next(1, 26), ToCity = random.Next(1, 26), ServicePrice = 456.35M},
                    new Transport { Name = "Ship", TicketTypeID = random.Next(1,4), FromCity = random.Next(1, 26), ToCity = random.Next(1, 26), ServicePrice = 419.98M},
                    new Transport { Name = "Car", TicketTypeID = random.Next(1,4), FromCity = random.Next(1, 26), ToCity = random.Next(1, 26), ServicePrice = 419.98M},
                    new Transport { Name = "Car", TicketTypeID = random.Next(1,4), FromCity = random.Next(1, 26), ToCity = random.Next(1, 26), ServicePrice = 419.98M},
                    new Transport { Name = "Plane", TicketTypeID = random.Next(1,4), FromCity = random.Next(1, 26), ToCity = random.Next(1, 26), ServicePrice = 456.35M},
                    new Transport { Name = "Plane", TicketTypeID = random.Next(1,4), FromCity = random.Next(1, 26), ToCity = random.Next(1, 26), ServicePrice = 456.35M},
                    new Transport { Name = "Bus", TicketTypeID = random.Next(1,4), FromCity = random.Next(1, 26), ToCity = random.Next(1, 26), ServicePrice = 456.35M},
                    new Transport { Name = "Car", TicketTypeID = random.Next(1,4), FromCity = random.Next(1, 26), ToCity = random.Next(1, 26), ServicePrice = 364.26M},
                    new Transport { Name = "Plane", TicketTypeID = random.Next(1,4), FromCity = random.Next(1, 26), ToCity = random.Next(1, 26), ServicePrice = 364.26M},
                    new Transport { Name = "Plane", TicketTypeID = random.Next(1,4), FromCity = random.Next(1, 26), ToCity = random.Next(1, 26), ServicePrice = 247.65M},
                    new Transport { Name = "Bus", TicketTypeID = random.Next(1,4), FromCity = random.Next(1, 26), ToCity = random.Next(1, 26), ServicePrice = 247.65M},
                    new Transport { Name = "Plane", TicketTypeID = random.Next(1,4), FromCity = random.Next(1, 26), ToCity = random.Next(1, 26), ServicePrice = 95.20M},
                    new Transport { Name = "Ship", TicketTypeID = random.Next(1,4), FromCity = random.Next(1, 26), ToCity = random.Next(1, 26), ServicePrice = 95.20M},
                    new Transport { Name = "Car", TicketTypeID = random.Next(1,4), FromCity = random.Next(1, 26), ToCity = random.Next(1, 26), ServicePrice = 419.98M},
                    new Transport { Name = "Train", TicketTypeID = random.Next(1,4), FromCity = random.Next(1, 26), ToCity = random.Next(1, 26), ServicePrice = 419.98M},
                    new Transport { Name = "Train", TicketTypeID = random.Next(1,4), FromCity = random.Next(1, 26), ToCity = random.Next(1, 26), ServicePrice = 247.65M},
                    new Transport { Name = "Ship", TicketTypeID = random.Next(1,4), FromCity = random.Next(1, 26), ToCity = random.Next(1, 26), ServicePrice = 364.26M},
                    new Transport { Name = "Plane", TicketTypeID = random.Next(1,4), FromCity = random.Next(1, 26), ToCity = random.Next(1, 26), ServicePrice = 456.35M},
                    new Transport { Name = "Plane", TicketTypeID = random.Next(1,4), FromCity = random.Next(1, 26), ToCity = random.Next(1, 26), ServicePrice = 456.35M},
                    new Transport { Name = "Bus", TicketTypeID = random.Next(1,4), FromCity = random.Next(1, 26), ToCity = random.Next(1, 26), ServicePrice = 456.35M},
                    new Transport { Name = "Bus", TicketTypeID = random.Next(1,4), FromCity = random.Next(1, 26), ToCity = random.Next(1, 26), ServicePrice = 364.26M},
                    new Transport { Name = "Plane", TicketTypeID = random.Next(1,4), FromCity = random.Next(1, 26), ToCity = random.Next(1, 26), ServicePrice = 364.26M},
                    new Transport { Name = "Plane", TicketTypeID = random.Next(1,4), FromCity = random.Next(1, 26), ToCity = random.Next(1, 26), ServicePrice = 364.26M},
                    new Transport { Name = "Car", TicketTypeID = random.Next(1,4), FromCity = random.Next(1, 26), ToCity = random.Next(1, 26), ServicePrice = 247.65M},
                    new Transport { Name = "Train", TicketTypeID = random.Next(1,4), FromCity = random.Next(1, 26), ToCity = random.Next(1, 26), ServicePrice = 419.98M},
                    new Transport { Name = "Bus", TicketTypeID = random.Next(1,4), FromCity = random.Next(1, 26), ToCity = random.Next(1, 26), ServicePrice = 364.26M},
                    new Transport { Name = "Bus", TicketTypeID = random.Next(1,4), FromCity = random.Next(1, 26), ToCity = random.Next(1, 26), ServicePrice = 456.35M},
                    new Transport { Name = "Plane", TicketTypeID = random.Next(1, 4), FromCity = random.Next(1, 26), ToCity = random.Next(1, 26), ServicePrice = 95.20M },
                    new Transport { Name = "Train", TicketTypeID = random.Next(1, 4), FromCity = random.Next(1, 26), ToCity = random.Next(1, 26), ServicePrice = 364.26M },
                    new Transport { Name = "Plane", TicketTypeID = random.Next(1, 4), FromCity = random.Next(1, 26), ToCity = random.Next(1, 26), ServicePrice = 95.20M },
                    new Transport { Name = "Bus", TicketTypeID = random.Next(1, 4), FromCity = random.Next(1, 26), ToCity = random.Next(1, 26), ServicePrice = 95.20M },
                    new Transport { Name = "Bus", TicketTypeID = random.Next(1, 4), FromCity = random.Next(1, 26), ToCity = random.Next(1, 26), ServicePrice = 456.35M },
                    new Transport { Name = "Ship", TicketTypeID = random.Next(1, 4), FromCity = random.Next(1, 26), ToCity = random.Next(1, 26), ServicePrice = 456.35M },
                    new Transport { Name = "Ship", TicketTypeID = random.Next(1, 4), FromCity = random.Next(1, 26), ToCity = random.Next(1, 26), ServicePrice = 419.98M },
                    new Transport { Name = "Car", TicketTypeID = random.Next(1, 4), FromCity = random.Next(1, 26), ToCity = random.Next(1, 26), ServicePrice = 419.98M },
                    new Transport { Name = "Car", TicketTypeID = random.Next(1, 4), FromCity = random.Next(1, 26), ToCity = random.Next(1, 26), ServicePrice = 419.98M },
                    new Transport { Name = "Plane", TicketTypeID = random.Next(1, 4), FromCity = random.Next(1, 26), ToCity = random.Next(1, 26), ServicePrice = 456.35M },
                    new Transport { Name = "Plane", TicketTypeID = random.Next(1, 4), FromCity = random.Next(1, 26), ToCity = random.Next(1, 26), ServicePrice = 456.35M },
                    new Transport { Name = "Bus", TicketTypeID = random.Next(1, 4), FromCity = random.Next(1, 26), ToCity = random.Next(1, 26), ServicePrice = 456.35M },
                    new Transport { Name = "Car", TicketTypeID = random.Next(1, 4), FromCity = random.Next(1, 26), ToCity = random.Next(1, 26), ServicePrice = 364.26M },
                    new Transport { Name = "Plane", TicketTypeID = random.Next(1, 4), FromCity = random.Next(1, 26), ToCity = random.Next(1, 26), ServicePrice = 364.26M },
                    new Transport { Name = "Plane", TicketTypeID = random.Next(1, 4), FromCity = random.Next(1, 26), ToCity = random.Next(1, 26), ServicePrice = 247.65M },
                    new Transport { Name = "Bus", TicketTypeID = random.Next(1, 4), FromCity = random.Next(1, 26), ToCity = random.Next(1, 26), ServicePrice = 247.65M },
                    new Transport { Name = "Plane", TicketTypeID = random.Next(1, 4), FromCity = random.Next(1, 26), ToCity = random.Next(1, 26), ServicePrice = 95.20M },
                    new Transport { Name = "Ship", TicketTypeID = random.Next(1, 4), FromCity = random.Next(1, 26), ToCity = random.Next(1, 26), ServicePrice = 95.20M },
                    new Transport { Name = "Car", TicketTypeID = random.Next(1, 4), FromCity = random.Next(1, 26), ToCity = random.Next(1, 26), ServicePrice = 419.98M },
                    new Transport { Name = "Train", TicketTypeID = random.Next(1, 4), FromCity = random.Next(1, 26), ToCity = random.Next(1, 26), ServicePrice = 419.98M },
                    new Transport { Name = "Train", TicketTypeID = random.Next(1, 4), FromCity = random.Next(1, 26), ToCity = random.Next(1, 26), ServicePrice = 247.65M },
                    new Transport { Name = "Ship", TicketTypeID = random.Next(1, 4), FromCity = random.Next(1, 26), ToCity = random.Next(1, 26), ServicePrice = 364.26M },
                    new Transport { Name = "Plane", TicketTypeID = random.Next(1, 4), FromCity = random.Next(1, 26), ToCity = random.Next(1, 26), ServicePrice = 456.35M },
                    new Transport { Name = "Plane", TicketTypeID = random.Next(1, 4), FromCity = random.Next(1, 26), ToCity = random.Next(1, 26), ServicePrice = 456.35M },
                    new Transport { Name = "Bus", TicketTypeID = random.Next(1, 4), FromCity = random.Next(1, 26), ToCity = random.Next(1, 26), ServicePrice = 456.35M },
                    new Transport { Name = "Bus", TicketTypeID = random.Next(1, 4), FromCity = random.Next(1, 26), ToCity = random.Next(1, 26), ServicePrice = 364.26M },
                    new Transport { Name = "Plane", TicketTypeID = random.Next(1, 4), FromCity = random.Next(1, 26), ToCity = random.Next(1, 26), ServicePrice = 364.26M },
                    new Transport { Name = "Plane", TicketTypeID = random.Next(1, 4), FromCity = random.Next(1, 26), ToCity = random.Next(1, 26), ServicePrice = 364.26M },
                    new Transport { Name = "Car", TicketTypeID = random.Next(1, 4), FromCity = random.Next(1, 26), ToCity = random.Next(1, 26), ServicePrice = 247.65M },
                    new Transport { Name = "Train", TicketTypeID = random.Next(1, 4), FromCity = random.Next(1, 26), ToCity = random.Next(1, 26), ServicePrice = 419.98M },
                    new Transport { Name = "Bus", TicketTypeID = random.Next(1, 4), FromCity = random.Next(1, 26), ToCity = random.Next(1, 26), ServicePrice = 364.26M },
                    new Transport { Name = "Bus", TicketTypeID = random.Next(1, 4), FromCity = random.Next(1, 26), ToCity = random.Next(1, 26), ServicePrice = 456.35M }
                    );
                context.SaveChanges();

                context.Offers.AddRange(
                    new Offer { HotelID = random.Next(1, 28), TransportID = random.Next(1, 63), NumberOfPeople = random.Next(1, 5), FromDate = DateTime.Parse("11/12/2021"), ToDate = DateTime.Parse("15/12/2021") },
                    new Offer { HotelID = random.Next(1, 28), TransportID = random.Next(1, 63), NumberOfPeople = random.Next(1, 5), FromDate = DateTime.Parse("12/12/2021"), ToDate = DateTime.Parse("15/12/2021") },
                    new Offer { HotelID = random.Next(1, 28), TransportID = random.Next(1, 63), NumberOfPeople = random.Next(1, 5), FromDate = DateTime.Parse("13/12/2021"), ToDate = DateTime.Parse("15/12/2021") },
                    new Offer { HotelID = random.Next(1, 28), TransportID = random.Next(1, 63), NumberOfPeople = random.Next(1, 5), FromDate = DateTime.Parse("14/12/2021"), ToDate = DateTime.Parse("15/12/2021") },
                    new Offer { HotelID = random.Next(1, 28), TransportID = random.Next(1, 63), NumberOfPeople = random.Next(1, 5), FromDate = DateTime.Parse("15/12/2021"), ToDate = DateTime.Parse("20/12/2021") },
                    new Offer { HotelID = random.Next(1, 28), TransportID = random.Next(1, 63), NumberOfPeople = random.Next(1, 5), FromDate = DateTime.Parse("16/12/2021"), ToDate = DateTime.Parse("20/12/2021") },
                    new Offer { HotelID = random.Next(1, 28), TransportID = random.Next(1, 63), NumberOfPeople = random.Next(1, 5), FromDate = DateTime.Parse("17/12/2021"), ToDate = DateTime.Parse("20/12/2021") },
                    new Offer { HotelID = random.Next(1, 28), TransportID = random.Next(1, 63), NumberOfPeople = random.Next(1, 5), FromDate = DateTime.Parse("18/12/2021"), ToDate = DateTime.Parse("20/12/2021") },
                    new Offer { HotelID = random.Next(1, 28), TransportID = random.Next(1, 63), NumberOfPeople = random.Next(1, 5), FromDate = DateTime.Parse("11/12/2021"), ToDate = DateTime.Parse("20/12/2021") },
                    new Offer { HotelID = random.Next(1, 28), TransportID = random.Next(1, 63), NumberOfPeople = random.Next(1, 5), FromDate = DateTime.Parse("21/12/2021"), ToDate = DateTime.Parse("03/01/2022") },
                    new Offer { HotelID = random.Next(1, 28), TransportID = random.Next(1, 63), NumberOfPeople = random.Next(1, 5), FromDate = DateTime.Parse("31/12/2021"), ToDate = DateTime.Parse("03/01/2022") },
                    new Offer { HotelID = random.Next(1, 28), TransportID = random.Next(1, 63), NumberOfPeople = random.Next(1, 5), FromDate = DateTime.Parse("24/12/2021"), ToDate = DateTime.Parse("03/01/2022") },
                    new Offer { HotelID = random.Next(1, 28), TransportID = random.Next(1, 63), NumberOfPeople = random.Next(1, 5), FromDate = DateTime.Parse("25/12/2021"), ToDate = DateTime.Parse("03/01/2022") },
                    new Offer { HotelID = random.Next(1, 28), TransportID = random.Next(1, 63), NumberOfPeople = random.Next(1, 5), FromDate = DateTime.Parse("26/12/2021"), ToDate = DateTime.Parse("03/01/2022") },
                    new Offer { HotelID = random.Next(1, 28), TransportID = random.Next(1, 63), NumberOfPeople = random.Next(1, 5), FromDate = DateTime.Parse("27/12/2021"), ToDate = DateTime.Parse("03/01/2022") },
                    new Offer { HotelID = random.Next(1, 28), TransportID = random.Next(1, 63), NumberOfPeople = random.Next(1, 5), FromDate = DateTime.Parse("28/12/2021"), ToDate = DateTime.Parse("03/01/2022") },
                    new Offer { HotelID = random.Next(1, 28), TransportID = random.Next(1, 63), NumberOfPeople = random.Next(1, 5), FromDate = DateTime.Parse("29/12/2021"), ToDate = DateTime.Parse("03/01/2022") },
                    new Offer { HotelID = random.Next(1, 28), TransportID = random.Next(1, 63), NumberOfPeople = random.Next(1, 5), FromDate = DateTime.Parse("01/01/2022"), ToDate = DateTime.Parse("12/01/2022") },
                    new Offer { HotelID = random.Next(1, 28), TransportID = random.Next(1, 63), NumberOfPeople = random.Next(1, 5), FromDate = DateTime.Parse("01/01/2022"), ToDate = DateTime.Parse("12/01/2022") },
                    new Offer { HotelID = random.Next(1, 28), TransportID = random.Next(1, 63), NumberOfPeople = random.Next(1, 5), FromDate = DateTime.Parse("02/01/2022"), ToDate = DateTime.Parse("12/01/2022") },
                    new Offer { HotelID = random.Next(1, 28), TransportID = random.Next(1, 63), NumberOfPeople = random.Next(1, 5), FromDate = DateTime.Parse("03/01/2022"), ToDate = DateTime.Parse("12/01/2022") },
                    new Offer { HotelID = random.Next(1, 28), TransportID = random.Next(1, 63), NumberOfPeople = random.Next(1, 5), FromDate = DateTime.Parse("04/01/2022"), ToDate = DateTime.Parse("12/01/2022") },
                    new Offer { HotelID = random.Next(1, 28), TransportID = random.Next(1, 63), NumberOfPeople = random.Next(1, 5), FromDate = DateTime.Parse("05/01/2022"), ToDate = DateTime.Parse("12/01/2022") },
                    new Offer { HotelID = random.Next(1, 28), TransportID = random.Next(1, 63), NumberOfPeople = random.Next(1, 5), FromDate = DateTime.Parse("06/01/2022"), ToDate = DateTime.Parse("12/01/2022") },
                    new Offer { HotelID = random.Next(1, 28), TransportID = random.Next(1, 63), NumberOfPeople = random.Next(1, 5), FromDate = DateTime.Parse("07/01/2022"), ToDate = DateTime.Parse("12/01/2022") },
                    new Offer { HotelID = random.Next(1, 28), TransportID = random.Next(1, 63), NumberOfPeople = random.Next(1, 5), FromDate = DateTime.Parse("08/01/2022"), ToDate = DateTime.Parse("12/01/2022") },
                    new Offer { HotelID = random.Next(1, 28), TransportID = random.Next(1, 63), NumberOfPeople = random.Next(1, 5), FromDate = DateTime.Parse("09/01/2022"), ToDate = DateTime.Parse("12/01/2022") },
                    new Offer { HotelID = random.Next(1, 28), TransportID = random.Next(1, 63), NumberOfPeople = random.Next(1, 5), FromDate = DateTime.Parse("10/01/2022"), ToDate = DateTime.Parse("12/01/2022") },
                    new Offer { HotelID = random.Next(1, 28), TransportID = random.Next(1, 63), NumberOfPeople = random.Next(1, 5), FromDate = DateTime.Parse("21/01/2022"), ToDate = DateTime.Parse("31/01/2022") },
                    new Offer { HotelID = random.Next(1, 28), TransportID = random.Next(1, 63), NumberOfPeople = random.Next(1, 5), FromDate = DateTime.Parse("22/01/2022"), ToDate = DateTime.Parse("31/01/2022") },
                    new Offer { HotelID = random.Next(1, 28), TransportID = random.Next(1, 63), NumberOfPeople = random.Next(1, 5), FromDate = DateTime.Parse("23/01/2022"), ToDate = DateTime.Parse("31/01/2022") },
                    new Offer { HotelID = random.Next(1, 28), TransportID = random.Next(1, 63), NumberOfPeople = random.Next(1, 5), FromDate = DateTime.Parse("24/01/2022"), ToDate = DateTime.Parse("31/01/2022") },
                    new Offer { HotelID = random.Next(1, 28), TransportID = random.Next(1, 63), NumberOfPeople = random.Next(1, 5), FromDate = DateTime.Parse("25/01/2022"), ToDate = DateTime.Parse("31/01/2022") },
                    new Offer { HotelID = random.Next(1, 28), TransportID = random.Next(1, 63), NumberOfPeople = random.Next(1, 5), FromDate = DateTime.Parse("27/01/2022"), ToDate = DateTime.Parse("31/01/2022") },
                    new Offer { HotelID = random.Next(1, 28), TransportID = random.Next(1, 63), NumberOfPeople = random.Next(1, 5), FromDate = DateTime.Parse("01/02/2022"), ToDate = DateTime.Parse("11/02/2022") },
                    new Offer { HotelID = random.Next(1, 28), TransportID = random.Next(1, 63), NumberOfPeople = random.Next(1, 5), FromDate = DateTime.Parse("02/02/2022"), ToDate = DateTime.Parse("11/02/2022") },
                    new Offer { HotelID = random.Next(1, 28), TransportID = random.Next(1, 63), NumberOfPeople = random.Next(1, 5), FromDate = DateTime.Parse("03/02/2022"), ToDate = DateTime.Parse("11/02/2022") },
                    new Offer { HotelID = random.Next(1, 28), TransportID = random.Next(1, 63), NumberOfPeople = random.Next(1, 5), FromDate = DateTime.Parse("04/02/2022"), ToDate = DateTime.Parse("11/02/2022") },
                    new Offer { HotelID = random.Next(1, 28), TransportID = random.Next(1, 63), NumberOfPeople = random.Next(1, 5), FromDate = DateTime.Parse("05/02/2022"), ToDate = DateTime.Parse("11/02/2022") },
                    new Offer { HotelID = random.Next(1, 28), TransportID = random.Next(1, 63), NumberOfPeople = random.Next(1, 5), FromDate = DateTime.Parse("06/02/2022"), ToDate = DateTime.Parse("11/02/2022") },
                    new Offer { HotelID = random.Next(1, 28), TransportID = random.Next(1, 63), NumberOfPeople = random.Next(1, 5), FromDate = DateTime.Parse("07/02/2022"), ToDate = DateTime.Parse("11/02/2022") },
                    new Offer { HotelID = random.Next(1, 28), TransportID = random.Next(1, 63), NumberOfPeople = random.Next(1, 5), FromDate = DateTime.Parse("08/02/2022"), ToDate = DateTime.Parse("11/02/2022") },
                    new Offer { HotelID = random.Next(1, 28), TransportID = random.Next(1, 63), NumberOfPeople = random.Next(1, 5), FromDate = DateTime.Parse("09/02/2022"), ToDate = DateTime.Parse("11/02/2022") },
                    new Offer { HotelID = random.Next(1, 28), TransportID = random.Next(1, 63), NumberOfPeople = random.Next(1, 5), FromDate = DateTime.Parse("10/02/2022"), ToDate = DateTime.Parse("11/02/2022") },
                    new Offer { HotelID = random.Next(1, 28), TransportID = random.Next(1, 63), NumberOfPeople = random.Next(1, 5), FromDate = DateTime.Parse("21/02/2022"), ToDate = DateTime.Parse("28/02/2022") },
                    new Offer { HotelID = random.Next(1, 28), TransportID = random.Next(1, 63), NumberOfPeople = random.Next(1, 5), FromDate = DateTime.Parse("21/02/2022"), ToDate = DateTime.Parse("28/02/2022") },
                    new Offer { HotelID = random.Next(1, 28), TransportID = random.Next(1, 63), NumberOfPeople = random.Next(1, 5), FromDate = DateTime.Parse("22/02/2022"), ToDate = DateTime.Parse("28/02/2022") },
                    new Offer { HotelID = random.Next(1, 28), TransportID = random.Next(1, 63), NumberOfPeople = random.Next(1, 5), FromDate = DateTime.Parse("23/02/2022"), ToDate = DateTime.Parse("28/02/2022") },
                    new Offer { HotelID = random.Next(1, 28), TransportID = random.Next(1, 63), NumberOfPeople = random.Next(1, 5), FromDate = DateTime.Parse("24/02/2022"), ToDate = DateTime.Parse("28/02/2022") },
                    new Offer { HotelID = random.Next(1, 28), TransportID = random.Next(1, 63), NumberOfPeople = random.Next(1, 5), FromDate = DateTime.Parse("25/02/2022"), ToDate = DateTime.Parse("28/02/2022") },
                    new Offer { HotelID = random.Next(1, 28), TransportID = random.Next(1, 63), NumberOfPeople = random.Next(1, 5), FromDate = DateTime.Parse("26/02/2022"), ToDate = DateTime.Parse("28/02/2022") },
                    new Offer { HotelID = random.Next(1, 28), TransportID = random.Next(1, 63), NumberOfPeople = random.Next(1, 5), FromDate = DateTime.Parse("27/02/2022"), ToDate = DateTime.Parse("28/02/2022") },
                    new Offer { HotelID = random.Next(1, 28), TransportID = random.Next(1, 63), NumberOfPeople = random.Next(1, 5), FromDate = DateTime.Parse("01/03/2022"), ToDate = DateTime.Parse("10/03/2022") },
                    new Offer { HotelID = random.Next(1, 28), TransportID = random.Next(1, 63), NumberOfPeople = random.Next(1, 5), FromDate = DateTime.Parse("02/03/2022"), ToDate = DateTime.Parse("10/03/2022") },
                    new Offer { HotelID = random.Next(1, 28), TransportID = random.Next(1, 63), NumberOfPeople = random.Next(1, 5), FromDate = DateTime.Parse("03/03/2022"), ToDate = DateTime.Parse("10/03/2022") },
                    new Offer { HotelID = random.Next(1, 28), TransportID = random.Next(1, 63), NumberOfPeople = random.Next(1, 5), FromDate = DateTime.Parse("04/03/2022"), ToDate = DateTime.Parse("10/03/2022") },
                    new Offer { HotelID = random.Next(1, 28), TransportID = random.Next(1, 63), NumberOfPeople = random.Next(1, 5), FromDate = DateTime.Parse("05/03/2022"), ToDate = DateTime.Parse("10/03/2022") },
                    new Offer { HotelID = random.Next(1, 28), TransportID = random.Next(1, 63), NumberOfPeople = random.Next(1, 5), FromDate = DateTime.Parse("06/03/2022"), ToDate = DateTime.Parse("10/03/2022") },
                    new Offer { HotelID = random.Next(1, 28), TransportID = random.Next(1, 63), NumberOfPeople = random.Next(1, 5), FromDate = DateTime.Parse("07/03/2022"), ToDate = DateTime.Parse("10/03/2022") },
                    new Offer { HotelID = random.Next(1, 28), TransportID = random.Next(1, 63), NumberOfPeople = random.Next(1, 5), FromDate = DateTime.Parse("17/03/2022"), ToDate = DateTime.Parse("30/03/2022") },
                    new Offer { HotelID = random.Next(1, 28), TransportID = random.Next(1, 63), NumberOfPeople = random.Next(1, 5), FromDate = DateTime.Parse("18/03/2022"), ToDate = DateTime.Parse("30/03/2022") },
                    new Offer { HotelID = random.Next(1, 28), TransportID = random.Next(1, 63), NumberOfPeople = random.Next(1, 5), FromDate = DateTime.Parse("19/03/2022"), ToDate = DateTime.Parse("30/03/2022") },
                    new Offer { HotelID = random.Next(1, 28), TransportID = random.Next(1, 63), NumberOfPeople = random.Next(1, 5), FromDate = DateTime.Parse("21/03/2022"), ToDate = DateTime.Parse("30/03/2022") },
                    new Offer { HotelID = random.Next(1, 28), TransportID = random.Next(1, 63), NumberOfPeople = random.Next(1, 5), FromDate = DateTime.Parse("23/03/2022"), ToDate = DateTime.Parse("30/03/2022") },
                    new Offer { HotelID = random.Next(1, 28), TransportID = random.Next(1, 63), NumberOfPeople = random.Next(1, 5), FromDate = DateTime.Parse("24/03/2022"), ToDate = DateTime.Parse("30/03/2022") },
                    new Offer { HotelID = random.Next(1, 28), TransportID = random.Next(1, 63), NumberOfPeople = random.Next(1, 5), FromDate = DateTime.Parse("25/03/2022"), ToDate = DateTime.Parse("30/03/2022") },
                    new Offer { HotelID = random.Next(1, 28), TransportID = random.Next(1, 63), NumberOfPeople = random.Next(1, 5), FromDate = DateTime.Parse("26/03/2022"), ToDate = DateTime.Parse("30/03/2022") },
                    new Offer { HotelID = random.Next(1, 28), TransportID = random.Next(1, 63), NumberOfPeople = random.Next(1, 5), FromDate = DateTime.Parse("27/03/2022"), ToDate = DateTime.Parse("30/03/2022") },
                    new Offer { HotelID = random.Next(1, 28), TransportID = random.Next(1, 63), NumberOfPeople = random.Next(1, 5), FromDate = DateTime.Parse("07/04/2022"), ToDate = DateTime.Parse("15/04/2022") }
                    );
                context.SaveChanges();

                context.Bookings.AddRange(
                    new Booking { CustomerID = 1, BookingStatusID = 1, OfferID = 1, Date = DateTime.Parse("11/12/2021") },
                    new Booking { CustomerID = 1, BookingStatusID = 2, OfferID = 2, Date = DateTime.Parse("12/12/2021") },
                    new Booking { CustomerID = 2, BookingStatusID = 3, OfferID = 3, Date = DateTime.Parse("13/12/2021") },
                    new Booking { CustomerID = 3, BookingStatusID = 4, OfferID = 4, Date = DateTime.Parse("14/12/2021") }
                    );
                context.SaveChanges();

                context.Payments.AddRange(
                    new Payment { BookingID = 1, Date = DateTime.Parse("11/12/2021"), Amount = 500.00M },
                    new Payment { BookingID = 2, Date = DateTime.Parse("12/12/2021"), Amount = 700.00M },
                    new Payment { BookingID = 3, Date = DateTime.Parse("13/12/2021"), Amount = 100.00M },
                    new Payment { BookingID = 4, Date = DateTime.Parse("14/12/2021"), Amount = 300.00M }
                    );
                context.SaveChanges();
            }
        }
    }
}
