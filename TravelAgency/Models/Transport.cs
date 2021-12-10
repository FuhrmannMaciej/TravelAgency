using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TravelAgency.Models
{
    public class Transport
    {
        public int ID { get; set; }
        [Column(TypeName = "varchar(255)")]
        public string Name { get; set; }
        [Key]
        [ForeignKey("TicketType")]
        public int TicketTypeID { get; set; }
        [Key]
        [ForeignKey("City")]
        public int FromCity { get; set; }
        [Key]
        [ForeignKey("City")]
        public int ToCity { get; set; }
        [Column(TypeName = "decimal(10,2)")]
        public decimal ServicePrice { get; set; }
    }
}
