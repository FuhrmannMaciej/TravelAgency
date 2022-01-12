using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration; 
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using TravelAgency.Models;
using TravelAgencyAPI.Models;
using System.Linq;
using System;


namespace TravelAgency.Controllers
{
    [Route("[controller]")]
    public class OfferBoardController : Controller
    {
        private readonly HttpClient client;
        private readonly string WebApiPath;
        private readonly string WebApiPathHotel;
        private readonly string WebApiPathCity;
        private readonly string WebApiPathCountry;
        private readonly string WebApiPathBooking;
        private readonly IConfiguration _configuration;

        public OfferBoardController(IConfiguration configuration)
        {
            _configuration = configuration;
            WebApiPath = _configuration["TravelAgencyConfig:Url"];
            WebApiPathHotel = _configuration["TravelAgencyConfig:UrlHotel"];
            WebApiPathCity = _configuration["TravelAgencyConfig:UrlCity"];
            WebApiPathCountry = _configuration["TravelAgencyConfig:UrlCountry"];
            WebApiPathBooking = _configuration["TravelAgencyConfig:UrlBooking"];
            client = new HttpClient();
            client.DefaultRequestHeaders.Add("ApiKey", _configuration["TravelAgencyConfig:ApiKey"]);
        }


        [HttpGet("{offerID ?}/{cityID ?}/{numberOfPeople ?}")]
        public async Task<ActionResult> Index(int? offerID, int? cityID, int? numberOfPeople)
        {
            List<Offer> offers = new List<Offer>();
            List<Hotel> hotels = new List<Hotel>();
            List<City> cities = new List<City>();
            List<Country> countries = new List<Country>();
            HttpResponseMessage response = await client.GetAsync(WebApiPath);

            if (response.IsSuccessStatusCode)
            {
                    if (offerID != null)
                    {
                        response = await client.GetAsync(WebApiPath + "?offerID=" + offerID.ToString());
                    }
                offers = await response.Content.ReadAsAsync<List<Offer>>();
            }
            response = await client.GetAsync(WebApiPathHotel);
            if (response.IsSuccessStatusCode)
            {
                hotels = await response.Content.ReadAsAsync<List<Hotel>>();
            }
            response = await client.GetAsync(WebApiPathCity);
            if (response.IsSuccessStatusCode)
            {
                if (cityID != null)
                {
                    response = await client.GetAsync(WebApiPathCity + "?cityID=" + cityID.ToString());
                }
                cities = await response.Content.ReadAsAsync<List<City>>();
            }
            response = await client.GetAsync(WebApiPathCountry);
            if (response.IsSuccessStatusCode)
            {
                countries = await response.Content.ReadAsAsync<List<Country>>();
            }

            var joinModel =           from h in hotels
                                      join o in offers on h.ID equals o.HotelID
                                      join c in cities on h.CityID equals c.ID 
                                      join cr in countries on c.CountryID equals cr.ID into o2
                                      orderby o.FromDate
                                      from cr in o2.DefaultIfEmpty()
                                      select new OfferViewModel { Offer = o, Hotel = h, City = c , Country = cr};

            return View(joinModel);
        }
        [HttpGet("/Details/{id}")]
        public async Task<ActionResult> Details(int id)
        {
            Offer offer = new Offer();
            Hotel hotel = new Hotel();
            City city = new City();
            Country country = new Country();
            HttpResponseMessage response = await client.GetAsync(WebApiPath + "/" + id);
            if (response.IsSuccessStatusCode)
            {
                offer = await response.Content.ReadAsAsync<Offer>();
            }
            response = await client.GetAsync(WebApiPathHotel + "/" + offer.HotelID);
            if (response.IsSuccessStatusCode)
            {
                hotel = await response.Content.ReadAsAsync<Hotel>();
            }
            response = await client.GetAsync(WebApiPathCity + "/" + hotel.CityID);
            if (response.IsSuccessStatusCode)
            {
                city = await response.Content.ReadAsAsync<City>();
            }
            response = await client.GetAsync(WebApiPathCountry + "/" + city.CountryID);
            if (response.IsSuccessStatusCode)
            {
                country = await response.Content.ReadAsAsync<Country>();
            }

            var joinModel = new OfferViewModel { Offer = offer, Hotel = hotel, City = city, Country = country };

            return View(joinModel);
        }

        [HttpPost("/Created/{id}")]
        public async Task<ActionResult> Created(int id)
        {
            Booking booking = new Booking();
            booking.CustomerID = 1;
            booking.BookingStatusID = 5;
            booking.OfferID = id;
            booking.Date = DateTime.Now;
            
            HttpResponseMessage response = await client.PostAsJsonAsync(WebApiPathBooking, booking);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }
            
            return View();
        }
    }
}
