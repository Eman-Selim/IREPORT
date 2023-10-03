using SC3_Alarm_Module.Collection;
using SC3_Alarm_Module.Entity;
using SC3_Alarm_Module_WS.Code_Files.DBL;
using System;
using System.Drawing.Imaging;
using System.Data;

namespace SC3_Alarm_Module.DAL
{
    public class Alarm_TypeDAL
    {
        DBL db = new DBL();
        public bool Alarm_Type_Delete(string username, string password, int alarm_type_id)
        {
            try
            {

                object[,] sp_Params = new object[,]
                {
                    {"@username",username},
                    {"@password", password},
                    {"@Alarm_Type_ID", alarm_type_id},

                };

                bool x = db.Execute_Update_Delete_Stored_Procedure("Alarm_Type_Delete", sp_Params);
                return x;



            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public Alarm_Type Alarm_Type_Insert(string username, string password, Alarm_Type New_Alarm_Type)
        {
            try
            {
                object[,] sp_Params = new object[,]
              {
                    {"@username", username},
                    {"@password", password},
                    {"@Alarm_Type_Name", New_Alarm_Type.Alarm_Type_Name },
                    {"@Alarm_Type_Message", New_Alarm_Type.Alarm_Type_Message },
                    {"@Alarm_Type_Icon", New_Alarm_Type.Alarm_Type_Icon == null ?System.Data.SqlTypes.SqlBinary.Null : New_Alarm_Type.Alarm_Type_Icon},
              };


                New_Alarm_Type.Alarm_Type_ID = db.Execute_Insert_Stored_Procedure("Alarm_Type_Insert", sp_Params);
                if (New_Alarm_Type.Alarm_Type_ID > 0)
                {
                    return New_Alarm_Type;
                }
                return null;


            }
            catch (Exception ex)
            {

                throw ex;
            }


        }

        public Alarm_TypeCollection Alarm_Type_Select(string username, string password, int alarm_type_id)
        {
            try
            {
                Alarm_TypeCollection Alarm_Type = new Alarm_TypeCollection();
                object[,] sp_Params = new object[,]

                {
                {"@username",username},
                {"@password",password},
                {"@Alarm_Type_ID",alarm_type_id}
                };


                DataTable dt = db.Execute_Stored_Procedure_Show_Values("Alarm_Type_Select", sp_Params);

                if (dt.Rows.Count.Equals(0))
                {
                    return null;
                }

                else
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        Alarm_Type.Add(new Alarm_Type
                        {
                            Alarm_Type_ID = Convert.ToInt32(dr["Alarm_Type_ID"]),
                            Alarm_Type_Name = dr["Alarm_Type_Name"].ToString(),
                            Alarm_Type_Message = dr["Alarm_Type_Message"].ToString(),
                            Alarm_Type_Icon = dr["Alarm_Type_Icon"] is DBNull ? null : (byte[])dr["Alarm_Type_Icon"],


                        });
                    }
                    return Alarm_Type;
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }



        }

        public Alarm_TypeCollection Alarm_Type_Select_All(string username, string password)
        {
            try
            {
                Alarm_TypeCollection All_Alarm_Type = new Alarm_TypeCollection();
                object[,] sp_Params = new object[,]

                {
                {"@username",username},
                {"@password",password},

                };


                DataTable dt = db.Execute_Stored_Procedure_Show_Values("Alarm_Type_Select_All", sp_Params);

                if (dt.Rows.Count.Equals(0))
                {
                    return null;
                }

                else
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        All_Alarm_Type.Add(new Alarm_Type
                        {

                            Alarm_Type_ID = Convert.ToInt32(dr["Alarm_Type_ID"]),
                            Alarm_Type_Name = dr["Alarm_Type_Name"].ToString(),
                            Alarm_Type_Message = dr["Alarm_Type_Message"].ToString(),
                            Alarm_Type_Icon = dr["Alarm_Type_Icon"] is DBNull ? null : (byte[])dr["Alarm_Type_Icon"],

                        });
                    }
                    return All_Alarm_Type;
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }



        }

        public bool Alarm_Type_Update(string username, string password, Alarm_Type Upd_Alarm_Type)
        {
            try
            {
                object[,] sp_Params = new object[,]
                {

                    {"@username", username},
                    {"@password", password},
                    {"@Alarm_Type_ID", Upd_Alarm_Type.Alarm_Type_ID },
                    {"@Alarm_Type_Name", Upd_Alarm_Type.Alarm_Type_Name },
                    {"@Alarm_Type_Message", Upd_Alarm_Type.Alarm_Type_Message },
                    {"@Alarm_Type_Icon",  Upd_Alarm_Type.Alarm_Type_Icon == null ?System.Data.SqlTypes.SqlBinary.Null : Upd_Alarm_Type.Alarm_Type_Icon },

                };


                bool x = db.Execute_Update_Delete_Stored_Procedure("Alarm_Type_Update", sp_Params);

                return x;



            }

            catch (Exception ex)
            {

                throw ex;
            }



        }
    }
}