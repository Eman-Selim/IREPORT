using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IncidentReporting_WS.Code_Files.ENL;
using IncidentReporting_WS.Code_Files.COL;
using System.Data;

namespace IncidentReporting_WS.Code_Files.DAL
{
    public class DangerousPlacesDAL
    {
        DBL.DBL db = new DBL.DBL();

        public DangerousPlaces DangerousPlaces_Insert(string username, string password, DangerousPlaces DangerousPlaces)
        {
            try
            {
                bool flag = false;
                object[,] sp_params = new object[,]
               {
                    {"@username", username},
                    {"@password", password},
                    {"@HazardousSubstance", DangerousPlaces.HazardousSubstance },
                    {"@Location", DangerousPlaces.Location},
                    {"@FireMediator",DangerousPlaces.FireMediator},
                    {"@CompanyID",DangerousPlaces.CompanyID },
                    {"@Image",DangerousPlaces.Image },
                    {"@ImageUrl",DangerousPlaces.ImageURL }
               };

                DangerousPlaces.DangerousPlaceID = db.Execute_Insert_Stored_Procedure("DangerousPlaces_Insert", sp_params);
                if (DangerousPlaces.DangerousPlaceID > 0)
                {
                    return DangerousPlaces;
                }

                return null;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public DangerousPlaces DangerousPlaces_Update(string username, string password, DangerousPlaces DangerousPlaces)
        {
            try
            {
                bool flag = false;
                object[,] sp_params = new object[,]
               {
                    {"@username", username},
                    {"@password", password},
                    {"@HazardousSubstance", DangerousPlaces.HazardousSubstance },
                    {"@Location", DangerousPlaces.Location},
                    {"@FireMediator",DangerousPlaces.FireMediator},
                    {"@CompanyID",DangerousPlaces.CompanyID },
                    {"@Image",DangerousPlaces.Image },
                    {"@DangerousPlaceID",DangerousPlaces.DangerousPlaceID },
                    {"@ImageUrl",DangerousPlaces.ImageURL }
               };

                DangerousPlaces.DangerousPlaceID = db.Execute_Insert_Stored_Procedure("DangerousPlaces_Update", sp_params);
                if (DangerousPlaces.DangerousPlaceID > 0)
                {
                    return DangerousPlaces;
                }

                return null;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public DangerousPlacesCollection DangerousPlaces_Select_All(string username, string password)
        {
            try
            {
                DangerousPlacesCollection place = new DangerousPlacesCollection();
                DateTime temp_date = new DateTime(0000 - 00 - 00);
                object[,] sp_params = new object[,]
                {
                    {"@username", username},
                    {"@password", password}
                };

                DataTable dt = db.Execute_Stored_Procedure_Show_Values("DangerousPlaces_Select_All", sp_params);

                if (dt.Rows.Count.Equals(0))
                {
                    return null;
                }
                else
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        place.Add(new DangerousPlaces
                        {
                            HazardousSubstance = Convert.ToString(dr["HazardousSubstance"]),
                            Location = Convert.ToString(dr["Location"]),
                            FireMediator = Convert.ToString(dr["FireMediator"]),
                            CompanyID = Convert.ToInt32(dr["CompanyID"]),
                            Image = (byte[])dr["Image"],
                            DangerousPlaceID = Convert.ToInt32(dr["DangerousPlaceID"])
                        });
                    }
                }
                return place;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public DangerousPlacesCollection DangerousPlaces_Select_By_CompanyID(string username, string password, int CompanyID)
        {
            try
            {
                DangerousPlacesCollection place = new DangerousPlacesCollection();
                DateTime temp_date = new DateTime(0000 - 00 - 00);
                object[,] sp_params = new object[,]
                {
                    {"@username", username},
                    {"@password", password},
                    {"@CompanyID",CompanyID }
                };

                DataTable dt = db.Execute_Stored_Procedure_Show_Values("DangerousPlaces_Select_By_CompanyID", sp_params);

                if (dt.Rows.Count.Equals(0))
                {
                    return null;
                }
                else
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        place.Add( new DangerousPlaces
                        {
                            HazardousSubstance = Convert.ToString(dr["HazardousSubstance"]),
                            Location = Convert.ToString(dr["Location"]),
                            FireMediator = Convert.ToString(dr["FireMediator"]),
                            CompanyID = Convert.ToInt32(dr["CompanyID"]),
                            Image = (byte[])dr["Image"],
                            DangerousPlaceID = Convert.ToInt32(dr["DangerousPlaceID"])
                        });
                    }
                }
                return place;
            }
            catch (Exception e)
            {
                return null;
            }
        }
        public DangerousPlaces DangerousPlaces_Select_By_ID(string username, string password, int DangerousPlaceID)
        {
            try
            {
                DangerousPlaces place = new DangerousPlaces();
                DateTime temp_date = new DateTime(0000 - 00 - 00);
                object[,] sp_params = new object[,]
                {
                    {"@username", username},
                    {"@password", password},
                    {"@DangerousPlaceID",DangerousPlaceID }
                };

                DataTable dt = db.Execute_Stored_Procedure_Show_Values("DangerousPlaces_Select_By_ID", sp_params);

                if (dt.Rows.Count.Equals(0))
                {
                    return null;
                }
                else
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        place=new DangerousPlaces
                        {
                            HazardousSubstance = Convert.ToString(dr["HazardousSubstance"]),
                            Location = Convert.ToString(dr["Location"]),
                            FireMediator = Convert.ToString(dr["FireMediator"]),
                            CompanyID = Convert.ToInt32(dr["CompanyID"]),
                            Image = (byte[])dr["Image"],
                            DangerousPlaceID = Convert.ToInt32(dr["DangerousPlaceID"])
                        };
                    }
                }
                return place;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public DangerousPlacesCollection DangerousPlaces_Select_By_FireMediator(string username, string password, string FireMediator)
        {
            try
            {
                DangerousPlacesCollection place = new DangerousPlacesCollection();
                DateTime temp_date = new DateTime(0000 - 00 - 00);
                object[,] sp_params = new object[,]
                {
                    {"@username", username},
                    {"@password", password},
                    {"@FireMediator",FireMediator }
                };

                DataTable dt = db.Execute_Stored_Procedure_Show_Values("DangerousPlaces_Select_By_FireMediator", sp_params);

                if (dt.Rows.Count.Equals(0))
                {
                    return null;
                }
                else
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        place.Add(new DangerousPlaces
                        {
                            HazardousSubstance = Convert.ToString(dr["HazardousSubstance"]),
                            Location = Convert.ToString(dr["Location"]),
                            FireMediator = Convert.ToString(dr["FireMediator"]),
                            CompanyID = Convert.ToInt32(dr["CompanyID"]),
                            Image = (byte[])dr["Image"],
                            DangerousPlaceID = Convert.ToInt32(dr["DangerousPlaceID"])
                        });
                    }
                }
                return place;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public DangerousPlacesCollection DangerousPlaces_Select_By_HazardousSubstance(string username, string password, string HazardousSubstance)
        {
            try
            {
                DangerousPlacesCollection place = new DangerousPlacesCollection();
                DateTime temp_date = new DateTime(0000 - 00 - 00);
                object[,] sp_params = new object[,]
                {
                    {"@username", username},
                    {"@password", password},
                    {"@HazardousSubstance",HazardousSubstance }
                };

                DataTable dt = db.Execute_Stored_Procedure_Show_Values("DangerousPlaces_Select_By_HazardousSubstance", sp_params);

                if (dt.Rows.Count.Equals(0))
                {
                    return null;
                }
                else
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        place.Add(new DangerousPlaces
                        {
                            HazardousSubstance = Convert.ToString(dr["HazardousSubstance"]),
                            Location = Convert.ToString(dr["Location"]),
                            FireMediator = Convert.ToString(dr["FireMediator"]),
                            CompanyID = Convert.ToInt32(dr["CompanyID"]),
                            Image = (byte[])dr["Image"],
                            DangerousPlaceID = Convert.ToInt32(dr["DangerousPlaceID"])
                        });
                    }
                }
                return place;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public DangerousPlacesCollection DangerousPlaces_Select_By_Location(string username, string password, string Location)
        {
            try
            {
                DangerousPlacesCollection place = new DangerousPlacesCollection();
                DateTime temp_date = new DateTime(0000 - 00 - 00);
                object[,] sp_params = new object[,]
                {
                    {"@username", username},
                    {"@password", password},
                    {"@Location",Location }
                };

                DataTable dt = db.Execute_Stored_Procedure_Show_Values("DangerousPlaces_Select_By_Location", sp_params);

                if (dt.Rows.Count.Equals(0))
                {
                    return null;
                }
                else
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        place.Add(new DangerousPlaces
                        {
                            HazardousSubstance = Convert.ToString(dr["HazardousSubstance"]),
                            Location = Convert.ToString(dr["Location"]),
                            FireMediator = Convert.ToString(dr["FireMediator"]),
                            CompanyID = Convert.ToInt32(dr["CompanyID"]),
                            Image = (byte[])dr["Image"],
                            DangerousPlaceID = Convert.ToInt32(dr["DangerousPlaceID"])
                        });
                    }
                }
                return place;
            }
            catch (Exception e)
            {
                return null;
            }
        }


    }
}