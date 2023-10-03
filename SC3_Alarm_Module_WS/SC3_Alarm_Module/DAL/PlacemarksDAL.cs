using SC3_Alarm_Module.Collection;
using SC3_Alarm_Module.Entity;
using System;
using SC3_Alarm_Module_WS.Code_Files.DBL;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace SC3_Alarm_Module.DAL
{
    public class PlacemarksDAL
    {
        DBL db = new DBL();

        public bool Placemarks_Delete(string username, string password, int placemark_id, int layer_id)
        {
            try
            {
                object[,] sp_Params = new object[,]
                {
                    {"@userauthentivation", username},
                    {"@passwordauthentication", password},
                    {"@Placemark_id", placemark_id},
                    {"@Layer_id", layer_id }
                };

                bool flag = db.Execute_Update_Delete_Stored_Procedure("Placemarks_Delete", sp_Params);
                return flag;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public Placemarks Placemarks_Insert(string username, string password, Placemarks Placemark)
        {
            try
            {
                object[,] sp_params = new object[,]
               {
                    {"@userauthentivation", username},
                    {"@passwordauthentication", password},
                    {"@Layer_id", Placemark.Layer_id},
                    {"@Placemark_Name", Placemark.Placemark_Name},
                    {"@Placemark_Lat", Placemark.Placemark_Lat},
                    {"@Placemark_Lon", Placemark.Placemark_Lon},
                    {"@Placemark_info", Placemark.Placemark_info},
               };

                Placemark.Placemark_id = db.Execute_Insert_Stored_Procedure("Placemarks_Insert", sp_params);
                if( Placemark.Placemark_id > 0 )
                {
                    return Placemark;
                }

                return null;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public bool Placemarks_Insert_Bulk(string username, string password, PlacemarksCollection Placemarks_Array)
        {
            try
            {
                bool flag = false;
                if (Placemarks_Array.Count > 0)
                {
                    #region Add Placemarks 

                    string _Query = "";

                    decimal Insert_Queries_Number = (Placemarks_Array.Count / 1000) + 1;

                    for (int j = 0; j < Insert_Queries_Number; j++)
                    {
                        _Query = "INSERT INTO Placemarks(Layer_id,Placemark_Name,Placemark_Lat,Placemark_Lon,Placemark_info) Values";

                        for (int i = j * 1000; i < (j * 1000) + 1000; i++)
                        {
                            _Query += "(" + Placemarks_Array[i].Layer_id + ",N'" + Placemarks_Array[i].Placemark_Name + "',"+ Placemarks_Array[i].Placemark_Lat + ","+ Placemarks_Array[i].Placemark_Lon +",N'"+ Placemarks_Array[i].Placemark_info+ "') \r\n";



                            if (i + 1 >= Placemarks_Array.Count)
                            {
                                break;
                            }

                            if (i + 1 < (j * 1000) + 1000)
                            {
                                _Query += ",";
                            }
                            else
                            {
                                _Query += ";";
                            }
                        }

                        object[,] sp_params = new object[,]
                       {
                            {"@userauthentivation", username},
                            {"@passwordauthentication", password},
                            {"@query", _Query}
                       };

                        int Last_id = db.Execute_Insert_Stored_Procedure("Placemarks_Insert_Bulk", sp_params);
                        flag = Last_id > 0 ? true : false;

                    }
                    #endregion
                }
                return flag;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public PlacemarksCollection Placemarks_Select(string username, string password, int placemarkid)
        {
            try
            {
                PlacemarksCollection placemarks = new PlacemarksCollection();
                DateTime temp_date = new DateTime(0000 - 00 - 00);
                object[,] sp_params = new object[,]
                {
                    {"@userauthentivation", username},
                    {"@passwordauthentication", password},
                    {"@Placemark_id", placemarkid}
                };

                DataTable dt = db.Execute_Stored_Procedure_Show_Values("Placemarks_Select", sp_params);

                if (dt.Rows.Count.Equals(0))
                {
                    return null;
                }
                else
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        placemarks.Add(new Placemarks
                        {
                            Placemark_id = Convert.ToInt32(dr["Placemark_id"]),
                            Placemark_info = dr["Placemark_info"] is DBNull ? "" : dr["Placemark_info"].ToString(),
                            Placemark_Lat = dr["Placemark_Lat"] is DBNull ? 0 : Convert.ToDouble(dr["Placemark_Lat"]),
                            Placemark_Lon = dr["Placemark_Lon"] is DBNull ? 0 : Convert.ToDouble(dr["Placemark_Lon"]),
                            Placemark_Name = dr["Placemark_Name"] is DBNull ? "" : dr["Placemark_Name"].ToString(),
                            Layer_id = Convert.ToInt32(dr["Layer_id"])
                        });
                    }
                }
                return placemarks;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public PlacemarksCollection Placemarks_SelectByLayerId(string username, string password, int layerid)
        {
            try
            {
                PlacemarksCollection placemarks = new PlacemarksCollection();
                DateTime temp_date = new DateTime(0000 - 00 - 00);
                object[,] sp_params = new object[,]
                {
                    {"@userauthentivation", username},
                    {"@passwordauthentication", password},
                    {"@Layer_id", layerid}
                };

                DataTable dt = db.Execute_Stored_Procedure_Show_Values("Placemarks_SelectByLayerId", sp_params);

                if (dt.Rows.Count.Equals(0))
                {
                    return null;
                }
                else
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        placemarks.Add(new Placemarks
                        {
                            Placemark_id = Convert.ToInt32(dr["Placemark_id"]),
                            Placemark_info = dr["Placemark_info"] is DBNull ? "" : dr["Placemark_info"].ToString(),
                            Placemark_Lat = dr["Placemark_Lat"] is DBNull ? 0 : Convert.ToDouble(dr["Placemark_Lat"]),
                            Placemark_Lon = dr["Placemark_Lon"] is DBNull ? 0 : Convert.ToDouble(dr["Placemark_Lon"]),
                            Placemark_Name = dr["Placemark_Name"] is DBNull ? "" : dr["Placemark_Name"].ToString(),
                            Layer_id = Convert.ToInt32(dr["Layer_id"])
                        });
                    }
                }
                return placemarks;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public PlacemarksCollection Placemarks_SelectByUserId(string username, string password, int userid)
        {
            try
            {
                PlacemarksCollection placemarks = new PlacemarksCollection();
                DateTime temp_date = new DateTime(0000 - 00 - 00);
                object[,] sp_params = new object[,]
                {
                    {"@userauthentivation", username},
                    {"@passwordauthentication", password},
                    {"@userid", userid}
                };

                DataTable dt = db.Execute_Stored_Procedure_Show_Values("Placemarks_SelectByUserId", sp_params);

                if (dt.Rows.Count.Equals(0))
                {
                    return null;
                }
                else
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        placemarks.Add(new Placemarks
                        {
                            Placemark_id = Convert.ToInt32(dr["Placemark_id"]),
                            Placemark_info = dr["Placemark_info"] is DBNull ? "" : dr["Placemark_info"].ToString(),
                            Placemark_Lat = dr["Placemark_Lat"] is DBNull ? 0 : Convert.ToDouble(dr["Placemark_Lat"]),
                            Placemark_Lon = dr["Placemark_Lon"] is DBNull ? 0 : Convert.ToDouble(dr["Placemark_Lon"]),
                            Placemark_Name = dr["Placemark_Name"] is DBNull ? "" : dr["Placemark_Name"].ToString(),
                            Layer_id = Convert.ToInt32(dr["Layer_id"])
                        });
                    }
                }
                return placemarks;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public bool Placemarks_Update(string username, string password, Placemarks Placemark)
        {
            try
            {
                object[,] sp_params = new object[,]
                 {
                        {"@userauthentivation", username},
                        {"@passwordauthentication", password},
                        {"@Placemark_id", Placemark.Placemark_id},
                        {"@Layer_id", Placemark.Layer_id},
                        {"@Placemark_Name", Placemark.Placemark_Name},
                        {"@Placemark_Lat", Placemark.Placemark_Lat},
                        {"@Placemark_Lon", Placemark.Placemark_Lon},
                        {"@Placemark_info", Placemark.Placemark_info},
                 }; 

                bool flag = db.Execute_Update_Delete_Stored_Procedure("Placemarks_Update", sp_params);
                return flag;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool Placemarks_Update_Bulk(string username, string password, PlacemarksCollection Placemarks_Array)
        {
            try
            {
                bool flag = false;
                if (Placemarks_Array.Count > 0)
                {
                    #region Edit Placemarks 

                    for (int j = 0; j < Placemarks_Array.Count; j++)
                    {
                        flag = Placemarks_Update(username, password, Placemarks_Array[j]);
                        if (flag == false)
                        {
                            break;
                        }
                    }
                    #endregion
                }
                return flag;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

    }
}