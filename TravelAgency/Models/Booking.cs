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
        public int ID { get; set; }
        [Key]
        [ForeignKey("Customer")]
        public int CustomerID { get; set; }
        [Key]
        [ForeignKey("Offer")]
        public int OfferID { get; set; }
        [Key]
        [ForeignKey("BookingStatus")]
        public int BookingStatusID { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime Date { get; set; }
        [Column(TypeName = "varchar(255)")]
        public string Details { get; set; }
    }
}
