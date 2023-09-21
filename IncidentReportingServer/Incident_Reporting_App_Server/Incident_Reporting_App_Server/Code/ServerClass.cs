using SDS_Remote_Control_Application_Server.Code;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Incident_Reporting_App_Server.localhost;
using Incident_Reporting_App_Server.localhost1;

namespace Incident_Reporting_App_Server.Code
{
    class ServerClass
    {
        public delegate void del_Update_Log(string text);
        public event del_Update_Log log_Handler;
        Incident_WS IncidentReporting_WS_Obj = new Incident_WS();
        Alarm_WS Alarm_WS_Obj = new Alarm_WS();

        #region Login Info
        public static string UserName { get; set; }
        public static string Password { get; set; }
        #endregion

        #region Connect
        

        /// <summary>
        /// Intializes the connectivty variables then starts the authentication thread
        /// </summary>
        /// <param name="userName">Contains the Super admin user name</param>
        /// <param name="passWord">Contains the Super admin Password</param>
        public bool Start_Server(string userName, string passWord)
        {
            try
            {
                UserName = userName;
                Password = passWord;
                if (IncidentReporting_WS_Obj.Users_SelectByNamePass(UserName, Password)!=null)
                {
                    return true;
                }
                return false;
            }
            catch (Exception exception1)
            {
                Auditing.Error(exception1.Message);
                return false;
            }
        }
        public IRUser Select_Account()
        {
            try
            {
                
                return IncidentReporting_WS_Obj.Users_SelectByNamePass(UserName, Password);
            }
            catch (Exception exception1)
            {
                Auditing.Error(exception1.Message);
                return null;
            }
        }

        public IRUser Select_User(int UserId)
        {
            try
            {
                return IncidentReporting_WS_Obj.Users_SelectByUserId(UserName, Password, UserId);
            }
            catch (Exception exception1)
            {
                Auditing.Error(exception1.Message);
                return null;
            }
        }

        public Alarms[] Select_Alarms()
        {
            try
            {
                return Alarm_WS_Obj.Alarms_Select_ALL(UserName, Password);
            }
            catch (Exception exception1)
            {
                Auditing.Error(exception1.Message);
                return null;
            }
        }

        public Company Select_Company(int CompanyID)
        {
            try
            {
                return IncidentReporting_WS_Obj.Company_Select_By_CompanyID(UserName, Password, CompanyID);
            }
            catch (Exception exception1)
            {
                Auditing.Error(exception1.Message);
                return null;
            }
        }
        public Company Select_CompanyByISSI(string ISSI)
        {
            try
            {
                return IncidentReporting_WS_Obj.Company_Select_By_ISSI(UserName, Password, ISSI);
            }
            catch (Exception exception1)
            {
                Auditing.Error(exception1.Message);
                return null;
            }
        }

        public Building_Alarm_Unit[] Select_Building_Alarm_Unit(int Id)
        {
            try
            {
                return Alarm_WS_Obj.Building_AlarmUnit_Select(UserName, Password, Id);
            }
            catch (Exception exception1)
            {
                Auditing.Error(exception1.Message);
                return null;
            }
        }
        public bool Update_Company(Company company)
        {
            try
            {
                return IncidentReporting_WS_Obj.Company_Update(UserName, Password, company);
            }
            catch (Exception exception1)
            {
                Auditing.Error(exception1.Message);
                return false;
            }
        }

        public bool Update_Building(Buildings company)
        {
            try
            {
                return IncidentReporting_WS_Obj.Buildings_Update(UserName, Password, company);
            }
            catch (Exception exception1)
            {
                Auditing.Error(exception1.Message);
                return false;
            }
        }

        public bool Update_Floor(Floors floor)
        {
            try
            {
                return IncidentReporting_WS_Obj.Floors_Update(UserName, Password, floor);
            }
            catch (Exception exception1)
            {
                Auditing.Error(exception1.Message);
                return false;
            }
        }


