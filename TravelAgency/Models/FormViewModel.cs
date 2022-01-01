﻿using Microsoft.AspNetCore.Mvc.Rendering;
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
        public Offer Offer { get; set; }
        public IEnumerable<SelectListItem> CountryList { get; set; }
        public Country Country { get; set; }
    }
}
