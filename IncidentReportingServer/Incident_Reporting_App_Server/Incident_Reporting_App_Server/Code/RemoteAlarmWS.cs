using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Incident_Reporting_App_Server.RemoteAlarm;
using Incident_Reporting_App_Server.Code;

namespace Incident_Reporting_App_Server.Code
{
    class RemoteAlarmWS
    {
        Remote_Alarms_Web_Service Alarm_WS = new Remote_Alarms_Web_Service();

        public IncomingAlarm[] Alarms_Select_ALL(int User_id,string username, string password)
        {
            try
            {
                return Alarm_WS.User_Load_Incoming_Alarms(User_id,username, password);
            }
            catch (Exception ex)
            {
                Auditing.Error(ex.Message);
                return null;
            }
        }

        public Company Company_Select(int User_id, string username, string password, int Radio_Number)
        {
            try
            {
                return Alarm_WS.Company_Select(User_id, username, password, Radio_Number);
            }
            catch (Exception ex)
            {
                Auditing.Error(ex.Message);
                return null;
            }
        }
        //public Building_Alarm_Unit[] Building_AlarmUnit_Select(string username, string password, int id)
        //{
        //    try
        //    {
        //        return Alarm_WS.Building_AlarmUnit_Select(username, password, id);
        //    }
        //    catch (Exception ex)
        //    {
        //        Auditing.Error(ex.Message);
        //        return null;
        //    }
        //}
    }
}
