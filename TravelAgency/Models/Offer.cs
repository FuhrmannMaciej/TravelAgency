using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TravelAgency.Models
{
    public class Offer
    {
        public int ID { get; set; }
        [Key]
        [ForeignKey("Hotel")]
        public int HotelID { get; set; }
        [Key]
        [ForeignKey("Transport")]
        public int TransportID { get; set; }
        [Key]
        [ForeignKey("City")]
        public int CityID { get; set; }
        [DataType(DataType.Date)]
        public DateTime FromDate { get; set; }
        [DataType(DataType.Date)]
        public DateTime ToDate { get; set; }
        [Column(TypeName = "int")]
        public int NumberOfPeople { get; set; }
        [DataType(DataType.Currency)]
        public int Price { get; set; }
    }
}
