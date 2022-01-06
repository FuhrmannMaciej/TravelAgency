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
    public class ClientController : Controller
    {
        private readonly HttpClient client;
        private readonly string WebApiPath;
        private readonly string WebApiPathHotel;
        private readonly string WebApiPathCity;
        private readonly string WebApiPathCountry;
        private readonly IConfiguration _configuration;

        public ClientController(IConfiguration configuration)
        {
            _configuration = configuration;
            WebApiPath = _configuration["TravelAgencyConfig:Url"];
            WebApiPathHotel = _configuration["TravelAgencyConfig:UrlHotel"];
            WebApiPathCity = _configuration["TravelAgencyConfig:UrlCity"];
            WebApiPathCountry = _configuration["TravelAgencyConfig:UrlCountry"];
            client = new HttpClient();
            client.DefaultRequestHeaders.Add("ApiKey", _configuration["TravelAgencyConfig:ApiKey"]);
        }


        // GET: ClientController
        public async Task<ActionResult> Index(FormViewModel offerSearch)
        {
            List<Offer> offers = new List<Offer>();
            List<Hotel> hotels = new List<Hotel>();
            List<City> cities = new List<City>();
            List<Country> countries = new List<Country>();
            HttpResponseMessage response = await client.GetAsync(WebApiPath);

            if (response.IsSuccessStatusCode)
            {
                if (offerSearch != null)
                {
                    if (!string.IsNullOrEmpty(offerSearch.Offer.ID.ToString()))
                    {
                        response = await client.GetAsync(WebApiPath + "?offerID=" + offerSearch.Offer.ID.ToString());
                    }
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
                cities = await response.Content.ReadAsAsync<List<City>>();
            }
            response = await client.GetAsync(WebApiPathCountry);
            if (response.IsSuccessStatusCode)
            {
                if (offerSearch != null)
                {
                    if (!string.IsNullOrEmpty(offerSearch.Country.Code))
                    {
                        response = await client.GetAsync(WebApiPathCountry + "?countryCode=" + offerSearch.Country.Code);
                    }
                }
                countries = await response.Content.ReadAsAsync<List<Country>>();
            }

            var joinModel =           from h in hotels
                                      join o in offers on h.ID equals o.HotelID
                                      join c in cities on h.CityID equals c.ID 
                                      join cr in countries on c.CountryID equals cr.ID into o2
                                      from cr in o2.DefaultIfEmpty()
                                      select new OfferViewModel { Offer = o, Hotel = h, City = c , Country = cr};

            return View(joinModel);
        }



        // GET: ClientController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            HttpResponseMessage response = await client.GetAsync(WebApiPath + id);
            if (response.IsSuccessStatusCode)
            {
                Offer offer = await response.Content.ReadAsAsync<Offer>();
                return View(offer);
            }
            return NotFound();
        }


        // GET: ClientController/Create
        public ActionResult Create()
        {
            return View();
        }



        // POST: ClientController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]  //offer add deoc to slides
        public async Task<ActionResult> Create([Bind("ID,HotelID,TransportID,FromDate,ToDate,NumberOfPeople,Price")] Offer offer)
        {
            if (ModelState.IsValid)
            {
                HttpResponseMessage response = await client.PostAsJsonAsync(WebApiPath, offer);
                response.EnsureSuccessStatusCode();
                return RedirectToAction(nameof(Index));
            }
            return View(offer);
        }



        // GET: ClientController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            HttpResponseMessage response = await client.GetAsync(WebApiPath + id);
            if (response.IsSuccessStatusCode)
            {
                Offer offer = await response.Content.ReadAsAsync<Offer>();
                return View(offer);
            }
            return NotFound();
        }


        // POST: ClientController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, [Bind("ID,HotelID,TransportID,FromDate,ToDate,NumberOfPeople,Price")] Offer offer)
        {
            if (ModelState.IsValid)
            {
                HttpResponseMessage response = await client.PutAsJsonAsync(WebApiPath + id, offer);
                response.EnsureSuccessStatusCode();
                return RedirectToAction(nameof(Index));
            }
            return View(offer);
        }




        // GET: ClientController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            HttpResponseMessage response = await client.GetAsync(WebApiPath + id);
            if (response.IsSuccessStatusCode)
            {
                Offer offer = await response.Content.ReadAsAsync<Offer>();
                return View(offer);
            }
            return NotFound();
        }


        // POST: ClientController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, int notUsed = 0)
        {
            HttpResponseMessage response = await client.DeleteAsync(WebApiPath + id);
            response.EnsureSuccessStatusCode();
            return RedirectToAction(nameof(Index));
        }
    }
}
