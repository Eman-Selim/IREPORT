using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SC3_Alarm_Module.Collection;

namespace SC3_Alarm_Module.Entity
{
    public class Movable_Alarm_Unit
    {
        int movable_alarmUnit_ID;
        string network_identifier;
        int user_id;
        string movable_alarmunit_Name;
        string contactPersonName;
        string landLinePhoneNumber;
        string mobileNumber;
        int systemCheck;
        string network_Type;
        bool reallocate_Flag;
        DateTime systemCheckedDate;
        AlarmsCollection alarms;

        public AlarmsCollection Alarms
        {
            get
            {
                return alarms;
            }
            set
            {
                alarms = value;
            }
        }

        public int Movable_AlarmUnit_ID
        {
            get
            {
                return movable_alarmUnit_ID;
            }

            set
            {
                movable_alarmUnit_ID = value;
            }
        }

        public string Network_Identifier
        {
            get
            {
                return network_identifier;
            }

            set
            {
                network_identifier = value;
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

        public string Movable_AlarmUnit_Name
        {
            get
            {
                return movable_alarmunit_Name;
            }

            set
            {
                movable_alarmunit_Name = value;
            }
        }

        public string ContactPersonName
        {
            get
            {
                return contactPersonName;
            }

            set
            {
                contactPersonName = value;
            }
        }

        public string LandLinePhoneNumber
        {
            get
            {
                return landLinePhoneNumber;
            }

            set
            {
                landLinePhoneNumber = value;
            }
        }

        public string MobileNumber
        {
            get
            {
                return mobileNumber;
            }

            set
            {
                mobileNumber = value;
            }
        }

        public int SystemCheck
        {
            get
            {
                return systemCheck;
            }

            set
            {
                systemCheck = value;
            }
        }

        public DateTime SystemCheckedDate
        {
            get
            {
                return systemCheckedDate;
            }

            set
            {
                systemCheckedDate = value;
            }
        }

        public string Network_Type
        {
            get
            {
                return network_Type;
            }
            set
            {
                network_Type = value;
            }
        }

        public bool Reallocate_Flag
        {
            get
            {
                return reallocate_Flag;
            }

            set
            {
                reallocate_Flag = value;
            }
        }
    }
}