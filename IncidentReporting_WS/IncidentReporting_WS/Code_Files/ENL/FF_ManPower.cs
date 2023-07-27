using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IncidentReporting_WS.Code_Files.ENL
{
    public class FF_ManPower
    {
        public int FF_ManPowerID { get; set; }
        public string Sector { get; set; }
        public string Area { get; set; }
        public string Point { get; set; }
        public string OfficerName { get; set; }
        public string Rank { get; set; }
        public string TimeSlot { get; set; }
        public string Availability { get; set; }
        public string Job { get; set; }
        public string Additional_info { get; set; }
        public int UserID { get; set; }
        public int FF_ID { get; set; }

    }
}