using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static TravelTracker.Domain.TravelTrackerEnums;

namespace TravelTracker.Helpers
{
    public static class TravelTrackerEnumHelpers
    {
        public static List<SelectListItem> GetTravelAgentRoleTypes()
        {
            var roleTypeList = new List<SelectListItem>();
            foreach (RoleType eVal in Enum.GetValues(typeof(RoleType)))
            {
                roleTypeList.Add(new SelectListItem { Text = Enum.GetName(typeof(RoleType), eVal), Value = eVal.ToString() });
            }

            return roleTypeList;
        }

        public static List<SelectListItem> GetTravelTypes()
        {
            var TravelTypeList = new List<SelectListItem>();
            foreach (TravelType eVal in Enum.GetValues(typeof(TravelType)))
            {
                TravelTypeList.Add(new SelectListItem { Text = Enum.GetName(typeof(TravelType), eVal), Value = eVal.ToString() });
            }

            return TravelTypeList;
        }

        public static List<SelectListItem> GetAirTravelTypes()
        {
            var airTravelTypeList = new List<SelectListItem>();
            foreach (AirTravelClass eVal in Enum.GetValues(typeof(AirTravelClass)))
            {
                airTravelTypeList.Add(new SelectListItem { Text = Enum.GetName(typeof(AirTravelClass), eVal), Value = eVal.ToString() });
            }

            return airTravelTypeList;
        }

        public static List<SelectListItem> GetQueryStatusOptions()
        {
            var queryOptionsList = new List<SelectListItem>();
            foreach (QueryStatus eVal in Enum.GetValues(typeof(QueryStatus)))
            {
                queryOptionsList.Add(new SelectListItem { Text = Enum.GetName(typeof(QueryStatus), eVal), Value = eVal.ToString() });
            }

            return queryOptionsList;
        }
    }
}
