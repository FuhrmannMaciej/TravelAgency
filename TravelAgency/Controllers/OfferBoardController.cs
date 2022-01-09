using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration; 
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using TravelAgency.Models;
using TravelAgencyAPI.Models;
using System.Linq;


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


        // GET: ClientController
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
                /*if (!string.IsNullOrEmpty(countryCode))
                {
                        response = await client.GetAsync(WebApiPathCountry + "?countryCode=" + countryCode);
                }*/
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



        // POST: ClientController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]  //offer add deoc to slides
        public async Task<ActionResult> Create([Bind("ID,CustonerID,OfferID,BookingStatusID,Date")] Booking booking)
        {
            if (ModelState.IsValid)
            {
                HttpResponseMessage response = await client.PostAsJsonAsync(WebApiPathBooking, booking);
                response.EnsureSuccessStatusCode();
                return RedirectToAction(nameof(Index));
            }
            return View();
        }
    }
}
