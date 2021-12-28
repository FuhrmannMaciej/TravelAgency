using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using TravelAgencyAPI.Attributes;

namespace TravelAgencyAPI.Models
{
    public class HotelService
    {
        [SwaggerIgnore]
        [Key]
        public int ID { get; set; }
        public int HotelID { get; set; }
        public int RoomTypeID { get; set; }
        [Column(TypeName = "decimal(10,2)")]
        public decimal ServicePrice { get; set; }

        [SwaggerIgnore]
        public virtual Hotel Hotel { get; set; }
        [SwaggerIgnore]
        public virtual ICollection<RoomType> RoomTypes { get; set; }
    }
}
