using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using TravelAgencyAPI.Attributes;

namespace TravelAgencyAPI.Models
{
    public class Transport
    {
        [SwaggerIgnore]
        [Key]
        public int ID { get; set; }
        [Column(TypeName = "varchar(255)")]
        public string Name { get; set; }
        public int TicketTypeID { get; set; }
        public int ToCity { get; set; }
        [Column(TypeName = "decimal(10,2)")]
        public decimal ServicePrice { get; set; }

        [SwaggerIgnore]
        public virtual ICollection<TicketType> TicketTypes { get; set; }
        [SwaggerIgnore]
        public virtual ICollection<City> Cities{ get; set; }
        [SwaggerIgnore]
        public virtual ICollection<Offer> Offers { get; set; }

    }
}
