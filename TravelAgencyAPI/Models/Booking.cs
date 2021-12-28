using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using TravelAgencyAPI.Attributes;

namespace TravelAgencyAPI.Models
{
    public class Booking
    {
        [SwaggerIgnore]
        [Key]
        public int ID { get; set; }
        public int CustomerID { get; set; }
        public int OfferID { get; set; }
        public int BookingStatusID { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime Date { get; set; }

        [SwaggerIgnore]
        public virtual Customer Customer { get; set; }
        [SwaggerIgnore]
        public virtual Offer Offer { get; set; }
        [SwaggerIgnore]
        public virtual BookingStatus BookingStatus { get; set; }
    }
}
