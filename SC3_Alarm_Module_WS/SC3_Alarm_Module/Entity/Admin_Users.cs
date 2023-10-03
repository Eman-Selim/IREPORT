using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SC3_Alarm_Module.Entity
{
    public class Admin_Users
    {
        int admin_id;
        int user_id;



        public int Admin_ID
        {
            get
            {
                return admin_id;
            }

            set
            {
                admin_id = value;
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
    }
}