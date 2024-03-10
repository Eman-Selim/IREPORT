using Incident_Reporting_App_Server.Code;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Incident_Reporting_App_Server.IncidentReporting;
using Incident_Reporting_App_Server.RemoteAlarm;
using SDS_Remote_Control_Application_Server.Code;
using System.Threading;
using System.IO;

namespace Incident_Reporting_App_Server
{
    public partial class Main : Form
    {
        #region Vars
        private bool form_status;
        int menu_Selected_Index = 0;
        ServerClass server_Class_Obj = new ServerClass();
        Image imagenu = Image.FromFile("Capture.PNG");
        IRUser LoginAccount;
        Buildings[] buildings;
        List<Buildings> Newbuildings = new List<Buildings>();
        List<KeyValuePair<int, Floors>> NewFloors = new List<KeyValuePair<int, Floors>>();
        Managers[] managers;
        DangerousPlaces[] places;
        FFstations[] points;
        FFstations station = new FFstations();
        ICompany selectedCompany;
        FF_pumps pump;
        int buildingCount = 0;
        int Selected_User_ID;
        int Selected_Company_ID;
        int selectedStationIndex;
        int selectedBuildingIndex;
        int selectedManagerIndex;
        int selectedDangerousIndex;
        int PumpID;
        TreeNode companyNode;
        TreeNode UserNode;
        private bool First_Time_Loading_User_Data_Flag = true;
        bool AlarmCheck = true;
        Thread AlarmCheck_Thread;
        #endregion

        public Main()
        {
            InitializeComponent();
            pictureBox5.MouseWheel += PictureBox5_MouseWheel;
            Thread Main_Thread = new Thread(load_all_treeviews_cycle);
            Main_Thread.Start();
            LoginAccount = server_Class_Obj.Select_Account();
            AlarmCheck_Thread = new Thread(CheckAlarm_Thread);
            AlarmCheck_Thread.Start();
            AlarmCheck_Thread.Priority = ThreadPriority.Highest;
        }

        public byte[] ImageToByteArray(System.Drawing.Image imageIn)
        {
            using (var ms = new MemoryStream())
            {
                imageIn.Save(ms, imageIn.RawFormat);
                return ms.ToArray();
            }
        }

        public Image byteArrayToImage(byte[] bytesArr)
        {
            using (MemoryStream memstr = new MemoryStream(bytesArr))
            {
                Image img = Image.FromStream(memstr);
                return img;
            }
        }

        internal class ComboboxItem
        {
            public string Text { get; set; }
            public object Value { get; set; }
        }

        #region Scroll

        private void PictureBox5_MouseWheel(object sender, MouseEventArgs e)
        {
            //throw new NotImplementedException();
            if (e.Delta == 120)
            {
                menu_Selected_Index++;
                if (menu_Selected_Index >= 4)
                {
                    menu_Selected_Index = 0;
                }
            }
            else
            {
                menu_Selected_Index--;
                if (menu_Selected_Index <= -1)
                {
                    menu_Selected_Index = 3;
                }
            }


            switch (menu_Selected_Index)
            {
                case 0:
                    panel3.BackgroundImage = Properties.Resources.menu_item_5;
                    pictureBox5.BackgroundImage = Properties.Resources.BuildingSH1_MainForm;
                    c1DockingTab1.SelectedTab = c1DockingTabPage1;
                    break;

                case 1:
                    panel3.BackgroundImage = Properties.Resources.menu_item_4;
                    pictureBox5.BackgroundImage = Properties.Resources.Fire_FighterSH1_MainForm2;
                    c1DockingTab1.SelectedTab = c1DockingTabPage9;
                    break;

                case 3:
                    panel3.BackgroundImage = Properties.Resources.menu_item_4;
                    pictureBox5.BackgroundImage = Properties.Resources.Phone_BookSH1_MainForm;
                    c1DockingTab1.SelectedTab = c1DockingTabPage10;
                    break;
            }
        }

        #endregion

        #region load_Data
        private void Load_Data(ICompany selectedCompany)
        {
            //load selected company Data
            TB_companyName_DT.Text = selectedCompany.Name == null ? "" : selectedCompany.Name;
            govern.Text = selectedCompany.Address == null ? "" : selectedCompany.Address;
            TB_Address_DT.Text = selectedCompany.Address == null ? "" : selectedCompany.Address;
            district.Text = selectedCompany.Address == null ? "" : selectedCompany.Address;
            TB_LandlinePhone_DT.Text = selectedCompany.LandlinePhoneNumber == null ? "" : selectedCompany.LandlinePhoneNumber;
            TB_BuildingsNumber_DT.Text = Convert.ToString(selectedCompany.BuildingsNumber) == null ? "" : Convert.ToString(selectedCompany.BuildingsNumber);
            TB_ElectricalPanelLocation_DT.Text = selectedCompany.ElectricalPanelLocation == null ? "" : selectedCompany.ElectricalPanelLocation;
            TB_GasTrapLocation_DT.Text = selectedCompany.GasTrapLocation == null ? "" : selectedCompany.GasTrapLocation;
            TB_OxygenTrapLocation_DT.Text = selectedCompany.OxygenTrapLocation == null ? "" : selectedCompany.OxygenTrapLocation;
            ISSI.Text = selectedCompany.ISSI == null ? "" : selectedCompany.ISSI;
            TB_Stock_DT.Text = selectedCompany.StockVolume.ToString();
            TB_StockType_DT.Text = selectedCompany.StockType;
            TB_CompanyBuisiness_DT.Text = selectedCompany.CompanyBuisiness;
            CB_Sector_DT.Text = selectedCompany.sector == null? "" : selectedCompany.sector.ToString();
            TB_CompanyImage_DT.Image = selectedCompany.CompanyImage == null ? System.Drawing.Image.FromStream(new System.IO.MemoryStream(ImageToByteArray(imagenu))) : System.Drawing.Image.FromStream(new System.IO.MemoryStream(selectedCompany.CompanyImage));

            PB_ExitPathWayImage_DT.Image = System.Drawing.Image.FromStream(new System.IO.MemoryStream(ImageToByteArray(imagenu)));

            TB_CompanyGeometeryImage_DT.Image = selectedCompany.CompanyGeometeryImage == null ? System.Drawing.Image.FromStream(new System.IO.MemoryStream(ImageToByteArray(imagenu))) : System.Drawing.Image.FromStream(new System.IO.MemoryStream(selectedCompany.CompanyGeometeryImage));
            ISSI.Text = selectedCompany.ISSI;

            //Loading the neighboring companies

            PictureBox P1 = new PictureBox();
            P1.Image = System.Drawing.Image.FromStream(new System.IO.MemoryStream(selectedCompany.BackCompanyImage));

            FrontCompany_UC.TB_DCompanyBuisness_UC_ELe.Text = selectedCompany.FrontCompanyBusiness;
            FrontCompany_UC.TB_DComapnyName_UC_ELe.Text = selectedCompany.FrontCompanyName;
            FrontCompany_UC.TB_DCompanyMediator_UC_ELe.Text = selectedCompany.FrontFireMediator;
            FrontCompany_UC.TB_DCompanyImageURL_UC_ELe.Text = selectedCompany.FrontCompanyImageURL;
            FrontCompany_UC.TB_DCompanyImage_UC_ELe.Image = selectedCompany.FrontCompanyImage == null ? System.Drawing.Image.FromStream(new System.IO.MemoryStream(ImageToByteArray(imagenu))) : System.Drawing.Image.FromStream(new System.IO.MemoryStream(selectedCompany.FrontCompanyImage));

            BackCompany_UC.TB_DCompanyBuisness_UC_ELe.Text = selectedCompany.BackCompanyBusiness;
            BackCompany_UC.TB_DComapnyName_UC_ELe.Text = selectedCompany.BackCompanyName;
            BackCompany_UC.TB_DCompanyMediator_UC_ELe.Text = selectedCompany.BackFireMediator;
            BackCompany_UC.TB_DCompanyImageURL_UC_ELe.Text = selectedCompany.BackCompanyImageURL;
            BackCompany_UC.TB_DCompanyImage_UC_ELe.Image = selectedCompany.BackCompanyImage == null ? System.Drawing.Image.FromStream(new System.IO.MemoryStream(ImageToByteArray(imagenu))) : System.Drawing.Image.FromStream(new System.IO.MemoryStream(selectedCompany.BackCompanyImage));

            RightCompany_UC.TB_DCompanyBuisness_UC_ELe.Text = selectedCompany.RightCompanyBusiness;
            RightCompany_UC.TB_DComapnyName_UC_ELe.Text = selectedCompany.RightCompanyName;
            RightCompany_UC.TB_DCompanyMediator_UC_ELe.Text = selectedCompany.RightFireMediator;
            RightCompany_UC.TB_DCompanyImageURL_UC_ELe.Text = selectedCompany.RightCompanyImageURL;
            RightCompany_UC.TB_DCompanyImage_UC_ELe.Image = selectedCompany.RightCompanyImage == null ? System.Drawing.Image.FromStream(new System.IO.MemoryStream(ImageToByteArray(imagenu))) : System.Drawing.Image.FromStream(new System.IO.MemoryStream(selectedCompany.RightCompanyImage));

            LeftCompany_UC.TB_DCompanyBuisness_UC_ELe.Text = selectedCompany.LeftCompanyBusiness;
            LeftCompany_UC.TB_DComapnyName_UC_ELe.Text = selectedCompany.LeftCompanyName;
            LeftCompany_UC.TB_DCompanyMediator_UC_ELe.Text = selectedCompany.LeftFireMediator;
            LeftCompany_UC.TB_DCompanyImageURL_UC_ELe.Text = selectedCompany.LeftCompanyImageURL;
            LeftCompany_UC.TB_DCompanyImage_UC_ELe.Image = selectedCompany.LeftCompanyImage == null ? System.Drawing.Image.FromStream(new System.IO.MemoryStream(ImageToByteArray(imagenu))) : System.Drawing.Image.FromStream(new System.IO.MemoryStream(selectedCompany.LeftCompanyImage));


            //load buildings of selected company


            buildings = selectedCompany.companyBuildings;
            int buildings_length = buildings != null ? buildings.Length : 0;

            buildingCB.Items.Clear();
            for (int i = 0; i < buildings_length; i++)
            {
                buildingCB.Items.Add(buildings[i].BuildingNumber);
            }

            //load admins of the selected company
            managers = selectedCompany.companyManagers;
            int managers_length = managers != null ? managers.Length : 0;
            comboBox1.Items.Clear();
            for (int i = 0; i < managers_length; i++)
            {
                comboBox1.Items.Add(managers[i].Name);
            }

            //load Dangerous places of the selected company

            places = selectedCompany.CompanyDangerousPlaces;
            int places_length = places != null ? places.Length : 0;
            Dangerous.Items.Clear();
            for (int i = 0; i < places_length; i++)
            {
                Dangerous.Items.Add(places[i].HazardousSubstance);
            }


        }
        private void Load_User_Data(IRUser SelectedUser)
        {

            //load account info
            accountName.Text = SelectedUser.Username == null ? "" : SelectedUser.Username;
            AccountInfo.Text = SelectedUser.Info == null ? "" : SelectedUser.Info;
            accountPassword.Clear();
            ReAccountPassword.Clear();
            for (int i = 0; i < SelectedUser.Password.Length; i++)
            {
                accountPassword.Text += "*";
                ReAccountPassword.Text += "*";
            }
            //load Station points 

            points = SelectedUser.User_FFstations;
            int points_length = points != null ? points.Length : 0;
            CB_Stations_DT.Items.Clear();
            for (int i = 0; i < points_length; i++)
            {
                CB_Stations_DT.Items.Add(points[i].FF_ID);
            }

            //load User Pumps
            FF_pumps[] pumps = SelectedUser.User_FF_Pumps;
            int pumps_length = pumps != null ? pumps.Length : 0;
            DG_Pumps_DT.Rows.Clear();
            for (int i = 0; i < pumps_length; i++)
            {
                string[] row = new string[] {Convert.ToString(pumps[i].FF_pumpsID), pumps[i].PumpNumber, pumps[i].Area, pumps[i].Sector,
                    pumps[i].PumpType,pumps[i].Status,pumps[i].Address,pumps[i].Signs,pumps[i].Additional_info };

                DG_Pumps_DT.Rows.Add(row);
            }
        }
        #endregion

