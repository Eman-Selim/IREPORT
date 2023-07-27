using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IncidentReporting_WS.Code_Files.ENL
{
    public class DangerousPlaces
    {
        public string HazardousSubstance { get; set; }
        public string Location { get; set; }
        public string FireMediator { get; set; }
        public int CompanyID { get; set; }
        public byte[] Image { get; set; }
        public int DangerousPlaceID { get; set; }
        public string ImageURL { get; set; }
    }
}