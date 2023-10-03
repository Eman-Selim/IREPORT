using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SC3_Alarm_Module.Entity
{
    public class Alarms
    {
         int alarm_id;       
         int building_alarmunit_id;
          int movable_alarmunit_id;
         int alarm_type_id;
         double latitude;
         double longitude;
         DateTime dateReceived;
         int acknowledege;
         DateTime acknowledegeDate;
         bool visibility;

        public int Alarm_ID
        {
            get
            {
                return alarm_id;
            }

            set
            {
                alarm_id = value;
            }
        }

        public int Building_AlarmUnit_ID
        {
            get
            {
                return building_alarmunit_id;
            }

            set
            {
                building_alarmunit_id = value;
            }
        }
        public int Movable_AlarmUnit_ID
        {
            get
            {
                return movable_alarmunit_id;
            }

            set
            {
                movable_alarmunit_id = value;
            }
        }

        public int Alarm_Type_ID
        {
            get
            {
                return alarm_type_id;
            }

            set
            {
                alarm_type_id = value;
            }
        }

        public double Latitude
        {
            get
            {
                return latitude;
            }

            set
            {
                latitude = value;
            }
        }

        public double Longitude
        {
            get
            {
                return longitude;
            }

            set
            {
                longitude = value;
            }
        }

        public DateTime DateReceived
        {
            get
            {
                return dateReceived;
            }

            set
            {
                dateReceived = value;
            }
        }

     
        public int Acknowledege
        {
            get
            {
                return acknowledege;
            }

            set
            {
                acknowledege = value;
            }
        }

        public DateTime AcknowledegeDate
        {
            get
            {
                return acknowledegeDate;
            }

            set
            {
                acknowledegeDate = value;
            }
        }
        public bool Visibility
        {
            get
            {
                return visibility;
            }
            set
            {
                visibility = value;
            }
        }


    }
}
