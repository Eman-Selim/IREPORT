using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IncidentReporting_WS.Code_Files.ENL;
using IncidentReporting_WS.Code_Files.COL;
using System.Data;

namespace IncidentReporting_WS.Code_Files.DAL
{
    public class FloorsDAL
    {
        DBL.DBL db = new DBL.DBL();
        public Floors Floors_Insert(string username, string password, Floors Floors)
        {
            try
            {
                bool flag = false;
                object[,] sp_params = new object[,]
               {
                    {"@username", username},
                    {"@password", password},
                    {"@FloorNumber", Floors.FloorNumber },
                    {"@FireHydrantsNumber", Floors.FireHydrantsNumber},
                    {"@PowderExtinguishersNumber",Floors.PowderExtinguishersNumber},{"@CarbonDioxideExtinguishersNumbers",Floors.CarbonDioxideExtinguishersNumbers},
                    {"@FoamExtinguishersNumbers",Floors.FoamExtinguishersNumbers },
                    
                    {"@PowderExtinguishersWeight",Floors.PowderExtinguishersWeight },
                    {"@CarbonDioxideExtinguishersWeight",Floors.CarbonDioxideExtinguishersWeight},
                    {"@FoamExtinguishersWeight",Floors.FoamExtinguishersWeight},
                    {"@BuildingID",Floors.BuildingID }

               };

                Floors.FloorID = db.Execute_Insert_Stored_Procedure("Floors_Insert", sp_params);
                if (Floors.FloorID > 0)
                {
                    return Floors;
                }

                return null;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public bool Floor_Update(string username, string password, Floors Floors)
        {
            try
            {
                bool flag = false;
                object[,] sp_params = new object[,]
               {
                    {"@username", username},
                    {"@password", password},
                    {"@FloorNumber", Floors.FloorNumber },
                    {"@FireHydrantsNumber", Floors.FireHydrantsNumber},
                    {"@PowderExtinguishersNumber",Floors.PowderExtinguishersNumber},{"@CarbonDioxideExtinguishersNumbers",Floors.CarbonDioxideExtinguishersNumbers},
                    {"@FoamExtinguishersNumbers",Floors.FoamExtinguishersNumbers },
                    {"@PowderExtinguishersWeight",Floors.PowderExtinguishersWeight },
                    {"@CarbonDioxideExtinguishersWeight",Floors.CarbonDioxideExtinguishersWeight},
                    {"@FoamExtinguishersWeight",Floors.FoamExtinguishersWeight},
                    {"@BuildingID",Floors.BuildingID },
                    {"@FloorID",Floors.FloorID}

               };

                flag = db.Execute_Update_Delete_Stored_Procedure("Floor_Update", sp_params);
               
                    return flag;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public FloorsCollection Floors_Select_All(string username, string password)
        {
            try
            {
                FloorsCollection Floors = new FloorsCollection();
                DateTime temp_date = new DateTime(0000 - 00 - 00);
                object[,] sp_params = new object[,]
                {
                    {"@username", username},
                    {"@password", password}
                };

                DataTable dt = db.Execute_Stored_Procedure_Show_Values("Floors_Select_All", sp_params);

                if (dt.Rows.Count.Equals(0))
                {
                    return null;
                }
                else
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        Floors.Add(new Floors
                        {
                            FloorNumber = Convert.ToString(dr["FloorNumber"]),
                            FireHydrantsNumber = Convert.ToString(dr["FireHydrantsNumber"]),
                            PowderExtinguishersNumber = Convert.ToString(dr["PowderExtinguishersNumber"]),
                            CarbonDioxideExtinguishersNumbers = Convert.ToString(dr["CarbonDioxideExtinguishersNumbers"]),
                            FoamExtinguishersNumbers = Convert.ToString(dr["FoamExtinguishersNumbers"]),
                            PowderExtinguishersWeight = Convert.ToInt32(dr["PowderExtinguishersWeight"]),
                            CarbonDioxideExtinguishersWeight =Convert.ToInt32(dr["CarbonDioxideExtinguishersWeight"]),
                            
                            FoamExtinguishersWeight = Convert.ToInt32(dr["FoamExtinguishersWeight"]),
                            BuildingID= Convert.ToInt32(dr["BuildingID"]),
                            FloorID = Convert.ToInt32(dr["FloorID"])
                        });
                    }
                }
                return Floors;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public FloorsCollection Floors_Select_By_BuildingID(string username, string password, int BuildingID)
        {
            try
            {
                FloorsCollection Floors = new FloorsCollection();
                DateTime temp_date = new DateTime(0000 - 00 - 00);
                object[,] sp_params = new object[,]
                {
                    {"@username", username},
                    {"@password", password},
                    {"@BuildingID",BuildingID }
                };

                DataTable dt = db.Execute_Stored_Procedure_Show_Values("Floors_Select_By_BuildingID", sp_params);

                if (dt.Rows.Count.Equals(0))
                {
                    return null;
                }
                else
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        Floors.Add( new Floors
                        {
                            FloorNumber = Convert.ToString(dr["FloorNumber"]),
                            FireHydrantsNumber = Convert.ToString(dr["FireHydrantsNumber"]),
                            PowderExtinguishersNumber = Convert.ToString(dr["PowderExtinguishersNumber"]),
                            CarbonDioxideExtinguishersNumbers = Convert.ToString(dr["CarbonDioxideExtinguishersNumbers"]),
                            FoamExtinguishersNumbers = Convert.ToString(dr["FoamExtinguishersNumbers"]),
                            PowderExtinguishersWeight = Convert.ToInt32(dr["PowderExtinguishersWeight"]),
                            CarbonDioxideExtinguishersWeight = Convert.ToInt32(dr["CarbonDioxideExtinguishersWeight"]),

                            FoamExtinguishersWeight = Convert.ToInt32(dr["FoamExtinguishersWeight"]),
                            BuildingID = Convert.ToInt32(dr["BuildingID"]),
                            FloorID = Convert.ToInt32(dr["FloorID"])
                        });
                    }
                }
                return Floors;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public FloorsCollection Floors_Select_By_CarbonDioxideExtinguishersNumbers(string username, string password, String CarbonDioxideExtinguishersNumbers)
        {
            try
            {
                FloorsCollection Floors = new FloorsCollection();
                DateTime temp_date = new DateTime(0000 - 00 - 00);
                object[,] sp_params = new object[,]
                {
                    {"@username", username},
                    {"@password", password},
                    {"@CarbonDioxideExtinguishersNumbers",CarbonDioxideExtinguishersNumbers }
                };

                DataTable dt = db.Execute_Stored_Procedure_Show_Values("Floors_Select_By_CarbonDioxideExtinguishersNumbers", sp_params);

                if (dt.Rows.Count.Equals(0))
                {
                    return null;
                }
                else
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        Floors.Add(new Floors
                        {
                            FloorNumber = Convert.ToString(dr["FloorNumber"]),
                            FireHydrantsNumber = Convert.ToString(dr["FireHydrantsNumber"]),
                            PowderExtinguishersNumber = Convert.ToString(dr["PowderExtinguishersNumber"]),
                            CarbonDioxideExtinguishersNumbers = Convert.ToString(dr["CarbonDioxideExtinguishersNumbers"]),
                            FoamExtinguishersNumbers = Convert.ToString(dr["FoamExtinguishersNumbers"]),
                            PowderExtinguishersWeight = Convert.ToInt32(dr["PowderExtinguishersWeight"]),
                            CarbonDioxideExtinguishersWeight = Convert.ToInt32(dr["CarbonDioxideExtinguishersWeight"]),

                            FoamExtinguishersWeight = Convert.ToInt32(dr["FoamExtinguishersWeight"]),
                            BuildingID = Convert.ToInt32(dr["BuildingID"]),
                            FloorID = Convert.ToInt32(dr["FloorID"])
                        });
                    }
                }
                return Floors;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public FloorsCollection Floors_Select_By_PowderExtinguishersNumber(string username, string password, String PowderExtinguishersNumber)
        {
            try
            {
                FloorsCollection Floors = new FloorsCollection();
                DateTime temp_date = new DateTime(0000 - 00 - 00);
                object[,] sp_params = new object[,]
                {
                    {"@username", username},
                    {"@password", password},
                    {"@PowderExtinguishersNumber",PowderExtinguishersNumber }
                };

                DataTable dt = db.Execute_Stored_Procedure_Show_Values("Floors_Select_By_PowderExtinguishersNumber", sp_params);

                if (dt.Rows.Count.Equals(0))
                {
                    return null;
                }
                else
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        Floors.Add(new Floors
                        {
                            FloorNumber = Convert.ToString(dr["FloorNumber"]),
                            FireHydrantsNumber = Convert.ToString(dr["FireHydrantsNumber"]),
                            PowderExtinguishersNumber = Convert.ToString(dr["PowderExtinguishersNumber"]),
                            CarbonDioxideExtinguishersNumbers = Convert.ToString(dr["CarbonDioxideExtinguishersNumbers"]),
                            FoamExtinguishersNumbers = Convert.ToString(dr["FoamExtinguishersNumbers"]),
                            PowderExtinguishersWeight = Convert.ToInt32(dr["PowderExtinguishersWeight"]),
                            CarbonDioxideExtinguishersWeight = Convert.ToInt32(dr["CarbonDioxideExtinguishersWeight"]),

                            FoamExtinguishersWeight = Convert.ToInt32(dr["FoamExtinguishersWeight"]),
                            BuildingID = Convert.ToInt32(dr["BuildingID"]),
                            FloorID = Convert.ToInt32(dr["FloorID"])
                        });
                    }
                }
                return Floors;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public FloorsCollection Floors_Select_By_FoamExtinguishersNumbers(string username, string password, String FoamExtinguishersNumbers)
        {
            try
            {
                FloorsCollection Floors = new FloorsCollection();
                DateTime temp_date = new DateTime(0000 - 00 - 00);
                object[,] sp_params = new object[,]
                {
                    {"@username", username},
                    {"@password", password},
                    {"@FoamExtinguishersNumbers",FoamExtinguishersNumbers}
                };

                DataTable dt = db.Execute_Stored_Procedure_Show_Values("Floors_Select_By_FoamExtinguishersNumbers", sp_params);

                if (dt.Rows.Count.Equals(0))
                {
                    return null;
                }
                else
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        Floors.Add(new Floors
                        {
                            FloorNumber = Convert.ToString(dr["FloorNumber"]),
                            FireHydrantsNumber = Convert.ToString(dr["FireHydrantsNumber"]),
                            PowderExtinguishersNumber = Convert.ToString(dr["PowderExtinguishersNumber"]),
                            CarbonDioxideExtinguishersNumbers = Convert.ToString(dr["CarbonDioxideExtinguishersNumbers"]),
                            FoamExtinguishersNumbers = Convert.ToString(dr["FoamExtinguishersNumbers"]),
                            PowderExtinguishersWeight = Convert.ToInt32(dr["PowderExtinguishersWeight"]),
                            CarbonDioxideExtinguishersWeight = Convert.ToInt32(dr["CarbonDioxideExtinguishersWeight"]),

                            FoamExtinguishersWeight = Convert.ToInt32(dr["FoamExtinguishersWeight"]),
                            BuildingID = Convert.ToInt32(dr["BuildingID"]),
                            FloorID = Convert.ToInt32(dr["FloorID"])
                        });
                    }
                }
                return Floors;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public FloorsCollection Floors_Select_By_PowderExtinguishersWeight(string username, string password, int PowderExtinguishersWeight)
        {
            try
            {
                FloorsCollection Floors = new FloorsCollection();
                DateTime temp_date = new DateTime(0000 - 00 - 00);
                object[,] sp_params = new object[,]
                {
                    {"@username", username},
                    {"@password", password},
                    {"@PowderExtinguishersWeight",PowderExtinguishersWeight }
                };

                DataTable dt = db.Execute_Stored_Procedure_Show_Values("Floors_Select_By_PowderExtinguishersWeight", sp_params);

                if (dt.Rows.Count.Equals(0))
                {
                    return null;
                }
                else
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        Floors.Add(new Floors
                        {
                            FloorNumber = Convert.ToString(dr["FloorNumber"]),
                            FireHydrantsNumber = Convert.ToString(dr["FireHydrantsNumber"]),
                            PowderExtinguishersNumber = Convert.ToString(dr["PowderExtinguishersNumber"]),
                            CarbonDioxideExtinguishersNumbers = Convert.ToString(dr["CarbonDioxideExtinguishersNumbers"]),
                            FoamExtinguishersNumbers = Convert.ToString(dr["FoamExtinguishersNumbers"]),
                            PowderExtinguishersWeight = Convert.ToInt32(dr["PowderExtinguishersWeight"]),
                            CarbonDioxideExtinguishersWeight = Convert.ToInt32(dr["CarbonDioxideExtinguishersWeight"]),

                            FoamExtinguishersWeight = Convert.ToInt32(dr["FoamExtinguishersWeight"]),
                            BuildingID = Convert.ToInt32(dr["BuildingID"]),
                            FloorID = Convert.ToInt32(dr["FloorID"])
                        });
                    }
                }
                return Floors;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public FloorsCollection Floors_Select_By_CarbonDioxideExtinguishersWeight(string username, string password, int CarbonDioxideExtinguishersWeight)
        {
            try
            {
                FloorsCollection Floors = new FloorsCollection();
                DateTime temp_date = new DateTime(0000 - 00 - 00);
                object[,] sp_params = new object[,]
                {
                    {"@username", username},
                    {"@password", password},
                    {"@CarbonDioxideExtinguishersWeight",CarbonDioxideExtinguishersWeight}
                };

                DataTable dt = db.Execute_Stored_Procedure_Show_Values("Floors_Select_By_CarbonDioxideExtinguishersWeight", sp_params);

                if (dt.Rows.Count.Equals(0))
                {
                    return null;
                }
                else
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        Floors.Add(new Floors
                        {
                            FloorNumber = Convert.ToString(dr["FloorNumber"]),
                            FireHydrantsNumber = Convert.ToString(dr["FireHydrantsNumber"]),
                            PowderExtinguishersNumber = Convert.ToString(dr["PowderExtinguishersNumber"]),
                            CarbonDioxideExtinguishersNumbers = Convert.ToString(dr["CarbonDioxideExtinguishersNumbers"]),
                            FoamExtinguishersNumbers = Convert.ToString(dr["FoamExtinguishersNumbers"]),
                            PowderExtinguishersWeight = Convert.ToInt32(dr["PowderExtinguishersWeight"]),
                            CarbonDioxideExtinguishersWeight = Convert.ToInt32(dr["CarbonDioxideExtinguishersWeight"]),

                            FoamExtinguishersWeight = Convert.ToInt32(dr["FoamExtinguishersWeight"]),
                            BuildingID = Convert.ToInt32(dr["BuildingID"]),
                            FloorID = Convert.ToInt32(dr["FloorID"])
                        });
                    }
                }
                return Floors;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public FloorsCollection Floors_Select_By_FoamExtinguishersWeight(string username, string password, int FoamExtinguishersWeight)
        {
            try
            {
                FloorsCollection Floors = new FloorsCollection();
                DateTime temp_date = new DateTime(0000 - 00 - 00);
                object[,] sp_params = new object[,]
                {
                    {"@username", username},
                    {"@password", password},
                    {"@FoamExtinguishersWeight",FoamExtinguishersWeight}
                };

                DataTable dt = db.Execute_Stored_Procedure_Show_Values("Floors_Select_By_FoamExtinguishersWeight", sp_params);

                if (dt.Rows.Count.Equals(0))
                {
                    return null;
                }
                else
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        Floors.Add(new Floors
                        {
                            FloorNumber = Convert.ToString(dr["FloorNumber"]),
                            FireHydrantsNumber = Convert.ToString(dr["FireHydrantsNumber"]),
                            PowderExtinguishersNumber = Convert.ToString(dr["PowderExtinguishersNumber"]),
                            CarbonDioxideExtinguishersNumbers = Convert.ToString(dr["CarbonDioxideExtinguishersNumbers"]),
                            FoamExtinguishersNumbers = Convert.ToString(dr["FoamExtinguishersNumbers"]),
                            PowderExtinguishersWeight = Convert.ToInt32(dr["PowderExtinguishersWeight"]),
                            CarbonDioxideExtinguishersWeight = Convert.ToInt32(dr["CarbonDioxideExtinguishersWeight"]),

                            FoamExtinguishersWeight = Convert.ToInt32(dr["FoamExtinguishersWeight"]),
                            BuildingID = Convert.ToInt32(dr["BuildingID"]),
                            FloorID = Convert.ToInt32(dr["FloorID"])
                        });
                    }
                }
                return Floors;
            }
            catch (Exception e)
            {
                return null;
            }
        }

    }
}