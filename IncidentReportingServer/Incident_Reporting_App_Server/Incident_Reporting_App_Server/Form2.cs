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
using Incident_Reporting_App_Server.localhost;
using SDS_Remote_Control_Application_Server.Code;
using System.Threading;
using System.IO;

namespace Incident_Reporting_App_Server
{
    public partial class Form2 : Form
    {
        int menu_Selected_Index = 0;
        ServerClass server_Class_Obj = new ServerClass();
        Incident_WS IncidentReporting_WS_Obj = new Incident_WS();
        
        byte[] imagenu = { 0x02,0x01};
        Users U1;
        Users LoginAccount;
        //Company[] companies;
        Buildings[] buildings;
        List<Buildings> Newbuildings = new List<Buildings>();
        List<KeyValuePair<int, Floors>> NewFloors = new List<KeyValuePair<int, Floors>>();
       // Dictionary<int, Floors> NewFloors = new Dictionary<int, Floors>();
        Managers[] managers;
        DangerousPlaces[] places;
        FFstations[] points;
        FFstations station=new FFstations();
        FF_ManPower men;
        Floors[] floors;
        ExitPathways[] exitPathWays;
        Company selectedCompany;
        FF_pumps[] pumps;
        FF_ManPower[] man;
        Company c1;
        FF_pumps pump ;
        int buildingCount = 0;
        int Selected_User_ID;
        int Selected_Company_ID;
        private bool First_Time_Loading_User_Data_Flag = true;
        public Form2()
        {
            InitializeComponent();
            pictureBox5.MouseWheel += PictureBox5_MouseWheel;
            Thread Main_Thread = new Thread(load_all_treeviews_cycle);
            Main_Thread.Start();
            LoginAccount = server_Class_Obj.Select_Account();
            #region load acounts treeview
            //LoginAccount = server_Class_Obj.Select_Account();
            //treeView3.Nodes[0].Tag = LoginAccount.UserID;
            //treeView3.Nodes[0].Text = LoginAccount.Username;
            //treeView3.Nodes[0].Name = "User";
            //TreeNode node = new TreeNode();
            //node.Tag = LoginAccount.User_Companies;
            //node.Text = "Companies";
            //treeView3.Nodes[0].Nodes.Add(node);
            //node.Tag = LoginAccount.Users_of_Users;
            //node.Text = "Users";
            //treeView3.Nodes[0].Nodes.Add(node);

            //Company[] LoginCompany = LoginAccount.User_Companies;
            //int LoginCompany_length = LoginCompany != null ? LoginCompany.Length : 0;
            //for (int i = 0; i < LoginCompany_length; i++)
            //{
            //    TreeNode company_node = new TreeNode();
            //    company_node.Text = LoginCompany[i].Name == null ? "" : LoginCompany[i].Name;
            //    company_node.Tag = LoginCompany[i].CompanyID;
            //    company_node.Name = "Company";
            //    treeView3.Nodes[0].Nodes[0].Nodes.Add(company_node);
            //}

            //Users[] Users = LoginAccount.Users_of_Users;
            //int Users_length = Users != null ? Users.Length : 0;
            //if (Users_length != 0)
            //{
            //    treeView3.BeginUpdate();
            //    for (int i = 0; i < Users_length; i++)
            //    {
            //        TreeNode user_node = new TreeNode();
            //        user_node.Text = Users[i].Username == null ? "" : Users[i].Username;
            //        user_node.Tag = Users[i].UserID;
            //        user_node.Name = "User";
            //        treeView3.Nodes[0].Nodes[1].Nodes.Add(user_node);
            //        Company[] companies = Users[i].User_Companies;
            //        int Companies_length = companies != null ? companies.Length : 0;
            //        if (Companies_length != 0)
            //        {
            //            node.Tag = LoginAccount.User_Companies;
            //            node.Text = "Companies";
            //            treeView3.Nodes[0].Nodes[1].Nodes[i].Nodes.Add(node);


            //            for (int j = 0; j < Companies_length; j++)
            //            {
            //                TreeNode company_node = new TreeNode();
            //                company_node.Text = companies[j].Name == null ? "" : companies[j].Name;
            //                company_node.Tag = companies[j].CompanyID;
            //                company_node.Name = "Company";

            //                treeView3.Nodes[0].Nodes[1].Nodes[i].Nodes[0].Nodes.Add(company_node);
            //            }
            //            Users[] UsersOfUser = Users[i].Users_of_Users;
            //            int UsersOfUser_length = UsersOfUser != null ? UsersOfUser.Length : 0;
            //            node.Tag = LoginAccount.Users_of_Users;
            //            node.Text = "Users";
            //            treeView3.Nodes[0].Nodes[1].Nodes[i].Nodes.Add(node);

            //            for (int k = 0; k < UsersOfUser_length; k++)
            //            {
            //                TreeNode moreUsers_node = new TreeNode();
            //                moreUsers_node.Text = UsersOfUser[k].Username == null ? "" : UsersOfUser[k].Username;
            //                moreUsers_node.Tag = UsersOfUser[k].UserID;
            //                moreUsers_node.Name = "User";

            //                treeView3.Nodes[0].Nodes[1].Nodes[i].Nodes[1].Nodes.Add(moreUsers_node);
            //            }
            //        }
            //    }
            //    treeView3.EndUpdate();
            //}
            //else
            //{
            //    treeView3.Nodes.Clear();
            //    return;
            //}
            //Thread Main_Thread = new Thread(load_all_treeviews_cycle);
            //Main_Thread.Start();
            //#endregion

            //#region load acounts treeview
            //LoginAccount = server_Class_Obj.Select_Account();
            //treeView3.Nodes[0].Tag = LoginAccount.UserID;
            //treeView3.Nodes[0].Text = LoginAccount.Username;
            //treeView3.Nodes[0].Name = "User";

            //Company[] LoginCompany = LoginAccount.User_Companies;
            //int LoginCompany_length = LoginCompany != null ? LoginCompany.Length : 0;
            //for (int i = 0; i < LoginCompany_length; i++)
            //{
            //    TreeNode company_node = new TreeNode();
            //    company_node.Text = LoginCompany[i].Name == null ? "" : LoginCompany[i].Name;
            //    company_node.Tag = LoginCompany[i].CompanyID;
            //    company_node.Name = "Company";
            //    treeView3.Nodes[0].Nodes.Add(company_node);
            //}

            //Users[] Users = LoginAccount.Users_of_Users;
            //int Users_length = Users != null ? Users.Length : 0;
            //if (Users_length != 0)
            //{
            //    treeView3.BeginUpdate();
            //    for (int i = 0; i < Users_length; i++)
            //    {
            //        TreeNode user_node = new TreeNode();
            //        user_node.Text = Users[i].Username == null ? "" : Users[i].Username;
            //        user_node.Tag = Users[i].UserID;
            //        user_node.Name = "User";
            //        treeView3.Nodes[0].Nodes.Add(user_node);
            //        Company[] companies = Users[i].User_Companies;
            //        int Companies_length = companies != null ? companies.Length : 0;
            //        if (Companies_length != 0)
            //        {
            //            for (int j = 0; j < Companies_length; j++)
            //            {
            //                TreeNode company_node = new TreeNode();
            //                company_node.Text = companies[j].Name == null ? "" : companies[j].Name;
            //                company_node.Tag = companies[j].CompanyID;
            //                company_node.Name = "Company";
            //                treeView3.Nodes[0].Nodes[LoginCompany_length + i].Nodes.Add(company_node);
            //            }
            //            Users[] UsersOfUser = Users[i].Users_of_Users;
            //            int UsersOfUser_length = UsersOfUser != null ? UsersOfUser.Length : 0;
            //            for (int k = 0; k < UsersOfUser_length; k++)
            //            {
            //                TreeNode moreUsers_node = new TreeNode();
            //                moreUsers_node.Text = UsersOfUser[k].Username == null ? "" : UsersOfUser[k].Username;
            //                moreUsers_node.Tag = UsersOfUser[k].UserID;
            //                moreUsers_node.Name = "User";
            //                treeView3.Nodes[0].Nodes[LoginCompany_length + i].Nodes.Add(moreUsers_node);
            //            }
            //        }
            //    }
            //    treeView3.EndUpdate();
            //}
            //else
            //{
            //    treeView3.Nodes.Clear();
            //    return;
            //}
            //Thread Main_Thread = new Thread(load_all_treeviews_cycle);
            //Main_Thread.Start();
            #endregion
        }
        public byte[] ImageToByteArray(System.Drawing.Image imageIn)
        {
            using (var ms = new MemoryStream())
            {
                imageIn.Save(ms, imageIn.RawFormat);
                return ms.ToArray();
            }
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
        private void Load_Data( int Selected_Company_ID )
        {

            //load account info

             U1 = server_Class_Obj.Select_User(Selected_User_ID);
            accountName.Text = U1.Username==null?"": U1.Username;
            AccountInfo.Text = U1.Info==null?"": U1.Info;
            accountPassword.Clear();
            ReAccountPassword.Clear();
            for (int i = 0; i < U1.Password.Length; i++)
            {
                accountPassword.Text += "*";
                ReAccountPassword.Text += "*";
            }

            //load selected company Data
            
            selectedCompany = server_Class_Obj.Select_Company(Selected_Company_ID);
            TB_companyName_DT.Text = selectedCompany.Name==null?"": selectedCompany.Name;
            govern.Text = selectedCompany.Address==null?"": selectedCompany.Address;
            TB_Address_DT.Text = selectedCompany.Address==null?"": selectedCompany.Address;
            district.Text= selectedCompany.Address == null ? "" : selectedCompany.Address;
            TB_LandlinePhone_DT.Text = selectedCompany.LandlinePhoneNumber==null?"": selectedCompany.LandlinePhoneNumber;
            TB_BuildingsNumber_DT.Text = Convert.ToString(selectedCompany.BuildingsNumber)==null?"": Convert.ToString(selectedCompany.BuildingsNumber);
            TB_ElectricalPanelLocation_DT.Text = selectedCompany.ElectricalPanelLocation==null?"": selectedCompany.ElectricalPanelLocation;
            TB_GasTrapLocation_DT.Text = selectedCompany.GasTrapLocation==null?"": selectedCompany.GasTrapLocation;
            TB_OxygenTrapLocation_DT.Text = selectedCompany.OxygenTrapLocation==null?"": selectedCompany.OxygenTrapLocation;
            TB_CompanyImage_DT.Image = selectedCompany.RightCompanyImage==null? System.Drawing.Image.FromStream(new System.IO.MemoryStream(imagenu)) : System.Drawing.Image.FromStream(new System.IO.MemoryStream(selectedCompany.RightCompanyImage));
            
            //Loading the neighboring companies

            PictureBox P1 = new PictureBox();
            P1.Image= System.Drawing.Image.FromStream(new System.IO.MemoryStream(selectedCompany.BackCompanyImage));
            
            FrontCompany_UC.TB_DCompanyBuisness_UC_ELe.Text= selectedCompany.FrontCompanyBusiness;
            FrontCompany_UC.TB_DComapnyName_UC_ELe.Text = selectedCompany.FrontCompanyName;
            FrontCompany_UC.TB_DCompanyMediator_UC_ELe.Text = selectedCompany.FrontFireMediator;
            FrontCompany_UC.TB_DCompanyImageURL_UC_ELe.Text = selectedCompany.FrontCompanyImageURL;
            FrontCompany_UC.TB_DCompanyImage_UC_ELe.Image = selectedCompany.FrontCompanyImage == null? System.Drawing.Image.FromStream(new System.IO.MemoryStream(imagenu))  : System.Drawing.Image.FromStream(new System.IO.MemoryStream(selectedCompany.FrontCompanyImage));

            BackCompany_UC.TB_DCompanyBuisness_UC_ELe.Text = selectedCompany.BackCompanyBusiness;
            BackCompany_UC.TB_DComapnyName_UC_ELe.Text = selectedCompany.BackCompanyName;
            BackCompany_UC.TB_DCompanyMediator_UC_ELe.Text = selectedCompany.BackFireMediator;
            BackCompany_UC.TB_DCompanyImageURL_UC_ELe.Text = selectedCompany.BackCompanyImageURL;
            BackCompany_UC.TB_DCompanyImage_UC_ELe.Image = selectedCompany.BackCompanyImage == null ? System.Drawing.Image.FromStream(new System.IO.MemoryStream(imagenu)) : System.Drawing.Image.FromStream(new System.IO.MemoryStream(selectedCompany.BackCompanyImage));



            RightCompany_UC.TB_DCompanyBuisness_UC_ELe.Text = selectedCompany.RightCompanyBusiness;
            RightCompany_UC.TB_DComapnyName_UC_ELe.Text = selectedCompany.RightCompanyName;
            RightCompany_UC.TB_DCompanyMediator_UC_ELe.Text = selectedCompany.RightFireMediator;
            RightCompany_UC.TB_DCompanyImageURL_UC_ELe.Text = selectedCompany.RightCompanyImageURL;
            RightCompany_UC.TB_DCompanyImage_UC_ELe.Image = selectedCompany.RightCompanyImage == null ? System.Drawing.Image.FromStream(new System.IO.MemoryStream(imagenu)) : System.Drawing.Image.FromStream(new System.IO.MemoryStream(selectedCompany.RightCompanyImage));

            LeftCompany_UC.TB_DCompanyBuisness_UC_ELe.Text = selectedCompany.LeftCompanyBusiness;
            LeftCompany_UC.TB_DComapnyName_UC_ELe.Text = selectedCompany.LeftCompanyName;
            LeftCompany_UC.TB_DCompanyMediator_UC_ELe.Text = selectedCompany.LeftFireMediator;
            LeftCompany_UC.TB_DCompanyImageURL_UC_ELe.Text = selectedCompany.LeftCompanyImageURL;
            LeftCompany_UC.TB_DCompanyImage_UC_ELe.Image = selectedCompany.LeftCompanyImage == null ? System.Drawing.Image.FromStream(new System.IO.MemoryStream(imagenu)) : System.Drawing.Image.FromStream(new System.IO.MemoryStream(selectedCompany.LeftCompanyImage));

            richTextBox38.AppendText(selectedCompany.GasTrapLocation);
           richTextBox38.AppendText( selectedCompany.OxygenTrapLocation);
            richTextBox38.AppendText(selectedCompany.ElectricalPanelLocation);
           
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
                Dangerous.Items.Add(places[i].Location);
            }

            //load Station points 

            points = U1.User_FFstations;
            int points_length = points != null ? points.Length : 0;
            CB_Stations_DT.Items.Clear();
            for (int i = 0; i < points_length; i++)
            {
                CB_Stations_DT.Items.Add(points[i].FF_ID);
            }

            

            //load User Pumps
            pumps = U1.User_FF_Pumps;
            int pumps_length = pumps != null ? pumps.Length : 0;
            for(int i=0;i< pumps_length; i++)
            {
                string[] row = new string[] { pumps[i].PumpNumber, pumps[i].Area, pumps[i].Sector,
                    pumps[i].PumpType,pumps[i].Status,pumps[i].Address,pumps[i].Signs,pumps[i].Additional_info };
                DG_Pumps_DT.Rows.Add(row);
            }

            

        }

