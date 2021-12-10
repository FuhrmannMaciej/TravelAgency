using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TravelAgency.Models
{
    public class BookingStatus
    {
        public int ID { get; set; }
        [Column(TypeName = "varchar(20)")]
        public string Status { get; set; }
    }
}
