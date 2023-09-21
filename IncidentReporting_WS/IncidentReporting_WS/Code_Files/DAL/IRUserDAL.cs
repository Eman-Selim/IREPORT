using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IncidentReporting_WS.Code_Files.ENL;
using IncidentReporting_WS.Code_Files.COL;
using System.Data;

namespace IncidentReporting_WS.Code_Files.DAL
{
    public class IRUserDAL
    {
        DBL.DBL db = new DBL.DBL();

        public bool Users_Delete(string username, string password, int user_id )
        {
            try
            {
                object[,] sp_Params = new object[,]
                {
                    {"@username", username},
                    {"@password", password},
                    {"@user_id", user_id}
                };
                bool flag = db.Execute_Update_Delete_Stored_Procedure("Users_Delete", sp_Params);
                return flag;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public IRUser Users_Insert(string username, string password, IRUser Users)
        {
            try
            {
                bool flag = false;
                object[,] sp_params = new object[,]
               {
                    {"@username", username},
                    {"@password", username},
                    {"@newUser", Users.Username},
                    {"@newPass", Users.Password},
                    {"@Info",Users.Info},
                    {"@AdminMode", Users.AdminMode}
                };

            

                Users.UserID = db.Execute_Insert_Stored_Procedure("Users_Insert", sp_params);
                if (Users.UserID> 0)
                {
                    return Users;
                }

                return null;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public bool Users_Update(string username, string password, IRUser Users)
        {
            try
            {
                bool flag = false;
                object[,] sp_params = new object[,]
               {
                    {"@username", username},
                    {"@password", password},
                    {"@newUser", Users.Username},
                    {"@newPass", Users.Password},
                    {"@userid",Users.UserID },
                    {"@Info",Users.Info},
                    {"@AdminMode", Users.AdminMode}
                };

                flag= db.Execute_Update_Delete_Stored_Procedure("Users_Update", sp_params);
                return flag;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public IRUserCollection Users_Select_All(string username, string password)
        {
            try
            {
                IRUserCollection Users = new IRUserCollection();
                DateTime temp_date = new DateTime(0000 - 00 - 00);
                object[,] sp_params = new object[,]
                {
                    {"@username", username},
                    {"@password", password}
                };

                DataTable dt = db.Execute_Stored_Procedure_Show_Values("Users_Select_All", sp_params);

                if (dt.Rows.Count.Equals(0))
                {
                    return null;
                }
                else
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        Users.Add(new IRUser
                        {
                            UserID = Convert.ToInt32(dr["UserID"]),
                            Username=Convert.ToString(dr["Username"]),
                            Password=Convert.ToString(dr["Password"]),
                            Info = Convert.ToString(dr["Info"]),
                            AdminMode = Convert.ToString(dr["AdminMode"])
                        });
                    }
                }
                return Users;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public IRUser Users_SelectByUserId(string username, string password, int UserId)
        {
            try
            {
                IRUser Users = new IRUser();
                DateTime temp_date = new DateTime(0000 - 00 - 00);
                object[,] sp_params = new object[,]
                {
                    {"@username", username},
                    {"@password", password},
                    {"@user_id",UserId }
                };

                DataTable dt = db.Execute_Stored_Procedure_Show_Values("Users_SelectByUserId", sp_params);

                if (dt.Rows.Count.Equals(0))
                {
                    return null;
                }
                else
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        Users = new IRUser
                        {
                            UserID = Convert.ToInt32(dr["UserID"]),
                            Username = Convert.ToString(dr["Username"]),
                            Password = Convert.ToString(dr["Password"]),
                            Info = Convert.ToString(dr["Info"]),
                            AdminMode = Convert.ToString(dr["AdminMode"])
                        };
                    }
                }
                return Users;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public IRUser Users_SelectByNamePass(string username, string password)
        {
            try
            {
                IRUser Users = new IRUser();
                DateTime temp_date = new DateTime(0000 - 00 - 00);
                object[,] sp_params = new object[,]
                {
                    {"@username", username},
                    {"@password", password}
                };

                DataTable dt = db.Execute_Stored_Procedure_Show_Values("Users_SelectByNamePass", sp_params);

                if (dt.Rows.Count.Equals(0))
                {
                    return null;
                }
                else
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        Users = new IRUser
                        {
                            UserID = Convert.ToInt32(dr["UserID"]),
                            Username = Convert.ToString(dr["Username"]),
                            Password = Convert.ToString(dr["Password"]),
                            Info = Convert.ToString(dr["Info"]),
                            AdminMode = Convert.ToString(dr["AdminMode"])
                        };
                    }
                }
                return Users;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public IRUserCollection Users_Select_Users_Of_User(string username, string password, int UserId)
        {
            try
            {
                IRUserCollection Users = new IRUserCollection();
                DateTime temp_date = new DateTime(0000 - 00 - 00);
                object[,] sp_params = new object[,]
                {
                    {"@username", username},
                    {"@password", password},
                    {"@userid",UserId }
                };

                DataTable dt = db.Execute_Stored_Procedure_Show_Values("Users_Select_Users_Of_User", sp_params);

                if (dt.Rows.Count.Equals(0))
                {
                    return null;
                }
                else
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        Users.Add( new IRUser
                        {
                            UserID = Convert.ToInt32(dr["User_ID"]),
                            Username = Convert.ToString(dr["Username"]),
                            Password = Convert.ToString(dr["Password"]),
                            Info = Convert.ToString(dr["Info"]),
                            AdminMode = Convert.ToString(dr["AdminMode"])
                        });
                    }
                }
                return Users;
            }
            catch (Exception e)
            {
                return null;
            }
        }
       

        public IRUser Users_SelectByName(string username, string password, string name)
        {
            try
            {
                IRUser Users = new IRUser();
                DateTime temp_date = new DateTime(0000 - 00 - 00);
                object[,] sp_params = new object[,]
                {
                    {"@username", username},
                    {"@password", password},
                    {"@name",name }
                };

                DataTable dt = db.Execute_Stored_Procedure_Show_Values("Users_SelectByName", sp_params);

                if (dt.Rows.Count.Equals(0))
                {
                    return null;
                }
                else
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        Users = new IRUser
                        {
                            UserID = Convert.ToInt32(dr["UserID"]),
                            Username = Convert.ToString(dr["Username"]),
                            Password = Convert.ToString(dr["Password"]),
                            Info = Convert.ToString(dr["Info"]),
                            AdminMode = Convert.ToString(dr["AdminMode"])
                        };
                    }
                }
                return Users;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public IRUserCollection Users_Select_Super_Admin(string username, string password)
        {
            try
            {
                IRUserCollection Users = new IRUserCollection();
                DateTime temp_date = new DateTime(0000 - 00 - 00);
                object[,] sp_params = new object[,]
                {
                    {"@username", username},
                    {"@password", password}
                };

                DataTable dt = db.Execute_Stored_Procedure_Show_Values("Users_Select_Super_Admin", sp_params);

                if (dt.Rows.Count.Equals(0))
                {
                    return null;
                }
                else
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        Users.Add(new IRUser
                        {
                            UserID = Convert.ToInt32(dr["UserID"]),
                            Username = Convert.ToString(dr["Username"]),
                            Password = Convert.ToString(dr["Password"]),
                            Info = Convert.ToString(dr["Info"]),
                            AdminMode = Convert.ToString(dr["AdminMode"])
                        });
                    }
                }
                return Users;
            }
            catch (Exception e)
            {
                return null;
            }
        }


        
    }
}