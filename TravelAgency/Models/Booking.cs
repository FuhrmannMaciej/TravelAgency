using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TravelAgency.Models
{
    public class Booking
    {
        [Key]
        public int ID { get; set; }
        [ForeignKey("Customers")]
        public int CustomerID { get; set; }
        public Customer Customer { get; set; }
        [ForeignKey("Offers")]
        public int OfferID { get; set; }
        public Offer Offer { get; set; }
        [ForeignKey("BookingStatuses")]
        public int BookingStatusID { get; set; }
        public BookingStatus BookingStatus { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime Date { get; set; }
    }
}
