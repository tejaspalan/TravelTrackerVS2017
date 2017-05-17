using System;
using System.Collections.Generic;
using System.Text;

namespace TravelTracker.Domain
{
    public class TravelTrackerEnums
    {
        public enum TravelType
        {
            Domestic = 0,
            International = 1,
            Mix = 2
        }

        public enum AirTravelClass
        {
            Economy = 0,
            Business = 1,
            Premium = 2
        }

        public enum QueryStatus
        {
            Opened = 0,
            InProgressWithAgency = 1,
            InProgressWithCustomer = 2,
            Accepeted = 3,
            Processed = 4,
            Declined = 5,
            Closed = 6
        }

        public enum RoleType
        {
            Agent = 0,
            Admin = 1
        }
    }
}
