using System;
using IncidentReporting_WS.Code_Files.CBL;
using IncidentReporting_WS.Code_Files.COL;
using IncidentReporting_WS.Code_Files.DAL;
using IncidentReporting_WS.Code_Files.ENL;

namespace IncidentReporting_WS.Code_Files.SBL
{
	public class DangerousPlacesSBL 
	{
        ChkCBL Chk = new ChkCBL();
        DangerousPlacesDAL DangerousPlacesDAL_Obj = new DangerousPlacesDAL();

        public DangerousPlaces DangerousPlaces_Insert(string username, string password, DangerousPlaces DangerousPlaces)
        {
            try
            {
                if (Chk.check_authority(username, password))
                {
                    return DangerousPlacesDAL_Obj.DangerousPlaces_Insert( username, password, DangerousPlaces);
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

        public bool DangerousPlaces_Update(string username, string password, DangerousPlaces DangerousPlaces)
        {
            try
            {
                if (Chk.check_authority(username, password))
                {
                    return DangerousPlacesDAL_Obj.DangerousPlaces_Update(username, password, DangerousPlaces);
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

        public DangerousPlacesCollection DangerousPlaces_Select_All(string username, string password)
        {
            try
            {
                if (Chk.check_authority(username, password))
                {
                    return DangerousPlacesDAL_Obj.DangerousPlaces_Select_All( username, password);
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

        public DangerousPlacesCollection DangerousPlaces_Select_By_CompanyID(string username, string password, int CompanyID)
        {
            try
            {
                if (Chk.check_authority(username, password))
                {
                    return DangerousPlacesDAL_Obj.DangerousPlaces_Select_By_CompanyID( username, password, CompanyID);
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

        public DangerousPlaces DangerousPlaces_Select_By_ID(string username, string password, int DangerousPlaceID)
        {
            try
            {
                if (Chk.check_authority(username, password))
                {
                    return DangerousPlacesDAL_Obj.DangerousPlaces_Select_By_ID(username, password, DangerousPlaceID);
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

        public DangerousPlacesCollection DangerousPlaces_Select_By_FireMediator(string username, string password, string FireMediator)
        {
            try
            {
                if (Chk.check_authority(username, password))
                {
                    return DangerousPlacesDAL_Obj.DangerousPlaces_Select_By_FireMediator( username, password, FireMediator);
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

        public DangerousPlacesCollection DangerousPlaces_Select_By_HazardousSubstance(string username, string password, string HazardousSubstance)
        {
            try
            {
                if (Chk.check_authority(username, password))
                {
                    return DangerousPlacesDAL_Obj.DangerousPlaces_Select_By_HazardousSubstance( username, password, HazardousSubstance);
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

        public DangerousPlacesCollection DangerousPlaces_Select_By_Location(string username, string password, string Location)
        {
            try
            {
                if (Chk.check_authority(username, password))
                {
                    return DangerousPlacesDAL_Obj.DangerousPlaces_Select_By_Location( username, password, Location);
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
