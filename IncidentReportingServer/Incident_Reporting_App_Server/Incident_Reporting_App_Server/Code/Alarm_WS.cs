using Incident_Reporting_App_Server.localhost1;
using SDS_Remote_Control_Application_Server.Code;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Incident_Reporting_App_Server.Code
{
    class Alarm_WS
    {
        SC3_Alarm_Module_WS SC3_Alarm_WS_Obj = new SC3_Alarm_Module_WS();


        #region Users

        public Alarms[] Alarms_Select_ALL(string username, string password )
        {
            try
            {
                return SC3_Alarm_WS_Obj.Alarms_Select_ALL(username, password );
            }
            catch (Exception ex)
            {
                Auditing.Error(ex.Message);
                return null;
            }
        }


        #endregion
    }


}
