using System;
using System.Data;
using SC3_Alarm_Module.Entity;
using SC3_Alarm_Module.Collection;
using SC3_Alarm_Module_WS.Code_Files.DBL;

namespace SC3_Alarm_Module.DAL
{
    public class UsersDAL
    {
        DBL db = new DBL();

        #region Users Methods

        /// <summary>
        /// Method Used To Delete User In The Users Table.
        public bool Users_Delete(string username, string password, int user_id , int user_delete_id)
        {
            try
            {
                object[,] sp_Params = new object[,]
            {
                   {"@username",username},
                   {"@password",password},
                   {"@user_ID",user_id},
                   {"@user_delete_id", user_delete_id }

            };


                bool x= db.Execute_Update_Delete_Stored_Procedure("Users_Delete", sp_Params);
                return x;

            }
            catch (Exception ex)
            {
                throw ex;
            }
         

         
        }


        /// <summary>
        /// Method To Add A New User In The Users Table.
        /// </summary>
        /// <param name="New_User"></param>
        /// <returns></returns>
        public Users Users_Insert(string username ,string password, Users New_User)
        {
            try
            {
                object[,] sp_Params = new object[,]
                {
                    {"@username", username},
                    {"@password", password},
                    {"@New_Username", New_User.Username },
                    {"@New_Password", New_User.Password },
                    {"@Privilege", New_User.Privilege }
                    

                };

                New_User.User_ID = db.Execute_Insert_Stored_Procedure("Users_Insert", sp_Params);
                if(New_User.User_ID > 0)
                {
                    return New_User;
                }
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
           
        }


        /// <summary>
        /// Method Used To Select  the User In The Application And Retrieve All Their Information,Authorized 
        public UsersCollection Users_Select( string username , string password )
        {
            try
            {
                UsersCollection users = new UsersCollection();
                object[,] sp_Params = new object[,]
            {
                {"@username", username},
                {"@password", password}
            };

                
                
                DataTable dt = db.Execute_Stored_Procedure_Show_Values("Users_Select", sp_Params);

                if (dt.Rows.Count.Equals(0))
                {
                    return null;
                }
                else
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        users.Add(new Users
                        {
                            User_ID = Convert.ToInt32(dr["User_ID"]),
                            Username = dr["Username"] is DBNull ? "" : dr["Username"].ToString(),
                            Password = dr["Password"] is DBNull ? "" : dr["Password"].ToString(),
                            Privilege = dr["Privilege"] is DBNull ? "" : dr["Privilege"].ToString()
                        });

                    }

                    return users;
                }
            
            }
            catch (Exception)
            {

                throw;
            }
            
            
       
        }



        /// <summary>
        /// Method To Update An Old User Existed In The Users Table.
        /// </summary>
        /// <param name="Upd_User"></param>
        /// <returns></returns>
        public bool Users_Update(string Old_Username, string Old_Password, Users Upd_User)
        {
            try
            {
                object[,] sp_Params = new object[,]
              {
                    {"@user_id", Upd_User.User_ID},
                    {"@Old_Username", Old_Username},
                    {"@Old_Password", Old_Password},
                    {"@New_username",Upd_User.Username },
                    {"@New_password", Upd_User.Password },
                    {"@privilege", Upd_User.Privilege.ToString()},

              };

                bool x = db.Execute_Update_Delete_Stored_Procedure("Users_Update", sp_Params);
                return x;
               
            }
            catch (Exception)
            {

                throw;
            }
        }
        public UsersCollection Users_Select_Users_Of_Admin_User(string username, string password)
        {
            try
            {
                UsersCollection users = new UsersCollection();
                object[,] sp_Params = new object[,]
            {
                {"@username", username},
                {"@password", password}
            };



                DataTable dt = db.Execute_Stored_Procedure_Show_Values("Users_Select_Users_Of_Admin_User", sp_Params);

                if (dt.Rows.Count.Equals(0))
                {
                    return null;
                }
                else
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        users.Add(new Users
                        {
                            User_ID = Convert.ToInt32(dr["User_ID"]),
                            Username = dr["Username"] is DBNull ? "" : dr["Username"].ToString(),
                            Password = dr["Password"] is DBNull ? "" : dr["Password"].ToString(),
                            Privilege = dr["Privilege"] is DBNull ? "" : dr["Privilege"].ToString(),
                        });

                    }

                    return users;
                }

            }
            catch (Exception)
            {

                throw;
            }



        }
        public UsersCollection Users_Select_Super_Admin(string username, string password)
        {
            try
            {
                UsersCollection users = new UsersCollection();
                object[,] sp_Params = new object[,]
            {
                {"@username", username},
                {"@password", password}
            };



                DataTable dt = db.Execute_Stored_Procedure_Show_Values("Users_Select_Super_Admin", sp_Params);

                if (dt.Rows.Count.Equals(0))
                {
                    return null;
                }
                else
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        users.Add(new Users
                        {
                            User_ID = Convert.ToInt32(dr["User_ID"]),
                            Username = dr["Username"] is DBNull ? "" : dr["Username"].ToString(),
                            Password = dr["Password"] is DBNull ? "" : dr["Password"].ToString(),
                            Privilege = dr["Privilege"] is DBNull ? "" : dr["Privilege"].ToString(),
                        });

                    }

                    return users;
                }

            }
            catch (Exception)
            {

                throw;
            }



        }

        public UsersCollection Users_Select_All(string username, string password)
        {
            try
            {
                UsersCollection users = new UsersCollection();
                DateTime temp_date = new DateTime(0000 - 00 - 00);
                object[,] sp_params = new object[,]
                {
                    {"@userauthentivation", username},
                    {"@passwordauthentication", password}
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
                        users.Add(new Users
                        {
                            
                            Password = dr["Password"] is DBNull ? "" : dr["Password"].ToString(),
                            User_ID = Convert.ToInt32(dr["User_ID"]),
                            Privilege = dr["Privilege"] is DBNull ? "" : dr["Privilege"].ToString(),
                            Username = dr["Username"] is DBNull ? "" : dr["Username"].ToString(),
                        });
                    }
                }
                return users;
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
                bool flag = false;


                object[,] sp_params = new object[,]
               {
                    {"@username", username},
                    {"@password", password},
                    {"@userid", userid.ToString()},
                    {"@new_username", user.Username },
                    {"@new_password", user.Password },
                    {"@new_privilege", user.Privilege },
               };

                user.User_ID = db.Execute_Insert_Stored_Procedure("Users_InsertByAdmin", sp_params);
                if (user.User_ID > 0)
                {
                    return user;
                }

                return null;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        #endregion

    }
}