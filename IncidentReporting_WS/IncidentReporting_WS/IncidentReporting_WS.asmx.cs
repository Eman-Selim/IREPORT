using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using IncidentReporting_WS.Code_Files.CBL;
using IncidentReporting_WS.Code_Files.ENL;
using IncidentReporting_WS.Code_Files.COL;
using IncidentReporting_WS.Code_Files.SBL;

namespace IncidentReporting_WS
{
    /// <summary>
    /// Summary description for IncidentReporting_WS
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class IncidentReporting_WS : System.Web.Services.WebService
    {
        #region UsersSBL
        IRUserSBL UsersSBL_Obj = new IRUserSBL();

        [WebMethod]
        public bool Users_Delete(string username, string password, int user_id)
        {
            try
            {
                return UsersSBL_Obj.Users_Delete( username, password, user_id);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        [WebMethod]
        public IRUser Users_Insert(string username, string password, IRUser Users)
        {
            try
            {
                return UsersSBL_Obj.Users_Insert( username, password, Users);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        [WebMethod]
        public bool Users_Update(string username, string password, IRUser Users)
        {
            try
            {
                return UsersSBL_Obj.Users_Update(username, password, Users);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        [WebMethod]
        public IRUserCollection Users_Select_All(string username, string password)
        {
            try
            {
                IRUserCollection users_obj = new IRUserCollection();
                users_obj = UsersSBL_Obj.Users_Select_All( username, password);
                return Load_Users_Data(username, password, users_obj);
            }
            catch (Exception e)
            {
                return null;
            }
        }

        [WebMethod]
        public IRUserCollection Users_Select_Users_Of_User(string username, string password, int UserId)
        {
            try
            {
                IRUserCollection users_obj = new IRUserCollection();
                users_obj = UsersSBL_Obj.Users_Select_Users_Of_User(username, password, UserId);
                return Load_Users_Data(username, password,users_obj );
            }
            catch (Exception e)
            {
                return null;
            }
        }

        [WebMethod]
        public IRUser Users_SelectByUserId(string username, string password, int UserId)
        {
            try
            {
                IRUser users_obj = new IRUser();
                users_obj = UsersSBL_Obj.Users_SelectByUserId( username, password, UserId);
                return Load_Users_Data(username, password, new IRUserCollection() { users_obj })[0];

            }
            catch (Exception e)
            {
                return null;
            }
        }

        [WebMethod]
        public IRUser Users_SelectByNamePass(string username, string password)
        {
            try
            {
                IRUser users_obj = new IRUser();
                users_obj = UsersSBL_Obj.Users_SelectByNamePass( username,   password);
                return Load_Users_Data(username, password, new IRUserCollection() { users_obj })[0];

            }
            catch (Exception e)
            {
                return null;
            }
        }

       
        [WebMethod]
        public IRUser Users_SelectByName(string username, string password, string name)
        {
            try
            {
                IRUser users_obj = new IRUser();
                users_obj = UsersSBL_Obj.Users_SelectByName( username,  password,  name);
                return Load_Users_Data(username, password, new IRUserCollection() { users_obj })[0];

            }
            catch (Exception e)
            {
                return null;
            }
        }
        [WebMethod]
        public IRUserCollection Users_Select_Super_Admin(string username, string password)
        {
            try
            {
                IRUserCollection users_obj = new IRUserCollection();
                users_obj = UsersSBL_Obj.Users_Select_Super_Admin( username, password);
                return Load_Users_Data(username, password, users_obj);

            }
            catch (Exception e)
            {
                return null;
            }
        }

        private IRUserCollection Load_Users_Data(string username, string password, IRUserCollection Users_Array)
        {
            if (Users_Array != null)
                for (int loop = 0; loop < Users_Array.Count; loop++)
                {
                    Users_Array[loop].Users_of_Users = Users_Select_Users_Of_User(username, password, Users_Array[loop].UserID);
                    Users_Array[loop].User_Companies = Company_Select_By_UserID(username, password, Users_Array[loop].UserID);
                    Users_Array[loop].User_FFstations = FFstations_Select_By_UserID(username, password, Users_Array[loop].UserID);
                    Users_Array[loop].User_FF_Pumps = FF_pumps_Select_By_UserID(username, password, Users_Array[loop].UserID);

                    
                }
            return Users_Array;
        }

        #endregion

        #region Users_AdminSBL
        Users_AdminSBL Users_AdminSBL_Obj = new Users_AdminSBL();

        [WebMethod]
        public bool Users_Admin_Delete(string username, string password, int user_id, int Admin_id)
        {
            try
            {

                return Users_AdminSBL_Obj.Users_Admin_Delete( username, password, user_id, Admin_id);

            }
            catch (Exception ex)
            {
                return false;
            }
        }

        [WebMethod]
        public Users_Admin Users_Admin_Insert(string username, string password, Users_Admin Users_Admin)
        {
            try
            {
                return Users_AdminSBL_Obj.Users_Admin_Insert( username, password, Users_Admin);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        [WebMethod]
        public Users_AdminCollection Users_Admin_Select_All(string username, string password)
        {
            try
            {
                Users_AdminCollection users = new Users_AdminCollection();
                users = Users_AdminSBL_Obj.Users_Admin_Select_All( username, password);
                return users;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        [WebMethod]
        public Users_Admin Users_Admin_SelectByAdminId(string username, string password, int Admin_ID)
        {
            try
            {
                Users_Admin users = new Users_Admin();
                users = Users_AdminSBL_Obj.Users_Admin_SelectByAdminId( username, password, Admin_ID);
                return users;

            }
            catch (Exception e)
            {
                return null;
            }
        }

        [WebMethod]
        public Users_Admin Users_Admin_SelectByUserID(string username, string password, int User_ID)
        {
            try
            {
                Users_Admin users = new Users_Admin();
                users = Users_AdminSBL_Obj.Users_Admin_SelectByUserID( username, password, User_ID);
                return users;

            }
            catch (Exception e)
            {
                return null;
            }
        }
        
        #endregion

        #region InjuredSBL
        InjuredSBL InjuredSBL_Obj = new InjuredSBL();

        [WebMethod]
        public bool Injured_Delete(string username, string password, int InjuredID)
        {
            try
            {

                return InjuredSBL_Obj.Injured_Delete( username, password, InjuredID);

            }
            catch (Exception ex)
            {
                return false;
            }
        }

        [WebMethod]
        public Injured Injured_Insert(string username, string password, Injured Injured)
        {
            try
            {
                return InjuredSBL_Obj.Injured_Insert( username, password, Injured);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        [WebMethod]
        public InjuredCollection Injured_Select_All(string username, string password)
        {
            try
            {
                InjuredCollection users = new InjuredCollection();
                users = InjuredSBL_Obj.Injured_Select_All( username, password);
                return users;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        [WebMethod]
        public InjuredCollection Injured_Select_By_AccidentID(string username, string password, int AccidentID)
        {
            try
            {
                InjuredCollection users = new InjuredCollection();
                users = InjuredSBL_Obj.Injured_Select_By_AccidentID( username, password, AccidentID);
                return users;

            }
            catch (Exception e)
            {
                return null;
            }
        }

        [WebMethod]
        public InjuredCollection Injured_Select_By_Age(string username, string password, int Age)
        {
            try
            {
                InjuredCollection users = new InjuredCollection();
                users = InjuredSBL_Obj.Injured_Select_By_Age( username, password, Age);
                return users;

            }
            catch (Exception e)
            {
                return null;
            }
        }

        [WebMethod]
        public InjuredCollection Injured_Select_By_Civil_Military(string username, string password, string Civil_Military)
        {
            try
            {
                InjuredCollection users = new InjuredCollection();
                users = InjuredSBL_Obj.Injured_Select_By_Civil_Military( username, password,Civil_Military);
                return users;

            }
            catch (Exception e)
            {
                return null;
            }
        }

        [WebMethod]
        public InjuredCollection Injured_Select_By_Date(string username, string password, DateTime Date)
        {
            try
            {
                InjuredCollection users = new InjuredCollection();
                users = InjuredSBL_Obj.Injured_Select_By_Date( username, password, Date);
                return users;

            }
            catch (Exception e)
            {
                return null;
            }
        }

        [WebMethod]
        public InjuredCollection Injured_Select_By_InjuredID(string username, string password, int InjuredID)
        {
            try
            {
                InjuredCollection users = new InjuredCollection();
                users = InjuredSBL_Obj.Injured_Select_By_InjuredID(username,password,InjuredID);
                return users;

            }
            catch (Exception e)
            {
                return null;
            }
        }

        [WebMethod]
        public InjuredCollection Injured_Select_By_Name(string username, string password, string Name)
        {
            try
            {
                InjuredCollection users = new InjuredCollection();
                users = InjuredSBL_Obj.Injured_Select_By_Name( username, password, Name);
                return users;

            }
            catch (Exception e)
            {
                return null;
            }
        }
        
        [WebMethod]
        public InjuredCollection Injured_Select_By_Rank(string username, string password, string Rank)
        {
            try
            {
                InjuredCollection users = new InjuredCollection();
                users = InjuredSBL_Obj.Injured_Select_By_Rank( username, password, Rank);
                return users;

            }
            catch (Exception e)
            {
                return null;
            }
        }
        #endregion

        #region ImagesSBL
        ImagesSBL ImagesSBL_Obj = new ImagesSBL();

        [WebMethod]
        public Images Images_Insert(string username, string password, Images Images)
        {
            try
            {

                return ImagesSBL_Obj.Images_Insert( username, password, Images);

            }
            catch (Exception ex)
            {
                return null;
            }
        }

        [WebMethod]
        public ImagesCollection Images_Select_All(string username, string password)
        {
            try
            {
                return ImagesSBL_Obj.Images_Select_All( username, password);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        [WebMethod]
        public ImagesCollection Images_Select_By_BuildingID(string username, string password, int BuildingID)
        {
            try
            {
                ImagesCollection Images = new ImagesCollection();
                Images = ImagesSBL_Obj.Images_Select_By_BuildingID( username, password,  BuildingID);
                return Images;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        [WebMethod]
        public ImagesCollection Images_Select_By_ImageDescription(string username, string password, string ImageDescription)
        {
            try
            {
                ImagesCollection Images = new ImagesCollection();
                Images = ImagesSBL_Obj.Images_Select_By_ImageDescription(username,password, ImageDescription);
                return Images;

            }
            catch (Exception e)
            {
                return null;
            }
        }

       
        #endregion

        #region FloorsSBL
        FloorsSBL FloorsSBL_Obj = new FloorsSBL();

        [WebMethod]
        public Floors Floors_Insert(string username, string password, Floors Floors)
        {
            try
            {

                return FloorsSBL_Obj.Floors_Insert( username,password,Floors);

            }
            catch (Exception ex)
            {
                return null;
            }
        }

        [WebMethod]
        public bool Floors_Update(string username, string password, Floors Floors)
        {
            try
            {

                return FloorsSBL_Obj.Floors_Update(username, password, Floors);

            }
            catch (Exception ex)
            {
                return false;
            }
        }

        [WebMethod]
        public FloorsCollection Floors_Select_All(string username, string password)
        {
            try
            {
                return FloorsSBL_Obj.Floors_Select_All(username,password);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        [WebMethod]
        public FloorsCollection Floors_Select_By_BuildingID(string username, string password, int BuildingID)
        {
            try
            {
                FloorsCollection Floors = new FloorsCollection();
                Floors = FloorsSBL_Obj.Floors_Select_By_BuildingID(username,password,BuildingID);
                return Floors;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        [WebMethod]
        public FloorsCollection Floors_Select_By_CarbonDioxideExtinguishersNumbers(string username, string password, String CarbonDioxideExtinguishersNumbers)
        {
            try
            {
                FloorsCollection Floors = new FloorsCollection();
                Floors = FloorsSBL_Obj.Floors_Select_By_CarbonDioxideExtinguishersNumbers( username, password, CarbonDioxideExtinguishersNumbers);
                return Floors;

            }
            catch (Exception e)
            {
                return null;
            }
        }

        [WebMethod]
        public FloorsCollection Floors_Select_By_PowderExtinguishersNumber(string username, string password, String PowderExtinguishersNumber)
        {
            try
            {
                FloorsCollection Floors = new FloorsCollection();
                Floors = FloorsSBL_Obj.Floors_Select_By_PowderExtinguishersNumber(username,password,PowderExtinguishersNumber);
                return Floors;

            }
            catch (Exception e)
            {
                return null;
            }
        }       

        [WebMethod]
        public FloorsCollection Floors_Select_By_FoamExtinguishersNumbers(string username, string password, String FoamExtinguishersNumbers)
        {
            try
            {
                FloorsCollection Floors = new FloorsCollection();
                Floors = FloorsSBL_Obj.Floors_Select_By_FoamExtinguishersNumbers( username, password, FoamExtinguishersNumbers);
                return Floors;

            }
            catch (Exception e)
            {
                return null;
            }
        }       

        [WebMethod]
        public FloorsCollection Floors_Select_By_PowderExtinguishersWeight(string username, string password, int PowderExtinguishersWeight)
        {
            try
            {
                FloorsCollection Floors = new FloorsCollection();
                Floors = FloorsSBL_Obj.Floors_Select_By_PowderExtinguishersWeight( username, password, PowderExtinguishersWeight);
                return Floors;

            }
            catch (Exception e)
            {
                return null;
            }
        }       

        [WebMethod]
        public FloorsCollection Floors_Select_By_CarbonDioxideExtinguishersWeight(string username, string password, int CarbonDioxideExtinguishersWeight)
        {
            try
            {
                FloorsCollection Floors = new FloorsCollection();
                Floors = FloorsSBL_Obj.Floors_Select_By_CarbonDioxideExtinguishersWeight(username,password,CarbonDioxideExtinguishersWeight);
                return Floors;

            }
            catch (Exception e)
            {
                return null;
            }
        }       

        [WebMethod]
        public FloorsCollection Floors_Select_By_FoamExtinguishersWeight(string username, string password, int FoamExtinguishersWeight)
        {
            try
            {
                FloorsCollection Floors = new FloorsCollection();
                Floors = FloorsSBL_Obj.Floors_Select_By_FoamExtinguishersWeight(username, password, FoamExtinguishersWeight);
                return Floors;

            }
            catch (Exception e)
            {
                return null;
            }
        }       
        #endregion

        #region FFstationsSBL
        FFstationsSBL FFstationsSBL_Obj = new FFstationsSBL();

        [WebMethod]
        public bool FFstations_Delete(string username, string password, int FFstationsID)
        {
            try
            {

                return FFstationsSBL_Obj.FFstations_Delete( username, password, FFstationsID);

            }
            catch (Exception ex)
            {
                return false;
            }
        }

        [WebMethod]
        public FFstations FFstations_Insert(string username, string password, FFstations FFstations)
        {
            try
            {
                return FFstationsSBL_Obj.FFstations_Insert( username, password, FFstations);
            }
            catch (Exception ex)
            {
                return null;
            }
        }


        [WebMethod]
        public bool FFstations_Update(string username, string password, FFstations FFstations)
        {
            try
            {
                return FFstationsSBL_Obj.FFstations_Update(username, password, FFstations);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        [WebMethod]
        public FFstationsCollection FFstations_Select_All(string username, string password)
        {
            try
            {
                FFstationsCollection FFstations_obj = FFstationsSBL_Obj.FFstations_Select_All(username, password);
                return Load_FFstations_Data(username, password, FFstations_obj);
            }
            catch (Exception e)
            {
                return null;
            }
        }



        [WebMethod]
        public FFstationsCollection FFstations_Select_By_AreaName(string username, string password, string AreaName)
        {
            try
            {
                FFstationsCollection FFstations_obj = new FFstationsCollection();
                FFstations_obj = FFstationsSBL_Obj.FFstations_Select_By_AreaName( username, password, AreaName);
                return Load_FFstations_Data(username, password, FFstations_obj) ;

            }
            catch (Exception e)
            {
                return null;
            }
        }

        [WebMethod]
        public FFstationsCollection FFstations_Select_By_CarsNumber(string username, string password, string CarsNumber)
        {
            try
            {
                FFstationsCollection FFstations_obj = new FFstationsCollection();
                FFstations_obj = FFstationsSBL_Obj.FFstations_Select_By_CarsNumber( username, password, CarsNumber);
                return Load_FFstations_Data(username, password, FFstations_obj);

            }
            catch (Exception e)
            {
                return null;
            }
        }       

        [WebMethod]
        public FFstationsCollection FFstations_Select_By_Equipments(string username, string password, string Equipments)
        {
            try
            {
                FFstationsCollection FFstations_obj = new FFstationsCollection();
                FFstations_obj = FFstationsSBL_Obj.FFstations_Select_By_Equipments(username,password,Equipments);
                return Load_FFstations_Data(username, password, FFstations_obj);

            }
            catch (Exception e)
            {
                return null;
            }
        }       

        [WebMethod]
        public FFstationsCollection FFstations_Select_By_FF_ID(string username, string password, int FF_ID)
        {
            try
            {
                FFstationsCollection FFstations_obj = new FFstationsCollection();
                FFstations_obj = FFstationsSBL_Obj.FFstations_Select_By_FF_ID(username,password,FF_ID);
                return Load_FFstations_Data(username, password, FFstations_obj);

            }
            catch (Exception e)
            {
                return null;
            }
        }       

        [WebMethod]
        public FFstationsCollection FFstations_Select_By_OfficersNumber(string username, string password, string OfficersNumber)
        {
            try
            {
                FFstationsCollection FFstations_obj = new FFstationsCollection();
                FFstations_obj = FFstationsSBL_Obj.FFstations_Select_By_OfficersNumber(username,password,OfficersNumber);
                return Load_FFstations_Data(username, password, FFstations_obj);

            }
            catch (Exception e)
            {
                return null;
            }
        }       

        [WebMethod]
        public FFstationsCollection FFstations_Select_By_Sector(string username, string password, string Sector)
        {
            try
            {
                FFstationsCollection FFstations_obj = new FFstationsCollection();
                FFstations_obj = FFstationsSBL_Obj.FFstations_Select_By_Sector( username, password, Sector);
                return Load_FFstations_Data(username, password, FFstations_obj);

            }
            catch (Exception e)
            {
                return null;
            }
        }       

        [WebMethod]
        public FFstationsCollection FFstations_Select_By_Signs(string username, string password, string Signs)
        {
            try
            {
                FFstationsCollection FFstations_obj = new FFstationsCollection();
                FFstations_obj = FFstationsSBL_Obj.FFstations_Select_By_Signs(username,password,Signs);
                return Load_FFstations_Data(username, password, FFstations_obj);

            }
            catch (Exception e)
            {
                return null;
            }
        }       

        [WebMethod]
        public FFstationsCollection FFstations_Select_By_SoliderNumber(string username, string password, string SoliderNumber)
        {
            try
            {
                FFstationsCollection FFstations_obj = new FFstationsCollection();
                FFstations_obj = FFstationsSBL_Obj.FFstations_Select_By_SoliderNumber(username,password,SoliderNumber);
                return Load_FFstations_Data(username, password, FFstations_obj);

            }
            catch (Exception e)
            {
                return null;
            }
        }       

        [WebMethod]
        public FFstationsCollection FFstations_Select_By_Street(string username, string password, string Street)
        {
            try
            {
                FFstationsCollection FFstations_obj = new FFstationsCollection();
                FFstations_obj = FFstationsSBL_Obj.FFstations_Select_By_Street(username,password,Street);
                return Load_FFstations_Data(username, password, FFstations_obj);

            }
            catch (Exception e)
            {
                return null;
            }
        }       

        [WebMethod]
        public FFstationsCollection FFstations_Select_By_UserID(string username, string password, int UserID)
        {
            try
            {
                FFstationsCollection FFstations_obj = new FFstationsCollection();
                FFstations_obj = FFstationsSBL_Obj.FFstations_Select_By_UserID(username,password,UserID);
                return Load_FFstations_Data(username, password, FFstations_obj);

            }
            catch (Exception e)
            {
                return null;
            }
        }       

        [WebMethod]
        public FFstationsCollection FFstations_Select_By_ZoneNumber(string username, string password, string ZoneNumber)
        {
            try
            {
                FFstationsCollection FFstations_obj = new FFstationsCollection();
                FFstations_obj = FFstationsSBL_Obj.FFstations_Select_By_ZoneNumber(username,password,ZoneNumber);
                return Load_FFstations_Data(username, password, FFstations_obj);

            }
            catch (Exception e)
            {
                return null;
            }
        }

        private FFstationsCollection Load_FFstations_Data(string username, string password, FFstationsCollection FFstations_Array)
        {
            if (FFstations_Array != null)
                for (int loop = 0; loop < FFstations_Array.Count; loop++)
                {
                    FFstations_Array[loop].Station_ManPower = FF_ManPower_Select_By_FF_ID(username, password, FFstations_Array[loop].FF_ID);
                }
            return FFstations_Array;
        }

        #endregion

        #region FF_pumpsSBL
        FF_pumpsSBL FF_pumpsSBL_Obj = new FF_pumpsSBL();

        [WebMethod]
        public bool FF_pumps_Delete(string username, string password, int FF_pumpsID)
        {
            try
            {

                return FF_pumpsSBL_Obj.FF_pumps_Delete( username,password,FF_pumpsID);

            }
            catch (Exception ex)
            {
                return false;
            }
        }

        [WebMethod]
        public FF_pumps FF_pumps_Insert(string username, string password, FF_pumps FF_pumps)
        {
            try
            {
                return FF_pumpsSBL_Obj.FF_pumps_Insert(username,password,FF_pumps);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        [WebMethod]
        public bool FF_pumps_Update(string username, string password, FF_pumps FF_pumps)
        {
            try
            {

                return FF_pumpsSBL_Obj.FF_pumps_Update(username, password, FF_pumps);

            }
            catch (Exception ex)
            {
                return false;
            }
        }

        [WebMethod]
        public FF_pumpsCollection FF_pumps_Select_All(string username, string password)
        {
            try
            {
                FF_pumpsCollection FF_pumps = new FF_pumpsCollection();
                FF_pumps = FF_pumpsSBL_Obj.FF_pumps_Select_All(username,password);
                return FF_pumps;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        [WebMethod]
        public FF_pumpsCollection FF_pumps_Select_By_Address(string username, string password, string Address)
        {
            try
            {
                FF_pumpsCollection FF_pumps = new FF_pumpsCollection();
                FF_pumps = FF_pumpsSBL_Obj.FF_pumps_Select_By_Address( username, password, Address);
                return FF_pumps;

            }
            catch (Exception e)
            {
                return null;
            }
        }

        [WebMethod]
        public FF_pumpsCollection FF_pumps_Select_By_Area(string username, string password, string Area)
        {
            try
            {
                FF_pumpsCollection FF_pumps = new FF_pumpsCollection();
                FF_pumps = FF_pumpsSBL_Obj.FF_pumps_Select_By_Area( username, password, Area);
                return FF_pumps;

            }
            catch (Exception e)
            {
                return null;
            }
        }       

        [WebMethod]
        public FF_pumpsCollection FF_pumps_Select_By_FF_pumpsID(string username, string password, int FF_pumpsID)
        {
            try
            {
                FF_pumpsCollection FF_pumps = new FF_pumpsCollection();
               FF_pumps = FF_pumpsSBL_Obj.FF_pumps_Select_By_FF_pumpsID( username, password, FF_pumpsID);
                return FF_pumps;

            }
            catch (Exception e)
            {
                return null;
            }
        }       

        [WebMethod]
        public FF_pumpsCollection FF_pumps_Select_By_PumpNumber(string username, string password, string PumpNumber)
        {
            try
            {
                FF_pumpsCollection FF_pumps= new FF_pumpsCollection();
                FF_pumps = FF_pumpsSBL_Obj.FF_pumps_Select_By_PumpNumber( username, password, PumpNumber);
                return FF_pumps;

            }
            catch (Exception e)
            {
                return null;
            }
        }       

        [WebMethod]
        public FF_pumpsCollection FF_pumps_Select_By_Sector(string username, string password, string Sector)
        {
            try
            {
                FF_pumpsCollection FF_pumps = new FF_pumpsCollection();
                FF_pumps = FF_pumpsSBL_Obj.FF_pumps_Select_By_Sector(username,password,Sector);
                return FF_pumps;

            }
            catch (Exception e)
            {
                return null;
            }
        }       

        [WebMethod]
        public FF_pumpsCollection FF_pumps_Select_By_Signs(string username, string password, string Signs)
        {
            try
            {
                FF_pumpsCollection FF_pumps = new FF_pumpsCollection();
                FF_pumps  = FF_pumpsSBL_Obj.FF_pumps_Select_By_Signs( username, password, Signs);
                return FF_pumps;

            }
            catch (Exception e)
            {
                return null;
            }
        }       

        [WebMethod]
        public FF_pumpsCollection FF_pumps_Select_By_Status(string username, string password, string Status)
        {
            try
            {
                FF_pumpsCollection FF_pumps = new FF_pumpsCollection();
                FF_pumps  = FF_pumpsSBL_Obj.FF_pumps_Select_By_Status(username, password, Status);
                return FF_pumps;

            }
            catch (Exception e)
            {
                return null;
            }
        }
        [WebMethod]
        public FF_pumpsCollection FF_pumps_Select_By_UserID(string username, string password, int UserID)
        {
            try
            {
                FF_pumpsCollection FF_pumps = new FF_pumpsCollection();
                FF_pumps = FF_pumpsSBL_Obj.FF_pumps_Select_By_UserID(username, password, UserID);
                return FF_pumps;

            }
            catch (Exception e)
            {
                return null;
            }
        }

        #endregion

        #region FF_ManPowerSBL

        FF_ManPowerSBL FF_ManPowerSBL_Obj = new FF_ManPowerSBL();

        [WebMethod]
        public bool FF_ManPower_Delete(string username, string password, int FF_ManPowerID)
        {
            try
            {

                return FF_ManPowerSBL_Obj.FF_ManPower_Delete( username, password, FF_ManPowerID);

            }
            catch (Exception ex)
            {
                return false;
            }
        }


        [WebMethod]
        public bool FF_ManPower_DeleteAll(string username, string password, int FF_ID)
        {
            try
            {

                return FF_ManPowerSBL_Obj.FF_ManPower_DeleteAll(username, password, FF_ID);

            }
            catch (Exception ex)
            {
                return false;
            }
        }

        [WebMethod]
        public FF_ManPower FF_ManPower_Insert(string username, string password, FF_ManPower ManPower)
        {
            try
            {
                FF_ManPower FF_ManPower = new FF_ManPower();
                FF_ManPower  = FF_ManPowerSBL_Obj.FF_ManPower_Insert(username,password,ManPower);
                return FF_ManPower;

            }
            catch (Exception e)
            {
                return null;
            }
        }
        [WebMethod]
        public bool FF_ManPower_Update(string username, string password, FF_ManPower ManPower)
        {
            try
            {
                return FF_ManPowerSBL_Obj.FF_ManPower_Update(username, password, ManPower);
                

            }
            catch (Exception e)
            {
                return false;
            }
        }

        [WebMethod]
        public FF_ManPowerCollection FF_ManPower_Select_All(string username, string password)
        {
            try
            {
                FF_ManPowerCollection FF_ManPower = new FF_ManPowerCollection();
                FF_ManPower  = FF_ManPowerSBL_Obj.FF_ManPower_Select_All(username,password);
                return FF_ManPower;

            }
            catch (Exception e)
            {
                return null;
            }
        }       

        [WebMethod]
        public FF_ManPowerCollection FF_ManPower_Select_By_Area(string username, string password, string Area)
        {
            try
            {
                FF_ManPowerCollection FF_ManPower = new FF_ManPowerCollection();
                FF_ManPower  = FF_ManPowerSBL_Obj.FF_ManPower_Select_By_Area( username, password, Area);
                return FF_ManPower;

            }
            catch (Exception e)
            {
                return null;
            }
        }       

        [WebMethod]
        public FF_ManPowerCollection FF_ManPower_Select_By_Availability(string username, string password, string Availability)
        {
            try
            {
                FF_ManPowerCollection FF_ManPower = new FF_ManPowerCollection();
                FF_ManPower  = FF_ManPowerSBL_Obj.FF_ManPower_Select_By_Availability(username,password,Availability);
                return FF_ManPower;

            }
            catch (Exception e)
            {
                return null;
            }
        }       

        [WebMethod]
        public FF_ManPower FF_ManPower_Select_By_FF_ManPowerID(string username, string password, int FF_ManPowerID)
        {
            try
            {
                FF_ManPower FF_ManPower = new FF_ManPower();
                FF_ManPower  = FF_ManPowerSBL_Obj.FF_ManPower_Select_By_FF_ManPowerID(username,password,FF_ManPowerID);
                return FF_ManPower;

            }
            catch (Exception e)
            {
                return null;
            }
        }       

        [WebMethod]
        public FF_ManPowerCollection FF_ManPower_Select_By_Job(string username, string password, string Job)
        {
            try
            {
                FF_ManPowerCollection FF_ManPower = new FF_ManPowerCollection();
                FF_ManPower  = FF_ManPowerSBL_Obj.FF_ManPower_Select_By_Job( username, password, Job);
                return FF_ManPower;

            }
            catch (Exception e)
            {
                return null;
            }
        }       

        [WebMethod]
        public FF_ManPowerCollection FF_ManPower_Select_By_OfficerName(string username, string password, string OfficerName)
        {
            try
            {
                FF_ManPowerCollection FF_ManPower = new FF_ManPowerCollection();
                FF_ManPower  = FF_ManPowerSBL_Obj.FF_ManPower_Select_By_OfficerName(username,password,OfficerName);
                return FF_ManPower;

            }
            catch (Exception e)
            {
                return null;
            }
        }       

        [WebMethod]
        public FF_ManPowerCollection FF_ManPower_Select_By_Point(string username, string password, string Point)
        {
            try
            {
                FF_ManPowerCollection FF_ManPower = new FF_ManPowerCollection();
                FF_ManPower  = FF_ManPowerSBL_Obj.FF_ManPower_Select_By_Point(username,password,Point);
                return FF_ManPower;

            }
            catch (Exception e)
            {
                return null;
            }
        }       

        [WebMethod]
        public FF_ManPowerCollection FF_ManPower_Select_By_Rank(string username, string password, string Rank)
        {
            try
            {
                FF_ManPowerCollection FF_ManPower = new FF_ManPowerCollection();
                FF_ManPower  = FF_ManPowerSBL_Obj.FF_ManPower_Select_By_Rank(username,password,Rank);
                return FF_ManPower;

            }
            catch (Exception e)
            {
                return null;
            }
        }       

        [WebMethod]
        public FF_ManPowerCollection FF_ManPower_Select_By_Sector(string username, string password, string Sector)
        {
            try
            {
                FF_ManPowerCollection FF_ManPower = new FF_ManPowerCollection();
                FF_ManPower  = FF_ManPowerSBL_Obj.FF_ManPower_Select_By_Sector(username,password,Sector);
                return FF_ManPower;

            }
            catch (Exception e)
            {
                return null;
            }
        }       

        [WebMethod]
        public FF_ManPowerCollection FF_ManPower_Select_By_TimeSlot(string username, string password, string TimeSlot)
        {
            try
            {
                FF_ManPowerCollection FF_ManPower = new FF_ManPowerCollection();
                FF_ManPower  = FF_ManPowerSBL_Obj.FF_ManPower_Select_By_TimeSlot(username,password,TimeSlot);
                return FF_ManPower;

            }
            catch (Exception e)
            {
                return null;
            }
        }       

        [WebMethod]
        public FF_ManPowerCollection FF_ManPower_Select_By_UserID(string username, string password, int UserID)
        {
            try
            {
                FF_ManPowerCollection FF_ManPower = new FF_ManPowerCollection();
                FF_ManPower  = FF_ManPowerSBL_Obj.FF_ManPower_Select_By_UserID(username,password,UserID);
                return FF_ManPower;

            }
            catch (Exception e)
            {
                return null;
            }
        }

        [WebMethod]
        public FF_ManPowerCollection FF_ManPower_Select_By_FF_ID(string username, string password, int FF_ID)
        {
            try
            {
                FF_ManPowerCollection FF_ManPower = new FF_ManPowerCollection();
                FF_ManPower = FF_ManPowerSBL_Obj.FF_ManPower_Select_By_FF_ID(username, password, FF_ID);
                return FF_ManPower;

            }
            catch (Exception e)
            {
                return null;
            }
        }
        #endregion

        #region ExitPathwaysSBL
        ExitPathwaysSBL ExitPathwaysSBL_Obj = new ExitPathwaysSBL();

        [WebMethod]
        public ExitPathways ExitPathways_Insert(string username, string password, ExitPathways ExitPathway)
        {
            try
            {
               ExitPathways ExitPathways= new ExitPathways();
                ExitPathways  =ExitPathwaysSBL_Obj.ExitPathways_Insert( username, password, ExitPathway);
                return ExitPathways;

            }
            catch (Exception ex)
            {
                return null;
            }
        }

        [WebMethod]
        public bool ExitPathways_Update(string username, string password, ExitPathways ExitPathway)
        {
            try
            {
                bool flag = ExitPathwaysSBL_Obj.ExitPathways_Update(username, password, ExitPathway);
                return flag;

            }
            catch (Exception ex)
            {
                return false;
            }
        }

        [WebMethod]
        public ExitPathwaysCollection ExitPathways_Select_All(string username, string password)
        {
            try
            {
                ExitPathwaysCollection ExitPathways= new ExitPathwaysCollection();
                ExitPathways  =ExitPathwaysSBL_Obj.ExitPathways_Select_All(username, password);
                return ExitPathways;

            }
            catch (Exception ex)
            {
                return null;
            }
        }

        [WebMethod]
        public ExitPathwaysCollection ExitPathways_Select_By_BuildingID(string username, string password, int BuildingID)
        {
            try
            {
                ExitPathwaysCollection ExitPathways= new ExitPathwaysCollection();
                ExitPathways  =ExitPathwaysSBL_Obj.ExitPathways_Select_By_BuildingID(username,password,BuildingID);
                return ExitPathways;

            }
            catch (Exception ex)
            {
                return null;
            }
        }


        #endregion

        #region DeathSBL
            DeathSBL DeathSBL_Obj= new DeathSBL();

        [WebMethod]
        public bool Death_Delete(string username, string password, int DeathID)
        {
            try
            {
                return DeathSBL_Obj.Death_Delete( username,password, DeathID);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        [WebMethod]
        public Death Death_Insert(string username, string password, Death death)
        {
            try
            {
               Death Death= new Death();
                Death  =DeathSBL_Obj.Death_Insert( username,  password, death);
                return Death;

            }
            catch (Exception ex)
            {
                return null;
            }
        }

        [WebMethod]
        public DeathCollection Death_Select_All(string username, string password)
        {
            try
            {
               DeathCollection Death= new DeathCollection();
                Death  =DeathSBL_Obj.Death_Select_All( username, password);
                return Death;

            }
            catch (Exception ex)
            {
                return null;
            }
        }

        [WebMethod]
        public DeathCollection Death_Select_By_AccidentID(string username, string password, int AccidentID)
        {
            try
            {
               DeathCollection Death= new DeathCollection();
                Death  =DeathSBL_Obj.Death_Select_By_AccidentID( username, password,AccidentID);
                return Death;

            }
            catch (Exception ex)
            {
                return null;
            }
        }

        [WebMethod]
        public DeathCollection Death_Select_By_Age(string username, string password, int Age)
        {
            try
            {
               DeathCollection Death= new DeathCollection();
                Death  =DeathSBL_Obj.Death_Select_By_Age( username, password, Age);
                return Death;

            }
            catch (Exception ex)
            {
                return null;
            }
        }

        [WebMethod]
        public DeathCollection Death_Select_By_Civil_Military(string username, string password, string Civil_Military)
        {
            try
            {
               DeathCollection Death= new DeathCollection();
                Death  =DeathSBL_Obj.Death_Select_By_Civil_Military( username, password, Civil_Military);
                return Death;

            }
            catch (Exception ex)
            {
                return null;
            }
        }

        [WebMethod]
        public DeathCollection Death_Select_By_Date(string username, string password, DateTime Date)
        {
            try
            {
               DeathCollection Death= new DeathCollection();
                Death  =DeathSBL_Obj.Death_Select_By_Date( username, password, Date);
                return Death;

            }
            catch (Exception ex)
            {
                return null;
            }
        }

        [WebMethod]
        public DeathCollection Death_Select_By_DeathID(string username, string password, int DeathID)
        {
            try
            {
               DeathCollection Death= new DeathCollection();
                Death  =DeathSBL_Obj.Death_Select_By_DeathID( username, password, DeathID);
                return Death;

            }
            catch (Exception ex)
            {
                return null;
            }
        }

        [WebMethod]
        public DeathCollection Death_Select_By_Name(string username, string password, string Name)
        {
            try
            {
               DeathCollection Death= new DeathCollection();
                Death  =DeathSBL_Obj.Death_Select_By_Name( username,  password, Name);
                return Death;

            }
            catch (Exception ex)
            {
                return null;
            }
        }

        [WebMethod]
        public DeathCollection Death_Select_By_Rank(string username, string password, string Rank)
        {
            try
            {
               DeathCollection Death= new DeathCollection();
                Death  =DeathSBL_Obj.Death_Select_By_Rank( username, password, Rank);
                return Death;

            }
            catch (Exception ex)
            {
                return null;
            }
        }

        #endregion
        
        #region DangerousPlacesSBL
        DangerousPlacesSBL DangerousPlacesSBL_Obj =new DangerousPlacesSBL();

        [WebMethod]
        public bool DangerousPlaces_Delete_By_CompanyID(string username, string password, int CompanyID)
        {
            try
            {
                return DangerousPlacesSBL_Obj.DangerousPlaces_Delete_By_CompanyID(username, password, CompanyID);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        [WebMethod]
        public bool DangerousPlaces_Delete(string username, string password, int DangerousPlaceID)
        {
            try
            {
                return DangerousPlacesSBL_Obj.DangerousPlaces_Delete(username, password, DangerousPlaceID);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        [WebMethod]
        public DangerousPlaces DangerousPlaces_Insert(string username, string password, DangerousPlaces dangerousPlaces)
        {
            try
            {
                DangerousPlaces DangerousPlaces = new DangerousPlaces();
                DangerousPlaces  =DangerousPlacesSBL_Obj.DangerousPlaces_Insert( username, password, dangerousPlaces);
                return DangerousPlaces;

            }
            catch (Exception ex)
            {
                return null;
            }
        }

        [WebMethod]
        public bool DangerousPlaces_Update(string username, string password, DangerousPlaces dangerousPlaces)
        {
            try
            {
                bool flag = DangerousPlacesSBL_Obj.DangerousPlaces_Update(username, password, dangerousPlaces);
                return flag;

            }
            catch (Exception ex)
            {
                return false;
            }
        }
        [WebMethod]
        public DangerousPlacesCollection DangerousPlaces_Select_All(string username, string password)
        {
            try
            {
               DangerousPlacesCollection DangerousPlaces= new DangerousPlacesCollection();
                DangerousPlaces  =DangerousPlacesSBL_Obj.DangerousPlaces_Select_All( username, password);
                return DangerousPlaces;

            }
            catch (Exception ex)
            {
                return null;
            }
        }

        [WebMethod]
        public DangerousPlacesCollection DangerousPlaces_Select_By_CompanyID(string username, string password, int CompanyID)
        {
            try
            {
               DangerousPlacesCollection DangerousPlaces= new DangerousPlacesCollection();
                DangerousPlaces  =DangerousPlacesSBL_Obj.DangerousPlaces_Select_By_CompanyID( username, password, CompanyID);
                return DangerousPlaces;

            }
            catch (Exception ex)
            {
                return null;
            }
        }

        [WebMethod]
        public DangerousPlaces DangerousPlaces_Select_By_ID(string username, string password, int DangerousPlaceID)
        {
            try
            {
                DangerousPlaces DangerousPlaces = new DangerousPlaces();
                DangerousPlaces = DangerousPlacesSBL_Obj.DangerousPlaces_Select_By_ID(username, password, DangerousPlaceID);
                return DangerousPlaces;

            }
            catch (Exception ex)
            {
                return null;
            }
        }
        [WebMethod]
        public DangerousPlacesCollection DangerousPlaces_Select_By_FireMediator(string username, string password, string FireMediator)
        {
            try
            {
               DangerousPlacesCollection DangerousPlaces= new DangerousPlacesCollection();
                DangerousPlaces  =DangerousPlacesSBL_Obj.DangerousPlaces_Select_By_FireMediator( username, password, FireMediator);
                return DangerousPlaces;

            }
            catch (Exception ex)
            {
                return null;
            }
        }

        [WebMethod]
        public DangerousPlacesCollection DangerousPlaces_Select_By_HazardousSubstance(string username, string password, string HazardousSubstance)
        {
            try
            {
               DangerousPlacesCollection DangerousPlaces= new DangerousPlacesCollection();
                DangerousPlaces  =DangerousPlacesSBL_Obj.DangerousPlaces_Select_By_HazardousSubstance( username, password, HazardousSubstance);
                return DangerousPlaces;

            }
            catch (Exception ex)
            {
                return null;
            }
        }

        [WebMethod]
        public DangerousPlacesCollection DangerousPlaces_Select_By_Location(string username, string password, string Location)
        {
            try
            {
               DangerousPlacesCollection DangerousPlaces= new DangerousPlacesCollection();
                DangerousPlaces  =DangerousPlacesSBL_Obj.DangerousPlaces_Select_By_Location(username,password,Location);
                return DangerousPlaces;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        #endregion

        #region CompanySBL
            CompanySBL CompanySBL_Obj=new CompanySBL();
            
        [WebMethod]
        public bool Company_Delete(string username, string password, int CompanyID)
        {
            try
            {
                return CompanySBL_Obj.Company_Delete( username, password, CompanyID);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        [WebMethod]
        public ICompany Company_Insert(string username, string password, ICompany company)
        {
            try
            {
                ICompany Company= new ICompany();
                Company=CompanySBL_Obj.Company_Insert( username, password, company);
                return Company;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        [WebMethod]
        public bool Company_Update(string username, string password, ICompany company)
        {
            try
            {
                bool flag= CompanySBL_Obj.Company_Update(username, password, company);
                return flag;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        [WebMethod]
        public CompanyCollection Company_Select_All(string username, string password)
        {
            try
            {
                CompanyCollection Company_obj = new CompanyCollection();
                Company_obj = CompanySBL_Obj.Company_Select_All( username, password);
                return Load_Company_Data(username, password, Company_obj);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        [WebMethod]
        public CompanyCollection Company_Select_By_Address(string username, string password, string address)
        {
            try
            {
               CompanyCollection Company_obj = new CompanyCollection();
               Company_obj = CompanySBL_Obj.Company_Select_By_Address(username,password,address);
               return Load_Company_Data(username, password, Company_obj);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        [WebMethod]
        public CompanyCollection Company_Select_By_BackCompanyBusiness(string username, string password, string BackCompanyBusiness)
        {
            try
            {
                CompanyCollection Company_obj = new CompanyCollection();
                Company_obj = CompanySBL_Obj.Company_Select_By_BackCompanyBusiness(username,password,BackCompanyBusiness);
                return Load_Company_Data(username, password, Company_obj);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        [WebMethod]
        public CompanyCollection Company_Select_By_BackCompanyName(string username, string password, string BackCompanyName)
        {
            try
            {
                CompanyCollection Company_obj = new CompanyCollection();
                Company_obj = CompanySBL_Obj.Company_Select_By_BackCompanyName( username, password, BackCompanyName);
                return Load_Company_Data(username, password, Company_obj);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        [WebMethod]
        public ICompany Company_Select_By_ISSI(string username, string password, string ISSI)
        {
            try
            {
                ICompany Company_obj = new ICompany();
                Company_obj = CompanySBL_Obj.Company_Select_By_ISSI(username, password, ISSI);
                return Load_Company_Data(username, password, new CompanyCollection() { Company_obj })[0];
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        [WebMethod]
        public CompanyCollection Company_Select_By_BackFireMediator(string username, string password, string BackFireMediator)
        {
            try
            {
                CompanyCollection Company_obj = new CompanyCollection();
                Company_obj = CompanySBL_Obj.Company_Select_By_BackFireMediator( username, password, BackFireMediator);
                return Load_Company_Data(username, password, Company_obj);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        [WebMethod]
        public CompanyCollection Company_Select_By_BuildingsNumber(string username, string password, int BuildingsNumber)
        {
            try
            {
                CompanyCollection Company_obj = new CompanyCollection();
                Company_obj = CompanySBL_Obj.Company_Select_By_BuildingsNumber( username, password,BuildingsNumber);
                return Load_Company_Data(username, password, Company_obj);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

         [WebMethod]
        public ICompany Company_Select_By_CompanyID(string username, string password, int CompanyID)
        {
            try
            {
                
                ICompany Company_obj= new ICompany();
                Company_obj=CompanySBL_Obj.Company_Select_By_CompanyID( username, password, CompanyID);
                return Load_Company_Data(username, password, new CompanyCollection() { Company_obj })[0];
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        [WebMethod]
        public CompanyCollection Company_Select_By_ElectricalPanelLocation(string username, string password, string ElectricalPanelLocation)
        {
            try
            {
                CompanyCollection Company_obj = new CompanyCollection();
                Company_obj = CompanySBL_Obj.Company_Select_By_ElectricalPanelLocation(username,password,ElectricalPanelLocation);
                return Load_Company_Data(username, password, Company_obj);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        [WebMethod]
        public CompanyCollection Company_Select_By_FrontCompanyBusiness(string username, string password, string FrontCompanyBusiness)
        {
            try
            {
                CompanyCollection Company_obj = new CompanyCollection();
                Company_obj = CompanySBL_Obj.Company_Select_By_FrontCompanyBusiness( username, password, FrontCompanyBusiness);
                return Load_Company_Data(username, password, Company_obj);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        [WebMethod]
        public CompanyCollection Company_Select_By_FrontCompanyName(string username, string password, string FrontCompanyName)
        {
            try
            {
                CompanyCollection Company_obj = new CompanyCollection();
                Company_obj = CompanySBL_Obj.Company_Select_By_FrontCompanyName( username, password, FrontCompanyName);
                return Load_Company_Data(username, password, Company_obj);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        [WebMethod]
        public CompanyCollection Company_Select_By_FrontFireMediator(string username, string password, string FrontFireMediator)
        {
            try
            {
                CompanyCollection Company_obj = new CompanyCollection();
                Company_obj = CompanySBL_Obj.Company_Select_By_FrontFireMediator( username, password, FrontFireMediator);
                return Load_Company_Data(username, password, Company_obj);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        [WebMethod]
        public CompanyCollection Company_Select_By_GasTrapLocation(string username, string password, string GasTrapLocation)
        {
            try
            {
                CompanyCollection Company_obj = new CompanyCollection();
                Company_obj = CompanySBL_Obj.Company_Select_By_GasTrapLocation( username, password, GasTrapLocation);
                return Load_Company_Data(username, password, Company_obj);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        [WebMethod]
        public CompanyCollection Company_Select_By_LandlinePhoneNumber(string username, string password, string LandlinePhoneNumber)
        {
            try
            {
                CompanyCollection Company_obj = new CompanyCollection();
                Company_obj = CompanySBL_Obj.Company_Select_By_LandlinePhoneNumber( username, password, LandlinePhoneNumber);
                return Load_Company_Data(username, password, Company_obj);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        [WebMethod]
        public CompanyCollection Company_Select_By_LeftCompanyBusiness(string username, string password, string LeftCompanyBusiness)
        {
            try
            {
                CompanyCollection Company_obj = new CompanyCollection();
                Company_obj = CompanySBL_Obj.Company_Select_By_LeftCompanyBusiness( username, password, LeftCompanyBusiness);
                return Load_Company_Data(username, password, Company_obj);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        [WebMethod]
        public CompanyCollection Company_Select_By_LeftCompanyName(string username, string password, string LeftCompanyName)
        {
            try
            {
                CompanyCollection Company_obj = new CompanyCollection();
                Company_obj = CompanySBL_Obj.Company_Select_By_LeftCompanyName( username, password, LeftCompanyName);
                return Load_Company_Data(username, password, Company_obj);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        [WebMethod]
        public CompanyCollection Company_Select_By_LeftFireMediator(string username, string password, string LeftFireMediator)
        {
            try
            {
                CompanyCollection Company_obj = new CompanyCollection();
                Company_obj = CompanySBL_Obj.Company_Select_By_LeftFireMediator( username ,password, LeftFireMediator);
                return Load_Company_Data(username, password, Company_obj);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        [WebMethod]
        public CompanyCollection Company_Select_By_Name(string username, string password, string Name)
        {
            try
            {
                CompanyCollection Company_obj = new CompanyCollection();
                Company_obj = CompanySBL_Obj.Company_Select_By_Name( username, password, Name);
                return Load_Company_Data(username, password, Company_obj);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        [WebMethod]
        public CompanyCollection Company_Select_By_OxygenTrapLocation(string username, string password, string OxygenTrapLocation)
        {
            try
            {
                CompanyCollection Company_obj = new CompanyCollection();
                Company_obj = CompanySBL_Obj.Company_Select_By_OxygenTrapLocation( username, password, OxygenTrapLocation);
                return Load_Company_Data(username, password, Company_obj);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        [WebMethod]
        public CompanyCollection Company_Select_By_RightCompanyBusiness(string username, string password, string RightCompanyBusiness)
        {
            try
            {
                CompanyCollection Company_obj = new CompanyCollection();
                Company_obj = CompanySBL_Obj.Company_Select_By_RightCompanyBusiness( username, password, RightCompanyBusiness);
                return Load_Company_Data(username, password, Company_obj);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        [WebMethod]
        public CompanyCollection Company_Select_By_RightCompanyName(string username, string password, string RightCompanyName)
        {
            try
            {
                CompanyCollection Company_obj = new CompanyCollection();
                Company_obj = CompanySBL_Obj.Company_Select_By_RightCompanyName( username, password, RightCompanyName);
                return Load_Company_Data(username, password, Company_obj);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        [WebMethod]
        public CompanyCollection Company_Select_By_RightFireMediator(string username, string password, string RightFireMediator)
        {
            try
            {
                CompanyCollection Company_obj = new CompanyCollection();
                Company_obj = CompanySBL_Obj.Company_Select_By_RightFireMediator( username, password,  RightFireMediator);
                return Load_Company_Data(username, password, Company_obj);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        [WebMethod]
        public CompanyCollection Company_Select_By_UserID(string username, string password, int UserID)
        {
            try
            {
                CompanyCollection Company_obj = new CompanyCollection();
                Company_obj = CompanySBL_Obj.Company_Select_By_UserID( username, password, UserID);
                return Load_Company_Data( username, password,Company_obj);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        private CompanyCollection Load_Company_Data(string username, string password, CompanyCollection Company_Array)
        {
            if (Company_Array != null)
                for (int loop = 0; loop < Company_Array.Count; loop++)
                {
                    Company_Array[loop].companyManagers = Managers_Select_By_CompanyID(username, password, Company_Array[loop].CompanyID);
                    Company_Array[loop].CompanyDangerousPlaces=DangerousPlaces_Select_By_CompanyID(username, password, Company_Array[loop].CompanyID);
                    Company_Array[loop].companyBuildings=Buildings_Select_By_CompanyID(username, password, Company_Array[loop].CompanyID);
                    Company_Array[loop].CompanyAccident=Accident_Select_By_CompanyID(username, password, Company_Array[loop].CompanyID);
                }
            return Company_Array;
        }
      
        #endregion

        #region Managers
        ManagersSBL ManagersSBL_Obj = new ManagersSBL();

        [WebMethod]
        public bool Managers_Delete(string username, string password, int ManagerID)
        {
            try
            {
                return ManagersSBL_Obj.Managers_Delete(username, password, ManagerID);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        [WebMethod]
        public Managers Managers_Insert(string username, string password, Managers Manager)
        {
            try
            {
                return ManagersSBL_Obj.Managers_Insert(username, password, Manager);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        [WebMethod]
        public ManagersCollection Managers_Select_All(string username, string password)
        {
            try
            {
                return ManagersSBL_Obj.Managers_Select_All(username, password);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        [WebMethod]
        public ManagersCollection Managers_Select_By_CompanyID(string username, string password, int CompanyID)
        {
            try
            {
                return ManagersSBL_Obj.Managers_Select_By_CompanyID(username, password, CompanyID);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        [WebMethod]
        public Managers Managers_SelectByManagerID(string username, string password, int ManagerID)
        {
            try
            {
                return ManagersSBL_Obj.Managers_SelectByManagerID(username, password, ManagerID);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        #endregion

        #region BuildingSBL
        BuildingSBL BuildingSBL_Obj =new BuildingSBL();

        [WebMethod]
        public bool Buildings_Delete(string username, string password, int BuildingID)
        {
            try
            {
                return BuildingSBL_Obj.Buildings_Delete( username, password, BuildingID);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        [WebMethod]
        public bool Buildings_Delete_By_CompanyID(string username, string password, int CompanyID)
        {
            try
            {
                return BuildingSBL_Obj.Buildings_Delete_By_CompanyID(username, password, CompanyID);
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        [WebMethod]
        public Buildings Buildings_Insert(string username, string password, Buildings buildings)
        {
            try
            {
                Buildings Buildings_obj = new Buildings();
                Buildings_obj = BuildingSBL_Obj.Buildings_Insert( username, password, buildings);
                return Load_Buildings_Data(username, password, new BuildingsCollection() { Buildings_obj })[0];
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        [WebMethod]
        public bool Buildings_Update(string username, string password, Buildings buildings)
        {
            try
            {
                bool flag = BuildingSBL_Obj.Building_Update(username, password, buildings);
                return flag;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        [WebMethod]
        public BuildingsCollection Buildings_Select_All(string username, string password)
        {
            try
            {
                BuildingsCollection Buildings_obj = new BuildingsCollection();
                Buildings_obj = BuildingSBL_Obj.Buildings_Select_All(username, password);
                return Load_Buildings_Data(username, password, Buildings_obj );
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        [WebMethod]
        public Buildings Buildings_Select_By_BuildingID(string username, string password, int ID)
        {
            try
            {
                Buildings Buildings_obj = new Buildings();
                Buildings_obj = BuildingSBL_Obj.Buildings_Select_By_BuildingID(username,password,ID);
                return Load_Buildings_Data(username, password, new BuildingsCollection() { Buildings_obj })[0];
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        [WebMethod]
        public BuildingsCollection Buildings_Select_By_BuildingNumber(string username, string password, int BuildingNumber)
        {
            try
            {
                BuildingsCollection Buildings_obj = new BuildingsCollection();
                Buildings_obj = BuildingSBL_Obj.Buildings_Select_By_BuildingNumber(  username, password, BuildingNumber);
                return Load_Buildings_Data(username, password, Buildings_obj);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        [WebMethod]
        public BuildingsCollection Buildings_Select_By_CompanyID(string username, string password, int CompanyID)
        {
            try
            {
                BuildingsCollection Buildings_obj = new BuildingsCollection();
                Buildings_obj = BuildingSBL_Obj.Buildings_Select_By_CompanyID( username, password, CompanyID);
                return Load_Buildings_Data(username, password, Buildings_obj);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        [WebMethod]
        public BuildingsCollection Buildings_Select_By_FloorsNumber(string username, string password, int FloorsNumber)
        {
            try
            {
                BuildingsCollection Buildings_obj = new BuildingsCollection();
                Buildings_obj = BuildingSBL_Obj.Buildings_Select_By_FloorsNumber(username,password,FloorsNumber);
                return Load_Buildings_Data(username, password, Buildings_obj);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        private BuildingsCollection Load_Buildings_Data(string username, string password, BuildingsCollection Buildings_Array)
        {
            if (Buildings_Array != null)
                for (int loop = 0; loop < Buildings_Array.Count; loop++)
                {
                    Buildings_Array[loop].BuildingFloors = Floors_Select_By_BuildingID(username, password, Buildings_Array[loop].BuildingID);
                    Buildings_Array[loop].BuildingImageCollection = Images_Select_By_BuildingID(username, password, Buildings_Array[loop].BuildingID);
                    Buildings_Array[loop].BuildingExitPaths = ExitPathways_Select_By_BuildingID(username, password, Buildings_Array[loop].BuildingID);
                }
            return Buildings_Array;
        }
        #endregion

        #region AccidentSBL
        AccidentSBL AccidentSBL_Obj=new AccidentSBL();
        [WebMethod]
        public bool Accident_Delete(string username, string password, int accidentid)
        {
            try
            {
                return AccidentSBL_Obj.Accident_Delete(username,password,accidentid);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

         [WebMethod]
        public Accident Accident_Insert(string username, string password, Accident accident)
        {
            try
            {
                Accident Accident= new Accident();
                Accident=AccidentSBL_Obj.Accident_Insert( username,  password,  accident);
                return Accident;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        [WebMethod]
        public AccidentCollection Accident_Select_All(string username, string password)
        {
            try
            {
                AccidentCollection Accident= new AccidentCollection();
                Accident=AccidentSBL_Obj.Accident_Select_All( username, password);
                return Accident;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        [WebMethod]
        public Accident Accident_Select_By_AccidentNumber(string username, string password, int AccidentNumber)
        {
            try
            {
                Accident Accident= new Accident();
                Accident=AccidentSBL_Obj.Accident_Select_By_AccidentNumber( username, password, AccidentNumber);
                return Accident;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        [WebMethod]
        public AccidentCollection Accident_Select_By_CompanyID(string username, string password, int CompanyID)
        {
            try
            {
                AccidentCollection Accident= new AccidentCollection();
                Accident=AccidentSBL_Obj.Accident_Select_By_CompanyID( username, password, CompanyID);
                return Accident;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        [WebMethod]
        public AccidentCollection Accident_Select_By_Date(string username, string password, DateTime date)
        {
            try
            {
                AccidentCollection Accident= new AccidentCollection();
                Accident=AccidentSBL_Obj.Accident_Select_By_Date( username, password, date);
                return Accident;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        [WebMethod]
        public AccidentCollection Accident_Select_By_Equipments(string username, string password, string equipments)
        {
            try
            {
                AccidentCollection Accident= new AccidentCollection();
                Accident=AccidentSBL_Obj.Accident_Select_By_Equipments( username, password, equipments);
                return Accident;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        [WebMethod]
        public Accident Accident_Select_By_ID(string username, string password, int ID)
        {
            try
            {
                Accident Accident= new Accident();
                Accident=AccidentSBL_Obj.Accident_Select_By_ID( username, password, ID);
                return Accident;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        [WebMethod]
        public AccidentCollection Accident_Select_By_LossesType(string username, string password, string LossesType)
        {
            try
            {
                AccidentCollection Accident= new AccidentCollection();
                Accident=AccidentSBL_Obj.Accident_Select_By_LossesType( username, password, LossesType);
                return Accident;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        [WebMethod]
        public AccidentCollection Accident_Select_By_TimeToArrive(string username, string password, DateTime TimeToArrive)
        { 
            try
            {
                AccidentCollection Accident= new AccidentCollection();
                Accident=AccidentSBL_Obj.Accident_Select_By_TimeToArrive( username, password, TimeToArrive);
                return Accident;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        [WebMethod]
        public AccidentCollection Accident_Select_By_TimeToSend(string username, string password, DateTime TimeToSend)
        { 
            try
            {
                AccidentCollection Accident= new AccidentCollection();
                Accident=AccidentSBL_Obj.Accident_Select_By_TimeToSend( username, password, TimeToSend);
                return Accident;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        [WebMethod]
        public AccidentCollection Accident_Select_By_Type(string username, string password, string AccidentType)
        { 
            try
            {
                AccidentCollection Accident= new AccidentCollection();
                Accident=AccidentSBL_Obj.Accident_Select_By_Type( username, password, AccidentType);
                return Accident;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        [WebMethod]
        public AccidentCollection Accident_Select_By_VehiclesToAccident(string username, string password, string VehiclesToAccident)
        { 
            try
            {
                AccidentCollection Accident= new AccidentCollection();
                Accident=AccidentSBL_Obj.Accident_Select_By_VehiclesToAccident(username, password, VehiclesToAccident);
                return Accident;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        #endregion  
    }
}
