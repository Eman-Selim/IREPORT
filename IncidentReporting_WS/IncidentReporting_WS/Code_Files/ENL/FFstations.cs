using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IncidentReporting_WS.Code_Files.COL;

namespace IncidentReporting_WS.Code_Files.ENL
{
    public class FFstations
    {
        public int FF_ID { set; get; }
        public string Sector { get; set; }
        public string AreaName { get; set; }
        public string Street { get; set; }
        public string ZoneNumber { get; set; }
        public string Signs { get; set; }
        public string OfficersNumber { get; set; }
        public string SoliderNumber { get; set; }
        public string CarsNumber { get; set; }
        public string Equipments { get; set; }
        public string Additional_info { get; set; }
        public int UserID { get; set; }
        public FF_ManPowerCollection Station_ManPower { get; set; }
    }
}