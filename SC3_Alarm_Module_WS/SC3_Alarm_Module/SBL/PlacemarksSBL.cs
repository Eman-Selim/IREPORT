using System;
using SC3_Alarm_Module.CBL;
using SC3_Alarm_Module.Entity;
using SC3_Alarm_Module.Collection;
using SC3_Alarm_Module.DAL;

namespace SC3_Alarm_Module.SBL
{
    public class PlacemarksSBL
    {
        CHK Chk = new CHK();
        PlacemarksDAL PlacemarksDAL_Obj = new PlacemarksDAL();

        public bool Placemarks_Delete(string username, string password, int placemark_id, int layer_id)
        {
            try
            {
                if (Chk.check_authority(username, password))
                {
                    return PlacemarksDAL_Obj.Placemarks_Delete(username, password, placemark_id, layer_id);
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

        public Placemarks Placemarks_Insert(string username, string password, Placemarks Placemark)
        {
            try
            {
                if (Chk.check_authority(username, password))
                {
                    return PlacemarksDAL_Obj.Placemarks_Insert(username, password, Placemark);
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

        public bool Placemarks_Insert_Bulk(string username, string password, PlacemarksCollection Placemarks_Array)
        {
            try
            {
                if (Chk.check_authority(username, password))
                {
                    return PlacemarksDAL_Obj.Placemarks_Insert_Bulk(username, password, Placemarks_Array);
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

        
        public PlacemarksCollection Placemarks_Select(string username, string password, int placemarkid)
        {
            try
            {
                if (Chk.check_authority(username, password))
                {
                    return PlacemarksDAL_Obj.Placemarks_Select(username, password, placemarkid);
                }
                else
                {
                    return null;
                }
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public PlacemarksCollection Placemarks_SelectByLayerId(string username, string password, int layerid)
        {
            try
            {
                if (Chk.check_authority(username, password))
                {
                    return PlacemarksDAL_Obj.Placemarks_SelectByLayerId(username, password, layerid);
                }
                else
                {
                    return null;
                }
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public PlacemarksCollection Placemarks_SelectByUserId(string username, string password, int userid)
        {
            try
            {
                if (Chk.check_authority(username, password))
                {
                    return PlacemarksDAL_Obj.Placemarks_SelectByUserId(username, password, userid);
                }
                else
                {
                    return null;
                }
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public bool Placemarks_Update(string username, string password, Placemarks Placemark)
        {
            try
            {
                if (Chk.check_authority(username, password))
                {
                    return PlacemarksDAL_Obj.Placemarks_Update(username, password, Placemark);
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

        public bool Placemarks_Update_Bulk(string username, string password, PlacemarksCollection Placemarks_Array)
        {
            try
            {
                if (Chk.check_authority(username, password))
                {
                    return PlacemarksDAL_Obj.Placemarks_Update_Bulk(username, password, Placemarks_Array);
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

    }
}