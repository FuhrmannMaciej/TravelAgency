using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TravelAgencyAPI.Models.OtherModels
{
    public class OfferParams
    {
        public Offer offer { get; set; }
        public Country country { get; set; }
    }
}
