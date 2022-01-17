using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using TravelAgency.Models;
using TravelAgency.Models.ViewModels;
using TravelAgencyAPI.Models;


namespace TravelAgency.Controllers
{
    public class HomeController : Controller
    {
        private readonly HttpClient client;
        private readonly ILogger<HomeController> _logger;
        private readonly string WebApiPath;
        private readonly IConfiguration _configuration;
        private readonly string WebApiPathCountry;
        private readonly string WebApiPathCity;
        private readonly string WebApiPathBooking;
        private readonly string WebApiPathBookingStatus;
        private readonly string WebApiPathCustomer;

        public HomeController(ILogger<HomeController> logger, IConfiguration configuration)
        {
            _configuration = configuration;
            _logger = logger;
            WebApiPath = _configuration["TravelAgencyConfig:Url"];
            WebApiPathCountry = _configuration["TravelAgencyConfig:UrlCountry"];
            WebApiPathCity = _configuration["TravelAgencyConfig:UrlCity"];
            WebApiPathBooking = _configuration["TravelAgencyConfig:UrlBooking"];
            WebApiPathBookingStatus = _configuration["TravelAgencyConfig:UrlBookingStatus"];
            WebApiPathCustomer = _configuration["TravelAgencyConfig:UrlCustomer"];
            client = new HttpClient();
            client.DefaultRequestHeaders.Add("ApiKey", _configuration["TravelAgencyConfig:ApiKey"]);
        }

        [HttpGet]
        public async Task<ActionResult> Index()
        {
            List<Offer> offers = new List<Offer>();
            List<Country> countries = new List<Country>();
            List<City> cities = new List<City>();
            HttpResponseMessage response = await client.GetAsync(WebApiPath);
            if (response.IsSuccessStatusCode)
            {
                offers = await response.Content.ReadAsAsync<List<Offer>>();
            }
            response = await client.GetAsync(WebApiPathCountry);
            if (response.IsSuccessStatusCode)
            {
                countries = await response.Content.ReadAsAsync<List<Country>>();
            }
            response = await client.GetAsync(WebApiPathCity);
            if (response.IsSuccessStatusCode)
            {
                cities = await response.Content.ReadAsAsync<List<City>>();
            }
            var formViewModel = new FormViewModel
            {
                OfferList = offers.Select(x => new SelectListItem
                {
                    Value = x.ID.ToString(),
                    Text = x.FromDate.Date.ToShortDateString()
                }),
                CountryList = countries.Select(x => new SelectListItem
                {
                    Value = x.Code,
                    Text = x.Name
                }),
                CityList = cities.Select(x => new SelectListItem
                {
                    Value = x.ID.ToString(),
                    Text = x.Name
                })
            };
            return View(formViewModel);
        }

        [HttpGet]
        public async Task<ActionResult> MyBookings()
        {
            List<Offer> offers = new List<Offer>();
            List<Customer> customers = new List<Customer>();
            List<Booking> bookings = new List<Booking>();
            List<BookingStatus> bookingStatuses = new List<BookingStatus>();
            HttpResponseMessage response = await client.GetAsync(WebApiPath);
            if (response.IsSuccessStatusCode)
            {
                offers = await response.Content.ReadAsAsync<List<Offer>>();
            }
            response = await client.GetAsync(WebApiPathBooking);
            if (response.IsSuccessStatusCode)
            {
                bookings = await response.Content.ReadAsAsync<List<Booking>>();
            }
            response = await client.GetAsync(WebApiPathBookingStatus);
            if (response.IsSuccessStatusCode)
            {
                bookingStatuses = await response.Content.ReadAsAsync<List<BookingStatus>>();
            }
            response = await client.GetAsync(WebApiPathCustomer);
            if (response.IsSuccessStatusCode)
            {
                customers = await response.Content.ReadAsAsync<List<Customer>>();
            }

            var bookingModel = from b in bookings
                               join o in offers on b.OfferID equals o.ID
                               join bs in bookingStatuses on b.BookingStatusID equals bs.ID
                               join c in customers on b.CustomerID equals c.ID into o2
                               orderby b.Date
                               from c in o2.DefaultIfEmpty()
                               select new BookingsViewModel { Offer = o, Booking = b, BookingStatus = bs, Customer = c };

            return View(bookingModel);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
