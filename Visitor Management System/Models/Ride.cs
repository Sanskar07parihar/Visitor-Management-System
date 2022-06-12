using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Visitor_Management_System.Models
{
    public class Ride
    {

        public string RideId { get; set; }

        public double Price { get; set; }
        
        public int ParkId { get; set; }
        
        public int CustomerId { get; set; }

        public Customer Customer { get; set; }

        public Park Park { get; set; }

    }
}
