using SC3_Alarm_Module.Collection;
using SC3_Alarm_Module.Entity;
using SC3_Alarm_Module_WS.Code_Files.DBL;
using System;
using System.Data;

namespace SC3_Alarm_Module.DAL
{
    public class Building_Alarm_UnitDAL
    {
        DBL db = new DBL();

        #region AlarmUnit Methods

        /// <summary>
        /// Method Used To Delete Alarm Unit existed in AlarmUnit Table

        public bool Building_AlarmUnit_Delete(string username, string password,int building_alarmunit_id)
        {
            try
            {
                
                object[,]  sp_Params = new object[,]
                {
                    {"@username",username},
                    {"@password", password},
                    {"@Building_AlarmUnit_ID", building_alarmunit_id},

                };

                bool x = db.Execute_Update_Delete_Stored_Procedure("Building_AlarmUnit_Delete", sp_Params);
                return x;

                
                
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public bool Building_AlarmUnit_Delete_All(string username, string password)
        {
            try
            {

                object[,] sp_Params = new object[,]
                {
                    {"@username",username},
                    {"@password", password},
                    

                };

                bool x = db.Execute_Update_Delete_Stored_Procedure("Building_AlarmUnit_Delete_All", sp_Params);
                return x;



            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        /// <summary>
        /// Method Used To Insert New Alarm Unit In The AlarmUnit Table.

        public Building_Alarm_Unit Building_AlarmUnit_Insert(string username, string password, Building_Alarm_Unit New_Building_AlarmUnit)
        {
            try
            {
                object[,] sp_Params = new object[,]
              {
                    {"@Network_Identifier", New_Building_AlarmUnit.Network_Identifier},
                    {"@User_id", New_Building_AlarmUnit.User_ID},
                    {"@Building_AlarmUnit_Name", New_Building_AlarmUnit.Building_AlarmUnit_Name},
                    {"@Latitude", New_Building_AlarmUnit.Latitude},
                    {"@Longitude", New_Building_AlarmUnit.Longitude},
                    {"@ContactPersonName", New_Building_AlarmUnit.ContactPersonName},
                    {"@LandLinePhoneNumber", New_Building_AlarmUnit.LandLinePhoneNumber},
                    {"@MobileNumber", New_Building_AlarmUnit.MobileNumber},
                    {"@AddressLineOne", New_Building_AlarmUnit.AddressLineOne},
                    {"@AddressLineTwo", New_Building_AlarmUnit.AddressLineTwo},
                    {"@SystemCheck", New_Building_AlarmUnit.SystemCheck},
                    {"@SystemCheckedDate", New_Building_AlarmUnit.SystemCheckedDate},
                    {"@CAM1", New_Building_AlarmUnit.CAM1 },
                    {"@CAM2", New_Building_AlarmUnit.CAM2 },
                    {"@CAM3", New_Building_AlarmUnit.CAM3 },
                    {"@CAM4", New_Building_AlarmUnit.CAM4 },
                    {"@Picture1", New_Building_AlarmUnit.Picture1 == null ? System.Data.SqlTypes.SqlBinary.Null : New_Building_AlarmUnit.Picture1 },
                    {"@Picture2", New_Building_AlarmUnit.Picture2 == null ? System.Data.SqlTypes.SqlBinary.Null : New_Building_AlarmUnit.Picture2 },
                    {"@Picture3", New_Building_AlarmUnit.Picture3 == null ? System.Data.SqlTypes.SqlBinary.Null : New_Building_AlarmUnit.Picture3 },
                    {"@Picture4", New_Building_AlarmUnit.Picture4 == null ? System.Data.SqlTypes.SqlBinary.Null : New_Building_AlarmUnit.Picture4 },
                    {"@Network_Type", New_Building_AlarmUnit.Network_Type },
                    {"@Info", New_Building_AlarmUnit.Info },
                    {"@username", username},
                    {"@password", password},
                    
              };


                if (New_Building_AlarmUnit.SystemCheckedDate.Year==0001)
                {
                    sp_Params[11, 1] = DBNull.Value.ToString();
                }

                New_Building_AlarmUnit.Building_AlarmUnit_ID = db.Execute_Insert_Stored_Procedure("Building_AlarmUnit_Insert", sp_Params);
                if(New_Building_AlarmUnit.Building_AlarmUnit_ID > 0)
                {
                    return New_Building_AlarmUnit;
                }
                return null;
                

            }
            catch (Exception ex)
            {

                throw ex;
            }

           
        }

     
        /// <summary>
        /// Method Used To Bring All Information Of One Building Alarm Unit by it's ID From the AlarmUnit Table.
        /// </summary>
        /// <param name="_User"></param>
        /// <param name="AU"></param>
        /// <returns></returns>
        public Building_Alarm_UnitCollection Building_AlarmUnit_Select(string username,string password, int building_alarmunit_id)
        {
            try
            {
                Building_Alarm_UnitCollection Building_AlarmUnit = new Building_Alarm_UnitCollection();
                DateTime dat = new DateTime(0000 - 00 - 00);
                object[,] sp_Params = new object[,]
                
                {
                {"@username",username},
                {"@password",password},
                {"@AlarmUnit_ID",building_alarmunit_id}
                };
 
                
                DataTable dt = db.Execute_Stored_Procedure_Show_Values("Building_AlarmUnit_Select", sp_Params);

                if (dt.Rows.Count.Equals(0))
                {
                    return null;
                }

                else
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        Building_AlarmUnit.Add(new Building_Alarm_Unit
                        {
                            Building_AlarmUnit_ID = Convert.ToInt32(dr["Building_AlarmUnit_ID"]),
                            Network_Identifier = dr["Network_Identifier"] is DBNull ? "" : dr["Network_Identifier"].ToString(),
                            User_ID = Convert.ToInt32(dr["User_ID"]),
                            Building_AlarmUnit_Name = dr["Building_AlarmUnit_Name"].ToString(),
                            Latitude = dr["Latitude"] is DBNull ? 0 : Convert.ToDouble(dr["Latitude"]),
                            Longitude = dr["Longitude"] is DBNull ? 0 : Convert.ToDouble(dr["Longitude"]),
                            ContactPersonName = dr["ContactPersonName"] is DBNull ? "" : dr["ContactPersonName"].ToString(),
                            LandLinePhoneNumber = dr["LandLinePhoneNumber"].ToString(),
                            MobileNumber =  dr["MobileNumber"].ToString(),
                            AddressLineOne = dr["AddressLineOne"] is DBNull ? "" : Convert.ToString(dr["AddressLineOne"]),
                            AddressLineTwo = dr["AddressLineTwo"] is DBNull ? "" : Convert.ToString(dr["AddressLineTwo"]),
                            SystemCheck = dr["SystemCheck"] is DBNull ? 0 : Convert.ToInt32(dr["SystemCheck"]),
                            SystemCheckedDate = dr["SystemCheckedDate"] is DBNull ? dat : Convert.ToDateTime(dr["SystemCheckedDate"]),
                            CAM1 = dr["CAM1"] is DBNull ? "" : dr["CAM1"].ToString(),
                            CAM2 = dr["CAM2"] is DBNull ? "" : dr["CAM2"].ToString(),
                            CAM3 = dr["CAM3"] is DBNull ? "" : dr["CAM3"].ToString(),
                            CAM4 = dr["CAM4"] is DBNull ? "" : dr["CAM4"].ToString(),
                            Picture1 = dr["Picture1"] is DBNull ? null : (byte[])dr["Picture1"],
                            Picture2 = dr["Picture2"] is DBNull ? null : (byte[])dr["Picture2"],
                            Picture3 = dr["Picture3"] is DBNull ? null : (byte[])dr["Picture3"],
                            Picture4 = dr["Picture4"] is DBNull ? null : (byte[])dr["Picture4"],
                            Network_Type = dr["Network_Type"] is DBNull ? "" : Convert.ToString(dr["Network_Type"]),
                            Info = dr["Info"] is DBNull ? "" : Convert.ToString(dr["Info"])
                        });
                    }
                    return Building_AlarmUnit;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        /// <summary>
        /// Method Used To Bring All Information of all Alarm Units From AlarmUnit Table,Authorized By An Admin.

        public Building_Alarm_UnitCollection Building_AlarmUnit_Select_ALL(string username, string password)
        {
            try
            {
                object[,] sp_Params = new object[,]
              {
                {"@username",username},
                {"@password",password}
              };

                Building_Alarm_UnitCollection Building_AlarmUnits = new Building_Alarm_UnitCollection();
                DateTime dat = new DateTime(0000 - 00 - 00);
                DataTable dt = db.Execute_Stored_Procedure_Show_Values("Building_AlarmUnit_Select_ALL", sp_Params);

                if (dt.Rows.Count.Equals(0))
                {
                    return null;
                  
                }


                else
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        Building_AlarmUnits.Add(new Building_Alarm_Unit
                        {
                            Building_AlarmUnit_ID = Convert.ToInt32(dr["Building_AlarmUnit_ID"]),
                            Network_Identifier = dr["Network_Identifier"] is DBNull ? "" : dr["Network_Identifier"].ToString(),
                            User_ID = Convert.ToInt32(dr["User_ID"]),
                            Building_AlarmUnit_Name = dr["Building_AlarmUnit_Name"] is DBNull ? "" : dr["Building_AlarmUnit_Name"].ToString(),
                            Latitude = dr["Latitude"] is DBNull ? 0 : Convert.ToDouble(dr["Latitude"]),
                            Longitude = dr["Longitude"] is DBNull ? 0 : Convert.ToDouble(dr["Longitude"]),
                            ContactPersonName = dr["ContactPersonName"] is DBNull ? "" : dr["ContactPersonName"].ToString(),
                            LandLinePhoneNumber = dr["LandLinePhoneNumber"] is DBNull ? "" : dr["LandLinePhoneNumber"].ToString(),
                            MobileNumber = dr["MobileNumber"] is DBNull ? "" : dr["MobileNumber"].ToString(),
                            AddressLineOne = dr["AddressLineOne"] is DBNull ? "" : Convert.ToString(dr["AddressLineOne"]),
                            AddressLineTwo = dr["AddressLineTwo"] is DBNull ? "" : Convert.ToString(dr["AddressLineTwo"]),
                            SystemCheck = dr["SystemCheck"] is DBNull ? 0 : Convert.ToInt32(dr["SystemCheck"]),
                            SystemCheckedDate = dr["SystemCheckedDate"] is DBNull ? dat : Convert.ToDateTime(dr["SystemCheckedDate"]),
                            CAM1 = dr["CAM1"] is DBNull ? "" : dr["CAM1"].ToString(),
                            CAM2 = dr["CAM2"] is DBNull ? "" : dr["CAM2"].ToString(),
                            CAM3 = dr["CAM3"] is DBNull ? "" : dr["CAM3"].ToString(),
                            CAM4 = dr["CAM4"] is DBNull ? "" : dr["CAM4"].ToString(),
                            Picture1 = dr["Picture1"] is DBNull ? null : (byte[])dr["Picture1"],
                            Picture2 = dr["Picture2"] is DBNull ? null : (byte[])dr["Picture2"],
                            Picture3 = dr["Picture3"] is DBNull ? null : (byte[])dr["Picture3"],
                            Picture4 = dr["Picture4"] is DBNull ? null : (byte[])dr["Picture4"],
                            Network_Type = dr["Network_Type"] is DBNull ? "" : Convert.ToString(dr["Network_Type"]),
                            Info = dr["Info"] is DBNull ? "" : Convert.ToString(dr["Info"])
                        });
                    }

                    return Building_AlarmUnits;
                }
            
            }
            catch (Exception ex)
            {

                throw ex;
            }

            


        }

        public Building_Alarm_UnitCollection Building_AlarmUnit_SelectByUsername(string username, string password)
        {
            try
            {
                object[,] sp_Params = new object[,]
              {
                {"@username",username},
                {"@password",password}
              };

                Building_Alarm_UnitCollection Building_AlarmUnits = new Building_Alarm_UnitCollection();
                DateTime dat = new DateTime(0000 - 00 - 00);
                DataTable dt = db.Execute_Stored_Procedure_Show_Values("Building_AlarmUnit_SelectByUsername", sp_Params);

                if (dt.Rows.Count.Equals(0))
                {
                    return null;

                }


                else
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        Building_AlarmUnits.Add(new Building_Alarm_Unit
                        {
                            Building_AlarmUnit_ID = Convert.ToInt32(dr["Building_AlarmUnit_ID"]),
                            Network_Identifier = dr["Network_Identifier"] is DBNull ? "" : dr["Network_Identifier"].ToString(),
                            User_ID = Convert.ToInt32(dr["User_ID"]),
                            Building_AlarmUnit_Name = dr["Building_AlarmUnit_Name"] is DBNull ? "" : dr["Building_AlarmUnit_Name"].ToString(),
                            Latitude = dr["Latitude"] is DBNull ? 0 : Convert.ToDouble(dr["Latitude"]),
                            Longitude = dr["Longitude"] is DBNull ? 0 : Convert.ToDouble(dr["Longitude"]),
                            ContactPersonName = dr["ContactPersonName"] is DBNull ? "" : dr["ContactPersonName"].ToString(),
                            LandLinePhoneNumber = dr["LandLinePhoneNumber"] is DBNull ? "" : dr["LandLinePhoneNumber"].ToString(),
                            MobileNumber = dr["MobileNumber"] is DBNull ? "" : dr["MobileNumber"].ToString(),
                            AddressLineOne = dr["AddressLineOne"] is DBNull ? "" : Convert.ToString(dr["AddressLineOne"]),
                            AddressLineTwo = dr["AddressLineTwo"] is DBNull ? "" : Convert.ToString(dr["AddressLineTwo"]),
                            SystemCheck = dr["SystemCheck"] is DBNull ? 0 : Convert.ToInt32(dr["SystemCheck"]),
                            SystemCheckedDate = dr["SystemCheckedDate"] is DBNull ? dat : Convert.ToDateTime(dr["SystemCheckedDate"]),
                            CAM1 = dr["CAM1"] is DBNull ? "" : dr["CAM1"].ToString(),
                            CAM2 = dr["CAM2"] is DBNull ? "" : dr["CAM2"].ToString(),
                            CAM3 = dr["CAM3"] is DBNull ? "" : dr["CAM3"].ToString(),
                            CAM4 = dr["CAM4"] is DBNull ? "" : dr["CAM4"].ToString(),
                            Picture1 = dr["Picture1"] is DBNull ? null : (byte[])dr["Picture1"],
                            Picture2 = dr["Picture2"] is DBNull ? null : (byte[])dr["Picture2"],
                            Picture3 = dr["Picture3"] is DBNull ? null : (byte[])dr["Picture3"],
                            Picture4 = dr["Picture4"] is DBNull ? null : (byte[])dr["Picture4"],
                            Network_Type = dr["Network_Type"] is DBNull ? "" : Convert.ToString(dr["Network_Type"]),
                            Info = dr["Info"] is DBNull ? "" : Convert.ToString(dr["Info"])
                        });
                    }

                    return Building_AlarmUnits;
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }




        }


        /// <summary>
        /// Method Used To Update An Existed Alarm Unit In The AlarmUnit Table.
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <param name="Upd_Building_AlarmUnit"></param>
        /// <returns></returns>
        public bool Building_AlarmUnit_Update(string username, string password, Building_Alarm_Unit Upd_Building_AlarmUnit)
        {
            try
            {
                object[,] sp_Params = new object[,]
                {

                    {"@Building_AlarmUnit_ID", Upd_Building_AlarmUnit.Building_AlarmUnit_ID.ToString()},
                    {"@Network_Identifier", Upd_Building_AlarmUnit.Network_Identifier.ToString()},
                    {"@User_id", Upd_Building_AlarmUnit.User_ID.ToString()},
                    {"@Building_AlarmUnit_Name", Upd_Building_AlarmUnit.Building_AlarmUnit_Name},
                    {"@Latitude", Upd_Building_AlarmUnit.Latitude.ToString()},
                    {"@Longitude", Upd_Building_AlarmUnit.Longitude.ToString()},
                    {"@ContactPersonName", Upd_Building_AlarmUnit.ContactPersonName},
                    {"@LandLinePhoneNumber", Upd_Building_AlarmUnit.LandLinePhoneNumber},
                    {"@MobileNumber", Upd_Building_AlarmUnit.MobileNumber.ToString()},
                    {"@AddressLineOne", Upd_Building_AlarmUnit.AddressLineOne},
                    {"@AddressLineTwo", Upd_Building_AlarmUnit.AddressLineTwo},
                    {"@SystemCheck", Upd_Building_AlarmUnit.SystemCheck.ToString()},
                    {"@SystemCheckedDate", Upd_Building_AlarmUnit.SystemCheckedDate.ToString()},
                    {"@CAM1", Upd_Building_AlarmUnit.CAM1.ToString() },
                    {"@CAM2", Upd_Building_AlarmUnit.CAM2.ToString() },
                    {"@CAM3", Upd_Building_AlarmUnit.CAM3.ToString() },
                    {"@CAM4", Upd_Building_AlarmUnit.CAM4.ToString() },
                    {"@Picture1", Upd_Building_AlarmUnit.Picture1 == null ?System.Data.SqlTypes.SqlBinary.Null : Upd_Building_AlarmUnit.Picture1 },
                    {"@Picture2", Upd_Building_AlarmUnit.Picture2 == null ?System.Data.SqlTypes.SqlBinary.Null : Upd_Building_AlarmUnit.Picture2 },
                    {"@Picture3", Upd_Building_AlarmUnit.Picture3 == null ?System.Data.SqlTypes.SqlBinary.Null : Upd_Building_AlarmUnit.Picture3 },
                    {"@Picture4", Upd_Building_AlarmUnit.Picture4 == null ?System.Data.SqlTypes.SqlBinary.Null : Upd_Building_AlarmUnit.Picture4 },
                    {"@Network_Type", Upd_Building_AlarmUnit.Network_Type},
                    {"@Info", Upd_Building_AlarmUnit.Info},
                    {"@username", username},
                    {"@password", password},
                };
               
                if (Upd_Building_AlarmUnit.SystemCheckedDate.Year==0001)
                {
                    sp_Params[12, 1] = DBNull.Value.ToString();
                }

                bool x= db.Execute_Update_Delete_Stored_Procedure("Building_AlarmUnit_Update", sp_Params);

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