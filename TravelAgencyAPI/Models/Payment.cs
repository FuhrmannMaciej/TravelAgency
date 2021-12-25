using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using TravelAgencyAPI.Attributes;

namespace TravelAgencyAPI.Models
{
    public class Payment
    {
        [SwaggerIgnore]
        [Key]
        public int ID { get; set; }
        [ForeignKey("Bookings")]
        public int BookingID { get; set; }
        private Booking Booking { get; set; }
        [DataType(DataType.Currency)]
        public decimal Amount { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime Date { get; set; }
    }
}
