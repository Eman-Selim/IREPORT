using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IncidentReporting_WS.Code_Files.ENL;
using IncidentReporting_WS.Code_Files.COL;
using System.Data;

namespace IncidentReporting_WS.Code_Files.DAL
{
    public class FF_ManPowerDAL
    {
        DBL.DBL db = new DBL.DBL();

        public bool FF_ManPower_Delete(string username, string password, int FF_ManPowerID)
        {
            try
            {
                object[,] sp_Params = new object[,]
                {
                    {"@username", username},
                    {"@password", password},
                    {"@FF_ManPowerID", FF_ManPowerID}
                };
                bool flag = db.Execute_Update_Delete_Stored_Procedure("FF_ManPower_Delete", sp_Params);
                return flag;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool FF_ManPower_DeleteAll(string username, string password, int FF_ID)
        {
            try
            {
                object[,] sp_Params = new object[,]
                {
                    {"@username", username},
                    {"@password", password},
                    {"@FF_ID", FF_ID}
                };
                bool flag = db.Execute_Update_Delete_Stored_Procedure("FF_ManPower_DeleteAll", sp_Params);
                return flag;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool FF_ManPower_Update(string username, string password, FF_ManPower ManPower)
        {
            try
            {
                object[,] sp_params = new object[,]
                 {
                    {"@username", username},
                    {"@password", password},
                    {"@Sector", ManPower.Sector },
                    {"@Area", ManPower.Area},
                    {"@Point",ManPower.Point},
                    {"@OfficerName",ManPower.OfficerName},
                    {"@Rank",ManPower.Rank},
                    {"@TimeSlot",ManPower.TimeSlot},
                    {"@Availability",ManPower.Availability},
                    {"@Job",ManPower.Job},
                    {"@Additional_info",ManPower.Additional_info},
                    {"@UserID",ManPower.UserID},
                    {"@FF_ManPowerID",ManPower.FF_ManPowerID },
                    {"@FF_ID", ManPower.FF_ID }

                 };
                bool flag = db.Execute_Update_Delete_Stored_Procedure("FF_ManPower_Update", sp_params);
                return flag;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public FF_ManPower FF_ManPower_Insert(string username, string password, FF_ManPower ManPower)
        {
            try
            {
                bool flag = false;
                object[,] sp_params = new object[,]
               {
                    {"@username", username},
                    {"@password", password},
                    {"@Sector", ManPower.Sector },
                    {"@Area", ManPower.Area},
                    {"@Point",ManPower.Point},
                    {"@OfficerName",ManPower.OfficerName},
                    {"@Rank",ManPower.Rank},
                    {"@TimeSlot",ManPower.TimeSlot},
                    {"@Availability",ManPower.Availability},
                    {"@Job",ManPower.Job},
                    {"@Additional_info",ManPower.Additional_info},
                    {"@UserID",ManPower.UserID},
                    {"@FF_ID", ManPower.FF_ID }

               };
                ManPower.FF_ManPowerID = db.Execute_Insert_Stored_Procedure("FF_ManPower_Insert", sp_params);
                if (ManPower.FF_ManPowerID > 0)
                {
                    return ManPower;
                }

                return null;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public FF_ManPowerCollection FF_ManPower_Select_All(string username, string password)
        {
            try
            {
                FF_ManPowerCollection FF_ManPower = new FF_ManPowerCollection();
                DateTime temp_date = new DateTime(0000 - 00 - 00);
                object[,] sp_params = new object[,]
                {
                    {"@username", username},
                    {"@password", password}
                };

                DataTable dt = db.Execute_Stored_Procedure_Show_Values("FF_ManPower_Select_All", sp_params);

                if (dt.Rows.Count.Equals(0))
                {
                    return null;
                }
                else
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        FF_ManPower.Add(new FF_ManPower
                        {
                            FF_ManPowerID = dr["FF_ManPowerID"] is DBNull ? -1 : Convert.ToInt32(dr["FF_ManPowerID"]),
                            Sector = dr["Sector"] is DBNull ? "" : Convert.ToString(dr["Sector"]),
                            Area = dr["Area"] is DBNull ? "" : Convert.ToString(dr["Area"]),
                            Point = dr["Point"] is DBNull ? "" : Convert.ToString(dr["Point"]),
                            OfficerName = dr["OfficerName"] is DBNull ? "" : Convert.ToString(dr["OfficerName"]),
                            Rank = dr["Rank"] is DBNull ? "" : Convert.ToString(dr["Rank"]),
                            TimeSlot = dr["TimeSlot"] is DBNull ? "" : dr["TimeSlot"].ToString(),
                            Availability = dr["Availability"] is DBNull ? "" : dr["Availability"].ToString(),
                            Job = dr["Job"] is DBNull ? "" : dr["Job"].ToString(),
                            Additional_info = dr["Additional_info"] is DBNull ? "" : dr["Additional_info"].ToString(),
                            UserID = dr["UserID"] is DBNull ? -1 : Convert.ToInt32(dr["UserID"]),
                            FF_ID = dr["FF_ID"] is DBNull ? -1 : Convert.ToInt32(dr["FF_ID"])
                        });
                    }
                }
                return FF_ManPower;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public FF_ManPowerCollection FF_ManPower_Select_By_Area(string username, string password, string Area)
        {
            try
            {
                FF_ManPowerCollection FF_ManPower = new FF_ManPowerCollection();
                DateTime temp_date = new DateTime(0000 - 00 - 00);
                object[,] sp_params = new object[,]
                {
                    {"@username", username},
                    {"@password", password},
                    {"@Area",Area}
                };

                DataTable dt = db.Execute_Stored_Procedure_Show_Values("FF_ManPower_Select_By_Area", sp_params);

                if (dt.Rows.Count.Equals(0))
                {
                    return null;
                }
                else
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        FF_ManPower.Add(new FF_ManPower
                        {
                            FF_ManPowerID = dr["FF_ManPowerID"] is DBNull ? -1 : Convert.ToInt32(dr["FF_ManPowerID"]),
                            Sector = dr["Sector"] is DBNull ? "" : Convert.ToString(dr["Sector"]),
                            Area = dr["Area"] is DBNull ? "" : Convert.ToString(dr["Area"]),
                            Point = dr["Point"] is DBNull ? "" : Convert.ToString(dr["Point"]),
                            OfficerName = dr["OfficerName"] is DBNull ? "" : Convert.ToString(dr["OfficerName"]),
                            Rank = dr["Rank"] is DBNull ? "" : Convert.ToString(dr["Rank"]),
                            TimeSlot = dr["TimeSlot"] is DBNull ? "" : dr["TimeSlot"].ToString(),
                            Availability = dr["Availability"] is DBNull ? "" : dr["Availability"].ToString(),
                            Job = dr["Job"] is DBNull ? "" : dr["Job"].ToString(),
                            Additional_info = dr["Additional_info"] is DBNull ? "" : dr["Additional_info"].ToString(),
                            UserID = dr["UserID"] is DBNull ? -1 : Convert.ToInt32(dr["UserID"]),
                            FF_ID = dr["FF_ID"] is DBNull ? -1 : Convert.ToInt32(dr["FF_ID"])
                        });
                    }
                }
                return FF_ManPower;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public FF_ManPowerCollection FF_ManPower_Select_By_Availability(string username, string password, string Availability)
        {
            try
            {
                FF_ManPowerCollection FF_ManPower = new FF_ManPowerCollection();
                DateTime temp_date = new DateTime(0000 - 00 - 00);
                object[,] sp_params = new object[,]
                {
                    {"@username", username},
                    {"@password", password},
                    {"@Availability", Availability}
                };

                DataTable dt = db.Execute_Stored_Procedure_Show_Values("FF_ManPower_Select_By_Availability", sp_params);

                if (dt.Rows.Count.Equals(0))
                {
                    return null;
                }
                else
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        FF_ManPower.Add(new FF_ManPower
                        {
                            FF_ManPowerID = dr["FF_ManPowerID"] is DBNull ? -1 : Convert.ToInt32(dr["FF_ManPowerID"]),
                            Sector = dr["Sector"] is DBNull ? "" : Convert.ToString(dr["Sector"]),
                            Area = dr["Area"] is DBNull ? "" : Convert.ToString(dr["Area"]),
                            Point = dr["Point"] is DBNull ? "" : Convert.ToString(dr["Point"]),
                            OfficerName = dr["OfficerName"] is DBNull ? "" : Convert.ToString(dr["OfficerName"]),
                            Rank = dr["Rank"] is DBNull ? "" : Convert.ToString(dr["Rank"]),
                            TimeSlot = dr["TimeSlot"] is DBNull ? "" : dr["TimeSlot"].ToString(),
                            Availability = dr["Availability"] is DBNull ? "" : dr["Availability"].ToString(),
                            Job = dr["Job"] is DBNull ? "" : dr["Job"].ToString(),
                            Additional_info = dr["Additional_info"] is DBNull ? "" : dr["Additional_info"].ToString(),
                            UserID = dr["UserID"] is DBNull ? -1 : Convert.ToInt32(dr["UserID"]),
                            FF_ID = dr["FF_ID"] is DBNull ? -1 : Convert.ToInt32(dr["FF_ID"])
                        });
                    }
                }
                return FF_ManPower;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public FF_ManPower FF_ManPower_Select_By_FF_ManPowerID(string username, string password, int FF_ManPowerID)
        {
            try
            {
                FF_ManPower FF_ManPower = new FF_ManPower();
                DateTime temp_date = new DateTime(0000 - 00 - 00);
                object[,] sp_params = new object[,]
                {
                    {"@username", username},
                    {"@password", password},
                    {"@FF_ManPowerID", FF_ManPowerID}
                };

                DataTable dt = db.Execute_Stored_Procedure_Show_Values("FF_ManPower_Select_By_FF_ManPowerID", sp_params);

                if (dt.Rows.Count.Equals(0))
                {
                    return null;
                }
                else
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        FF_ManPower=new FF_ManPower
                        {
                            FF_ManPowerID = dr["FF_ManPowerID"] is DBNull ? -1 : Convert.ToInt32(dr["FF_ManPowerID"]),
                            Sector = dr["Sector"] is DBNull ? "" : Convert.ToString(dr["Sector"]),
                            Area = dr["Area"] is DBNull ? "" : Convert.ToString(dr["Area"]),
                            Point = dr["Point"] is DBNull ? "" : Convert.ToString(dr["Point"]),
                            OfficerName = dr["OfficerName"] is DBNull ? "" : Convert.ToString(dr["OfficerName"]),
                            Rank = dr["Rank"] is DBNull ? "" : Convert.ToString(dr["Rank"]),
                            TimeSlot = dr["TimeSlot"] is DBNull ? "" : dr["TimeSlot"].ToString(),
                            Availability = dr["Availability"] is DBNull ? "" : dr["Availability"].ToString(),
                            Job = dr["Job"] is DBNull ? "" : dr["Job"].ToString(),
                            Additional_info = dr["Additional_info"] is DBNull ? "" : dr["Additional_info"].ToString(),
                            UserID = dr["UserID"] is DBNull ? -1 : Convert.ToInt32(dr["UserID"]),
                            FF_ID = dr["FF_ID"] is DBNull ? -1 : Convert.ToInt32(dr["FF_ID"])
                        };
                    }
                }
                return FF_ManPower;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public FF_ManPowerCollection FF_ManPower_Select_By_Job(string username, string password, string Job)
        {
            try
            {
                FF_ManPowerCollection FF_ManPower = new FF_ManPowerCollection();
                DateTime temp_date = new DateTime(0000 - 00 - 00);
                object[,] sp_params = new object[,]
                {
                    {"@username", username},
                    {"@password", password},
                    {"@Job", Job}
                };

                DataTable dt = db.Execute_Stored_Procedure_Show_Values("FF_ManPower_Select_By_Job", sp_params);

                if (dt.Rows.Count.Equals(0))
                {
                    return null;
                }
                else
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        FF_ManPower.Add(new FF_ManPower
                        {
                            FF_ManPowerID = dr["FF_ManPowerID"] is DBNull ? -1 : Convert.ToInt32(dr["FF_ManPowerID"]),
                            Sector = dr["Sector"] is DBNull ? "" : Convert.ToString(dr["Sector"]),
                            Area = dr["Area"] is DBNull ? "" : Convert.ToString(dr["Area"]),
                            Point = dr["Point"] is DBNull ? "" : Convert.ToString(dr["Point"]),
                            OfficerName = dr["OfficerName"] is DBNull ? "" : Convert.ToString(dr["OfficerName"]),
                            Rank = dr["Rank"] is DBNull ? "" : Convert.ToString(dr["Rank"]),
                            TimeSlot = dr["TimeSlot"] is DBNull ? "" : dr["TimeSlot"].ToString(),
                            Availability = dr["Availability"] is DBNull ? "" : dr["Availability"].ToString(),
                            Job = dr["Job"] is DBNull ? "" : dr["Job"].ToString(),
                            Additional_info = dr["Additional_info"] is DBNull ? "" : dr["Additional_info"].ToString(),
                            UserID = dr["UserID"] is DBNull ? -1 : Convert.ToInt32(dr["UserID"]),
                            FF_ID = dr["FF_ID"] is DBNull ? -1 : Convert.ToInt32(dr["FF_ID"])
                        });
                    }
                }
                return FF_ManPower;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public FF_ManPowerCollection FF_ManPower_Select_By_OfficerName(string username, string password, string OfficerName)
        {
            try
            {
                FF_ManPowerCollection FF_ManPower = new FF_ManPowerCollection();
                DateTime temp_date = new DateTime(0000 - 00 - 00);
                object[,] sp_params = new object[,]
                {
                    {"@username", username},
                    {"@password", password},
                    {"@OfficerName", OfficerName}
                };

                DataTable dt = db.Execute_Stored_Procedure_Show_Values("FF_ManPower_Select_By_OfficerName", sp_params);

                if (dt.Rows.Count.Equals(0))
                {
                    return null;
                }
                else
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        FF_ManPower.Add(new FF_ManPower
                        {
                            FF_ManPowerID = dr["FF_ManPowerID"] is DBNull ? -1 : Convert.ToInt32(dr["FF_ManPowerID"]),
                            Sector = dr["Sector"] is DBNull ? "" : Convert.ToString(dr["Sector"]),
                            Area = dr["Area"] is DBNull ? "" : Convert.ToString(dr["Area"]),
                            Point = dr["Point"] is DBNull ? "" : Convert.ToString(dr["Point"]),
                            OfficerName = dr["OfficerName"] is DBNull ? "" : Convert.ToString(dr["OfficerName"]),
                            Rank = dr["Rank"] is DBNull ? "" : Convert.ToString(dr["Rank"]),
                            TimeSlot = dr["TimeSlot"] is DBNull ? "" : dr["TimeSlot"].ToString(),
                            Availability = dr["Availability"] is DBNull ? "" : dr["Availability"].ToString(),
                            Job = dr["Job"] is DBNull ? "" : dr["Job"].ToString(),
                            Additional_info = dr["Additional_info"] is DBNull ? "" : dr["Additional_info"].ToString(),
                            UserID = dr["UserID"] is DBNull ? -1 : Convert.ToInt32(dr["UserID"]),
                            FF_ID = dr["FF_ID"] is DBNull ? -1 : Convert.ToInt32(dr["FF_ID"])
                        });
                    }
                }
                return FF_ManPower;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public FF_ManPowerCollection FF_ManPower_Select_By_Point(string username, string password, string Point)
        {
            try
            {
                FF_ManPowerCollection FF_ManPower = new FF_ManPowerCollection();
                DateTime temp_date = new DateTime(0000 - 00 - 00);
                object[,] sp_params = new object[,]
                {
                    {"@username", username},
                    {"@password", password},
                    {"@Point", Point}
                };

                DataTable dt = db.Execute_Stored_Procedure_Show_Values("FF_ManPower_Select_By_Point", sp_params);

                if (dt.Rows.Count.Equals(0))
                {
                    return null;
                }
                else
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        FF_ManPower.Add(new FF_ManPower
                        {
                            FF_ManPowerID = dr["FF_ManPowerID"] is DBNull ? -1 : Convert.ToInt32(dr["FF_ManPowerID"]),
                            Sector = dr["Sector"] is DBNull ? "" : Convert.ToString(dr["Sector"]),
                            Area = dr["Area"] is DBNull ? "" : Convert.ToString(dr["Area"]),
                            Point = dr["Point"] is DBNull ? "" : Convert.ToString(dr["Point"]),
                            OfficerName = dr["OfficerName"] is DBNull ? "" : Convert.ToString(dr["OfficerName"]),
                            Rank = dr["Rank"] is DBNull ? "" : Convert.ToString(dr["Rank"]),
                            TimeSlot = dr["TimeSlot"] is DBNull ? "" : dr["TimeSlot"].ToString(),
                            Availability = dr["Availability"] is DBNull ? "" : dr["Availability"].ToString(),
                            Job = dr["Job"] is DBNull ? "" : dr["Job"].ToString(),
                            Additional_info = dr["Additional_info"] is DBNull ? "" : dr["Additional_info"].ToString(),
                            UserID = dr["UserID"] is DBNull ? -1 : Convert.ToInt32(dr["UserID"]),
                            FF_ID = dr["FF_ID"] is DBNull ? -1 : Convert.ToInt32(dr["FF_ID"])
                        });
                    }
                }
                return FF_ManPower;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public FF_ManPowerCollection FF_ManPower_Select_By_Rank(string username, string password, string Rank)
        {
            try
            {
                FF_ManPowerCollection FF_ManPower = new FF_ManPowerCollection();
                DateTime temp_date = new DateTime(0000 - 00 - 00);
                object[,] sp_params = new object[,]
                {
                    {"@username", username},
                    {"@password", password},
                    {"@Rank", Rank}
                };

                DataTable dt = db.Execute_Stored_Procedure_Show_Values("FF_ManPower_Select_By_Rank", sp_params);

                if (dt.Rows.Count.Equals(0))
                {
                    return null;
                }
                else
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        FF_ManPower.Add(new FF_ManPower
                        {
                            FF_ManPowerID = dr["FF_ManPowerID"] is DBNull ? -1 : Convert.ToInt32(dr["FF_ManPowerID"]),
                            Sector = dr["Sector"] is DBNull ? "" : Convert.ToString(dr["Sector"]),
                            Area = dr["Area"] is DBNull ? "" : Convert.ToString(dr["Area"]),
                            Point = dr["Point"] is DBNull ? "" : Convert.ToString(dr["Point"]),
                            OfficerName = dr["OfficerName"] is DBNull ? "" : Convert.ToString(dr["OfficerName"]),
                            Rank = dr["Rank"] is DBNull ? "" : Convert.ToString(dr["Rank"]),
                            TimeSlot = dr["TimeSlot"] is DBNull ? "" : dr["TimeSlot"].ToString(),
                            Availability = dr["Availability"] is DBNull ? "" : dr["Availability"].ToString(),
                            Job = dr["Job"] is DBNull ? "" : dr["Job"].ToString(),
                            Additional_info = dr["Additional_info"] is DBNull ? "" : dr["Additional_info"].ToString(),
                            UserID = dr["UserID"] is DBNull ? -1 : Convert.ToInt32(dr["UserID"]),
                            FF_ID = dr["FF_ID"] is DBNull ? -1 : Convert.ToInt32(dr["FF_ID"])
                        });
                    }
                }
                return FF_ManPower;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public FF_ManPowerCollection FF_ManPower_Select_By_Sector(string username, string password, string Sector)
        {
            try
            {
                FF_ManPowerCollection FF_ManPower = new FF_ManPowerCollection();
                DateTime temp_date = new DateTime(0000 - 00 - 00);
                object[,] sp_params = new object[,]
                {
                    {"@username", username},
                    {"@password", password},
                    {"@Sector", Sector}
                };

                DataTable dt = db.Execute_Stored_Procedure_Show_Values("FF_ManPower_Select_By_Sector", sp_params);

                if (dt.Rows.Count.Equals(0))
                {
                    return null;
                }
                else
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        FF_ManPower.Add(new FF_ManPower
                        {
                            FF_ManPowerID = dr["FF_ManPowerID"] is DBNull ? -1 : Convert.ToInt32(dr["FF_ManPowerID"]),
                            Sector = dr["Sector"] is DBNull ? "" : Convert.ToString(dr["Sector"]),
                            Area = dr["Area"] is DBNull ? "" : Convert.ToString(dr["Area"]),
                            Point = dr["Point"] is DBNull ? "" : Convert.ToString(dr["Point"]),
                            OfficerName = dr["OfficerName"] is DBNull ? "" : Convert.ToString(dr["OfficerName"]),
                            Rank = dr["Rank"] is DBNull ? "" : Convert.ToString(dr["Rank"]),
                            TimeSlot = dr["TimeSlot"] is DBNull ? "" : dr["TimeSlot"].ToString(),
                            Availability = dr["Availability"] is DBNull ? "" : dr["Availability"].ToString(),
                            Job = dr["Job"] is DBNull ? "" : dr["Job"].ToString(),
                            Additional_info = dr["Additional_info"] is DBNull ? "" : dr["Additional_info"].ToString(),
                            UserID = dr["UserID"] is DBNull ? -1 : Convert.ToInt32(dr["UserID"]),
                            FF_ID = dr["FF_ID"] is DBNull ? -1 : Convert.ToInt32(dr["FF_ID"])
                        });
                    }
                }
                return FF_ManPower;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public FF_ManPowerCollection FF_ManPower_Select_By_TimeSlot(string username, string password, string TimeSlot)
        {
            try
            {
                FF_ManPowerCollection FF_ManPower = new FF_ManPowerCollection();
                DateTime temp_date = new DateTime(0000 - 00 - 00);
                object[,] sp_params = new object[,]
                {
                    {"@username", username},
                    {"@password", password},
                    {"@TimeSlot", TimeSlot}
                };

                DataTable dt = db.Execute_Stored_Procedure_Show_Values("FF_ManPower_Select_By_TimeSlot", sp_params);

                if (dt.Rows.Count.Equals(0))
                {
                    return null;
                }
                else
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        FF_ManPower.Add(new FF_ManPower
                        {
                            FF_ManPowerID = dr["FF_ManPowerID"] is DBNull ? -1 : Convert.ToInt32(dr["FF_ManPowerID"]),
                            Sector = dr["Sector"] is DBNull ? "" : Convert.ToString(dr["Sector"]),
                            Area = dr["Area"] is DBNull ? "" : Convert.ToString(dr["Area"]),
                            Point = dr["Point"] is DBNull ? "" : Convert.ToString(dr["Point"]),
                            OfficerName = dr["OfficerName"] is DBNull ? "" : Convert.ToString(dr["OfficerName"]),
                            Rank = dr["Rank"] is DBNull ? "" : Convert.ToString(dr["Rank"]),
                            TimeSlot = dr["TimeSlot"] is DBNull ? "" : dr["TimeSlot"].ToString(),
                            Availability = dr["Availability"] is DBNull ? "" : dr["Availability"].ToString(),
                            Job = dr["Job"] is DBNull ? "" : dr["Job"].ToString(),
                            Additional_info = dr["Additional_info"] is DBNull ? "" : dr["Additional_info"].ToString(),
                            UserID = dr["UserID"] is DBNull ? -1 : Convert.ToInt32(dr["UserID"]),
                            FF_ID = dr["FF_ID"] is DBNull ? -1 : Convert.ToInt32(dr["FF_ID"])
                        });
                    }
                }
                return FF_ManPower;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public FF_ManPowerCollection FF_ManPower_Select_By_UserID(string username, string password, int UserID)
        {
            try
            {
                FF_ManPowerCollection FF_ManPower = new FF_ManPowerCollection();
                DateTime temp_date = new DateTime(0000 - 00 - 00);
                object[,] sp_params = new object[,]
                {
                    {"@username", username},
                    {"@password", password},
                    {"@UserID", UserID}
                };

                DataTable dt = db.Execute_Stored_Procedure_Show_Values("FF_ManPower_Select_By_UserID", sp_params);

                if (dt.Rows.Count.Equals(0))
                {
                    return null;
                }
                else
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        FF_ManPower.Add(new FF_ManPower
                        {
                            FF_ManPowerID = dr["FF_ManPowerID"] is DBNull ? -1 : Convert.ToInt32(dr["FF_ManPowerID"]),
                            Sector = dr["Sector"] is DBNull ? "" : Convert.ToString(dr["Sector"]),
                            Area = dr["Area"] is DBNull ? "" : Convert.ToString(dr["Area"]),
                            Point = dr["Point"] is DBNull ? "" : Convert.ToString(dr["Point"]),
                            OfficerName = dr["OfficerName"] is DBNull ? "" : Convert.ToString(dr["OfficerName"]),
                            Rank = dr["Rank"] is DBNull ? "" : Convert.ToString(dr["Rank"]),
                            TimeSlot = dr["TimeSlot"] is DBNull ? "" : dr["TimeSlot"].ToString(),
                            Availability = dr["Availability"] is DBNull ? "" : dr["Availability"].ToString(),
                            Job = dr["Job"] is DBNull ? "" : dr["Job"].ToString(),
                            Additional_info = dr["Additional_info"] is DBNull ? "" : dr["Additional_info"].ToString(),
                            UserID = dr["UserID"] is DBNull ? -1 : Convert.ToInt32(dr["UserID"]),
                            FF_ID = dr["FF_ID"] is DBNull ? -1 : Convert.ToInt32(dr["FF_ID"])
                        });
                    }
                }
                return FF_ManPower;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public FF_ManPowerCollection FF_ManPower_Select_By_FF_ID(string username, string password, int FF_ID)
        {
            try
            {
                FF_ManPowerCollection FF_ManPower = new FF_ManPowerCollection();
                DateTime temp_date = new DateTime(0000 - 00 - 00);
                object[,] sp_params = new object[,]
                {
                    {"@username", username},
                    {"@password", password},
                    {"@FF_ID", FF_ID}
                };

                DataTable dt = db.Execute_Stored_Procedure_Show_Values("FF_ManPower_Select_By_FF_ID", sp_params);

                if (dt.Rows.Count.Equals(0))
                {
                    return null;
                }
                else
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        FF_ManPower.Add(new FF_ManPower
                        {
                            FF_ManPowerID = dr["FF_ManPowerID"] is DBNull ? -1 : Convert.ToInt32(dr["FF_ManPowerID"]),
                            Sector = dr["Sector"] is DBNull ? "" : Convert.ToString(dr["Sector"]),
                            Area = dr["Area"] is DBNull ? "" : Convert.ToString(dr["Area"]),
                            Point = dr["Point"] is DBNull ? "" : Convert.ToString(dr["Point"]),
                            OfficerName = dr["OfficerName"] is DBNull ? "" : Convert.ToString(dr["OfficerName"]),
                            Rank = dr["Rank"] is DBNull ? "" : Convert.ToString(dr["Rank"]),
                            TimeSlot = dr["TimeSlot"] is DBNull ? "" : dr["TimeSlot"].ToString(),
                            Availability = dr["Availability"] is DBNull ? "" : dr["Availability"].ToString(),
                            Job = dr["Job"] is DBNull ? "" : dr["Job"].ToString(),
                            Additional_info = dr["Additional_info"] is DBNull ? "" : dr["Additional_info"].ToString(),
                            UserID = dr["UserID"] is DBNull ? -1 : Convert.ToInt32(dr["UserID"]),
                            FF_ID = dr["FF_ID"] is DBNull ? -1 : Convert.ToInt32(dr["FF_ID"])
                        });
                    }
                }
                return FF_ManPower;
            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
}