        #endregion

        #region Manager
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cmb = (ComboBox)sender;
            int selectedIndex = cmb.SelectedIndex;
            TB_SelectedUserName_DT.Text = managers[selectedIndex].Name;
            TB_SelectedUserBuisiness_DT.Text = managers[selectedIndex].CurrentPosition;
            TB_SelectedUserPhone_DT.Text = managers[selectedIndex].PhoneNumber;
            TB_SelectedUserInfo_DT.Text = managers[selectedIndex].Info;
        }
        #endregion

        #region Dangerous
        private void Dangerous_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            ComboBox cmb = (ComboBox)sender;
            int selectedIndex = cmb.SelectedIndex;
            HazardousSubstance.Text = places[selectedIndex].HazardousSubstance;
            DangerouseLocation.Text = places[selectedIndex].Location;
            FireMediator.Text = places[selectedIndex].FireMediator;
        }
        #endregion

        #region Station
        private void AddStationsManPower_Click(object sender, EventArgs e)
        {
            station.CarsNumber = TB_CarsNumber_DT.Text == null ? "" : Convert.ToString(TB_CarsNumber_DT.Text);
            station.SoliderNumber = TB_SoliderNumber_DT.Text == null ? "" : Convert.ToString(TB_SoliderNumber_DT.Text);
            station.Sector = TB_sector_DT.Text == null ? "" : Convert.ToString(TB_sector_DT.Text);
            station.Signs = TB_signs_DT.Text == null ? "" : Convert.ToString(TB_signs_DT.Text);
            station.Street = TB_street_DT.Text == null ? "" : Convert.ToString(TB_street_DT.Text);
            station.ZoneNumber = TB_area_DT.Text == null ? "" : Convert.ToString(TB_area_DT.Text);
            station.Additional_info = TB_Additional_info_DT.Text == null ? "" : Convert.ToString(TB_Additional_info_DT.Text);
            station.UserID = Selected_User_ID;


            FFstations st = server_Class_Obj.Add_FFstations(station);
            men = new FF_ManPower();
            men.OfficerName = ff_ManPowerGrid.CurrentRow.Cells[0].Value==null?"":(string)ff_ManPowerGrid.CurrentRow.Cells[0].Value;
            men.Sector = ff_ManPowerGrid.CurrentRow.Cells[1].Value==null?"":(string)ff_ManPowerGrid.CurrentRow.Cells[1].Value;
            men.Area = ff_ManPowerGrid.CurrentRow.Cells[2].Value==null?"":(string)ff_ManPowerGrid.CurrentRow.Cells[2].Value;
            men.Rank = ff_ManPowerGrid.CurrentRow.Cells[3].Value==null?"":(string)ff_ManPowerGrid.CurrentRow.Cells[3].Value;
            men.Job = ff_ManPowerGrid.CurrentRow.Cells[4].Value==null?"":(string)ff_ManPowerGrid.CurrentRow.Cells[4].Value;
            men.Additional_info = ff_ManPowerGrid.CurrentRow.Cells[5].Value==null?"":(string)ff_ManPowerGrid.CurrentRow.Cells[5].Value;
            men.FF_ID = st.FF_ID;
            FF_ManPower MM = server_Class_Obj.AddFF_ManPower(men);
            if (MM != null)
                label22.Text="\n Station_ManPower Updated Successfully";
        }

        private void EditStationsManPower_Click_1(object sender, EventArgs e)
        {
            station.CarsNumber = TB_CarsNumber_DT.Text == null ? "" : Convert.ToString(TB_CarsNumber_DT.Text);
            station.SoliderNumber = TB_SoliderNumber_DT.Text == null ? "" : Convert.ToString(TB_SoliderNumber_DT.Text);
            station.Sector = TB_sector_DT.Text == null ? "" : Convert.ToString(TB_sector_DT.Text);
            station.Signs = TB_signs_DT.Text == null ? "" : Convert.ToString(TB_signs_DT.Text);
            station.Street = TB_street_DT.Text == null ? "" : Convert.ToString(TB_street_DT.Text);
            station.ZoneNumber = TB_area_DT.Text == null ? "" : Convert.ToString(TB_area_DT.Text);
            station.Additional_info = TB_Additional_info_DT.Text == null ? "" : Convert.ToString(TB_Additional_info_DT.Text);
            station.UserID = Selected_User_ID;
            bool flag1 = server_Class_Obj.Update_FFstations(station);
            men = new FF_ManPower();
            men.OfficerName = ff_ManPowerGrid.CurrentRow.Cells[0].Value==null?"":(string)ff_ManPowerGrid.CurrentRow.Cells[0].Value;
            men.Sector = ff_ManPowerGrid.CurrentRow.Cells[1].Value==null?"":(string)ff_ManPowerGrid.CurrentRow.Cells[1].Value;
            men.Area = ff_ManPowerGrid.CurrentRow.Cells[2].Value==null?"":(string)ff_ManPowerGrid.CurrentRow.Cells[2].Value;
            men.Rank = ff_ManPowerGrid.CurrentRow.Cells[3].Value==null?"":(string)ff_ManPowerGrid.CurrentRow.Cells[3].Value;
            men.Job = ff_ManPowerGrid.CurrentRow.Cells[4].Value==null?"":(string)ff_ManPowerGrid.CurrentRow.Cells[4].Value;
            men.Additional_info = (string)ff_ManPowerGrid.CurrentRow.Cells[5].Value;
            men.FF_ID = station.FF_ID;
            bool flag = server_Class_Obj.Update_FF_ManPower(men);
            if (flag == true && flag1 == true)
                richTextBox1.Text="\n Station_ManPower Updated Successfully";
        }

        private void DeleteStationsManPower_Click_1(object sender, EventArgs e)
        {
            bool flag = server_Class_Obj.Delete_FFstations(station.FF_ID);
            if (flag == true)
                richTextBox1.Text="\n Station_ManPower Deleted Successfully";
        }

        #endregion
        

        #region Building

        private void AddBuildings_Click_1(object sender, EventArgs e)
        {
            buildingCount++;
            Buildings building = new Buildings();
            building.BuildingNumber = BuildingNumber.Text==null?0:Convert.ToInt32(BuildingNumber.Text);
            building.FloorsNumber = floorNumbers.Text == null ? 0 : Convert.ToInt32(floorNumbers.Text);
            building.MainWaterTankCapacity = mainTankCapacity.Text == null ? 0 : Convert.ToInt32(mainTankCapacity.Text);
            building.GeometricImage = mainTankCapacity.Text == null ? imagenu : ImageToByteArray(BuildingGeoPic_DT.Image);
            building.GeometricImageURL = GeoPicURL.Text;
            Newbuildings.Add(building);
            for (int i = 0; i < DG_Floors_DT.Rows.Count; i++)
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
        private void SaveAddedBuildings_Click_1(object sender, EventArgs e)
        {
            
            Company c1 = new Company();
            c1.Name = TB_companyName_DT.Text;
            c1.Address = TB_Address_DT.Text;
            c1.LandlinePhoneNumber = TB_LandlinePhone_DT.Text;
            c1.ElectricalPanelLocation = TB_ElectricalPanelLocation_DT.Text;
            c1.OxygenTrapLocation = TB_OxygenTrapLocation_DT.Text;
            c1.GasTrapLocation = TB_GasTrapLocation_DT.Text;
            c1.RightCompanyName = RightCompany_UC.TB_DComapnyName_UC_ELe.Text;
            c1.RightCompanyBusiness = RightCompany_UC.TB_DCompanyBuisness_UC_ELe.Text;
            c1.LeftCompanyName = LeftCompany_UC.TB_DComapnyName_UC_ELe.Text;
            c1.LeftCompanyBusiness = LeftCompany_UC.TB_DCompanyBuisness_UC_ELe.Text;
            c1.FrontCompanyName = FrontCompany_UC.TB_DComapnyName_UC_ELe.Text;
            c1.FrontCompanyBusiness = FrontCompany_UC.TB_DCompanyBuisness_UC_ELe.Text;
            c1.BackCompanyName = BackCompany_UC.TB_DComapnyName_UC_ELe.Text;
            c1.BackCompanyBusiness = BackCompany_UC.TB_DCompanyBuisness_UC_ELe.Text;
            c1.FrontFireMediator = FrontCompany_UC.TB_DCompanyMediator_UC_ELe.Text;
            c1.BackFireMediator = BackCompany_UC.TB_DCompanyMediator_UC_ELe.Text;
            c1.RightFireMediator = RightCompany_UC.TB_DCompanyMediator_UC_ELe.Text;
            c1.LeftFireMediator = LeftCompany_UC.TB_DCompanyMediator_UC_ELe.Text;
            c1.BuildingsNumber = Convert.ToInt32(TB_BuildingsNumber_DT.Text);
            c1.FrontCompanyImage = FrontCompany_UC.TB_DCompanyImage_UC_ELe.Image == null ?imagenu : ImageToByteArray(FrontCompany_UC.TB_DCompanyImage_UC_ELe.Image);
            c1.BackCompanyImage = BackCompany_UC.TB_DCompanyImage_UC_ELe.Image == null ? imagenu : ImageToByteArray(BackCompany_UC.TB_DCompanyImage_UC_ELe.Image);
            c1.RightCompanyImage = RightCompany_UC.TB_DCompanyImage_UC_ELe.Image == null ? imagenu : ImageToByteArray(RightCompany_UC.TB_DCompanyImage_UC_ELe.Image);
            c1.LeftCompanyImage = LeftCompany_UC.TB_DCompanyImage_UC_ELe.Image == null ? imagenu : ImageToByteArray(LeftCompany_UC.TB_DCompanyImage_UC_ELe.Image);
            c1.UserID = Selected_User_ID;
            c1.FrontCompanyImageURL = FrontCompany_UC.TB_DCompanyImageURL_UC_ELe.Text==null?"": FrontCompany_UC.TB_DCompanyImageURL_UC_ELe.Text;
            c1.BackCompanyImageURL = BackCompany_UC.TB_DCompanyImageURL_UC_ELe.Text==null?"": BackCompany_UC.TB_DCompanyImageURL_UC_ELe.Text;
            c1.RightCompanyImageURL = RightCompany_UC.TB_DCompanyImageURL_UC_ELe.Text==null?"": RightCompany_UC.TB_DCompanyImageURL_UC_ELe.Text;
            c1.LeftCompanyImageURL = LeftCompany_UC.TB_DCompanyImageURL_UC_ELe.Text==null?"": LeftCompany_UC.TB_DCompanyImageURL_UC_ELe.Text;
            c1.Longitude = 0;
            c1.Latitude = 0;
            c1.CompanyBuisiness = TB_CompanyBuisiness_DT.Text==null?"": Convert.ToString(TB_CompanyBuisiness_DT.Text);
            c1.StockVolume = TB_Stock_DT.Text==""?0: Convert.ToInt32(TB_Stock_DT.Text);
            c1.StockType = TB_StockType_DT.Text==""?"": TB_StockType_DT.Text;
            c1.CompanyImage = TB_CompanyImage_DT.Image==null? imagenu : ImageToByteArray(TB_CompanyImage_DT.Image);
            c1.CompanyGeometeryImage = TB_CompanyGeometeryImage_DT.Image == null ? imagenu : ImageToByteArray(TB_CompanyGeometeryImage_DT.Image);
            c1 = server_Class_Obj.Add_Company(c1);
            if(c1!=null)
            {
                statusfeild.Text += "\t Company added Successfully";
            }

            for (int i = 0; i < Newbuildings.Count; i++)
            {
                Newbuildings[i].CompanyID = c1.CompanyID;
                Buildings B1 = server_Class_Obj.Add_Building(Newbuildings[i]);
                if (B1 != null)
                    statusfeild.Text +="\t Building added Successfully";
                foreach (var kvp in NewFloors.FindAll(m => m.Key == i+1))
                {
                    Floors floor = new Floors();
                    kvp.Value.BuildingID = B1.BuildingID;
                    floor=server_Class_Obj.Add_Floors(kvp.Value);
                    if (floor != null)
                        statusfeild.Text +="\t Floor added Successfully";
                }

                ExitPathways exitPathWay = new ExitPathways();
                exitPathWay.BuildingID = B1.BuildingID;
                exitPathWay.PathwaysImage = PB_ExitPathWayImage_DT.Image == null ? imagenu : ImageToByteArray(PB_ExitPathWayImage_DT.Image);
                exitPathWay.PathwaysImageURL = "";
                exitPathWay.Description = "";
                exitPathWay = server_Class_Obj.Add_exitPath(exitPathWay);
                if (exitPathWay != null)
                    statusfeild.Text +="\t exitPathWay added Successfully";
            }
            DangerousPlaces place = new DangerousPlaces();
            place.Location = DangerouseLocation.Text;
            place.HazardousSubstance = HazardousSubstance.Text;
            place.FireMediator = FireMediator.Text;
            place.Image = imagenu;
            place.ImageURL = "";
            place.CompanyID = c1.CompanyID;
            place = server_Class_Obj.Add_DangerousPlace(place);
            if (place != null)
                statusfeild.Text +="\t DangerousPlaces added Successfully";
        }

        private void deleteBuildingList_Click_1(object sender, EventArgs e)
        {
            Newbuildings.Clear();
        }

        private void buildingCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cmb = (ComboBox)sender;
            int selectedIndex = cmb.SelectedIndex;
            if (buildings.Length >= selectedIndex)
            {
                BuildingNumber.Text = Convert.ToString(buildings[selectedIndex].BuildingNumber);
                floorNumbers.Text = Convert.ToString(buildings[selectedIndex].FloorsNumber);
                mainTankCapacity.Text = Convert.ToString(buildings[selectedIndex].MainWaterTankCapacity);
                GeoPicURL.Text = buildings[selectedIndex].GeometricImageURL;
                if (buildings[selectedIndex].BuildingExitPaths != null)
                    PB_ExitPathWayImage_DT.Image = buildings[selectedIndex].BuildingExitPaths[0].PathwaysImage==null? System.Drawing.Image.FromStream(new System.IO.MemoryStream(imagenu)) : System.Drawing.Image.FromStream(new System.IO.MemoryStream(buildings[selectedIndex].BuildingExitPaths[0].PathwaysImage));
                BuildingGeoPic_DT.Image = buildings[selectedIndex].GeometricImage==null? System.Drawing.Image.FromStream(new System.IO.MemoryStream(imagenu)): System.Drawing.Image.FromStream(new System.IO.MemoryStream(buildings[selectedIndex].GeometricImage));
                Floors[] floor = buildings[selectedIndex].BuildingFloors;
                int floor_length = floor != null ? floor.Length : 0;
                DG_Floors_DT.Rows.Clear();
                for (int i = 0; i < floor_length; i++)
                {
                    string[] row = new string[] { floor[i].FloorNumber, floor[i].FireHydrantsNumber, floor[i].PowderExtinguishersNumber,
                    Convert.ToString(floor[i].PowderExtinguishersWeight),
                    floor[i].CarbonDioxideExtinguishersNumbers,
                    Convert.ToString(floor[i].CarbonDioxideExtinguishersWeight),
                    floor[0].PowderExtinguishersNumber,
                    Convert.ToString(floor[0].PowderExtinguishersWeight)};

                    DG_Floors_DT.Rows.Add(row);
                }
                Images[] img = buildings[selectedIndex].BuildingImageCollection;
                int img_length = img != null ? img.Length : 0;
                if (img_length > 0)
                {
                    TB_CompanyImage_DT.Image = img[0].Image==null? System.Drawing.Image.FromStream(new System.IO.MemoryStream(imagenu)) : System.Drawing.Image.FromStream(new System.IO.MemoryStream(img[0].Image));
                    if (img_length > 1)
                    {
                        TB_CompanyGeometeryImage_DT.Image = img[1].Image==null? System.Drawing.Image.FromStream(new System.IO.MemoryStream(imagenu)) : System.Drawing.Image.FromStream(new System.IO.MemoryStream(img[1].Image));
                        if (img_length > 2)
                            PB_ExitPathWayImage_DT.Image = img[2].Image==null? System.Drawing.Image.FromStream(new System.IO.MemoryStream(imagenu)) : System.Drawing.Image.FromStream(new System.IO.MemoryStream(img[2].Image));
                    }
                }
            }
        }
        #endregion

        #region Company

        private void DeleteCompany_Click_1(object sender, EventArgs e)
        {
            bool flag=server_Class_Obj.Delete_Company(Selected_Company_ID);
            if(flag ==true)
                statusfeild.Text +="\t Company Deleted Successfully";
        }
        private void EditCompany_Click_1(object sender, EventArgs e)
        {
             Company c1 = new Company();

            c1.Name = TB_companyName_DT.Text;
            c1.Address = TB_Address_DT.Text;
            c1.LandlinePhoneNumber = TB_LandlinePhone_DT.Text;
            c1.ElectricalPanelLocation = TB_ElectricalPanelLocation_DT.Text;
            c1.OxygenTrapLocation = TB_OxygenTrapLocation_DT.Text;
            c1.GasTrapLocation = TB_GasTrapLocation_DT.Text;
            c1.RightCompanyName = RightCompany_UC.TB_DComapnyName_UC_ELe.Text;
            c1.RightCompanyBusiness = RightCompany_UC.TB_DCompanyBuisness_UC_ELe.Text;
            c1.LeftCompanyName = LeftCompany_UC.TB_DComapnyName_UC_ELe.Text;
            c1.LeftCompanyBusiness = LeftCompany_UC.TB_DCompanyBuisness_UC_ELe.Text;
            c1.FrontCompanyName = FrontCompany_UC.TB_DComapnyName_UC_ELe.Text;
            c1.FrontCompanyBusiness = FrontCompany_UC.TB_DCompanyBuisness_UC_ELe.Text;
            c1.BackCompanyName = BackCompany_UC.TB_DComapnyName_UC_ELe.Text;
            c1.BackCompanyBusiness = BackCompany_UC.TB_DCompanyBuisness_UC_ELe.Text;
            c1.FrontFireMediator = FrontCompany_UC.TB_DCompanyMediator_UC_ELe.Text;
            c1.BackFireMediator = BackCompany_UC.TB_DCompanyMediator_UC_ELe.Text;
            c1.RightFireMediator = RightCompany_UC.TB_DCompanyMediator_UC_ELe.Text;
            c1.LeftFireMediator = LeftCompany_UC.TB_DCompanyMediator_UC_ELe.Text;
            c1.BuildingsNumber = Convert.ToInt32(TB_BuildingsNumber_DT.Text);
            c1.FrontCompanyImage = FrontCompany_UC.TB_DCompanyImage_UC_ELe.Image==null? imagenu : ImageToByteArray(FrontCompany_UC.TB_DCompanyImage_UC_ELe.Image);
            c1.BackCompanyImage = BackCompany_UC.TB_DCompanyImage_UC_ELe.Image==null? imagenu : ImageToByteArray(BackCompany_UC.TB_DCompanyImage_UC_ELe.Image);
            c1.RightCompanyImage = RightCompany_UC.TB_DCompanyImage_UC_ELe.Image==null? imagenu : ImageToByteArray(RightCompany_UC.TB_DCompanyImage_UC_ELe.Image);
            c1.LeftCompanyImage = LeftCompany_UC.TB_DCompanyImage_UC_ELe.Image==null ? imagenu : ImageToByteArray(LeftCompany_UC.TB_DCompanyImage_UC_ELe.Image);
            c1.UserID = Selected_User_ID;
            c1.FrontCompanyImageURL = FrontCompany_UC.TB_DCompanyImageURL_UC_ELe.Text;
            c1.BackCompanyImageURL = BackCompany_UC.TB_DCompanyImageURL_UC_ELe.Text;
            c1.RightCompanyImageURL = RightCompany_UC.TB_DCompanyImageURL_UC_ELe.Text;
            c1.LeftCompanyImageURL = LeftCompany_UC.TB_DCompanyImageURL_UC_ELe.Text;
            c1.Longitude = 0;
            c1.Latitude = 0;
            c1.CompanyBuisiness = TB_CompanyBuisiness_DT.Text;
            c1.StockVolume = TB_Stock_DT.Text == ""? 0 : Convert.ToInt32(TB_Stock_DT.Text);
            c1.StockType = TB_StockType_DT.Text;
            c1.CompanyID = Selected_Company_ID;
            c1.CompanyImage = TB_CompanyImage_DT.Image == null ? imagenu : ImageToByteArray(TB_CompanyImage_DT.Image);
            c1.CompanyGeometeryImage = TB_CompanyGeometeryImage_DT.Image == null ? imagenu : ImageToByteArray(TB_CompanyGeometeryImage_DT.Image);
            bool flag= server_Class_Obj.Update_Company(c1);
            if(flag==true)
                statusfeild.Text +="\t Company updated Successfully";

            Buildings building = new Buildings();
            building.BuildingNumber = BuildingNumber.Text==""? -1 : Convert.ToInt32(BuildingNumber.Text);
            building.FloorsNumber = floorNumbers.Text==""? -1 : Convert.ToInt32(floorNumbers.Text);
            building.CompanyID = Selected_Company_ID;
            building.MainWaterTankCapacity = floorNumbers.Text == ""? -1 : Convert.ToInt32(mainTankCapacity.Text);
            building.GeometricImage = BuildingGeoPic_DT.Image==null? imagenu : ImageToByteArray(BuildingGeoPic_DT.Image);
            building.GeometricImageURL = GeoPicURL.Text==""? "" : GeoPicURL.Text;
            flag = server_Class_Obj.Update_Building(building);
            if (flag == true)
            {
                statusfeild.Text +="\t Building updated Successfully";

                Floors floor = new Floors();
                floor.FloorNumber = DG_Floors_DT.CurrentRow.Cells[0].Value == null ? "" : (string)DG_Floors_DT.CurrentRow.Cells[0].Value;
                floor.FireHydrantsNumber = DG_Floors_DT.CurrentRow.Cells[1].Value == null ? "" : (string)DG_Floors_DT.CurrentRow.Cells[1].Value;
                floor.PowderExtinguishersNumber = DG_Floors_DT.CurrentRow.Cells[2].Value == null ? "" : (string)DG_Floors_DT.CurrentRow.Cells[2].Value;
                floor.PowderExtinguishersWeight = DG_Floors_DT.CurrentRow.Cells[3].Value == null ? -1 : Convert.ToInt32(DG_Floors_DT.CurrentRow.Cells[3].Value);
                floor.CarbonDioxideExtinguishersNumbers = DG_Floors_DT.CurrentRow.Cells[4].Value == null ? "" : (string)DG_Floors_DT.CurrentRow.Cells[4].Value;
                floor.CarbonDioxideExtinguishersWeight = DG_Floors_DT.CurrentRow.Cells[5].Value == null ? -1 : Convert.ToInt32(DG_Floors_DT.CurrentRow.Cells[5].Value);
                floor.FoamExtinguishersNumbers = DG_Floors_DT.CurrentRow.Cells[6].Value == null ? "" : (string)DG_Floors_DT.CurrentRow.Cells[6].Value;
                floor.FoamExtinguishersWeight = DG_Floors_DT.CurrentRow.Cells[7].Value == null ? -1 : Convert.ToInt32(DG_Floors_DT.CurrentRow.Cells[7].Value);
                floor.BuildingID = building.BuildingID;
                flag = server_Class_Obj.Update_Floor(floor);
                if (flag == true)
                    statusfeild.Text +="\n Floor updated Successfully";

                DangerousPlaces place = new DangerousPlaces();
                place.Location = DangerouseLocation.Text == null ? "" : DangerouseLocation.Text;
                place.HazardousSubstance = HazardousSubstance.Text == null ? "" : HazardousSubstance.Text;
                place.FireMediator = FireMediator.Text == null ? "" : FireMediator.Text;
                place.Image = imagenu;
                place.ImageURL = "";
                place.CompanyID = c1.CompanyID;
                flag = server_Class_Obj.Update_DangerousePlaces(place);
                if (flag == true)
                    statusfeild.Text +="\t DangerousPlace updated Successfully";

                ExitPathways exitPathWay = new ExitPathways();
                exitPathWay.BuildingID = building.BuildingID;
                exitPathWay.PathwaysImage = PB_ExitPathWayImage_DT.Image == null ? imagenu : ImageToByteArray(PB_ExitPathWayImage_DT.Image);
                exitPathWay.PathwaysImageURL = "";
                exitPathWay.Description = "";
                flag = server_Class_Obj.Update_ExitPathways(exitPathWay);
                if (flag == true)
                    statusfeild.Text +="\t ExitPathway updated Successfully";
            }
              
        }
        #endregion

        #region clear

        private void clearData_Click_1(object sender, EventArgs e)
        {
            BuildingNumber.Clear();
            floorNumbers.Clear();
            mainTankCapacity.Clear();
            GeoPicURL.Clear();
            BuildingGeoPic_DT.Image = null;
            DG_Floors_DT.Rows.Clear();
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
        private void button2_Click_1(object sender, EventArgs e)
        {
            FF_pumps pump = new FF_pumps();
            pump.Additional_info = pumpInfo.Text==null?"": pumpInfo.Text;
            pump.Address = pumpAddress.Text==null?"": pumpAddress.Text;
            pump.Area = pumpArea.Text==null?"": pumpArea.Text;
            pump.PumpNumber = PumpNumber.Text==null?"": PumpNumber.Text;
            pump.Status = Status.Text==null?"": Status.Text;
            pump.Signs = pumpSign.Text == null?"": pumpSign.Text;
            pump.Sector = pumpSector.Text==null?"": pumpSector.Text;
            pump.PumpType = PumpType.Text==null?"": PumpType.Text;
            pump.UserID = Selected_User_ID;
            FF_pumps p=server_Class_Obj.Add_FFPump(pump);
            if(p!=null)
                richTextBox1.Text="\n FF_pumps Added Successfully";

        }

        private void EditPUMP_Click_1(object sender, EventArgs e)
        {
            pump = new FF_pumps();
            pump.Additional_info = pumpInfo.Text==null?"": pumpInfo.Text;
            pump.Address = pumpAddress.Text==null?"": pumpAddress.Text;
            pump.Area = pumpArea.Text==null?"": pumpArea.Text;
            pump.PumpNumber = PumpNumber.Text==null?"": PumpNumber.Text;
            pump.Status = Status.Text==null?"": Status.Text;
            pump.Signs = pumpSign.Text==null?"": pumpSign.Text;
            pump.Sector = pumpSector.Text==null?"": pumpSector.Text;
            pump.PumpType = PumpType.Text==null?"": PumpType.Text;
            pump.UserID = Selected_User_ID;
            bool flag=server_Class_Obj.Update_FFPump(pump);
            if (flag ==true)
                richTextBox1.Text="\n FF_pumps Updated Successfully";
        }
        private void DG_Pumps_DT_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            PumpNumber.Text = (string)DG_Pumps_DT.CurrentRow.Cells[0].Value==null?"": (string)DG_Pumps_DT.CurrentRow.Cells[0].Value;
            pumpArea.Text = (string)DG_Pumps_DT.CurrentRow.Cells[1].Value==null?"": (string)DG_Pumps_DT.CurrentRow.Cells[1].Value;
            pumpSector.Text = (string)DG_Pumps_DT.CurrentRow.Cells[2].Value==null?"": (string)DG_Pumps_DT.CurrentRow.Cells[2].Value;
            PumpType.Text = (string)DG_Pumps_DT.CurrentRow.Cells[3].Value==null?"": (string)DG_Pumps_DT.CurrentRow.Cells[3].Value;
            Status.Text = (string)DG_Pumps_DT.CurrentRow.Cells[4].Value == null?"": (string)DG_Pumps_DT.CurrentRow.Cells[4].Value;
            pumpAddress.Text = (string)DG_Pumps_DT.CurrentRow.Cells[5].Value==null?"": (string)DG_Pumps_DT.CurrentRow.Cells[5].Value;
            pumpSign.Text = (string)DG_Pumps_DT.CurrentRow.Cells[6].Value==null?"": (string)DG_Pumps_DT.CurrentRow.Cells[6].Value;
            pumpInfo.Text = (string)DG_Pumps_DT.CurrentRow.Cells[7].Value==null?"": (string)DG_Pumps_DT.CurrentRow.Cells[7].Value;

        }

        private void DeletePump_Click(object sender, EventArgs e)
        {
            PumpNumber.Text = "";
            pumpArea.Text = "";
            pumpSector.Text = "";
            PumpType.Text = "";
            Status.Text = "";
            pumpAddress.Text = "";
            pumpSign.Text = "";
            pumpInfo.Text = "";
            bool flag = server_Class_Obj.Delete_FF_pumps(pump.FF_pumpsID);
            if (flag == true)
                richTextBox1.Text="\n FF_pumps Deleted Successfully";
        }
        #endregion

        #region Account

        private void AddAccount_Click(object sender, EventArgs e)
        {
            try
            {
                Users user = new Users();
                user.Username = accountName.Text;
                user.AdminMode = "";
                if (string.Compare(accountPassword.Text, ReAccountPassword.Text) == 0)
                {
                    user.Password = accountPassword.Text;
                    user.Info = AccountInfo.Text;
                    Users newUser = server_Class_Obj.Add_Account(user);
                    Users_Admin User = new Users_Admin();
                    User.Admin_ID = Selected_User_ID!=0? Selected_User_ID:LoginAccount.UserID;
                    User.User_ID = newUser.UserID;
                    User.Info = Selected_User_ID + " over " + newUser.UserID;
                    Users_Admin flag = server_Class_Obj.Add_Users_Admin(User);
                    if (flag != null)
                        AccountStatus.Text = "\n Account Added Successfully";
                }
                else
                {
                    AccountStatus.Text = "\n Password not matched";
                }

                
            }
            catch (Exception exception1)
            {
                Auditing.Error(exception1.Message);
            }
        }

        private void EditUser_Click(object sender, EventArgs e)
        {
            try
            {
                Users user = new Users();
                user.Username = accountName.Text;
                user.AdminMode = "";
                if (string.Compare(accountPassword.Text, ReAccountPassword.Text) == 0)
                {
                    user.Password = accountPassword.Text;
                }
                user.UserID = Selected_User_ID;
                user.Info = AccountInfo.Text;
                
               bool flag= server_Class_Obj.Update_Account(user);
                if(flag==true)
                    AccountStatus.Text="\n Account Updated Successfully";

            }
            catch (Exception exception1)
            {
                Auditing.Error(exception1.Message);
            }
        }

        private void DeleteUser_Click(object sender, EventArgs e)
        {
            bool flag = server_Class_Obj.Delete_Account(Selected_User_ID);
            if (flag == true)
                AccountStatus.Text="\n Account Deleted Successfully";
        }




        #endregion

        private void CB_Stations_DT_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            ComboBox cmb = (ComboBox)sender;
            int selectedIndex = cmb.SelectedIndex;
            if (points.Length >= selectedIndex)
            {
                TB_sector_DT.Text = Convert.ToString(points[selectedIndex].Sector);
                TB_area_DT.Text = Convert.ToString(points[selectedIndex].AreaName);
                TB_street_DT.Text = Convert.ToString(points[selectedIndex].Street);
                TB_signs_DT.Text = points[selectedIndex].Signs;
                TB_Additional_info_DT.Text = points[selectedIndex].Additional_info;
                TB_OfficersNumber_DT.Text = points[selectedIndex].OfficersNumber;
                TB_SoliderNumber_DT.Text = points[selectedIndex].SoliderNumber;
                TB_CarsNumber_DT.Text = points[selectedIndex].CarsNumber;
                TB_Equipments_DT.Text = points[selectedIndex].Equipments;
                ff_ManPowerGrid.Rows.Clear();
                int Station_ManPower_length = points[selectedIndex].Station_ManPower!= null ? points[selectedIndex].Station_ManPower.Length : 0;
                for (int i = 0; i < Station_ManPower_length; i++)
                {
                    string[] row = new string[] { points[selectedIndex].Station_ManPower[i].OfficerName,
                    points[selectedIndex].Station_ManPower[i].Sector, points[selectedIndex].Station_ManPower[i].Area,
                    points[selectedIndex].Station_ManPower[i].Rank,
                    points[selectedIndex].Station_ManPower[i].Job,
                    points[selectedIndex].Station_ManPower[i].Additional_info };

                    ff_ManPowerGrid.Rows.Add(row);
                }
               
            }
        }


        private delegate void Update_Incident_Reporting_trv_Companies_Delegate();

        public void load_all_treeviews_cycle()
        {
            try
            {
                while (true)
                {
                    
                    Update_Incident_Reporting_trv_Companies();
                    Thread.Sleep(20000);
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

                        //Add Main User Companies node
                        treeView3.Nodes[0].Nodes.Add("Companies");

                        //Add Main User Users node
                        treeView3.Nodes[0].Nodes.Add("Users");


                    }
                    else
                    {
                        treeView3.Nodes[0].Tag = LoginAccount;
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
                                treeView3.Nodes[0].Nodes[0].Nodes[treeView3.Nodes[0].Nodes[0].Nodes.Count - 1].Name ="Company";
                                treeView3.Nodes[0].Nodes[0].Nodes[treeView3.Nodes[0].Nodes[0].Nodes.Count - 1].Checked = true;
                            }
                        }
                    }
                    #endregion



                    Update_User_Users_Companies_TV(LoginAccount.Users_of_Users, treeView3.Nodes[0].Nodes[1]);
                    First_Time_Loading_User_Data_Flag = false;


                    treeView3.EndUpdate();
                }
            }
            catch (Exception ex)
            {
                Auditing.Error(ex.Message);
            }
        }

        private void Update_User_Users_Companies_TV(Users[] users, TreeNode node_obj)
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
                                        }
                                        else
                                        {
                                            node_obj.Nodes[uc].Nodes[0].Nodes.Add(users[uc].User_Companies[ucm].Name.ToString());
                                            node_obj.Nodes[uc].Nodes[0].Nodes[node_obj.Nodes[uc].Nodes[0].Nodes.Count - 1].Tag = users[uc].User_Companies[ucm];
                                            
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

                                node_obj.Nodes[node_obj.Nodes.Count - 1].Nodes.Add("Companies");
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
                                        }
                                        else
                                        {
                                            node_obj.Nodes[uc].Nodes[0].Nodes.Add(users[uc].User_Companies[ucm].Name.ToString());
                                            node_obj.Nodes[uc].Nodes[0].Nodes[node_obj.Nodes[uc].Nodes[0].Nodes.Count - 1].Tag = users[uc].User_Companies[ucm];

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
                                node_obj.Nodes[node_obj.Nodes.Count - 1].Nodes.Add("Users");
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

                            node_obj.Nodes[node_obj.Nodes.Count - 1].Nodes.Add("Companies");
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
                            node_obj.Nodes[node_obj.Nodes.Count - 1].Nodes.Add("Users");
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
            if (e.Node.Name == "Company")
            {
                Company C1 = (Company)e.Node.Tag;
                Selected_Company_ID = Convert.ToInt32(C1.CompanyID);
                Users U1 = (Users)e.Node.Parent.Parent.Tag;
                Selected_User_ID = Convert.ToInt32(U1.UserID);
                Load_Data(Selected_Company_ID);
            }
            else if (e.Node.Name == "User")
            {
                Users SelectedUser = (Users)e.Node.Tag;
                Selected_User_ID = Convert.ToInt32(SelectedUser.UserID);
                Users U1 = server_Class_Obj.Select_User(Selected_User_ID);
                accountName.Text = U1.Username == null ? "" : U1.Username;
                AccountInfo.Text = U1.Info;
                accountPassword.Clear();
                ReAccountPassword.Clear();
                for (int i = 0; i < U1.Password.Length; i++)
                {
                    accountPassword.Text += "*";
                    ReAccountPassword.Text += "*";
                }
            }
        }
    }

    internal class ComboboxItem
    {
        public string Text { get; set; }
        public object Value { get; set; }
    }
}
