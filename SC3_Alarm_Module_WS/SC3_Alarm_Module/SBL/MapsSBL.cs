using SC3_Alarm_Module.CBL;
using SC3_Alarm_Module.Collection;
using SC3_Alarm_Module.DAL;
using SC3_Alarm_Module.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SC3_Alarm_Module.SBL
{
    public class MapsSBL
    {
        CHK Chk = new CHK();
        MapsDAL MapsDAL_Obj = new MapsDAL();

        public bool Maps_Delete(string username, string password, int map_id)
        {
            try
            {
                if(Chk.check_authority(username,password))
                {
                    return MapsDAL_Obj.Maps_Delete(username, password, map_id);
                }
                else
                {
                    return false;
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public Maps Maps_Insert(string username, string password, Maps Map)
        {
            try
            {
                if(Chk.check_authority(username,password))
                {
                    return MapsDAL_Obj.Maps_Insert(username, password, Map);
                }
                else
                {
                    return null;
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public MapsCollection Maps_Select(string username, string password, int map_id)
        {
            try
            {
                if(Chk.check_authority(username,password))
                {
                    return MapsDAL_Obj.Maps_Select(username, password, map_id);
                }
                else
                {
                    return null;
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public MapsCollection Maps_SelectAll(string username, string password)
        {
            try
            {
                if(Chk.check_authority(username,password))
                {
                    return MapsDAL_Obj.Maps_SelectAll(username, password);
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Maps_Update(string username, string password, Maps Upd_Map)
        {
            try
            {
                if(Chk.check_authority(username,password))
                {
                    return MapsDAL_Obj.Maps_Update(username, password, Upd_Map);
                }
                else
                {
                    return false;
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}