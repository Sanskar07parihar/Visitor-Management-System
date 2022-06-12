using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Visitor_Management_System.Models
{
    public class Park
    {
        public int ParkId { get; set; }

        public string Name { get; set; }


        public double EntryFee { get; set; }

        public string Location { get; set; }

        public List<Ride> Rides { get; set; }


    }
}
