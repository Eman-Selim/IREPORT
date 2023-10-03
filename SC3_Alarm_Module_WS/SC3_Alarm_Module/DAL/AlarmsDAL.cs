using SC3_Alarm_Module.Collection;
using SC3_Alarm_Module.Entity;
using SC3_Alarm_Module_WS.Code_Files.DBL;
using System;
using System.Data;

namespace SC3_Alarm_Module.DAL
{
    public class AlarmsDAL
    {
        DBL db = new DBL();

       
        #region Alarm Methods
        
        
        /// <summary>
        /// Method Used To Delete An Existed Alarm In Alarms Table,Authorized By An Admin.

        public bool Alarms_Delete_Row(string username, string password, int alarm_id)
        {
            try
            {
                object[,] sp_Params = new object[,]
              {
                {"@username", username},
                {"@password", password},
                {"@Alarm_ID", alarm_id},

              };

                 bool x  = db.Execute_Update_Delete_Stored_Procedure("Alarms_Delete_Row", sp_Params);
                return x;
               
               
            }
            catch (Exception ex)
            {
                throw ex;
            }
          
        }

        public bool Alarms_Delete_User_AckAlarms(string username, string password)
        {
            try
            {
                string[,] sp_Params = new string[,]
              {
                {"@username", username},
                {"@password", password }
                

              };

                bool x = db.Execute_Update_Delete_Stored_Procedure("Alarms_Delete_User_AckAlarms", sp_Params);
                return x;


            }
            catch (Exception ex)
            {
                throw ex;
            }


        }


        public bool Alarms_Delete_User_AllAlarms(string username, string password)
        {
            try
            {
                object[,] sp_Params = new object[,]
              {
                {"@username", username},
                {"@password", password},


              };

                bool x = db.Execute_Update_Delete_Stored_Procedure("Alarms_Delete_User_AllAlarms", sp_Params);
                return x;


            }
            catch (Exception ex)
            {
                throw ex;
            }


        }

        /// <summary>
        /// Method Used To Add A New Alarm In Alarms Table.


        public Alarms Alarms_Insert(string username, string password , Alarms New_Alarm)
        {
            try
            {
                object[,] sp_Params = new object[,]
                {
                {"@username", username},
                {"@password", password},
                {"@Building_AlarmUnit_ID", New_Alarm.Building_AlarmUnit_ID.ToString()=="0"? "" : New_Alarm.Building_AlarmUnit_ID.ToString() },
                {"@Movable_AlarmUnit_ID", New_Alarm.Movable_AlarmUnit_ID.ToString()=="0"? "" : New_Alarm.Movable_AlarmUnit_ID.ToString() },
                {"@Alarm_Type_ID", New_Alarm.Alarm_Type_ID.ToString() },
                {"@Latitude", New_Alarm.Latitude.ToString()},
                {"@Longitude", New_Alarm.Longitude.ToString()},
                {"@DateReceived", New_Alarm.DateReceived.ToString()},
                {"@Acknowledege", New_Alarm.Acknowledege.ToString()},
                {"@AcknowledegeDate", null},
                {"@Visibility",New_Alarm.Visibility},

                };



                New_Alarm.Alarm_ID = db.Execute_Insert_Stored_Procedure("Alarms_Insert", sp_Params );
                if (New_Alarm.Alarm_ID > 0 )
                {
                    return New_Alarm;
                }
                return null;

             }

            catch (Exception ex)
            {
                throw ex;
            }
        }


        /// <summary>
        /// Method Used To Retrieve All Information of The Selected Alarm by it's Id.

