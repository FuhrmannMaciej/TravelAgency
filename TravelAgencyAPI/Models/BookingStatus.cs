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
    public class BookingStatus
    {
        [SwaggerIgnore]
        [Key]
        public int ID { get; set; }
        [Column(TypeName = "varchar(20)")]
        public string Status { get; set; }

        [SwaggerIgnore]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public virtual ICollection<Booking> Bookings { get; set; }
    }
}
