using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SC3_Alarm_Module.Entity
{
    public class Maps
    {
        int map_id;
        int user_id;
        string map_name;
        bool online_or_offline;
        string map_url;
        string map_info;

        
        public int Map_ID
        {
            get
            {
                return map_id;
            }

            set
            {
                map_id = value;
            }
        }
        public int User_ID
        {
            get
            {
                return user_id;
            }

            set
            {
                user_id = value;
            }
        }
        public string Map_Name
        {
            get
            {
                return map_name;
            }
            set
            {
                map_name = value;
            }
        }
        public bool Online_Or_Offline
        {
            get
            {
                return online_or_offline;
            }

            set
            {
                online_or_offline = value;
            }
        }
        public string Map_URL
        {
            get
            {
                return map_url;
            }

            set
            {
                map_url = value;
            }
        }
        public string Map_Info
        {
            get
            {
                return map_info;
            }

            set
            {
                map_info = value;
            }
        }
    }
}