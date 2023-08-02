using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IncidentReporting_WS.Code_Files.ENL;
using IncidentReporting_WS.Code_Files.COL;
using System.Data;

namespace IncidentReporting_WS.Code_Files.DAL
{
    public class ExitPathwaysDAL
    {
        DBL.DBL db = new DBL.DBL();
        byte[] smallArray = new byte[] { 0x20, 0x20 };
        public ExitPathways ExitPathways_Insert(string username, string password, ExitPathways ExitPathway)
        {
            try
            {
                bool flag = false;
                object[,] sp_params = new object[,]
               {
                    {"@username", username},
                    {"@password", password},
                    {"@Description", ExitPathway.Description},
                    {"@PathwaysImage", ExitPathway.PathwaysImage },
                    {"@PathwaysImageURL",ExitPathway.PathwaysImageURL },
                    {"@BuildingID",ExitPathway.BuildingID}

               };

                ExitPathway.BuildingID = db.Execute_Insert_Stored_Procedure("ExitPathways_Insert", sp_params);
                if (ExitPathway.BuildingID > 0)
                {
                    return ExitPathway;
                }

                return null;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public bool ExitPathways_Update(string username, string password, ExitPathways ExitPathway)
        {
            try
            {
                bool flag = false;
                object[,] sp_params = new object[,]
               {
                    {"@username", username},
                    {"@password", password},
                    {"@PathwaysImage", ExitPathway.PathwaysImage },
                    {"@Description", ExitPathway.Description},
                    {"@BuildingID",ExitPathway.BuildingID},
                    {"@ExitPathwaysID",ExitPathway.ExitPathwaysID }

               };

                flag = db.Execute_Update_Delete_Stored_Procedure("ExitPathways_Update", sp_params);
                
                return flag;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public ExitPathwaysCollection ExitPathways_Select_All(string username, string password)
        {
            try
            {
                ExitPathwaysCollection exitPathway = new ExitPathwaysCollection();
                DateTime temp_date = new DateTime(0000 - 00 - 00);
                object[,] sp_params = new object[,]
                {
                    {"@username", username},
                    {"@password", password}
                };

                DataTable dt = db.Execute_Stored_Procedure_Show_Values("ExitPathways_Select_All", sp_params);

                if (dt.Rows.Count.Equals(0))
                {
                    return null;
                }
                else
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        exitPathway.Add(new ExitPathways
                        {
                            PathwaysImage = dr["PathwaysImage"] is DBNull ? smallArray : (byte[])dr["PathwaysImage"],
                            Description = dr["Description"] is DBNull ? "" : Convert.ToString(dr["Description"]),
                            BuildingID = dr["BuildingID"] is DBNull ? 0 : Convert.ToInt32(dr["BuildingID"])
                        });
                    }
                }
                return exitPathway;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public ExitPathwaysCollection ExitPathways_Select_By_BuildingID(string username, string password, int BuildingID)
        {
            try
            {
                ExitPathwaysCollection pathway = new ExitPathwaysCollection();
                DateTime temp_date = new DateTime(0000 - 00 - 00);
                object[,] sp_params = new object[,]
                {
                    {"@username", username},
                    {"@password", password},
                    {"@BuildingID",BuildingID }
                };

                DataTable dt = db.Execute_Stored_Procedure_Show_Values("ExitPathways_Select_By_BuildingID", sp_params);

                if (dt.Rows.Count.Equals(0))
                {
                    return null;
                }
                else
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        pathway.Add(new ExitPathways
                        {
                            PathwaysImage = dr["PathwaysImage"] is DBNull ? smallArray : (byte[])dr["PathwaysImage"],
                            Description = dr["Description"] is DBNull ? "" : Convert.ToString(dr["Description"]),
                            BuildingID = dr["BuildingID"] is DBNull ? 0 : Convert.ToInt32(dr["BuildingID"])
                        });
                    }
                }
                return pathway;
            }
            catch (Exception e)
            {
                return null;
            }
        }


    }
}