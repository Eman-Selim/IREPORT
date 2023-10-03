using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SC3_Alarm_Module.Entity
{
    public class Alarm_Type
    {
        int alarm_type_id;
        string alarm_type_name;
        string alarm_type_message;
        byte[] alarm_type_icon;

        public int Alarm_Type_ID
        {
            get { return alarm_type_id; }

            set { alarm_type_id = value; }
        }

        public string Alarm_Type_Name
        {
            get { return alarm_type_name; }

            set { alarm_type_name = value; }
        }
        public string Alarm_Type_Message
        {
            get
            {
               return alarm_type_message;
            }
            set
            {
                alarm_type_message = value;
            }
        }

        public byte[] Alarm_Type_Icon
        {
            get
            {
                return alarm_type_icon;
            }
            set
            {
                alarm_type_icon = value;
            }
        }
    }
}