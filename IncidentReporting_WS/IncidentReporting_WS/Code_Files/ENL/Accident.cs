using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IncidentReporting_WS.Code_Files.COL;

namespace IncidentReporting_WS.Code_Files.ENL
{
    public class Accident
    {
        public int AccidentID { get; set; }
        public string AccidentType { get; set; }
        public string VehiclesToAccident { get; set; }
        public string Equipments { get; set; }
        public string LossesType { get; set; }
        public string LossesInfo { get; set; }
        public DateTime Date { get; set; }
        public DateTime TimeToSend { get; set; }
        public DateTime TimeToArrive { get; set; }
        public string AccidentNumber { get; set; }
        public string Additional_info { get; set; }
        public int CompanyID { get; set; }
        public InjuredCollection Accident_Injured { get; set; }
        public DeathCollection Accident_Death { get; set; }
    }
}