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
    public class City
    {
        [SwaggerIgnore]
        [Key]
        public int ID { get; set; }
        [Column(TypeName = "varchar(255)")]
        public string Name { get; set; }
        public int CountryID { get; set; }
        [SwaggerIgnore]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public virtual Country Country { get; set; }
        [SwaggerIgnore]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public virtual ICollection<Hotel> Hotels { get; set; }
    }
}
