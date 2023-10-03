using SC3_Alarm_Module.Collection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SC3_Alarm_Module.Entity
{
    public class Layers
    {
        int layer_id;
        int u_id;
        string layer_Name;
        string layer_Info;
        Byte[] icon;
        PlacemarksCollection placemarks;
        

        public int Layer_id
        {
            get
            {
                return layer_id;
            }

            set
            {
                layer_id = value;
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
        public string Layer_Name
        {
            get
            {
                return layer_Name;
            }

            set
            {
                layer_Name = value;
            }
        }

        public string Layer_Info
        {
            get
            {
                return layer_Info;
            }

            set
            {
                layer_Info = value;
            }
        }

        public PlacemarksCollection Placemarks
        {
            get
            {
                return placemarks;
            }

            set
            {
                placemarks = value;
            }
        }

        public byte[] Icon
        {
            get
            {
                return icon;
            }

            set
            {
                icon = value;
            }
        }
    }
}