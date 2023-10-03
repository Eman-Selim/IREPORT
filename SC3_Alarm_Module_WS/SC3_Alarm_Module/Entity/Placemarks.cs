using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SC3_Alarm_Module.Entity
{
    public class Placemarks
    {
        int placemark_id;
        int layer_id;
        string placemark_Name;
        double placemark_Lat;
        double placemark_Lon;
        string placemark_info;

        public int Placemark_id 
        {
            get
            {
                return placemark_id;
            }

            set
            {
                placemark_id = value;
            }
        }

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

        public string Placemark_Name
        {
            get
            {
                return placemark_Name;
            }

            set
            {
                placemark_Name = value;
            }
        }

        public double Placemark_Lat
        {
            get
            {
                return placemark_Lat;
            }

            set
            {
                placemark_Lat = value;
            }
        }

        public double Placemark_Lon
        {
            get
            {
                return placemark_Lon;
            }

            set
            {
                placemark_Lon = value;
            }
        }

        public string Placemark_info
        {
            get
            {
                return placemark_info;
            }

            set
            {
                placemark_info = value;
            }
        }
    }
}