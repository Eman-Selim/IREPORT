using SC3_Alarm_Module.CBL;
using SC3_Alarm_Module.Entity;
using SC3_Alarm_Module.Collection;
using SC3_Alarm_Module.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SC3_Alarm_Module.SBL
{
    public class ZonesSBL
    {
        CHK Chk = new CHK();
        ZonesDAL ZonesDAL_Obj = new ZonesDAL();

        public bool Zones_Delete(string username, string password, int Path_id)
        {
            try
            {
                if (Chk.check_authority(username, password))
                {
                    return ZonesDAL_Obj.Zones_Delete(username, password, Path_id);
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

        public Zones Zones_Insert(string username, string password, Zones Zone)
        {
            try
            {
                if (Chk.check_authority(username, password))
                {
                    return ZonesDAL_Obj.Zones_Insert(username, password, Zone);
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

        public ZonesCollection Zones_Select(string username, string password, int zoneid)
        {
            try
            {
                if (Chk.check_authority(username, password))
                {
                    return ZonesDAL_Obj.Zones_Select(username, password, zoneid);
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

        public ZonesCollection Zones_Select_All(string username, string password)
        {
            try
            {
                if (Chk.check_authority(username, password))
                {
                    return ZonesDAL_Obj.Zones_Select_All(username, password);
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

        public ZonesCollection Zones_Select_BySchedule_Id(string username, string password, int Schedules_Id)
        {
            try
            {
                if (Chk.check_authority(username, password))
                {
                    return ZonesDAL_Obj.Zones_Select_BySchedule_Id(username, password, Schedules_Id);
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


        public ZonesCollection Zones_SelectByUserId(string username, string password, int userid)
        {
            try
            {
                if (Chk.check_authority(username, password))
                {
                    return ZonesDAL_Obj.Zones_SelectByUserId(username, password, userid);
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

        public bool Zones_Update(string username, string password, Zones Zone)
        {
            try
            {
                if (Chk.check_authority(username, password))
                {
                    return ZonesDAL_Obj.Zones_Update(username, password, Zone);
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