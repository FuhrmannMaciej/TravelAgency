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
                    var countries = new List<Country>
                    {
                        new Country { Name = "Argentina", Code = "ARG" },
                        new Country { Name = "Canada", Code = "CAN" },
                        new Country { Name = "Cyprus", Code = "CYP" },
                        new Country { Name = "Egypt", Code = "EGY" },
                        new Country { Name = "France", Code = "FRA" },
                        new Country { Name = "Japan", Code = "JPN" },
                        new Country { Name = "Malta", Code = "MLT" },
                        new Country { Name = "New Zealand", Code = "NZL" },
                        new Country { Name = "Norway", Code = "NOR" },
                        new Country { Name = "Poland", Code = "POL" },
                        new Country { Name = "Russia", Code = "RUS" },
                        new Country { Name = "United Kingdom", Code = "GBR" },
                        new Country { Name = "United States", Code = "USA" }
                   };
                if (!context.Countries.Any())
                {
                        context.Countries.AddRange(countries);
                        context.SaveChanges();
                }

                    var cities = new List<City>
                    {
                        new City { Name = "Buenos Aires", CountryID = countries.Single( s => s.Code == "ARG").ID },
                        new City { Name = "La Plata", CountryID = countries.Single( s => s.Code == "ARG").ID },
                        new City { Name = "Formosa", CountryID = countries.Single( s => s.Code == "ARG").ID },
                        new City { Name = "Toronto", CountryID = countries.Single(s => s.Code == "CAN").ID },
                        new City { Name = "Ottawa", CountryID = countries.Single(s => s.Code == "CAN").ID },
                        new City { Name = "Larnaca", CountryID = countries.Single(s => s.Code == "CYP").ID },
                        new City { Name = "Nicosia", CountryID = countries.Single(s => s.Code == "CYP").ID },
                        new City { Name = "Alexandria", CountryID = countries.Single(s => s.Code == "EGY").ID },
                        new City { Name = "Cairo", CountryID = countries.Single(s => s.Code == "EGY").ID },
                        new City { Name = "Paris", CountryID = countries.Single(s => s.Code == "FRA").ID },
                        new City { Name = "Lyon", CountryID = countries.Single(s => s.Code == "FRA").ID },
                        new City { Name = "Nice", CountryID = countries.Single(s => s.Code == "FRA").ID },
                        new City { Name = "Tokio", CountryID = countries.Single(s => s.Code == "JPN").ID },
                        new City { Name = "Qormi", CountryID = countries.Single(s => s.Code == "MLT").ID },
                        new City { Name = "Wellington", CountryID = countries.Single(s => s.Code == "NZL").ID },
                        new City { Name = "Oslo", CountryID = countries.Single(s => s.Code == "NOR").ID },
                        new City { Name = "Warsaw", CountryID = countries.Single(s => s.Code == "POL").ID },
                        new City { Name = "Cracow", CountryID = countries.Single(s => s.Code == "POL").ID },
                        new City { Name = "Gdansk", CountryID = countries.Single(s => s.Code == "POL").ID },
                        new City { Name = "Kielce", CountryID = countries.Single(s => s.Code == "POL").ID },
                        new City { Name = "Moscow", CountryID = countries.Single(s => s.Code == "RUS").ID },
                        new City { Name = "Abaza", CountryID = countries.Single(s => s.Code == "RUS").ID },
                        new City { Name = "London", CountryID = countries.Single(s => s.Code == "GBR").ID },
                        new City { Name = "Liverpool", CountryID = countries.Single(s => s.Code == "GBR").ID },
                        new City { Name = "New York", CountryID = countries.Single(s => s.Code == "USA").ID },
                        new City {  Name = "Miami", CountryID = countries.Single(s => s.Code == "USA").ID }
                    };
                if (!context.Cities.Any())
                {
                    context.Cities.AddRange(cities);
                    context.SaveChanges();
                }

                var bookingStatuses = new List<BookingStatus>
                {
                    new BookingStatus { Status = "Pending" },
                    new BookingStatus { Status = "Reserved" },
                    new BookingStatus { Status = "Paid" },
                    new BookingStatus { Status = "Cancelled" },
                    new BookingStatus { Status = "Archived" }
                };

                if (!context.BookingStatuses.Any())
                {
                    context.BookingStatuses.AddRange(bookingStatuses);
                    context.SaveChanges();
                }

                var customers = new List<Customer>
                {
                    new Customer
                    {
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
                };

                if (!context.Customers.Any())
                {
                    context.Customers.AddRange(customers);
                    context.SaveChanges();
                }

                var hotels = new List<Hotel>
                {
                    new Hotel { CityID = cities.Single( s => s.Name == "Buenos Aires").ID, Name = "Manoir Hovey", Address = "1850 Willow Oaks Lane", StarRating = 3 },
                    new Hotel { CityID = cities.Single( s => s.Name == "La Plata").ID, Name = "Grand Hotel", Address = "4086 Lyndon Street", StarRating = 4 },
                    new Hotel { CityID = cities.Single( s => s.Name == "Formosa").ID, Name = "Blue Hotel", Address = "1599 Quincy Street", StarRating = 2 },
                    new Hotel { CityID = cities.Single( s => s.Name == "Toronto").ID, Name = "Manoir Hovey", Address = "4525 Cityview Drive", StarRating = 3 },
                    new Hotel { CityID = cities.Single( s => s.Name == "Ottawa").ID, Name = "The Opposite House", Address = "1850 Willow Oaks Lane", StarRating = 3 },
                    new Hotel { CityID = cities.Single( s => s.Name == "Larnaca").ID, Name = "Hotel Felix", Address = "1850 Willow Oaks Lane", StarRating = 5 },
                    new Hotel { CityID = cities.Single( s => s.Name == "Nicosia").ID, Name = "The Opposite House", Address = "1850 Willow Oaks Lane", StarRating = 5 },
                    new Hotel { CityID = cities.Single( s => s.Name == "Alexandria").ID, Name = "Grand Hotel", Address = "867 Baker Avenue", StarRating = 3 },
                    new Hotel { CityID = cities.Single( s => s.Name == "Cairo").ID, Name = "Hotel Felix", Address = "1850 Willow Oaks Lane", StarRating = 4 },
                    new Hotel { CityID = cities.Single( s => s.Name == "Paris").ID, Name = "Hotel Felix", Address = "4395 Yorkie Lane", StarRating = 5 },
                    new Hotel { CityID = cities.Single( s => s.Name == "Lyon").ID, Name = "Grace Hotel", Address = "91 Hillside Street", StarRating = 2 },
                    new Hotel { CityID = cities.Single( s => s.Name == "Nice").ID, Name = "Hotel Felix", Address = "1794 Rockford Road", StarRating = 3 },
                    new Hotel { CityID = cities.Single( s => s.Name == "Tokio").ID, Name = "The Opposite House", Address = "1794 Rockford Road", StarRating = 1 },
                    new Hotel { CityID = cities.Single( s => s.Name == "Qormi").ID, Name = "Shangri-La the Shard", Address = "1850 Willow Oaks Lane", StarRating = 5 },
                    new Hotel { CityID = cities.Single( s => s.Name == "Wellington").ID, Name = "Hotel Felix", Address = "4395 Yorkie Lane", StarRating = 3 },
                    new Hotel { CityID = cities.Single( s => s.Name == "Oslo").ID, Name = "Grace Hotel", Address = "1850 Willow Oaks Lane", StarRating = 4 },
                    new Hotel { CityID = cities.Single( s => s.Name == "Warsaw").ID, Name = "Shangri-La the Shard", Address = "1850 Willow Oaks Lane", StarRating = 5 },
                    new Hotel { CityID = cities.Single( s => s.Name == "Cracow").ID, Name = "Hotel Paracas", Address = "4525 Cityview Drive", StarRating = 3 },
                    new Hotel { CityID = cities.Single( s => s.Name == "Gdansk").ID, Name = "Hotel Paracas", Address = "1850 Willow Oaks Lane", StarRating = 5 },
                    new Hotel { CityID = cities.Single( s => s.Name == "Kielce").ID, Name = "Hotel Felix", Address = "867 Baker Avenue", StarRating = 4 },
                    new Hotel { CityID = cities.Single( s => s.Name == "Moscow").ID, Name = "Grace Hotel", Address = "1850 Willow Oaks Lane", StarRating = 3 },
                    new Hotel { CityID = cities.Single( s => s.Name == "Abaza").ID, Name = "Hotel Felix", Address = "91 Hillside Street", StarRating = 4 },
                    new Hotel { CityID = cities.Single( s => s.Name == "London").ID, Name = "Grand Hotel", Address = "3444 Drainer Avenue", StarRating = 3 },
                    new Hotel { CityID = cities.Single( s => s.Name == "Liverpool").ID, Name = "Hotel Paracas", Address = "1850 Willow Oaks Lane", StarRating = 3 },
                    new Hotel { CityID = cities.Single( s => s.Name == "New York").ID, Name = "Grand Hotel", Address = "3444 Drainer Avenue", StarRating = 3 },
                    new Hotel { CityID = cities.Single( s => s.Name == "Miami").ID, Name = "Taj Holiday Village Resort & Spa, Goa", Address = "4525 Cityview Drive", StarRating = 4 },
                    new Hotel { CityID = cities.Single( s => s.Name == "Buenos Aires").ID, Name = "Taj Holiday Village Resort & Spa, Goa", Address = "1794 Rockford Road", StarRating = 3 },
                    new Hotel { CityID = cities.Single( s => s.Name == "Gdansk").ID, Name = "Grand Hotel", Address = "91 Hillside Street", StarRating = 2 }
                };

                if (!context.Hotels.Any())
                {
                    context.Hotels.AddRange(hotels);
                    context.SaveChanges();
                }

                var offers = new List<Offer>
                {
                    new Offer { HotelID = random.Next(1, 28), NumberOfPeople = random.Next(1, 5), FromDate = DateTime.Parse("11/12/2021"), ToDate = DateTime.Parse("15/12/2021"), Price = random.Next(100, 3000) },
                    new Offer { HotelID = random.Next(1, 28), NumberOfPeople = random.Next(1, 5), FromDate = DateTime.Parse("12/12/2021"), ToDate = DateTime.Parse("15/12/2021"), Price = random.Next(100, 3000) },
                    new Offer { HotelID = random.Next(1, 28), NumberOfPeople = random.Next(1, 5), FromDate = DateTime.Parse("13/12/2021"), ToDate = DateTime.Parse("15/12/2021"), Price = random.Next(100, 3000) },
                    new Offer { HotelID = random.Next(1, 28), NumberOfPeople = random.Next(1, 5), FromDate = DateTime.Parse("14/12/2021"), ToDate = DateTime.Parse("15/12/2021"), Price = random.Next(100, 3000) },
                    new Offer { HotelID = random.Next(1, 28), NumberOfPeople = random.Next(1, 5), FromDate = DateTime.Parse("15/12/2021"), ToDate = DateTime.Parse("20/12/2021"), Price = random.Next(100, 3000) },
                    new Offer { HotelID = random.Next(1, 28), NumberOfPeople = random.Next(1, 5), FromDate = DateTime.Parse("16/12/2021"), ToDate = DateTime.Parse("20/12/2021"), Price = random.Next(100, 3000) },
                    new Offer { HotelID = random.Next(1, 28), NumberOfPeople = random.Next(1, 5), FromDate = DateTime.Parse("17/12/2021"), ToDate = DateTime.Parse("20/12/2021"), Price = random.Next(100, 3000) },
                    new Offer { HotelID = random.Next(1, 28), NumberOfPeople = random.Next(1, 5), FromDate = DateTime.Parse("18/12/2021"), ToDate = DateTime.Parse("20/12/2021"), Price = random.Next(100, 3000) },
                    new Offer { HotelID = random.Next(1, 28), NumberOfPeople = random.Next(1, 5), FromDate = DateTime.Parse("11/12/2021"), ToDate = DateTime.Parse("20/12/2021"), Price = random.Next(100, 3000) },
                    new Offer { HotelID = random.Next(1, 28), NumberOfPeople = random.Next(1, 5), FromDate = DateTime.Parse("21/12/2021"), ToDate = DateTime.Parse("03/01/2022"), Price = random.Next(100, 3000) },
                    new Offer { HotelID = random.Next(1, 28), NumberOfPeople = random.Next(1, 5), FromDate = DateTime.Parse("31/12/2021"), ToDate = DateTime.Parse("03/01/2022"), Price = random.Next(100, 3000) },
                    new Offer { HotelID = random.Next(1, 28), NumberOfPeople = random.Next(1, 5), FromDate = DateTime.Parse("24/12/2021"), ToDate = DateTime.Parse("03/01/2022"), Price = random.Next(100, 3000) },
                    new Offer { HotelID = random.Next(1, 28), NumberOfPeople = random.Next(1, 5), FromDate = DateTime.Parse("25/12/2021"), ToDate = DateTime.Parse("03/01/2022"), Price = random.Next(100, 3000) },
                    new Offer { HotelID = random.Next(1, 28), NumberOfPeople = random.Next(1, 5), FromDate = DateTime.Parse("26/12/2021"), ToDate = DateTime.Parse("03/01/2022"), Price = random.Next(100, 3000) },
                    new Offer { HotelID = random.Next(1, 28), NumberOfPeople = random.Next(1, 5), FromDate = DateTime.Parse("27/12/2021"), ToDate = DateTime.Parse("03/01/2022"), Price = random.Next(100, 3000) },
                    new Offer { HotelID = random.Next(1, 28), NumberOfPeople = random.Next(1, 5), FromDate = DateTime.Parse("28/12/2021"), ToDate = DateTime.Parse("03/01/2022"), Price = random.Next(100, 3000) },
                    new Offer { HotelID = random.Next(1, 28), NumberOfPeople = random.Next(1, 5), FromDate = DateTime.Parse("29/12/2021"), ToDate = DateTime.Parse("03/01/2022"), Price = random.Next(100, 3000) },
                    new Offer { HotelID = random.Next(1, 28), NumberOfPeople = random.Next(1, 5), FromDate = DateTime.Parse("01/01/2022"), ToDate = DateTime.Parse("12/01/2022"), Price = random.Next(100, 3000) },
                    new Offer { HotelID = random.Next(1, 28), NumberOfPeople = random.Next(1, 5), FromDate = DateTime.Parse("01/01/2022"), ToDate = DateTime.Parse("12/01/2022"), Price = random.Next(100, 3000) },
                    new Offer { HotelID = random.Next(1, 28), NumberOfPeople = random.Next(1, 5), FromDate = DateTime.Parse("02/01/2022"), ToDate = DateTime.Parse("12/01/2022"), Price = random.Next(100, 3000) },
                    new Offer { HotelID = random.Next(1, 28), NumberOfPeople = random.Next(1, 5), FromDate = DateTime.Parse("03/01/2022"), ToDate = DateTime.Parse("12/01/2022"), Price = random.Next(100, 3000) },
                    new Offer { HotelID = random.Next(1, 28), NumberOfPeople = random.Next(1, 5), FromDate = DateTime.Parse("04/01/2022"), ToDate = DateTime.Parse("12/01/2022"), Price = random.Next(100, 3000) },
                    new Offer { HotelID = random.Next(1, 28), NumberOfPeople = random.Next(1, 5), FromDate = DateTime.Parse("05/01/2022"), ToDate = DateTime.Parse("12/01/2022"), Price = random.Next(100, 3000) },
                    new Offer { HotelID = random.Next(1, 28), NumberOfPeople = random.Next(1, 5), FromDate = DateTime.Parse("06/01/2022"), ToDate = DateTime.Parse("12/01/2022"), Price = random.Next(100, 3000) },
                    new Offer { HotelID = random.Next(1, 28), NumberOfPeople = random.Next(1, 5), FromDate = DateTime.Parse("07/01/2022"), ToDate = DateTime.Parse("12/01/2022"), Price = random.Next(100, 3000) },
                    new Offer { HotelID = random.Next(1, 28), NumberOfPeople = random.Next(1, 5), FromDate = DateTime.Parse("08/01/2022"), ToDate = DateTime.Parse("12/01/2022"), Price = random.Next(100, 3000) },
                    new Offer { HotelID = random.Next(1, 28), NumberOfPeople = random.Next(1, 5), FromDate = DateTime.Parse("09/01/2022"), ToDate = DateTime.Parse("12/01/2022"), Price = random.Next(100, 3000) },
                    new Offer { HotelID = random.Next(1, 28), NumberOfPeople = random.Next(1, 5), FromDate = DateTime.Parse("10/01/2022"), ToDate = DateTime.Parse("12/01/2022"), Price = random.Next(100, 3000) },
                    new Offer { HotelID = random.Next(1, 28), NumberOfPeople = random.Next(1, 5), FromDate = DateTime.Parse("21/01/2022"), ToDate = DateTime.Parse("31/01/2022"), Price = random.Next(100, 3000) },
                    new Offer { HotelID = random.Next(1, 28), NumberOfPeople = random.Next(1, 5), FromDate = DateTime.Parse("22/01/2022"), ToDate = DateTime.Parse("31/01/2022"), Price = random.Next(100, 3000) },
                    new Offer { HotelID = random.Next(1, 28), NumberOfPeople = random.Next(1, 5), FromDate = DateTime.Parse("23/01/2022"), ToDate = DateTime.Parse("31/01/2022"), Price = random.Next(100, 3000) },
                    new Offer { HotelID = random.Next(1, 28), NumberOfPeople = random.Next(1, 5), FromDate = DateTime.Parse("24/01/2022"), ToDate = DateTime.Parse("31/01/2022"), Price = random.Next(100, 3000) },
                    new Offer { HotelID = random.Next(1, 28), NumberOfPeople = random.Next(1, 5), FromDate = DateTime.Parse("25/01/2022"), ToDate = DateTime.Parse("31/01/2022"), Price = random.Next(100, 3000) },
                    new Offer { HotelID = random.Next(1, 28), NumberOfPeople = random.Next(1, 5), FromDate = DateTime.Parse("27/01/2022"), ToDate = DateTime.Parse("31/01/2022"), Price = random.Next(100, 3000) },
                    new Offer { HotelID = random.Next(1, 28), NumberOfPeople = random.Next(1, 5), FromDate = DateTime.Parse("01/02/2022"), ToDate = DateTime.Parse("11/02/2022"), Price = random.Next(100, 3000) },
                    new Offer { HotelID = random.Next(1, 28), NumberOfPeople = random.Next(1, 5), FromDate = DateTime.Parse("02/02/2022"), ToDate = DateTime.Parse("11/02/2022"), Price = random.Next(100, 3000) },
                    new Offer { HotelID = random.Next(1, 28), NumberOfPeople = random.Next(1, 5), FromDate = DateTime.Parse("03/02/2022"), ToDate = DateTime.Parse("11/02/2022"), Price = random.Next(100, 3000) },
                    new Offer { HotelID = random.Next(1, 28), NumberOfPeople = random.Next(1, 5), FromDate = DateTime.Parse("04/02/2022"), ToDate = DateTime.Parse("11/02/2022"), Price = random.Next(100, 3000) },
                    new Offer { HotelID = random.Next(1, 28), NumberOfPeople = random.Next(1, 5), FromDate = DateTime.Parse("05/02/2022"), ToDate = DateTime.Parse("11/02/2022"), Price = random.Next(100, 3000) },
                    new Offer { HotelID = random.Next(1, 28), NumberOfPeople = random.Next(1, 5), FromDate = DateTime.Parse("06/02/2022"), ToDate = DateTime.Parse("11/02/2022"), Price = random.Next(100, 3000) },
                    new Offer { HotelID = random.Next(1, 28), NumberOfPeople = random.Next(1, 5), FromDate = DateTime.Parse("07/02/2022"), ToDate = DateTime.Parse("11/02/2022"), Price = random.Next(100, 3000) },
                    new Offer { HotelID = random.Next(1, 28), NumberOfPeople = random.Next(1, 5), FromDate = DateTime.Parse("08/02/2022"), ToDate = DateTime.Parse("11/02/2022"), Price = random.Next(100, 3000) },
                    new Offer { HotelID = random.Next(1, 28), NumberOfPeople = random.Next(1, 5), FromDate = DateTime.Parse("09/02/2022"), ToDate = DateTime.Parse("11/02/2022"), Price = random.Next(100, 3000) },
                    new Offer { HotelID = random.Next(1, 28), NumberOfPeople = random.Next(1, 5), FromDate = DateTime.Parse("10/02/2022"), ToDate = DateTime.Parse("11/02/2022"), Price = random.Next(100, 3000) },
                    new Offer { HotelID = random.Next(1, 28), NumberOfPeople = random.Next(1, 5), FromDate = DateTime.Parse("21/02/2022"), ToDate = DateTime.Parse("28/02/2022"), Price = random.Next(100, 3000) },
                    new Offer { HotelID = random.Next(1, 28), NumberOfPeople = random.Next(1, 5), FromDate = DateTime.Parse("21/02/2022"), ToDate = DateTime.Parse("28/02/2022"), Price = random.Next(100, 3000) },
                    new Offer { HotelID = random.Next(1, 28), NumberOfPeople = random.Next(1, 5), FromDate = DateTime.Parse("22/02/2022"), ToDate = DateTime.Parse("28/02/2022"), Price = random.Next(100, 3000) },
                    new Offer { HotelID = random.Next(1, 28), NumberOfPeople = random.Next(1, 5), FromDate = DateTime.Parse("23/02/2022"), ToDate = DateTime.Parse("28/02/2022"), Price = random.Next(100, 3000) },
                    new Offer { HotelID = random.Next(1, 28), NumberOfPeople = random.Next(1, 5), FromDate = DateTime.Parse("24/02/2022"), ToDate = DateTime.Parse("28/02/2022"), Price = random.Next(100, 3000) },
                    new Offer { HotelID = random.Next(1, 28), NumberOfPeople = random.Next(1, 5), FromDate = DateTime.Parse("25/02/2022"), ToDate = DateTime.Parse("28/02/2022"), Price = random.Next(100, 3000) },
                    new Offer { HotelID = random.Next(1, 28), NumberOfPeople = random.Next(1, 5), FromDate = DateTime.Parse("26/02/2022"), ToDate = DateTime.Parse("28/02/2022"), Price = random.Next(100, 3000) },
                    new Offer { HotelID = random.Next(1, 28), NumberOfPeople = random.Next(1, 5), FromDate = DateTime.Parse("27/02/2022"), ToDate = DateTime.Parse("28/02/2022"), Price = random.Next(100, 3000) },
                    new Offer { HotelID = random.Next(1, 28), NumberOfPeople = random.Next(1, 5), FromDate = DateTime.Parse("01/03/2022"), ToDate = DateTime.Parse("10/03/2022"), Price = random.Next(100, 3000) },
                    new Offer { HotelID = random.Next(1, 28), NumberOfPeople = random.Next(1, 5), FromDate = DateTime.Parse("02/03/2022"), ToDate = DateTime.Parse("10/03/2022"), Price = random.Next(100, 3000) },
                    new Offer { HotelID = random.Next(1, 28), NumberOfPeople = random.Next(1, 5), FromDate = DateTime.Parse("03/03/2022"), ToDate = DateTime.Parse("10/03/2022"), Price = random.Next(100, 3000) },
                    new Offer { HotelID = random.Next(1, 28), NumberOfPeople = random.Next(1, 5), FromDate = DateTime.Parse("04/03/2022"), ToDate = DateTime.Parse("10/03/2022"), Price = random.Next(100, 3000) },
                    new Offer { HotelID = random.Next(1, 28), NumberOfPeople = random.Next(1, 5), FromDate = DateTime.Parse("05/03/2022"), ToDate = DateTime.Parse("10/03/2022"), Price = random.Next(100, 3000) },
                    new Offer { HotelID = random.Next(1, 28), NumberOfPeople = random.Next(1, 5), FromDate = DateTime.Parse("06/03/2022"), ToDate = DateTime.Parse("10/03/2022"), Price = random.Next(100, 3000) },
                    new Offer { HotelID = random.Next(1, 28), NumberOfPeople = random.Next(1, 5), FromDate = DateTime.Parse("07/03/2022"), ToDate = DateTime.Parse("10/03/2022"), Price = random.Next(100, 3000) },
                    new Offer { HotelID = random.Next(1, 28), NumberOfPeople = random.Next(1, 5), FromDate = DateTime.Parse("17/03/2022"), ToDate = DateTime.Parse("30/03/2022"), Price = random.Next(100, 3000) },
                    new Offer { HotelID = random.Next(1, 28), NumberOfPeople = random.Next(1, 5), FromDate = DateTime.Parse("18/03/2022"), ToDate = DateTime.Parse("30/03/2022"), Price = random.Next(100, 3000) },
                    new Offer { HotelID = random.Next(1, 28), NumberOfPeople = random.Next(1, 5), FromDate = DateTime.Parse("19/03/2022"), ToDate = DateTime.Parse("30/03/2022"), Price = random.Next(100, 3000) },
                    new Offer { HotelID = random.Next(1, 28), NumberOfPeople = random.Next(1, 5), FromDate = DateTime.Parse("21/03/2022"), ToDate = DateTime.Parse("30/03/2022"), Price = random.Next(100, 3000) },
                    new Offer { HotelID = random.Next(1, 28), NumberOfPeople = random.Next(1, 5), FromDate = DateTime.Parse("23/03/2022"), ToDate = DateTime.Parse("30/03/2022"), Price = random.Next(100, 3000) },
                    new Offer { HotelID = random.Next(1, 28), NumberOfPeople = random.Next(1, 5), FromDate = DateTime.Parse("24/03/2022"), ToDate = DateTime.Parse("30/03/2022"), Price = random.Next(100, 3000) },
                    new Offer { HotelID = random.Next(1, 28), NumberOfPeople = random.Next(1, 5), FromDate = DateTime.Parse("25/03/2022"), ToDate = DateTime.Parse("30/03/2022"), Price = random.Next(100, 3000) },
                    new Offer { HotelID = random.Next(1, 28), NumberOfPeople = random.Next(1, 5), FromDate = DateTime.Parse("26/03/2022"), ToDate = DateTime.Parse("30/03/2022"), Price = random.Next(100, 3000) },
                    new Offer { HotelID = random.Next(1, 28), NumberOfPeople = random.Next(1, 5), FromDate = DateTime.Parse("27/03/2022"), ToDate = DateTime.Parse("30/03/2022"), Price = random.Next(100, 3000) },
                    new Offer { HotelID = random.Next(1, 28), NumberOfPeople = random.Next(1, 5), FromDate = DateTime.Parse("07/04/2022"), ToDate = DateTime.Parse("15/04/2022"), Price = random.Next(100, 3000) }
                };

                if (!context.Offers.Any())
                {
                    context.Offers.AddRange(offers);
                    context.SaveChanges();
                }

                var bookings = new List<Booking>
                {
                    new Booking { CustomerID = 1, BookingStatusID = 1, OfferID = 1, Date = DateTime.Parse("11/12/2021") },
                    new Booking { CustomerID = 1, BookingStatusID = 2, OfferID = 2, Date = DateTime.Parse("12/12/2021") },
                    new Booking { CustomerID = 2, BookingStatusID = 3, OfferID = 3, Date = DateTime.Parse("13/12/2021") },
                    new Booking { CustomerID = 3, BookingStatusID = 4, OfferID = 4, Date = DateTime.Parse("14/12/2021") }
                };

                if (!context.Bookings.Any())
                {
                    context.Bookings.AddRange(bookings);
                    context.SaveChanges();
                }
            }
        }
    }
}
