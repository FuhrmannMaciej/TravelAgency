﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TravelAgencyAPI.Models
{
    public class TicketType
    {
        [Key]
        public int ID { get; set; }
        [Column(TypeName = "varchar(64)")]
        public string Name { get; set; }
    }
}