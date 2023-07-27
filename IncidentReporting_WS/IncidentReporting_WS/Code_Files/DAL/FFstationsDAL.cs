using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IncidentReporting_WS.Code_Files.ENL;
using IncidentReporting_WS.Code_Files.COL;
using System.Data;

namespace IncidentReporting_WS.Code_Files.DAL
{
    public class FFstationsDAL
    {
        DBL.DBL db = new DBL.DBL();

        public bool FFstations_Delete(string username, string password, int FFstationsID)
        {
            try
            {
                object[,] sp_Params = new object[,]
                {
                    {"@username", username},
                    {"@password", password},
                    {"@FFstationsID", FFstationsID}
                };
                bool flag = db.Execute_Update_Delete_Stored_Procedure("FFstations_Delete", sp_Params);
                return flag;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public FFstations FFstations_Insert(string username, string password, FFstations FFstations )
        {
            try
            {
                bool flag = false;
                object[,] sp_params = new object[,]
               {
                    {"@username", username},
                    {"@password", password},
                    {"@Sector", FFstations.Sector },
                    {"@AreaName", FFstations.AreaName},
                    {"@Street",FFstations.Street},
                    {"@ZoneNumber",FFstations.ZoneNumber},
                    {"@Signs",FFstations.Signs},
                    {"@OfficersNumber",FFstations.OfficersNumber},
                    {"@SoliderNumber",FFstations.SoliderNumber},
                    {"@CarsNumber",FFstations.CarsNumber},
                    {"@Equipments",FFstations.Equipments},
                    {"@Additional_info",FFstations.Additional_info},
                    {"@UserID",FFstations.UserID}

               };

                FFstations.FF_ID = db.Execute_Insert_Stored_Procedure("FFstations_Insert", sp_params);
                if (FFstations.FF_ID > 0)
                {
                    return FFstations;
                }

                return null;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public FFstationsCollection FFstations_Select_All(string username, string password)
        {
            try
            {
                FFstationsCollection FFstations = new FFstationsCollection();
                DateTime temp_date = new DateTime(0000 - 00 - 00);
                object[,] sp_params = new object[,]
                {
                    {"@username", username},
                    {"@password", password}
                };

                DataTable dt = db.Execute_Stored_Procedure_Show_Values("FFstations_Select_All", sp_params);

                if (dt.Rows.Count.Equals(0))
                {
                    return null;
                }
                else
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        FFstations.Add(new FFstations
                        {
                            FF_ID = Convert.ToInt32(dr["FF_ID"]),
                            Sector = Convert.ToString(dr["Sector"]),
                            AreaName = Convert.ToString(dr["AreaName"]),
                            Equipments = Convert.ToString(dr["Equipments"]),
                            Street = Convert.ToString(dr["Street"]),
                            ZoneNumber = Convert.ToString(dr["ZoneNumber"]),
                            Signs = dr["Signs"].ToString(),
                            OfficersNumber = dr["OfficersNumber"].ToString(),
                            SoliderNumber = dr["SoliderNumber"].ToString(),
                            CarsNumber = Convert.ToString(dr["CarsNumber"]),
                            Additional_info = dr["Additional_info"] is DBNull ? "" : dr["Additional_info"].ToString(),
                            UserID = Convert.ToInt32(dr["UserID"])
                        });
                    }
                }
                return FFstations;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public FFstationsCollection FFstations_Select_By_AreaName(string username, string password, string AreaName)
        {
            try
            {
                FFstationsCollection FFstations = new FFstationsCollection();
                DateTime temp_date = new DateTime(0000 - 00 - 00);
                object[,] sp_params = new object[,]
                {
                    {"@username", username},
                    {"@password", password},
                    {"@AreaName",AreaName }
                };

                DataTable dt = db.Execute_Stored_Procedure_Show_Values("FFstations_Select_By_AreaName", sp_params);

                if (dt.Rows.Count.Equals(0))
                {
                    return null;
                }
                else
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        FFstations.Add( new FFstations
                        {
                            FF_ID = Convert.ToInt32(dr["FF_ID"]),
                            Sector = Convert.ToString(dr["Sector"]),
                            AreaName = Convert.ToString(dr["AreaName"]),
                            Equipments = Convert.ToString(dr["Equipments"]),
                            Street = Convert.ToString(dr["Street"]),
                            ZoneNumber = Convert.ToString(dr["ZoneNumber"]),
                            Signs = dr["Signs"].ToString(),
                            OfficersNumber = dr["OfficersNumber"].ToString(),
                            SoliderNumber = dr["SoliderNumber"].ToString(),
                            CarsNumber = Convert.ToString(dr["CarsNumber"]),
                            Additional_info = dr["Additional_info"] is DBNull ? "" : dr["Additional_info"].ToString(),
                            UserID = Convert.ToInt32(dr["UserID"])
                        });
                    }
                }
                return FFstations;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public FFstationsCollection FFstations_Select_By_CarsNumber(string username, string password, string CarsNumber)
        {
            try
            {
                FFstationsCollection FFstations = new FFstationsCollection();
                DateTime temp_date = new DateTime(0000 - 00 - 00);
                object[,] sp_params = new object[,]
                {
                    {"@username", username},
                    {"@password", password},
                    {"@CarsNumber",CarsNumber }
                };

                DataTable dt = db.Execute_Stored_Procedure_Show_Values("FFstations_Select_By_CarsNumber", sp_params);

                if (dt.Rows.Count.Equals(0))
                {
                    return null;
                }
                else
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        FFstations.Add(new FFstations
                        {
                            FF_ID = Convert.ToInt32(dr["FF_ID"]),
                            Sector = Convert.ToString(dr["Sector"]),
                            AreaName = Convert.ToString(dr["AreaName"]),
                            Equipments = Convert.ToString(dr["Equipments"]),
                            Street = Convert.ToString(dr["Street"]),
                            ZoneNumber = Convert.ToString(dr["ZoneNumber"]),
                            Signs = dr["Signs"].ToString(),
                            OfficersNumber = dr["OfficersNumber"].ToString(),
                            SoliderNumber = dr["SoliderNumber"].ToString(),
                            CarsNumber = Convert.ToString(dr["CarsNumber"]),
                            Additional_info = dr["Additional_info"] is DBNull ? "" : dr["Additional_info"].ToString(),
                            UserID = Convert.ToInt32(dr["UserID"])
                        });
                    }
                }
                return FFstations;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public FFstationsCollection FFstations_Select_By_Equipments(string username, string password, string Equipments)
        {
            try
            {
                FFstationsCollection FFstations = new FFstationsCollection();
                DateTime temp_date = new DateTime(0000 - 00 - 00);
                object[,] sp_params = new object[,]
                {
                    {"@username", username},
                    {"@password", password},
                    {"@Equipments",Equipments }
                };

                DataTable dt = db.Execute_Stored_Procedure_Show_Values("FFstations_Select_By_Equipments", sp_params);

                if (dt.Rows.Count.Equals(0))
                {
                    return null;
                }
                else
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        FFstations.Add(new FFstations
                        {
                            FF_ID = Convert.ToInt32(dr["FF_ID"]),
                            Sector = Convert.ToString(dr["Sector"]),
                            AreaName = Convert.ToString(dr["AreaName"]),
                            Equipments = Convert.ToString(dr["Equipments"]),
                            Street = Convert.ToString(dr["Street"]),
                            ZoneNumber = Convert.ToString(dr["ZoneNumber"]),
                            Signs = dr["Signs"].ToString(),
                            OfficersNumber = dr["OfficersNumber"].ToString(),
                            SoliderNumber = dr["SoliderNumber"].ToString(),
                            CarsNumber = Convert.ToString(dr["CarsNumber"]),
                            Additional_info = dr["Additional_info"] is DBNull ? "" : dr["Additional_info"].ToString(),
                            UserID = Convert.ToInt32(dr["UserID"])
                        });
                    }
                }
                return FFstations;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public FFstationsCollection FFstations_Select_By_FF_ID(string username, string password, int FF_ID)
        {
            try
            {
                FFstationsCollection FFstations = new FFstationsCollection();
                DateTime temp_date = new DateTime(0000 - 00 - 00);
                object[,] sp_params = new object[,]
                {
                    {"@username", username},
                    {"@password", password},
                    {"@FF_ID",FF_ID }
                };

                DataTable dt = db.Execute_Stored_Procedure_Show_Values("FFstations_Select_By_FF_ID", sp_params);

                if (dt.Rows.Count.Equals(0))
                {
                    return null;
                }
                else
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        FFstations.Add(new FFstations
                        {
                            FF_ID = Convert.ToInt32(dr["FF_ID"]),
                            Sector = Convert.ToString(dr["Sector"]),
                            AreaName = Convert.ToString(dr["AreaName"]),
                            Equipments = Convert.ToString(dr["Equipments"]),
                            Street = Convert.ToString(dr["Street"]),
                            ZoneNumber = Convert.ToString(dr["ZoneNumber"]),
                            Signs = dr["Signs"].ToString(),
                            OfficersNumber = dr["OfficersNumber"].ToString(),
                            SoliderNumber = dr["SoliderNumber"].ToString(),
                            CarsNumber = Convert.ToString(dr["CarsNumber"]),
                            Additional_info = dr["Additional_info"] is DBNull ? "" : dr["Additional_info"].ToString(),
                            UserID = Convert.ToInt32(dr["UserID"])
                        });
                    }
                }
                return FFstations;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public FFstationsCollection FFstations_Select_By_OfficersNumber(string username, string password, string OfficersNumber)
        {
            try
            {
                FFstationsCollection FFstations = new FFstationsCollection();
                DateTime temp_date = new DateTime(0000 - 00 - 00);
                object[,] sp_params = new object[,]
                {
                    {"@username", username},
                    {"@password", password},
                    {"@OfficersNumber",OfficersNumber }
                };

                DataTable dt = db.Execute_Stored_Procedure_Show_Values("FFstations_Select_By_OfficersNumber", sp_params);

                if (dt.Rows.Count.Equals(0))
                {
                    return null;
                }
                else
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        FFstations.Add(new FFstations
                        {
                            FF_ID = Convert.ToInt32(dr["FF_ID"]),
                            Sector = Convert.ToString(dr["Sector"]),
                            AreaName = Convert.ToString(dr["AreaName"]),
                            Equipments = Convert.ToString(dr["Equipments"]),
                            Street = Convert.ToString(dr["Street"]),
                            ZoneNumber = Convert.ToString(dr["ZoneNumber"]),
                            Signs = dr["Signs"].ToString(),
                            OfficersNumber = dr["OfficersNumber"].ToString(),
                            SoliderNumber = dr["SoliderNumber"].ToString(),
                            CarsNumber = Convert.ToString(dr["CarsNumber"]),
                            Additional_info = dr["Additional_info"] is DBNull ? "" : dr["Additional_info"].ToString(),
                            UserID = Convert.ToInt32(dr["UserID"])
                        });
                    }
                }
                return FFstations;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public FFstationsCollection FFstations_Select_By_Sector(string username, string password, string Sector)
        {
            try
            {
                FFstationsCollection FFstations = new FFstationsCollection();
                DateTime temp_date = new DateTime(0000 - 00 - 00);
                object[,] sp_params = new object[,]
                {
                    {"@username", username},
                    {"@password", password},
                    {"@Sector",Sector }
                };

                DataTable dt = db.Execute_Stored_Procedure_Show_Values("FFstations_Select_By_Sector", sp_params);

                if (dt.Rows.Count.Equals(0))
                {
                    return null;
                }
                else
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        FFstations.Add(new FFstations
                        {
                            FF_ID = Convert.ToInt32(dr["FF_ID"]),
                            Sector = Convert.ToString(dr["Sector"]),
                            AreaName = Convert.ToString(dr["AreaName"]),
                            Equipments = Convert.ToString(dr["Equipments"]),
                            Street = Convert.ToString(dr["Street"]),
                            ZoneNumber = Convert.ToString(dr["ZoneNumber"]),
                            Signs = dr["Signs"].ToString(),
                            OfficersNumber = dr["OfficersNumber"].ToString(),
                            SoliderNumber = dr["SoliderNumber"].ToString(),
                            CarsNumber = Convert.ToString(dr["CarsNumber"]),
                            Additional_info = dr["Additional_info"] is DBNull ? "" : dr["Additional_info"].ToString(),
                            UserID = Convert.ToInt32(dr["UserID"])
                        });
                    }
                }
                return FFstations;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public FFstationsCollection FFstations_Select_By_Signs(string username, string password, string Signs)
        {
            try
            {
                FFstationsCollection FFstations = new FFstationsCollection();
                DateTime temp_date = new DateTime(0000 - 00 - 00);
                object[,] sp_params = new object[,]
                {
                    {"@username", username},
                    {"@password", password},
                    {"@Signs",Signs }
                };

                DataTable dt = db.Execute_Stored_Procedure_Show_Values("FFstations_Select_By_Signs", sp_params);

                if (dt.Rows.Count.Equals(0))
                {
                    return null;
                }
                else
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        FFstations.Add(new FFstations
                        {
                            FF_ID = Convert.ToInt32(dr["FF_ID"]),
                            Sector = Convert.ToString(dr["Sector"]),
                            AreaName = Convert.ToString(dr["AreaName"]),
                            Equipments = Convert.ToString(dr["Equipments"]),
                            Street = Convert.ToString(dr["Street"]),
                            ZoneNumber = Convert.ToString(dr["ZoneNumber"]),
                            Signs = dr["Signs"].ToString(),
                            OfficersNumber = dr["OfficersNumber"].ToString(),
                            SoliderNumber = dr["SoliderNumber"].ToString(),
                            CarsNumber = Convert.ToString(dr["CarsNumber"]),
                            Additional_info = dr["Additional_info"] is DBNull ? "" : dr["Additional_info"].ToString(),
                            UserID = Convert.ToInt32(dr["UserID"])
                        });
                    }
                }
                return FFstations;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public FFstationsCollection FFstations_Select_By_SoliderNumber(string username, string password, string SoliderNumber)
        {
            try
            {
                FFstationsCollection FFstations = new FFstationsCollection();
                DateTime temp_date = new DateTime(0000 - 00 - 00);
                object[,] sp_params = new object[,]
                {
                    {"@username", username},
                    {"@password", password},
                    {"@SoliderNumber",SoliderNumber }
                };

                DataTable dt = db.Execute_Stored_Procedure_Show_Values("FFstations_Select_By_SoliderNumber", sp_params);

                if (dt.Rows.Count.Equals(0))
                {
                    return null;
                }
                else
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        FFstations.Add(new FFstations
                        {
                            FF_ID = Convert.ToInt32(dr["FF_ID"]),
                            Sector = Convert.ToString(dr["Sector"]),
                            AreaName = Convert.ToString(dr["AreaName"]),
                            Equipments = Convert.ToString(dr["Equipments"]),
                            Street = Convert.ToString(dr["Street"]),
                            ZoneNumber = Convert.ToString(dr["ZoneNumber"]),
                            Signs = dr["Signs"].ToString(),
                            OfficersNumber = dr["OfficersNumber"].ToString(),
                            SoliderNumber = dr["SoliderNumber"].ToString(),
                            CarsNumber = Convert.ToString(dr["CarsNumber"]),
                            Additional_info = dr["Additional_info"] is DBNull ? "" : dr["Additional_info"].ToString(),
                            UserID = Convert.ToInt32(dr["UserID"])
                        });
                    }
                }
                return FFstations;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public FFstationsCollection FFstations_Select_By_Street(string username, string password, string Street)
        {
            try
            {
                FFstationsCollection FFstations = new FFstationsCollection();
                DateTime temp_date = new DateTime(0000 - 00 - 00);
                object[,] sp_params = new object[,]
                {
                    {"@username", username},
                    {"@password", password},
                    {"@Street",Street }
                };

                DataTable dt = db.Execute_Stored_Procedure_Show_Values("FFstations_Select_By_Street", sp_params);

                if (dt.Rows.Count.Equals(0))
                {
                    return null;
                }
                else
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        FFstations.Add(new FFstations
                        {
                            FF_ID = Convert.ToInt32(dr["FF_ID"]),
                            Sector = Convert.ToString(dr["Sector"]),
                            AreaName = Convert.ToString(dr["AreaName"]),
                            Equipments = Convert.ToString(dr["Equipments"]),
                            Street = Convert.ToString(dr["Street"]),
                            ZoneNumber = Convert.ToString(dr["ZoneNumber"]),
                            Signs = dr["Signs"].ToString(),
                            OfficersNumber = dr["OfficersNumber"].ToString(),
                            SoliderNumber = dr["SoliderNumber"].ToString(),
                            CarsNumber = Convert.ToString(dr["CarsNumber"]),
                            Additional_info = dr["Additional_info"] is DBNull ? "" : dr["Additional_info"].ToString(),
                            UserID = Convert.ToInt32(dr["UserID"])
                        });
                    }
                }
                return FFstations;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public FFstationsCollection FFstations_Select_By_UserID(string username, string password, int UserID)
        {
            try
            {
                FFstationsCollection FFstations = new FFstationsCollection();
                DateTime temp_date = new DateTime(0000 - 00 - 00);
                object[,] sp_params = new object[,]
                {
                    {"@username", username},
                    {"@password", password},
                    {"@UserID",UserID }
                };

                DataTable dt = db.Execute_Stored_Procedure_Show_Values("FFstations_Select_By_UserID", sp_params);

                if (dt.Rows.Count.Equals(0))
                {
                    return null;
                }
                else
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        FFstations.Add(new FFstations
                        {
                            FF_ID = Convert.ToInt32(dr["FF_ID"]),
                            Sector = Convert.ToString(dr["Sector"]),
                            AreaName = Convert.ToString(dr["AreaName"]),
                            Equipments = Convert.ToString(dr["Equipments"]),
                            Street = Convert.ToString(dr["Street"]),
                            ZoneNumber = Convert.ToString(dr["ZoneNumber"]),
                            Signs = dr["Signs"].ToString(),
                            OfficersNumber = dr["OfficersNumber"].ToString(),
                            SoliderNumber = dr["SoliderNumber"].ToString(),
                            CarsNumber = Convert.ToString(dr["CarsNumber"]),
                            Additional_info = dr["Additional_info"] is DBNull ? "" : dr["Additional_info"].ToString(),
                            UserID = Convert.ToInt32(dr["UserID"])
                        });
                    }
                }
                return FFstations;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public FFstationsCollection FFstations_Select_By_ZoneNumber(string username, string password, string ZoneNumber)
        {
            try
            {
                FFstationsCollection FFstations = new FFstationsCollection();
                DateTime temp_date = new DateTime(0000 - 00 - 00);
                object[,] sp_params = new object[,]
                {
                    {"@username", username},
                    {"@password", password},
                    {"@ZoneNumber",ZoneNumber }
                };

                DataTable dt = db.Execute_Stored_Procedure_Show_Values("FFstations_Select_By_ZoneNumber", sp_params);

                if (dt.Rows.Count.Equals(0))
                {
                    return null;
                }
                else
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        FFstations.Add(new FFstations
                        {
                            FF_ID = Convert.ToInt32(dr["FF_ID"]),
                            Sector = Convert.ToString(dr["Sector"]),
                            AreaName = Convert.ToString(dr["AreaName"]),
                            Equipments = Convert.ToString(dr["Equipments"]),
                            Street = Convert.ToString(dr["Street"]),
                            ZoneNumber = Convert.ToString(dr["ZoneNumber"]),
                            Signs = dr["Signs"].ToString(),
                            OfficersNumber = dr["OfficersNumber"].ToString(),
                            SoliderNumber = dr["SoliderNumber"].ToString(),
                            CarsNumber = Convert.ToString(dr["CarsNumber"]),
                            Additional_info = dr["Additional_info"] is DBNull ? "" : dr["Additional_info"].ToString(),
                            UserID = Convert.ToInt32(dr["UserID"])
                        });
                    }
                }
                return FFstations;
            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
}