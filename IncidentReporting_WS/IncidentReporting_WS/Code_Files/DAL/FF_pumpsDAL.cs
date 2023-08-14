using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IncidentReporting_WS.Code_Files.ENL;
using IncidentReporting_WS.Code_Files.COL;
using System.Data;

namespace IncidentReporting_WS.Code_Files.DAL
{
    public class FF_pumpsDAL
    {
        DBL.DBL db = new DBL.DBL();
        public bool FF_pumps_Delete(string username, string password, int FF_pumpsID)
        {
            try
            {
                object[,] sp_Params = new object[,]
                {
                    {"@username", username},
                    {"@password", password},
                    {"@FF_pumpsID", FF_pumpsID}
                };
                bool flag = db.Execute_Update_Delete_Stored_Procedure("FF_pumps_Delete", sp_Params);
                return flag;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool FF_pumps_Update(string username, string password, FF_pumps FF_pumps)
        {
            try
            {
                object[,] sp_params = new object[,]
               {
                    {"@username", username},
                    {"@password", password},
                    {"@Sector", FF_pumps.Sector },
                    {"@Address", FF_pumps.Address},
                    {"@PumpNumber",FF_pumps.PumpNumber},
                    {"@PumpType",FF_pumps.PumpType },
                    {"@Signs",FF_pumps.Signs },
                    {"@Status",FF_pumps.Status },
                    {"@Area",FF_pumps.Area},
                    {"@Additional_info",FF_pumps.Additional_info },
                    {"@UserID",FF_pumps.UserID }
               };
                bool flag = db.Execute_Update_Delete_Stored_Procedure("FF_pumps_Update", sp_params);
                return flag;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public FF_pumps FF_pumps_Insert(string username, string password, FF_pumps FF_pumps)
        {
            try
            {
                bool flag = false;
                object[,] sp_params = new object[,]
               {
                    {"@username", username},
                    {"@password", password},
                    {"@Sector", FF_pumps.Sector },
                    {"@Address", FF_pumps.Address},
                    {"@PumpNumber",FF_pumps.PumpNumber},
                    {"@PumpType",FF_pumps.PumpType },
                    {"@Signs",FF_pumps.Signs },
                    {"@Status",FF_pumps.Status },
                    {"@Area",FF_pumps.Area},
                    {"@Additional_info",FF_pumps.Additional_info },
                    {"@UserID",FF_pumps.UserID }
               };

                FF_pumps.FF_pumpsID = db.Execute_Insert_Stored_Procedure("FF_pumps_Insert", sp_params);
                if (FF_pumps.FF_pumpsID > 0)
                {
                    return FF_pumps;
                }

                return null;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public FF_pumpsCollection FF_pumps_Select_All(string username, string password)
        {
            try
            {
                FF_pumpsCollection FF_pumps = new FF_pumpsCollection();
                DateTime temp_date = new DateTime(0000 - 00 - 00);
                object[,] sp_params = new object[,]
                {
                    {"@username", username},
                    {"@password", password}
                };

                DataTable dt = db.Execute_Stored_Procedure_Show_Values("FF_pumps_Select_All", sp_params);

                if (dt.Rows.Count.Equals(0))
                {
                    return null;
                }
                else
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        FF_pumps.Add(new FF_pumps
                        {
                            FF_pumpsID = Convert.ToInt32(dr["FF_pumpsID"]),
                            Sector = Convert.ToString(dr["Sector"]),
                            Address = Convert.ToString(dr["Address"]),
                            PumpNumber = Convert.ToString(dr["PumpNumber"]),
                            PumpType = Convert.ToString(dr["PumpType"]),
                            Signs = Convert.ToString(dr["Signs"]),
                            Status = dr["Status"].ToString(),
                            Area = dr["Area"].ToString(),
                            Additional_info = dr["Additional_info"] is DBNull ? "" : dr["Additional_info"].ToString(),
                            UserID = Convert.ToInt32(dr["UserID"])
                        });
                    }
                }
                return FF_pumps;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public FF_pumpsCollection FF_pumps_Select_By_Address(string username, string password, string Address)
        {
            try
            {
                FF_pumpsCollection FF_pumps = new FF_pumpsCollection();
                DateTime temp_date = new DateTime(0000 - 00 - 00);
                object[,] sp_params = new object[,]
                {
                    {"@username", username},
                    {"@password", password},
                    {"@Address",Address }
                };

                DataTable dt = db.Execute_Stored_Procedure_Show_Values("FF_pumps_Select_By_Address", sp_params);

                if (dt.Rows.Count.Equals(0))
                {
                    return null;
                }
                else
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        FF_pumps.Add(new FF_pumps
                        {
                            FF_pumpsID = Convert.ToInt32(dr["FF_pumpsID"]),
                            Sector = Convert.ToString(dr["Sector"]),
                            Address = Convert.ToString(dr["Address"]),
                            PumpNumber = Convert.ToString(dr["PumpNumber"]),
                            PumpType = Convert.ToString(dr["PumpType"]),
                            Signs = Convert.ToString(dr["Signs"]),
                            Status = dr["Status"].ToString(),
                            Area = dr["Area"].ToString(),
                            Additional_info = dr["Additional_info"] is DBNull ? "" : dr["Additional_info"].ToString(),
                            UserID = Convert.ToInt32(dr["UserID"])
                        });
                    }
                }
                return FF_pumps;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public FF_pumpsCollection FF_pumps_Select_By_Area(string username, string password, string Area)
        {
            try
            {
                FF_pumpsCollection FF_pumps = new FF_pumpsCollection();
                DateTime temp_date = new DateTime(0000 - 00 - 00);
                object[,] sp_params = new object[,]
                {
                    {"@username", username},
                    {"@password", password},
                    {"@Area",Area }
                };

                DataTable dt = db.Execute_Stored_Procedure_Show_Values("FF_pumps_Select_By_Area", sp_params);

                if (dt.Rows.Count.Equals(0))
                {
                    return null;
                }
                else
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        FF_pumps.Add(new FF_pumps
                        {
                            FF_pumpsID = Convert.ToInt32(dr["FF_pumpsID"]),
                            Sector = Convert.ToString(dr["Sector"]),
                            Address = Convert.ToString(dr["Address"]),
                            PumpNumber = Convert.ToString(dr["PumpNumber"]),
                            PumpType = Convert.ToString(dr["PumpType"]),
                            Signs = Convert.ToString(dr["Signs"]),
                            Status = dr["Status"].ToString(),
                            Area = dr["Area"].ToString(),
                            Additional_info = dr["Additional_info"] is DBNull ? "" : dr["Additional_info"].ToString(),
                            UserID = Convert.ToInt32(dr["UserID"])
                        });
                    }
                }
                return FF_pumps;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public FF_pumpsCollection FF_pumps_Select_By_FF_pumpsID(string username, string password, int FF_pumpsID)
        {
            try
            {
                FF_pumpsCollection FF_pumps = new FF_pumpsCollection();
                DateTime temp_date = new DateTime(0000 - 00 - 00);
                object[,] sp_params = new object[,]
                {
                    {"@username", username},
                    {"@password", password},
                    {"@FF_pumpsID",FF_pumpsID }
                };

                DataTable dt = db.Execute_Stored_Procedure_Show_Values("FF_pumps_Select_By_FF_pumpsID", sp_params);

                if (dt.Rows.Count.Equals(0))
                {
                    return null;
                }
                else
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        FF_pumps.Add(new FF_pumps
                        {
                            FF_pumpsID = Convert.ToInt32(dr["FF_pumpsID"]),
                            Sector = Convert.ToString(dr["Sector"]),
                            Address = Convert.ToString(dr["Address"]),
                            PumpNumber = Convert.ToString(dr["PumpNumber"]),
                            PumpType = Convert.ToString(dr["PumpType"]),
                            Signs = Convert.ToString(dr["Signs"]),
                            Status = dr["Status"].ToString(),
                            Area = dr["Area"].ToString(),
                            Additional_info = dr["Additional_info"] is DBNull ? "" : dr["Additional_info"].ToString(),
                            UserID = Convert.ToInt32(dr["UserID"])
                        });
                    }
                }
                return FF_pumps;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public FF_pumpsCollection FF_pumps_Select_By_PumpNumber(string username, string password, string PumpNumber)
        {
            try
            {
                FF_pumpsCollection FF_pumps = new FF_pumpsCollection();
                DateTime temp_date = new DateTime(0000 - 00 - 00);
                object[,] sp_params = new object[,]
                {
                    {"@username", username},
                    {"@password", password},
                    {"@PumpNumber",PumpNumber }
                };

                DataTable dt = db.Execute_Stored_Procedure_Show_Values("FF_pumps_Select_By_PumpNumber", sp_params);

                if (dt.Rows.Count.Equals(0))
                {
                    return null;
                }
                else
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        FF_pumps.Add(new FF_pumps
                        {
                            FF_pumpsID = Convert.ToInt32(dr["FF_pumpsID"]),
                            Sector = Convert.ToString(dr["Sector"]),
                            Address = Convert.ToString(dr["Address"]),
                            PumpNumber = Convert.ToString(dr["PumpNumber"]),
                            PumpType = Convert.ToString(dr["PumpType"]),
                            Signs = Convert.ToString(dr["Signs"]),
                            Status = dr["Status"].ToString(),
                            Area = dr["Area"].ToString(),
                            Additional_info = dr["Additional_info"] is DBNull ? "" : dr["Additional_info"].ToString(),
                            UserID = Convert.ToInt32(dr["UserID"])
                        });
                    }
                }
                return FF_pumps;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public FF_pumpsCollection FF_pumps_Select_By_Sector(string username, string password, string Sector)
        {
            try
            {
                FF_pumpsCollection FF_pumps = new FF_pumpsCollection();
                DateTime temp_date = new DateTime(0000 - 00 - 00);
                object[,] sp_params = new object[,]
                {
                    {"@username", username},
                    {"@password", password},
                    {"@Sector",Sector }
                };

                DataTable dt = db.Execute_Stored_Procedure_Show_Values("FF_pumps_Select_By_Sector", sp_params);

                if (dt.Rows.Count.Equals(0))
                {
                    return null;
                }
                else
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        FF_pumps.Add(new FF_pumps
                        {
                            FF_pumpsID = Convert.ToInt32(dr["FF_pumpsID"]),
                            Sector = Convert.ToString(dr["Sector"]),
                            Address = Convert.ToString(dr["Address"]),
                            PumpNumber = Convert.ToString(dr["PumpNumber"]),
                            PumpType = Convert.ToString(dr["PumpType"]),
                            Signs = Convert.ToString(dr["Signs"]),
                            Status = dr["Status"].ToString(),
                            Area = dr["Area"].ToString(),
                            Additional_info = dr["Additional_info"] is DBNull ? "" : dr["Additional_info"].ToString(),
                            UserID = Convert.ToInt32(dr["UserID"])
                        });
                    }
                }
                return FF_pumps;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public FF_pumpsCollection FF_pumps_Select_By_Signs(string username, string password, string Signs)
        {
            try
            {
                FF_pumpsCollection FF_pumps = new FF_pumpsCollection();
                DateTime temp_date = new DateTime(0000 - 00 - 00);
                object[,] sp_params = new object[,]
                {
                    {"@username", username},
                    {"@password", password},
                    {"@Signs",Signs }
                };

                DataTable dt = db.Execute_Stored_Procedure_Show_Values("FF_pumps_Select_By_Signs", sp_params);

                if (dt.Rows.Count.Equals(0))
                {
                    return null;
                }
                else
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        FF_pumps.Add(new FF_pumps
                        {
                            FF_pumpsID = Convert.ToInt32(dr["FF_pumpsID"]),
                            Sector = Convert.ToString(dr["Sector"]),
                            Address = Convert.ToString(dr["Address"]),
                            PumpNumber = Convert.ToString(dr["PumpNumber"]),
                            PumpType = Convert.ToString(dr["PumpType"]),
                            Signs = Convert.ToString(dr["Signs"]),
                            Status = dr["Status"].ToString(),
                            Area = dr["Area"].ToString(),
                            Additional_info = dr["Additional_info"] is DBNull ? "" : dr["Additional_info"].ToString(),
                            UserID = Convert.ToInt32(dr["UserID"])
                        });
                    }
                }
                return FF_pumps;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public FF_pumpsCollection FF_pumps_Select_By_Status(string username, string password, string Status)
        {
            try
            {
                FF_pumpsCollection FF_pumps = new FF_pumpsCollection();
                DateTime temp_date = new DateTime(0000 - 00 - 00);
                object[,] sp_params = new object[,]
                {
                    {"@username", username},
                    {"@password", password},
                    {"@Status",Status }
                };

                DataTable dt = db.Execute_Stored_Procedure_Show_Values("FF_pumps_Select_By_Status", sp_params);

                if (dt.Rows.Count.Equals(0))
                {
                    return null;
                }
                else
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        FF_pumps.Add(new FF_pumps
                        {
                            FF_pumpsID = Convert.ToInt32(dr["FF_pumpsID"]),
                            Sector = Convert.ToString(dr["Sector"]),
                            Address = Convert.ToString(dr["Address"]),
                            PumpNumber = Convert.ToString(dr["PumpNumber"]),
                            PumpType = Convert.ToString(dr["PumpType"]),
                            Signs = Convert.ToString(dr["Signs"]),
                            Status = dr["Status"].ToString(),
                            Area = dr["Area"].ToString(),
                            Additional_info = dr["Additional_info"] is DBNull ? "" : dr["Additional_info"].ToString(),
                            UserID = Convert.ToInt32(dr["UserID"])
                        });
                    }
                }
                return FF_pumps;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public FF_pumpsCollection FF_pumps_Select_By_UserID(string username, string password, int UserID)
        {
            try
            {
                FF_pumpsCollection FF_pumps = new FF_pumpsCollection();
                DateTime temp_date = new DateTime(0000 - 00 - 00);
                object[,] sp_params = new object[,]
                {
                    {"@username", username},
                    {"@password", password},
                    {"@UserID",UserID }
                };

                DataTable dt = db.Execute_Stored_Procedure_Show_Values("FF_pumps_Select_By_UserID", sp_params);

                if (dt.Rows.Count.Equals(0))
                {
                    return null;
                }
                else
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        FF_pumps.Add(new FF_pumps
                        {
                            FF_pumpsID = Convert.ToInt32(dr["FF_pumpsID"]),
                            Sector = Convert.ToString(dr["Sector"]),
                            Address = Convert.ToString(dr["Address"]),
                            PumpNumber = Convert.ToString(dr["PumpNumber"]),
                            PumpType = Convert.ToString(dr["PumpType"]),
                            Signs = Convert.ToString(dr["Signs"]),
                            Status = dr["Status"].ToString(),
                            Area = dr["Area"].ToString(),
                            Additional_info = dr["Additional_info"] is DBNull ? "" : dr["Additional_info"].ToString(),
                            UserID = Convert.ToInt32(dr["UserID"])
                        });
                    }
                }
                return FF_pumps;
            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
}