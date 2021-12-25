using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using TravelAgencyAPI.Attributes;

namespace TravelAgencyAPI.Models
{
    public class Customer
    {
        [SwaggerIgnore]
        [Key]
        public int ID { get; set; }
        [Column(TypeName = "varchar(64)")]
        public string FirstName { get; set; }
        [Column(TypeName = "varchar(64)")]
        public string LastName { get; set; }
        [Column(TypeName = "varchar(255)")]
        public string Address { get; set; }
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }
        [DataType(DataType.EmailAddress)]
        public string EmailAddress { get; set; }
        [Column(TypeName = "text")]
        public string Details { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime CustomerFrom { get; set; }
    }
}
