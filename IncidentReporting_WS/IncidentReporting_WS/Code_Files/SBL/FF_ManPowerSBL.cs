using System;
using IncidentReporting_WS.Code_Files.CBL;
using IncidentReporting_WS.Code_Files.COL;
using IncidentReporting_WS.Code_Files.DAL;
using IncidentReporting_WS.Code_Files.ENL;

namespace IncidentReporting_WS.Code_Files.SBL
{
	public class FF_ManPowerSBL 
	{
        ChkCBL Chk = new ChkCBL();
        FF_ManPowerDAL FF_ManPowerDAL_Obj = new FF_ManPowerDAL();

        public bool FF_ManPower_Delete(string username, string password, int FF_ManPowerID)
        {
            try
            {
                if (Chk.check_authority(username, password))
                {
                    return FF_ManPowerDAL_Obj.FF_ManPower_Delete( username, password, FF_ManPowerID);
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
        public bool FF_ManPower_Update(string username, string password, FF_ManPower ManPower)
        {
            try
            {
                if (Chk.check_authority(username, password))
                {
                    return FF_ManPowerDAL_Obj.FF_ManPower_Update(username, password, ManPower);
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
        public FF_ManPower FF_ManPower_Insert(string username, string password, FF_ManPower ManPower)
        {
            try
            {
                if (Chk.check_authority(username, password))
                {
                    return FF_ManPowerDAL_Obj.FF_ManPower_Insert( username, password, ManPower);
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

        public FF_ManPowerCollection FF_ManPower_Select_All(string username, string password)
        {
            try
            {
                if (Chk.check_authority(username, password))
                {
                    return FF_ManPowerDAL_Obj.FF_ManPower_Select_All( username, password);
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

        public FF_ManPowerCollection FF_ManPower_Select_By_Area(string username, string password, string Area)
        {
            try
            {
                if (Chk.check_authority(username, password))
                {
                    return FF_ManPowerDAL_Obj.FF_ManPower_Select_By_Area( username, password, Area);
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

        public FF_ManPowerCollection FF_ManPower_Select_By_Availability(string username, string password, string Availability)
        {
            try
            {
                if (Chk.check_authority(username, password))
                {
                    return FF_ManPowerDAL_Obj.FF_ManPower_Select_By_Availability( username, password, Availability);
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

        public FF_ManPower FF_ManPower_Select_By_FF_ManPowerID(string username, string password, int FF_ManPowerID)
        {
            try
            {
                if (Chk.check_authority(username, password))
                {
                    return FF_ManPowerDAL_Obj.FF_ManPower_Select_By_FF_ManPowerID( username, password, FF_ManPowerID);
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

        public FF_ManPowerCollection FF_ManPower_Select_By_Job(string username, string password, string Job)
        {
            try
            {
                if (Chk.check_authority(username, password))
                {
                    return FF_ManPowerDAL_Obj.FF_ManPower_Select_By_Job( username, password, Job);
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

        public FF_ManPowerCollection FF_ManPower_Select_By_OfficerName(string username, string password, string OfficerName)
        {
            try
            {
                if (Chk.check_authority(username, password))
                {
                    return FF_ManPowerDAL_Obj.FF_ManPower_Select_By_OfficerName( username, password, OfficerName);
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

        public FF_ManPowerCollection FF_ManPower_Select_By_Point(string username, string password, string Point)
        {
            try
            {
                if (Chk.check_authority(username, password))
                {
                    return FF_ManPowerDAL_Obj.FF_ManPower_Select_By_Point( username, password, Point);
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

        public FF_ManPowerCollection FF_ManPower_Select_By_Rank(string username, string password, string Rank)
        {
            try
            {
                if (Chk.check_authority(username, password))
                {
                    return FF_ManPowerDAL_Obj.FF_ManPower_Select_By_Rank( username, password, Rank);
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

        public FF_ManPowerCollection FF_ManPower_Select_By_Sector(string username, string password, string Sector)
        {
            try
            {
                if (Chk.check_authority(username, password))
                {
                    return FF_ManPowerDAL_Obj.FF_ManPower_Select_By_Sector( username, password, Sector);
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

        public FF_ManPowerCollection FF_ManPower_Select_By_TimeSlot(string username, string password, string TimeSlot)
        {
            try
            {
                if (Chk.check_authority(username, password))
                {
                    return FF_ManPowerDAL_Obj.FF_ManPower_Select_By_TimeSlot( username, password, TimeSlot);
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

        public FF_ManPowerCollection FF_ManPower_Select_By_UserID(string username, string password, int UserID)
        {
            try
            {
                if (Chk.check_authority(username, password))
                {
                    return FF_ManPowerDAL_Obj.FF_ManPower_Select_By_UserID( username, password, UserID);
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

        public FF_ManPowerCollection FF_ManPower_Select_By_FF_ID(string username, string password, int FF_ID)
        {
            try
            {
                if (Chk.check_authority(username, password))
                {
                    return FF_ManPowerDAL_Obj.FF_ManPower_Select_By_FF_ID(username, password, FF_ID);
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
