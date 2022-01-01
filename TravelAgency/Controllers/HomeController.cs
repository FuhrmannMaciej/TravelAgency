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

        public HomeController(ILogger<HomeController> logger, IConfiguration configuration)
        {
            _configuration = configuration;
            _logger = logger;
            WebApiPath = _configuration["TravelAgencyConfig:Url"];
            WebApiPathCountry = _configuration["TravelAgencyConfig:UrlCountry"];
            client = new HttpClient();
            client.DefaultRequestHeaders.Add("ApiKey", _configuration["TravelAgencyConfig:ApiKey"]);
        }

        public async Task<ActionResult> Index()
        {
            List<Offer> offers = new List<Offer>();
            List<Country> countries = new List<Country>();
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
                })
            };
            return View(formViewModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
