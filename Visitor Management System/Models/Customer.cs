using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Visitor_Management_System.Models
{
    public class Customer
    {
        public int CustomerId { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }
        
        public int PhoneNumber { get; set; }

        public List<Ride> Rides { get; set; }

    }
}
