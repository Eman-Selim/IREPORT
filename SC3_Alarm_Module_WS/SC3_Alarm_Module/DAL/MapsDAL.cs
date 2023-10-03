using System;
using System.Data;
using SC3_Alarm_Module.Entity;
using SC3_Alarm_Module.Collection;
using SC3_Alarm_Module_WS.Code_Files.DBL;

namespace SC3_Alarm_Module.DAL
{
    public class MapsDAL
    {
        DBL db = new DBL();

        public bool Maps_Delete(string username, string password, int Map_id)
        {
            try
            {
                object[,] sp_Params = new object[,]
                {
                    {"@username", username},
                    {"@password", password},
                    {"@Map_ID", Map_id}
                };

                bool x = db.Execute_Update_Delete_Stored_Procedure("Maps_Delete", sp_Params);
                return x;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Maps Maps_Insert(string username, string password, Maps Map)
        {
            try
            {
                object[,] sp_params = new object[,]
               {
                    {"@username", username},
                    {"@password", password},
                    {"@User_ID", Map.User_ID },
                    {"@Map_Name", Map.Map_Name },
                    {"@Online_Or_Offline", Map.Online_Or_Offline },
                    {"@Map_URL", Map.Map_URL },
                    {"@Map_Info" , Map.Map_Info }
               };

                Map.Map_ID = db.Execute_Insert_Stored_Procedure("Maps_Insert", sp_params);

                if (Map.Map_ID > 0)
                {
                    return Map;
                }

                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public MapsCollection Maps_Select(string username, string password, int map_id)
        {
            try
            {
                MapsCollection map = new MapsCollection();
                object[,] sp_params = new object[,]
                {
                    {"@username", username},
                    {"@password", password},
                    {"@Map_ID", map_id},
                };

                DataTable dt = db.Execute_Stored_Procedure_Show_Values("Maps_Select", sp_params);

                if (dt.Rows.Count.Equals(0))
                {
                    return null;
                }
                else
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        map.Add(new Maps
                        {
                            Map_ID = Convert.ToInt32(dr["Map_ID"]),
                            User_ID = Convert.ToInt32(dr["User_ID"]),
                            Map_Name= dr["Map_Name"].ToString(),
                            Online_Or_Offline = Convert.ToBoolean(dr["Online_Or_Offline"]),
                            Map_URL = dr["Map_URL"].ToString(),
                            Map_Info = dr["Map_Info"].ToString(),
                        });
                    }
                }
                return map;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public MapsCollection Maps_SelectAll(string username, string password)
        {
            try
            {
                MapsCollection maps = new MapsCollection();
                object[,] sp_params = new object[,]
                {
                    {"@username", username},
                    {"@password", password},
                };

                DataTable dt = db.Execute_Stored_Procedure_Show_Values("Maps_SelectAll", sp_params);

                if (dt.Rows.Count.Equals(0))
                {
                    return null;
                }
                else
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        maps.Add(new Maps
                        {
                            Map_ID = Convert.ToInt32(dr["Map_ID"]),
                            User_ID = Convert.ToInt32(dr["User_ID"]),
                            Map_Name = dr["Map_Name"].ToString(),
                            Online_Or_Offline = Convert.ToBoolean(dr["Online_Or_Offline"]),
                            Map_URL = dr["Map_URL"].ToString(),
                            Map_Info = dr["Map_Info"].ToString(),
                        });
                    }
                }
                return maps;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Maps_Update(string username, string password, Maps Upd_Map)
        {
            try
            {
                object[,] sp_Params = new object[,]
                {

                    {"@username", username},
                    {"@password", password},
                    {"@Map_ID", Upd_Map.Map_ID},
                    {"@User_ID", Upd_Map.User_ID},
                    {"@Map_Name", Upd_Map.Map_Name },
                    {"@Online_Or_Offline", Upd_Map.Online_Or_Offline },
                    {"@Map_URL", Upd_Map.Map_URL },
                    {"@Map_Info", Upd_Map.Map_Info }

                };


                bool x = db.Execute_Update_Delete_Stored_Procedure("Maps_Update", sp_Params);

                return x;



            }

            catch (Exception ex)
            {

                throw ex;
            }



        }

    }
}