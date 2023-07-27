using SDS_Remote_Control_Application_Server.Code;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Incident_Reporting_App_Server.localhost;

namespace Incident_Reporting_App_Server.Code
{
    class ServerClass
    {
        public delegate void del_Update_Log(string text);
        public event del_Update_Log log_Handler;
        Incident_WS IncidentReporting_WS_Obj = new Incident_WS();
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
        public void Start_Server(string userName, string passWord)
        {
            try
            {
               // WS1.HelloWorld();
                UserName = userName;
                Password = passWord;
                if (IncidentReporting_WS_Obj.Users_SelectByNamePass(UserName, Password)!=null)
                {
                    Form2 f2 = new Form2();
                    f2.Show();
                }
            }
            catch (Exception exception1)
            {
                Auditing.Error(exception1.Message);
            }
        }

        public Users Select_Account()
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

        public Users Select_User(int UserId)
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

        public Company Update_Company(Company company)
        {
            try
            {
                return IncidentReporting_WS_Obj.Company_Update(UserName, Password, company);
            }
            catch (Exception exception1)
            {
                Auditing.Error(exception1.Message);
                return null;
            }
        }

        public Buildings Update_Building(Buildings company)
        {
            try
            {
                return IncidentReporting_WS_Obj.Buildings_Update(UserName, Password, company);
            }
            catch (Exception exception1)
            {
                Auditing.Error(exception1.Message);
                return null;
            }
        }

        public Floors Update_Floor(Floors floor)
        {
            try
            {
                return IncidentReporting_WS_Obj.Floors_Update(UserName, Password, floor);
            }
            catch (Exception exception1)
            {
                Auditing.Error(exception1.Message);
                return null;
            }
        }

        public DangerousPlaces Update_DangerousePlaces(DangerousPlaces place)
        {
            try
            {
                return IncidentReporting_WS_Obj.DangerousPlaces_Update(UserName, Password, place);
            }
            catch (Exception exception1)
            {
                Auditing.Error(exception1.Message);
                return null;
            }
        }
        public void Add_Account(Users user)
        {
            try
            {
                IncidentReporting_WS_Obj.Users_Insert(UserName, Password, user);
            }
            catch (Exception exception1)
            {
                Auditing.Error(exception1.Message);
            }
        }
        public Users Update_Account(Users user)
        {
            try
            {
                return IncidentReporting_WS_Obj.Users_Update(UserName, Password, user);
            }
            catch (Exception exception1)
            {
                Auditing.Error(exception1.Message);
                return null;
            }
        }

        public void Delete_Account(int UserID)
        {
            try
            {
                
                IncidentReporting_WS_Obj.Users_Delete(UserName, Password, UserID);
            }
            catch (Exception exception1)
            {
                Auditing.Error(exception1.Message);
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
        public void Delete_Company(int id)
        {
            try
            {
                
                IncidentReporting_WS_Obj.Company_Delete(UserName, Password, id);
            }
            catch (Exception exception1)
            {
                Auditing.Error(exception1.Message);
            }
        }

        public void Add_FFstations_FF_ManPower(FFstations station)
        {
            try
            {
                IncidentReporting_WS_Obj.FFstations_Insert(UserName, Password, station);
            }
            catch (Exception exception1)
            {
                Auditing.Error(exception1.Message);
            }
        }

        public void Add_FFPump(FF_pumps pump)
        {
            try
            {
                IncidentReporting_WS_Obj.FF_pumps_Insert(UserName, Password, pump);
            }
            catch (Exception exception1)
            {
                Auditing.Error(exception1.Message);
            }
        }

        public ExitPathways Update_ExitPathways(ExitPathways path)
        {
            try
            {
                return IncidentReporting_WS_Obj.ExitPathways_Update(UserName, Password, path);
            }
            catch (Exception exception1)
            {
                Auditing.Error(exception1.Message);
                return null;
            }
        }



        #endregion
    }
}