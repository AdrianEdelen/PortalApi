using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PortalApi.Models
{
    public class Transaction
    {
        public int Id { get; set; }
        public int HouseholdId { get; set; }
        public DateTimeOffset Created { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public Boolean IsRead { get; set; }

    }
}
