using System;
using System.Data;
using System.Collections.Generic;
using SC3_Alarm_Module.Entity;
using SC3_Alarm_Module.Collection;
using SC3_Alarm_Module_WS.Code_Files.DBL;

namespace SC3_Alarm_Module.DAL
{
    public class Admin_UsersDAL
    {
        DBL db = new DBL();

        public bool Admin_Users_Delete(string username, string password, int user_id, int admin_id,int user_id2)
        {
            try
            {
                object[,] sp_Params = new object[,]
            {
                   {"@username",username},
                   {"@password",password},
                   {"@user_ID",user_id},
                   {"@Admin_ID", admin_id },
                   {"@user_ID2", user_id2 }

            };


                bool x = db.Execute_Update_Delete_Stored_Procedure("Admin_Users_Delete", sp_Params);
                return x;

            }
            catch (Exception ex)
            {
                throw ex;
            }



        }

        public Admin_Users Admin_Users_Insert(string username, string password, int user_id, Admin_Users New_Admin)
        {
            try
            {
                object[,] sp_Params = new object[,]
                {
                    {"@username", username },
                    {"@password", password },
                    {"@user_ID", user_id },
                    {"@Admin_ID", New_Admin.Admin_ID },
                    {"@User_ID2", New_Admin.User_ID },
                };
                if (db.Execute_Insert_Stored_Procedure("Admin_Users_Insert", sp_Params) > 0)
                {
                    return New_Admin;
                }
                return null;
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
                Admin_UsersCollection User_Admins = new Admin_UsersCollection();

                object[,] sp_params = new object[,]
                {
                    {"@userauthentivation", username},
                    {"@passwordauthentication", password}
                };

                DataTable dt = db.Execute_Stored_Procedure_Show_Values("Users_Admins_Select_All", sp_params);

                if (dt.Rows.Count.Equals(0))
                {
                    return null;
                }
                else
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        User_Admins.Add(new Admin_Users
                        {
                            User_ID = Convert.ToInt32(dr["User_ID"].ToString()),
                            Admin_ID = Convert.ToInt32(dr["Admin_ID"])
                        });
                    }
                }
                return User_Admins;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public bool Users_Admins_Delete(string username, string password, int user_id, int Admin_id)
        {
            try
            {
                object[,] sp_Params = new object[,]
               {
                    {"@userauthentivation", username},
                    {"@passwordauthentication", password},
                    {"@user_id", user_id.ToString() },
                    {"@Admin_id", Admin_id.ToString() }
               };

                bool flag = db.Execute_Update_Delete_Stored_Procedure("Users_Admins_Delete", sp_Params);
                return flag;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool Users_Admins_Insert_Bulk(string username, string password, Admin_UsersCollection Users_Admins_Array)
        {
            try
            {
                bool flag = false;
                if (Users_Admins_Array.Count > 0)
                {
                    List<string> Queries = new List<string>();

                    for (int i = 0; i < Users_Admins_Array.Count; i++)
                    {
                        Queries.Add("insert into Admin_Users(Admin_ID,User_ID) values " +
                        "(" + Users_Admins_Array[i].Admin_ID + "," + Users_Admins_Array[i].User_ID + ");");
                    }

                    object[,] sp_params = new object[,]
                   {
                            {"@userauthentivation", username},
                            {"@passwordauthentication", password},
                            {"@query", string.Join("\r\n", Queries.ToArray())}
                   };

                    int Last_id = db.Execute_Insert_Stored_Procedure("Users_Admins_Insert_Bulk", sp_params);
                    flag = Last_id > 0 ? true : false;
                    return flag;
                }
                return flag;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}