using SC3_Alarm_Module.Collection;
using SC3_Alarm_Module.Entity;
using SC3_Alarm_Module_WS.Code_Files.DBL;
using System;
using System.Data;

namespace SC3_Alarm_Module.DAL
{
    public class LayersDAL
    {
        DBL db = new DBL();

        public bool Layers_Delete(string username, string password, int layer_id)
        {
            try
            {
                object[,] sp_Params = new object[,]
                {
                    {"@userauthentivation", username},
                    {"@passwordauthentication", password},
                    {"@layer_id", layer_id}
                };

                bool flag = db.Execute_Update_Delete_Stored_Procedure("Layers_Delete", sp_Params);
                return flag;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public Layers Layers_Insert(string username, string password, Layers Layer)
        {
            try
            {
                object[,] sp_params = new object[,]
               {
                    {"@userauthentivation", username},
                    {"@passwordauthentication", password},
                    {"@U_id", Layer.U_id},
                    {"@Layer_Name", Layer.Layer_Name},
                    {"@Layer_Info", Layer.Layer_Info},
                    {"@Icon", Layer.Icon}
               };

                Layer.Layer_id = db.Execute_Insert_Stored_Procedure("Layers_Insert", sp_params);

                if(Layer.Layer_id > 0 )
                {
                    return Layer;
                }

                return null;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public LayersCollection Layers_Select(string username, string password, int layerid)
        {
            try
            {
                LayersCollection layers = new LayersCollection();
                DateTime temp_date = new DateTime(0000 - 00 - 00);
                object[,] sp_params = new object[,]
                {
                    {"@userauthentivation", username},
                    {"@passwordauthentication", password},
                    {"@layerid", layerid}
                };

                DataTable dt = db.Execute_Stored_Procedure_Show_Values("Layers_Select", sp_params);

                if (dt.Rows.Count.Equals(0))
                {
                    return null;
                }
                else
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        layers.Add(new Layers
                        {
                            Layer_id = Convert.ToInt32(dr["Layer_id"].ToString()),
                            U_id = Convert.ToInt32(dr["U_id"]),
                            Layer_Name = dr["Layer_Name"] is DBNull ? "" : dr["Layer_Name"].ToString(),
                            Layer_Info = dr["Layer_Info"] is DBNull ? "" : dr["Layer_Info"].ToString(),
                            Icon = dr["Icon"] is DBNull? null : (byte[])dr["Icon"]
                        });
                    }
                }
                return layers;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public LayersCollection Layers_SelectByUserId(string username, string password, int userid)
        {
            try
            {
                LayersCollection layers = new LayersCollection();
                DateTime temp_date = new DateTime(0000 - 00 - 00);
                object[,] sp_params = new object[,]
                {
                    {"@userauthentivation", username},
                    {"@passwordauthentication", password},
                    {"@userid", userid.ToString()}
                };

                DataTable dt = db.Execute_Stored_Procedure_Show_Values("Layers_SelectByUserId", sp_params);

                if (dt.Rows.Count.Equals(0))
                {
                    return null;
                }
                else
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        layers.Add(new Layers
                        {
                            Layer_id = Convert.ToInt32(dr["Layer_id"].ToString()),
                            U_id = Convert.ToInt32(dr["U_id"]),
                            Layer_Name = dr["Layer_Name"] is DBNull ? "" : dr["Layer_Name"].ToString(),
                            Layer_Info = dr["Layer_Info"] is DBNull ? "" : dr["Layer_Info"].ToString(),
                            Icon = dr["Icon"] is DBNull ? null : (byte[])dr["Icon"]
                        });
                    }
                }
                return layers;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public bool Layers_Update(string username, string password, Layers layer_obj)
        {
            try
            {
                object[,] sp_params = new object[,]
                {
                    {"@userauthentivation", username},
                    {"@passwordauthentication", password},
                    {"@U_id", layer_obj.U_id},
                    {"@Layer_id", layer_obj.Layer_id},
                    {"@Layer_Name", layer_obj.Layer_Name},
                    {"@Layer_Info", layer_obj.Layer_Info},
                    {"@Icon", layer_obj.Icon}
                };

                bool flag = db.Execute_Update_Delete_Stored_Procedure("Layers_Update", sp_params);
                return flag;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}