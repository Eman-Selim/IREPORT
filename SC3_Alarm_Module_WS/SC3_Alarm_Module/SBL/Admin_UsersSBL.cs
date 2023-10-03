using SC3_Alarm_Module.CBL;
using SC3_Alarm_Module.Collection;
using SC3_Alarm_Module.DAL;
using SC3_Alarm_Module.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SC3_Alarm_Module.SBL
{
    public class Admin_UsersSBL
    {
        CHK Chk = new CHK();
        Admin_UsersDAL Admin_Users_Obj = new Admin_UsersDAL();

        public bool Admin_Users_Delete(string username, string password,int user_id, int admin_id,int user_id2)
        {
            try
            {
                if (Chk.check_authority(username, password))
                {
                    return Admin_Users_Obj.Admin_Users_Delete(username, password, user_id, admin_id, user_id2);

                }
                else
                {
                    return false;
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public Admin_Users Admin_Users_Insert(string username, string password, int user_id,  Admin_Users New_Admin)
        {
            try
            {
                if(Chk.check_authority(username,password))
                {
                    return Admin_Users_Obj.Admin_Users_Insert(username, password,user_id, New_Admin);
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Admin_UsersCollection Users_Admins_Select_All(string username, string password)
        {
            try
            {
                if (Chk.check_authority(username, password))
                {
                    return Admin_Users_Obj.Users_Admins_Select_All(username, password);
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public bool Users_Admins_Insert_Bulk(string username, string password, Admin_UsersCollection Users_Admins_Array)
        {
            try
            {
                if (Chk.check_authority(username, password))
                {
                    return Admin_Users_Obj.Users_Admins_Insert_Bulk(username, password, Users_Admins_Array);
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool Users_Admins_Delete(string username, string password, int user_id, int Admin_id)
        {
            try
            {
                if (Chk.check_authority(username, password))
                {
                    return Admin_Users_Obj.Users_Admins_Delete(username, password, user_id, Admin_id);
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}