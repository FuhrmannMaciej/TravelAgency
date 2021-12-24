using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TravelAgencyAPI.Models
{
    public class City
    {
        [Key]
        public int ID { get; set; }
        [Column(TypeName = "varchar(255)")]
        public string Name { get; set; }
        [ForeignKey("Country")]
        public int CountryID { get; set; }
        private Country Country { get; set; }
    }
}
