using System;
using IncidentReporting_WS.Code_Files.CBL;
using IncidentReporting_WS.Code_Files.COL;
using IncidentReporting_WS.Code_Files.DAL;
using IncidentReporting_WS.Code_Files.ENL;

namespace IncidentReporting_WS.Code_Files.SBL
{
	public class ExitPathwaysSBL 
	{
        ChkCBL Chk = new ChkCBL();
        ExitPathwaysDAL ExitPathwaysDAL_Obj = new ExitPathwaysDAL();

        public ExitPathways ExitPathways_Insert(string username, string password, ExitPathways ExitPathway)
        {
            try
            {
                if (Chk.check_authority(username, password))
                {
                    return ExitPathwaysDAL_Obj.ExitPathways_Insert( username, password, ExitPathway);
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

        public ExitPathways ExitPathways_Update(string username, string password, ExitPathways ExitPathway)
        {
            try
            {
                if (Chk.check_authority(username, password))
                {
                    return ExitPathwaysDAL_Obj.ExitPathways_Update(username, password, ExitPathway);
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

        public ExitPathwaysCollection ExitPathways_Select_All(string username, string password)
        {
            try
            {
                if (Chk.check_authority(username, password))
                {
                    return ExitPathwaysDAL_Obj.ExitPathways_Select_All( username, password);
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

        public ExitPathwaysCollection ExitPathways_Select_By_BuildingID(string username, string password, int BuildingID)
        {
            try
            {
                if (Chk.check_authority(username, password))
                {
                    return ExitPathwaysDAL_Obj.ExitPathways_Select_By_BuildingID( username, password, BuildingID);
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
