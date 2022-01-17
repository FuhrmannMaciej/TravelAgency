using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelAgencyAPI.Models;

namespace TravelAgency.Models.ViewModels
{
    public class BookingsViewModel
    {
        public Booking Booking { get; set; }
        public Offer Offer { get; set; }
        public Customer Customer { get; set; }
        public BookingStatus BookingStatus { get; set; }
    }
}
