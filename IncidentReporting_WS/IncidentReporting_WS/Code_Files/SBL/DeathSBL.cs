using System;
using IncidentReporting_WS.Code_Files.CBL;
using IncidentReporting_WS.Code_Files.COL;
using IncidentReporting_WS.Code_Files.DAL;
using IncidentReporting_WS.Code_Files.ENL;

namespace IncidentReporting_WS.Code_Files.SBL
{
	public class DeathSBL 
	{
        ChkCBL Chk = new ChkCBL();
        DeathDAL DeathDAL_Obj = new DeathDAL();

        public bool Death_Delete(string username, string password, int DeathID)
        {
            try
            {
                if (Chk.check_authority(username, password))
                {
                    return DeathDAL_Obj.Death_Delete( username, password, DeathID);
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

        public Death Death_Insert(string username, string password, Death death)
        {
            try
            {
                if (Chk.check_authority(username, password))
                {
                    return DeathDAL_Obj.Death_Insert( username, password, death);
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

        public DeathCollection Death_Select_All(string username, string password)
        {
            try
            {
                if (Chk.check_authority(username, password))
                {
                    return DeathDAL_Obj.Death_Select_All( username, password);
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

        public DeathCollection Death_Select_By_AccidentID(string username, string password, int AccidentID)
        {
            try
            {
                if (Chk.check_authority(username, password))
                {
                    return DeathDAL_Obj.Death_Select_By_AccidentID( username, password, AccidentID);
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

        public DeathCollection Death_Select_By_Age(string username, string password, int Age)
        {
            try
            {
                if (Chk.check_authority(username, password))
                {
                    return DeathDAL_Obj.Death_Select_By_Age( username, password, Age);
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

        public DeathCollection Death_Select_By_Civil_Military(string username, string password, string Civil_Military)
        {
            try
            {
                if (Chk.check_authority(username, password))
                {
                    return DeathDAL_Obj.Death_Select_By_Civil_Military( username, password, Civil_Military);
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

        public DeathCollection Death_Select_By_Date(string username, string password, DateTime Date)
        {
            try
            {
                if (Chk.check_authority(username, password))
                {
                    return DeathDAL_Obj.Death_Select_By_Date( username, password, Date);
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

        public DeathCollection Death_Select_By_DeathID(string username, string password, int DeathID)
        {
            try
            {
                if (Chk.check_authority(username, password))
                {
                    return DeathDAL_Obj.Death_Select_By_DeathID( username, password, DeathID);
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

        public DeathCollection Death_Select_By_Name(string username, string password, string Name)
        {
            try
            {
                if (Chk.check_authority(username, password))
                {
                    return DeathDAL_Obj.Death_Select_By_Name( username, password, Name);
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

        public DeathCollection Death_Select_By_Rank(string username, string password, string Rank)
        {
            try
            {
                if (Chk.check_authority(username, password))
                {
                    return DeathDAL_Obj.Death_Select_By_Rank( username, password, Rank);
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
