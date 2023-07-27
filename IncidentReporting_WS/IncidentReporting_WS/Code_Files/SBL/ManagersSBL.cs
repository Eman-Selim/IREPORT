using System;
using IncidentReporting_WS.Code_Files.CBL;
using IncidentReporting_WS.Code_Files.COL;
using IncidentReporting_WS.Code_Files.DAL;
using IncidentReporting_WS.Code_Files.ENL;

namespace IncidentReporting_WS.Code_Files.SBL
{
    public class ManagersSBL
    {
        ChkCBL Chk = new ChkCBL();
        ManagersDAL ManagersDAL_Obj = new ManagersDAL();

        public bool Managers_Delete(string username, string password, int ManagerID)
        {
            try
            {
                if (Chk.check_authority(username, password))
                {
                    return ManagersDAL_Obj.Managers_Delete(username, password, ManagerID);
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public Managers Managers_Insert(string username, string password, Managers Manager)
        {
            try
            {
                if (Chk.check_authority(username, password))
                {
                    return ManagersDAL_Obj.Managers_Insert(username, password, Manager);
                }
                else
                {
                    return null;
                }
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
                if (Chk.check_authority(username, password))
                {
                    return ManagersDAL_Obj.Managers_Select_All(username, password);
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public ManagersCollection Managers_Select_By_CompanyID(string username, string password, int CompanyID)
        {
            try
            {
                if (Chk.check_authority(username, password))
                {
                    return ManagersDAL_Obj.Managers_SelectByCompanyID(username, password, CompanyID);
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public Managers Managers_SelectByManagerID(string username, string password, int ManagerID)
        {
            try
            {
                if (Chk.check_authority(username, password))
                {
                    return ManagersDAL_Obj.Managers_SelectByManagerID(username, password, ManagerID);
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
