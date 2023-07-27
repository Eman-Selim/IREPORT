using IncidentReporting_WS.Code_Files.ENL;
using IncidentReporting_WS.Code_Files.COL;
using System;
using System.Data;

namespace IncidentReporting_WS.Code_Files.DAL
{
    public class AccidentDAL
    {
        DBL.DBL db = new DBL.DBL();

        public bool Accident_Delete(string username, string password, int accidentid)
        {
            try
            {
                object[,] sp_Params = new object[,]
                {
                    {"@username", username},
                    {"@password", password},
                    {"@Accident_ID", accidentid}
                };
                bool flag = db.Execute_Update_Delete_Stored_Procedure("Accident_Delete", sp_Params);
                return flag;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public Accident Accident_Insert(string username, string password, Accident accident)
        {
            try
            {
                bool flag = false;
                object[,] sp_params = new object[,]
               {
                    {"@username", username},
                    {"@password", password},
                    {"@AccidentType", accident.AccidentType },
                    {"@VehiclesToAccident", accident.VehiclesToAccident},
                    {"@Equipments",accident.Equipments},
                    {"@LossesType",accident.LossesType },
                    {"@LossesInfo",accident.LossesInfo },
                    {"@Date",accident.Date },
                    {"@TimeToSend",accident.TimeToSend },
                    {"@TimeToArrive",accident.TimeToArrive },
                    {"@AccidentNumber",accident.AccidentNumber },
                    {"@Additional_info",accident.Additional_info },
                    {"@CompanyID",accident.AccidentID }

               };

                accident.AccidentID = db.Execute_Insert_Stored_Procedure("Accident_Insert", sp_params);
                if (accident.AccidentID > 0)
                {
                    return accident;
                }

                return null;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public AccidentCollection Accident_Select_All(string username, string password)
        {
            try
            {
                AccidentCollection accident = new AccidentCollection();
                DateTime temp_date = new DateTime(0000 - 00 - 00);
                object[,] sp_params = new object[,]
                {
                    {"@username", username},
                    {"@password", password}
                };

                DataTable dt = db.Execute_Stored_Procedure_Show_Values("Accident_Select_All", sp_params);

                if (dt.Rows.Count.Equals(0))
                {
                    return null;
                }
                else
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        accident.Add(new Accident
                        {
                            AccidentID = dr["AccidentID"] is DBNull ? 0 : Convert.ToInt32(dr["AccidentID"]),
                            AccidentType = dr["AccidentType"] is DBNull ? "" : Convert.ToString(dr["AccidentType"]),
                            VehiclesToAccident = dr["VehiclesToAccedent"] is DBNull ? "" : Convert.ToString(dr["VehiclesToAccedent"]),
                            Equipments = dr["Equipments"] is DBNull ? "" : Convert.ToString(dr["Equipments"]),
                            LossesType= dr["LossesType"] is DBNull ? "" : Convert.ToString(dr["LossesType"]),
                            LossesInfo= dr["LossesInfo"] is DBNull ? "":Convert.ToString(dr["LossesInfo"]),
                            Date= dr["Date"] is DBNull ? DateTime.Now : DateTime.Parse(dr["Date"].ToString()),
                            TimeToSend = dr["TimeToSend"] is DBNull ? DateTime.Now : DateTime.Parse(dr["TimeToSend"].ToString()),
                            TimeToArrive = dr["TimeToArrive"] is DBNull ? DateTime.Now : DateTime.Parse(dr["TimeToArrive"].ToString()),
                            AccidentNumber= dr["AccidentNumber"] is DBNull ? "":Convert.ToString(dr["AccidentNumber"]),
                            Additional_info = dr["Additional_info"] is DBNull ? "" : dr["Additional_info"].ToString(),
                            CompanyID = dr["CompanyID"] is DBNull ? 0 : Convert.ToInt32(dr["CompanyID"])
                        });
                    }
                }
                return accident;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public Accident Accident_Select_By_AccidentNumber(string username, string password, int AccidentNumber)
        {
            try
            {
                Accident accident = new Accident();
                DateTime temp_date = new DateTime(0000 - 00 - 00);
                object[,] sp_params = new object[,]
                {
                    {"@username", username},
                    {"@password", password},
                    {"@AccidentNumber",AccidentNumber }
                };

                DataTable dt = db.Execute_Stored_Procedure_Show_Values("Accident_Select_By_AccidentNumber", sp_params);

                if (dt.Rows.Count.Equals(0))
                {
                    return null;
                }
                else
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        accident= new Accident
                        {
                            AccidentID = dr["AccidentID"] is DBNull ? 0 : Convert.ToInt32(dr["AccidentID"]),
                            AccidentType = dr["AccidentType"] is DBNull ? "" : Convert.ToString(dr["AccidentType"]),
                            VehiclesToAccident = dr["VehiclesToAccedent"] is DBNull ? "" : Convert.ToString(dr["VehiclesToAccedent"]),
                            Equipments = dr["Equipments"] is DBNull ? "" : Convert.ToString(dr["Equipments"]),
                            LossesType = dr["LossesType"] is DBNull ? "" : Convert.ToString(dr["LossesType"]),
                            LossesInfo = dr["LossesInfo"] is DBNull ? "" : Convert.ToString(dr["LossesInfo"]),
                            Date = dr["Date"] is DBNull ? DateTime.Now : DateTime.Parse(dr["Date"].ToString()),
                            TimeToSend = dr["TimeToSend"] is DBNull ? DateTime.Now : DateTime.Parse(dr["TimeToSend"].ToString()),
                            TimeToArrive = dr["TimeToArrive"] is DBNull ? DateTime.Now : DateTime.Parse(dr["TimeToArrive"].ToString()),
                            AccidentNumber = dr["AccidentNumber"] is DBNull ? "" : Convert.ToString(dr["AccidentNumber"]),
                            Additional_info = dr["Additional_info"] is DBNull ? "" : dr["Additional_info"].ToString(),
                            CompanyID = dr["CompanyID"] is DBNull ? 0 : Convert.ToInt32(dr["CompanyID"])
                        };
                    }
                }
                return accident;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public AccidentCollection Accident_Select_By_CompanyID(string username, string password, int CompanyID)
        {
            try
            {
                AccidentCollection accident = new AccidentCollection();
                DateTime temp_date = new DateTime(0000 - 00 - 00);
                object[,] sp_params = new object[,]
                {
                    {"@username", username},
                    {"@password", password},
                    {"@CompanyID",CompanyID }
                };

                DataTable dt = db.Execute_Stored_Procedure_Show_Values("Accident_Select_By_CompanyID", sp_params);

                if (dt.Rows.Count.Equals(0))
                {
                    return null;
                }
                else
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        accident .Add( new Accident
                        {
                            AccidentID = dr["AccidentID"] is DBNull ? 0 : Convert.ToInt32(dr["AccidentID"]),
                            AccidentType = dr["AccidentType"] is DBNull ? "" : Convert.ToString(dr["AccidentType"]),
                            VehiclesToAccident = dr["VehiclesToAccedent"] is DBNull ? "" : Convert.ToString(dr["VehiclesToAccedent"]),
                            Equipments = dr["Equipments"] is DBNull ? "" : Convert.ToString(dr["Equipments"]),
                            LossesType = dr["LossesType"] is DBNull ? "" : Convert.ToString(dr["LossesType"]),
                            LossesInfo = dr["LossesInfo"] is DBNull ? "" : Convert.ToString(dr["LossesInfo"]),
                            Date = dr["Date"] is DBNull ? DateTime.Now : DateTime.Parse(dr["Date"].ToString()),
                            TimeToSend = dr["TimeToSend"] is DBNull ? DateTime.Now : DateTime.Parse(dr["TimeToSend"].ToString()),
                            TimeToArrive = dr["TimeToArrive"] is DBNull ? DateTime.Now : DateTime.Parse(dr["TimeToArrive"].ToString()),
                            AccidentNumber = dr["AccidentNumber"] is DBNull ? "" : Convert.ToString(dr["AccidentNumber"]),
                            Additional_info = dr["Additional_info"] is DBNull ? "" : dr["Additional_info"].ToString(),
                            CompanyID = dr["CompanyID"] is DBNull ? 0 : Convert.ToInt32(dr["CompanyID"])
                        });
                    }
                }
                return accident;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public AccidentCollection Accident_Select_By_Date(string username, string password, DateTime date)
        {
            try
            {
                AccidentCollection accident = new AccidentCollection();
                DateTime temp_date = new DateTime(0000 - 00 - 00);
                object[,] sp_params = new object[,]
                {
                    {"@username", username},
                    {"@password", password},
                    {"@Date",date }
                };

                DataTable dt = db.Execute_Stored_Procedure_Show_Values("Accident_Select_By_Date", sp_params);

                if (dt.Rows.Count.Equals(0))
                {
                    return null;
                }
                else
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        accident .Add(new Accident
                        {
                            AccidentID = dr["AccidentID"] is DBNull ? 0 : Convert.ToInt32(dr["AccidentID"]),
                            AccidentType = dr["AccidentType"] is DBNull ? "" : Convert.ToString(dr["AccidentType"]),
                            VehiclesToAccident = dr["VehiclesToAccedent"] is DBNull ? "" : Convert.ToString(dr["VehiclesToAccedent"]),
                            Equipments = dr["Equipments"] is DBNull ? "" : Convert.ToString(dr["Equipments"]),
                            LossesType = dr["LossesType"] is DBNull ? "" : Convert.ToString(dr["LossesType"]),
                            LossesInfo = dr["LossesInfo"] is DBNull ? "" : Convert.ToString(dr["LossesInfo"]),
                            Date = dr["Date"] is DBNull ? DateTime.Now : DateTime.Parse(dr["Date"].ToString()),
                            TimeToSend = dr["TimeToSend"] is DBNull ? DateTime.Now : DateTime.Parse(dr["TimeToSend"].ToString()),
                            TimeToArrive = dr["TimeToArrive"] is DBNull ? DateTime.Now : DateTime.Parse(dr["TimeToArrive"].ToString()),
                            AccidentNumber = dr["AccidentNumber"] is DBNull ? "" : Convert.ToString(dr["AccidentNumber"]),
                            Additional_info = dr["Additional_info"] is DBNull ? "" : dr["Additional_info"].ToString(),
                            CompanyID = dr["CompanyID"] is DBNull ? 0 : Convert.ToInt32(dr["CompanyID"])
                        });
                    }
                }
                return accident;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public AccidentCollection Accident_Select_By_Equipments(string username, string password, string equipments)
        {
            try
            {
                AccidentCollection accident = new AccidentCollection();
                DateTime temp_date = new DateTime(0000 - 00 - 00);
                object[,] sp_params = new object[,]
                {
                    {"@username", username},
                    {"@password", password},
                    {"@Equipments",equipments}
                };

                DataTable dt = db.Execute_Stored_Procedure_Show_Values("Accident_Select_By_Equipments", sp_params);

                if (dt.Rows.Count.Equals(0))
                {
                    return null;
                }
                else
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        accident.Add(new Accident
                        {
                            AccidentID = dr["AccidentID"] is DBNull ? 0 : Convert.ToInt32(dr["AccidentID"]),
                            AccidentType = dr["AccidentType"] is DBNull ? "" : Convert.ToString(dr["AccidentType"]),
                            VehiclesToAccident = dr["VehiclesToAccedent"] is DBNull ? "" : Convert.ToString(dr["VehiclesToAccedent"]),
                            Equipments = dr["Equipments"] is DBNull ? "" : Convert.ToString(dr["Equipments"]),
                            LossesType = dr["LossesType"] is DBNull ? "" : Convert.ToString(dr["LossesType"]),
                            LossesInfo = dr["LossesInfo"] is DBNull ? "" : Convert.ToString(dr["LossesInfo"]),
                            Date = dr["Date"] is DBNull ? DateTime.Now : DateTime.Parse(dr["Date"].ToString()),
                            TimeToSend = dr["TimeToSend"] is DBNull ? DateTime.Now : DateTime.Parse(dr["TimeToSend"].ToString()),
                            TimeToArrive = dr["TimeToArrive"] is DBNull ? DateTime.Now : DateTime.Parse(dr["TimeToArrive"].ToString()),
                            AccidentNumber = dr["AccidentNumber"] is DBNull ? "" : Convert.ToString(dr["AccidentNumber"]),
                            Additional_info = dr["Additional_info"] is DBNull ? "" : dr["Additional_info"].ToString(),
                            CompanyID = dr["CompanyID"] is DBNull ? 0 : Convert.ToInt32(dr["CompanyID"])
                        });
                    }
                }
                return accident;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public Accident Accident_Select_By_ID(string username, string password, int ID)
        {
            try
            {
                Accident accident = new Accident();
                DateTime temp_date = new DateTime(0000 - 00 - 00);
                object[,] sp_params = new object[,]
                {
                    {"@username", username},
                    {"@password", password},
                    {"@AccidentID",ID }
                };

                DataTable dt = db.Execute_Stored_Procedure_Show_Values("Accident_Select_By_ID", sp_params);

                if (dt.Rows.Count.Equals(0))
                {
                    return null;
                }
                else
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        accident = new Accident
                        {
                            AccidentID = dr["AccidentID"] is DBNull ? 0 : Convert.ToInt32(dr["AccidentID"]),
                            AccidentType = dr["AccidentType"] is DBNull ? "" : Convert.ToString(dr["AccidentType"]),
                            VehiclesToAccident = dr["VehiclesToAccedent"] is DBNull ? "" : Convert.ToString(dr["VehiclesToAccedent"]),
                            Equipments = dr["Equipments"] is DBNull ? "" : Convert.ToString(dr["Equipments"]),
                            LossesType = dr["LossesType"] is DBNull ? "" : Convert.ToString(dr["LossesType"]),
                            LossesInfo = dr["LossesInfo"] is DBNull ? "" : Convert.ToString(dr["LossesInfo"]),
                            Date = dr["Date"] is DBNull ? DateTime.Now : DateTime.Parse(dr["Date"].ToString()),
                            TimeToSend = dr["TimeToSend"] is DBNull ? DateTime.Now : DateTime.Parse(dr["TimeToSend"].ToString()),
                            TimeToArrive = dr["TimeToArrive"] is DBNull ? DateTime.Now : DateTime.Parse(dr["TimeToArrive"].ToString()),
                            AccidentNumber = dr["AccidentNumber"] is DBNull ? "" : Convert.ToString(dr["AccidentNumber"]),
                            Additional_info = dr["Additional_info"] is DBNull ? "" : dr["Additional_info"].ToString(),
                            CompanyID = dr["CompanyID"] is DBNull ? 0 : Convert.ToInt32(dr["CompanyID"])
                        };
                    }
                }
                return accident;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public AccidentCollection Accident_Select_By_LossesType(string username, string password, string LossesType)
        {
            try
            {
                AccidentCollection accident = new AccidentCollection();
                DateTime temp_date = new DateTime(0000 - 00 - 00);
                object[,] sp_params = new object[,]
                {
                    {"@username", username},
                    {"@password", password},
                    {"@LossesType",LossesType}
                };

                DataTable dt = db.Execute_Stored_Procedure_Show_Values("Accident_Select_By_LossesType", sp_params);

                if (dt.Rows.Count.Equals(0))
                {
                    return null;
                }
                else
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        accident.Add(new Accident
                        {
                            AccidentID = dr["AccidentID"] is DBNull ? 0 : Convert.ToInt32(dr["AccidentID"]),
                            AccidentType = dr["AccidentType"] is DBNull ? "" : Convert.ToString(dr["AccidentType"]),
                            VehiclesToAccident = dr["VehiclesToAccedent"] is DBNull ? "" : Convert.ToString(dr["VehiclesToAccedent"]),
                            Equipments = dr["Equipments"] is DBNull ? "" : Convert.ToString(dr["Equipments"]),
                            LossesType = dr["LossesType"] is DBNull ? "" : Convert.ToString(dr["LossesType"]),
                            LossesInfo = dr["LossesInfo"] is DBNull ? "" : Convert.ToString(dr["LossesInfo"]),
                            Date = dr["Date"] is DBNull ? DateTime.Now : DateTime.Parse(dr["Date"].ToString()),
                            TimeToSend = dr["TimeToSend"] is DBNull ? DateTime.Now : DateTime.Parse(dr["TimeToSend"].ToString()),
                            TimeToArrive = dr["TimeToArrive"] is DBNull ? DateTime.Now : DateTime.Parse(dr["TimeToArrive"].ToString()),
                            AccidentNumber = dr["AccidentNumber"] is DBNull ? "" : Convert.ToString(dr["AccidentNumber"]),
                            Additional_info = dr["Additional_info"] is DBNull ? "" : dr["Additional_info"].ToString(),
                            CompanyID = dr["CompanyID"] is DBNull ? 0 : Convert.ToInt32(dr["CompanyID"])
                        });
                    }
                }
                return accident;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public AccidentCollection Accident_Select_By_TimeToArrive(string username, string password, DateTime TimeToArrive)
        {
            try
            {
                AccidentCollection accident = new AccidentCollection();
                DateTime temp_date = new DateTime(0000 - 00 - 00);
                object[,] sp_params = new object[,]
                {
                    {"@username", username},
                    {"@password", password},
                    {"@TimeToArrive",TimeToArrive }
                };

                DataTable dt = db.Execute_Stored_Procedure_Show_Values("Accident_Select_By_TimeToArrive", sp_params);

                if (dt.Rows.Count.Equals(0))
                {
                    return null;
                }
                else
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        accident.Add(new Accident
                        {
                            AccidentID = dr["AccidentID"] is DBNull ? 0 : Convert.ToInt32(dr["AccidentID"]),
                            AccidentType = dr["AccidentType"] is DBNull ? "" : Convert.ToString(dr["AccidentType"]),
                            VehiclesToAccident = dr["VehiclesToAccedent"] is DBNull ? "" : Convert.ToString(dr["VehiclesToAccedent"]),
                            Equipments = dr["Equipments"] is DBNull ? "" : Convert.ToString(dr["Equipments"]),
                            LossesType = dr["LossesType"] is DBNull ? "" : Convert.ToString(dr["LossesType"]),
                            LossesInfo = dr["LossesInfo"] is DBNull ? "" : Convert.ToString(dr["LossesInfo"]),
                            Date = dr["Date"] is DBNull ? DateTime.Now : DateTime.Parse(dr["Date"].ToString()),
                            TimeToSend = dr["TimeToSend"] is DBNull ? DateTime.Now : DateTime.Parse(dr["TimeToSend"].ToString()),
                            TimeToArrive = dr["TimeToArrive"] is DBNull ? DateTime.Now : DateTime.Parse(dr["TimeToArrive"].ToString()),
                            AccidentNumber = dr["AccidentNumber"] is DBNull ? "" : Convert.ToString(dr["AccidentNumber"]),
                            Additional_info = dr["Additional_info"] is DBNull ? "" : dr["Additional_info"].ToString(),
                            CompanyID = dr["CompanyID"] is DBNull ? 0 : Convert.ToInt32(dr["CompanyID"])
                        });
                    }
                }
                return accident;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public AccidentCollection Accident_Select_By_TimeToSend(string username, string password, DateTime TimeToSend)
        {
            try
            {
                AccidentCollection accident = new AccidentCollection();
                DateTime temp_date = new DateTime(0000 - 00 - 00);
                object[,] sp_params = new object[,]
                {
                    {"@username", username},
                    {"@password", password},
                    {"@TimeToSend",TimeToSend }
                };

                DataTable dt = db.Execute_Stored_Procedure_Show_Values("Accident_Select_By_TimeToSend", sp_params);

                if (dt.Rows.Count.Equals(0))
                {
                    return null;
                }
                else
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        accident.Add(new Accident
                        {
                            AccidentID = dr["AccidentID"] is DBNull ? 0 : Convert.ToInt32(dr["AccidentID"]),
                            AccidentType = dr["AccidentType"] is DBNull ? "" : Convert.ToString(dr["AccidentType"]),
                            VehiclesToAccident = dr["VehiclesToAccedent"] is DBNull ? "" : Convert.ToString(dr["VehiclesToAccedent"]),
                            Equipments = dr["Equipments"] is DBNull ? "" : Convert.ToString(dr["Equipments"]),
                            LossesType = dr["LossesType"] is DBNull ? "" : Convert.ToString(dr["LossesType"]),
                            LossesInfo = dr["LossesInfo"] is DBNull ? "" : Convert.ToString(dr["LossesInfo"]),
                            Date = dr["Date"] is DBNull ? DateTime.Now : DateTime.Parse(dr["Date"].ToString()),
                            TimeToSend = dr["TimeToSend"] is DBNull ? DateTime.Now : DateTime.Parse(dr["TimeToSend"].ToString()),
                            TimeToArrive = dr["TimeToArrive"] is DBNull ? DateTime.Now : DateTime.Parse(dr["TimeToArrive"].ToString()),
                            AccidentNumber = dr["AccidentNumber"] is DBNull ? "" : Convert.ToString(dr["AccidentNumber"]),
                            Additional_info = dr["Additional_info"] is DBNull ? "" : dr["Additional_info"].ToString(),
                            CompanyID = dr["CompanyID"] is DBNull ? 0 : Convert.ToInt32(dr["CompanyID"])
                        });
                    }
                }
                return accident;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public AccidentCollection Accident_Select_By_Type(string username, string password, string AccidentType)
        {
            try
            {
                AccidentCollection accident = new AccidentCollection();
                DateTime temp_date = new DateTime(0000 - 00 - 00);
                object[,] sp_params = new object[,]
                {
                    {"@username", username},
                    {"@password", password},
                    {"@AccidentType",AccidentType}
                };

                DataTable dt = db.Execute_Stored_Procedure_Show_Values("Accident_Select_By_Type", sp_params);

                if (dt.Rows.Count.Equals(0))
                {
                    return null;
                }
                else
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        accident.Add(new Accident
                        {
                            AccidentID = dr["AccidentID"] is DBNull ? 0 : Convert.ToInt32(dr["AccidentID"]),
                            AccidentType = dr["AccidentType"] is DBNull ? "" : Convert.ToString(dr["AccidentType"]),
                            VehiclesToAccident = dr["VehiclesToAccedent"] is DBNull ? "" : Convert.ToString(dr["VehiclesToAccedent"]),
                            Equipments = dr["Equipments"] is DBNull ? "" : Convert.ToString(dr["Equipments"]),
                            LossesType = dr["LossesType"] is DBNull ? "" : Convert.ToString(dr["LossesType"]),
                            LossesInfo = dr["LossesInfo"] is DBNull ? "" : Convert.ToString(dr["LossesInfo"]),
                            Date = dr["Date"] is DBNull ? DateTime.Now : DateTime.Parse(dr["Date"].ToString()),
                            TimeToSend = dr["TimeToSend"] is DBNull ? DateTime.Now : DateTime.Parse(dr["TimeToSend"].ToString()),
                            TimeToArrive = dr["TimeToArrive"] is DBNull ? DateTime.Now : DateTime.Parse(dr["TimeToArrive"].ToString()),
                            AccidentNumber = dr["AccidentNumber"] is DBNull ? "" : Convert.ToString(dr["AccidentNumber"]),
                            Additional_info = dr["Additional_info"] is DBNull ? "" : dr["Additional_info"].ToString(),
                            CompanyID = dr["CompanyID"] is DBNull ? 0 : Convert.ToInt32(dr["CompanyID"])
                        });
                    }
                }
                return accident;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public AccidentCollection Accident_Select_By_VehiclesToAccident(string username, string password, string VehiclesToAccident)
        {
            try
            {
                AccidentCollection accident = new AccidentCollection();
                DateTime temp_date = new DateTime(0000 - 00 - 00);
                object[,] sp_params = new object[,]
                {
                    {"@username", username},
                    {"@password", password},
                    {"@VehiclesToAccident",VehiclesToAccident}
                };

                DataTable dt = db.Execute_Stored_Procedure_Show_Values("Accident_Select_By_VehiclesToAccident", sp_params);

                if (dt.Rows.Count.Equals(0))
                {
                    return null;
                }
                else
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        accident.Add(new Accident
                        {
                            AccidentID = dr["AccidentID"] is DBNull ? 0 : Convert.ToInt32(dr["AccidentID"]),
                            AccidentType = dr["AccidentType"] is DBNull ? "" : Convert.ToString(dr["AccidentType"]),
                            VehiclesToAccident = dr["VehiclesToAccedent"] is DBNull ? "" : Convert.ToString(dr["VehiclesToAccedent"]),
                            Equipments = dr["Equipments"] is DBNull ? "" : Convert.ToString(dr["Equipments"]),
                            LossesType = dr["LossesType"] is DBNull ? "" : Convert.ToString(dr["LossesType"]),
                            LossesInfo = dr["LossesInfo"] is DBNull ? "" : Convert.ToString(dr["LossesInfo"]),
                            Date = dr["Date"] is DBNull ? DateTime.Now : DateTime.Parse(dr["Date"].ToString()),
                            TimeToSend = dr["TimeToSend"] is DBNull ? DateTime.Now : DateTime.Parse(dr["TimeToSend"].ToString()),
                            TimeToArrive = dr["TimeToArrive"] is DBNull ? DateTime.Now : DateTime.Parse(dr["TimeToArrive"].ToString()),
                            AccidentNumber = dr["AccidentNumber"] is DBNull ? "" : Convert.ToString(dr["AccidentNumber"]),
                            Additional_info = dr["Additional_info"] is DBNull ? "" : dr["Additional_info"].ToString(),
                            CompanyID = dr["CompanyID"] is DBNull ? 0 : Convert.ToInt32(dr["CompanyID"])
                        });
                    }
                }
                return accident;
            }
            catch (Exception e)
            {
                return null;
            }
        }

       

    }
}