using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelAgencyAPI.Models;

namespace TravelAgency.Models
{
    public class FormViewModel
    {
        public IEnumerable<SelectListItem> OfferList { get; set; }
        [BindProperty(SupportsGet = true)]
        public Offer Offer { get; set; }
        public List<Offer> Offers { get; set; }
        public IEnumerable<SelectListItem> CountryList { get; set; }
        [BindProperty(SupportsGet = true)]
        public Country Country { get; set; }
        public List<Country> Countries { get; set; }
    }
}
