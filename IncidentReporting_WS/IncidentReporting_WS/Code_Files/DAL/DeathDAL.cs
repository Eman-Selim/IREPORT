using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IncidentReporting_WS.Code_Files.ENL;
using IncidentReporting_WS.Code_Files.COL;
using System.Data;

namespace IncidentReporting_WS.Code_Files.DAL
{
    public class DeathDAL
    {
        DBL.DBL db = new DBL.DBL();
        public bool Death_Delete(string username, string password, int DeathID)
        {
            try
            {
                object[,] sp_Params = new object[,]
                {
                    {"@username", username},
                    {"@password", password},
                    {"@DeathID", DeathID}
                };
                bool flag = db.Execute_Update_Delete_Stored_Procedure("Death_Delete", sp_Params);
                return flag;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public Death Death_Insert(string username, string password, Death death)
        {
            try
            {
                bool flag = false;
                object[,] sp_params = new object[,]
               {
                    {"@username", username},
                    {"@password", password},
                    {"@Name",death.Name },
                    {"@Age", death.Age},
                                            {"@Civil_Military",death.Civil_Military},
                    {"@Rank",death.Rank},
                    {"@Date",death.Date},
                    {"@Additional_info",death.Additional_info },
                    {"@AccidentID",death.AccidentID }

               };

                death.DeathID = db.Execute_Insert_Stored_Procedure("Death_Insert", sp_params);
                if (death.DeathID > 0)
                {
                    return death;
                }

                return null;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public DeathCollection Death_Select_All(string username, string password)
        {
            try
            {
                DeathCollection death = new DeathCollection();
                DateTime temp_date = new DateTime(0000 - 00 - 00);
                object[,] sp_params = new object[,]
                {
                    {"@username", username},
                    {"@password", password}
                };

                DataTable dt = db.Execute_Stored_Procedure_Show_Values("Death_Select_All", sp_params);

                if (dt.Rows.Count.Equals(0))
                {
                    return null;
                }
                else
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        death.Add(new Death
                        {
                            DeathID = Convert.ToInt32(dr["AccidentID"]),
                            Name= Convert.ToString(dr["Name"]),
                            Age = Convert.ToInt32(dr["Age"]),
                            Civil_Military = Convert.ToString(dr["Civil_Military"]),
                            Rank = Convert.ToString(dr["Rank"]),
                            Date = dr["Date"] is DBNull ? DateTime.Now : DateTime.Parse(dr["Date"].ToString()),
                            Additional_info = dr["Additional_info"] is DBNull ? "" : dr["Additional_info"].ToString(),
                            AccidentID = Convert.ToInt32(dr["AccidentID"])
                        });
                    }
                }
                return death;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public DeathCollection Death_Select_By_AccidentID(string username, string password, int AccidentID)
        {
            try
            {
                DeathCollection death = new DeathCollection();
                DateTime temp_date = new DateTime(0000 - 00 - 00);
                object[,] sp_params = new object[,]
                {
                    {"@username", username},
                    {"@password", password},
                    {"@AccidentID", AccidentID }
                };

                DataTable dt = db.Execute_Stored_Procedure_Show_Values("Death_Select_By_AccidentID", sp_params);

                if (dt.Rows.Count.Equals(0))
                {
                    return null;
                }
                else
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        death.Add(new Death
                        {
                            DeathID = Convert.ToInt32(dr["AccidentID"]),
                            Name = Convert.ToString(dr["Name"]),
                            Age = Convert.ToInt32(dr["Age"]),
                            Civil_Military = Convert.ToString(dr["Civil_Military"]),
                            Rank = Convert.ToString(dr["Rank"]),
                            Date = dr["Date"] is DBNull ? DateTime.Now : DateTime.Parse(dr["Date"].ToString()),
                            Additional_info = dr["Additional_info"] is DBNull ? "" : dr["Additional_info"].ToString(),
                            AccidentID = Convert.ToInt32(dr["AccidentID"])
                        });
                    }
                }
                return death;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public DeathCollection Death_Select_By_Age(string username, string password, int Age)
        {
            try
            {
                DeathCollection death = new DeathCollection();
                DateTime temp_date = new DateTime(0000 - 00 - 00);
                object[,] sp_params = new object[,]
                {
                    {"@username", username},
                    {"@password", password},
                    {"@Age", Age }
                };

                DataTable dt = db.Execute_Stored_Procedure_Show_Values("Death_Select_By_Age", sp_params);

                if (dt.Rows.Count.Equals(0))
                {
                    return null;
                }
                else
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        death.Add(new Death
                        {
                            DeathID = Convert.ToInt32(dr["AccidentID"]),
                            Name = Convert.ToString(dr["Name"]),
                            Age = Convert.ToInt32(dr["Age"]),
                            Civil_Military = Convert.ToString(dr["Civil_Military"]),
                            Rank = Convert.ToString(dr["Rank"]),
                            Date = dr["Date"] is DBNull ? DateTime.Now : DateTime.Parse(dr["Date"].ToString()),
                            Additional_info = dr["Additional_info"] is DBNull ? "" : dr["Additional_info"].ToString(),
                            AccidentID = Convert.ToInt32(dr["AccidentID"])
                        });
                    }
                }
                return death;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public DeathCollection Death_Select_By_Civil_Military(string username, string password, string Civil_Military)
        {
            try
            {
                DeathCollection death = new DeathCollection();
                DateTime temp_date = new DateTime(0000 - 00 - 00);
                object[,] sp_params = new object[,]
                {
                    {"@username", username},
                    {"@password", password},
                    {"@Civil_Military", Civil_Military }
                };

                DataTable dt = db.Execute_Stored_Procedure_Show_Values("Death_Select_By_Civil_Military", sp_params);

                if (dt.Rows.Count.Equals(0))
                {
                    return null;
                }
                else
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        death.Add(new Death
                        {
                            DeathID = Convert.ToInt32(dr["AccidentID"]),
                            Name = Convert.ToString(dr["Name"]),
                            Age = Convert.ToInt32(dr["Age"]),
                            Civil_Military = Convert.ToString(dr["Civil_Military"]),
                            Rank = Convert.ToString(dr["Rank"]),
                            Date = dr["Date"] is DBNull ? DateTime.Now : DateTime.Parse(dr["Date"].ToString()),
                            Additional_info = dr["Additional_info"] is DBNull ? "" : dr["Additional_info"].ToString(),
                            AccidentID = Convert.ToInt32(dr["AccidentID"])
                        });
                    }
                }
                return death;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public DeathCollection Death_Select_By_Date(string username, string password, DateTime Date)
        {
            try
            {
                DeathCollection death = new DeathCollection();
                DateTime temp_date = new DateTime(0000 - 00 - 00);
                object[,] sp_params = new object[,]
                {
                    {"@username", username},
                    {"@password", password},
                    {"@Date", Date }
                };

                DataTable dt = db.Execute_Stored_Procedure_Show_Values("Death_Select_By_Date", sp_params);

                if (dt.Rows.Count.Equals(0))
                {
                    return null;
                }
                else
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        death.Add(new Death
                        {
                            DeathID = Convert.ToInt32(dr["AccidentID"]),
                            Name = Convert.ToString(dr["Name"]),
                            Age = Convert.ToInt32(dr["Age"]),
                            Civil_Military = Convert.ToString(dr["Civil_Military"]),
                            Rank = Convert.ToString(dr["Rank"]),
                            Date = dr["Date"] is DBNull ? DateTime.Now : DateTime.Parse(dr["Date"].ToString()),
                            Additional_info = dr["Additional_info"] is DBNull ? "" : dr["Additional_info"].ToString(),
                            AccidentID = Convert.ToInt32(dr["AccidentID"])
                        });
                    }
                }
                return death;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public DeathCollection Death_Select_By_DeathID(string username, string password, int DeathID)
        {
            try
            {
                DeathCollection death = new DeathCollection();
                DateTime temp_date = new DateTime(0000 - 00 - 00);
                object[,] sp_params = new object[,]
                {
                    {"@username", username},
                    {"@password", password},
                    {"@DeathID", DeathID }
                };

                DataTable dt = db.Execute_Stored_Procedure_Show_Values("Death_Select_By_DeathID", sp_params);

                if (dt.Rows.Count.Equals(0))
                {
                    return null;
                }
                else
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        death.Add(new Death
                        {
                            DeathID = Convert.ToInt32(dr["AccidentID"]),
                            Name = Convert.ToString(dr["Name"]),
                            Age = Convert.ToInt32(dr["Age"]),
                            Civil_Military = Convert.ToString(dr["Civil_Military"]),
                            Rank = Convert.ToString(dr["Rank"]),
                            Date = dr["Date"] is DBNull ? DateTime.Now : DateTime.Parse(dr["Date"].ToString()),
                            Additional_info = dr["Additional_info"] is DBNull ? "" : dr["Additional_info"].ToString(),
                            AccidentID = Convert.ToInt32(dr["AccidentID"])
                        });
                    }
                }
                return death;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public DeathCollection Death_Select_By_Name(string username, string password, string Name)
        {
            try
            {
                DeathCollection death = new DeathCollection();
                DateTime temp_date = new DateTime(0000 - 00 - 00);
                object[,] sp_params = new object[,]
                {
                    {"@username", username},
                    {"@password", password},
                    {"@Name", Name }
                };

                DataTable dt = db.Execute_Stored_Procedure_Show_Values("Death_Select_By_Name", sp_params);

                if (dt.Rows.Count.Equals(0))
                {
                    return null;
                }
                else
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        death.Add(new Death
                        {
                            DeathID = Convert.ToInt32(dr["AccidentID"]),
                            Name = Convert.ToString(dr["Name"]),
                            Age = Convert.ToInt32(dr["Age"]),
                            Civil_Military = Convert.ToString(dr["Civil_Military"]),
                            Rank = Convert.ToString(dr["Rank"]),
                            Date = dr["Date"] is DBNull ? DateTime.Now : DateTime.Parse(dr["Date"].ToString()),
                            Additional_info = dr["Additional_info"] is DBNull ? "" : dr["Additional_info"].ToString(),
                            AccidentID = Convert.ToInt32(dr["AccidentID"])
                        });
                    }
                }
                return death;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public DeathCollection Death_Select_By_Rank(string username, string password, string Rank)
        {
            try
            {
                DeathCollection death = new DeathCollection();
                DateTime temp_date = new DateTime(0000 - 00 - 00);
                object[,] sp_params = new object[,]
                {
                    {"@username", username},
                    {"@password", password},
                    {"@Rank", Rank }
                };

                DataTable dt = db.Execute_Stored_Procedure_Show_Values("Death_Select_By_Rank", sp_params);

                if (dt.Rows.Count.Equals(0))
                {
                    return null;
                }
                else
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        death.Add(new Death
                        {
                            DeathID = Convert.ToInt32(dr["AccidentID"]),
                            Name = Convert.ToString(dr["Name"]),
                            Age = Convert.ToInt32(dr["Age"]),
                            Civil_Military = Convert.ToString(dr["Civil_Military"]),
                            Rank = Convert.ToString(dr["Rank"]),
                            Date = dr["Date"] is DBNull ? DateTime.Now : DateTime.Parse(dr["Date"].ToString()),
                            Additional_info = dr["Additional_info"] is DBNull ? "" : dr["Additional_info"].ToString(),
                            AccidentID = Convert.ToInt32(dr["AccidentID"])
                        });
                    }
                }
                return death;
            }
            catch (Exception e)
            {
                return null;
            }
        }

    }


}