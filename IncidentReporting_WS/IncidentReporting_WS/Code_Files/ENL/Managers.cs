using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IncidentReporting_WS.Code_Files.COL;

namespace IncidentReporting_WS.Code_Files.ENL
{
    public class Managers
    {
        public string Name { set; get; }
        public string CurrentPosition { set; get; }
        public string PhoneNumber { set; get; }
        public string Info { set; get; }
        public int CompanyID { set; get; }
        public int ManagerID { set; get; }
    }
}