using System;
using IncidentReporting_WS.Code_Files.CBL;
using IncidentReporting_WS.Code_Files.COL;
using IncidentReporting_WS.Code_Files.DAL;
using IncidentReporting_WS.Code_Files.ENL;

namespace IncidentReporting_WS.Code_Files.SBL
{
	public class UserSBL 
	{
        ChkCBL Chk = new ChkCBL();
        UserDAL UsersDAL_Obj = new UserDAL();

        public bool Users_Delete(string username, string password, int user_id)
        {
            try
            {
                if (Chk.check_authority(username, password))
                {
                    return UsersDAL_Obj.Users_Delete( username, password, user_id);
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

        public User Users_Insert(string username, string password, User Users)
        {
            try
            {
                if (Chk.check_authority(username, password))
                {
                    return UsersDAL_Obj.Users_Insert( username, password, Users);
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

        public bool Users_Update(string username, string password, User Users)
        {
            try
            {
                if (Chk.check_authority(username, password))
                {
                    return UsersDAL_Obj.Users_Update(username, password, Users);
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

        public UserCollection Users_Select_All(string username, string password)
        {
            try
            {
                if (Chk.check_authority(username, password))
                {
                    return UsersDAL_Obj.Users_Select_All( username, password);
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

        public User Users_SelectByUserId(string username, string password, int UserId)
        {
            try
            {
                if (Chk.check_authority(username, password))
                {
                    return UsersDAL_Obj.Users_SelectByUserId( username, password, UserId);
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

        public User Users_SelectByNamePass(string username, string password)
        {
            try
            {
                if (Chk.check_authority(username, password))
                {
                    return UsersDAL_Obj.Users_SelectByNamePass(username, password);
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
        public UserCollection Users_Select_Users_Of_User(string username, string password, int UserId)
        {
            try
            {
                if (Chk.check_authority(username, password))
                {
                    return UsersDAL_Obj.Users_Select_Users_Of_User(username, password, UserId);
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

       
        public User Users_SelectByName(string username, string password, string name)
        {
            try
            {
                if (Chk.check_authority(username, password))
                {
                    return UsersDAL_Obj.Users_SelectByName(username, password, name);
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
        public UserCollection Users_Select_Super_Admin(string username, string password)
        {
            try
            {
                if (Chk.check_authority(username, password))
                {
                    return UsersDAL_Obj.Users_Select_Super_Admin( username, password);
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


    }
}
