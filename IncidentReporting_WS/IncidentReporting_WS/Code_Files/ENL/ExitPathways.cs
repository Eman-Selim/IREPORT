using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IncidentReporting_WS.Code_Files.ENL
{
    public class ExitPathways
    {
        public byte[] PathwaysImage { get; set; }
        public string Description { get; set; }
        public int BuildingID { get; set; }
        public string PathwaysImageURL { get; set; }
        public int ExitPathwaysID { get; set; }
    }
}