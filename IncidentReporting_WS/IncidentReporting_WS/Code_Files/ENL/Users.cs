using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IncidentReporting_WS.Code_Files.COL;

namespace IncidentReporting_WS.Code_Files.ENL
{
    public class Users
    {
        public int UserID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Info { get; set; }
        public string AdminMode { get; set; }
        public CompanyCollection User_Companies { get; set; }
        public FF_pumpsCollection User_FF_Pumps { get; set; }
        public FFstationsCollection User_FFstations { get; set; }
        public UsersCollection Users_of_Users { get; set; }
    }
}