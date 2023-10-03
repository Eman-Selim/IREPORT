using System;
using SC3_Alarm_Module.CBL;
using SC3_Alarm_Module.Entity;
using SC3_Alarm_Module.Collection;
using SC3_Alarm_Module.DAL;

namespace SC3_Alarm_Module.SBL
{
    public class Movable_Alarm_UnitSBL
    {
        CHK Chk = new CHK();

        Movable_Alarm_UnitDAL Movable_AU_Obj = new Movable_Alarm_UnitDAL();

        public bool Movable_AlarmUnit_Delete(string username, string password, int movable_alarmunit_id)
        {
            try
            {
                if (Chk.check_authority(username, password))
                {

                    return Movable_AU_Obj.Movable_AlarmUnit_Delete(username, password, movable_alarmunit_id);
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

        public bool Movable_AlarmUnit_Delete_All(string username, string password)
        {
            try
            {
                if (Chk.check_authority(username, password))
                {
                    return Movable_AU_Obj.Movable_AlarmUnit_Delete_All(username, password);
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


        public Movable_Alarm_Unit Movable_AlarmUnit_Insert(string username, string password, Movable_Alarm_Unit New_Movable_AU)
        {
            try
            {
                if (Chk.check_authority(username, password))
                {
                    return Movable_AU_Obj.Movable_AlarmUnit_Insert(username, password, New_Movable_AU);
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


        public Movable_Alarm_UnitCollection Movable_AlarmUnit_Select(string username, string password, int movable_alarmunit_id)

        {
            try
            {
                if (Chk.check_authority(username, password))
                {
                    return Movable_AU_Obj.Movable_AlarmUnit_Select(username, password, movable_alarmunit_id);
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

        public Movable_Alarm_UnitCollection Movable_AlarmUnit_Select_ALL(string username, string password)
        {
            try
            {
                if (Chk.check_authority(username, password))
                {
                    return Movable_AU_Obj.Movable_AlarmUnit_Select_ALL(username, password);
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

        public Movable_Alarm_UnitCollection Movable_AlarmUnit_SelectByUsername(string username, string password)
        {
            try
            {
                if (Chk.check_authority(username, password))
                {
                    return Movable_AU_Obj.Movable_AlarmUnit_SelectByUsername(username, password);
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

        public bool Movable_AlarmUnit_Update(string username, string password, Movable_Alarm_Unit upd_Movable_AU)
        {
            try
            {

                if (Chk.check_authority(username, password))
                {
                    return Movable_AU_Obj.Movable_AlarmUnit_Update(username, password, upd_Movable_AU);
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

        public bool Movable_AlarmUnit_Update_User(string username, string password, Movable_Alarm_Unit upd_Movable_AU)
        {
            try
            {

                if (Chk.check_authority(username, password))
                {
                    return Movable_AU_Obj.Movable_AlarmUnit_Update_User(username, password, upd_Movable_AU);
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