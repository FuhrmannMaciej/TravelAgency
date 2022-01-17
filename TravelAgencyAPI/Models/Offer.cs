using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using TravelAgencyAPI.Attributes;

namespace TravelAgencyAPI.Models
{
    public class Offer
    {
        [SwaggerIgnore]
        [Key]
        public int ID { get; set; }
        public int HotelID { get; set; }
        [DataType(DataType.Date)]
        public DateTime FromDate { get; set; }
        [DataType(DataType.Date)]
        public DateTime ToDate { get; set; }
        [Column(TypeName = "int")]
        public int NumberOfPeople { get; set; }
        [DataType(DataType.Currency)]
        public int Price { get; set; }
        public int NumberOfDays { get
            {
                return (ToDate.Date - FromDate.Date).Days;
            } }

        [SwaggerIgnore]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public virtual Hotel Hotels { get; set; }
        [SwaggerIgnore]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public virtual ICollection<Booking> Bookings { get; set; }

    }
}
