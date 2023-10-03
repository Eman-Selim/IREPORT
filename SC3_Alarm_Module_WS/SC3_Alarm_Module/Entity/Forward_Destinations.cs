using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SC3_Alarm_Module.Entity
{
    public class Forward_Destinations
    {
        int destination_id;
        int bu_id;
        int mu_id;
        int alarm_type_id;
        string network_Type;
        string network_id;
        string message_body;
        string info;

        public int Destination_ID
        {
            get { return destination_id; }

            set { destination_id = value; }
        }

        public int BU_ID
        {
            get { return bu_id; }

            set { bu_id = value; }
        }

        public int MU_ID
        {
            get
            {
                return mu_id;
            }
            set
            {
                mu_id = value;
            }
        }

        public int Alarm_Type_ID
        {
            get { return alarm_type_id; }

            set { alarm_type_id = value; }
        }

        public string Network_Type
        {
            get { return network_Type; }

            set { network_Type = value; }
        }

        public string Network_ID
        {
            get { return network_id; }

            set { network_id = value; }
        }

        public string  Message_Body
        {
            get { return message_body; }

            set { message_body = value; }
        }

        public string Info
        {
            get { return info; }

            set { info = value; }
        }
    }

}