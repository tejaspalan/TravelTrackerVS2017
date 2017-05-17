using System;
using System.Collections.Generic;
using static TravelTracker.Domain.TravelTrackerEnums;

namespace TravelTracker.Domain
{
    public abstract class TravelTrackerQueryBase
    {
        public int RequestId { get; set; }
        #region Travel Agent Reference
        public int TravelAgentId { get; set; }
        public TravelAgent TravelAgent { get; set; }
        #endregion
        public string CustomerContactNumber { get; set; }
        public string CustomerName { get; set; }
        public DateTime QueryDate { get; set; }
        public DateTime TentativeTripStartDate { get; set; }
        public DateTime TentativeTripEndDate { get; set; }
        public QueryStatus QueryStatus { get; set; }
        public IEnumerable<TravelQueryLog> HistoryLog { get; set; }
        public int NumberOfAdults { get; set; }
        public int NumberOfChildren { get; set; }
    }
}
