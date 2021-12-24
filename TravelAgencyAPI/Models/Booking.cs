using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TravelAgencyAPI.Models
{
    public class Booking
    {
        [Key]
        public int ID { get; set; }
        [ForeignKey("Customers")]
        public int CustomerID { get; set; }
        private Customer Customer { get; set; }
        [ForeignKey("Offers")]
        public int OfferID { get; set; }
        private Offer Offer { get; set; }
        [ForeignKey("BookingStatuses")]
        public int BookingStatusID { get; set; }
        private BookingStatus BookingStatus { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime Date { get; set; }
    }
}
