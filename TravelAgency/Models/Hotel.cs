using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TravelAgency.Models
{
    public class Hotel
    {
        [Key]
        public int ID { get; set; }
        [Column(TypeName = "varchar(255)")]
        public string Name { get; set; }
        [ForeignKey("Cities")]
        public int CityID { get; set; }
        public City City { get; set; }
        [Column(TypeName = "varchar(255)")]
        public string Address { get; set; }
        [Column(TypeName = "int")]
        public int StarRating { get; set; }
    }
}
