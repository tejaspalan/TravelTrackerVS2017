using System;
using System.Collections.Generic;
using System.Text;

namespace TravelTracker.Domain
{
    public class TravelAgent
    {
        public int TravelAgentId { get; set; }
        public string AgentName { get; set; }
        public IEnumerable<TravelTrackerQueryBase> Queries { get; set; }
    }
}