        #region Manager
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cmb = (ComboBox)sender;
            selectedManagerIndex = cmb.SelectedIndex;
            if (selectedManagerIndex >= 0)
            {
                TB_SelectedUserName_DT.Text = managers[selectedManagerIndex].Name;
                TB_SelectedUserBuisiness_DT.Text = managers[selectedManagerIndex].CurrentPosition;
                TB_SelectedUserPhone_DT.Text = managers[selectedManagerIndex].PhoneNumber;
                TB_SelectedUserInfo_DT.Text = managers[selectedManagerIndex].Info;
            }
        }
        private async void Deleted_SelectedManager_Click_1(object sender, EventArgs e)
        {
            if (managers == null)
                statusfeild.Text = "من فضلك اختر المسئول";
            else
            {
                bool flag = server_Class_Obj.Delete_Manager(managers[selectedManagerIndex].ManagerID);
                if (flag == true)
                {
                    statusfeild.ForeColor = Color.YellowGreen;
                    TB_SelectedUserName_DT.Clear();
                    TB_SelectedUserBuisiness_DT.Clear();
                    TB_SelectedUserPhone_DT.Clear();
                    TB_SelectedUserInfo_DT.Clear();
                    statusfeild.Text = " تم مسح المسئول بنجاح";
                    LoginAccount = await Task.Run(() => server_Class_Obj.Select_Account());
                    Update_Incident_Reporting_trv_Companies();
                }
                else
                {
                    statusfeild.ForeColor = Color.Red;
                    statusfeild.Text = "فشلت العملية";
                }
            }

        }

        private async void Delete_SelectedDangerous_Click_1(object sender, EventArgs e)
        {
            if (places == null)
                statusfeild.Text = " من فضلك اختر مصدر الخطورة ";
            else
            {
                bool flag = server_Class_Obj.Delete_SelectedDangerousPlaces(places[selectedDangerousIndex].DangerousPlaceID);
                if (flag == true)
                {
                    statusfeild.ForeColor = Color.YellowGreen;
                    HazardousSubstance.Clear();
                    DangerouseLocation.Clear();
                    FireMediator.Clear();
                    statusfeild.Text = " تم تعديل مصدر الخطورة بنجاح";
                    LoginAccount = await Task.Run(() => server_Class_Obj.Select_Account());
                    Update_Incident_Reporting_trv_Companies();
                }
                else
                {
                    statusfeild.ForeColor = Color.Red;
                    statusfeild.Text = "فشلت العملية";
                }
            }
        }
        #endregion

