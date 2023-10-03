using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SC3_Alarm_Module.Collection;

namespace SC3_Alarm_Module.Entity
{
    public class Users
    {
        int user_id;
        string username;
        string password;
        string privilege;
        MapsCollection maps;
        UsersCollection usersCollection;
        Movable_Alarm_UnitCollection movable_Alarm_Units;
        LayersCollection layers;
        Building_Alarm_UnitCollection building_Alarm_Units;
        AlarmsCollection alarms;
        Alarm_TypeCollection alarm_Type;
        ZonesCollection zones;
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

        public string Username
        {
            get
            {
                return username;
            }

            set
            {
                username = value;
            }
        }

        public string Password
        {
            get
            {
                return password;
            }

            set
            {
                password = value;
            }
        }

        public string Privilege
        {
            get
            {
                return privilege;
            }

            set
            {
                privilege = value;
            }
        }
        public MapsCollection Maps
        {
            get
            {
                return maps;
            }

            set
            {
                maps = value;
            }
        }
        public UsersCollection UsersCollection
        {
            get
            {
                return usersCollection;
            }

            set
            {
                usersCollection = value;
            }
        }
        public Movable_Alarm_UnitCollection Movable_Alarm_Units
        {
            get
            {
                return movable_Alarm_Units;
            }
            set
            {
                movable_Alarm_Units = value;
            }
        }
        public Building_Alarm_UnitCollection Building_Alarm_Units
        {
            get
            {
                return building_Alarm_Units;
            }
            set
            {
                building_Alarm_Units = value;
            }
        }
        public LayersCollection Layers
        {
            get
            {
                return layers;
            }
            set
            {
                layers = value;
            }
        }

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

        public Alarm_TypeCollection Alarm_Type
        {
            get
            {
                return alarm_Type;
            }
            set
            {
                alarm_Type = value;
            }
        }

        public ZonesCollection Zones
        {
            get
            {
                return zones;
            }

            set
            {
                zones = value;
            }
        }

    }
}