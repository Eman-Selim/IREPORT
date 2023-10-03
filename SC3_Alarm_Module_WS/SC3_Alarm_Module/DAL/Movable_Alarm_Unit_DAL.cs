using SC3_Alarm_Module.Collection;
using SC3_Alarm_Module.Entity;
using SC3_Alarm_Module_WS.Code_Files.DBL;
using System;
using System.Data;

namespace SC3_Alarm_Module.DAL
{
    public class Movable_Alarm_UnitDAL
    {
        DBL db = new DBL();



        #region AlarmUnit Methods

        /// <summary>
        /// Method Used To Delete Alarm Unit existed in AlarmUnit Table

        public bool Movable_AlarmUnit_Delete(string username, string password, int movable_alarmunit_id)
        {
            try
            {

                object[,] sp_Params = new object[,]
                {
                    {"@username",username},
                    {"@password", password},
                    {"@Movable_AlarmUnit_ID", movable_alarmunit_id},

                };

                bool x = db.Execute_Update_Delete_Stored_Procedure("Movable_AlarmUnit_Delete", sp_Params);
                return x;



            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public bool Movable_AlarmUnit_Delete_All(string username, string password)
        {
            try
            {

                object[,] sp_Params = new object[,]
                {
                    {"@username",username},
                    {"@password", password},


                };

                bool x = db.Execute_Update_Delete_Stored_Procedure("Movable_AlarmUnit_Delete_All", sp_Params);
                return x;



            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        /// <summary>
        /// Method Used To Insert New Alarm Unit In The AlarmUnit Table.

        public Movable_Alarm_Unit Movable_AlarmUnit_Insert(string username, string password, Movable_Alarm_Unit New_Movable_AlarmUnit)
        {
            try
            {
                object[,] sp_Params = new object[,]
              {
                    {"@Network_Identifier", New_Movable_AlarmUnit.Network_Identifier},
                    {"@User_id", New_Movable_AlarmUnit.User_ID},
                    {"@Movable_AlarmUnit_Name", New_Movable_AlarmUnit.Movable_AlarmUnit_Name},
                    {"@ContactPersonName", New_Movable_AlarmUnit.ContactPersonName},
                    {"@LandLinePhoneNumber", New_Movable_AlarmUnit.LandLinePhoneNumber},
                    {"@MobileNumber", New_Movable_AlarmUnit.MobileNumber},
                    {"@SystemCheck", New_Movable_AlarmUnit.SystemCheck},
                    {"@SystemCheckedDate", New_Movable_AlarmUnit.SystemCheckedDate},
                    {"@Network_Type", New_Movable_AlarmUnit.Network_Type},
                    {"@username", username},
                    {"@password", password},
                    {"@Reallocate_flag", New_Movable_AlarmUnit.Reallocate_Flag},
              };


                if (New_Movable_AlarmUnit.SystemCheckedDate.Year == 0001)
                {
                    sp_Params[7, 1] = DBNull.Value.ToString();
                }

                New_Movable_AlarmUnit.Movable_AlarmUnit_ID = db.Execute_Insert_Stored_Procedure("Movable_AlarmUnit_Insert", sp_Params);
                if (New_Movable_AlarmUnit.Movable_AlarmUnit_ID > 0)
                {
                    return New_Movable_AlarmUnit;
                }
                return null;


            }
            catch (Exception ex)
            {

                throw ex;
            }


        }



        /// <summary>
        /// Method Used To Bring All Information Of One Movable Alarm Unit by it's ID From the AlarmUnit Table.
        /// </summary>
        /// <param name="_User"></param>
        /// <param name="AU"></param>
        /// <returns></returns>
        public Movable_Alarm_UnitCollection Movable_AlarmUnit_Select(string username, string password, int movable_alarmunit_id)
        {
            try
            {
                Movable_Alarm_UnitCollection Movable_AlarmUnit = new Movable_Alarm_UnitCollection();
                DateTime dat = new DateTime(0000 - 00 - 00);
                object[,] sp_Params = new object[,]

                {
                {"@username",username},
                {"@password",password},
                {"@Movable_AlarmUnit_ID",movable_alarmunit_id}
                };


                DataTable dt = db.Execute_Stored_Procedure_Show_Values("Movable_AlarmUnit_Select", sp_Params);

                if (dt.Rows.Count.Equals(0))
                {
                    return null;
                }

                else
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        Movable_AlarmUnit.Add(new Movable_Alarm_Unit
                        {
                            Movable_AlarmUnit_ID = Convert.ToInt32(dr["Movable_AlarmUnit_ID"]),
                            Network_Identifier = dr["Network_Identifier"] is DBNull ? "" : dr["Network_Identifier"].ToString(),
                            User_ID = Convert.ToInt32(dr["User_ID"]),
                            Movable_AlarmUnit_Name = dr["Movable_AlarmUnit_Name"].ToString(),
                            ContactPersonName = dr["ContactPersonName"] is DBNull ? "" : dr["ContactPersonName"].ToString(),
                            LandLinePhoneNumber = dr["LandLinePhoneNumber"].ToString(),
                            MobileNumber = dr["MobileNumber"].ToString(),
                            SystemCheck = dr["SystemCheck"] is DBNull ? 0 : Convert.ToInt32(dr["SystemCheck"]),
                            SystemCheckedDate = dr["SystemCheckedDate"] is DBNull ? dat : Convert.ToDateTime(dr["SystemCheckedDate"]),
                            Network_Type = dr["Network_Type"] is DBNull ? "" : dr["Network_Type"].ToString(),
                            Reallocate_Flag = bool.Parse(dr["Reallocate_Flag"].ToString())
                        });
                    }
                    return Movable_AlarmUnit;
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }



        }


        /// <summary>
        /// Method Used To Bring All Information of all Alarm Units From AlarmUnit Table,Authorized By An Admin.

        public Movable_Alarm_UnitCollection Movable_AlarmUnit_Select_ALL(string username, string password)
        {
            try
            {
                object[,] sp_Params = new object[,]
              {
                {"@username",username},
                {"@password",password}
              };

                Movable_Alarm_UnitCollection Movable_AlarmUnits = new Movable_Alarm_UnitCollection();
                DateTime dat = new DateTime(0000 - 00 - 00);
                DataTable dt = db.Execute_Stored_Procedure_Show_Values("Movable_AlarmUnit_Select_ALL", sp_Params);

                if (dt.Rows.Count.Equals(0))
                {
                    return null;

                }


                else
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        Movable_AlarmUnits.Add(new Movable_Alarm_Unit
                        {
                            Movable_AlarmUnit_ID = Convert.ToInt32(dr["Movable_AlarmUnit_ID"]),
                            Network_Identifier = dr["Network_Identifier"] is DBNull ? "" : dr["Network_Identifier"].ToString(),
                            User_ID = Convert.ToInt32(dr["User_ID"]),
                            Movable_AlarmUnit_Name = dr["Movable_AlarmUnit_Name"] is DBNull ? "" : dr["Movable_AlarmUnit_Name"].ToString(),
                            ContactPersonName = dr["ContactPersonName"] is DBNull ? "" : dr["ContactPersonName"].ToString(),
                            LandLinePhoneNumber = dr["LandLinePhoneNumber"] is DBNull ? "" : dr["LandLinePhoneNumber"].ToString(),
                            MobileNumber = dr["MobileNumber"] is DBNull ? "" : dr["MobileNumber"].ToString(),
                            SystemCheck = dr["SystemCheck"] is DBNull ? 0 : Convert.ToInt32(dr["SystemCheck"]),
                            SystemCheckedDate = dr["SystemCheckedDate"] is DBNull ? dat : Convert.ToDateTime(dr["SystemCheckedDate"]),
                            Network_Type = dr["Network_Type"] is DBNull? "" : dr["Network_Type"].ToString(),
                            Reallocate_Flag = bool.Parse(dr["Reallocate_Flag"].ToString())
                        });
                    }
                    return Movable_AlarmUnits;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Movable_Alarm_UnitCollection Movable_AlarmUnit_SelectByUsername(string username, string password)
        {
            try
            {
                object[,] sp_Params = new object[,]
              {
                {"@username",username},
                {"@password",password}
              };

                Movable_Alarm_UnitCollection Movable_AlarmUnits = new Movable_Alarm_UnitCollection();
                DateTime dat = new DateTime(0000 - 00 - 00);
                DataTable dt = db.Execute_Stored_Procedure_Show_Values("Movable_AlarmUnit_SelectByUsername", sp_Params);

                if (dt.Rows.Count.Equals(0))
                {
                    return null;

                }


                else
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        Movable_AlarmUnits.Add(new Movable_Alarm_Unit
                        {
                            Movable_AlarmUnit_ID = Convert.ToInt32(dr["Movable_AlarmUnit_ID"]),
                            Network_Identifier = dr["Network_Identifier"] is DBNull ? "" : dr["Network_Identifier"].ToString(),
                            User_ID = Convert.ToInt32(dr["User_ID"]),
                            Movable_AlarmUnit_Name = dr["Movable_AlarmUnit_Name"] is DBNull ? "" : dr["Movable_AlarmUnit_Name"].ToString(),
                            ContactPersonName = dr["ContactPersonName"] is DBNull ? "" : dr["ContactPersonName"].ToString(),
                            LandLinePhoneNumber = dr["LandLinePhoneNumber"] is DBNull ? "" : dr["LandLinePhoneNumber"].ToString(),
                            MobileNumber = dr["MobileNumber"] is DBNull ? "" : dr["MobileNumber"].ToString(),
                            SystemCheck = dr["SystemCheck"] is DBNull ? 0 : Convert.ToInt32(dr["SystemCheck"]),
                            SystemCheckedDate = dr["SystemCheckedDate"] is DBNull ? dat : Convert.ToDateTime(dr["SystemCheckedDate"]),
                            Network_Type = dr["Network_Type"] is DBNull ? "" : dr["Network_Type"].ToString(),
                            Reallocate_Flag = bool.Parse(dr["Reallocate_Flag"].ToString())
                        });
                    }

                    return Movable_AlarmUnits;
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }




        }

        /// <summary>
        /// Method Used To Update An Existed Alarm Unit In The AlarmUnit Table.

        public bool Movable_AlarmUnit_Update(string username, string password, Movable_Alarm_Unit Upd_Movable_AlarmUnit)
        {
            try
            {
                object[,] sp_Params = new object[,]
                {

                    {"@Movable_AlarmUnit_ID", Upd_Movable_AlarmUnit.Movable_AlarmUnit_ID.ToString()},
                    {"@Network_Identifier", Upd_Movable_AlarmUnit.Network_Identifier.ToString()},
                    {"@User_id", Upd_Movable_AlarmUnit.User_ID.ToString()},
                    {"@Movable_AlarmUnit_Name", Upd_Movable_AlarmUnit.Movable_AlarmUnit_Name},
                    {"@ContactPersonName", Upd_Movable_AlarmUnit.ContactPersonName},
                    {"@LandLinePhoneNumber", Upd_Movable_AlarmUnit.LandLinePhoneNumber},
                    {"@MobileNumber", Upd_Movable_AlarmUnit.MobileNumber.ToString()},
                    {"@SystemCheck", Upd_Movable_AlarmUnit.SystemCheck.ToString()},
                    {"@SystemCheckedDate", Upd_Movable_AlarmUnit.SystemCheckedDate.ToString()},
                    {"@Network_Type",Upd_Movable_AlarmUnit.Network_Type },
                    {"@username", username},
                    {"@password", password},
                    {"@Reallocate_flag", Upd_Movable_AlarmUnit.Reallocate_Flag},
                };

                if (Upd_Movable_AlarmUnit.SystemCheckedDate.Year == 0001)
                {
                    sp_Params[8, 1] = DBNull.Value.ToString();
                }

                bool x = db.Execute_Update_Delete_Stored_Procedure("Movable_AlarmUnit_Update", sp_Params);

                return x;
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Method Used To Update An Existed Alarm Unit In The AlarmUnit Table.

        public bool Movable_AlarmUnit_Update_User(string username, string password, Movable_Alarm_Unit Upd_Movable_AlarmUnit)
        {
            try
            {
                object[,] sp_Params = new object[,]
                {

                    {"@Movable_AlarmUnit_ID", Upd_Movable_AlarmUnit.Movable_AlarmUnit_ID.ToString()},
                    {"@User_id", Upd_Movable_AlarmUnit.User_ID.ToString()},
                    {"@username", username},
                    {"@password", password},
                   
                };

                if (Upd_Movable_AlarmUnit.SystemCheckedDate.Year == 0001)
                {
                    sp_Params[8, 1] = DBNull.Value.ToString();
                }

                bool x = db.Execute_Update_Delete_Stored_Procedure("Movable_AlarmUnit_Update_User", sp_Params);

                return x;
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
    #endregion
}