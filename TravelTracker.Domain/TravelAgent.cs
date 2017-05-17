using System;
using System.Collections.Generic;
using System.Text;
using static TravelTracker.Domain.TravelTrackerEnums;

namespace TravelTracker.Domain
{
    public class TravelAgent
    {
        public int TravelAgentId { get; set; }
        public string AgentName { get; set; }
        public RoleType Role { get; set; }
        public IEnumerable<TravelTrackerQueryBase> Queries { get; set; }
    }
}
