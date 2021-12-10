using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TravelAgency.Models
{
    public class HotelService
    {
        public int ID { get; set; }
        [Key]
        [ForeignKey("Hotel")]
        public int HotelID { get; set; }
        [Key]
        [ForeignKey("RoomType")]
        public int RoomTypeID { get; set; }
        [Column(TypeName = "decimal(10,2)")]
        public decimal ServicePrice { get; set; }
    }
}