        public AlarmsCollection Alarms_Select(string username, string password , int alarm_id)
        {
            try
            {
                AlarmsCollection alarms = new AlarmsCollection();
                DateTime temp_date = new DateTime(0000 - 00 - 00);
                object [,] sp_Params = new object[,]
                {

                {"@username", username},
                {"@password", password},
                {"@Alarm_ID", alarm_id},

                };


                DataTable dt = db.Execute_Stored_Procedure_Show_Values("Alarms_Select", sp_Params);

                if (dt.Rows.Count.Equals(0))
                {
                    return null;
                }
                else
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        alarms.Add(new Alarms
                        {
                            Alarm_ID = Convert.ToInt32(dr["Alarm_ID"]),
                            Building_AlarmUnit_ID = Convert.ToInt32(dr["Building_AlarmUnit_ID"]),
                            Movable_AlarmUnit_ID = Convert.ToInt32(dr["Movable_AlarmUnit_ID"]),
                            Alarm_Type_ID = Convert.ToInt32(dr["Alarm_Type_ID"]),
                            Latitude = dr["Latitude"] is DBNull ? 0 : Convert.ToDouble(dr["Latitude"]),
                            Longitude = dr["Longitude"] is DBNull ? 0 : Convert.ToDouble(dr["Longitude"]),
                            DateReceived = dr["DateReceived"] is DBNull ? temp_date : Convert.ToDateTime(dr["DateReceived"]),
                            Acknowledege = dr["Acknowledege"] is DBNull ? 0 : Convert.ToInt32(dr["Acknowledege"]),
                            AcknowledegeDate = dr["AcknowledegeDate"] is DBNull ? temp_date : Convert.ToDateTime(dr["AcknowledegeDate"]),
                            Visibility =  Convert.ToBoolean(dr["Visibility"])
                        });

                    }
                    return alarms;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }
        public AlarmsCollection Alarms_Select_Date(string username, string password, DateTime from , DateTime to)
        {
            try
            {
                AlarmsCollection alarms = new AlarmsCollection();
                DateTime temp_date = new DateTime(0000 - 00 - 00);
                object[,] sp_Params = new object[,]
                {

                {"@username", username},
                {"@password", password},
                {"@from",from },
                {"@to", to }
                
                };


                DataTable dt = db.Execute_Stored_Procedure_Show_Values("Alarms_Select_Date", sp_Params);

                if (dt.Rows.Count.Equals(0))
                {
                    return null;
                }
                else
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        alarms.Add(new Alarms
                        {
                            Alarm_ID = Convert.ToInt32(dr["Alarm_ID"]),
                            Building_AlarmUnit_ID = Convert.ToInt32(dr["Building_AlarmUnit_ID"]),
                            Movable_AlarmUnit_ID = Convert.ToInt32(dr["Movable_AlarmUnit_ID"]),
                            Alarm_Type_ID = Convert.ToInt32(dr["Alarm_Type_ID"]),
                            Latitude = dr["Latitude"] is DBNull ? 0 : Convert.ToDouble(dr["Latitude"]),
                            Longitude = dr["Longitude"] is DBNull ? 0 : Convert.ToDouble(dr["Longitude"]),
                            DateReceived = dr["DateReceived"] is DBNull ? temp_date : Convert.ToDateTime(dr["DateReceived"]),
                            Acknowledege = dr["Acknowledege"] is DBNull ? 0 : Convert.ToInt32(dr["Acknowledege"]),
                            AcknowledegeDate = dr["AcknowledegeDate"] is DBNull ? temp_date : Convert.ToDateTime(dr["AcknowledegeDate"]),
                            Visibility = Convert.ToBoolean(dr["Visibility"])
                        });

                    }
                    return alarms;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }
        public AlarmsCollection Alarms_Select_VisibleAlarms(string username, string password)
        {
            try
            {
                AlarmsCollection alarms = new AlarmsCollection();
                DateTime temp_date = new DateTime(0000 - 00 - 00);
                object[,] sp_Params = new object[,]
                {

                {"@username", username},
                {"@password", password},     

                };


                DataTable dt = db.Execute_Stored_Procedure_Show_Values("Alarms_Select_VisibleAlarms", sp_Params);

                if (dt.Rows.Count.Equals(0))
                {
                    return null;
                }
                else
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        alarms.Add(new Alarms
                        {
                            Alarm_ID = Convert.ToInt32(dr["Alarm_ID"]),
                            Building_AlarmUnit_ID = Convert.ToInt32(dr["Building_AlarmUnit_ID"]),
                            Movable_AlarmUnit_ID = Convert.ToInt32(dr["Movable_AlarmUnit_ID"]),
                            Alarm_Type_ID = Convert.ToInt32(dr["Alarm_Type_ID"]),
                            Latitude = dr["Latitude"] is DBNull ? 0 : Convert.ToDouble(dr["Latitude"]),
                            Longitude = dr["Longitude"] is DBNull ? 0 : Convert.ToDouble(dr["Longitude"]),
                            DateReceived = dr["DateReceived"] is DBNull ? temp_date : Convert.ToDateTime(dr["DateReceived"]),
                            Acknowledege = dr["Acknowledege"] is DBNull ? 0 : Convert.ToInt32(dr["Acknowledege"]),
                            AcknowledegeDate = dr["AcknowledegeDate"] is DBNull ? temp_date : Convert.ToDateTime(dr["AcknowledegeDate"]),
                            Visibility = Convert.ToBoolean(dr["Visibility"])
                        });

                    }
                    return alarms;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }


