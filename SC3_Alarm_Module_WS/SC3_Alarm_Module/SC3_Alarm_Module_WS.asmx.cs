using SC3_Alarm_Module.Collection;
using SC3_Alarm_Module.Entity;
using SC3_Alarm_Module.SBL;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Services;

namespace SC3_Alarm_Module
{
    /// <summary>
    /// Summary description for WebService1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class SC3_Alarm_Module_WS : System.Web.Services.WebService
    {
        #region Alarms

        AlarmsSBL AlarmsSBL_Obj = new AlarmsSBL();

        [WebMethod]
        public bool Alarms_Delete_Row(string username, string password, int alarm_id)
        {
            try
            {
                return AlarmsSBL_Obj.Alarms_Delete_Row(username, password, alarm_id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }

         
        [WebMethod]
        public bool Alarms_Delete_User_AckAlarms(string username,string password)
        {
            try
            {
                return AlarmsSBL_Obj.Alarms_Delete_User_AckAlarms(username, password);
            }
            
            catch (Exception ex)
            {
                throw ex;
            }
            
        }
     
        [WebMethod]
        public bool Alarms_Delete_User_AllAlarms(string username, string password)
        {
            try
            {
                return AlarmsSBL_Obj.Alarms_Delete_User_AllAlarms(username,password);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }
         
        [WebMethod]
        public Alarms Alarms_Insert(string username, string password, Alarms New_Alarm)
        {
            try
            {
                return AlarmsSBL_Obj.Alarm_Insert(username, password, New_Alarm);
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
            
        }


        [WebMethod]
        public AlarmsCollection Alarms_Select(string username,string password,int alarm_id)
        {
            try
            {
                return AlarmsSBL_Obj.Alarms_Select(username, password, alarm_id);
            }
            catch (Exception ex)
            { 
                throw ex;
            }
            
        }
        [WebMethod]
        public AlarmsCollection Alarms_Select_Date(string username, string password, DateTime from, DateTime to)
        {
            try
            {
                return AlarmsSBL_Obj.Alarms_Select_Date(username, password, from, to);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [WebMethod]
        public AlarmsCollection Alarms_Select_VisibleAlarms(string username,string password)
        {
            try
            {
                return AlarmsSBL_Obj.Alarms_Select_VisibleAlarms(username, password);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        [WebMethod]
        public AlarmsCollection Alarms_Select_ALL(string username, string password)
        {
            try
            {
                return AlarmsSBL_Obj.Alarm_Select_ALL(username, password);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        

        [WebMethod]
        public AlarmsCollection Alarms_SelectByBuildingID(string username, string password, int buildingID)
        {
            try
            {
                return AlarmsSBL_Obj.Alarms_SelectByBuildingID(username, password, buildingID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [WebMethod]
        public AlarmsCollection Alarms_SelectByMovableID(string username, string password, int movableID)
        {
            try
            {
                return AlarmsSBL_Obj.Alarms_SelectByMovableID(username, password, movableID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [WebMethod]
        public bool Alarms_Update(string username,string password,Alarms Upd)
        {
            try
            {
                return AlarmsSBL_Obj.Alarms_Update(username, password, Upd);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        [WebMethod]
        public bool Alarms_UpdateVisibility_User_AckAlarms(string username, string password)
        {
            try
            {
                return AlarmsSBL_Obj.Alarms_UpdateVisibility_User_AckAlarms(username, password);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        [WebMethod]
        public bool Alarms_UpdateVisibility_User_AllAlarms(string username, string password)
        {
            try
            {
                return AlarmsSBL_Obj.Alarms_UpdateVisibility_User_AllAlarms(username, password);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Building_Alarm_Unit

        Building_Alarm_UnitSBL Building_Alarm_UnitSBL_Obj = new Building_Alarm_UnitSBL();

        [WebMethod]
        public bool Building_AlarmUnit_Delete(string username, string password, int building_alarmunit_id)
        {
            try
            {
                return Building_Alarm_UnitSBL_Obj.Building_AlarmUnit_Delete(username,password,building_alarmunit_id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }
        [WebMethod]
        public bool Building_AlarmUnit_Delete_All(string username, string password)
        {
            try
            {
                return Building_Alarm_UnitSBL_Obj.Building_AlarmUnit_Delete_All(username, password);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        [WebMethod]
        public Building_Alarm_Unit Building_AlarmUnit_Insert(string username,string password, Building_Alarm_Unit New_Building_AlarmUnit)
        {
            try
            {
                return Building_Alarm_UnitSBL_Obj.Building_AlarmUnit_Insert(username,password, New_Building_AlarmUnit);
            }
            catch (Exception ex)
            {
              
                throw ex;
            }
            
        }
        [WebMethod]
        public Building_Alarm_UnitCollection Building_AlarmUnit_Select(string username, string password, int building_alarmunit_id)
        {
            try
            {
                return Building_Alarm_UnitSBL_Obj.Building_AlarmUnit_Select(username, password, building_alarmunit_id);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        [WebMethod]
        public Building_Alarm_UnitCollection Building_AlarmUnit_Select_ALL(string username, string password)
        {
            try
            {
                return Building_Alarm_UnitSBL_Obj.Building_AlarmUnit_Select_ALL(username, password);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        [WebMethod]
        public Building_Alarm_UnitCollection Building_AlarmUnit_SelectByUsername(string username, string password)
        {
            try
            {
                Building_Alarm_UnitCollection BU_Array = new Building_Alarm_UnitCollection();
                BU_Array = Building_Alarm_UnitSBL_Obj.Building_AlarmUnit_SelectByUsername(username, password);
                 return Load_Building_Alarm_Unit_Details(username, password, BU_Array);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        [WebMethod]
         public bool Building_AlarmUnit_Update(string username,string password, Building_Alarm_Unit Upd_Building_AU)
        {
            try
            {
                return Building_Alarm_UnitSBL_Obj.Building_AlarmUnit_Update(username, password, Upd_Building_AU);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }
        private Building_Alarm_UnitCollection Load_Building_Alarm_Unit_Details(string username, string password, Building_Alarm_UnitCollection building_Units)
        {
            try
            {
                for (int i = 0; i < building_Units.Count; i++)
                {
                    building_Units[i].Alarms = new AlarmsCollection();
                    building_Units[i].Alarms = Alarms_SelectByBuildingID(username, password, building_Units[i].Building_AlarmUnit_ID);
                }

                return building_Units;
            }
            catch (Exception ex)
            {
                return null;
            }
        }


        #endregion

        #region Movable_Alarm_Unit

        Movable_Alarm_UnitSBL Movable_Alarm_UnitSBL_Obj = new Movable_Alarm_UnitSBL();

        [WebMethod]
        public bool Movable_AlarmUnit_Delete(string username, string password, int movable_alarmunit_id)
        {
            try
            {
                return Movable_Alarm_UnitSBL_Obj.Movable_AlarmUnit_Delete(username, password, movable_alarmunit_id);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        [WebMethod]
        public bool Movable_AlarmUnit_Delete_All(string username, string password)
        {
            try
            {
                return Movable_Alarm_UnitSBL_Obj.Movable_AlarmUnit_Delete_All(username, password);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        [WebMethod]
        public Movable_Alarm_Unit Movable_AlarmUnit_Insert(string username, string password, Movable_Alarm_Unit New_Movable_AlarmUnit)
        {
            try
            {
                return Movable_Alarm_UnitSBL_Obj.Movable_AlarmUnit_Insert(username, password, New_Movable_AlarmUnit);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        [WebMethod]
        public Movable_Alarm_UnitCollection Movable_AlarmUnit_Select(string username, string password, int movable_alarmunit_id)
        {
            try
            {
                return Movable_Alarm_UnitSBL_Obj.Movable_AlarmUnit_Select(username, password, movable_alarmunit_id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [WebMethod]
        public Movable_Alarm_UnitCollection Movable_AlarmUnit_Select_ALL(string username, string password)
        {
            try
            {
                return Movable_Alarm_UnitSBL_Obj.Movable_AlarmUnit_Select_ALL(username, password);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [WebMethod]
        public Movable_Alarm_UnitCollection Movable_AlarmUnit_SelectByUsername(string username, string password)
        {
            try
            {
                Movable_Alarm_UnitCollection MU_Array = new Movable_Alarm_UnitCollection();
                MU_Array = Movable_Alarm_UnitSBL_Obj.Movable_AlarmUnit_SelectByUsername(username, password);
                return Load_Movable_Alarm_Unit_Details(username, password, MU_Array);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [WebMethod]
        public bool Movable_AlarmUnit_Update(string username, string password, Movable_Alarm_Unit Upd_Movable_AU)
        {
            try
            {
                return Movable_Alarm_UnitSBL_Obj.Movable_AlarmUnit_Update(username, password, Upd_Movable_AU);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        [WebMethod]
        public bool Movable_AlarmUnit_Update_User(string username, string password, Movable_Alarm_Unit Upd_Movable_AU)
        {
            try
            {
                return Movable_Alarm_UnitSBL_Obj.Movable_AlarmUnit_Update_User(username, password, Upd_Movable_AU);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        private Movable_Alarm_UnitCollection Load_Movable_Alarm_Unit_Details(string username, string password, Movable_Alarm_UnitCollection movable_Units)
        {
            try
            {
                for (int i = 0; i < movable_Units.Count; i++)
                {
                    movable_Units[i].Alarms = new AlarmsCollection();
                    movable_Units[i].Alarms = Alarms_SelectByMovableID(username, password, movable_Units[i].Movable_AlarmUnit_ID);
                }

                return movable_Units;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        #endregion

        #region Users 

        UsersSBL UsersSBL_Obj = new UsersSBL();
        
        [WebMethod]
        public bool Users_Delete(string username,string password,int user_id, int user_delete_id)
        {
            try
            {
                return UsersSBL_Obj.Users_Delete(username, password, user_id, user_delete_id);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        
        [WebMethod]
        public Users Users_Insert( string username,string password, Users New_User)
        {
            try
            {
                return UsersSBL_Obj.Users_Insert(username, password, New_User);
            }
            catch (Exception ex)
            {

                throw ex ;
            }
        }
        
     
        [WebMethod]
        public UsersCollection Users_Select(string username,string password)
        {
            try
            {
                UsersCollection users = new UsersCollection();
                users = UsersSBL_Obj.Users_Select(username, password);
                UsersCollection co = Load_User_Details(username, password, users);
                return co;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        [WebMethod]
        public bool Users_Update(string Old_Username, string Old_Password, int user_id, Users Upd_User)
        {
            try
            {
                return UsersSBL_Obj.Users_Update(Old_Username, Old_Password, user_id, Upd_User);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }

        [WebMethod]
        public UsersCollection Users_Select_Users_Of_Admin_User(string username, string password)
        {
            try
            {
                UsersCollection users = new UsersCollection();
                users = UsersSBL_Obj.Users_Selct_Users_Of_Admin_User(username, password);
                UsersCollection co = Load_User_Details(username, password, users);
                return co;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }
        [WebMethod]
        public UsersCollection Users_Select_Super_Admin(string username, string password)
        {
            try
            {
                
                return UsersSBL_Obj.Users_Select_Super_Admin(username, password);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        [WebMethod]
        public UsersCollection Users_Select_All(string username, string password)
        {
            try
            {
                UsersCollection users = new UsersCollection();
                users = UsersSBL_Obj.Users_Select_All(username, password);
                UsersCollection co = Load_User_Details(username, password, users);
                return co;

            }
            catch (Exception e)
            {
                return null;
            }
        }
        private UsersCollection Load_User_Details(string username , string password, UsersCollection users)
        {
            try
            {
                if(users != null)
                {
                    for(int i = 0; i<users.Count; i++)
                    {
                        users[i].Maps = new MapsCollection();
                        users[i].Maps = Maps_SelectAll(users[i].Username, users[i].Password);

                        users[i].UsersCollection = new UsersCollection();
                        users[i].UsersCollection = Users_Select_Users_Of_Admin_User(users[i].Username, users[i].Password);

                        users[i].Movable_Alarm_Units = new Movable_Alarm_UnitCollection();
                        users[i].Movable_Alarm_Units = Movable_AlarmUnit_SelectByUsername(users[i].Username, users[i].Password);

                        users[i].Layers = new LayersCollection();
                        users[i].Layers = Layers_SelectByUserId(users[i].Username, users[i].Password, users[i].User_ID);

                        users[i].Building_Alarm_Units = new Building_Alarm_UnitCollection();
                        users[i].Building_Alarm_Units = Building_AlarmUnit_SelectByUsername(users[i].Username, users[i].Password);

                        //users[i].Alarms = new AlarmsCollection();
                        //users[i].Alarms = Alarms_Select_ALL(users[i].Username, users[i].Password);

                        users[i].Alarm_Type = new Alarm_TypeCollection();
                        users[i].Alarm_Type = Alarm_Type_Select_All(users[i].Username, users[i].Password);

                        users[i].Zones = new ZonesCollection();
                        users[i].Zones = Zones_SelectByUserId(users[i].Username, users[i].Password, users[i].User_ID);
                    }
                    
                }
                return users;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        [WebMethod]
        public Users Users_InsertByAdmin(string username, string password, int userid, Users user)
        {
            try
            {
                return UsersSBL_Obj.Users_InsertByAdmin(username, password, userid, user);
            }
            catch (Exception ex)
            {
                return null;
            }
        }


        #endregion

        #region Admin_Users

        Admin_UsersSBL Admin_UsersSBL_Obj = new Admin_UsersSBL();
        [WebMethod]

         public bool Admin_Users_Delete(string username, string password, int user_id, int admin_id, int user_id2)
        {
            try
            {
                return Admin_UsersSBL_Obj.Admin_Users_Delete(username, password, user_id, admin_id, user_id2);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        [WebMethod]
        public Admin_Users Admin_Users_Insert(string username, string password, int user_id, Admin_Users New_Admin)
        {
            try
            {
                return Admin_UsersSBL_Obj.Admin_Users_Insert(username, password, user_id,New_Admin);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        [WebMethod]
        public Admin_UsersCollection Users_Admins_Select_All(string username, string password)
        {
            try
            {
                return Admin_UsersSBL_Obj.Users_Admins_Select_All(username, password);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        [WebMethod]
        public bool Users_Admins_Insert_Bulk(string username, string password, Admin_UsersCollection Users_Admins_Array)
        {
            try
            {
                return Admin_UsersSBL_Obj.Users_Admins_Insert_Bulk(username, password, Users_Admins_Array);
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        [WebMethod]
        public bool Users_Admins_Delete(string username, string password, int user_id, int Admin_id)
        {
            try
            {
                return Admin_UsersSBL_Obj.Users_Admins_Delete(username, password, user_id, Admin_id);
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        #endregion

        #region  Maps

        MapsSBL MapsSBL_Obj = new MapsSBL();
        [WebMethod]
        public bool Maps_Delete(string username, string password, int Map_id)
        {
            try
            {
                return MapsSBL_Obj.Maps_Delete(username, password, Map_id);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        [WebMethod]
        public Maps Maps_Insert(string username, string password, Maps Map)
        {
            try
            {
                return MapsSBL_Obj.Maps_Insert(username, password, Map);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        [WebMethod]
        public MapsCollection Maps_Select(string username, string password, int map_id)
        {
            try
            {
                return MapsSBL_Obj.Maps_Select(username, password, map_id);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        [WebMethod]
        public MapsCollection Maps_SelectAll(string username, string password)
        {
            try
            {
                return MapsSBL_Obj.Maps_SelectAll(username, password);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        [WebMethod]
        public bool Maps_Update(string username, string password, Maps Upd_Map)
        {
            try
            {
                return MapsSBL_Obj.Maps_Update(username, password, Upd_Map);
            }
            catch(Exception ex)
            {
                throw ex;

            }
        }

        #endregion

        #region Alarm_Type

        Alarm_TypeSBL Alarm_TypeSBL_Obj = new Alarm_TypeSBL();
        [WebMethod]
        public bool Alarm_Type_Delete(string username, string password, int alarm_type_id)
        {
            try
            {
                return Alarm_TypeSBL_Obj.Alarm_Type_Delete(username, password, alarm_type_id);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        [WebMethod]
        public Alarm_Type Alarm_Type_Insert(string username, string password, Alarm_Type New_Alarm_Type)
        {
            try
            {
                return Alarm_TypeSBL_Obj.Alarm_Type_Insert(username, password, New_Alarm_Type);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        [WebMethod]
        public Alarm_TypeCollection Alarm_Type_Select(string username, string password, int alarm_type_id)
        {
            try
            {
                return Alarm_TypeSBL_Obj.Alarm_Type_Select(username, password, alarm_type_id);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        [WebMethod]
        public Alarm_TypeCollection Alarm_Type_Select_All(string username, string password)
        {
            try
            {
                return Alarm_TypeSBL_Obj.Alarm_Type_Select_All(username, password);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        [WebMethod]
        public bool Alarm_Type_Update(string username, string password, Alarm_Type Upd_Alarm_Type)
        {
            try
            {
                return Alarm_TypeSBL_Obj.Alarm_Type_Update(username, password, Upd_Alarm_Type);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Layers

        LayersSBL LayersSBL_Obj = new LayersSBL();

        [WebMethod]
        public bool Layers_Delete(string username, string password, int layer_id)
        {
            try
            {
                return LayersSBL_Obj.Layers_Delete(username, password, layer_id);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        [WebMethod]
        public Layers Layers_Insert(string username, string password, Layers Layer)
        {
            try
            {
                return LayersSBL_Obj.Layers_Insert(username, password, Layer);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        [WebMethod]
        public LayersCollection Layers_Select(string username, string password, int layerid)
        {
            try
            {
                LayersCollection layers = new LayersCollection();
                layers = LayersSBL_Obj.Layers_Select(username, password, layerid);
                return Load_Layer_Details(username, password, layers);
            }
            catch (Exception e)
            {
                return null;
            }
        }

        [WebMethod]
        public LayersCollection Layers_SelectByUserId(string username, string password, int userid)
        {
            try
            {
                LayersCollection layers = new LayersCollection();
                layers = LayersSBL_Obj.Layers_SelectByUserId(username, password, userid);
                return Load_Layer_Details(username, password, layers);

            }
            catch (Exception e)
            {
                return null;
            }
        }

        [WebMethod]
        public bool Layers_Update(string username, string password, Layers layer_obj)
        {
            try
            {
                return LayersSBL_Obj.Layers_Update(username, password, layer_obj);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        [WebMethod]
        public LayersCollection Load_Layer_Details(string username, string password, LayersCollection layers)
        {
            try
            {
                for (int i = 0; i < layers.Count; i++)
                {
                    layers[i].Placemarks = new PlacemarksCollection();
                    layers[i].Placemarks = Placemarks_SelectByLayerId(username, password, layers[i].Layer_id);
                }

                return layers;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion

        #region Placemarks

        PlacemarksSBL PlacemarksSBL_Obj = new PlacemarksSBL();

        [WebMethod]
        public bool Placemarks_Delete(string username, string password, int placemark_id, int layer_id)
        {
            try
            {
                return PlacemarksSBL_Obj.Placemarks_Delete(username, password, placemark_id, layer_id);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        [WebMethod]
        public Placemarks Placemarks_Insert(string username, string password, Placemarks Placemark)
        {
            try
            {
                return PlacemarksSBL_Obj.Placemarks_Insert(username, password, Placemark);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        [WebMethod]
        public bool Placemarks_Insert_Bulk(string username, string password, PlacemarksCollection Placemarks_Array)
        {
            try
            {
                return PlacemarksSBL_Obj.Placemarks_Insert_Bulk(username, password, Placemarks_Array);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        [WebMethod]
        public PlacemarksCollection Placemarks_Select(string username, string password, int placemarkid)
        {
            try
            {
                return PlacemarksSBL_Obj.Placemarks_Select(username, password, placemarkid);
            }
            catch (Exception e)
            {
                return null;
            }
        }

        [WebMethod]
        public PlacemarksCollection Placemarks_SelectByLayerId(string username, string password, int layerid)
        {
            try
            {
                return PlacemarksSBL_Obj.Placemarks_SelectByLayerId(username, password, layerid);
            }
            catch (Exception e)
            {
                return null;
            }
        }

        [WebMethod]
        public PlacemarksCollection Placemarks_SelectByUserId(string username, string password, int userid)
        {
            try
            {
                return PlacemarksSBL_Obj.Placemarks_SelectByUserId(username, password, userid);
            }
            catch (Exception e)
            {
                return null;
            }
        }

        [WebMethod]
        public bool Placemarks_Update(string username, string password, Placemarks Placemark)
        {
            try
            {
                return PlacemarksSBL_Obj.Placemarks_Update(username, password, Placemark);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        [WebMethod]
        public bool Placemarks_Update_Bulk(string username, string password, PlacemarksCollection Placemarks_Array)
        {
            try
            {
                return PlacemarksSBL_Obj.Placemarks_Update_Bulk(username, password, Placemarks_Array);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        #endregion

        #region Forward Destinations
        Forward_DestinationsSBL Forward_DestinationsSBL_Obj = new Forward_DestinationsSBL();

        [WebMethod]
        public bool Forward_Destinations_Delete(string username, string password, int destination_id)
        {
            try
            {
                return Forward_DestinationsSBL_Obj.Forward_Destinations_Delete(username, password, destination_id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [WebMethod]
        public bool Forward_Destinations_Delete_All(string username, string password)
        {
            try
            {
                return Forward_DestinationsSBL_Obj.Forward_Destinations_Delete_All(username, password);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [WebMethod]
        public bool Forward_Destinations_Update(string username, string password, Forward_Destinations Upd_Forward_Destination)
        {
            try
            {
                return Forward_DestinationsSBL_Obj.Forward_Destinations_Update(username, password, Upd_Forward_Destination);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [WebMethod]
        public Forward_Destinations Forward_Destinations_Insert(string username, string password, Forward_Destinations New_Forward_Destination)
        {
            try
            {
                return Forward_DestinationsSBL_Obj.Forward_Destinations_Insert(username, password, New_Forward_Destination);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [WebMethod]
        public Forward_DestinationsCollection Forward_Destinations_Select_All(string username, string password)
        {
            try
            {
                return Forward_DestinationsSBL_Obj.Forward_Destinations_Select_All(username, password);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [WebMethod]
        public Forward_DestinationsCollection Forward_Destinations_Select(string username, string password,int destination_id)
        {
            try
            {
                return Forward_DestinationsSBL_Obj.Forward_Destinations_Select(username, password, destination_id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [WebMethod]
        public Forward_DestinationsCollection Forward_Destinations_SelectBy_MU_ID_and_AT_ID(string username, string password, int mu_id, int at_id)
        {
            try
            {
                return Forward_DestinationsSBL_Obj.Forward_Destinations_SelectBy_MU_ID_and_AT_ID(username, password, mu_id,at_id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [WebMethod]
        public Forward_DestinationsCollection Forward_Destinations_SelectBy_BU_ID_and_AT_ID(string username, string password, int bu_id, int at_id)
        {
            try
            {
                return Forward_DestinationsSBL_Obj.Forward_Destinations_SelectBy_BU_ID_and_AT_ID(username, password, bu_id, at_id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Zones

        ZonesSBL ZonesSBL_Obj = new ZonesSBL();

        [WebMethod]
        public bool Zones_Delete(string username, string password, int Path_id)
        {
            try
            {
                return ZonesSBL_Obj.Zones_Delete(username, password, Path_id);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        [WebMethod]
        public Zones Zones_Insert(string username, string password, Zones Zone)
        {
            try
            {
                return ZonesSBL_Obj.Zones_Insert(username, password, Zone);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        [WebMethod]
        public ZonesCollection Zones_Select(string username, string password, int zoneid)
        {
            try
            {
                ZonesCollection zones = new ZonesCollection();
                zones = ZonesSBL_Obj.Zones_Select(username, password, zoneid);
                return zones;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        //
        [WebMethod]
        public ZonesCollection Zones_Select_All(string username, string password)
        {
            try
            {
                ZonesCollection zones = new ZonesCollection();
                zones = ZonesSBL_Obj.Zones_Select_All(username, password);
                return zones;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        

        [WebMethod]
        public ZonesCollection Zones_SelectByUserId(string username, string password, int userid)
        {
            try
            {
                ZonesCollection zones = new ZonesCollection();
                zones = ZonesSBL_Obj.Zones_SelectByUserId(username, password, userid);
                return zones;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        [WebMethod]
        public bool Zones_Update(string username, string password, Zones Zone)
        {
            try
            {
                return ZonesSBL_Obj.Zones_Update(username, password, Zone);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        

        #endregion

        [WebMethod]
        public DateTime Get_Server_DateTime()
        {
            try
            {
                return DateTime.Now;
            }
            catch (Exception ex)
            {
                return DateTime.Now;
            }
        }
    }

}
