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
    public class Alarm_TypeSBL
    {
        CHK Chk = new CHK();
        Alarm_TypeDAL ALarm_TypeDAL_Obj = new Alarm_TypeDAL();

        public bool Alarm_Type_Delete(string username, string password, int alarm_type_id)
        {
            try
            {
                if(Chk.check_authority(username,password))
                {
                    return ALarm_TypeDAL_Obj.Alarm_Type_Delete(username, password, alarm_type_id);
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

        public Alarm_Type Alarm_Type_Insert(string username, string password, Alarm_Type New_Alarm_Type)
        {
            try
            {
                if(Chk.check_authority(username,password))
                {
                   return ALarm_TypeDAL_Obj.Alarm_Type_Insert(username, password, New_Alarm_Type);
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

        public Alarm_TypeCollection Alarm_Type_Select(string username, string password, int alarm_type_id)
        {
            try
            {
                if(Chk.check_authority(username,password))
                {
                    return ALarm_TypeDAL_Obj.Alarm_Type_Select(username, password, alarm_type_id);
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

        public Alarm_TypeCollection Alarm_Type_Select_All(string username, string password)
        {
            try
            {
                if(Chk.check_authority(username,password))
                    {
                    return ALarm_TypeDAL_Obj.Alarm_Type_Select_All(username, password);
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

        public bool Alarm_Type_Update(string username, string password, Alarm_Type Upd_Alarm_Type)
        {
            try
            {
                if(Chk.check_authority(username,password))
                {
                    return ALarm_TypeDAL_Obj.Alarm_Type_Update(username, password, Upd_Alarm_Type);
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