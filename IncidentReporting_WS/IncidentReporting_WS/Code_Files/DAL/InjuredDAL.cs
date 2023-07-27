using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IncidentReporting_WS.Code_Files.ENL;
using IncidentReporting_WS.Code_Files.COL;
using System.Data;

namespace IncidentReporting_WS.Code_Files.DAL
{
    public class InjuredDAL
    {
        DBL.DBL db = new DBL.DBL();

        public bool Injured_Delete(string username, string password, int InjuredID)
        {
            try
            {
                object[,] sp_Params = new object[,]
                {
                    {"@username", username},
                    {"@password", password},
                    {"@InjuredID", InjuredID}
                };
                bool flag = db.Execute_Update_Delete_Stored_Procedure("Injured_Delete", sp_Params);
                return flag;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public Injured Injured_Insert(string username, string password, Injured Injured)
        {
            try
            {
                bool flag = false;
                object[,] sp_params = new object[,]
               {
                    {"@username", username},
                    {"@password", password},
                    {"@Name", Injured.Name},
                    {"@Age", Injured.Age},
                    {"@Civil_Military",Injured.Civil_Military},
                    {"@Rank",Injured.Rank},
                    {"@Date",Injured.Date},
                    {"@Additional_info",Injured.Additional_info},
                    {"@AccidentID",Injured.AccidentID}
               };

                Injured.InjuredID = db.Execute_Insert_Stored_Procedure("Injured_Insert", sp_params);
                if (Injured.InjuredID > 0)
                {
                    return Injured;
                }

                return null;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public InjuredCollection Injured_Select_All(string username, string password)
        {
            try
            {
                InjuredCollection Injured = new InjuredCollection();
                DateTime temp_date = new DateTime(0000 - 00 - 00);
                object[,] sp_params = new object[,]
                {
                    {"@username", username},
                    {"@password", password}
                };

                DataTable dt = db.Execute_Stored_Procedure_Show_Values("Injured_Select_All", sp_params);

                if (dt.Rows.Count.Equals(0))
                {
                    return null;
                }
                else
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        Injured.Add(new Injured
                        {
                            InjuredID=Convert.ToInt32("InjuredID"),
                            Name = Convert.ToString(dr["Name"]),
                            Age = Convert.ToInt32(dr["Age"]),
                            Civil_Military = Convert.ToString(dr["Civil_Military"]),
                            Rank = Convert.ToString(dr["Rank"]),
                            Date = DateTime.Parse(dr["Date"].ToString()),
                            Additional_info = dr["Additional_info"] is DBNull ? "" : dr["Additional_info"].ToString(),
                            AccidentID = Convert.ToInt32(dr["AccidentID"])
                        });
                    }
                }
                return Injured;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public InjuredCollection Injured_Select_By_AccidentID(string username, string password, int AccidentID)
        {
            try
            {
                InjuredCollection Injured = new InjuredCollection();
                DateTime temp_date = new DateTime(0000 - 00 - 00);
                object[,] sp_params = new object[,]
                {
                    {"@username", username},
                    {"@password", password},
                    {"@AccidentID",AccidentID }
                };

                DataTable dt = db.Execute_Stored_Procedure_Show_Values("Injured_Select_By_AccidentID", sp_params);

                if (dt.Rows.Count.Equals(0))
                {
                    return null;
                }
                else
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        Injured.Add(new Injured
                        {
                            InjuredID = Convert.ToInt32("InjuredID"),
                            Name = Convert.ToString(dr["Name"]),
                            Age = Convert.ToInt32(dr["Age"]),
                            Civil_Military = Convert.ToString(dr["Civil_Military"]),
                            Rank = Convert.ToString(dr["Rank"]),
                            Date = DateTime.Parse(dr["Date"].ToString()),
                            Additional_info = dr["Additional_info"] is DBNull ? "" : dr["Additional_info"].ToString(),
                            AccidentID = Convert.ToInt32(dr["AccidentID"])
                        });
                    }
                }
                return Injured;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public InjuredCollection Injured_Select_By_Age(string username, string password, int Age)
        {
            try
            {
                InjuredCollection Injured = new InjuredCollection();
                DateTime temp_date = new DateTime(0000 - 00 - 00);
                object[,] sp_params = new object[,]
                {
                    {"@username", username},
                    {"@password", password},
                    {"@Age",Age }
                };

                DataTable dt = db.Execute_Stored_Procedure_Show_Values("Injured_Select_By_Age", sp_params);

                if (dt.Rows.Count.Equals(0))
                {
                    return null;
                }
                else
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        Injured.Add(new Injured
                        {
                            InjuredID = Convert.ToInt32("InjuredID"),
                            Name = Convert.ToString(dr["Name"]),
                            Age = Convert.ToInt32(dr["Age"]),
                            Civil_Military = Convert.ToString(dr["Civil_Military"]),
                            Rank = Convert.ToString(dr["Rank"]),
                            Date = DateTime.Parse(dr["Date"].ToString()),
                            Additional_info = dr["Additional_info"] is DBNull ? "" : dr["Additional_info"].ToString(),
                            AccidentID = Convert.ToInt32(dr["AccidentID"])
                        });
                    }
                }
                return Injured;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public InjuredCollection Injured_Select_By_Civil_Military(string username, string password, string Civil_Military)
        {
            try
            {
                InjuredCollection Injured = new InjuredCollection();
                DateTime temp_date = new DateTime(0000 - 00 - 00);
                object[,] sp_params = new object[,]
                {
                    {"@username", username},
                    {"@password", password},
                    {"@Civil_Military",Civil_Military }
                };

                DataTable dt = db.Execute_Stored_Procedure_Show_Values("Injured_Select_By_Civil_Military", sp_params);

                if (dt.Rows.Count.Equals(0))
                {
                    return null;
                }
                else
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        Injured.Add(new Injured
                        {
                            InjuredID = Convert.ToInt32("InjuredID"),
                            Name = Convert.ToString(dr["Name"]),
                            Age = Convert.ToInt32(dr["Age"]),
                            Civil_Military = Convert.ToString(dr["Civil_Military"]),
                            Rank = Convert.ToString(dr["Rank"]),
                            Date = DateTime.Parse(dr["Date"].ToString()),
                            Additional_info = dr["Additional_info"] is DBNull ? "" : dr["Additional_info"].ToString(),
                            AccidentID = Convert.ToInt32(dr["AccidentID"])
                        });
                    }
                }
                return Injured;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public InjuredCollection Injured_Select_By_Date(string username, string password, DateTime Date)
        {
            try
            {
                InjuredCollection Injured = new InjuredCollection();
                DateTime temp_date = new DateTime(0000 - 00 - 00);
                object[,] sp_params = new object[,]
                {
                    {"@username", username},
                    {"@password", password},
                    {"@Date",Date }
                };

                DataTable dt = db.Execute_Stored_Procedure_Show_Values("Injured_Select_By_Date", sp_params);

                if (dt.Rows.Count.Equals(0))
                {
                    return null;
                }
                else
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        Injured.Add(new Injured
                        {
                            InjuredID = Convert.ToInt32("InjuredID"),
                            Name = Convert.ToString(dr["Name"]),
                            Age = Convert.ToInt32(dr["Age"]),
                            Civil_Military = Convert.ToString(dr["Civil_Military"]),
                            Rank = Convert.ToString(dr["Rank"]),
                            Date = DateTime.Parse(dr["Date"].ToString()),
                            Additional_info = dr["Additional_info"] is DBNull ? "" : dr["Additional_info"].ToString(),
                            AccidentID = Convert.ToInt32(dr["AccidentID"])
                        });
                    }
                }
                return Injured;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public InjuredCollection Injured_Select_By_InjuredID(string username, string password, int InjuredID)
        {
            try
            {
                InjuredCollection Injured = new InjuredCollection();
                DateTime temp_date = new DateTime(0000 - 00 - 00);
                object[,] sp_params = new object[,]
                {
                    {"@username", username},
                    {"@password", password},
                    {"@InjuredID",InjuredID }
                };

                DataTable dt = db.Execute_Stored_Procedure_Show_Values("Injured_Select_By_InjuredID", sp_params);

                if (dt.Rows.Count.Equals(0))
                {
                    return null;
                }
                else
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        Injured.Add(new Injured
                        {
                            InjuredID = Convert.ToInt32("InjuredID"),
                            Name = Convert.ToString(dr["Name"]),
                            Age = Convert.ToInt32(dr["Age"]),
                            Civil_Military = Convert.ToString(dr["Civil_Military"]),
                            Rank = Convert.ToString(dr["Rank"]),
                            Date = DateTime.Parse(dr["Date"].ToString()),
                            Additional_info = dr["Additional_info"] is DBNull ? "" : dr["Additional_info"].ToString(),
                            AccidentID = Convert.ToInt32(dr["AccidentID"])
                        });
                    }
                }
                return Injured;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public InjuredCollection Injured_Select_By_Name(string username, string password, string Name)
        {
            try
            {
                InjuredCollection Injured = new InjuredCollection();
                DateTime temp_date = new DateTime(0000 - 00 - 00);
                object[,] sp_params = new object[,]
                {
                    {"@username", username},
                    {"@password", password},
                    {"@Name",Name}
                };

                DataTable dt = db.Execute_Stored_Procedure_Show_Values("Injured_Select_By_Name", sp_params);

                if (dt.Rows.Count.Equals(0))
                {
                    return null;
                }
                else
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        Injured.Add(new Injured
                        {
                            InjuredID = Convert.ToInt32("InjuredID"),
                            Name = Convert.ToString(dr["Name"]),
                            Age = Convert.ToInt32(dr["Age"]),
                            Civil_Military = Convert.ToString(dr["Civil_Military"]),
                            Rank = Convert.ToString(dr["Rank"]),
                            Date = DateTime.Parse(dr["Date"].ToString()),
                            Additional_info = dr["Additional_info"] is DBNull ? "" : dr["Additional_info"].ToString(),
                            AccidentID = Convert.ToInt32(dr["AccidentID"])
                        });
                    }
                }
                return Injured;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public InjuredCollection Injured_Select_By_Rank(string username, string password, string Rank)
        {
            try
            {
                InjuredCollection Injured = new InjuredCollection();
                DateTime temp_date = new DateTime(0000 - 00 - 00);
                object[,] sp_params = new object[,]
                {
                    {"@username", username},
                    {"@password", password},
                    {"@Rank",Rank}
                };

                DataTable dt = db.Execute_Stored_Procedure_Show_Values("Injured_Select_By_Rank", sp_params);

                if (dt.Rows.Count.Equals(0))
                {
                    return null;
                }
                else
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        Injured.Add(new Injured
                        {
                            InjuredID = Convert.ToInt32("InjuredID"),
                            Name = Convert.ToString(dr["Name"]),
                            Age = Convert.ToInt32(dr["Age"]),
                            Civil_Military = Convert.ToString(dr["Civil_Military"]),
                            Rank = Convert.ToString(dr["Rank"]),
                            Date = DateTime.Parse(dr["Date"].ToString()),
                            Additional_info = dr["Additional_info"] is DBNull ? "" : dr["Additional_info"].ToString(),
                            AccidentID = Convert.ToInt32(dr["AccidentID"])
                        });
                    }
                }
                return Injured;
            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
}