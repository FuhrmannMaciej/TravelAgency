using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using TravelAgencyAPI.Attributes;

namespace TravelAgencyAPI.Models
{
    public class Country
    {
        [SwaggerIgnore]
        [Key]
        public int ID { get; set; }
        [Column(TypeName = "varchar(8)")]
        public string Code { get; set; }
        [Column(TypeName = "varchar(64)")]
        public string Name{ get; set; }

        [SwaggerIgnore]
        public virtual ICollection<City> Cities { get; set; }
    }
}
