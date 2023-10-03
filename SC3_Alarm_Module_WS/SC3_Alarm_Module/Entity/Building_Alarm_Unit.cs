using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SC3_Alarm_Module.Collection;

namespace SC3_Alarm_Module.Entity
{
    public class Building_Alarm_Unit
    {
        int building_alarmUnit_ID;
        string network_identifier;
        int user_id;
        string building_alarmunit_Name;
        double latitude;
        double longitude;
        string contactPersonName;
        string landLinePhoneNumber;
        string mobileNumber;
        string addressLineOne;
        string addressLineTwo;
        int systemCheck;
        DateTime systemCheckedDate;
        string cam1;
        string cam2;
        string cam3;
        string cam4;
        byte[] picture1;
        byte[] picture2;
        byte[] picture3;
        byte[] picture4;
        string network_Type;
        string info;
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

        public int Building_AlarmUnit_ID
        {
            get
            {
                return building_alarmUnit_ID;
            }

            set
            {
                building_alarmUnit_ID = value;
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

        public string Building_AlarmUnit_Name
        {
            get
            {
                return building_alarmunit_Name;
            }

            set
            {
                building_alarmunit_Name = value;
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

        public string AddressLineOne
        {
            get
            {
                return addressLineOne;
            }

            set
            {
                addressLineOne = value;
            }
        }

        public string AddressLineTwo
        {
            get
            {
                return addressLineTwo;
            }

            set
            {
                addressLineTwo = value;
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

        public string CAM1
        {
            get
            {
                return cam1;
            }

            set
            {
                cam1 = value;
            }
        }

        public string CAM2
        {
            get
            {
                return cam2;
            }

            set
            {
                cam2 = value;
            }
        }

        public string CAM3
        {
            get
            {
                return cam3;
            }

            set
            {
                cam3 = value;
            }
        }

        public string CAM4
        {
            get
            {
                return cam4;
            }

            set
            {
                cam4 = value;
            }
        }

        public byte[] Picture1
        {
            get
            {
                return picture1;
            }
            set
            {
                picture1 = value;
            }
        }

        public byte[] Picture2
        {
            get
            {
                return picture2;
            }
            set
            {
                picture2 = value;
            }
        }

        public byte[] Picture3
        {
            get
            {
                return picture3;
            }
            set
            {
                picture3 = value;
            }
        }

        public byte[] Picture4
        {
            get
            {
                return picture4;
            }
            set
            {
                picture4 = value;
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
        public string Info
        {
            get
            {
                return info;
            }

            set
            {
                info = value;
            }
        }
    }
}