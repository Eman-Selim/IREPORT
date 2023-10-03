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
    public class Forward_DestinationsSBL
    {
        CHK Chk = new CHK();
        Forward_DestinationsDAL Forward_DestinationsDAL_Obj = new Forward_DestinationsDAL();

        public Forward_Destinations Forward_Destinations_Insert(string username, string password, Forward_Destinations New_Forward_Destination)
        {
            try
            {
                if (Chk.check_authority(username, password))
                {
                    return Forward_DestinationsDAL_Obj.Forward_Destinations_Insert(username, password, New_Forward_Destination);
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

        public bool Forward_Destinations_Update(string username, string password, Forward_Destinations Upd_Forward_Destination)
        {
            try
            {
                if (Chk.check_authority(username, password))
                {
                    return Forward_DestinationsDAL_Obj.Forward_Destinations_Update(username, password, Upd_Forward_Destination);
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

        public Forward_DestinationsCollection Forward_Destinations_Select(string username, string password, int destination_id)
        {
            try
            {
                if (Chk.check_authority(username, password))
                {
                    return Forward_DestinationsDAL_Obj.Forward_Destinations_Select(username, password, destination_id);
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
        public Forward_DestinationsCollection Forward_Destinations_SelectBy_MU_ID_and_AT_ID(string username, string password, int mu_id,int at_id)
        {
            try
            {
                if (Chk.check_authority(username, password))
                {
                    return Forward_DestinationsDAL_Obj.Forward_Destinations_SelectBy_MU_ID_and_AT_ID(username, password, mu_id,at_id);
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

        public Forward_DestinationsCollection Forward_Destinations_SelectBy_BU_ID_and_AT_ID(string username, string password, int bu_id, int at_id)
        {
            try
            {
                if (Chk.check_authority(username, password))
                {
                    return Forward_DestinationsDAL_Obj.Forward_Destinations_SelectBy_BU_ID_and_AT_ID(username, password, bu_id, at_id);
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

        public Forward_DestinationsCollection Forward_Destinations_Select_All(string username, string password)
        {
            try
            {
                if (Chk.check_authority(username, password))
                {
                    return Forward_DestinationsDAL_Obj.Forward_Destinations_Select_All(username, password);
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

        public bool Forward_Destinations_Delete(string username, string password, int destination_id)
        {
            try
            {
                if (Chk.check_authority(username, password))
                {
                    return Forward_DestinationsDAL_Obj.Forward_Destinations_Delete(username, password, destination_id);
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

        public bool Forward_Destinations_Delete_All(string username, string password)
        {
            try
            {
                if (Chk.check_authority(username, password))
                {
                    return Forward_DestinationsDAL_Obj.Forward_Destinations_Delete_All(username, password);
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