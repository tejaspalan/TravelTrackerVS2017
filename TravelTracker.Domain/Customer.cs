using System;
using System.Collections.Generic;
using System.Text;

namespace TravelTracker.Domain
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string ContactNumber { get; set; }
        public string Address { get; set; }
        public IEnumerable<TravelTrackerQueryBase> Queries { get; set; }
    }
}
