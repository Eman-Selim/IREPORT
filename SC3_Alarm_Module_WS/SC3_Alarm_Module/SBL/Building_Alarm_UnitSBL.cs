using System;
using SC3_Alarm_Module.CBL;
using SC3_Alarm_Module.Entity;
using SC3_Alarm_Module.Collection;
using SC3_Alarm_Module.DAL;

namespace SC3_Alarm_Module.SBL
{
    public class Building_Alarm_UnitSBL
    {
        CHK Chk = new CHK();

        Building_Alarm_UnitDAL Building_AU_Obj = new Building_Alarm_UnitDAL();

        public bool Building_AlarmUnit_Delete(string username, string password, int building_alarmunit_id )
        {
            try
            {
                if (Chk.check_authority(username, password))
                {

                    return Building_AU_Obj.Building_AlarmUnit_Delete(username, password, building_alarmunit_id);
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

        public bool Building_AlarmUnit_Delete_All(string username, string password)
        {
            try
            {
                if(Chk.check_authority(username,password))
                {
                    return Building_AU_Obj.Building_AlarmUnit_Delete_All(username, password);
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


        public Building_Alarm_Unit Building_AlarmUnit_Insert(string username ,string password, Building_Alarm_Unit New_Building_AU)
        {
            try
            {
               if(Chk.check_authority(username,password))
                {
                    return Building_AU_Obj.Building_AlarmUnit_Insert(username, password, New_Building_AU);
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


        public Building_Alarm_UnitCollection Building_AlarmUnit_Select(string username, string password, int building_alarmunit_id)

        {
            try
            {
                if(Chk.check_authority(username,password))
                {
                    return Building_AU_Obj.Building_AlarmUnit_Select(username, password, building_alarmunit_id);
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

        public Building_Alarm_UnitCollection Building_AlarmUnit_Select_ALL(string username,string password)
        {
            try
            {
                if(Chk.check_authority(username,password))
                {
                    return Building_AU_Obj.Building_AlarmUnit_Select_ALL(username, password);
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

        public Building_Alarm_UnitCollection Building_AlarmUnit_SelectByUsername(string username, string password)
        {
            try
            {
                if (Chk.check_authority(username, password))
                {
                    return Building_AU_Obj.Building_AlarmUnit_SelectByUsername(username, password);
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

        public bool Building_AlarmUnit_Update(string username, string password, Building_Alarm_Unit upd_Building_AU)
        {
            try
            {
                
                    if(Chk.check_authority(username,password))
                    {
                    return Building_AU_Obj.Building_AlarmUnit_Update(username, password, upd_Building_AU);
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