        #region Dangerous
        private void Dangerous_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            ComboBox cmb = (ComboBox)sender;
            selectedDangerousIndex = cmb.SelectedIndex;
            HazardousSubstance.Text = places[selectedDangerousIndex].HazardousSubstance;
            DangerouseLocation.Text = places[selectedDangerousIndex].Location;
            FireMediator.Text = places[selectedDangerousIndex].FireMediator;
        }
        #endregion

        #region Station
        private async void AddStationsManPower_Click(object sender, EventArgs e)
        {
            station.CarsNumber = TB_CarsNumber_DT.Text == null ? "" : Convert.ToString(TB_CarsNumber_DT.Text);
            station.SoliderNumber = TB_SoliderNumber_DT.Text == null ? "" : Convert.ToString(TB_SoliderNumber_DT.Text);
            station.AreaName= TB_area_DT.Text == null ? "" : Convert.ToString(TB_area_DT.Text);
            station.OfficersNumber = TB_OfficersNumber_DT.Text == null ? "" : Convert.ToString(TB_OfficersNumber_DT.Text);
            station.Sector = TB_sector_DT.Text == null ? "" : Convert.ToString(TB_sector_DT.Text);
            station.Signs = TB_signs_DT.Text == null ? "" : Convert.ToString(TB_signs_DT.Text);
            station.Street = TB_street_DT.Text == null ? "" : Convert.ToString(TB_street_DT.Text);
            station.ZoneNumber = TB_area_DT.Text == null ? "" : Convert.ToString(TB_area_DT.Text);
            station.Additional_info = TB_Additional_info_DT.Text == null ? "" : Convert.ToString(TB_Additional_info_DT.Text);
            station.UserID = Selected_User_ID;
            station.Equipments = TB_Equipments_DT.Text == null ? "" : TB_Equipments_DT.Text;

            FFstations st = server_Class_Obj.Add_FFstations(station);
            FF_ManPower men = new FF_ManPower();
            if (ff_ManPowerGrid.CurrentRow != null)
            {
                men.OfficerName = ff_ManPowerGrid.CurrentRow.Cells[0].Value == null ? "" : (string)ff_ManPowerGrid.CurrentRow.Cells[0].Value;
                men.Sector = ff_ManPowerGrid.CurrentRow.Cells[1].Value == null ? "" : (string)ff_ManPowerGrid.CurrentRow.Cells[1].Value;
                men.Area = ff_ManPowerGrid.CurrentRow.Cells[2].Value == null ? "" : (string)ff_ManPowerGrid.CurrentRow.Cells[2].Value;
                men.Rank = ff_ManPowerGrid.CurrentRow.Cells[3].Value == null ? "" : (string)ff_ManPowerGrid.CurrentRow.Cells[3].Value;
                men.Job = ff_ManPowerGrid.CurrentRow.Cells[4].Value == null ? "" : (string)ff_ManPowerGrid.CurrentRow.Cells[4].Value;
                men.Additional_info = ff_ManPowerGrid.CurrentRow.Cells[5].Value == null ? "" : (string)ff_ManPowerGrid.CurrentRow.Cells[5].Value;
                men.FF_ID = st.FF_ID;
                FF_ManPower MM = server_Class_Obj.AddFF_ManPower(men);
                if (MM != null)
                {
                    richTextBox1.ForeColor = Color.YellowGreen;
                    richTextBox1.Text = " تم إضافة البيانات بنجاح";
                    LoginAccount = await Task.Run(() => server_Class_Obj.Select_Account());
                    Load_User_Data(LoginAccount);
                }
                else
                {
                    richTextBox1.ForeColor = Color.Red;
                    richTextBox1.Text = "فشلت العملية";
                }
            }
            else if (st != null)
            {
                richTextBox1.ForeColor = Color.YellowGreen;
                richTextBox1.Text = " تم إضافة البيانات بنجاح";
            }
            else
            {
                richTextBox1.ForeColor = Color.Red;
                richTextBox1.Text = "فشلت العملية";
            }
        }

        private async void EditStationsManPower_Click(object sender, EventArgs e)
        {
            station.CarsNumber = TB_CarsNumber_DT.Text == null ? "" : Convert.ToString(TB_CarsNumber_DT.Text);
            station.SoliderNumber = TB_SoliderNumber_DT.Text == null ? "" : Convert.ToString(TB_SoliderNumber_DT.Text);
            station.OfficersNumber = TB_OfficersNumber_DT.Text == null ? "" : Convert.ToString(TB_OfficersNumber_DT.Text);
            station.AreaName= TB_area_DT.Text == null ? "" : Convert.ToString(TB_area_DT.Text);
            station.Sector = TB_sector_DT.Text == null ? "" : Convert.ToString(TB_sector_DT.Text);
            station.Signs = TB_signs_DT.Text == null ? "" : Convert.ToString(TB_signs_DT.Text);
            station.Street = TB_street_DT.Text == null ? "" : Convert.ToString(TB_street_DT.Text);
            station.ZoneNumber = TB_area_DT.Text == null ? "" : Convert.ToString(TB_area_DT.Text);
            station.Additional_info = TB_Additional_info_DT.Text == null ? "" : Convert.ToString(TB_Additional_info_DT.Text);
            station.UserID = Selected_User_ID;
            station.Equipments = TB_Equipments_DT.Text == null ? "" : TB_Equipments_DT.Text;
            station.FF_ID = points[selectedStationIndex].FF_ID;
            bool flag1 =await Task.Run(()=> server_Class_Obj.Update_FFstations(station));
            if (flag1 == true)
            {
                richTextBox1.ForeColor = Color.YellowGreen;
                richTextBox1.Text = " تم تعديل البيانات بنجاح";
                LoginAccount = await Task.Run(() => server_Class_Obj.Select_Account());
                Load_User_Data(LoginAccount);
            }
            else
            {
                richTextBox1.ForeColor = Color.Red;
                richTextBox1.Text = "فشلت العملية";
            }


            await Task.Run(()=>server_Class_Obj.DeleteFF_ManPower(station.FF_ID));
            FF_ManPower men = new FF_ManPower();
            for (int i = 0; i < ff_ManPowerGrid.RowCount - 1; i++)
            {
                if (ff_ManPowerGrid.Rows[i] != null)
                {
                    men.OfficerName = ff_ManPowerGrid.CurrentRow.Cells[0].Value == null ? "" : (string)ff_ManPowerGrid.CurrentRow.Cells[0].Value;
                    men.Sector = ff_ManPowerGrid.CurrentRow.Cells[1].Value == null ? "" : (string)ff_ManPowerGrid.CurrentRow.Cells[1].Value;
                    men.Area = ff_ManPowerGrid.CurrentRow.Cells[2].Value == null ? "" : (string)ff_ManPowerGrid.CurrentRow.Cells[2].Value;
                    men.Rank = ff_ManPowerGrid.CurrentRow.Cells[3].Value == null ? "" : (string)ff_ManPowerGrid.CurrentRow.Cells[3].Value;
                    men.Job = ff_ManPowerGrid.CurrentRow.Cells[4].Value == null ? "" : (string)ff_ManPowerGrid.CurrentRow.Cells[4].Value;
                    men.Additional_info = ff_ManPowerGrid.CurrentRow.Cells[5].Value == null ? "" : (string)ff_ManPowerGrid.CurrentRow.Cells[5].Value;
                    men.FF_ID = station.FF_ID;
                    FF_ManPower flag = await Task.Run(() => server_Class_Obj.AddFF_ManPower(men));
                    if (flag != null && flag1 == true)
                    {
                        richTextBox1.ForeColor = Color.YellowGreen;
                        richTextBox1.Text = " تم تعديل البيانات بنجاح";
                        LoginAccount = await Task.Run(() => server_Class_Obj.Select_Account());
                        Load_User_Data(LoginAccount);
                    }
                    else
                    {
                        richTextBox1.ForeColor = Color.Red;
                        richTextBox1.Text = "فشلت العملية";
                    }

                }
            }
        }

        private void CB_Stations_DT_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cmb = (ComboBox)sender;
            selectedStationIndex = cmb.SelectedIndex;
            if (points.Length >= selectedStationIndex)
            {
                TB_sector_DT.Text = points[selectedStationIndex].Sector==null?"": Convert.ToString(points[selectedStationIndex].Sector);
                TB_area_DT.Text = points[selectedStationIndex].AreaName==null?"": Convert.ToString(points[selectedStationIndex].AreaName);
                TB_street_DT.Text = points[selectedStationIndex].Street==null?"":Convert.ToString(points[selectedStationIndex].Street);
                TB_signs_DT.Text = points[selectedStationIndex].Signs==null? "" : Convert.ToString(points[selectedStationIndex].Signs);
                TB_Additional_info_DT.Text = points[selectedStationIndex].Additional_info==null?"": points[selectedStationIndex].Additional_info;
                TB_OfficersNumber_DT.Text = points[selectedStationIndex].OfficersNumber == null ? "" : Convert.ToString(points[selectedStationIndex].OfficersNumber);
                TB_SoliderNumber_DT.Text = points[selectedStationIndex].SoliderNumber==null?"" : Convert.ToString(points[selectedStationIndex].SoliderNumber);
                TB_CarsNumber_DT.Text = points[selectedStationIndex].CarsNumber==null?"": Convert.ToString(points[selectedStationIndex].CarsNumber);
                TB_Equipments_DT.Text = points[selectedStationIndex].Equipments==null?"": Convert.ToString(points[selectedStationIndex].Equipments);
                ff_ManPowerGrid.Rows.Clear();
                int Station_ManPower_length = points[selectedStationIndex].Station_ManPower != null ? points[selectedStationIndex].Station_ManPower.Length : 0;
                for (int i = 0; i < Station_ManPower_length; i++)
                {
                    string[] row = new string[] { points[selectedStationIndex].Station_ManPower[i].OfficerName,
                    points[selectedStationIndex].Station_ManPower[i].Sector, points[selectedStationIndex].Station_ManPower[i].Area,
                    points[selectedStationIndex].Station_ManPower[i].Rank,
                    points[selectedStationIndex].Station_ManPower[i].Job,
                    points[selectedStationIndex].Station_ManPower[i].Additional_info };

                    ff_ManPowerGrid.Rows.Add(row);
                }
            }
        }
        private async void DeleteStationsManPower_Click(object sender, EventArgs e)
        {
            bool flag = server_Class_Obj.Delete_FFstations(points[selectedStationIndex].FF_ID);
            if (flag == true)
            {
                richTextBox1.ForeColor = Color.YellowGreen;
                richTextBox1.Text = "تم مسح البيانات بنجاح";
                LoginAccount = await Task.Run(() => server_Class_Obj.Select_Account());
                Load_User_Data(LoginAccount);
            }
            else
            {
                richTextBox1.ForeColor = Color.Red;
                richTextBox1.Text = "فشلت العملية";
            }
        }

        #endregion

        #region Building

        private  void AddBuildings_Click_1(object sender, EventArgs e)
        {
            buildingCount++;
            Buildings building = new Buildings();
            if (BuildingNumber.Text == "")
                statusfeild.Text = "من فضلك أدخل رقم المبنى";
            else if (floorNumbers.Text == "")
                statusfeild.Text = "من فضلك أدخل رقم الدور";
            else
            {
                building.BuildingNumber = Convert.ToInt32(BuildingNumber.Text);
                building.FloorsNumber = Convert.ToInt32(floorNumbers.Text);
                building.MainWaterTankCapacity = mainTankCapacity.Text == null ? 0 : Convert.ToInt32(mainTankCapacity.Text);
                building.GeometricImage = BuildingGeoPic_DT.Image == null ? ImageToByteArray(imagenu) : ImageToByteArray(BuildingGeoPic_DT.Image);
                building.GeometricImageURL = GeoPicURL.Text;
                building.PathwaysImage= PB_ExitPathWayImage_DT.Image == null ? ImageToByteArray(imagenu) : ImageToByteArray(PB_ExitPathWayImage_DT.Image);
                Newbuildings.Add(building);
                statusfeild.Text = "تم حفظ البيانات اضغط تعديل للمتابعة";
                for (int i = 0; i < DG_Floors_DT.Rows.Count - 1; i++)
                {
                    Floors floor = new Floors();
                    if (DG_Floors_DT.Rows[i].Cells[0].Value != null)
                    {
                        floor.FloorNumber = (string)DG_Floors_DT.Rows[i].Cells[0].Value;
                    }
                    else
                    {
                        floor.FloorNumber = "";
                    }
                    if (DG_Floors_DT.Rows[i].Cells[1].Value != null)
                    {
                        floor.FireHydrantsNumber = (string)DG_Floors_DT.Rows[i].Cells[1].Value;
                    }
                    else
                    {
                        floor.FireHydrantsNumber = "";
                    }
                    if (DG_Floors_DT.Rows[i].Cells[2].Value != null)
                    {
                        floor.PowderExtinguishersNumber = (string)DG_Floors_DT.Rows[i].Cells[2].Value;
                    }
                    else
                    {
                        floor.PowderExtinguishersNumber = "";
                    }
                    if (DG_Floors_DT.Rows[i].Cells[3].Value != null)
                    {
                        floor.PowderExtinguishersWeight = Convert.ToInt32(DG_Floors_DT.Rows[i].Cells[3].Value);
                    }
                    else
                    {
                        floor.PowderExtinguishersWeight = 0;
                    }
                    if (DG_Floors_DT.Rows[i].Cells[4].Value != null)
                    {
                        floor.CarbonDioxideExtinguishersNumbers = (string)DG_Floors_DT.Rows[i].Cells[4].Value;
                    }
                    else
                    {
                        floor.CarbonDioxideExtinguishersNumbers = "";
                    }
                    if (DG_Floors_DT.Rows[i].Cells[5].Value != null)
                    {
                        floor.CarbonDioxideExtinguishersWeight = Convert.ToInt32(DG_Floors_DT.Rows[i].Cells[5].Value);
                    }
                    else
                    {
                        floor.CarbonDioxideExtinguishersWeight = 0;
                    }
                    if (DG_Floors_DT.Rows[i].Cells[6].Value != null)
                    {
                        floor.FoamExtinguishersNumbers = (string)DG_Floors_DT.Rows[i].Cells[6].Value;
                    }
                    else
                    {
                        floor.FoamExtinguishersNumbers = "";
                    }
                    if (DG_Floors_DT.Rows[i].Cells[7].Value != null)
                    {
                        floor.FoamExtinguishersWeight = Convert.ToInt32(DG_Floors_DT.Rows[i].Cells[7].Value);
                    }
                    else
                    {
                        floor.FoamExtinguishersWeight = 0;
                    }
                    NewFloors.Add(new KeyValuePair<int, Floors>(buildingCount, floor));

                }
            }
        }


        private void deleteBuildingList_Click_1(object sender, EventArgs e)
        {
            Newbuildings.Clear();
            BuildingNumber.Clear();
            floorNumbers.Clear();
            mainTankCapacity.Clear();
            GeoPicURL.Clear();
            BuildingGeoPic_DT.Image = null;
            DG_Floors_DT.Rows.Clear();
        }

        private void buildingCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cmb = (ComboBox)sender;
            selectedBuildingIndex = cmb.SelectedIndex;

            if (buildings.Length >= selectedBuildingIndex)
            {
                BuildingNumber.Text = Convert.ToString(buildings[selectedBuildingIndex].BuildingNumber);
                floorNumbers.Text = Convert.ToString(buildings[selectedBuildingIndex].FloorsNumber);
                mainTankCapacity.Text = Convert.ToString(buildings[selectedBuildingIndex].MainWaterTankCapacity);
                GeoPicURL.Text = buildings[selectedBuildingIndex].GeometricImageURL;
                 PB_ExitPathWayImage_DT.Image = buildings[selectedBuildingIndex].PathwaysImage == null|| buildings[selectedBuildingIndex].PathwaysImage.Length==2 ? System.Drawing.Image.FromStream(new System.IO.MemoryStream(ImageToByteArray(imagenu))) : System.Drawing.Image.FromStream(new System.IO.MemoryStream(buildings[selectedBuildingIndex].PathwaysImage));

                BuildingGeoPic_DT.Image = buildings[selectedBuildingIndex].GeometricImage == null ? System.Drawing.Image.FromStream(new System.IO.MemoryStream(ImageToByteArray(imagenu))) : System.Drawing.Image.FromStream(new System.IO.MemoryStream(buildings[selectedBuildingIndex].GeometricImage));
                Floors[] floor = buildings[selectedBuildingIndex].BuildingFloors;
                int floor_length = floor != null ? floor.Length : 0;
                DG_Floors_DT.Rows.Clear();
                for (int i = 0; i < floor_length; i++)
                {
                    string[] row = new string[] { floor[i].FloorNumber, floor[i].FireHydrantsNumber, floor[i].PowderExtinguishersNumber,
                    Convert.ToString(floor[i].PowderExtinguishersWeight),
                    floor[i].CarbonDioxideExtinguishersNumbers,
                    Convert.ToString(floor[i].CarbonDioxideExtinguishersWeight),
                    floor[0].FoamExtinguishersNumbers,
                    Convert.ToString(floor[0].FoamExtinguishersWeight)};

                    DG_Floors_DT.Rows.Add(row);
                }
                Images[] img = buildings[selectedBuildingIndex].BuildingImageCollection;
                int img_length = img != null ? img.Length : 0;
                if (img_length > 0)
                {
                    TB_CompanyImage_DT.Image = img[0].Image == null ? System.Drawing.Image.FromStream(new System.IO.MemoryStream(ImageToByteArray(imagenu))) : System.Drawing.Image.FromStream(new System.IO.MemoryStream(img[0].Image));
                    if (img_length > 1)
                    {
                        TB_CompanyGeometeryImage_DT.Image = img[1].Image == null ? System.Drawing.Image.FromStream(new System.IO.MemoryStream(ImageToByteArray(imagenu))) : System.Drawing.Image.FromStream(new System.IO.MemoryStream(img[1].Image));
                        if (img_length > 2)
                            PB_ExitPathWayImage_DT.Image = img[2].Image == null ? System.Drawing.Image.FromStream(new System.IO.MemoryStream(ImageToByteArray(imagenu))) : System.Drawing.Image.FromStream(new System.IO.MemoryStream(img[2].Image));
                    }
                }
            }
        }

        #endregion

        #region Company

        private async void DeleteCompany_Click_1(object sender, EventArgs e)
        {
            bool flag = server_Class_Obj.Delete_Company(Selected_Company_ID);
            if (flag == true)
            {
                statusfeild.ForeColor = Color.YellowGreen;
                statusfeild.Text = "تم مسح المنشأة بنجاح";
                LoginAccount = await Task.Run(() => server_Class_Obj.Select_Account());
                 Update_Incident_Reporting_trv_Companies();
            }

            else
            {
                statusfeild.ForeColor = Color.Red;
                statusfeild.Text = "فشلت عملية المسح";
            }
        }

        private async void SaveAddedBuildings_Click_1(object sender, EventArgs e)
        {

            ICompany c1 = new ICompany();
            c1.Name = TB_companyName_DT.Text == null ? "" : TB_companyName_DT.Text;
            c1.Address = TB_Address_DT.Text == null ? "" : TB_Address_DT.Text;
            c1.LandlinePhoneNumber = TB_LandlinePhone_DT.Text == null ? "" : TB_LandlinePhone_DT.Text;
            c1.ElectricalPanelLocation = TB_ElectricalPanelLocation_DT.Text == null ? "" : TB_ElectricalPanelLocation_DT.Text;
            c1.OxygenTrapLocation = TB_OxygenTrapLocation_DT.Text == null ? "" : TB_OxygenTrapLocation_DT.Text;
            c1.ISSI = ISSI.Text == null ? "" : ISSI.Text;
            c1.GasTrapLocation = TB_GasTrapLocation_DT.Text == null ? "" : TB_GasTrapLocation_DT.Text;
            c1.RightCompanyName = RightCompany_UC.TB_DComapnyName_UC_ELe.Text == null ? "" : RightCompany_UC.TB_DComapnyName_UC_ELe.Text;
            c1.RightCompanyBusiness = RightCompany_UC.TB_DCompanyBuisness_UC_ELe.Text == null ? "" : RightCompany_UC.TB_DCompanyBuisness_UC_ELe.Text;
            c1.LeftCompanyName = LeftCompany_UC.TB_DComapnyName_UC_ELe.Text == null ? "" : LeftCompany_UC.TB_DComapnyName_UC_ELe.Text;
            c1.LeftCompanyBusiness = LeftCompany_UC.TB_DCompanyBuisness_UC_ELe.Text == null ? "" : LeftCompany_UC.TB_DCompanyBuisness_UC_ELe.Text;
            c1.FrontCompanyName = FrontCompany_UC.TB_DComapnyName_UC_ELe.Text == null ? "" : FrontCompany_UC.TB_DComapnyName_UC_ELe.Text;
            c1.FrontCompanyBusiness = FrontCompany_UC.TB_DCompanyBuisness_UC_ELe.Text == null ? "" : FrontCompany_UC.TB_DCompanyBuisness_UC_ELe.Text;
            c1.BackCompanyName = BackCompany_UC.TB_DComapnyName_UC_ELe.Text == null ? "" : BackCompany_UC.TB_DComapnyName_UC_ELe.Text;
            c1.BackCompanyBusiness = BackCompany_UC.TB_DCompanyBuisness_UC_ELe.Text == null ? "" : BackCompany_UC.TB_DCompanyBuisness_UC_ELe.Text;
            c1.FrontFireMediator = FrontCompany_UC.TB_DCompanyMediator_UC_ELe.Text == null ? "" : FrontCompany_UC.TB_DCompanyMediator_UC_ELe.Text;
            c1.BackFireMediator = BackCompany_UC.TB_DCompanyMediator_UC_ELe.Text == null ? "" : BackCompany_UC.TB_DCompanyMediator_UC_ELe.Text;
            c1.RightFireMediator = RightCompany_UC.TB_DCompanyMediator_UC_ELe.Text == null ? "" : RightCompany_UC.TB_DCompanyMediator_UC_ELe.Text;
            c1.LeftFireMediator = LeftCompany_UC.TB_DCompanyMediator_UC_ELe.Text == null ? "" : LeftCompany_UC.TB_DCompanyMediator_UC_ELe.Text;
            c1.BuildingsNumber = TB_BuildingsNumber_DT.Text == "" ? 0 : Convert.ToInt32(TB_BuildingsNumber_DT.Text);
            c1.FrontCompanyImage = FrontCompany_UC.TB_DCompanyImage_UC_ELe.Image == null ? ImageToByteArray(imagenu) : ImageToByteArray(FrontCompany_UC.TB_DCompanyImage_UC_ELe.Image);
            c1.BackCompanyImage = BackCompany_UC.TB_DCompanyImage_UC_ELe.Image == null ? ImageToByteArray(imagenu) : ImageToByteArray(BackCompany_UC.TB_DCompanyImage_UC_ELe.Image);
            c1.RightCompanyImage = RightCompany_UC.TB_DCompanyImage_UC_ELe.Image == null ? ImageToByteArray(imagenu) : ImageToByteArray(RightCompany_UC.TB_DCompanyImage_UC_ELe.Image);
            c1.LeftCompanyImage = LeftCompany_UC.TB_DCompanyImage_UC_ELe.Image == null ? ImageToByteArray(imagenu) : ImageToByteArray(LeftCompany_UC.TB_DCompanyImage_UC_ELe.Image);
            c1.UserID = Selected_User_ID;
            c1.FrontCompanyImageURL = FrontCompany_UC.TB_DCompanyImageURL_UC_ELe.Text == null ? "" : FrontCompany_UC.TB_DCompanyImageURL_UC_ELe.Text;
            c1.BackCompanyImageURL = BackCompany_UC.TB_DCompanyImageURL_UC_ELe.Text == null ? "" : BackCompany_UC.TB_DCompanyImageURL_UC_ELe.Text;
            c1.RightCompanyImageURL = RightCompany_UC.TB_DCompanyImageURL_UC_ELe.Text == null ? "" : RightCompany_UC.TB_DCompanyImageURL_UC_ELe.Text;
            c1.LeftCompanyImageURL = LeftCompany_UC.TB_DCompanyImageURL_UC_ELe.Text == null ? "" : LeftCompany_UC.TB_DCompanyImageURL_UC_ELe.Text;
            c1.Longitude = 0;
            c1.Latitude = 0;
            c1.CompanyBuisiness = TB_CompanyBuisiness_DT.Text == null ? "" : Convert.ToString(TB_CompanyBuisiness_DT.Text);
            c1.StockVolume = TB_Stock_DT.Text == "" ? 0 : Convert.ToInt32(TB_Stock_DT.Text);
            c1.StockType = TB_StockType_DT.Text == "" ? "" : TB_StockType_DT.Text;
            c1.CompanyImage = TB_CompanyImage_DT.Image == null ? ImageToByteArray(imagenu) : ImageToByteArray(TB_CompanyImage_DT.Image);
            c1.CompanyGeometeryImage = TB_CompanyGeometeryImage_DT.Image == null ? ImageToByteArray(imagenu) : ImageToByteArray(TB_CompanyGeometeryImage_DT.Image);
            c1.sector = CB_Sector_DT.SelectedItem == null ? "" : CB_Sector_DT.SelectedItem.ToString();
            c1 = await Task.Run(() => server_Class_Obj.Add_Company(c1));
            if (c1 != null)
            {
                statusfeild.ForeColor = Color.YellowGreen;
                statusfeild.Text = "تم إضافة المنشأة بنجاح";
            }
            else
            {
                statusfeild.ForeColor = Color.Red;
                statusfeild.Text = "فشلت عملية الإضافة";
            }

            for (int i = 0; i < Newbuildings.Count; i++)
            {
                Newbuildings[i].CompanyID = c1.CompanyID;
                Buildings B1 = server_Class_Obj.Add_Building(Newbuildings[i]);

                foreach (var kvp in NewFloors.FindAll(m => m.Key == i + 1))
                {
                    Floors floor = new Floors();
                    kvp.Value.BuildingID = B1.BuildingID;
                    floor = await Task.Run(() => server_Class_Obj.Add_Floors(kvp.Value));

                }

            }
            DangerousPlaces place = new DangerousPlaces();
            place.Location = DangerouseLocation.Text;
            place.HazardousSubstance = HazardousSubstance.Text;
            place.FireMediator = FireMediator.Text;
            place.Image = ImageToByteArray(imagenu);
            place.ImageURL = "";
            if(c1!=null)
            place.CompanyID = c1.CompanyID;
            place = await Task.Run(() => server_Class_Obj.Add_DangerousPlace(place));

            Managers M = new Managers();
            M.Name = TB_SelectedUserName_DT.Text;
            M.CurrentPosition = TB_SelectedUserBuisiness_DT.Text;
            M.PhoneNumber = TB_SelectedUserPhone_DT.Text;
            M.Info = TB_SelectedUserInfo_DT.Text;
            M.CompanyID = Selected_Company_ID;
            M = server_Class_Obj.Add_Manager(M);
            LoginAccount = await Task.Run(() => server_Class_Obj.Select_Account());
             Update_Incident_Reporting_trv_Companies();
        }

        private async void EditCompany_Click_1(object sender, EventArgs e)
        {
            
            if (selectedCompany == null)
                statusfeild.Text = "من فضلك اختر المنشأة";
            else
            {
                ICompany c1 = new ICompany();
                c1.companyBuildings = selectedCompany.companyBuildings;
                c1.CompanyDangerousPlaces = selectedCompany.CompanyDangerousPlaces;
                c1.Name = TB_companyName_DT.Text == null ? "" : TB_companyName_DT.Text;
                c1.Address = TB_Address_DT.Text == null ? "" : TB_Address_DT.Text;
                c1.LandlinePhoneNumber = TB_LandlinePhone_DT.Text == null ? "" : TB_LandlinePhone_DT.Text;
                c1.ElectricalPanelLocation = TB_ElectricalPanelLocation_DT.Text == null ? "" : TB_ElectricalPanelLocation_DT.Text;
                c1.OxygenTrapLocation = TB_OxygenTrapLocation_DT.Text == null ? "" : TB_OxygenTrapLocation_DT.Text;
                c1.ISSI = ISSI.Text == null ? "" : ISSI.Text;
                c1.GasTrapLocation = TB_GasTrapLocation_DT.Text == null ? "" : TB_GasTrapLocation_DT.Text;
                c1.RightCompanyName = RightCompany_UC.TB_DComapnyName_UC_ELe.Text == null ? "" : RightCompany_UC.TB_DComapnyName_UC_ELe.Text;
                c1.RightCompanyBusiness = RightCompany_UC.TB_DCompanyBuisness_UC_ELe.Text == null ? "" : RightCompany_UC.TB_DCompanyBuisness_UC_ELe.Text;
                c1.LeftCompanyName = LeftCompany_UC.TB_DComapnyName_UC_ELe.Text == null ? "" : LeftCompany_UC.TB_DComapnyName_UC_ELe.Text;
                c1.LeftCompanyBusiness = LeftCompany_UC.TB_DCompanyBuisness_UC_ELe.Text == null ? "" : LeftCompany_UC.TB_DCompanyBuisness_UC_ELe.Text;
                c1.FrontCompanyName = FrontCompany_UC.TB_DComapnyName_UC_ELe.Text == null ? "" : FrontCompany_UC.TB_DComapnyName_UC_ELe.Text;
                c1.FrontCompanyBusiness = FrontCompany_UC.TB_DCompanyBuisness_UC_ELe.Text == null ? "" : FrontCompany_UC.TB_DCompanyBuisness_UC_ELe.Text;
                c1.BackCompanyName = BackCompany_UC.TB_DComapnyName_UC_ELe.Text == null ? "" : BackCompany_UC.TB_DComapnyName_UC_ELe.Text;
                c1.BackCompanyBusiness = BackCompany_UC.TB_DCompanyBuisness_UC_ELe.Text == null ? "" : BackCompany_UC.TB_DCompanyBuisness_UC_ELe.Text;
                c1.FrontFireMediator = FrontCompany_UC.TB_DCompanyMediator_UC_ELe.Text == null ? "" : FrontCompany_UC.TB_DCompanyMediator_UC_ELe.Text;
                c1.BackFireMediator = BackCompany_UC.TB_DCompanyMediator_UC_ELe.Text == null ? "" : BackCompany_UC.TB_DCompanyMediator_UC_ELe.Text;
                c1.RightFireMediator = RightCompany_UC.TB_DCompanyMediator_UC_ELe.Text == null ? "" : RightCompany_UC.TB_DCompanyMediator_UC_ELe.Text;
                c1.LeftFireMediator = LeftCompany_UC.TB_DCompanyMediator_UC_ELe.Text == null ? "" : LeftCompany_UC.TB_DCompanyMediator_UC_ELe.Text;
                c1.BuildingsNumber = TB_BuildingsNumber_DT.Text == "" ? 0 : Convert.ToInt32(TB_BuildingsNumber_DT.Text);
                c1.FrontCompanyImage = FrontCompany_UC.TB_DCompanyImage_UC_ELe.Image == null ? ImageToByteArray(imagenu) : ImageToByteArray(FrontCompany_UC.TB_DCompanyImage_UC_ELe.Image);
                c1.BackCompanyImage = BackCompany_UC.TB_DCompanyImage_UC_ELe.Image == null ? ImageToByteArray(imagenu) : ImageToByteArray(BackCompany_UC.TB_DCompanyImage_UC_ELe.Image);
                c1.RightCompanyImage = RightCompany_UC.TB_DCompanyImage_UC_ELe.Image == null ? ImageToByteArray(imagenu) : ImageToByteArray(RightCompany_UC.TB_DCompanyImage_UC_ELe.Image);
                c1.LeftCompanyImage = LeftCompany_UC.TB_DCompanyImage_UC_ELe.Image == null ? ImageToByteArray(imagenu) : ImageToByteArray(LeftCompany_UC.TB_DCompanyImage_UC_ELe.Image);
                c1.UserID = Selected_User_ID;
                c1.FrontCompanyImageURL = FrontCompany_UC.TB_DCompanyImageURL_UC_ELe.Text == null ? "" : FrontCompany_UC.TB_DCompanyImageURL_UC_ELe.Text;
                c1.BackCompanyImageURL = BackCompany_UC.TB_DCompanyImageURL_UC_ELe.Text == null ? "" : BackCompany_UC.TB_DCompanyImageURL_UC_ELe.Text;
                c1.RightCompanyImageURL = RightCompany_UC.TB_DCompanyImageURL_UC_ELe.Text == null ? "" : RightCompany_UC.TB_DCompanyImageURL_UC_ELe.Text;
                c1.LeftCompanyImageURL = LeftCompany_UC.TB_DCompanyImageURL_UC_ELe.Text == null ? "" : LeftCompany_UC.TB_DCompanyImageURL_UC_ELe.Text;
                c1.Longitude = 0;
                c1.Latitude = 0;
                c1.CompanyBuisiness = TB_CompanyBuisiness_DT.Text == null ? "" : TB_CompanyBuisiness_DT.Text;
                c1.StockVolume = TB_Stock_DT.Text == "" ? 0 : Convert.ToInt32(TB_Stock_DT.Text);
                c1.StockType = TB_StockType_DT.Text == null ? "" : TB_StockType_DT.Text;
                c1.CompanyID = Selected_Company_ID;
                c1.CompanyImage = TB_CompanyImage_DT.Image == null ? ImageToByteArray(imagenu) : ImageToByteArray(TB_CompanyImage_DT.Image);
                c1.CompanyGeometeryImage = TB_CompanyGeometeryImage_DT.Image == null ? ImageToByteArray(imagenu) : ImageToByteArray(TB_CompanyGeometeryImage_DT.Image);
                c1.sector = CB_Sector_DT.SelectedItem == null ? "" : CB_Sector_DT.SelectedItem.ToString(); 
               
                DangerousPlaces place = new DangerousPlaces();
                place.Location = DangerouseLocation.Text;
                place.HazardousSubstance = HazardousSubstance.Text;
                place.FireMediator = FireMediator.Text;
                place.Image = ImageToByteArray(imagenu);
                place.ImageURL = "";
                Managers M = new Managers();
                M.Name = TB_SelectedUserName_DT.Text;
                M.CurrentPosition = TB_SelectedUserBuisiness_DT.Text;
                M.PhoneNumber = TB_SelectedUserPhone_DT.Text;
                M.Info = TB_SelectedUserInfo_DT.Text;

                var x = System.Environment.CurrentManagedThreadId;
                bool flag = await Task.Run(() => server_Class_Obj.Update_Company(c1));
               
                    place.CompanyID = c1.CompanyID;
                    place = await Task.Run(() => server_Class_Obj.Add_DangerousPlace(place));
                
                if (flag == true)
                {
                    statusfeild.ForeColor = Color.YellowGreen;
                    statusfeild.Text = "تم تعديل المنشأة بنجاح";
                    M.CompanyID = Selected_Company_ID;
                    M = await Task.Run(() => server_Class_Obj.Add_Manager(M));
                    if (c1.companyBuildings != null)
                    {
                        
                        bool flag1 = server_Class_Obj.Delete_Building(c1.CompanyID);
                        if (flag1 == true)
                        {
                            int BuildingLength = c1.companyBuildings.Length > 0 ? c1.companyBuildings.Length : 0;
                            for (int i = 0; i < BuildingLength; i++)
                            {
                                c1.companyBuildings[i].CompanyID = c1.CompanyID;
                                Buildings B1 = await Task.Run(() => server_Class_Obj.Add_Building(c1.companyBuildings[i]));
                                if (c1.companyBuildings[i].BuildingFloors != null)
                                {
                                    for (int j = 0; j < c1.companyBuildings[i].BuildingFloors.Length; j++)
                                    {
                                        Floors floor = new Floors();
                                        if (B1 != null)
                                            c1.companyBuildings[i].BuildingFloors[j].BuildingID = B1.BuildingID;
                                        floor = await Task.Run(() => server_Class_Obj.Add_Floors(c1.companyBuildings[i].BuildingFloors[j]));
                                    }
                                }
                               

                            }
                        }

                    }
                    for (int i = 0; i < Newbuildings.Count; i++)
                    {
                        Newbuildings[i].CompanyID = c1.CompanyID;
                        Buildings B1 = server_Class_Obj.Add_Building(Newbuildings[i]);
                        if(B1!=null)
                        foreach (var kvp in NewFloors.FindAll(m => m.Key == i + 1))
                        {
                            Floors floor = new Floors();
                            kvp.Value.BuildingID = B1.BuildingID;
                            floor = await Task.Run(() => server_Class_Obj.Add_Floors(kvp.Value));
                        }
                        
                       
                    }

                    LoginAccount = await Task.Run(() => server_Class_Obj.Select_Account());
                    Update_Incident_Reporting_trv_Companies();
                }
                else
                {
                    statusfeild.ForeColor = Color.Red;
                    statusfeild.Text = "فشلت عملية التعديل";
                }
            }
        }


        #endregion

        #region clear

        private void Delete_SelectedBuilding_Click_1(object sender, EventArgs e)
        {
            if (buildings == null)
                statusfeild.Text = "من فضلك اختر المبنى";
            else
            {
                server_Class_Obj.Delete_SelectedBuilding(buildings[selectedBuildingIndex].BuildingID);

            }

        }

        #endregion

        #region images
        private void BuildingGeoPic_DT_Click_1(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            string filePath = openFileDialog1.FileName;
            if (File.Exists(filePath))
            {
                BuildingGeoPic_DT.Image = Image.FromFile(filePath);
            }
        }

        private void TB_CompanyImage_DT_Click_1(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            string filePath = openFileDialog1.FileName;
            if (File.Exists(filePath))
            {
                TB_CompanyImage_DT.Image = Image.FromFile(filePath);
            }
        }

        private void TB_CompanyGeometeryImage_DT_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            string filePath = openFileDialog1.FileName;
            if (File.Exists(filePath))
            {
                TB_CompanyGeometeryImage_DT.Image = Image.FromFile(filePath);
            }
        }

        private void PB_ExitPathWayImage_DT_Click_1(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            string filePath = openFileDialog1.FileName;
            if (File.Exists(filePath))
            {
                PB_ExitPathWayImage_DT.Image = Image.FromFile(filePath);
            }
        }
        #endregion

        #region Pump

        private async void EditPUMP_Click_1(object sender, EventArgs e)
        {
            pump = new FF_pumps();
            pump.FF_pumpsID = PumpID;
            pump.Additional_info = pumpInfo.Text == null ? "" : pumpInfo.Text;
            pump.Address = pumpAddress.Text == null ? "" : pumpAddress.Text;
            pump.Area = pumpArea.Text == null ? "" : pumpArea.Text;
            pump.PumpNumber = PumpNumber.Text == null ? "" : PumpNumber.Text;
            pump.Status = Status.Text == null ? "" : Status.Text;
            pump.Signs = pumpSign.Text == null ? "" : pumpSign.Text;
            pump.Sector = pumpSector.Text == null ? "" : pumpSector.Text;
            pump.PumpType = PumpType.Text == null ? "" : PumpType.Text;
            pump.UserID = Selected_User_ID;

            bool flag = server_Class_Obj.Update_FFPump(pump);
            if (flag == true)
            {
                label22.ForeColor = Color.YellowGreen;
                label22.Text = " تم تعديل المضخة بنجاح";
                LoginAccount = await Task.Run(() => server_Class_Obj.Select_Account());
                Load_User_Data(LoginAccount);
            }

            else
            {
                label22.ForeColor = Color.Red;
                label22.Text = "فشلت عملية التعديل";
            }

        }
        private void DG_Pumps_DT_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

            PumpNumber.Text = (string)DG_Pumps_DT.CurrentRow.Cells[1].Value == null ? "" : (string)DG_Pumps_DT.CurrentRow.Cells[1].Value;
            pumpArea.Text = (string)DG_Pumps_DT.CurrentRow.Cells[2].Value == null ? "" : (string)DG_Pumps_DT.CurrentRow.Cells[2].Value;
            pumpSector.Text = (string)DG_Pumps_DT.CurrentRow.Cells[3].Value == null ? "" : (string)DG_Pumps_DT.CurrentRow.Cells[3].Value;
            PumpType.Text = (string)DG_Pumps_DT.CurrentRow.Cells[4].Value == null ? "" : (string)DG_Pumps_DT.CurrentRow.Cells[4].Value;
            Status.Text = (string)DG_Pumps_DT.CurrentRow.Cells[5].Value == null ? "" : (string)DG_Pumps_DT.CurrentRow.Cells[5].Value;
            pumpAddress.Text = (string)DG_Pumps_DT.CurrentRow.Cells[6].Value == null ? "" : (string)DG_Pumps_DT.CurrentRow.Cells[6].Value;
            pumpSign.Text = (string)DG_Pumps_DT.CurrentRow.Cells[7].Value == null ? "" : (string)DG_Pumps_DT.CurrentRow.Cells[7].Value;
            pumpInfo.Text = (string)DG_Pumps_DT.CurrentRow.Cells[8].Value == null ? "" : (string)DG_Pumps_DT.CurrentRow.Cells[8].Value;
            PumpID = Convert.ToInt32(DG_Pumps_DT.CurrentRow.Cells[0].Value);
        }
        private async void button2_Click(object sender, EventArgs e)
        {
            pump = new FF_pumps();
            pump.FF_pumpsID = PumpID;
            pump.Additional_info = pumpInfo.Text == null ? "" : pumpInfo.Text;
            pump.Address = pumpAddress.Text == null ? "" : pumpAddress.Text;
            pump.Area = pumpArea.Text == null ? "" : pumpArea.Text;
            pump.PumpNumber = PumpNumber.Text == null ? "" : PumpNumber.Text;
            pump.Status = Status.Text == null ? "" : Status.Text;
            pump.Signs = pumpSign.Text == null ? "" : pumpSign.Text;
            pump.Sector = pumpSector.Text == null ? "" : pumpSector.Text;
            pump.PumpType = PumpType.Text == null ? "" : PumpType.Text;
            pump.UserID = Selected_User_ID;
            FF_pumps flag = server_Class_Obj.Add_FFPump(pump);
            if (flag != null)
            {
                label22.ForeColor = Color.YellowGreen;
                label22.Text = "تم إضافة المضخة بنجاح";
                LoginAccount = await Task.Run(() => server_Class_Obj.Select_Account());
                Load_User_Data(LoginAccount);
            }
            else
            {
                label22.ForeColor = Color.Red;
                label22.Text = "فشلت عملية الإضافة";
            }
        }
        private async void DeletePump_Click(object sender, EventArgs e)
        {
            PumpNumber.Text = "";
            pumpArea.Text = "";
            pumpSector.Text = "";
            PumpType.Text = "";
            Status.Text = "";
            pumpAddress.Text = "";
            pumpSign.Text = "";
            pumpInfo.Text = "";
            bool flag = server_Class_Obj.Delete_FF_pumps(PumpID);
            if (flag == true)
            {
                label22.ForeColor = Color.YellowGreen;
                label22.Text = "تم مسح المضخة بنجاح";
                LoginAccount = await Task.Run(() => server_Class_Obj.Select_Account());
                Load_User_Data(LoginAccount);

            }
            else
            {
                label22.ForeColor = Color.Red;
                label22.Text = "فشلت عملية المسح";
            }

        }
        #endregion

        #region Account

        private async void AddAccount_Click_1(object sender, EventArgs e)
        {
            try
            {
                IRUser user = new IRUser();
                user.Username = accountName.Text;
                user.AdminMode = "";
                if (string.Compare(accountPassword.Text, ReAccountPassword.Text) == 0)
                {
                    user.Password = accountPassword.Text;
                    user.Info = AccountInfo.Text;
                    IRUser newUser = server_Class_Obj.Add_Account(user);
                    if(newUser!=null)
                    {
                        Users_Admin User = new Users_Admin();
                        User.Admin_ID = Selected_User_ID != 0 ? Selected_User_ID : LoginAccount.UserID;
                        User.User_ID = newUser.UserID;
                        User.Info = Selected_User_ID + " over " + newUser.UserID;
                        Users_Admin flag = server_Class_Obj.Add_Users_Admin(User);
                        if (flag != null)
                        {
                            AccountStatus.ForeColor = Color.YellowGreen;
                            AccountStatus.Text = "تم إضافة المستخدم بنجاح";
                            LoginAccount = await Task.Run(() => server_Class_Obj.Select_Account());
                            Load_User_Data(LoginAccount);
                             Update_Incident_Reporting_trv_Companies();
                        }
                        else
                        {
                            AccountStatus.ForeColor = Color.Red;
                            AccountStatus.Text = "فشلت عملية الإضافة ";
                        }

                    }
                    
                }
                else
                {
                    AccountStatus.Text = " الرقم السري غير متطابق";
                }
            }
            catch (Exception exception1)
            {
                Auditing.Error(exception1.Message);
            }
        }

        private async void EditUser_Click_1(object sender, EventArgs e)
        {
            try
            {
                IRUser user = new IRUser();
                user.Username = accountName.Text;
                user.AdminMode = "";
                if (string.Compare(accountPassword.Text, ReAccountPassword.Text) == 0)
                {
                    if(accountPassword.Text == "**********")
                    {
                        AccountStatus.Text = "من فضلك ادخل الرقم السري ";
                        
                    }
                    else
                    user.Password = accountPassword.Text;
                }
                user.UserID = Selected_User_ID;
                user.Info = AccountInfo.Text;

                bool flag = server_Class_Obj.Update_Account(user);
                if (flag == true)
                {
                    AccountStatus.ForeColor = Color.YellowGreen;
                    AccountStatus.Text = " تم تعديل المستخدم بنجاح";
                    this.Close();
                    Login f1 = new Login();
                    f1.Show();
                }
                else
                {
                    AccountStatus.ForeColor = Color.Red;
                    AccountStatus.Text = "فشلت العملية";
                }
            }
            catch (Exception exception1)
            {
                Auditing.Error(exception1.Message);
            }
        }

        private async void DeleteUser_Click_1(object sender, EventArgs e)
        {
            bool flag = server_Class_Obj.Delete_Account(Selected_User_ID);
            if (flag == true)
            {
                AccountStatus.ForeColor = Color.YellowGreen;
                AccountStatus.Text = "تم مسح المستخدم بنجاح";
                LoginAccount = await Task.Run(() => server_Class_Obj.Select_Account());
                Load_User_Data(LoginAccount);
                 Update_Incident_Reporting_trv_Companies();
                //treeView3.Nodes.Remove(UserNode);
            }
            else
            {
                AccountStatus.ForeColor = Color.Red;
                AccountStatus.Text = "فشلت عملية المسح";
            }

        }



        #endregion

        #region Alarm
        private delegate void CheckAlarm_Delegate();

        public void CheckAlarm_Thread()
        {
            try
            {
                while (true)
                {
                    if (AlarmCheck == true)
                    {
                        CheckAlarm();
                    }

                    Thread.Sleep(20000);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Auditing.Error(ex.Message);
            }
        }

        private void CheckAlarm()
        {
            try
            {
                if (treeView3.InvokeRequired)
                {
                    CheckAlarm_Delegate _delegate = new CheckAlarm_Delegate(CheckAlarm);
                    treeView3.Invoke(_delegate, new object[] { });
                }
                else if (AlarmCheck == true)
                {
                    IncomingAlarm[] a = server_Class_Obj.Select_Alarms(Selected_User_ID);
                    if (a != null)
                    {
                        int alarmLength = a == null ? 0 : a.Length;
                        for (int i = 0; i < alarmLength; i++)
                        {
                            if (a[i].Acknowledege == 0)
                            {

                                selectedCompany = server_Class_Obj.Select_CompanyByISSI(a[i].RadioID.ToString());
                                IRUser U1 = server_Class_Obj.Select_User(Selected_User_ID);

                                Load_Data(selectedCompany);
                                Load_User_Data(U1);
                                break;
                            }
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Auditing.Error(ex.Message);
            }
        }
        #endregion

        #region TreeView

        private delegate void Update_Incident_Reporting_trv_Companies_Delegate();

        public void load_all_treeviews_cycle()
        {
            try
            {
                while (true)
                {

                    Update_Incident_Reporting_trv_Companies();
                    Thread.Sleep(2000000);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Auditing.Error(ex.Message);
            }
        }

        private void Update_Incident_Reporting_trv_Companies()
        {
            try
            {
                if (treeView3.InvokeRequired)
                {
                    Update_Incident_Reporting_trv_Companies_Delegate _delegate = new Update_Incident_Reporting_trv_Companies_Delegate(Update_Incident_Reporting_trv_Companies);
                    treeView3.Invoke(_delegate, new object[] { });
                }
                else
                {
                    treeView3.BeginUpdate();
                    #region Check the TV roots

                    if (treeView3.Nodes.Count == 0)
                    {
                        treeView3.Nodes.Add(LoginAccount.Username);
                        treeView3.Nodes[0].Tag = LoginAccount;
                        treeView3.Nodes[0].Name = "User";
                        //Add Main User Companies node
                        treeView3.Nodes[0].Nodes.Add("المنشآت");

                        //Add Main User Users node
                        treeView3.Nodes[0].Nodes.Add("المستخدمين");
                    }
                    else
                    {
                        treeView3.Nodes[0].Tag = LoginAccount;
                        treeView3.Nodes[0].Name = "User";
                    }

                    #endregion
                    #region Add , Edit and Delete main user Companies
                    if (First_Time_Loading_User_Data_Flag == false)
                    {
                        if (LoginAccount.User_Companies != null)
                        {
                            for (int umn = treeView3.Nodes[0].Nodes[0].Nodes.Count - 1; umn > LoginAccount.User_Companies.Length - 1; umn--)
                            {
                                treeView3.Nodes[0].Nodes[0].Nodes.RemoveAt(umn);
                            }

                            for (int um = 0; um < LoginAccount.User_Companies.Length; um++)
                            {
                                if (um <= treeView3.Nodes[0].Nodes[0].Nodes.Count - 1)
                                {
                                    treeView3.Nodes[0].Nodes[0].Nodes[um].Text = LoginAccount.User_Companies[um].Name.ToString();
                                    treeView3.Nodes[0].Nodes[0].Nodes[um].Tag = LoginAccount.User_Companies[um];
                                    treeView3.Nodes[0].Nodes[0].Nodes[um].Name = "Company";
                                }
                                else
                                {
                                    treeView3.Nodes[0].Nodes[0].Nodes.Add(LoginAccount.User_Companies[um].Name.ToString());
                                    treeView3.Nodes[0].Nodes[0].Nodes[treeView3.Nodes[0].Nodes[0].Nodes.Count - 1].Tag = LoginAccount.User_Companies[um];
                                    treeView3.Nodes[0].Nodes[0].Nodes[treeView3.Nodes[0].Nodes[0].Nodes.Count - 1].Name = "Company";
                                    treeView3.Nodes[0].Nodes[0].Nodes[treeView3.Nodes[0].Nodes[0].Nodes.Count - 1].Checked = true;
                                }
                            }
                        }
                        else
                        {
                            for (int udn = treeView3.Nodes[0].Nodes[0].Nodes.Count - 1; udn >= 0; udn--)
                            {
                                treeView3.Nodes[0].Nodes[0].Nodes.RemoveAt(udn);
                            }
                        }
                    }
                    else
                    {
                        if (LoginAccount.User_Companies != null)
                        {
                            for (int um = 0; um < LoginAccount.User_Companies.Length; um++)
                            {
                                treeView3.Nodes[0].Nodes[0].Nodes.Add(LoginAccount.User_Companies[um].Name.ToString());
                                treeView3.Nodes[0].Nodes[0].Nodes[treeView3.Nodes[0].Nodes[0].Nodes.Count - 1].Tag = LoginAccount.User_Companies[um];
                                treeView3.Nodes[0].Nodes[0].Nodes[treeView3.Nodes[0].Nodes[0].Nodes.Count - 1].Name = "Company";
                                treeView3.Nodes[0].Nodes[0].Nodes[treeView3.Nodes[0].Nodes[0].Nodes.Count - 1].Checked = true;
                            }
                        }
                    }
                    #endregion
                    Update_User_Users_Companies_TV(LoginAccount.Users_of_Users, treeView3.Nodes[0].Nodes[1]);
                    First_Time_Loading_User_Data_Flag = false;
                    treeView3.ExpandAll();
                    treeView3.EndUpdate();
                }
            }
            catch (Exception ex)
            {
                Auditing.Error(ex.Message);
            }
        }

        private void Update_User_Users_Companies_TV(IRUser[] users, TreeNode node_obj)
        {
            try
            {
                #region Add , Edit and Delete main user usercollection 

                if (First_Time_Loading_User_Data_Flag == false)
                {
                    if (users != null)
                    {
                        for (int un = node_obj.Nodes.Count - 1; un > users.Length - 1; un--)
                        {
                            node_obj.Nodes.RemoveAt(un);
                        }

                        for (int uc = 0; uc < users.Length; uc++)
                        {
                            if (uc <= node_obj.Nodes.Count - 1)
                            {
                                node_obj.Nodes[uc].Text = users[uc].Username;
                                node_obj.Nodes[uc].Tag = users[uc];
                                node_obj.Nodes[uc].Name = "User";

                                #region Add and Edit Companies
                                if (users[uc].User_Companies != null)
                                {
                                    for (int umn = node_obj.Nodes[uc].Nodes[0].Nodes.Count - 1; umn > users[uc].User_Companies.Length - 1; umn--)
                                    {
                                        node_obj.Nodes[uc].Nodes[0].Nodes.RemoveAt(umn);
                                    }

                                    for (int ucm = 0; ucm < users[uc].User_Companies.Length; ucm++)
                                    {
                                        if (ucm <= node_obj.Nodes[uc].Nodes[0].Nodes.Count - 1)
                                        {
                                            node_obj.Nodes[uc].Nodes[0].Nodes[ucm].Text = users[uc].User_Companies[ucm].Name.ToString();
                                            node_obj.Nodes[uc].Nodes[0].Nodes[ucm].Tag = users[uc].User_Companies[ucm];
                                            node_obj.Nodes[uc].Nodes[0].Nodes[ucm].Name = "Company";
                                        }
                                        else
                                        {
                                            node_obj.Nodes[uc].Nodes[0].Nodes.Add(users[uc].User_Companies[ucm].Name.ToString());
                                            node_obj.Nodes[uc].Nodes[0].Nodes[node_obj.Nodes[uc].Nodes[0].Nodes.Count - 1].Tag = users[uc].User_Companies[ucm];
                                            node_obj.Nodes[uc].Nodes[0].Nodes[node_obj.Nodes[uc].Nodes[0].Nodes.Count - 1].Name = "Company";
                                        }
                                    }
                                }
                                else
                                {
                                    if (node_obj.Nodes[uc].Nodes[0].Nodes != null)
                                    {
                                        for (int umn = node_obj.Nodes[uc].Nodes[0].Nodes.Count - 1; umn >= 0; umn--)
                                        {
                                            node_obj.Nodes[uc].Nodes[0].Nodes.RemoveAt(umn);
                                        }
                                    }
                                }
                                #endregion
                            }
                            else
                            {
                                node_obj.Nodes.Add(users[uc].Username, users[uc].Username);
                                node_obj.Nodes[node_obj.Nodes.Count - 1].Tag = users[uc];
                                node_obj.Nodes[node_obj.Nodes.Count - 1].Name = "User";
                                node_obj.Nodes[node_obj.Nodes.Count - 1].Checked = true;

                                node_obj.Nodes[node_obj.Nodes.Count - 1].Nodes.Add("المنشآت");
                                node_obj.Nodes[node_obj.Nodes.Count - 1].Nodes[node_obj.Nodes[node_obj.Nodes.Count - 1].Nodes.Count - 1].Checked = true;

                                #region Add and Edit Companies
                                if (users[uc].User_Companies != null)
                                {
                                    for (int umn = node_obj.Nodes[uc].Nodes[0].Nodes.Count - 1; umn > users[uc].User_Companies.Length - 1; umn--)
                                    {
                                        node_obj.Nodes[uc].Nodes[0].Nodes.RemoveAt(umn);
                                    }

                                    for (int ucm = 0; ucm < users[uc].User_Companies.Length; ucm++)
                                    {
                                        if (ucm <= node_obj.Nodes[uc].Nodes[0].Nodes.Count - 1)
                                        {
                                            node_obj.Nodes[uc].Nodes[0].Nodes[ucm].Text = users[uc].User_Companies[ucm].Name.ToString();
                                            node_obj.Nodes[uc].Nodes[0].Nodes[ucm].Tag = users[uc].User_Companies[ucm];
                                            node_obj.Nodes[uc].Nodes[0].Nodes[ucm].Name = "Company";
                                        }
                                        else
                                        {
                                            node_obj.Nodes[uc].Nodes[0].Nodes.Add(users[uc].User_Companies[ucm].Name.ToString());
                                            node_obj.Nodes[uc].Nodes[0].Nodes[node_obj.Nodes[uc].Nodes[0].Nodes.Count - 1].Tag = users[uc].User_Companies[ucm];
                                            node_obj.Nodes[uc].Nodes[0].Nodes[node_obj.Nodes[uc].Nodes[0].Nodes.Count - 1].Name = "Company";
                                        }
                                    }
                                }
                                else
                                {
                                    for (int umn = node_obj.Nodes[uc].Nodes[0].Nodes.Count - 1; umn >= 0; umn--)
                                    {
                                        node_obj.Nodes[uc].Nodes[0].Nodes.RemoveAt(umn);
                                    }
                                }
                                #endregion

                                //Add  User Users node
                                node_obj.Nodes[node_obj.Nodes.Count - 1].Nodes.Add("المستخدمين");
                                node_obj.Nodes[node_obj.Nodes.Count - 1].Nodes[node_obj.Nodes[node_obj.Nodes.Count - 1].Nodes.Count - 1].Checked = true;
                            }

                            Update_User_Users_Companies_TV(users[uc].Users_of_Users, node_obj.Nodes[uc].Nodes[1]);
                        }
                    }
                    else
                    {
                        for (int un = node_obj.Nodes.Count - 1; un >= 0; un--)
                        {
                            node_obj.Nodes.RemoveAt(un);
                        }
                    }
                }
                else
                {
                    if (users != null)
                    {
                        for (int uc = 0; uc < users.Length; uc++)
                        {
                            node_obj.Nodes.Add(users[uc].Username, users[uc].Username);
                            node_obj.Nodes[node_obj.Nodes.Count - 1].Tag = users[uc];
                            node_obj.Nodes[node_obj.Nodes.Count - 1].Name = "User";
                            node_obj.Nodes[node_obj.Nodes.Count - 1].Checked = true;

                            node_obj.Nodes[node_obj.Nodes.Count - 1].Nodes.Add("المنشآت");
                            node_obj.Nodes[node_obj.Nodes.Count - 1].Nodes[node_obj.Nodes[node_obj.Nodes.Count - 1].Nodes.Count - 1].Checked = true;

                            #region Add and Edit Companies
                            if (users[uc].User_Companies != null)
                            {
                                for (int umn = node_obj.Nodes[uc].Nodes[0].Nodes.Count - 1; umn > users[uc].User_Companies.Length - 1; umn--)
                                {
                                    node_obj.Nodes[uc].Nodes[0].Nodes.RemoveAt(umn);
                                }

                                for (int ucm = 0; ucm < users[uc].User_Companies.Length; ucm++)
                                {
                                    if (ucm <= node_obj.Nodes[uc].Nodes[0].Nodes.Count - 1)
                                    {
                                        node_obj.Nodes[uc].Nodes[0].Nodes[ucm].Text = users[uc].User_Companies[ucm].Name.ToString();
                                        node_obj.Nodes[uc].Nodes[0].Nodes[ucm].Tag = users[uc].User_Companies[ucm];
                                        node_obj.Nodes[uc].Nodes[0].Nodes[ucm].Name = "Company";
                                    }
                                    else
                                    {
                                        node_obj.Nodes[uc].Nodes[0].Nodes.Add(users[uc].User_Companies[ucm].Name.ToString());
                                        node_obj.Nodes[uc].Nodes[0].Nodes[node_obj.Nodes[uc].Nodes[0].Nodes.Count - 1].Tag = users[uc].User_Companies[ucm];
                                        node_obj.Nodes[uc].Nodes[0].Nodes[node_obj.Nodes[uc].Nodes[0].Nodes.Count - 1].Name = "Company";
                                        node_obj.Nodes[uc].Nodes[0].Nodes[node_obj.Nodes[uc].Nodes[0].Nodes.Count - 1].Checked = true;
                                    }
                                }
                            }
                            else
                            {
                                for (int umn = node_obj.Nodes[uc].Nodes[0].Nodes.Count - 1; umn >= 0; umn--)
                                {
                                    node_obj.Nodes[uc].Nodes[0].Nodes.RemoveAt(umn);
                                }
                            }
                            #endregion

                            //Add  User Users node
                            node_obj.Nodes[node_obj.Nodes.Count - 1].Nodes.Add("المستخدمين");
                            node_obj.Nodes[node_obj.Nodes.Count - 1].Nodes[node_obj.Nodes[node_obj.Nodes.Count - 1].Nodes.Count - 1].Checked = true;

                            Update_User_Users_Companies_TV(users[uc].Users_of_Users, node_obj.Nodes[uc].Nodes[1]);
                        }
                    }
                }
                #endregion
            }
            catch (Exception ex)
            {
                Auditing.Error(ex.Message);
            }
        }

        private void treeView3_AfterSelect(object sender, TreeViewEventArgs e)
        {
            var x = System.Environment.CurrentManagedThreadId;
            BuildingNumber.Clear();
            floorNumbers.Clear();
            mainTankCapacity.Clear();
            GeoPicURL.Clear();
            BuildingGeoPic_DT.Image = null;
            DG_Floors_DT.Rows.Clear();
            HazardousSubstance.Clear();
            DangerouseLocation.Clear();
            FireMediator.Clear();
            TB_SelectedUserName_DT.Clear();
            TB_SelectedUserBuisiness_DT.Clear();
            TB_SelectedUserPhone_DT.Clear();
            TB_SelectedUserInfo_DT.Clear();
            Newbuildings.Clear();
            NewFloors.Clear();
            statusfeild.Text = " ";
            if (e.Node.Name == "Company")
            {
                selectedCompany = (ICompany)e.Node.Tag;
                companyNode = e.Node;
                Selected_Company_ID = Convert.ToInt32(selectedCompany.CompanyID);
                IRUser U1 = (IRUser)e.Node.Parent.Parent.Tag;
                Selected_User_ID = Convert.ToInt32(U1.UserID);
                Load_Data(selectedCompany);
                Load_User_Data(U1);
            }
            else if (e.Node.Name == "User")
            {
                IRUser SelectedUser = (IRUser)e.Node.Tag;
                UserNode = e.Node;
                Selected_User_ID = Convert.ToInt32(SelectedUser.UserID);

                Load_User_Data(SelectedUser);

            }
        }
        #endregion
        private void checkBox1_CheckedChanged_1(object sender, EventArgs e)
        {
            try
            {
                AlarmCheck = !AlarmCheck;
            }
            catch (ThreadAbortException ex)
            {
                Thread.ResetAbort();
            }
        }

        private void Log_out_Click_1(object sender, EventArgs e)
        {

            this.Close();
            Login f1 = new Login();
            f1.Show();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            try
            {
                System.Environment.Exit(0);
            }
            catch (Exception ex)
            {
                Auditing.Error(ex.Message);
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (form_status == false)
            {
                this.WindowState = FormWindowState.Maximized;
                form_status = true;
            }
            else
            {
                this.WindowState = FormWindowState.Normal;
                form_status = false;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        
    }
}

