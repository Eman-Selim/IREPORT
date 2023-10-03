using SC3_Alarm_Module.Collection;
using SC3_Alarm_Module.Entity;
using SC3_Alarm_Module_WS.Code_Files.DBL;
using System;
using System.Drawing.Imaging;
using System.Data;

namespace SC3_Alarm_Module.DAL
{
    public class Forward_DestinationsDAL
    {
        DBL db = new DBL();

        public Forward_Destinations Forward_Destinations_Insert(string username, string password, Forward_Destinations New_Forward_Destination)
        {
            try
            {
                object[,] sp_Params = new object[,]
              {
                    {"@username", username},
                    {"@password", password},
                    {"@BU_ID", (New_Forward_Destination.BU_ID == 0 ? DBNull.Value : (object)New_Forward_Destination.BU_ID)},
                    {"@MU_ID", (New_Forward_Destination.MU_ID == 0 ? DBNull.Value : (object)New_Forward_Destination.MU_ID)},
                    {"@Alarm_Type_ID", New_Forward_Destination.Alarm_Type_ID},
                    {"@Network_Type", New_Forward_Destination.Network_Type },
                    {"@Network_ID", New_Forward_Destination.Network_ID },
                    {"@Message_Body", New_Forward_Destination.Message_Body },
                    {"@Info", New_Forward_Destination.Info },
              };


                New_Forward_Destination.Destination_ID = db.Execute_Insert_Stored_Procedure("Forward_Destinations_Insert", sp_Params);
                if (New_Forward_Destination.Destination_ID > 0)
                {
                    return New_Forward_Destination;
                }
                return null;


            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public bool Forward_Destinations_Update(string username, string password, Forward_Destinations Upd_Forward_Destination)
        {
            try
            {
                object[,] sp_Params = new object[,]
                {
                    {"@username", username},
                    {"@password", password},
                    {"@Destination_ID", Upd_Forward_Destination.Destination_ID },
                    {"@BU_ID", (Upd_Forward_Destination.BU_ID == 0 ? DBNull.Value : (object)Upd_Forward_Destination.BU_ID)},
                    {"@MU_ID", (Upd_Forward_Destination.MU_ID == 0 ? DBNull.Value : (object)Upd_Forward_Destination.MU_ID)},
                    { "@Alarm_Type_ID",  Upd_Forward_Destination.Alarm_Type_ID},
                    {"@Network_Type", Upd_Forward_Destination.Network_Type },
                    {"@Network_ID", Upd_Forward_Destination.Network_ID },
                    {"@Message_Body", Upd_Forward_Destination.Message_Body },
                    {"@Info", Upd_Forward_Destination.Info },

                };
                bool x = db.Execute_Update_Delete_Stored_Procedure("Forward_Destinations_Update", sp_Params);
                return x;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Forward_DestinationsCollection Forward_Destinations_Select_All(string username, string password)
        {
            try
            {
                Forward_DestinationsCollection All_Forward_Destinations = new Forward_DestinationsCollection();
                object[,] sp_Params = new object[,]

                {
                {"@username",username},
                {"@password",password},

                };

                DataTable dt = db.Execute_Stored_Procedure_Show_Values("Forward_Destinations_Select_All", sp_Params);

                if (dt.Rows.Count.Equals(0))
                {
                    return null;
                }
                else
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        All_Forward_Destinations.Add(new Forward_Destinations
                        {
                            Destination_ID = Convert.ToInt32(dr["Destination_ID"]),
                            BU_ID = dr["BU_ID"] is DBNull ? 0 : Convert.ToInt32(dr["BU_ID"]),
                            MU_ID = dr["MU_ID"] is DBNull ? 0 : Convert.ToInt32(dr["MU_ID"]),
                            Alarm_Type_ID = Convert.ToInt32(dr["Alarm_Type_ID"]),
                            Network_Type = dr["Network_Type"] is DBNull? "" : dr["Network_Type"].ToString(),
                            Network_ID  = dr["Network_ID"].ToString(),
                            Message_Body = dr["Message_Body"].ToString(),
                            Info = dr["Info"].ToString(),
                        });
                    }
                    return All_Forward_Destinations;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Forward_DestinationsCollection Forward_Destinations_Select(string username, string password, int forward_destination_id)
        {
            try
            {
                Forward_DestinationsCollection Forward_Destnation = new Forward_DestinationsCollection();
                object[,] sp_Params = new object[,]

                {
                {"@username",username},
                {"@password",password},
                {"@Destination_ID",forward_destination_id}
                };


                DataTable dt = db.Execute_Stored_Procedure_Show_Values("Forward_Destinations_Select", sp_Params);

                if (dt.Rows.Count.Equals(0))
                {
                    return null;
                }
                else
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        Forward_Destnation.Add(new Forward_Destinations
                        {
                            Destination_ID = Convert.ToInt32(dr["Destination_ID"]),
                            BU_ID = Convert.ToInt32(dr["BU_ID"]),
                            MU_ID = Convert.ToInt32(dr["MU_ID"]),
                            Alarm_Type_ID = Convert.ToInt32(dr["Alarm_Type_ID"]),
                            Network_Type = dr["Network_Type"] is DBNull ? "" : dr["Network_Type"].ToString(),
                            Network_ID = dr["Network_ID"].ToString(),
                            Message_Body = dr["Message_Body"].ToString(),
                            Info = dr["Info"].ToString(),
                        });
                    }
                    return Forward_Destnation;
                }            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public Forward_DestinationsCollection Forward_Destinations_SelectBy_MU_ID_and_AT_ID(string username, string password, int mu_id,int at_id)
        {
            try
            {
                Forward_DestinationsCollection Forward_Destnation = new Forward_DestinationsCollection();
                object[,] sp_Params = new object[,]

                {
                {"@username",username},
                {"@password",password},
                {"@MU_ID",mu_id},
                {"@AT_ID",at_id }
                };


                DataTable dt = db.Execute_Stored_Procedure_Show_Values("Forward_Destinations_SelectBy_MU_ID_and_AT_ID", sp_Params);

                if (dt.Rows.Count.Equals(0))
                {
                    return null;
                }
                else
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        Forward_Destnation.Add(new Forward_Destinations
                        {
                            Destination_ID = Convert.ToInt32(dr["Destination_ID"]),
                            BU_ID = dr["BU_ID"] is DBNull ? 0 : Convert.ToInt32(dr["BU_ID"]),
                            MU_ID = dr["MU_ID"] is DBNull ? 0 : Convert.ToInt32(dr["MU_ID"]),
                            Alarm_Type_ID = Convert.ToInt32(dr["Alarm_Type_ID"]),
                            Network_Type = dr["Network_Type"] is DBNull ? "" : dr["Network_Type"].ToString(),
                            Network_ID = dr["Network_ID"].ToString(),
                            Message_Body = dr["Message_Body"].ToString(),
                            Info = dr["Info"].ToString(),
                        });
                    }
                    return Forward_Destnation;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public Forward_DestinationsCollection Forward_Destinations_SelectBy_BU_ID_and_AT_ID(string username, string password, int bu_id, int at_id)
        {
            try
            {
                Forward_DestinationsCollection Forward_Destnation = new Forward_DestinationsCollection();
                object[,] sp_Params = new object[,]

                {
                {"@username",username},
                {"@password",password},
                {"@BU_ID",bu_id},
                {"@AT_ID",at_id }
                };


                DataTable dt = db.Execute_Stored_Procedure_Show_Values("Forward_Destinations_SelectBy_BU_ID_and_AT_ID", sp_Params);

                if (dt.Rows.Count.Equals(0))
                {
                    return null;
                }
                else
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        Forward_Destnation.Add(new Forward_Destinations
                        {
                            Destination_ID = Convert.ToInt32(dr["Destination_ID"]),
                            BU_ID = dr["BU_ID"] is DBNull ? 0 : Convert.ToInt32(dr["BU_ID"]),
                            MU_ID = dr["MU_ID"] is DBNull ? 0 : Convert.ToInt32(dr["MU_ID"]),
                            Alarm_Type_ID = Convert.ToInt32(dr["Alarm_Type_ID"]),
                            Network_Type = dr["Network_Type"] is DBNull ? "" : dr["Network_Type"].ToString(),
                            Network_ID = dr["Network_ID"].ToString(),
                            Message_Body = dr["Message_Body"].ToString(),
                            Info = dr["Info"].ToString(),
                        });
                    }
                    return Forward_Destnation;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public bool Forward_Destinations_Delete(string username, string password, int forward_destination_id)
        {
            try
            {
                object[,] sp_Params = new object[,]
                {
                    {"@username",username},
                    {"@password", password},
                    {"@Destination_ID", forward_destination_id},
                };
                bool x = db.Execute_Update_Delete_Stored_Procedure("Forward_Destinations_Delete", sp_Params);
                return x;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public bool Forward_Destinations_Delete_All(string username, string password)
        {
            try
            {
                object[,] sp_Params = new object[,]
                {
                    {"@username",username},
                    {"@password", password},
                };
                bool x = db.Execute_Update_Delete_Stored_Procedure("Forward_Destinations_Delete_All", sp_Params);
                return x;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}