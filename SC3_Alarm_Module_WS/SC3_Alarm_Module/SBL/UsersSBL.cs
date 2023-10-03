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
    public class UsersSBL
    {

        CHK chk = new CHK();
        UsersDAL UsersDAL_Obj = new UsersDAL();


        #region User Methods

        public bool Users_Delete( string username, string password, int user_id , int user_delete_id)
        {
            try
            {

                if (chk.check_authority(username, password))
                {

                    return UsersDAL_Obj.Users_Delete(username, password, user_id , user_delete_id);
                }
                else
                {
                    return false;
                }
                

            }
            catch (Exception ex)
            {
                throw ex;
            }
        
        }

        public  Users Users_Insert(string username, string password , Users New_user)
        {
            try
            {
                if (chk.check_authority(username, password))
                {
                    return UsersDAL_Obj.Users_Insert(username, password, New_user);
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

        public UsersCollection Users_Select(string username, string password)
        {
            try
            {
                if (chk.check_authority(username,password))
                {
                    return UsersDAL_Obj.Users_Select(username,password);
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

        public bool Users_Update(string old_username, string old_password, int user_id, Users upd_user)
        {
            try
            {
                if(chk.check_authority(old_username,old_password))
                {
                    return UsersDAL_Obj.Users_Update(old_username, old_password, upd_user);
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }
        public UsersCollection Users_Selct_Users_Of_Admin_User(string username, string password)
        {
            try
            {
                if(chk.check_authority(username,password))
                {
                    return UsersDAL_Obj.Users_Select_Users_Of_Admin_User(username, password);
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

        public UsersCollection Users_Select_Super_Admin(string username, string password)
        {
            try
            {
                if (chk.check_authority(username, password))
                {
                    return UsersDAL_Obj.Users_Select_Super_Admin(username, password);
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

        public UsersCollection Users_Select_All(string username, string password)
        {
            try
            {
                if (chk.check_authority(username, password))
                {
                    return UsersDAL_Obj.Users_Select_All(username, password);
                }
                else
                {
                    return null;
                }
            }
            catch (Exception e)
            {
                return null;
            }
        }
        public Users Users_InsertByAdmin(string username, string password, int userid, Users user)
        {
            try
            {
                if (chk.check_authority(username, password))
                {
                    return UsersDAL_Obj.Users_InsertByAdmin(username, password, userid, user);
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
        #endregion



    }
}