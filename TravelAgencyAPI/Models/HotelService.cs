using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TravelAgencyAPI.Models
{
    public class HotelService
    {
        [Key]
        public int ID { get; set; }
        [ForeignKey("Hotels")]
        public int HotelID { get; set; }
        public Hotel Hotel { get; set; }
        [ForeignKey("RoomTypes")]
        public int RoomTypeID { get; set; }
        public RoomType RoomType { get; set; }
        [Column(TypeName = "decimal(10,2)")]
        public decimal ServicePrice { get; set; }
    }
}
