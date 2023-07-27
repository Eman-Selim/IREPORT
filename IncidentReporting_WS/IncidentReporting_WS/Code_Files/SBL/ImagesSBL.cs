using System;
using IncidentReporting_WS.Code_Files.CBL;
using IncidentReporting_WS.Code_Files.COL;
using IncidentReporting_WS.Code_Files.DAL;
using IncidentReporting_WS.Code_Files.ENL;

namespace IncidentReporting_WS.Code_Files.SBL
{
	public class ImagesSBL 
	{
        ChkCBL Chk = new ChkCBL();
        ImagesDAL ImagesDAL_Obj = new ImagesDAL();

        public Images Images_Insert(string username, string password, Images Images)
        {
            try
            {
                if (Chk.check_authority(username, password))
                {
                    return ImagesDAL_Obj.Images_Insert( username, password, Images);
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

        public ImagesCollection Images_Select_All(string username, string password)
        {
            try
            {
                if (Chk.check_authority(username, password))
                {
                    return ImagesDAL_Obj.Images_Select_All( username, password);
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

        public ImagesCollection Images_Select_By_BuildingID(string username, string password, int BuildingID)
        {
            try
            {
                if (Chk.check_authority(username, password))
                {
                    return ImagesDAL_Obj.Images_Select_By_BuildingID( username, password, BuildingID);
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

        public ImagesCollection Images_Select_By_ImageDescription(string username, string password, string ImageDescription)
        {
            try
            {
                if (Chk.check_authority(username, password))
                {
                    return ImagesDAL_Obj.Images_Select_By_ImageDescription(username, password, ImageDescription);
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
