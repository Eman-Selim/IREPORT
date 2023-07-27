using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IncidentReporting_WS.Code_Files.ENL;
using IncidentReporting_WS.Code_Files.COL;
using System.Data;

namespace IncidentReporting_WS.Code_Files.DAL
{
    public class Users_AdminDAL
    {
        DBL.DBL db = new DBL.DBL();

        public bool Users_Admin_Delete(string username, string password, int user_id , int Admin_id)
        {
            try
            {
                object[,] sp_Params = new object[,]
                {
                    {"@username", username},
                    {"@password", password},
                    {"@user_id", user_id},
                    {"@Admin_id",Admin_id}
                };
                bool flag = db.Execute_Update_Delete_Stored_Procedure("Users_Admin_Delete", sp_Params);
                return flag;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public Users_Admin Users_Admin_Insert(string username, string password, Users_Admin Users_Admin)
        {
            try
            {
                bool flag = false;
                object[,] sp_params = new object[,]
               {
                    {"@username", username},
                    {"@password", password},
                    {"@Admin_ID", Users_Admin.Admin_ID },
                    {"@User_ID", Users_Admin.User_ID},
                    {"@Info",Users_Admin.Info}
               };

                Users_Admin.Admin_ID = db.Execute_Insert_Stored_Procedure("Users_Admin_Insert", sp_params);
                if (Users_Admin.Admin_ID > 0)
                {
                    return Users_Admin;
                }

                return null;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public Users_AdminCollection Users_Admin_Select_All(string username, string password)
        {
            try
            {
                Users_AdminCollection Users_Admin = new Users_AdminCollection();
                DateTime temp_date = new DateTime(0000 - 00 - 00);
                object[,] sp_params = new object[,]
                {
                    {"@username", username},
                    {"@password", password}
                };

                DataTable dt = db.Execute_Stored_Procedure_Show_Values("Users_Admin_Select_All", sp_params);

                if (dt.Rows.Count.Equals(0))
                {
                    return null;
                }
                else
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        Users_Admin.Add(new Users_Admin
                        {
                            Admin_ID = Convert.ToInt32(dr["Admin_ID"]),
                            User_ID = Convert.ToInt32(dr["User_ID"]),
                            Info = Convert.ToString(dr["Info"])
                        });
                    }
                }
                return Users_Admin;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public Users_Admin Users_Admin_SelectByAdminId(string username, string password, int Admin_ID)
        {
            try
            {
                Users_Admin Users_Admin = new Users_Admin();
                DateTime temp_date = new DateTime(0000 - 00 - 00);
                object[,] sp_params = new object[,]
                {
                    {"@username", username},
                    {"@password", password},
                    {"@Admin_ID",Admin_ID }
                };

                DataTable dt = db.Execute_Stored_Procedure_Show_Values("Users_Admin_SelectByAdminId", sp_params);

                if (dt.Rows.Count.Equals(0))
                {
                    return null;
                }
                else
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        Users_Admin = new Users_Admin
                        {
                            Admin_ID = Convert.ToInt32(dr["Admin_ID"]),
                            User_ID = Convert.ToInt32(dr["User_ID"]),
                            Info = Convert.ToString(dr["Info"])
                        };
                    }
                }
                return Users_Admin;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public Users_Admin Users_Admin_SelectByUserID(string username, string password, int User_ID)
        {
            try
            {
                Users_Admin Users_Admin = new Users_Admin();
                DateTime temp_date = new DateTime(0000 - 00 - 00);
                object[,] sp_params = new object[,]
                {
                    {"@username", username},
                    {"@password", password},
                    {"@User_ID",User_ID }
                };

                DataTable dt = db.Execute_Stored_Procedure_Show_Values("Users_Admin_SelectByUserID", sp_params);

                if (dt.Rows.Count.Equals(0))
                {
                    return null;
                }
                else
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        Users_Admin = new Users_Admin
                        {
                            Admin_ID = Convert.ToInt32(dr["Admin_ID"]),
                            User_ID = Convert.ToInt32(dr["User_ID"]),
                            Info = Convert.ToString(dr["Info"])
                        };
                    }
                }
                return Users_Admin;
            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
}