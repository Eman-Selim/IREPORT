using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IncidentReporting_WS.Code_Files.ENL
{
    public class Floors
    {
        public string FloorNumber { get; set; }
        public string FireHydrantsNumber { get; set; }
        public string PowderExtinguishersNumber { get; set; }
        public string CarbonDioxideExtinguishersNumbers { get; set; }
        public string FoamExtinguishersNumbers { get; set; }
        public int PowderExtinguishersWeight { get; set; }
        public int CarbonDioxideExtinguishersWeight { get; set; }
        public int FoamExtinguishersWeight { get; set; }
        public int BuildingID { get; set; }
        public int FloorID { get; set; }
    }
}