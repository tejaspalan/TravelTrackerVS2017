using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static TravelTracker.Domain.TravelTrackerEnums;

namespace TravelTracker.Domain
{
    public class AirTravelQuery : TravelTrackerQueryBase
    {
        public AirTravelClass TravelClass { get; set; }
        public TravelType TravelType { get; set; }
    }
}
