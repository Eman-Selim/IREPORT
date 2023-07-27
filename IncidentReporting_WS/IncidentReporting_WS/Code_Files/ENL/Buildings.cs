using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IncidentReporting_WS.Code_Files.COL;

namespace IncidentReporting_WS.Code_Files.ENL
{
    public class Buildings
    {
        public int BuildingNumber { set; get; }
        public int FloorsNumber { set; get; }
        public int CompanyID { set; get; }
        public int BuildingID { set; get; }
        public int MainWaterTankCapacity { set; get; }
        public byte[] GeometricImage { set; get; }
        public String GeometricImageURL { set; get; }
        public FloorsCollection BuildingFloors { set; get; }
        public ImagesCollection BuildingImageCollection { get; set; }
        public ExitPathwaysCollection BuildingExitPaths { get; set; }
    }
}