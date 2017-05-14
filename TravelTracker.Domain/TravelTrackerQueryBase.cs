using System;

namespace TravelTracker.Domain
{
    public class TravelTrackerQueryBase
    {
        public int RequestId { get; set; }
        #region Travel Agent Reference
        public int TravelAgentId { get; set; }
        public TravelAgent TravelAgent { get; set; }
        #endregion

        #region Customer
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        #endregion
        public DateTime QueryDate { get; set; }
        public DateTime TentativeTripStartDate { get; set; }
        public DateTime TentativeTripEndDate { get; set; }
        public int TravelType { get; set; }
        public int QueryStatus { get; set; }
    }
}
