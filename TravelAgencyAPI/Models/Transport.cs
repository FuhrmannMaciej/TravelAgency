using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TravelAgencyAPI.Models
{
    public class Transport
    {
        [Key]
        public int ID { get; set; }
        [Column(TypeName = "varchar(255)")]
        public string Name { get; set; }
        [ForeignKey("TicketTypes")]
        public int TicketTypeID { get; set; }
        private TicketType TicketType { get; set; }
        [ForeignKey("Cities")]
        public int FromCity { get; set; }
        private City City{ get; set; }
        [ForeignKey("Cities")]
        public int ToCity { get; set; }
        [Column(TypeName = "decimal(10,2)")]
        public decimal ServicePrice { get; set; }
    }
}
