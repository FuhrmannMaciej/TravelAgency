using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using TravelAgencyAPI.Attributes;

namespace TravelAgencyAPI.Models
{
    public class Hotel
    {
        [SwaggerIgnore]
        [Key]
        public int ID { get; set; }
        [Column(TypeName = "varchar(255)")]
        public string Name { get; set; }
        public int CityID { get; set; }
        [Column(TypeName = "varchar(255)")]
        public string Address { get; set; }
        [Column(TypeName = "int")]
        public int StarRating { get; set; }

        [SwaggerIgnore]
        public virtual ICollection<Offer> Offers { get; set; }
        [SwaggerIgnore]
        public virtual ICollection<City> Cities { get; set; }
        [SwaggerIgnore]
        public virtual ICollection<HotelService> HotelServices { get; set; }
    }
}
