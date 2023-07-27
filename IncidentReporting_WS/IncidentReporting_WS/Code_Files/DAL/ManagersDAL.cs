using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IncidentReporting_WS.Code_Files.ENL;
using IncidentReporting_WS.Code_Files.COL;
using System.Data;

namespace IncidentReporting_WS.Code_Files.DAL
{
    public class ManagersDAL
    {
        DBL.DBL db = new DBL.DBL();
        byte[] smallArray = new byte[] { 0x20, 0x20 };

        public bool Managers_Delete(string username, string password, int ManagerID)
        {
            try
            {
                object[,] sp_Params = new object[,]
                {
                    {"@username", username},
                    {"@password", password},
                    {"@ManagerID", ManagerID}
                };
                bool flag = db.Execute_Update_Delete_Stored_Procedure("Managers_Delete", sp_Params);
                return flag;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public Managers Managers_Insert(string username, string password, Managers managers)
        {
            try
            {
                bool flag = false;
                object[,] sp_params = new object[,]
               {
                    {"@username", username},
                    {"@password", password},
                    {"@Name", managers.Name},
                    {"@CurrentPosition", managers.CurrentPosition},
                    {"@PhoneNumber",managers.PhoneNumber },
                    {"@Info", managers.Info },
                    {"@CompanyID",managers.CompanyID }
               };

                managers.ManagerID = db.Execute_Insert_Stored_Procedure("Managers_Insert", sp_params);
                if (managers.ManagerID > 0)
                {
                    return managers;
                }

                return null;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public ManagersCollection Managers_Select_All(string username, string password)
        {
            try
            {
                ManagersCollection managers = new ManagersCollection();
                DateTime temp_date = new DateTime(0000 - 00 - 00);
                object[,] sp_params = new object[,]
                {
                    {"@username", username},
                    {"@password", password}
                };

                DataTable dt = db.Execute_Stored_Procedure_Show_Values("Managers_Select_All", sp_params);

                if (dt.Rows.Count.Equals(0))
                {
                    return null;
                }
                else
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        managers.Add(new Managers
                        {
                            Name = dr["Name"] is DBNull ? "" : Convert.ToString(dr["Name"]),
                            CurrentPosition = dr["CurrentPosition"] is DBNull ? "" : Convert.ToString(dr["CurrentPosition"]),
                            PhoneNumber = dr["PhoneNumber"] is DBNull ?"" : Convert.ToString(dr["PhoneNumber"]),
                            Info=dr["Info"] is DBNull?"" :Convert.ToString(dr["Info"]),
                            CompanyID = dr["CompanyID"] is DBNull ? 0 : Convert.ToInt32(dr["CompanyID"]),
                            ManagerID = dr["ManagerID"] is DBNull ? 0 : Convert.ToInt32(dr["ManagerID"])
                        });
                    }
                }
                return managers;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public ManagersCollection Managers_SelectByCompanyID(string username, string password, int CompanyID)
        {
            try
            {
                ManagersCollection managers = new ManagersCollection();
                DateTime temp_date = new DateTime(0000 - 00 - 00);
                object[,] sp_params = new object[,]
                {
                    {"@username", username},
                    {"@password", password},
                    {"@CompanyID",CompanyID }
                };

                DataTable dt = db.Execute_Stored_Procedure_Show_Values("Managers_SelectByCompanyID", sp_params);

                if (dt.Rows.Count.Equals(0))
                {
                    return null;
                }
                else
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        managers.Add(new Managers
                        {
                            Name = dr["Name"] is DBNull ? "" : Convert.ToString(dr["Name"]),
                            CurrentPosition = dr["CurrentPosition"] is DBNull ? "" : Convert.ToString(dr["CurrentPosition"]),
                            PhoneNumber = dr["PhoneNumber"] is DBNull ? "" : Convert.ToString(dr["PhoneNumber"]),
                            Info = dr["Info"] is DBNull ? "" : Convert.ToString(dr["Info"]),
                            CompanyID = dr["CompanyID"] is DBNull ? 0 : Convert.ToInt32(dr["CompanyID"]),
                            ManagerID=dr["ManagerID"] is DBNull? 0: Convert.ToInt32(dr["ManagerID"])
                        });
                    }
                }
                return managers;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public Managers Managers_SelectByManagerID(string username, string password, int ManagerID)
        {
            try
            {
                Managers managers = new Managers();
                DateTime temp_date = new DateTime(0000 - 00 - 00);
                object[,] sp_params = new object[,]
                {
                    {"@username", username},
                    {"@password", password},
                    {"@ManagerID",ManagerID }
                };

                DataTable dt = db.Execute_Stored_Procedure_Show_Values("Managers_SelectByManagerID", sp_params);

                if (dt.Rows.Count.Equals(0))
                {
                    return null;
                }
                else
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        managers=new Managers
                        {
                            Name = dr["Name"] is DBNull ? "" : Convert.ToString(dr["Name"]),
                            CurrentPosition = dr["CurrentPosition"] is DBNull ? "" : Convert.ToString(dr["CurrentPosition"]),
                            PhoneNumber = dr["PhoneNumber"] is DBNull ? "" : Convert.ToString(dr["PhoneNumber"]),
                            Info = dr["Info"] is DBNull ? "" : Convert.ToString(dr["Info"]),
                            CompanyID = dr["CompanyID"] is DBNull ? 0 : Convert.ToInt32(dr["CompanyID"]),
                            ManagerID = dr["ManagerID"] is DBNull ? 0 : Convert.ToInt32(dr["ManagerID"])
                        };
                    }
                }
                return managers;
            }
            catch (Exception e)
            {
                return null;
            }
        }


    }
}