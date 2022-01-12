using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelAgencyAPI.Models;

namespace TravelAgency.Models
{
    public class OfferViewModel
    {
        public Offer Offer { get; set; }
        public Hotel Hotel { get; set; }
        public City City { get; set; }
        public Country Country { get; set; }
    }
}