        /// <summary>
        /// Method Used To Select & Retrive All Information About All Existed Alarms in The Table.

        public AlarmsCollection Alarms_Select_ALL(string username, string password)
        {
            try
            {
              object[,] sp_Params = new object [,]
            {
                {"@username",username},
                {"@password",password},
            };

                

                DateTime dat = new DateTime(0000 - 00 - 00);

                AlarmsCollection alarms = new AlarmsCollection();

                DataTable dt = db.Execute_Stored_Procedure_Show_Values("Alarms_Select_ALL", sp_Params);

                if (dt.Rows.Count.Equals(0))
                {
                    return null;
                }

                else
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        alarms.Add(new Alarms
                        {
                            Alarm_ID = Convert.ToInt32(dr["Alarm_ID"]),
                            Building_AlarmUnit_ID =dr["Building_AlarmUnit_ID"] is DBNull? 0 : Convert.ToInt32(dr["Building_AlarmUnit_ID"]),
                            Movable_AlarmUnit_ID = dr ["Movable_AlarmUnit_ID"] is DBNull? 0 : Convert.ToInt32(dr["Movable_AlarmUnit_ID"]),
                            Alarm_Type_ID = Convert.ToInt32(dr["Alarm_Type_ID"]),
                            Latitude = dr["Latitude"] is DBNull ? 0 : Convert.ToDouble(dr["Latitude"]),
                            Longitude = dr["Longitude"] is DBNull ? 0 : Convert.ToDouble(dr["Longitude"]),
                            DateReceived = dr["DateReceived"] is DBNull ? dat : Convert.ToDateTime(dr["DateReceived"]),
                            Acknowledege = dr["Acknowledege"] is DBNull ? 0 : Convert.ToInt32(dr["Acknowledege"]),
                            AcknowledegeDate = dr["AcknowledegeDate"] is DBNull ? dat : Convert.ToDateTime(dr["AcknowledegeDate"]),
                            Visibility = Convert.ToBoolean(dr["Visibility"])
                        });

                    }

                    return alarms;
                }
        

            }
            catch (Exception ex)
            {
                throw ex;
            }
          
        }

        public AlarmsCollection Alarms_SelectByBuildingID(string username , string password , int building_id)
        {
            try
            {
                object[,] sp_Params = new object[,]
              {
                {"@username",username},
                {"@password",password},
                {"@building_alarmunit_ID" , building_id},
              };



                DateTime dat = new DateTime(0000 - 00 - 00);

                AlarmsCollection alarms = new AlarmsCollection();

                DataTable dt = db.Execute_Stored_Procedure_Show_Values("Alarms_SelectByBuildingID", sp_Params);

                if (dt.Rows.Count.Equals(0))
                {
                    return null;
                }

                else
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        alarms.Add(new Alarms
                        {
                            Alarm_ID = Convert.ToInt32(dr["Alarm_ID"]),
                            Building_AlarmUnit_ID = dr["Building_AlarmUnit_ID"] is DBNull ? 0 : Convert.ToInt32(dr["Building_AlarmUnit_ID"]),
                            Movable_AlarmUnit_ID = dr["Movable_AlarmUnit_ID"] is DBNull ? 0 : Convert.ToInt32(dr["Movable_AlarmUnit_ID"]),
                            Alarm_Type_ID = Convert.ToInt32(dr["Alarm_Type_ID"]),
                            Latitude = dr["Latitude"] is DBNull ? 0 : Convert.ToDouble(dr["Latitude"]),
                            Longitude = dr["Longitude"] is DBNull ? 0 : Convert.ToDouble(dr["Longitude"]),
                            DateReceived = dr["DateReceived"] is DBNull ? dat : Convert.ToDateTime(dr["DateReceived"]),
                            Acknowledege = dr["Acknowledege"] is DBNull ? 0 : Convert.ToInt32(dr["Acknowledege"]),
                            AcknowledegeDate = dr["AcknowledegeDate"] is DBNull ? dat : Convert.ToDateTime(dr["AcknowledegeDate"]),
                            Visibility = Convert.ToBoolean(dr["Visibility"])
                        });

                    }

                    return alarms;
                }


            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public AlarmsCollection Alarms_SelectByMovableID(string username, string password, int movable_id)
        {
            try
            {
                object[,] sp_Params = new object[,]
              {
                {"@username",username},
                {"@password",password},
                {"@movable_alarmunit_ID" , movable_id},
              };



                DateTime dat = new DateTime(0000 - 00 - 00);

                AlarmsCollection alarms = new AlarmsCollection();

                DataTable dt = db.Execute_Stored_Procedure_Show_Values("Alarms_SelectByMovableID", sp_Params);

                if (dt.Rows.Count.Equals(0))
                {
                    return null;
                }

                else
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        alarms.Add(new Alarms
                        {
                            Alarm_ID = Convert.ToInt32(dr["Alarm_ID"]),
                            Building_AlarmUnit_ID = dr["Building_AlarmUnit_ID"] is DBNull ? 0 : Convert.ToInt32(dr["Building_AlarmUnit_ID"]),
                            Movable_AlarmUnit_ID = dr["Movable_AlarmUnit_ID"] is DBNull ? 0 : Convert.ToInt32(dr["Movable_AlarmUnit_ID"]),
                            Alarm_Type_ID = Convert.ToInt32(dr["Alarm_Type_ID"]),
                            Latitude = dr["Latitude"] is DBNull ? 0 : Convert.ToDouble(dr["Latitude"]),
                            Longitude = dr["Longitude"] is DBNull ? 0 : Convert.ToDouble(dr["Longitude"]),
                            DateReceived = dr["DateReceived"] is DBNull ? dat : Convert.ToDateTime(dr["DateReceived"]),
                            Acknowledege = dr["Acknowledege"] is DBNull ? 0 : Convert.ToInt32(dr["Acknowledege"]),
                            AcknowledegeDate = dr["AcknowledegeDate"] is DBNull ? dat : Convert.ToDateTime(dr["AcknowledegeDate"]),
                            Visibility = Convert.ToBoolean(dr["Visibility"])
                        });

                    }

                    return alarms;
                }


            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Method Used To Update An Existed Alarm In Alarms Table.

        public bool Alarms_Update (string username, string password , Alarms Update)
        {
            try
            {
                object[,] sp_Params = new object[,]
            {
                {"@username", username},
                {"@password", password},
                {"@Alarm_ID", Update.Alarm_ID},
                {"@Building_AlarmUnit_ID", Update.Building_AlarmUnit_ID.ToString()=="0"? "" : Update.Building_AlarmUnit_ID.ToString()},
                {"@Movable_AlarmUnit_ID", Update.Movable_AlarmUnit_ID.ToString()=="0"? "" : Update.Movable_AlarmUnit_ID.ToString()},
                {"@Alarm_Type_ID", Update.Alarm_Type_ID},
                {"@Latitude", Update.Latitude},
                {"@Longitude", Update.Longitude},
                {"@DateReceived", Update.DateReceived},
                {"@Acknowledege", Update.Acknowledege},
                {"@AcknowledegeDate", Update.AcknowledegeDate},
                {"@Visibility", Update.Visibility}

            };
                if(Update.Building_AlarmUnit_ID == 0)
                {
                    sp_Params[3, 1] = DBNull.Value;
                }

                if (Update.AcknowledegeDate.Year == 0001)
                {
                    sp_Params[10, 1] = DBNull.Value.ToString();
                }
                if (Update.DateReceived.Year==0001)
                {
                    sp_Params[8, 1] = DBNull.Value.ToString();
                }
             
              bool x = db.Execute_Update_Delete_Stored_Procedure("Alarms_Update", sp_Params);

                return x;


            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        public bool Alarms_UpdateVisibility_User_AckAlarms(string username, string password)
        {
            try
            {
                object[,] sp_Params = new object [,]
            {
                {"@username", username},
                {"@password", password},
                

            };

                bool x = db.Execute_Update_Delete_Stored_Procedure("Alarms_UpdateVisibility_User_AckAlarms", sp_Params);

                return x;


            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        public bool Alarms_UpdateVisibility_User_AllAlarms(string username, string password)
        {
            try
            {
                object[,] sp_Params = new object[,]
            {
                {"@username", username},
                {"@password", password},
                

            };

                bool x = db.Execute_Update_Delete_Stored_Procedure("Alarms_UpdateVisibility_User_AllAlarms", sp_Params);

                return x;


            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        #endregion 

    }
}