        public bool Update_FFstations(FFstations FFstations)
        {
            try
            {
                return IncidentReporting_WS_Obj.FFstations_Update(UserName, Password, FFstations);
            }
            catch (Exception exception1)
            {
                Auditing.Error(exception1.Message);
                return false;
            }
        }

        public bool Update_FF_ManPower(FF_ManPower ManPower)
        {
            try
            {
                return IncidentReporting_WS_Obj.FF_ManPower_Update(UserName, Password, ManPower);
            }
            catch (Exception exception1)
            {
                Auditing.Error(exception1.Message);
                return false;
            }
        }
        public bool Update_DangerousePlaces(DangerousPlaces place)
        {
            try
            {
                return IncidentReporting_WS_Obj.DangerousPlaces_Update(UserName, Password, place);
            }
            catch (Exception exception1)
            {
                Auditing.Error(exception1.Message);
                return false;
            }
        }

        public IRUser Add_Account(IRUser user)
        {
            try
            {
                return IncidentReporting_WS_Obj.Users_Insert(UserName, Password, user);
            }
            catch (Exception exception1)
            {
                Auditing.Error(exception1.Message);
                return null;
            }
        }

        public Users_Admin Add_Users_Admin(Users_Admin user)
        {
            try
            {
                return IncidentReporting_WS_Obj.Users_Admin_Insert(UserName, Password, user);
            }
            catch (Exception exception1)
            {
                Auditing.Error(exception1.Message);
                return null;
            }
        }

        public bool Update_Account(IRUser user)
        {
            try
            {
                return IncidentReporting_WS_Obj.Users_Update(UserName, Password, user);
            }
            catch (Exception exception1)
            {
                Auditing.Error(exception1.Message);
                return false;
            }
        }

        public bool Delete_Account(int UserID)
        {
            try
            {
                
                return IncidentReporting_WS_Obj.Users_Delete(UserName, Password, UserID);
            }
            catch (Exception exception1)
            {
                Auditing.Error(exception1.Message);
                return false;
            }
        }

        public Company Add_Company(Company company)
        {
            try
            {
                return IncidentReporting_WS_Obj.Company_Insert(UserName, Password, company);
            }
            catch (Exception exception1)
            {
                Auditing.Error(exception1.Message);
                return null;
            }
        }

        public Buildings Add_Building(Buildings building)
        {
            try
            {
                return IncidentReporting_WS_Obj.Buildings_Insert(UserName, Password, building);
            }
            catch (Exception exception1)
            {
                Auditing.Error(exception1.Message);
                return null;
            }
        }

        public Floors Add_Floors(Floors floor)
        {
            try
            {
                return IncidentReporting_WS_Obj.Floors_Insert(UserName, Password, floor);
            }
            catch (Exception exception1)
            {
                Auditing.Error(exception1.Message);
                return null;
            }
        }

        public ExitPathways Add_exitPath(ExitPathways exitPath)
        {
            try
            {
                return IncidentReporting_WS_Obj.ExitPathways_Insert(UserName, Password, exitPath);
            }
            catch (Exception exception1)
            {
                Auditing.Error(exception1.Message);
                return null;
            }
        }

        public DangerousPlaces Add_DangerousPlace(DangerousPlaces Place)
        {
            try
            {
                return IncidentReporting_WS_Obj.DangerousPlaces_Insert(UserName, Password, Place);
            }
            catch (Exception exception1)
            {
                Auditing.Error(exception1.Message);
                return null;
            }
        }
        public Managers Add_Manager(Managers Manager)
        {
            try
            {
                return IncidentReporting_WS_Obj.Managers_Insert(UserName, Password, Manager);
            }
            catch (Exception exception1)
            {
                Auditing.Error(exception1.Message);
                return null;
            }
        }
        public bool Delete_Company(int id)
        {
            try
            {
                
                return IncidentReporting_WS_Obj.Company_Delete(UserName, Password, id);
            }
            catch (Exception exception1)
            {
                Auditing.Error(exception1.Message);
                return false;
            }
        }

