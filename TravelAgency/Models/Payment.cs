using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TravelAgency.Models
{
    public class Payment
    {
        [Key]
        public int ID { get; set; }
        [ForeignKey("Bookings")]
        public int BookingID { get; set; }
        public Booking Booking { get; set; }
        [DataType(DataType.Currency)]
        public decimal Amount { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime Date { get; set; }
    }
}
