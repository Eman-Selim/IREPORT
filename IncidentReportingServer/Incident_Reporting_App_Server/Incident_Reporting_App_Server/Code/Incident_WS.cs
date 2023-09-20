using Incident_Reporting_App_Server.localhost;
using SDS_Remote_Control_Application_Server.Code;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Incident_Reporting_App_Server.Code
{
    class Incident_WS
    {
        IncidentReporting_WS IncidentReporting_WS_Obj = new IncidentReporting_WS();
        

        #region Users

        public bool Users_Delete(string username, string password, int user_id)
        {
            try
            {
                return IncidentReporting_WS_Obj.Users_Delete(username, password,user_id);
            }
            catch(Exception ex)
            {
                Auditing.Error(ex.Message);
                return false;
            }
        }

        public User Users_Insert(string username, string password, User Users)
        {
            try
            {
                return IncidentReporting_WS_Obj.Users_Insert(username, password, Users);
            }
            catch(Exception ex)
            {
                Auditing.Error(ex.Message);
                return null;
            }
        }

        public bool Users_Update(string username, string password, User Users)
        {
            try
            {
                return IncidentReporting_WS_Obj.Users_Update(username, password, Users);
            }
            catch (Exception ex)
            {
                Auditing.Error(ex.Message);
                return false;
            }
        }

        public bool FF_pumps_Update(string username, string password, FF_pumps pump)
        {
            try
            {
                return IncidentReporting_WS_Obj.FF_pumps_Update(username, password, pump);
            }
            catch (Exception ex)
            {
                Auditing.Error(ex.Message);
                return false;
            }
        }
        public User Users_SelectByNamePass(string username, string password)
        {
            try
            {
                return IncidentReporting_WS_Obj.Users_SelectByNamePass(username,password);
            }
            catch(Exception ex)
            {
                Auditing.Error(ex.Message);
                return null;
            }
        }

        public User[] Users_Select_All(string username, string password)
        {
            try
            {
                return IncidentReporting_WS_Obj.Users_Select_All(username, password);
            }
            catch (Exception ex)
            {
                Auditing.Error(ex.Message);
                return null;
            }
        }

        public User[] Users_Select_Users_Of_User(string username, string password,int UserID)
        {
            try
            {
                return IncidentReporting_WS_Obj.Users_Select_Users_Of_User(username, password, UserID);
            }
            catch (Exception ex)
            {
                Auditing.Error(ex.Message);
                return null;
            }
        }

        public User Users_SelectByUserId(string username, string password, int UserId)
        {
            try
            {
                return IncidentReporting_WS_Obj.Users_SelectByUserId(username, password, UserId);
            }
            catch(Exception ex)
            {
                Auditing.Error(ex.Message);
                return null;
            }
        }
       

        public User Users_SelectByName(string username, string password, string name)
        {
            try
            {
                return IncidentReporting_WS_Obj.Users_SelectByName( username,  password, name);
            }
            catch (Exception ex)
            {
                Auditing.Error(ex.Message);
                return null;
            }
        }
        public User[] Users_Select_Super_Admin(string username, string password)
        {
            try
            {
                return IncidentReporting_WS_Obj.Users_Select_Super_Admin(username,password);
            }
            catch(Exception ex)
            {
                Auditing.Error(ex.Message);
                return null;
            }
        }

        #endregion

        #region  Users_Admin
        public bool Users_Admin_Delete(string username, string password, int user_id, int Admin_id)
        {
            try 
            {
                return IncidentReporting_WS_Obj.Users_Admin_Delete(username,password,user_id,Admin_id);
            }
            catch (Exception ex)
            {
                Auditing.Error(ex.Message);
                return false;
            }
        }

        public Users_Admin Users_Admin_Insert(string username, string password, Users_Admin Users_Admin)
        {
            try
            {
                return IncidentReporting_WS_Obj.Users_Admin_Insert(username,password,Users_Admin);
            }
            catch(Exception ex)
            {
                Auditing.Error(ex.Message);
                return null;
            }
        }

        public Users_Admin[] Users_Admin_Select_All(string username, string password)
        {
            try
            {
                return IncidentReporting_WS_Obj.Users_Admin_Select_All(username, password);
            }
            catch(Exception ex)
            {
                Auditing.Error(ex.Message);
                return null;
            }
        }

        public Users_Admin Users_Admin_SelectByAdminId(string username, string password, int Admin_ID)
        {
            try
            {
                return IncidentReporting_WS_Obj.Users_Admin_SelectByAdminId(username, password, Admin_ID);
            }
            catch (Exception ex)
            {
                Auditing.Error(ex.Message);
                return null;

            }
        }

        public Users_Admin Users_Admin_SelectByUserID(string username, string password, int User_ID)
        {
            try
            {
                return IncidentReporting_WS_Obj.Users_Admin_SelectByUserID(username, password, User_ID);
            }
            catch(Exception ex)
            {
                Auditing.Error(ex.Message);
                return null;
            }
        }

        #endregion

        #region InjuredSBL
        public bool Injured_Delete(string username, string password, int InjuredID)
        {
            try
            {
                return IncidentReporting_WS_Obj.Injured_Delete(username, password, InjuredID);
            }
            catch(Exception ex)
            {
                Auditing.Error(ex.Message);
                return false;
            }
        }

        public Injured Injured_Insert(string username, string password, Injured Injured)
        {
            try
            {
                return IncidentReporting_WS_Obj.Injured_Insert(username, password, Injured);
            }
            catch(Exception ex)
            {
                Auditing.Error(ex.Message);
                return null;
            }
        }

        public Injured[] Injured_Select_All(string username, string password)
        {
            try
            {
                return IncidentReporting_WS_Obj.Injured_Select_All(username, password);
            }
            catch(Exception ex)
            {
                Auditing.Error(ex.Message);
                return null;
            }
        }

        public Injured[] Injured_Select_By_AccidentID(string username, string password, int AccidentID)
        {
            try
            {
                return IncidentReporting_WS_Obj.Injured_Select_By_AccidentID(username,password, AccidentID);
            }
            catch(Exception ex)
            {
                Auditing.Error(ex.Message);
                return null;
            }
        }

        public Injured[] Injured_Select_By_Age(string username, string password, int Age)
        {
            try
            {
                return IncidentReporting_WS_Obj.Injured_Select_By_Age(username, password, Age);
            }
            catch(Exception ex)
            {
                Auditing.Error(ex.Message);
                return null;
            }
        }

        public Injured[] Injured_Select_By_Civil_Military(string username, string password, string Civil_Military)
        {
            try
            {
                return IncidentReporting_WS_Obj.Injured_Select_By_Civil_Military(username, password, Civil_Military);
            }
            catch(Exception ex)
            {
                Auditing.Error(ex.Message);
                return null;
            }
        }

        public Injured[] Injured_Select_By_Date(string username, string password, DateTime Date)
        {
            try
            {
                return IncidentReporting_WS_Obj.Injured_Select_By_Date(username, password, Date);
            }
            catch(Exception ex)
            {
                Auditing.Error(ex.Message);
                return null;
            }
        }

        public Injured[] Injured_Select_By_InjuredID(string username, string password, int InjuredID)
        {
            try
            {
                return IncidentReporting_WS_Obj.Injured_Select_By_InjuredID(username, password, InjuredID);
            }
            catch(Exception ex)
            {
                Auditing.Error(ex.Message);
                return null;
            }
        }

        public Injured[] Injured_Select_By_Name(string username, string password, string Name)
        {
            try
            {
                return IncidentReporting_WS_Obj.Injured_Select_By_Name(username, password, Name);
            }
            catch(Exception ex)
            {
                Auditing.Error(ex.Message);
                return null;
            }
        }

        public Injured[] Injured_Select_By_Rank(string username, string password, string Rank)
        {
            try
            {
                return IncidentReporting_WS_Obj.Injured_Select_By_Rank(username, password, Rank);
            }
            catch(Exception ex)
            {
                Auditing.Error(ex.Message);
                return null;
            }
        }

        #endregion

        #region ImagesSBL
        public Images Images_Insert(string username, string password, Images Images)
        {
            try
            {
                return IncidentReporting_WS_Obj.Images_Insert(username, password, Images);
            }
            catch(Exception ex)
            {
                Auditing.Error(ex.Message);
                return null;
            }
        }

        public Images[] Images_Select_All(string username, string password)
        {
            try
            {
                return IncidentReporting_WS_Obj.Images_Select_All(username, password);
            }
            catch(Exception ex)
            {
                Auditing.Error(ex.Message);
                return null;
            }
        }

        public Images[] Images_Select_By_BuildingID(string username, string password, int BuildingID)
        {
            try
            {
                return IncidentReporting_WS_Obj.Images_Select_By_BuildingID(username, password, BuildingID);
            }
            catch(Exception ex)
            {
                Auditing.Error(ex.Message);
                return null;
            }
        }

        public Images[] Images_Select_By_ImageDescription(string username, string password, string ImageDescription)
        {
            try
            {
                return IncidentReporting_WS_Obj.Images_Select_By_ImageDescription(username, password, ImageDescription);
            }
            catch (Exception ex)
            {
                Auditing.Error(ex.Message);
                return null;
            }
        }

        #endregion

        #region Floors
        public Floors Floors_Insert(string username, string password, Floors Floors)
        {
            try
            {
                return IncidentReporting_WS_Obj.Floors_Insert(username, password, Floors);
            }
            catch (Exception ex)
            {
                Auditing.Error(ex.Message);
                return null;
            }
        }

        public bool Floors_Update(string username, string password, Floors Floors)
        {
            try
            {
                return IncidentReporting_WS_Obj.Floors_Update(username, password, Floors);
            }
            catch (Exception ex)
            {
                Auditing.Error(ex.Message);
                return false;
            }
        }

        public Floors[] Floors_Select_All(string username, string password)
        {
            try
            {
                return IncidentReporting_WS_Obj.Floors_Select_All(username, password);
            }
            catch (Exception ex)
            {
                Auditing.Error(ex.Message);
                return null;
            }
        }

        public Floors[] Floors_Select_By_BuildingID(string username, string password, int BuildingID)
        {
            try
            {
                return IncidentReporting_WS_Obj.Floors_Select_By_BuildingID(username, password, BuildingID);
            }
            catch (Exception ex)
            {
                Auditing.Error(ex.Message);
                return null;
            }
        }

        public Floors[] Floors_Select_By_CarbonDioxideExtinguishersNumbers(string username, string password, String CarbonDioxideExtinguishersNumbers)
        {
            try
            {
                return IncidentReporting_WS_Obj.Floors_Select_By_CarbonDioxideExtinguishersNumbers(username, password, CarbonDioxideExtinguishersNumbers);
            }
            catch (Exception ex)
            {
                Auditing.Error(ex.Message);
                return null;
            }
        }

        public Floors[] Floors_Select_By_PowderExtinguishersNumber(string username, string password, String PowderExtinguishersNumber)
        {
            try
            {
                return IncidentReporting_WS_Obj.Floors_Select_By_PowderExtinguishersNumber(username, password, PowderExtinguishersNumber);
            }
            catch(Exception ex)
            {
                Auditing.Error(ex.Message);
                return null;
            }
        }

        public Floors[] Floors_Select_By_FoamExtinguishersNumbers(string username, string password, String FoamExtinguishersNumbers)
        {
            try
            {
                return IncidentReporting_WS_Obj.Floors_Select_By_FoamExtinguishersNumbers(username, password, FoamExtinguishersNumbers);
            }
            catch(Exception ex)
            {
                Auditing.Error(ex.Message);
                return null;
            }
        }

        public Floors[] Floors_Select_By_PowderExtinguishersWeight(string username, string password, int PowderExtinguishersWeight)
        {
            try
            {
                return IncidentReporting_WS_Obj.Floors_Select_By_PowderExtinguishersWeight(username, password, PowderExtinguishersWeight);
            }
            catch (Exception ex)
            {
                Auditing.Error(ex.Message);
                return null;
            }
        }

        public Floors[] Floors_Select_By_CarbonDioxideExtinguishersWeight(string username, string password, int CarbonDioxideExtinguishersWeight)
        {
            try
            {
                return IncidentReporting_WS_Obj.Floors_Select_By_CarbonDioxideExtinguishersWeight(username, password, CarbonDioxideExtinguishersWeight);
            }
            catch (Exception ex)
            {
                Auditing.Error(ex.Message);
                return null;
            }
        }

        #endregion

        #region FFstations
        public bool FFstations_Delete(string username, string password, int FFstationsID)
        {
            try
            {
                return IncidentReporting_WS_Obj.FFstations_Delete(username, password, FFstationsID);
            }
            catch (Exception ex)
            {
                Auditing.Error(ex.Message);
                return false;
            }
        }
        public FFstations FFstations_Insert(string username, string password, FFstations FFstations)
        {
            try
            {
                return IncidentReporting_WS_Obj.FFstations_Insert(username, password, FFstations);
            }
            catch (Exception ex)
            {
                Auditing.Error(ex.Message);
                return null;
            }
        }

        public bool FFstations_Update(string username, string password, FFstations FFstations)
        {
            try
            {
                return IncidentReporting_WS_Obj.FFstations_Update(username, password, FFstations);
            }
            catch (Exception ex)
            {
                Auditing.Error(ex.Message);
                return false;
            }
        }
        public FFstations[] FFstations_Select_All(string username, string password)
        {
            try
            {
                return IncidentReporting_WS_Obj.FFstations_Select_All(username, password);
            }
            catch (Exception ex)
            {
                Auditing.Error(ex.Message);
                return null;
            }
        }

        public FFstations[] FFstations_Select_By_AreaName(string username, string password, string AreaName)
        {
            try
            {
                return IncidentReporting_WS_Obj.FFstations_Select_By_AreaName(username, password, AreaName);
            }
            catch (Exception ex)
            {
                Auditing.Error(ex.Message);
                return null;
            }
        }
        public FFstations[] FFstations_Select_By_CarsNumber(string username, string password, string CarsNumber)
        {
            try
            {
                return IncidentReporting_WS_Obj.FFstations_Select_By_CarsNumber(username, password, CarsNumber);
            }
            catch (Exception ex)
            {
                Auditing.Error(ex.Message);
                return null;
            }
        }

        public FFstations[] FFstations_Select_By_Equipments(string username, string password, string Equipments)
        {
            try
            {
                return IncidentReporting_WS_Obj.FFstations_Select_By_Equipments(username, password, Equipments);
            }
            catch (Exception ex)
            {
                Auditing.Error(ex.Message);
                return null;
            }
        }

        public FFstations[] FFstations_Select_By_FF_ID(string username, string password, int FF_ID)
        {
            try
            {
                return IncidentReporting_WS_Obj.FFstations_Select_By_FF_ID(username, password, FF_ID);
            }
            catch (Exception ex)
            {
                Auditing.Error(ex.Message);
                return null;
            }
        }

        public FFstations[] FFstations_Select_By_OfficersNumber(string username, string password, string OfficersNumber)
        {
            try 
            {
                return IncidentReporting_WS_Obj.FFstations_Select_By_OfficersNumber(username, password, OfficersNumber);
            }
            catch (Exception ex)
            {
                Auditing.Error(ex.Message);
                return null;
            }
        }

        public FFstations[] FFstations_Select_By_Sector(string username, string password, string Sector)
        {
            try
            {
                return IncidentReporting_WS_Obj.FFstations_Select_By_Sector(username, password, Sector);
            }
            catch (Exception ex)
            {
                Auditing.Error(ex.Message);
                return null;
            }
        }

        public FFstations[] FFstations_Select_By_Signs(string username, string password, string Signs)
        {
            try
            {
                return IncidentReporting_WS_Obj.FFstations_Select_By_Signs(username, password, Signs);
            }
            catch (Exception ex)
            {
                Auditing.Error(ex.Message);
                return null;
            }
        }

        public FFstations[] FFstations_Select_By_SoliderNumber(string username, string password, string SoliderNumber)
        {
            try
            {
                return IncidentReporting_WS_Obj.FFstations_Select_By_SoliderNumber(username, password, SoliderNumber);
            }
            catch (Exception ex)
            {
                Auditing.Error(ex.Message);
                return null;
            }
        }

        public FFstations[] FFstations_Select_By_Street(string username, string password, string Street)
        {
            try
            {
                return IncidentReporting_WS_Obj.FFstations_Select_By_Street(username, password, Street);
            }
            catch (Exception ex)
            {
                Auditing.Error(ex.Message);
                return null;
            }
        }

        public FFstations[] FFstations_Select_By_UserID(string username, string password, int UserID)
        {
            try
            {
                return IncidentReporting_WS_Obj.FFstations_Select_By_UserID(username, password, UserID);
            }
            catch (Exception ex)
            {
                Auditing.Error(ex.Message);
                return null;
            }
        }

        public FFstations[] FFstations_Select_By_ZoneNumber(string username, string password, string ZoneNumber)
        {
            try
            {
                return IncidentReporting_WS_Obj.FFstations_Select_By_ZoneNumber(username, password, ZoneNumber);
            }
            catch (Exception ex)
            {
                Auditing.Error(ex.Message);
                return null;
            }
        }

        #endregion

        #region FF_pumps
        public bool FF_pumps_Delete(string username, string password, int FF_pumpsID)
        {
            try
            {
                return IncidentReporting_WS_Obj.FF_pumps_Delete(username, password, FF_pumpsID);
            }
            catch (Exception ex)
            {
                Auditing.Error(ex.Message);
                return false;
            }
        }
        public FF_pumps FF_pumps_Insert(string username, string password, FF_pumps FF_pumps)
        {
            try
            {
                return IncidentReporting_WS_Obj.FF_pumps_Insert(username, password, FF_pumps);
            }
            catch (Exception ex)
            {
                Auditing.Error(ex.Message);
                return null;
            }
        }

        #endregion

        #region FF_ManPower
        public bool FF_ManPower_Delete(string username, string password, int FF_ManPowerID)
        {
            try
            {
                return IncidentReporting_WS_Obj.FF_ManPower_Delete(username, password, FF_ManPowerID);
            }
            catch (Exception ex)
            {
                Auditing.Error(ex.Message);
                return false;
            }
        }

        public bool FF_ManPower_DeleteAll(string username, string password, int FF_ID)
        {
            try
            {
                return IncidentReporting_WS_Obj.FF_ManPower_DeleteAll(username, password, FF_ID);
            }
            catch (Exception ex)
            {
                Auditing.Error(ex.Message);
                return false;
            }
        }

        public bool FF_ManPower_Update(string username, string password, FF_ManPower ManPower)
        {
            try
            {
                return IncidentReporting_WS_Obj.FF_ManPower_Update(username, password, ManPower);
            }
            catch (Exception ex)
            {
                Auditing.Error(ex.Message);
                return false;
            }
        }

        public FF_ManPower FF_ManPower_Insert(string username, string password, FF_ManPower ManPower)
        {
            try
            {
                return IncidentReporting_WS_Obj.FF_ManPower_Insert(username, password, ManPower);
            }
            catch (Exception ex)
            {
                Auditing.Error(ex.Message);
                return null;
            }
        }

        public FF_ManPower[] FF_ManPower_Select_All(string username, string password)
        {
            try
            {
                return IncidentReporting_WS_Obj.FF_ManPower_Select_All(username, password);
            }
            catch (Exception ex)
            {
                Auditing.Error(ex.Message);
                return null;
            }
        }

        public FF_ManPower[] FF_ManPower_Select_By_Area(string username, string password, string Area)
        {
            try
            {
                return IncidentReporting_WS_Obj.FF_ManPower_Select_By_Area(username, password, Area);
            }
            catch (Exception ex)
            {
                Auditing.Error(ex.Message);
                return null;
            }
        }

        public FF_ManPower[] FF_ManPower_Select_By_Availability(string username, string password, string Availability)
        {
            try
            {
                return IncidentReporting_WS_Obj.FF_ManPower_Select_By_Availability(username, password, Availability);
            }
            catch (Exception ex)
            {
                Auditing.Error(ex.Message);
                return null;
            }
        }

        public FF_ManPower FF_ManPower_Select_By_FF_ManPowerID(string username, string password, int FF_ManPowerID)
        {
            try
            {
                return IncidentReporting_WS_Obj.FF_ManPower_Select_By_FF_ManPowerID(username, password,FF_ManPowerID);
            }
            catch (Exception ex)
            {
                Auditing.Error(ex.Message);
                return null;
            }
        }

        public FF_ManPower[]FF_ManPower_Select_By_Job(string username, string password, string Job)
        {
            try
            {
                return IncidentReporting_WS_Obj.FF_ManPower_Select_By_Job(username, password,Job);
            }
            catch (Exception ex)
            {
                Auditing.Error(ex.Message);
                return null;
            }
        }

        public FF_ManPower[]FF_ManPower_Select_By_OfficerName(string username, string password, string OfficerName)
        {
            try
            {
                return IncidentReporting_WS_Obj.FF_ManPower_Select_By_Job(username, password, OfficerName);
            }
            catch (Exception ex)
            {
                Auditing.Error(ex.Message);
                return null;
            }
        }

        public FF_ManPower[]FF_ManPower_Select_By_Point(string username, string password, string Point)
        {
            try
            {
                return IncidentReporting_WS_Obj.FF_ManPower_Select_By_Job(username, password, Point);
            }
            catch (Exception ex)
            {
                Auditing.Error(ex.Message);
                return null;
            }
        }

        public FF_ManPower[] FF_ManPower_Select_By_Rank(string username, string password, string Rank)
        {
            try
            {
                return IncidentReporting_WS_Obj.FF_ManPower_Select_By_Rank(username, password, Rank);
            }
            catch (Exception ex)
            {
                Auditing.Error(ex.Message);
                return null;
            }
        }

        public FF_ManPower[] FF_ManPower_Select_By_Sector(string username, string password, string Sector)
        {
            try
            {
                return IncidentReporting_WS_Obj.FF_ManPower_Select_By_Rank(username, password, Sector);
            }
            catch (Exception ex)
            {
                Auditing.Error(ex.Message);
                return null;
            }
        }

        public FF_ManPower[] FF_ManPower_Select_By_TimeSlot(string username, string password, string TimeSlot)
        {
            try
            {
                return IncidentReporting_WS_Obj.FF_ManPower_Select_By_TimeSlot(username, password, TimeSlot);
            }
            catch (Exception ex)
            {
                Auditing.Error(ex.Message);
                return null;
            }
        }

        public FF_ManPower[] FF_ManPower_Select_By_UserID(string username, string password, int UserID)
        {
            try
            {
                return IncidentReporting_WS_Obj.FF_ManPower_Select_By_UserID(username, password, UserID);
            }
            catch (Exception ex)
            {
                Auditing.Error(ex.Message);
                return null;
            }
        }

        public FF_ManPower[] FF_ManPower_Select_By_FF_ID(string username, string password, int FF_ID)
        {
            try
            {
                return IncidentReporting_WS_Obj.FF_ManPower_Select_By_FF_ID(username, password, FF_ID);
            }
            catch (Exception ex)
            {
                Auditing.Error(ex.Message);
                return null;
            }
        }
        #endregion

        #region ExitPathways

        public ExitPathways ExitPathways_Insert(string username, string password, ExitPathways ExitPathway)
        {
            try
            {
                return IncidentReporting_WS_Obj.ExitPathways_Insert(username, password, ExitPathway);
            }
            catch (Exception ex)
            {
                Auditing.Error(ex.Message);
                return null;
            }
        }

        public bool ExitPathways_Update(string username, string password, ExitPathways ExitPathway)
        {
            try
            {
                return IncidentReporting_WS_Obj.ExitPathways_Update(username, password, ExitPathway);
            }
            catch (Exception ex)
            {
                Auditing.Error(ex.Message);
                return false;
            }
        }

        public ExitPathways[] ExitPathways_Select_All(string username, string password)
        {
            try
            {
                return IncidentReporting_WS_Obj.ExitPathways_Select_All(username, password);
            }
            catch (Exception ex)
            {
                Auditing.Error(ex.Message);
                return null;
            }
        }

        public ExitPathways[] ExitPathways_Select_By_BuildingID(string username, string password, int BuildingID)
        {
            try
            {
                return IncidentReporting_WS_Obj.ExitPathways_Select_By_BuildingID(username, password, BuildingID);
            }
            catch (Exception ex)
            {
                Auditing.Error(ex.Message);
                return null;
            }
        }


        #endregion

        #region Death

        public bool Death_Delete(string username, string password, int DeathID)
        {
            try
            {
                return IncidentReporting_WS_Obj.Death_Delete(username, password, DeathID);
            }
            catch (Exception ex)
            {
                Auditing.Error(ex.Message);
                return false;
            }
        }

        public Death Death_Insert(string username, string password, Death death)
        {
            try
            {
                return IncidentReporting_WS_Obj.Death_Insert(username, password, death);
            }
            catch (Exception ex)
            {
                Auditing.Error(ex.Message);
                return null;
            }
        }

        public Death[] Death_Select_All(string username, string password)
        {
            try
            {
                return IncidentReporting_WS_Obj.Death_Select_All(username, password);
            }
            catch (Exception ex)
            {
                Auditing.Error(ex.Message);
                return null;
            }
        }

        public Death[] Death_Select_By_AccidentID(string username, string password, int AccidentID)
        {
            try
            {
                return IncidentReporting_WS_Obj.Death_Select_By_AccidentID(username, password, AccidentID);
            }
            catch (Exception ex)
            {
                Auditing.Error(ex.Message);
                return null;
            }
        }

        public Death[] Death_Select_By_Age(string username, string password, int Age)
        {
            try
            {
                return IncidentReporting_WS_Obj.Death_Select_By_Age(username, password, Age);
            }
            catch (Exception ex)
            {
                Auditing.Error(ex.Message);
                return null;
            }
        }

        public Death[] Death_Select_By_Civil_Military(string username, string password, string Civil_Military)
        {
            try
            {
                return IncidentReporting_WS_Obj.Death_Select_By_Civil_Military(username, password, Civil_Military);
            }
            catch (Exception ex)
            {
                Auditing.Error(ex.Message);
                return null;
            }
        }

        public Death[] Death_Select_By_Date(string username, string password, DateTime Date)
        {
            try
            {
                return IncidentReporting_WS_Obj.Death_Select_By_Date(username, password, Date);
            }
            catch (Exception ex)
            {
                Auditing.Error(ex.Message);
                return null;
            }
        }

        public Death[] Death_Select_By_DeathID(string username, string password, int DeathID)
        {
            try
            {
                return IncidentReporting_WS_Obj.Death_Select_By_DeathID(username, password, DeathID);
            }
            catch (Exception ex)
            {
                Auditing.Error(ex.Message);
                return null;
            }
        }

        public Death[] Death_Select_By_Name(string username, string password, string Name)
        {
            try
            {
                return IncidentReporting_WS_Obj.Death_Select_By_Name(username, password, Name);
            }
            catch (Exception ex)
            {
                Auditing.Error(ex.Message);
                return null;
            }
        }

        public Death[] Death_Select_By_Rank(string username, string password, string Rank)
        {
            try
            {
                return IncidentReporting_WS_Obj.Death_Select_By_Rank(username, password, Rank);
            }
            catch (Exception ex)
            {
                Auditing.Error(ex.Message);
                return null;
            }
        }


        #endregion

        #region DangerousPlaces

        public bool DangerousPlaces_Delete_By_CompanyID(string username, string password, int CompanyID)
        {
            try
            {
                return IncidentReporting_WS_Obj.DangerousPlaces_Delete_By_CompanyID(username, password, CompanyID);
            }
            catch (Exception ex)
            {
                Auditing.Error(ex.Message);
                return false;
            }
        }

        public bool DangerousPlaces_Delete(string username, string password, int DangerousPlaceID)
        {
            try
            {
                return IncidentReporting_WS_Obj.DangerousPlaces_Delete(username, password, DangerousPlaceID);
            }
            catch (Exception ex)
            {
                Auditing.Error(ex.Message);
                return false;
            }
        }

        public DangerousPlaces DangerousPlaces_Insert(string username, string password, DangerousPlaces dangerousPlaces)
        {
            try
            {
                return IncidentReporting_WS_Obj.DangerousPlaces_Insert(username, password, dangerousPlaces);
            }
            catch (Exception ex)
            {
                Auditing.Error(ex.Message);
                return null;
            }
        }

        public bool DangerousPlaces_Update(string username, string password, DangerousPlaces dangerousPlaces)
        {
            try
            {
                return IncidentReporting_WS_Obj.DangerousPlaces_Update(username, password, dangerousPlaces);
            }
            catch (Exception ex)
            {
                Auditing.Error(ex.Message);
                return false;
            }
        }

        public DangerousPlaces[] DangerousPlaces_Select_All(string username, string password)
        {
            try
            {
                return IncidentReporting_WS_Obj.DangerousPlaces_Select_All(username, password );
            }
            catch (Exception ex)
            {
                Auditing.Error(ex.Message);
                return null;
            }
        }

        public DangerousPlaces[] DangerousPlaces_Select_By_CompanyID(string username, string password, int CompanyID)
        {
            try
            {
                return IncidentReporting_WS_Obj.DangerousPlaces_Select_By_CompanyID(username, password, CompanyID);
            }
            catch (Exception ex)
            {
                Auditing.Error(ex.Message);
                return null;
            }
        }

        public DangerousPlaces DangerousPlaces_Select_By_ID(string username, string password, int DangerousPlaceID)
        {
            try
            {
                return IncidentReporting_WS_Obj.DangerousPlaces_Select_By_ID(username, password, DangerousPlaceID);
            }
            catch (Exception ex)
            {
                Auditing.Error(ex.Message);
                return null;
            }
        }
        public DangerousPlaces[] DangerousPlaces_Select_By_FireMediator(string username, string password, string FireMediator)
        {
            try
            {
                return IncidentReporting_WS_Obj.DangerousPlaces_Select_By_FireMediator(username, password, FireMediator);
            }
            catch (Exception ex)
            {
                Auditing.Error(ex.Message);
                return null;
            }
        }

        public DangerousPlaces[] DangerousPlaces_Select_By_HazardousSubstance(string username, string password, string HazardousSubstance)
        {
            try
            {
                return IncidentReporting_WS_Obj.DangerousPlaces_Select_By_HazardousSubstance(username, password, HazardousSubstance);
            }
            catch (Exception ex)
            {
                Auditing.Error(ex.Message);
                return null;
            }
        }

        public DangerousPlaces[] DangerousPlaces_Select_By_Location(string username, string password, string Location)
        {
            try
            {
                return IncidentReporting_WS_Obj.DangerousPlaces_Select_By_Location(username, password, Location);
            }
            catch (Exception ex)
            {
                Auditing.Error(ex.Message);
                return null;
            }
        }


        #endregion

        #region Company

        public bool Company_Delete(string username, string password, int CompanyID)
        {
            try
            {
                return IncidentReporting_WS_Obj.Company_Delete(username, password, CompanyID);
            }
            catch (Exception ex)
            {
                Auditing.Error(ex.Message);
                return false;
            }
        }

        public Company Company_Insert(string username, string password, Company company)
        {
            try
            {
                return IncidentReporting_WS_Obj.Company_Insert(username, password, company);
            }
            catch (Exception ex)
            {
                Auditing.Error(ex.Message);
                return null;
            }
        }

        public bool Company_Update(string username, string password, Company company)
        {
            try
            {
                return IncidentReporting_WS_Obj.Company_Update(username, password, company);
            }
            catch (Exception ex)
            {
                Auditing.Error(ex.Message);
                return false;
            }
        }

        public Company[] Company_Select_All(string username, string password)
        {
            try
            {
                return IncidentReporting_WS_Obj.Company_Select_All(username, password );
            }
            catch (Exception ex)
            {
                Auditing.Error(ex.Message);
                return null;
            }
        }

        public Company[] Company_Select_By_Address(string username, string password, string address)
        {
            try
            {
                return IncidentReporting_WS_Obj.Company_Select_By_Address(username, password, address);
            }
            catch (Exception ex)
            {
                Auditing.Error(ex.Message);
                return null;
            }
        }
        public Company[] Company_Select_By_BackCompanyBusiness(string username, string password, string BackCompanyBusiness)
        {
            try
            {
                return IncidentReporting_WS_Obj.Company_Select_By_BackCompanyBusiness(username, password, BackCompanyBusiness);
            }
            catch (Exception ex)
            {
                Auditing.Error(ex.Message);
                return null;
            }
        }
        public Company[] Company_Select_By_BackCompanyName(string username, string password, string BackCompanyName)
        {
            try
            {
                return IncidentReporting_WS_Obj.Company_Select_By_BackCompanyName(username, password, BackCompanyName);
            }
            catch (Exception ex)
            {
                Auditing.Error(ex.Message);
                return null;
            }
        }

        public Company[] Company_Select_By_BackFireMediator(string username, string password, string BackFireMediator)
        {
            try
            {
                return IncidentReporting_WS_Obj.Company_Select_By_BackFireMediator(username, password, BackFireMediator);
            }
            catch (Exception ex)
            {
                Auditing.Error(ex.Message);
                return null;
            }
        }

        public Company[] Company_Select_By_BuildingsNumber(string username, string password, int BuildingsNumber)
        {
            try
            {
                return IncidentReporting_WS_Obj.Company_Select_By_BuildingsNumber(username, password, BuildingsNumber);
            }
            catch (Exception ex)
            {
                Auditing.Error(ex.Message);
                return null;
            }
        }

        public Company Company_Select_By_CompanyID(string username, string password, int CompanyID)
        {
            try
            {
                return IncidentReporting_WS_Obj.Company_Select_By_CompanyID(username, password, CompanyID);
            }
            catch (Exception ex)
            {
                Auditing.Error(ex.Message);
                return null;
            }
        }

        public Company[] Company_Select_By_ElectricalPanelLocation(string username, string password, string ElectricalPanelLocation)
        {
            try
            {
                return IncidentReporting_WS_Obj.Company_Select_By_ElectricalPanelLocation(username, password, ElectricalPanelLocation);
            }
            catch (Exception ex)
            {
                Auditing.Error(ex.Message);
                return null;
            }
        }

        public Company[] Company_Select_By_FrontCompanyBusiness(string username, string password, string FrontCompanyBusiness)
        {
            try
            {
                return IncidentReporting_WS_Obj.Company_Select_By_FrontCompanyBusiness(username, password, FrontCompanyBusiness);
            }
            catch (Exception ex)
            {
                Auditing.Error(ex.Message);
                return null;
            }
        }

        public Company[] Company_Select_By_FrontCompanyName(string username, string password, string FrontCompanyName)
        {
            try
            {
                return IncidentReporting_WS_Obj.Company_Select_By_FrontCompanyName(username, password, FrontCompanyName);
            }
            catch (Exception ex)
            {
                Auditing.Error(ex.Message);
                return null;
            }
        }

        public Company[] Company_Select_By_FrontFireMediator(string username, string password, string FrontFireMediator)
        {
            try
            {
                return IncidentReporting_WS_Obj.Company_Select_By_FrontFireMediator(username, password, FrontFireMediator);
            }
            catch (Exception ex)
            {
                Auditing.Error(ex.Message);
                return null;
            }
        }

        public Company[] Company_Select_By_GasTrapLocation(string username, string password, string GasTrapLocation)
        {
            try
            {
                return IncidentReporting_WS_Obj.Company_Select_By_GasTrapLocation(username, password, GasTrapLocation);
            }
            catch (Exception ex)
            {
                Auditing.Error(ex.Message);
                return null;
            }
        }

        public Company[] Company_Select_By_LandlinePhoneNumber(string username, string password, string LandlinePhoneNumber)
        {
            try
            {
                return IncidentReporting_WS_Obj.Company_Select_By_LandlinePhoneNumber(username, password, LandlinePhoneNumber);
            }
            catch (Exception ex)
            {
                Auditing.Error(ex.Message);
                return null;
            }
        }

        public Company[] Company_Select_By_LeftCompanyBusiness(string username, string password, string LeftCompanyBusiness)
        {
            try
            {
                return IncidentReporting_WS_Obj.Company_Select_By_LeftCompanyBusiness(username, password, LeftCompanyBusiness);
            }
            catch (Exception ex)
            {
                Auditing.Error(ex.Message);
                return null;
            }
        }
        public Company[] Company_Select_By_LeftCompanyName(string username, string password, string LeftCompanyName)
        {
            try
            {
                return IncidentReporting_WS_Obj.Company_Select_By_LeftCompanyName(username, password, LeftCompanyName);
            }
            catch (Exception ex)
            {
                Auditing.Error(ex.Message);
                return null;
            }
        }

        public Company[] Company_Select_By_LeftFireMediator(string username, string password, string LeftFireMediator)
        {
            try
            {
                return IncidentReporting_WS_Obj.Company_Select_By_LeftFireMediator(username, password, LeftFireMediator);
            }
            catch (Exception ex)
            {
                Auditing.Error(ex.Message);
                return null;
            }
        }

        public Company[] Company_Select_By_Name(string username, string password, string Name)
        {
            try
            {
                return IncidentReporting_WS_Obj.Company_Select_By_Name(username, password, Name);
            }
            catch (Exception ex)
            {
                Auditing.Error(ex.Message);
                return null;
            }
        }

        public Company[] Company_Select_By_OxygenTrapLocation(string username, string password, string OxygenTrapLocation)
        {
            try
            {
                return IncidentReporting_WS_Obj.Company_Select_By_OxygenTrapLocation(username, password, OxygenTrapLocation);
            }
            catch (Exception ex)
            {
                Auditing.Error(ex.Message);
                return null;
            }
        }

        public Company[] Company_Select_By_RightCompanyBusiness(string username, string password, string RightCompanyBusiness)
        {
            try
            {
                return IncidentReporting_WS_Obj.Company_Select_By_RightCompanyBusiness(username, password, RightCompanyBusiness);
            }
            catch (Exception ex)
            {
                Auditing.Error(ex.Message);
                return null;
            }
        }

        public Company[] Company_Select_By_RightCompanyName(string username, string password, string RightCompanyName)
        {
            try
            {
                return IncidentReporting_WS_Obj.Company_Select_By_RightCompanyName(username, password, RightCompanyName);
            }
            catch (Exception ex)
            {
                Auditing.Error(ex.Message);
                return null;
            }
        }

        public Company[] Company_Select_By_RightFireMediator(string username, string password, string RightFireMediator)
        {
            try
            {
                return IncidentReporting_WS_Obj.Company_Select_By_RightFireMediator(username, password, RightFireMediator);
            }
            catch (Exception ex)
            {
                Auditing.Error(ex.Message);
                return null;
            }
        }

        public Company[] Company_Select_By_UserID(string username, string password, int UserID)
        {
            try
            {
                return IncidentReporting_WS_Obj.Company_Select_By_UserID(username, password, UserID);
            }
            catch (Exception ex)
            {
                Auditing.Error(ex.Message);
                return null;
            }
        }


        #endregion

        #region Managers
        public bool Managers_Delete(string username, string password, int ManagerID)
        {
            try
            {
                return IncidentReporting_WS_Obj.Managers_Delete(username, password, ManagerID);
            }
            catch (Exception ex)
            {
                Auditing.Error(ex.Message);
                return false;
            }
        }

        public Managers Managers_Insert(string username, string password, Managers Manager)
        {
            try
            {
                return IncidentReporting_WS_Obj.Managers_Insert(username, password, Manager);
            }
            catch (Exception ex)
            {
                Auditing.Error(ex.Message);
                return null;
            }
        }
        public Managers[] Managers_Select_All(string username, string password)
        {
            try
            {
                return IncidentReporting_WS_Obj.Managers_Select_All(username, password);
            }
            catch (Exception ex)
            {
                Auditing.Error(ex.Message);
                return null;
            }
        }

        public Managers[] Managers_Select_By_CompanyID(string username, string password, int CompanyID)
        {
            try
            {
                return IncidentReporting_WS_Obj.Managers_Select_By_CompanyID(username, password, CompanyID);
            }
            catch (Exception ex)
            {
                Auditing.Error(ex.Message);
                return null;
            }
        }

        public Managers Managers_Select_By_ManagerID(string username, string password, int ManagerID)
        {
            try
            {
                return IncidentReporting_WS_Obj.Managers_SelectByManagerID(username, password, ManagerID);
            }
            catch (Exception ex)
            {
                Auditing.Error(ex.Message);
                return null;
            }
        }
        #endregion

        #region Building

        public bool Buildings_Delete(string username, string password, int BuildingID)
        {
            try
            {
                return IncidentReporting_WS_Obj.Buildings_Delete(username, password, BuildingID);
            }
            catch (Exception ex)
            {
                Auditing.Error(ex.Message);
                return false;
            }
        }

        public bool Buildings_Delete_By_CompanyID(string username, string password, int CompanyID)
        {
            try
            {
                return IncidentReporting_WS_Obj.Buildings_Delete_By_CompanyID(username, password, CompanyID);
            }
            catch (Exception ex)
            {
                Auditing.Error(ex.Message);
                return false;
            }
        }

        public Buildings Buildings_Insert(string username, string password, Buildings buildings)
        {
            try
            {
                return IncidentReporting_WS_Obj.Buildings_Insert(username, password, buildings);
            }
            catch (Exception ex)
            {
                Auditing.Error(ex.Message);
                return null;
            }
        }

        public bool Buildings_Update(string username, string password, Buildings buildings)
        {
            try
            {
                return IncidentReporting_WS_Obj.Buildings_Update(username, password, buildings);
            }
            catch (Exception ex)
            {
                Auditing.Error(ex.Message);
                return false;
            }
        }

        public Buildings[] Buildings_Select_All(string username, string password)
        {
            try
            {
                return IncidentReporting_WS_Obj.Buildings_Select_All(username, password);
            }
            catch (Exception ex)
            {
                Auditing.Error(ex.Message);
                return null;
            }
        }

        public Buildings Buildings_Select_By_BuildingID(string username, string password, int ID)
        {
            try
            {
                return IncidentReporting_WS_Obj.Buildings_Select_By_BuildingID(username, password, ID);
            }
            catch (Exception ex)
            {
                Auditing.Error(ex.Message);
                return null;
            }
        }

        public Buildings[] Buildings_Select_By_BuildingNumber(string username, string password, int BuildingNumber)
        {
            try
            {
                return IncidentReporting_WS_Obj.Buildings_Select_By_BuildingNumber(username, password, BuildingNumber);
            }
            catch (Exception ex)
            {
                Auditing.Error(ex.Message);
                return null;
            }
        }

        public Buildings[] Buildings_Select_By_CompanyID(string username, string password, int CompanyID)
        {
            try
            {
                return IncidentReporting_WS_Obj.Buildings_Select_By_CompanyID(username, password, CompanyID);
            }
            catch (Exception ex)
            {
                Auditing.Error(ex.Message);
                return null;
            }
        }

        public Buildings[] Buildings_Select_By_FloorsNumber(string username, string password, int FloorsNumber)
        {
            try
            {
                return IncidentReporting_WS_Obj.Buildings_Select_By_FloorsNumber(username, password, FloorsNumber);
            }
            catch (Exception ex)
            {
                Auditing.Error(ex.Message);
                return null;
            }
        }

        #endregion

        #region Accident
        public bool Accident_Delete(string username, string password, int accidentid)
        {
            try
            {
                return IncidentReporting_WS_Obj.Accident_Delete(username, password, accidentid);
            }
            catch (Exception ex)
            {
                Auditing.Error(ex.Message);
                return false;
            }
        }

        public Accident Accident_Insert(string username, string password, Accident accident)
        {
            try
            {
                return IncidentReporting_WS_Obj.Accident_Insert(username, password, accident);
            }
            catch (Exception ex)
            {
                Auditing.Error(ex.Message);
                return null;
            }
        }

        public Accident[] Accident_Select_All(string username, string password)
        {
            try
            {
                return IncidentReporting_WS_Obj.Accident_Select_All(username, password);
            }
            catch (Exception ex)
            {
                Auditing.Error(ex.Message);
                return null;
            }
        }

        public Accident Accident_Select_By_AccidentNumber(string username, string password, int AccidentNumber)
        {
            try
            {
                return IncidentReporting_WS_Obj.Accident_Select_By_AccidentNumber(username, password, AccidentNumber);
            }
            catch (Exception ex)
            {
                Auditing.Error(ex.Message);
                return null;
            }
        }

        public Accident[] Accident_Select_By_CompanyID(string username, string password, int CompanyID)
        {
            try
            {
                return IncidentReporting_WS_Obj.Accident_Select_By_CompanyID(username, password, CompanyID);
            }
            catch (Exception ex)
            {
                Auditing.Error(ex.Message);
                return null;
            }
        }

        public Accident[] Accident_Select_By_Date(string username, string password, DateTime date)
        {
            try
            {
                return IncidentReporting_WS_Obj.Accident_Select_By_Date(username, password, date);
            }
            catch (Exception ex)
            {
                Auditing.Error(ex.Message);
                return null;
            }
        }

        public Accident[] Accident_Select_By_Equipments(string username, string password, string equipments)
        {
            try
            {
                return IncidentReporting_WS_Obj.Accident_Select_By_Equipments(username, password, equipments);
            }
            catch (Exception ex)
            {
                Auditing.Error(ex.Message);
                return null;
            }
        }

        public Accident Accident_Select_By_ID(string username, string password, int ID)
        {
            try
            {
                return IncidentReporting_WS_Obj.Accident_Select_By_ID(username, password, ID);
            }
            catch (Exception ex)
            {
                Auditing.Error(ex.Message);
                return null;
            }
        }

        public Accident[] Accident_Select_By_LossesType(string username, string password, string LossesType)
        {
            try
            {
                return IncidentReporting_WS_Obj.Accident_Select_By_LossesType(username, password, LossesType);
            }
            catch (Exception ex)
            {
                Auditing.Error(ex.Message);
                return null;
            }
        }

        public Accident[] Accident_Select_By_TimeToArrive(string username, string password, DateTime TimeToArrive)
        {
            try
            {
                return IncidentReporting_WS_Obj.Accident_Select_By_TimeToArrive(username, password, TimeToArrive);
            }
            catch (Exception ex)
            {
                Auditing.Error(ex.Message);
                return null;
            }
        }

        public Accident[] Accident_Select_By_TimeToSend(string username, string password, DateTime TimeToSend)
        {
            try
            {
                return IncidentReporting_WS_Obj.Accident_Select_By_TimeToSend(username, password, TimeToSend);
            }
            catch (Exception ex)
            {
                Auditing.Error(ex.Message);
                return null;
            }
        }
        public Accident[] Accident_Select_By_Type(string username, string password, string AccidentType)
        {
            try
            {
                return IncidentReporting_WS_Obj.Accident_Select_By_Type(username, password, AccidentType);
            }
            catch (Exception ex)
            {
                Auditing.Error(ex.Message);
                return null;
            }
        }

        public Accident[] Accident_Select_By_VehiclesToAccident(string username, string password, string VehiclesToAccident)
        {
            try
            {
                return IncidentReporting_WS_Obj.Accident_Select_By_VehiclesToAccident(username, password, VehiclesToAccident);
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