        public FFstations Add_FFstations(FFstations station)
        {
            try
            {
                return IncidentReporting_WS_Obj.FFstations_Insert(UserName, Password, station);
            }
            catch (Exception exception1)
            {
                Auditing.Error(exception1.Message);
                return null;
            }
        }
        public FF_ManPower AddFF_ManPower(FF_ManPower ManPower)
        {
            try
            {
                return IncidentReporting_WS_Obj.FF_ManPower_Insert(UserName, Password, ManPower);
            }
            catch (Exception exception1)
            {
                Auditing.Error(exception1.Message);
                return null;
            }
        }
        public bool DeleteFF_ManPower(int FF_ID)
        {
            try
            {
                return IncidentReporting_WS_Obj.FF_ManPower_DeleteAll(UserName, Password, FF_ID);
            }
            catch (Exception exception1)
            {
                Auditing.Error(exception1.Message);
                return false;
            }
        }
        public bool Delete_FFstations(int id)
        {
            try
            {

                return IncidentReporting_WS_Obj.FFstations_Delete(UserName, Password, id);
            }
            catch (Exception exception1)
            {
                Auditing.Error(exception1.Message);
                return false;
            }
        }
        public bool Delete_Building(int id)
        {
            try
            {

                return IncidentReporting_WS_Obj.Buildings_Delete_By_CompanyID(UserName, Password, id);
            }
            catch (Exception exception1)
            {
                Auditing.Error(exception1.Message);
                return false;
            }
        }
        public bool Delete_SelectedBuilding(int id)
        {
            try
            {

                return IncidentReporting_WS_Obj.Buildings_Delete(UserName, Password, id);
            }
            catch (Exception exception1)
            {
                Auditing.Error(exception1.Message);
                return false;
            }
        }
        public bool Delete_DangerousPlaces(int id)
        {
            try
            {

                return IncidentReporting_WS_Obj.DangerousPlaces_Delete_By_CompanyID(UserName, Password, id);
            }
            catch (Exception exception1)
            {
                Auditing.Error(exception1.Message);
                return false;
            }
        }
        public bool Delete_SelectedDangerousPlaces(int id)
        {
            try
            {

                return IncidentReporting_WS_Obj.DangerousPlaces_Delete(UserName, Password, id);
            }
            catch (Exception exception1)
            {
                Auditing.Error(exception1.Message);
                return false;
            }
        }
        public bool Delete_Manager(int id)
        {
            try
            {

                return IncidentReporting_WS_Obj.Managers_Delete(UserName, Password, id);
            }
            catch (Exception exception1)
            {
                Auditing.Error(exception1.Message);
                return false;
            }
        }

        public FF_pumps Add_FFPump(FF_pumps pump)
        {
            try
            {
               return IncidentReporting_WS_Obj.FF_pumps_Insert(UserName, Password, pump);
            }
            catch (Exception exception1)
            {
                Auditing.Error(exception1.Message);
                return null;
            }
        }
        public bool Delete_FF_pumps(int id)
        {
            try
            {

                return IncidentReporting_WS_Obj.FF_pumps_Delete(UserName, Password, id);
            }
            catch (Exception exception1)
            {
                Auditing.Error(exception1.Message);
                return false;
            }
        }
        public bool Update_ExitPathways(ExitPathways path)
        {
            try
            {
                return IncidentReporting_WS_Obj.ExitPathways_Update(UserName, Password, path);
            }
            catch (Exception exception1)
            {
                Auditing.Error(exception1.Message);
                return false;
            }
        }
        public bool Update_FFPump(FF_pumps pump)
        {
            try
            {
                return IncidentReporting_WS_Obj.FF_pumps_Update(UserName, Password, pump);
            }
            catch (Exception exception1)
            {
                Auditing.Error(exception1.Message);
                return false;
            }
        }

        

        #endregion
    }
}