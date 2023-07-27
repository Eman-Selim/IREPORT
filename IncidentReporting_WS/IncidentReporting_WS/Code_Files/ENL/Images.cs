using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IncidentReporting_WS.Code_Files.ENL
{
    public class Images
    {
        public string ImageDescription { get; set; }
        public int BuildingID { get; set; }
        public byte[] Image { get; set; }
        public int ImageID { get; set; }
        public string ImageURL { get; set; }
    }
}