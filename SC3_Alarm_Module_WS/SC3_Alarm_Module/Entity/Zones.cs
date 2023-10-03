using SC3_Alarm_Module.Collection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SC3_Alarm_Module.Entity
{
    public class Zones
    {
        int zone_id;
        int u_id;
        string zone_Name;
        string zone_Type;
        string zone_Boundaries;
        string zone_Color;
        string zone_Info;
        
        

        public int Zone_id
        {
            get
            {
                return zone_id;
            }

            set
            {
                zone_id = value;
            }
        }

        public int U_id
        {
            get
            {
                return u_id;
            }

            set
            {
                u_id = value;
            }
        }

        public string Zone_Name
        {
            get
            {
                return zone_Name;
            }

            set
            {
                zone_Name = value;
            }
        }

        

        public string Zone_Type
        {
            get
            {
                return zone_Type;
            }

            set
            {
                zone_Type = value;
            }
        }

        public string Zone_Boundaries
        {
            get
            {
                return zone_Boundaries;
            }

            set
            {
                zone_Boundaries = value;
            }
        }

        public string Zone_Color
        {
            get
            {
                return zone_Color;
            }

            set
            {
                zone_Color = value;
            }
        }

        public string Zone_Info
        {
            get
            {
                return zone_Info;
            }

            set
            {
                zone_Info = value;
            }
        }

        



    }
}