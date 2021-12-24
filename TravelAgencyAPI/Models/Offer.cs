using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TravelAgencyAPI.Models
{
    public class Offer
    {
        [Key]
        public int ID { get; set; }
        [ForeignKey("Hotels")]
        public int HotelID { get; set; }
        private Hotel Hotel { get; set; }
        [ForeignKey("Transports")]
        public int TransportID { get; set; }
        private Transport Transport { get; set; }
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
