using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IncidentReporting_WS.Code_Files.ENL;
using IncidentReporting_WS.Code_Files.COL;
using System.Data;

namespace IncidentReporting_WS.Code_Files.DAL
{
    public class ImagesDAL
    {
        DBL.DBL db = new DBL.DBL();
        byte[] smallArray = new byte[] { 0x20, 0x20 };
        public Images Images_Insert(string username, string password, Images Images)
        {
            try
            {
                bool flag = false;
                object[,] sp_params = new object[,]
               {
                    {"@username", username},
                    {"@password", password},
                    {"@ImageDescription", Images.ImageDescription },
                    {"@BuildingID", Images.BuildingID},
                    {"@Image",Images.Image }

               };

                Images.ImageID = db.Execute_Insert_Stored_Procedure("Images_Insert", sp_params);
                if (Images.ImageID > 0)
                {
                    return Images;
                }

                return null;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public ImagesCollection Images_Select_All(string username, string password)
        {
            try
            {
                ImagesCollection Images = new ImagesCollection();
                DateTime temp_date = new DateTime(0000 - 00 - 00);
                object[,] sp_params = new object[,]
                {
                    {"@username", username},
                    {"@password", password}
                };

                DataTable dt = db.Execute_Stored_Procedure_Show_Values("Images_Select_All", sp_params);

                if (dt.Rows.Count.Equals(0))
                {
                    return null;
                }
                else
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        Images.Add(new Images
                        {
                            ImageDescription = dr["ImageDescription"] is DBNull ? "" : Convert.ToString(dr["ImageDescription"]),
                            BuildingID = dr["BuildingID"] is DBNull ? 0 : Convert.ToInt32(dr["BuildingID"]),
                            Image = dr["Image"] is DBNull ? smallArray : (byte[])dr["Image"],
                            ImageID= dr["ImageID"] is DBNull ? 0 : Convert.ToInt32(dr["ImageID"])
                        });
                    }
                }
                return Images;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public ImagesCollection Images_Select_By_BuildingID(string username, string password, int BuildingID)
        {
            try
            {
                ImagesCollection Images = new ImagesCollection();
                DateTime temp_date = new DateTime(0000 - 00 - 00);
                object[,] sp_params = new object[,]
                {
                    {"@username", username},
                    {"@password", password},
                    {"@BuildingID",BuildingID }
                };

                DataTable dt = db.Execute_Stored_Procedure_Show_Values("Images_Select_By_BuildingID", sp_params);

                if (dt.Rows.Count.Equals(0))
                {
                    return null;
                }
                else
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        Images.Add(new Images
                        {
                            ImageDescription = dr["ImageDescription"] is DBNull ? "" : Convert.ToString(dr["ImageDescription"]),
                            BuildingID = dr["BuildingID"] is DBNull ? 0 : Convert.ToInt32(dr["BuildingID"]),
                            Image = dr["Image"] is DBNull ? smallArray : (byte[])dr["Image"],
                            ImageID = dr["ImageID"] is DBNull ? 0 : Convert.ToInt32(dr["ImageID"])
                        });
                    }
                }
                return Images;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public ImagesCollection Images_Select_By_ImageDescription(string username, string password, string ImageDescription)
        {
            try
            {
                ImagesCollection Images = new ImagesCollection();
                DateTime temp_date = new DateTime(0000 - 00 - 00);
                object[,] sp_params = new object[,]
                {
                    {"@username", username},
                    {"@password", password},
                    {"@ImageDescription",ImageDescription}
                };

                DataTable dt = db.Execute_Stored_Procedure_Show_Values("Images_Select_By_ImageDescription", sp_params);

                if (dt.Rows.Count.Equals(0))
                {
                    return null;
                }
                else
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        Images.Add(new Images
                        {
                            ImageDescription = dr["ImageDescription"] is DBNull ? "" : Convert.ToString(dr["ImageDescription"]),
                            BuildingID = dr["BuildingID"] is DBNull ? 0 : Convert.ToInt32(dr["BuildingID"]),
                            Image = dr["Image"] is DBNull ? smallArray : (byte[])dr["Image"],
                            ImageID = dr["ImageID"] is DBNull ? 0 : Convert.ToInt32(dr["ImageID"])
                        });
                    }
                }
                return Images;
            }
            catch (Exception e)
            {
                return null;
            }
        }


    }
}