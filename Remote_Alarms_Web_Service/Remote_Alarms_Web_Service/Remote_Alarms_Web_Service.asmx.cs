using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace Remote_Alarms_Web_Service
{
    /// <summary>
    /// Summary description for Remote_Alarms_Web_Service
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class Remote_Alarms_Web_Service : System.Web.Services.WebService
    {

        #region  SqlConnection
        public SqlConnection Con = new SqlConnection(ConfigurationManager.ConnectionStrings["dbConnection"].ConnectionString);
        #endregion

        #region Structs

        public struct User
        {
            private int user_id;
            private string username;
            private string password;
            private int privilege;
            private bool good;
            private Company[] companies;
            private IncomingAlarm[] incoming_Alarms;

            #region Sets/Gets
            public int User_id
            {
                get
                {
                    return user_id;
                }

                set
                {
                    user_id = value;
                }
            }

            public string Username
            {
                get
                {
                    return username;
                }

                set
                {
                    username = value;
                }
            }

            public string Password
            {
                get
                {
                    return password;
                }

                set
                {
                    password = value;
                }
            }

            public int Privilege
            {
                get
                {
                    return privilege;
                }

                set
                {
                    privilege = value;
                }
            }

            public bool Good
            {
                get
                {
                    return good;
                }

                set
                {
                    good = value;
                }
            }

            public Company[] Companies
            {
                get
                {
                    return companies;
                }

                set
                {
                    companies = value;
                }
            }

            public IncomingAlarm[] Incoming_Alarms
            {
                get
                {
                    return incoming_Alarms;
                }

                set
                {
                    incoming_Alarms = value;
                }
            }

            #endregion
        }

        public struct Company
        {
            private int iD;
            private double radioID;
            private int u_id;
            private string companyName;
            private double latitude;
            private double longitude;
            private string contactPersonName;
            private string landLinePhoneNumber;
            private string mobileNumberOne;
            private string addressLineOne;
            private string addressLineTwo;
            private string companyType;
            private int systemCheck;
            private DateTime systemCheckedDate;
            private string mobileNumberTwo;

            #region Sets/Gets
            public int ID
            {
                get
                {
                    return iD;
                }

                set
                {
                    iD = value;
                }
            }

            public double RadioID
            {
                get
                {
                    return radioID;
                }

                set
                {
                    radioID = value;
                }
            }

            public int U_id
            {
                get
                {
                    return u_id;
                }

                set
                {
                    u_id = value;
                }
            }

            public string CompanyName
            {
                get
                {
                    return companyName;
                }

                set
                {
                    companyName = value;
                }
            }

            public double Latitude
            {
                get
                {
                    return latitude;
                }

                set
                {
                    latitude = value;
                }
            }

            public double Longitude
            {
                get
                {
                    return longitude;
                }

                set
                {
                    longitude = value;
                }
            }

            public string ContactPersonName
            {
                get
                {
                    return contactPersonName;
                }

                set
                {
                    contactPersonName = value;
                }
            }

            public string LandLinePhoneNumber
            {
                get
                {
                    return landLinePhoneNumber;
                }

                set
                {
                    landLinePhoneNumber = value;
                }
            }

            public string MobileNumberOne
            {
                get
                {
                    return mobileNumberOne;
                }

                set
                {
                    mobileNumberOne = value;
                }
            }

            public string AddressLineOne
            {
                get
                {
                    return addressLineOne;
                }

                set
                {
                    addressLineOne = value;
                }
            }

            public string AddressLineTwo
            {
                get
                {
                    return addressLineTwo;
                }

                set
                {
                    addressLineTwo = value;
                }
            }

            public string CompanyType
            {
                get
                {
                    return companyType;
                }

                set
                {
                    companyType = value;
                }
            }

            public int SystemCheck
            {
                get
                {
                    return systemCheck;
                }

                set
                {
                    systemCheck = value;
                }
            }

            public DateTime SystemCheckedDate
            {
                get
                {
                    return systemCheckedDate;
                }

                set
                {
                    systemCheckedDate = value;
                }
            }
            public string MobileNumberTwo
            {
                get
                {
                    return mobileNumberTwo;
                }

                set
                {
                    mobileNumberTwo = value;
                }
            }

            #endregion
        }

        public struct IncomingAlarm
        {
            private int iD;
            private double radioID;
            private int company_ID;
            private string alarmType;
            private double latitude;
            private double longitude;
            private DateTime dateReceived;
            private int acknowledege;
            private DateTime acknowledegeDate;
            private bool visibility;

            #region Sets/Gets
            public int ID
            {
                get
                {
                    return iD;
                }

                set
                {
                    iD = value;
                }
            }

            public double RadioID
            {
                get
                {
                    return radioID;
                }

                set
                {
                    radioID = value;
                }
            }

            public int Company_ID
            {
                get
                {
                    return company_ID;
                }

                set
                {
                    company_ID = value;
                }
            }

            public string AlarmType
            {
                get
                {
                    return alarmType;
                }

                set
                {
                    alarmType = value;
                }
            }

            public double Latitude
            {
                get
                {
                    return latitude;
                }

                set
                {
                    latitude = value;
                }
            }

            public double Longitude
            {
                get
                {
                    return longitude;
                }

                set
                {
                    longitude = value;
                }
            }

            public DateTime DateReceived
            {
                get
                {
                    return dateReceived;
                }

                set
                {
                    dateReceived = value;
                }
            }

            public int Acknowledege
            {
                get
                {
                    return acknowledege;
                }

                set
                {
                    acknowledege = value;
                }
            }

            public DateTime AcknowledegeDate
            {
                get
                {
                    return acknowledegeDate;
                }

                set
                {
                    acknowledegeDate = value;
                }
            }
            public bool Visibility
            {
                get
                {
                    return visibility;
                }

                set
                {
                    visibility = value;
                }
            }
            #endregion
        }

        public struct Company_Backup
        {
            private int iD;
            private int radioID;
            private int u_id;
            private string companyName;
            private double latitude;
            private double longitude;
            private string contactPersonName;
            private string landLinePhoneNumber;
            private string mobileNumberOne;
            private string addressLineOne;
            private string addressLineTwo;
            private string companyType;
            private int systemCheck;
            private DateTime systemCheckedDate;
            private string mobileNumberTwo;

            #region Sets/Gets
            public int ID
            {
                get
                {
                    return iD;
                }

                set
                {
                    iD = value;
                }
            }

            public int RadioID
            {
                get
                {
                    return radioID;
                }

                set
                {
                    radioID = value;
                }
            }

            public int U_id
            {
                get
                {
                    return u_id;
                }

                set
                {
                    u_id = value;
                }
            }

            public string CompanyName
            {
                get
                {
                    return companyName;
                }

                set
                {
                    companyName = value;
                }
            }

            public double Latitude
            {
                get
                {
                    return latitude;
                }

                set
                {
                    latitude = value;
                }
            }

            public double Longitude
            {
                get
                {
                    return longitude;
                }

                set
                {
                    longitude = value;
                }
            }

            public string ContactPersonName
            {
                get
                {
                    return contactPersonName;
                }

                set
                {
                    contactPersonName = value;
                }
            }

            public string LandLinePhoneNumber
            {
                get
                {
                    return landLinePhoneNumber;
                }

                set
                {
                    landLinePhoneNumber = value;
                }
            }

            public string MobileNumberOne
            {
                get
                {
                    return mobileNumberOne;
                }

                set
                {
                    mobileNumberOne = value;
                }
            }

            public string AddressLineOne
            {
                get
                {
                    return addressLineOne;
                }

                set
                {
                    addressLineOne = value;
                }
            }

            public string AddressLineTwo
            {
                get
                {
                    return addressLineTwo;
                }

                set
                {
                    addressLineTwo = value;
                }
            }

            public string CompanyType
            {
                get
                {
                    return companyType;
                }

                set
                {
                    companyType = value;
                }
            }

            public int SystemCheck
            {
                get
                {
                    return systemCheck;
                }

                set
                {
                    systemCheck = value;
                }
            }

            public DateTime SystemCheckedDate
            {
                get
                {
                    return systemCheckedDate;
                }

                set
                {
                    systemCheckedDate = value;
                }
            }
            public string MobileNumberTwo
            {
                get
                {
                    return mobileNumberTwo;
                }

                set
                {
                    mobileNumberTwo = value;
                }
            }

            #endregion
        }
       
        public struct IncomingAlarm_Backup
        {
            private int iD;
            private int radioID;
            private int company_ID;
            private string alarmType;
            private double latitude;
            private double longitude;
            private DateTime dateReceived;
            private int acknowledege;
            private DateTime acknowledegeDate;

            #region Sets/Gets
            public int ID
            {
                get
                {
                    return iD;
                }

                set
                {
                    iD = value;
                }
            }

            public int RadioID
            {
                get
                {
                    return radioID;
                }

                set
                {
                    radioID = value;
                }
            }

            public int Company_ID
            {
                get
                {
                    return company_ID;
                }

                set
                {
                    company_ID = value;
                }
            }

            public string AlarmType
            {
                get
                {
                    return alarmType;
                }

                set
                {
                    alarmType = value;
                }
            }

            public double Latitude
            {
                get
                {
                    return latitude;
                }

                set
                {
                    latitude = value;
                }
            }

            public double Longitude
            {
                get
                {
                    return longitude;
                }

                set
                {
                    longitude = value;
                }
            }

            public DateTime DateReceived
            {
                get
                {
                    return dateReceived;
                }

                set
                {
                    dateReceived = value;
                }
            }

            public int Acknowledege
            {
                get
                {
                    return acknowledege;
                }

                set
                {
                    acknowledege = value;
                }
            }

            public DateTime AcknowledegeDate
            {
                get
                {
                    return acknowledegeDate;
                }

                set
                {
                    acknowledegeDate = value;
                }
            }
            #endregion
        }

        #endregion

        #region Public Web Methods

        #region  User
        [WebMethod]
        public User User_Select(string username, string password)
        {
            User User_Obj = new User();
            User_Obj.Good = false;
            try
            {
                Con.Open();
                using (SqlCommand cmd = new SqlCommand("User_Select", Con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@password", password);
                    using (IDataReader myReader = cmd.ExecuteReader())
                    {
                        while (myReader.Read())
                        {
                            User_Obj.Username = (string)myReader["Username"];
                            User_Obj.Password = (string)myReader["Password"];
                            User_Obj.Privilege = (int)myReader["Privilege"];
                            User_Obj.User_id = (int)myReader["User_id"];
                            User_Obj.Good = true;
                        }
                    }
                    Con.Close();
                }
            }
            catch (Exception ex)
            {
                //Auditing.Error(ex.Message);
            }
            finally
            {
                Con.Close();
            }
            return User_Obj;
        }

        [WebMethod]
        public bool User_Insert(User New_User)
        {
            try
            {
                Con.Open();
                using (SqlCommand cmd = new SqlCommand("User_Insert", Con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@username", New_User.Username);
                    cmd.Parameters.AddWithValue("@password", New_User.Password);
                    cmd.Parameters.AddWithValue("@privilege", New_User.Privilege);
                    cmd.Parameters.AddWithValue("@userauthentivation", New_User.Username);  //authentication
                    cmd.Parameters.AddWithValue("@passwordauthentication", New_User.Password);
                    int rowsUpdated = cmd.ExecuteNonQuery();
                    bool Add_Result;
                    if (rowsUpdated > 0)
                    {
                        Add_Result = true;
                    }
                    else
                    {
                        Add_Result = false;
                    }

                    Con.Close();
                    return Add_Result;
                }
            }
            catch (Exception ex)
            {
                //Auditing.Error(ex.Message);
                return false;

            }

        }

        [WebMethod]
        public bool User_Update(User Edited_User)
        {
            try
            {
                Con.Open();
                using (SqlCommand cmd = new SqlCommand("User_Update", Con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@userid", Edited_User.User_id);
                    cmd.Parameters.AddWithValue("@username", Edited_User.Username);
                    cmd.Parameters.AddWithValue("@password", Edited_User.Password);
                    cmd.Parameters.AddWithValue("@privilege", Edited_User.Privilege);
                    cmd.Parameters.AddWithValue("@userauthentivation", Edited_User.Username);  //authentication
                    cmd.Parameters.AddWithValue("@passwordauthentication", Edited_User.Password);
                    int rowsUpdated = cmd.ExecuteNonQuery();
                    bool Edit_Result;
                    if (rowsUpdated > 0)
                    {
                        Edit_Result = true;
                    }
                    else
                    {
                        Edit_Result = false;
                    }

                    Con.Close();
                    return Edit_Result;
                }
            }
            catch (Exception ex)
            {
                //Auditing.Error(ex.Message);
                return false;

            }
        }

        [WebMethod]
        public bool User_Delete(User Deleted_User)
        {
            try
            {
                Con.Open();
                using (SqlCommand cmd = new SqlCommand("User_Delete", Con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@userid", Deleted_User.User_id);
                    cmd.Parameters.AddWithValue("@userauthentivation", Deleted_User.Username);  //authentication
                    cmd.Parameters.AddWithValue("@passwordauthentication", Deleted_User.Password);
                    int rowsUpdated = cmd.ExecuteNonQuery();
                    bool Delete_Result;
                    if (rowsUpdated > 0)
                    {
                        Delete_Result = true;
                    }
                    else
                    {
                        Delete_Result = false;
                    }

                    Con.Close();
                    return Delete_Result;
                }
            }
            catch (Exception ex)
            {
                //Auditing.Error(ex.Message);
                return false;

            }

        }

        [WebMethod]
        public Company[] User_Load_Companies(int User_id, string Username, string Password)
        {
            Company[] Company_Array = new Company[] { };
            Company Company_Obj = new Company();
            List<Company> Company_List = new List<Company>();

            try
            {
                Con.Open();
                using (SqlCommand cmd = new SqlCommand("User_Load_Companies", Con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@userid", User_id);
                    cmd.Parameters.AddWithValue("@userauthentivation", Username);  //authentication
                    cmd.Parameters.AddWithValue("@passwordauthentication", Password);

                    using (IDataReader myReader = cmd.ExecuteReader())
                    {
                        while (myReader.Read())
                        {
                            Company_Obj.ID = (int)myReader["ID"];
                            Company_Obj.RadioID = (int)myReader["RadioID"];
                            Company_Obj.U_id = (int)myReader["U_id"];
                            Company_Obj.CompanyName = (string)myReader["CompanyName"];
                            Company_Obj.Latitude = (double)myReader["Latitude"];
                            Company_Obj.Longitude = (double)myReader["Longitude"];
                            Company_Obj.ContactPersonName = (string)myReader["ContactPersonName"];
                            if (myReader["LandLinePhoneNumber"] != DBNull.Value)
                            {
                                Company_Obj.LandLinePhoneNumber = (string)myReader["LandLinePhoneNumber"];
                            }

                            Company_Obj.MobileNumberOne = (string)myReader["MobileNumberOne"];
                            Company_Obj.MobileNumberTwo = (string)myReader["MobileNumberTwo"];
                            Company_Obj.AddressLineOne = (string)myReader["AddressLineOne"];
                            Company_Obj.AddressLineTwo = (string)myReader["AddressLineTwo"];
                            if (myReader["CompanyType"] != DBNull.Value)
                            {
                                Company_Obj.CompanyType = (string)myReader["CompanyType"];
                            }
                            if (myReader["SystemCheck"] != DBNull.Value)
                            {
                                Company_Obj.SystemCheck = (int)myReader["SystemCheck"];
                            }

                            if (myReader["SystemCheckedDate"] != DBNull.Value)
                            {
                                Company_Obj.SystemCheckedDate = (DateTime)myReader["SystemCheckedDate"];
                            }

                            Company_List.Add(Company_Obj);
                        }

                        myReader.Close();
                        Con.Close();

                        Company_Array = new Company[Company_List.Count];

                        for (int i = 0; i < Company_List.Count; i++)
                        {
                            Company_Array[i] = new Company();
                            Company_Array[i].ID = Company_List[i].ID;
                            Company_Array[i].RadioID = Company_List[i].RadioID;
                            Company_Array[i].U_id = Company_List[i].U_id;
                            Company_Array[i].CompanyName = Company_List[i].CompanyName;
                            Company_Array[i].Latitude = Company_List[i].Latitude;
                            Company_Array[i].Longitude = Company_List[i].Longitude;
                            Company_Array[i].ContactPersonName = Company_List[i].ContactPersonName;
                            Company_Array[i].LandLinePhoneNumber = Company_List[i].LandLinePhoneNumber;
                            Company_Array[i].MobileNumberOne = Company_List[i].MobileNumberOne;
                            Company_Array[i].MobileNumberTwo = Company_List[i].MobileNumberTwo;
                            Company_Array[i].AddressLineOne = Company_List[i].AddressLineOne;
                            Company_Array[i].AddressLineTwo = Company_List[i].AddressLineTwo;
                            Company_Array[i].CompanyType = Company_List[i].CompanyType;
                            Company_Array[i].SystemCheck = Company_List[i].SystemCheck;
                            Company_Array[i].SystemCheckedDate = Company_List[i].SystemCheckedDate;

                        }

                    }
                }
            }
            catch (Exception ex)
            {
                //Auditing.Error(ex.Message);
            }
            return Company_Array;
        }

        [WebMethod]
        public Company_Backup[] User_Load_CompanyBackUp(int User_id, string Username, string Password)
        {
            Company_Backup[] Company_Array = new Company_Backup[] { };
            Company_Backup Company_Obj = new Company_Backup();
            List<Company_Backup> Company_List = new List<Company_Backup>();

            try
            {
                Con.Open();
                using (SqlCommand cmd = new SqlCommand("User_Load_CompanyDetailsBackUp", Con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@userid", User_id);
                    cmd.Parameters.AddWithValue("@userauthentivation", Username);  //authentication
                    cmd.Parameters.AddWithValue("@passwordauthentication", Password);
                    using (IDataReader myReader = cmd.ExecuteReader())
                    {
                        while (myReader.Read())
                        {

                            Company_Obj.ID = (int)myReader["ID"];
                            Company_Obj.RadioID = (int)myReader["RadioID"];
                            Company_Obj.U_id = (int)myReader["U_id"];
                            Company_Obj.CompanyName = (string)myReader["CompanyName"];
                            Company_Obj.Latitude = (double)myReader["Latitude"];
                            Company_Obj.Longitude = (double)myReader["Longitude"];
                            Company_Obj.ContactPersonName = (string)myReader["ContactPersonName"];
                            if (myReader["LandLinePhoneNumber"] != DBNull.Value)
                            {
                                Company_Obj.LandLinePhoneNumber = (string)myReader["LandLinePhoneNumber"];
                            }

                            Company_Obj.MobileNumberOne = (string)myReader["MobileNumberOne"];
                            Company_Obj.AddressLineOne = (string)myReader["AddressLineOne"];
                            Company_Obj.AddressLineTwo = (string)myReader["AddressLineTwo"];
                            if (myReader["CompanyType"] != DBNull.Value)
                            {
                                Company_Obj.CompanyType = (string)myReader["CompanyType"];
                            }

                            if (myReader["SystemCheck"] != DBNull.Value)
                            {
                                Company_Obj.SystemCheck = (int)myReader["SystemCheck"];
                            }

                            if (myReader["SystemCheckedDate"] != DBNull.Value)
                            {
                                Company_Obj.SystemCheckedDate = (DateTime)myReader["SystemCheckedDate"];
                            }

                            if (myReader["MobileNumberTwo"] != DBNull.Value)
                            {
                                Company_Obj.MobileNumberTwo = (string)myReader["MobileNumberTwo"];
                            }
                            Company_List.Add(Company_Obj);

                        }


                        Company_Array = new Company_Backup[Company_List.Count];

                        for (int i = 0; i < Company_List.Count; i++)
                        {
                            Company_Array[i] = new Company_Backup();
                            Company_Array[i].ID = Company_List[i].ID;
                            Company_Array[i].RadioID = Company_List[i].RadioID;
                            Company_Array[i].U_id = Company_List[i].U_id;
                            Company_Array[i].CompanyName = Company_List[i].CompanyName;
                            Company_Array[i].Latitude = Company_List[i].Latitude;
                            Company_Array[i].Longitude = Company_List[i].Longitude;
                            Company_Array[i].ContactPersonName = Company_List[i].ContactPersonName;
                            Company_Array[i].LandLinePhoneNumber = Company_List[i].LandLinePhoneNumber;
                            Company_Array[i].MobileNumberOne = Company_List[i].MobileNumberOne;
                            Company_Array[i].MobileNumberTwo = Company_List[i].MobileNumberTwo;
                            Company_Array[i].AddressLineOne = Company_List[i].AddressLineOne;
                            Company_Array[i].AddressLineTwo = Company_List[i].AddressLineTwo;
                            Company_Array[i].CompanyType = Company_List[i].CompanyType;
                            Company_Array[i].SystemCheck = Company_List[i].SystemCheck;
                            Company_Array[i].SystemCheckedDate = Company_List[i].SystemCheckedDate;
                        }
                        myReader.Close();
                    }
                    Con.Close();
                }
            }
            catch (Exception ex)
            {
                //Auditing.Error(ex.Message);
            }
            return Company_Array;
        }

        [WebMethod]
        public IncomingAlarm[] User_Load_Incoming_Alarms(int User_id, string Username, string Password)
        {
            IncomingAlarm[] Incoming = new IncomingAlarm[] { };
            
            List<IncomingAlarm> Alarm_List = new List<IncomingAlarm>();

            try
            {
                Con.Open();
                using (SqlCommand cmd = new SqlCommand("User_Load_IncomingAlarms", Con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@userid", User_id);
                    cmd.Parameters.AddWithValue("@userauthentivation", Username);  //authentication
                    cmd.Parameters.AddWithValue("@passwordauthentication", Password);

                    using (IDataReader myReader = cmd.ExecuteReader())
                    {
                        while (myReader.Read())
                        {
                            IncomingAlarm Incoming_Obj = new IncomingAlarm();
                            Incoming_Obj.ID = (int)myReader["ID"];
                            Incoming_Obj.Company_ID = (int)myReader["Company_ID"];
                            Incoming_Obj.RadioID = (int)myReader["RadioID"];
                            Incoming_Obj.AlarmType = (string)myReader["AlarmType"];
                            Incoming_Obj.Latitude = (double)myReader["Latitude"];
                            Incoming_Obj.Longitude = (double)myReader["Longitude"];
                            Incoming_Obj.DateReceived = (DateTime)myReader["DateReceived"];
                            Incoming_Obj.Acknowledege = (int)myReader["Acknowledege"];
                            Incoming_Obj.Visibility = (bool)myReader["Visibility"];
                            if (myReader["AcknowledegeDate"] != DBNull.Value)
                            {
                                Incoming_Obj.AcknowledegeDate = (DateTime)myReader["AcknowledegeDate"];
                            }

                            Alarm_List.Add(Incoming_Obj);
                        }

                        Incoming = new IncomingAlarm[Alarm_List.Count];

                        for (int i = 0; i < Alarm_List.Count; i++)
                        {
                            Incoming[i] = new IncomingAlarm();
                            Incoming[i].ID = Alarm_List[i].ID;
                            Incoming[i].Company_ID = Alarm_List[i].Company_ID;
                            Incoming[i].RadioID = Alarm_List[i].RadioID;
                            Incoming[i].AlarmType = Alarm_List[i].AlarmType;
                            Incoming[i].Latitude = Alarm_List[i].Latitude;
                            Incoming[i].Longitude = Alarm_List[i].Longitude;
                            Incoming[i].DateReceived = Alarm_List[i].DateReceived;
                            Incoming[i].Acknowledege = Alarm_List[i].Acknowledege;
                            Incoming[i].AcknowledegeDate = Alarm_List[i].AcknowledegeDate;
                            Incoming[i].Visibility = Alarm_List[i].Visibility;
                        }

                        myReader.Close();
                    }
                    Con.Close();
                }
            }
            catch (Exception ex)
            {
                //Auditing.Error(ex.Message);
            }
            return Incoming;
        }

        [WebMethod]
        public IncomingAlarm[] User_Load_Incoming_AlarmsVisible(int User_id, string Username, string Password)
        {
            IncomingAlarm[] Incoming = new IncomingAlarm[] { };

            List<IncomingAlarm> Alarm_List = new List<IncomingAlarm>();

            try
            {
                Con.Open();
                using (SqlCommand cmd = new SqlCommand("User_Load_IncomingAlarmsVisible", Con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@userid", User_id);
                    cmd.Parameters.AddWithValue("@userauthentivation", Username);  //authentication
                    cmd.Parameters.AddWithValue("@passwordauthentication", Password);

                    using (IDataReader myReader = cmd.ExecuteReader())
                    {
                        while (myReader.Read())
                        {
                            IncomingAlarm Incoming_Obj = new IncomingAlarm();
                            Incoming_Obj.ID = (int)myReader["ID"];
                            Incoming_Obj.Company_ID = (int)myReader["Company_ID"];
                            Incoming_Obj.RadioID = (int)myReader["RadioID"];
                            Incoming_Obj.AlarmType = (string)myReader["AlarmType"];
                            Incoming_Obj.Latitude = (double)myReader["Latitude"];
                            Incoming_Obj.Longitude = (double)myReader["Longitude"];
                            Incoming_Obj.DateReceived = (DateTime)myReader["DateReceived"];
                            Incoming_Obj.Acknowledege = (int)myReader["Acknowledege"];
                            Incoming_Obj.Visibility = (bool)myReader["Visibility"];
                            if (myReader["AcknowledegeDate"] != DBNull.Value)
                            {
                                Incoming_Obj.AcknowledegeDate = (DateTime)myReader["AcknowledegeDate"];
                            }

                            Alarm_List.Add(Incoming_Obj);
                        }

                        Incoming = new IncomingAlarm[Alarm_List.Count];

                        for (int i = 0; i < Alarm_List.Count; i++)
                        {
                            Incoming[i] = new IncomingAlarm();
                            Incoming[i].ID = Alarm_List[i].ID;
                            Incoming[i].Company_ID = Alarm_List[i].Company_ID;
                            Incoming[i].RadioID = Alarm_List[i].RadioID;
                            Incoming[i].AlarmType = Alarm_List[i].AlarmType;
                            Incoming[i].Latitude = Alarm_List[i].Latitude;
                            Incoming[i].Longitude = Alarm_List[i].Longitude;
                            Incoming[i].DateReceived = Alarm_List[i].DateReceived;
                            Incoming[i].Acknowledege = Alarm_List[i].Acknowledege;
                            Incoming[i].AcknowledegeDate = Alarm_List[i].AcknowledegeDate;
                            Incoming[i].Visibility = Alarm_List[i].Visibility;
                        }

                        myReader.Close();
                    }
                    Con.Close();
                }
            }
            catch (Exception ex)
            {
                //Auditing.Error(ex.Message);
            }
            return Incoming;
        }

        [WebMethod]
        public IncomingAlarm_Backup[] User_Load_Incoming_Alarms_BackUP(int User_id, string Username, string Password)
        {
            IncomingAlarm_Backup[] IncomingBackUP = new IncomingAlarm_Backup[] { };
            IncomingAlarm_Backup Incoming_BaackUP_Obj = new IncomingAlarm_Backup();
            List<IncomingAlarm_Backup> Alarm_List = new List<IncomingAlarm_Backup>();

            try
            {
                Con.Open();
                using (SqlCommand cmd = new SqlCommand("User_Load_IncomingAlarmsBackUp", Con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@userid", User_id);
                    cmd.Parameters.AddWithValue("@userauthentivation", Username);  //authentication
                    cmd.Parameters.AddWithValue("@passwordauthentication", Password);

                    using (IDataReader myReader = cmd.ExecuteReader())
                    {
                        while (myReader.Read())
                        {
                            Incoming_BaackUP_Obj.ID = (int)myReader["ID"];
                            Incoming_BaackUP_Obj.Company_ID = (int)myReader["CompanyDetailsBackUP_ID"];
                            Incoming_BaackUP_Obj.RadioID = (int)myReader["RadioID"];
                            Incoming_BaackUP_Obj.AlarmType = (string)myReader["AlarmType"];
                            Incoming_BaackUP_Obj.Latitude = (double)myReader["Latitude"];
                            Incoming_BaackUP_Obj.Longitude = (double)myReader["Longitude"];
                            Incoming_BaackUP_Obj.DateReceived = (DateTime)myReader["DateReceived"];
                            Incoming_BaackUP_Obj.Acknowledege = (int)myReader["Acknowledege"];
                            if (myReader["AcknowledegeDate"] != DBNull.Value)
                            {
                                Incoming_BaackUP_Obj.AcknowledegeDate = (DateTime)myReader["AcknowledegeDate"];
                            }
                            Alarm_List.Add(Incoming_BaackUP_Obj);
                        }

                        IncomingBackUP = new IncomingAlarm_Backup[Alarm_List.Count];

                        for (int i = 0; i < Alarm_List.Count; i++)
                        {
                            IncomingBackUP[i] = new IncomingAlarm_Backup();
                            IncomingBackUP[i].ID = Alarm_List[i].ID;
                            IncomingBackUP[i].Company_ID = Alarm_List[i].Company_ID;
                            IncomingBackUP[i].RadioID = Alarm_List[i].RadioID;
                            IncomingBackUP[i].AlarmType = Alarm_List[i].AlarmType;
                            IncomingBackUP[i].Latitude = Alarm_List[i].Latitude;
                            IncomingBackUP[i].Longitude = Alarm_List[i].Longitude;
                            IncomingBackUP[i].DateReceived = Alarm_List[i].DateReceived;
                            IncomingBackUP[i].Acknowledege = Alarm_List[i].Acknowledege;
                            IncomingBackUP[i].AcknowledegeDate = Alarm_List[i].AcknowledegeDate;
                        }
                        myReader.Close();
                    }
                    Con.Close();
                }
            }

            catch (Exception ex)
            {
                //Auditing.Error(ex.Message);
            }
            return IncomingBackUP;
        }

        #endregion

        #region Company

        [WebMethod]
        public Company Company_Select(int User_id, string Username, string Password, int Radio_ID)
        {
            Company Company_Obj = new Company();
            try
            {
                Con.Open();
                using (SqlCommand cmd = new SqlCommand("CompanyDetails_Select", Con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Radio_id", Radio_ID);
                    cmd.Parameters.AddWithValue("@userid", User_id);
                    cmd.Parameters.AddWithValue("@userauthentivation", Username);  //authentication
                    cmd.Parameters.AddWithValue("@passwordauthentication", Password);
                    using (IDataReader myReader = cmd.ExecuteReader())
                    {
                        while (myReader.Read())
                        {
                            Company_Obj.ID = (int)myReader["ID"];
                            Company_Obj.RadioID = (int)myReader["RadioID"];
                            Company_Obj.U_id = (int)myReader["U_id"];
                            Company_Obj.CompanyName = (string)myReader["CompanyName"];
                            Company_Obj.Latitude = (double)myReader["Latitude"];
                            Company_Obj.Longitude = (double)myReader["Longitude"];
                            Company_Obj.ContactPersonName = (string)myReader["ContactPersonName"];
                            Company_Obj.LandLinePhoneNumber = (string)myReader["LandLinePhoneNumber"];
                            Company_Obj.MobileNumberOne = (string)myReader["MobileNumberOne"];
                            Company_Obj.AddressLineOne = (string)myReader["AddressLineOne"];
                            Company_Obj.AddressLineTwo = (string)myReader["AddressLineTwo"];
                            Company_Obj.CompanyType = (string)myReader["CompanyType"];
                            Company_Obj.SystemCheck = (int)myReader["SystemCheck"];
                            Company_Obj.SystemCheckedDate = (DateTime)myReader["SystemCheckedDate"];
                            Company_Obj.MobileNumberTwo = (string)myReader["MobileNumberTwo"];
                        }
                    }
                    Con.Close();
                }
            }
            catch (Exception ex)
            {
                //Auditing.Error(ex.Message);
            }
            return Company_Obj;
        }

        [WebMethod]
        public bool Company_Insert(int User_id, string Username, string Password, Company New_Company)
        {
            try
            {
                Con.Open();
                using (SqlCommand cmd = new SqlCommand("Company_Insert", Con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@RadioID", New_Company.RadioID);
                    cmd.Parameters.AddWithValue("@U_id", User_id);
                    cmd.Parameters.AddWithValue("@CompanyName", New_Company.CompanyName);
                    cmd.Parameters.AddWithValue("@Latitude", New_Company.Latitude);
                    cmd.Parameters.AddWithValue("@Longitude", New_Company.Longitude);
                    cmd.Parameters.AddWithValue("@ContactPersonName", New_Company.ContactPersonName);
                    cmd.Parameters.AddWithValue("@LandLinePhoneNumber", New_Company.LandLinePhoneNumber);
                    cmd.Parameters.AddWithValue("@MobileNumberOne", New_Company.MobileNumberOne);
                    cmd.Parameters.AddWithValue("@AddressLineOne", New_Company.AddressLineOne);
                    cmd.Parameters.AddWithValue("@AddressLineTwo", "");
                    cmd.Parameters.AddWithValue("@CompanyType", New_Company.CompanyType);
                    cmd.Parameters.AddWithValue("@SystemCheck", New_Company.SystemCheck);
                    cmd.Parameters.AddWithValue("@SystemCheckedDate", New_Company.SystemCheckedDate);
                    cmd.Parameters.AddWithValue("@userauthentivation", Username);  //authentication
                    cmd.Parameters.AddWithValue("@passwordauthentication", Password);
                    cmd.Parameters.AddWithValue("@MobileNumberTwo", New_Company.MobileNumberTwo);
                    int rowsUpdated = cmd.ExecuteNonQuery();
                    bool Add_Result;
                    if (rowsUpdated > 0)
                    {
                        Add_Result = true;
                    }
                    else
                    {
                        Add_Result = false;
                    }

                    Con.Close();
                    return Add_Result;
                }
            }
            catch (Exception ex)
            {
                //Auditing.Error(ex.Message);
                return false;
            }

        }

        [WebMethod]
        public bool Company_Update(int User_id, string Username, string Password, Company Edited_Company)
        {
            try
            {
                Con.Open();
                using (SqlCommand cmd = new SqlCommand("Company_Update", Con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ID", Edited_Company.ID);
                    cmd.Parameters.AddWithValue("@RadioID", Edited_Company.RadioID);
                    cmd.Parameters.AddWithValue("@userid", User_id);
                    cmd.Parameters.AddWithValue("@U_id", Edited_Company.U_id);
                    cmd.Parameters.AddWithValue("@CompanyName", Edited_Company.CompanyName);
                    cmd.Parameters.AddWithValue("@Latitude", Edited_Company.Latitude);
                    cmd.Parameters.AddWithValue("@Longitude", Edited_Company.Longitude);
                    cmd.Parameters.AddWithValue("@ContactPersonName", Edited_Company.ContactPersonName);
                    cmd.Parameters.AddWithValue("@LandLinePhoneNumber", Edited_Company.LandLinePhoneNumber);
                    cmd.Parameters.AddWithValue("@MobileNumberOne", Edited_Company.MobileNumberOne);
                    cmd.Parameters.AddWithValue("@AddressLineOne", Edited_Company.AddressLineOne);
                    cmd.Parameters.AddWithValue("@AddressLineTwo", "");
                    cmd.Parameters.AddWithValue("@CompanyType", Edited_Company.CompanyType);
                    cmd.Parameters.AddWithValue("@SystemCheck", Edited_Company.SystemCheck);
                    cmd.Parameters.AddWithValue("@SystemCheckedDate", Edited_Company.SystemCheckedDate);
                    cmd.Parameters.AddWithValue("@userauthentivation", Username);  //authentication
                    cmd.Parameters.AddWithValue("@passwordauthentication", Password);
                    cmd.Parameters.AddWithValue("@MobileNumberTwo", Edited_Company.MobileNumberTwo);
                    int rowsUpdated = cmd.ExecuteNonQuery();
                    bool Edit_Result;
                    if (rowsUpdated > 0)
                    {
                        Edit_Result = true;
                    }
                    else
                    {
                        Edit_Result = false;
                    }

                    Con.Close();
                    return Edit_Result;
                }
            }
            catch (Exception ex)
            {
                //Auditing.Error(ex.Message);
                return false;

            }
        }

        [WebMethod]
        public bool Company_Status_Update(string Username, string Password,string OnlineAlarmUnits, string OfflineAlarmUnits , DateTime Check_DateTime)
        {
            try
            {
                Con.Open();
                using (SqlCommand cmd = new SqlCommand("Company_Status_Update", Con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@userauthentivation", Username);  
                    cmd.Parameters.AddWithValue("@passwordauthentication", Password);
                    cmd.Parameters.AddWithValue("@Online_RadioIDs", OnlineAlarmUnits);
                    cmd.Parameters.AddWithValue("@Offline_RadioIDs", OfflineAlarmUnits);
                    cmd.Parameters.AddWithValue("@SystemCheckedDate", Check_DateTime);

                    int rowsUpdated = cmd.ExecuteNonQuery();
                    bool Edit_Result;
                    if (rowsUpdated > 0)
                    {
                        Edit_Result = true;
                    }
                    else
                    {
                        Edit_Result = false;
                    }

                    Con.Close();
                    return Edit_Result;
                }
            }
            catch (Exception ex)
            {
                //Auditing.Error(ex.Message);
                return false;

            }
        }


        [WebMethod]
        public bool Company_Delete(int User_id, string Username, string Password, int Company_Id)
        {

            try
            {
                Con.Open();
                using (SqlCommand cmd = new SqlCommand("Company_Delete", Con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ID", Company_Id);
                    cmd.Parameters.AddWithValue("@userid", User_id);
                    cmd.Parameters.AddWithValue("@userauthentivation", Username);  //authentication
                    cmd.Parameters.AddWithValue("@passwordauthentication", Password);
                    int rowsUpdated = cmd.ExecuteNonQuery();
                    bool Delete_Result;
                    if (rowsUpdated > 0)
                    {
                        Delete_Result = true;
                    }
                    else
                    {
                        Delete_Result = false;
                    }

                    Con.Close();
                    return Delete_Result;
                }
            }
            catch (Exception ex)
            {
                //Auditing.Error(ex.Message);
                return false;

            }

        }

        [WebMethod]
        public IncomingAlarm[] Company_Alarms_Select(int User_id, string Username, string Password, int Radio_Number)
        {
            IncomingAlarm[] IncomingAlarm_Array = new IncomingAlarm[] { };
            IncomingAlarm Incoming_Alarm_Obj = new IncomingAlarm();
            List<IncomingAlarm> IncomingAlarm_List = new List<IncomingAlarm>();
            try
            {

                Con.Open();
                using (SqlCommand cmd = new SqlCommand("IncomingAlarms_Select", Con))
                {

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@RadioID", Radio_Number);
                    cmd.Parameters.AddWithValue("@userid", User_id);
                    cmd.Parameters.AddWithValue("@userauthentivation", Username);  //authentication
                    cmd.Parameters.AddWithValue("@passwordauthentication", Password);
                    using (IDataReader myReader = cmd.ExecuteReader())
                    {
                        while (myReader.Read())
                        {
                            Incoming_Alarm_Obj = new IncomingAlarm();
                            Incoming_Alarm_Obj.ID = (int)myReader["ID"];
                            Incoming_Alarm_Obj.Company_ID = (int)myReader["CompanyDetails_ID"];
                            Incoming_Alarm_Obj.RadioID = (int)myReader["RadioID"];
                            Incoming_Alarm_Obj.AlarmType = (string)myReader["AlarmType"];
                            Incoming_Alarm_Obj.Latitude = (double)myReader["Latitude"];
                            Incoming_Alarm_Obj.Longitude = (double)myReader["Longitude"];
                            Incoming_Alarm_Obj.DateReceived = (DateTime)myReader["DateReceived"];
                            Incoming_Alarm_Obj.Acknowledege = (int)myReader["Acknowledege"];
                            Incoming_Alarm_Obj.AcknowledegeDate = (DateTime)myReader["AcknowledegeDate"];
                            Incoming_Alarm_Obj.Visibility = (bool)myReader["Visibility"];

                            IncomingAlarm_List.Add(Incoming_Alarm_Obj);
                        }
                        myReader.Close();
                    }

                    Con.Close();

                    IncomingAlarm_Array = new IncomingAlarm[IncomingAlarm_List.Count];

                    for (int i = 0; i < IncomingAlarm_List.Count; i++)
                    {
                        IncomingAlarm_Array[i] = new IncomingAlarm();
                        IncomingAlarm_Array[i].ID = IncomingAlarm_List[i].ID;
                        IncomingAlarm_Array[i].Company_ID = IncomingAlarm_List[i].Company_ID;
                        IncomingAlarm_Array[i].RadioID = IncomingAlarm_List[i].RadioID;
                        IncomingAlarm_Array[i].AlarmType = IncomingAlarm_List[i].AlarmType;
                        IncomingAlarm_Array[i].Latitude = IncomingAlarm_List[i].Latitude;
                        IncomingAlarm_Array[i].Longitude = IncomingAlarm_List[i].Longitude;
                        IncomingAlarm_Array[i].DateReceived = IncomingAlarm_List[i].DateReceived;
                        IncomingAlarm_Array[i].Acknowledege = IncomingAlarm_List[i].Acknowledege;
                        IncomingAlarm_Array[i].AcknowledegeDate = IncomingAlarm_List[i].AcknowledegeDate;
                        IncomingAlarm_Array[i].Visibility = IncomingAlarm_List[i].Visibility;
                    }
                    return IncomingAlarm_Array;
                }
            }
            catch (Exception ex)
            {
                //Auditing.Error(ex.Message);
            }
            return IncomingAlarm_Array;
        }

        #endregion

        #region Incoming Alarm

       

        [WebMethod]
        public bool Incoming_Alarms_Insert(string Username, string Password, IncomingAlarm New_Incoming_Alarm)
        {
            try
            {
                Con.Open();
                using (SqlCommand cmd = new SqlCommand("IncomingAlarms_Insert", Con))
                {

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@RadioID", New_Incoming_Alarm.RadioID);
                    cmd.Parameters.AddWithValue("@Company_ID", New_Incoming_Alarm.Company_ID);
                    cmd.Parameters.AddWithValue("@AlarmType", New_Incoming_Alarm.AlarmType);
                    cmd.Parameters.AddWithValue("@Latitude", New_Incoming_Alarm.Latitude);
                    cmd.Parameters.AddWithValue("@Longitude", New_Incoming_Alarm.Longitude);
                    cmd.Parameters.AddWithValue("@DateReceived", New_Incoming_Alarm.DateReceived);
                    cmd.Parameters.AddWithValue("@Acknowledege", New_Incoming_Alarm.Acknowledege);
                    cmd.Parameters.AddWithValue("@Visibility", New_Incoming_Alarm.Visibility);

                    if (New_Incoming_Alarm.AcknowledegeDate.Year == 0001)
                    {
                        cmd.Parameters.AddWithValue("@AcknowledegeDate", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@AcknowledegeDate", New_Incoming_Alarm.AcknowledegeDate);
                    }
                    
                    cmd.Parameters.AddWithValue("@userauthentivation", Username);  //authentication
                    cmd.Parameters.AddWithValue("@passwordauthentication", Password);
                    int rowsUpdated = cmd.ExecuteNonQuery();
                    bool Add_Result;
                    if (rowsUpdated > 0)
                    {
                        Add_Result = true;
                    }
                    else
                    {
                        Add_Result = false;
                    }

                    Con.Close();
                    return Add_Result;
                }
            }
            catch (Exception ex)
            {
                //Auditing.Error(ex.Message);
                return false;
            }

        }

        [WebMethod]
        public bool Incoming_Alarms_Update(string Username, string Password, IncomingAlarm Edited_Incoming_Alarm)
        {
            try
            {
                Con.Open();
                using (SqlCommand cmd = new SqlCommand("IncomingAlarms_Update", Con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ID", Edited_Incoming_Alarm.ID);
                    cmd.Parameters.AddWithValue("@RadioID", Edited_Incoming_Alarm.RadioID);
                    cmd.Parameters.AddWithValue("@Company_ID", Edited_Incoming_Alarm.Company_ID);
                    cmd.Parameters.AddWithValue("@AlarmType", Edited_Incoming_Alarm.AlarmType);
                    cmd.Parameters.AddWithValue("@Latitude", Edited_Incoming_Alarm.Latitude);
                    cmd.Parameters.AddWithValue("@Longitude", Edited_Incoming_Alarm.Longitude);
                    cmd.Parameters.AddWithValue("@DateReceived", Edited_Incoming_Alarm.DateReceived);
                    cmd.Parameters.AddWithValue("@Acknowledege", Edited_Incoming_Alarm.Acknowledege);
                    cmd.Parameters.AddWithValue("@Visibility", Edited_Incoming_Alarm.Visibility);
                    if (Edited_Incoming_Alarm.AcknowledegeDate.Year == 0001)
                    {
                        cmd.Parameters.AddWithValue("@AcknowledegeDate", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@AcknowledegeDate", Edited_Incoming_Alarm.AcknowledegeDate);
                    }
                    cmd.Parameters.AddWithValue("@userauthentivation", Username);  //authentication
                    cmd.Parameters.AddWithValue("@passwordauthentication", Password);
                    int rowsUpdated = cmd.ExecuteNonQuery();
                    bool Edit_Result;
                    if (rowsUpdated > 0)
                    {
                        Edit_Result = true;
                    }
                    else
                    {
                        Edit_Result = false;
                    }

                    Con.Close();
                    return Edit_Result;
                }
            }
            catch (Exception ex)
            {
                //Auditing.Error(ex.Message);
                return false;

            }
        }


        [WebMethod]
        public bool Incoming_Alarms_Delete(int User_id, string Username, string Password, int Alarm_Id)
        {

            try
            {
                Con.Open();
                using (SqlCommand cmd = new SqlCommand("IncomingAlarms_Delete", Con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ID", Alarm_Id);
                    cmd.Parameters.AddWithValue("@userid", User_id);
                    cmd.Parameters.AddWithValue("@userauthentivation", Username);  //authentication
                    cmd.Parameters.AddWithValue("@passwordauthentication", Password);
                    int rowsUpdated = cmd.ExecuteNonQuery();

                    Con.Close();
                    return true;
                }
            }
            catch (Exception ex)
            {
                //Auditing.Error(ex.Message);
                return false;
            }

        }
        [WebMethod]
        public bool IncomingAlarms_ChangeVisibility(int User_id, string Username, string Password)
        {
            try
            {
                Con.Open();
                using (SqlCommand cmd = new SqlCommand("IncomingAlarms_ChangeVisibility", Con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@userid", User_id);
                    cmd.Parameters.AddWithValue("@userauthentivation", Username);  //authentication
                    cmd.Parameters.AddWithValue("@passwordauthentication", Password);

                    int rowsUpdated = cmd.ExecuteNonQuery();

                    Con.Close();
                    return true;
                }
            }
            catch (Exception ex)
            {
                //Auditing.Error(ex.Message);
                return false;
            }
        }

        [WebMethod]
        public bool IncomingAlarms_ChangeInVisibility(int User_id, string Username, string Password, DateTime From_DateTime, DateTime To_DateTime)
        {
            try
            {
                Con.Open();
                using (SqlCommand cmd = new SqlCommand("IncomingAlarms_ChangeInVisibility", Con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@userid", User_id);
                    cmd.Parameters.AddWithValue("@userauthentivation", Username);  //authentication
                    cmd.Parameters.AddWithValue("@passwordauthentication", Password);
                    cmd.Parameters.AddWithValue("@From_DateTime", From_DateTime);
                    cmd.Parameters.AddWithValue("@To_DateTime", To_DateTime);

                    int rowsUpdated = cmd.ExecuteNonQuery();

                    Con.Close();
                    return true;
                }
            }
            catch (Exception ex)
            {
                //Auditing.Error(ex.Message);
                return false;
            }
        }
        [WebMethod]
        public bool Incoming_Alarms_DeleteAll(int User_id, string Username, string Password)
        {
            try
            {
                Con.Open();
                using (SqlCommand cmd = new SqlCommand("IncomingAlarms_DeleteAll", Con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@userid", User_id);
                    cmd.Parameters.AddWithValue("@userauthentivation", Username);  //authentication
                    cmd.Parameters.AddWithValue("@passwordauthentication", Password);

                    int rowsUpdated = cmd.ExecuteNonQuery();

                    Con.Close();
                    return true;
                }
            }
            catch (Exception ex)
            {
                //Auditing.Error(ex.Message);
                return false;
            }
        }

        #endregion

        [WebMethod]
        public DateTime Get_Server_Datetime()
        {
            try
            {
                return DateTime.Now;
            }
            catch(Exception ex)
            {
                return DateTime.Now;
            }
        }
        #endregion
    }
}
