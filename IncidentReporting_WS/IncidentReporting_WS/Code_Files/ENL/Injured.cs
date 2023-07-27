using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IncidentReporting_WS.Code_Files.ENL
{
    public class Injured
    {
        public int InjuredID { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }

        public string Civil_Military { get; set; }
        public string Rank { get; set; }
        public DateTime Date { get; set; }
        public string Additional_info { get; set; }
        public int AccidentID { get; set; }
    }
}