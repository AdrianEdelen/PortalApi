﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PortalApi.Models
{
    public class BankAccount
    {
        public int Id { get; set; }
        public int HouseholdId { get; set; }

        public string PortalUserId { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        public int Type { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal StartingBalance { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal CurrentBalance { get; set; }
    }
}
