using System;
using SC3_Alarm_Module.DAL;
using SC3_Alarm_Module.Collection;
using SC3_Alarm_Module.CBL;
using SC3_Alarm_Module.Entity;

namespace SC3_Alarm_Module.SBL
{
    public class AlarmsSBL
    {
        CHK Chk = new CHK();

        AlarmsDAL AlarmsDAL_Obj = new AlarmsDAL();

        public bool Alarms_Delete_Row(string username, string password, int alarm_id)
        {
            try
            {
                if (Chk.check_authority(username,password))
                {
                    return AlarmsDAL_Obj.Alarms_Delete_Row(username, password,alarm_id);
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Alarms_Delete_User_AckAlarms(string username, string password)
        {
            try
            {
                if (Chk.check_authority(username,password))
                {
                    return AlarmsDAL_Obj.Alarms_Delete_User_AckAlarms(username, password);
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
      
        public bool Alarms_Delete_User_AllAlarms(string username , string password)
        {
            try
            {
                if (Chk.check_authority(username, password))
                {
                    return AlarmsDAL_Obj.Alarms_Delete_User_AllAlarms(username, password);
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Alarms Alarm_Insert(string username , string password,Alarms New_alarm)
        {
            try
            {
                if(Chk.check_authority(username,password))
                {
                    return AlarmsDAL_Obj.Alarms_Insert(username, password, New_alarm);
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

        public AlarmsCollection Alarms_Select(string username,string password,int alarm_id)
        {
            try
            {
                if(Chk.check_authority(username,password))
                {
                    return AlarmsDAL_Obj.Alarms_Select(username, password, alarm_id);
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

        public AlarmsCollection Alarms_Select_Date(string username, string password,DateTime from, DateTime to)
        {
            try
            {
                if(Chk.check_authority(username,password))
                {
                    return AlarmsDAL_Obj.Alarms_Select_Date(username, password, from, to);
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

        public AlarmsCollection Alarms_Select_VisibleAlarms(string username , string password)
        {
            try
            {
                if(Chk.check_authority(username,password))
                {
                    return AlarmsDAL_Obj.Alarms_Select_VisibleAlarms(username, password);
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

        public AlarmsCollection Alarm_Select_ALL(string username, string password)
        {
            try
            {
                if(Chk.check_authority(username,password))
                {
                    return AlarmsDAL_Obj.Alarms_Select_ALL(username, password);
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

        public AlarmsCollection Alarms_SelectByBuildingID(string username, string password, int building_ID)
        {
            try
            {
                if (Chk.check_authority(username, password))
                {
                    return AlarmsDAL_Obj.Alarms_SelectByBuildingID(username, password, building_ID);
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

        public AlarmsCollection Alarms_SelectByMovableID(string username, string password, int movable_ID)
        {
            try
            {
                if (Chk.check_authority(username, password))
                {
                    return AlarmsDAL_Obj.Alarms_SelectByMovableID(username, password, movable_ID);
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

        public bool Alarms_Update(string username,string password, Alarms upd_alarm)
        {
            try
            {
                if ( Chk.check_authority(username,password))
                {
                    return AlarmsDAL_Obj.Alarms_Update(username, password, upd_alarm);
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

        public bool Alarms_UpdateVisibility_User_AckAlarms(string username, string password)
        {
            try
            {
                if(Chk.check_authority(username,password))
                {
                    return AlarmsDAL_Obj.Alarms_UpdateVisibility_User_AckAlarms(username, password);
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Alarms_UpdateVisibility_User_AllAlarms(string username, string password)
        {
            try
            {
                if (Chk.check_authority(username, password))
                {
                    return AlarmsDAL_Obj.Alarms_UpdateVisibility_User_AllAlarms(username, password);
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}