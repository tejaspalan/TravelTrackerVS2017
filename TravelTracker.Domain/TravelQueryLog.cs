using System;
using System.Collections.Generic;
using System.Text;

namespace TravelTracker.Domain
{
    public class TravelQueryLog
    {
        public int LogIdentifier { get; set; }
        #region Foreign Key - TravelQueryBase
        public int QueryRequestId { get; set; }
        public TravelTrackerQueryBase QueryBase { get; set; }
        #endregion
        public int TransactingTravelAgentCode { get; set; }
        public int OldStatus { get; set; }
        public int NewStatus { get; set; }
        public string Remarks { get; set; }
    }
}
