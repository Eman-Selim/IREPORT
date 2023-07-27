using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IncidentReporting_WS.Code_Files.ENL
{
    public class FF_pumps
    {
        public int FF_pumpsID { get; set; }
        public string Sector { get; set; }
        public string Address { get; set; }
        public string PumpNumber { get; set; }
        public string PumpType { get; set; }
        public string Signs { get; set; }
        public string Status { get; set; }
        public string Area { get; set; }
        public string Additional_info { get; set; }
        public int UserID { get; set; }
    }
}