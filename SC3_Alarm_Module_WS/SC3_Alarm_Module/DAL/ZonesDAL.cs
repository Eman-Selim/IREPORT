using SC3_Alarm_Module.Collection;
using SC3_Alarm_Module.Entity;
using SC3_Alarm_Module_WS.Code_Files.DBL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace SC3_Alarm_Module.DAL
{
    public class ZonesDAL
    {
        DBL db = new DBL();

        public bool Zones_Delete(string username, string password, int Zone_id)
        {
            try
            {
                object[,] sp_Params = new object[,]
                {
                    {"@userauthentivation", username},
                    {"@passwordauthentication", password},
                    {"@Zone_id", Zone_id}
                };

                bool flag = db.Execute_Update_Delete_Stored_Procedure("Zones_Delete", sp_Params);
                return flag;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public Zones Zones_Insert(string username, string password, Zones Zone)
        {
            try
            {
                object[,] sp_params = new object[,]
               {
                    {"@userauthentivation", username},
                    {"@passwordauthentication", password},
                    {"@U_id", Zone.U_id},
                    {"@Zone_Name", Zone.Zone_Name},
                    {"@Zone_Type", Zone.Zone_Type},
                    {"@Zone_Boundaries",Zone.Zone_Boundaries},
                    {"@Zone_Color",Zone.Zone_Color},
                    {"@Zone_Info",Zone.Zone_Info }
               };

                Zone.Zone_id = db.Execute_Insert_Stored_Procedure("Zones_Insert", sp_params);
                if (Zone.Zone_id > 0)
                {
                    return Zone;
                }

                return null;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public ZonesCollection Zones_Select(string username, string password, int zoneid)
        {
            try
            {
                ZonesCollection zones = new ZonesCollection();
                object[,] sp_params = new object[,]
                {
                    {"@userauthentivation", username},
                    {"@passwordauthentication", password},
                    {"@zoneid", zoneid}
                };

                DataTable dt = db.Execute_Stored_Procedure_Show_Values("Zones_Select", sp_params);

                if (dt.Rows.Count.Equals(0))
                {
                    return null;
                }
                else
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        zones.Add(new Zones
                        {
                            Zone_Boundaries = dr["Zone_Boundaries"] is DBNull ? "" : dr["Zone_Boundaries"].ToString(),
                            Zone_Color = dr["Zone_Color"] is DBNull ? "" : dr["Zone_Color"].ToString(),
                            Zone_id = Convert.ToInt32(dr["Zone_id"]),
                            Zone_Name = dr["Zone_Name"] is DBNull ? "" : dr["Zone_Name"].ToString(),
                            Zone_Type = dr["Zone_Type"] is DBNull ? "" : dr["Zone_Type"].ToString(),
                            U_id = Convert.ToInt32(dr["U_id"]),
                            Zone_Info = dr["Zone_Info"] is DBNull ? "" : dr["Zone_Info"].ToString()
                        });
                    }
                }
                return zones;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public ZonesCollection Zones_Select_All(string username, string password)
        {
            try
            {
                ZonesCollection zones = new ZonesCollection();
                object[,] sp_params = new object[,]
                {
                    {"@userauthentivation", username},
                    {"@passwordauthentication", password}
                };

                DataTable dt = db.Execute_Stored_Procedure_Show_Values("Zones_Select_All", sp_params);

                if (dt.Rows.Count.Equals(0))
                {
                    return null;
                }
                else
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        zones.Add(new Zones
                        {
                            Zone_Boundaries = dr["Zone_Boundaries"] is DBNull ? "" : dr["Zone_Boundaries"].ToString(),
                            Zone_Color = dr["Zone_Color"] is DBNull ? "" : dr["Zone_Color"].ToString(),
                            Zone_id = Convert.ToInt32(dr["Zone_id"]),
                            Zone_Name = dr["Zone_Name"] is DBNull ? "" : dr["Zone_Name"].ToString(),
                            Zone_Type = dr["Zone_Type"] is DBNull ? "" : dr["Zone_Type"].ToString(),
                            U_id = Convert.ToInt32(dr["U_id"]),
                            Zone_Info = dr["Zone_Info"] is DBNull ? "" : dr["Zone_Info"].ToString()
                        });
                    }
                }
                return zones;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public ZonesCollection Zones_Select_BySchedule_Id(string username, string password, int Schedules_Id)
        {
            try
            {
                ZonesCollection zones = new ZonesCollection();

                object[,] sp_params = new object[,]
                {
                    {"@userauthentivation", username},
                    {"@passwordauthentication", password},
                    {"@Schedules_Id", Schedules_Id}
                };

                DataTable dt = db.Execute_Stored_Procedure_Show_Values("Zones_Select_BySchedule_Id", sp_params);

                if (dt.Rows.Count.Equals(0))
                {
                    return null;
                }
                else
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        zones.Add(new Zones
                        {
                            Zone_Boundaries = dr["Zone_Boundaries"] is DBNull ? "" : dr["Zone_Boundaries"].ToString(),
                            Zone_Color = dr["Zone_Color"] is DBNull ? "" : dr["Zone_Color"].ToString(),
                            Zone_id = Convert.ToInt32(dr["Zone_id"]),
                            Zone_Name = dr["Zone_Name"] is DBNull ? "" : dr["Zone_Name"].ToString(),
                            Zone_Type = dr["Zone_Type"] is DBNull ? "" : dr["Zone_Type"].ToString(),
                            U_id = Convert.ToInt32(dr["U_id"]),
                            Zone_Info = dr["Zone_Info"] is DBNull ? "" : dr["Zone_Info"].ToString()
                        });
                    }
                }
                return zones;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public ZonesCollection Zones_SelectByUserId(string username, string password, int userid)
        {
            try
            {
                ZonesCollection zones = new ZonesCollection();
                DateTime temp_date = new DateTime(0000 - 00 - 00);
                object[,] sp_params = new object[,]
                {
                    {"@userauthentivation", username},
                    {"@passwordauthentication", password},
                    {"@userid", userid}
                };

                DataTable dt = db.Execute_Stored_Procedure_Show_Values("Zones_SelectByUserId", sp_params);

                if (dt.Rows.Count.Equals(0))
                {
                    return null;
                }
                else
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        zones.Add(new Zones
                        {
                            Zone_Boundaries = dr["Zone_Boundaries"] is DBNull ? "" : dr["Zone_Boundaries"].ToString(),
                            Zone_Color = dr["Zone_Color"] is DBNull ? "" : dr["Zone_Color"].ToString(),
                            Zone_id = Convert.ToInt32(dr["Zone_id"]),
                            Zone_Name = dr["Zone_Name"] is DBNull ? "" : dr["Zone_Name"].ToString(),
                            Zone_Type = dr["Zone_Type"] is DBNull ? "" : dr["Zone_Type"].ToString(),
                            U_id = Convert.ToInt32(dr["U_id"]),
                            Zone_Info = dr["Zone_Info"] is DBNull ? "" : dr["Zone_Info"].ToString()
                        });
                    }
                }
                return zones;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public bool Zones_Update(string username, string password, Zones Zone)
        {
            try
            {
                object[,] sp_params = new object[,]
              {
                    {"@userauthentivation", username},
                    {"@passwordauthentication", password},
                    {"@Zone_id" ,Zone.Zone_id},
                    {"@U_id", Zone.U_id},
                    {"@Zone_Name", Zone.Zone_Name},
                    {"@Zone_Type", Zone.Zone_Type},
                    {"@Zone_Boundaries",Zone.Zone_Boundaries},
                    {"@Zone_Color",Zone.Zone_Color},
                    {"@Zone_Info",Zone.Zone_Info }
              };

                bool flag = db.Execute_Update_Delete_Stored_Procedure("Zones_Update", sp_params);
                return flag;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

    }
}