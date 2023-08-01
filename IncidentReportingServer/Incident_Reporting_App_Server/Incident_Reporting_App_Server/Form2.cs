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
        byte[] imagenu = null;
        Users U1;
        Users LoginAccount;
        //Company[] companies;
        Buildings[] buildings;
        List<Buildings> Newbuildings = new List<Buildings>();
        Dictionary<int, Floors> NewFloors = new Dictionary<int, Floors>();
        Managers[] managers;
        DangerousPlaces[] places;
        FFstations[] points;
        FFstations station;
        FF_ManPower men;
        Floors[] floors;
        ExitPathways[] exitPathWays;
        Company selectedCompany;
        FF_pumps[] pumps;
        FF_ManPower[] man;
        Company c1;
        int buildingCount = 0;
        int Selected_User_ID;
        int Selected_Company_ID;
        public Form2()
        {
            InitializeComponent();
            pictureBox5.MouseWheel += PictureBox5_MouseWheel;

            #region load acounts treeview
            LoginAccount = server_Class_Obj.Select_Account();
            treeView3.Nodes[0].Tag = LoginAccount.UserID;
            treeView3.Nodes[0].Text = LoginAccount.Username;
            treeView3.Nodes[0].Name = "User";
            
            Company[] LoginCompany = LoginAccount.User_Companies;
            int LoginCompany_length = LoginCompany != null ? LoginCompany.Length : 0;
            for (int i = 0; i < LoginCompany_length; i++)
            {
                TreeNode company_node = new TreeNode();
                company_node.Text = LoginCompany[i].Name == null ? "" : LoginCompany[i].Name;
                company_node.Tag = LoginCompany[i].CompanyID;
                company_node.Name = "Company";
                treeView3.Nodes[0].Nodes.Add(company_node);
            }

            Users[] Users = LoginAccount.Users_of_Users;
            int Users_length = Users != null ? Users.Length : 0;
            if (Users_length != 0)
            {
                treeView3.BeginUpdate();
                for (int i = 0; i < Users_length; i++)
                {
                    TreeNode user_node = new TreeNode();
                    user_node.Text = Users[i].Username==null?"": Users[i].Username;
                    user_node.Tag = Users[i].UserID;
                    user_node.Name = "User";
                    treeView3.Nodes[0].Nodes.Add(user_node);
                    Company[] companies = Users[i].User_Companies;
                    int Companies_length = companies != null ? companies.Length : 0;
                    if (Companies_length != 0)
                    {
                        for (int j = 0; j < Companies_length; j++)
                        {
                            TreeNode company_node = new TreeNode();
                            company_node.Text = companies[j].Name == null?"": companies[j].Name;
                            company_node.Tag = companies[j].CompanyID;
                            company_node.Name = "Company";
                            treeView3.Nodes[0].Nodes[LoginCompany_length+i].Nodes.Add(company_node);
                        }
                        Users[] UsersOfUser = Users[i].Users_of_Users;
                        int UsersOfUser_length = UsersOfUser != null ? UsersOfUser.Length : 0;
                        for (int k = 0; k < UsersOfUser_length; k++)
                        {
                            TreeNode moreUsers_node = new TreeNode();
                            moreUsers_node.Text = UsersOfUser[k].Username==null?"": UsersOfUser[k].Username;
                            moreUsers_node.Tag = Users[k].UserID;
                            moreUsers_node.Name = "User";
                            treeView3.Nodes[0].Nodes[LoginCompany_length+i].Nodes.Add(moreUsers_node);
                        }
                    }
                }
                treeView3.EndUpdate();
            }
            else
            {
                treeView3.Nodes.Clear();
                return;
            }
            Thread Main_Thread = new Thread(load_all_treeviews_cycle);
            Main_Thread.Start();
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
            FrontCompany_UC.TB_DCompanyImage_UC_ELe.Image = System.Drawing.Image.FromStream(new System.IO.MemoryStream(selectedCompany.FrontCompanyImage));

            BackCompany_UC.TB_DCompanyBuisness_UC_ELe.Text = selectedCompany.BackCompanyBusiness;
            BackCompany_UC.TB_DComapnyName_UC_ELe.Text = selectedCompany.BackCompanyName;
            BackCompany_UC.TB_DCompanyMediator_UC_ELe.Text = selectedCompany.BackFireMediator;
            BackCompany_UC.TB_DCompanyImageURL_UC_ELe.Text = selectedCompany.BackCompanyImageURL;
            BackCompany_UC.TB_DCompanyImage_UC_ELe.Image = System.Drawing.Image.FromStream(new System.IO.MemoryStream(selectedCompany.BackCompanyImage));

            RightCompany_UC.TB_DCompanyBuisness_UC_ELe.Text = selectedCompany.RightCompanyBusiness;
            RightCompany_UC.TB_DComapnyName_UC_ELe.Text = selectedCompany.RightCompanyName;
            RightCompany_UC.TB_DCompanyMediator_UC_ELe.Text = selectedCompany.RightFireMediator;
            RightCompany_UC.TB_DCompanyImageURL_UC_ELe.Text = selectedCompany.RightCompanyImageURL;
            RightCompany_UC.TB_DCompanyImage_UC_ELe.Image = System.Drawing.Image.FromStream(new System.IO.MemoryStream(selectedCompany.RightCompanyImage));

            LeftCompany_UC.TB_DCompanyBuisness_UC_ELe.Text = selectedCompany.LeftCompanyBusiness;
            LeftCompany_UC.TB_DComapnyName_UC_ELe.Text = selectedCompany.LeftCompanyName;
            LeftCompany_UC.TB_DCompanyMediator_UC_ELe.Text = selectedCompany.LeftFireMediator;
            LeftCompany_UC.TB_DCompanyImageURL_UC_ELe.Text = selectedCompany.LeftCompanyImageURL;
            LeftCompany_UC.TB_DCompanyImage_UC_ELe.Image = System.Drawing.Image.FromStream(new System.IO.MemoryStream(selectedCompany.RightCompanyImage));

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
            Managers.Items.Clear();
            for (int i = 0; i < managers_length; i++)
            {
                Managers.Items.Add(managers[i].Name);
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
        private void Managers_SelectedIndexChanged(object sender, EventArgs e)
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
        private void Dangerous_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cmb = (ComboBox)sender;
            int selectedIndex = cmb.SelectedIndex;
            HazardousSubstance.Text = places[selectedIndex].HazardousSubstance;
            DangerouseLocation.Text = places[selectedIndex].Location;
            FireMediator.Text = places[selectedIndex].FireMediator;
        }
        #endregion

        #region Station
        private void CB_Stations_DT_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cmb = (ComboBox)sender;
            int selectedIndex = cmb.SelectedIndex;
            TB_sector_DT.Text = points[selectedIndex].Sector;
            TB_area_DT.Text = points[selectedIndex].AreaName;
            TB_street_DT.Text = points[selectedIndex].Street;
            TB_signs_DT.Text = points[selectedIndex].Signs;
            TB_Additional_info_DT.Text = points[selectedIndex].Additional_info;
            TB_OfficersNumber_DT.Text = points[selectedIndex].OfficersNumber;
            TB_SoliderNumber_DT.Text = points[selectedIndex].SoliderNumber;
            TB_CarsNumber_DT.Text = points[selectedIndex].CarsNumber;
            TB_Equipments_DT.Text = points[selectedIndex].Equipments;
            man = points[selectedIndex].Station_ManPower;
            int man_length = man != null ? man.Length : 0;
            for (int i = 0; i < man_length; i++)
            {
                string[] row = new string[] { man[i].OfficerName, man[i].Sector, man[i].Area,
                    man[i].Rank,man[i].Job,man[i].Additional_info };
                ff_ManPowerGrid.Rows.Add(row);
            }
        }

        private void EditStationsManPower_Click(object sender, EventArgs e)
        {
            station.CarsNumber = TB_CarsNumber_DT.Text;
            station.SoliderNumber = TB_SoliderNumber_DT.Text;
            station.Sector = TB_sector_DT.Text;
            station.Signs = TB_signs_DT.Text;
            station.Street = TB_street_DT.Text;
            station.ZoneNumber = TB_area_DT.Text;
            station.Additional_info = TB_Additional_info_DT.Text;
            station.UserID = Selected_User_ID;
            men = new FF_ManPower();
            men.OfficerName = (string)ff_ManPowerGrid.CurrentRow.Cells[0].Value;
            men.Sector = (string)ff_ManPowerGrid.CurrentRow.Cells[1].Value;
            men.Area = (string)ff_ManPowerGrid.CurrentRow.Cells[2].Value;
            men.Rank = (string)ff_ManPowerGrid.CurrentRow.Cells[3].Value;
            men.Job = (string)ff_ManPowerGrid.CurrentRow.Cells[4].Value;
            men.Additional_info = (string)ff_ManPowerGrid.CurrentRow.Cells[5].Value;
            server_Class_Obj.Update_FFstations(station);

        }

        private void AddStationsManPower_Click(object sender, EventArgs e)
        {
            station.CarsNumber = TB_CarsNumber_DT.Text;
            station.SoliderNumber = TB_SoliderNumber_DT.Text;
            station.Sector = TB_sector_DT.Text;
            station.Signs = TB_signs_DT.Text;
            station.Street = TB_street_DT.Text;
            station.ZoneNumber = TB_area_DT.Text;
            station.Additional_info = TB_Additional_info_DT.Text;
            station.UserID = Selected_User_ID;
            men = new FF_ManPower();
            men.OfficerName = (string)ff_ManPowerGrid.CurrentRow.Cells[0].Value;
            men.Sector = (string)ff_ManPowerGrid.CurrentRow.Cells[1].Value;
            men.Area = (string)ff_ManPowerGrid.CurrentRow.Cells[2].Value;
            men.Rank = (string)ff_ManPowerGrid.CurrentRow.Cells[3].Value;
            men.Job = (string)ff_ManPowerGrid.CurrentRow.Cells[4].Value;
            men.Additional_info = (string)ff_ManPowerGrid.CurrentRow.Cells[5].Value;

            server_Class_Obj.Add_FFstations_FF_ManPower(station);
          
        }


        private void DeleteStationsManPower_Click(object sender, EventArgs e)
        {
            server_Class_Obj.Add_FFstations_FF_ManPower(station);
        }

        #endregion

        #region treeview 
        public delegate void load_trv_delegate();

        public void load_all_treeviews_cycle()
        {
            try
            {
                while (true)
                {
                    Thread.Sleep(100000);
                    load_trv_User_Tab();
                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Auditing.Error(ex.Message);
            }
        }

        /// <summary>
        /// update the users-Company treeview 
        /// </summary>
        
        public void load_trv_User_Tab()
       {
            try
            {
                if (treeView3.InvokeRequired)
                {
                    treeView3.Invoke(new load_trv_delegate(load_trv_User_Tab));
                }
                else
                {
                    treeView3.BeginUpdate();
                    Users LoginAccount = server_Class_Obj.Select_Account();
                    
                    treeView3.Nodes[0].Tag = LoginAccount.UserID;
                    treeView3.Nodes[0].Text = LoginAccount.Username;
                    treeView3.Nodes[0].Name = "User";

                    Company[] LoginCompany = LoginAccount.User_Companies;

                    int LoginCompany_length = LoginCompany != null ? LoginCompany.Length : 0;
                    for (int i = 1; i < LoginCompany_length; i++)
                    {
                        TreeNode company_node = new TreeNode();
                        treeView3.Nodes[0].Nodes[i].Text = LoginCompany[i].Name == null ? "" : LoginCompany[i].Name;
                        treeView3.Nodes[0].Nodes[i].Tag = LoginCompany[i].CompanyID;
                        treeView3.Nodes[0].Nodes[i].Name = "Company";
                    }

                    Users[] Users = LoginAccount.Users_of_Users;
                    int Users_length = Users != null ? Users.Length : 0;
                    if (Users_length != 0)
                    {
                        for (int i = 0; i < Users_length; i++)
                        {
                                treeView3.Nodes[0].Nodes[LoginCompany_length+i].Tag = Users[i].UserID;
                                treeView3.Nodes[0].Nodes[LoginCompany_length+i].Text = Users[i].Username==null?"": Users[i].Username;
                                treeView3.Nodes[0].Nodes[LoginCompany_length+i].Name = "User";
                                break;
                        }
                        for (int i = 0; i < Users_length; i++)
                        {
                            Company[] companies = Users[i].User_Companies;
                            int Companies_length = companies != null ? companies.Length : 0;
                            if (Companies_length != 0)
                            {
                               
                                for (int j = 0; j < Companies_length; j++)
                                {
                                    treeView3.Nodes[0].Nodes[LoginCompany_length+i].Nodes[j].Tag = companies[j].CompanyID;
                                    treeView3.Nodes[0].Nodes[LoginCompany_length+i].Nodes[j].Text = companies[j].Name==null?"": companies[j].Name;
                                    treeView3.Nodes[0].Nodes[LoginCompany_length+i].Nodes[j].Name = "Company";
                                }

                                Users[] UsersOfUser = Users[i].Users_of_Users;
                                int UsersOfUser_length = UsersOfUser != null ? UsersOfUser.Length : 0;
                                for (int k = 0; k < UsersOfUser_length; k++)
                                {
                                    treeView3.Nodes[0].Nodes[LoginCompany_length+i].Nodes[k + Companies_length].Tag = UsersOfUser[k].UserID;
                                    treeView3.Nodes[0].Nodes[LoginCompany_length+i].Nodes[k + Companies_length].Text = UsersOfUser[k].Username==null?"": UsersOfUser[k].Username;
                                    treeView3.Nodes[0].Nodes[LoginCompany_length+i].Nodes[k + Companies_length].Name = "User";
                                }
                            }
                        }
                        treeView3.EndUpdate();
                    }
                    else
                    {
                        treeView3.Nodes.Clear();
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                Auditing.Error(ex.Message);
            }
        }

        private void treeView3_AfterSelect_1(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Name == "Company")
            {
                Selected_Company_ID = Convert.ToInt32(e.Node.Tag);
                Selected_User_ID = Convert.ToInt32(e.Node.Parent.Tag);
                Load_Data(Selected_Company_ID);
            }
            else if (e.Node.Name == "User")
            {
                Selected_User_ID = Convert.ToInt32(e.Node.Tag);
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

        #endregion

        #region Building

        private void AddBuildings_Click(object sender, EventArgs e)
        {
            buildingCount++;
            Buildings building = new Buildings();
            building.BuildingNumber = Convert.ToInt32(BuildingNumber.Text);
            building.FloorsNumber = Convert.ToInt32(floorNumbers.Text);
            building.MainWaterTankCapacity = Convert.ToInt32(mainTankCapacity.Text);
            building.GeometricImage = ImageToByteArray(BuildingGeoPic_DT.Image);
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
                NewFloors.Add(buildingCount, floor);
            }
        }
        private void SaveAddedBuildings_Click(object sender, EventArgs e)
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
            c1.FrontCompanyImage = ImageToByteArray(FrontCompany_UC.TB_DCompanyImage_UC_ELe.Image);
            c1.BackCompanyImage = ImageToByteArray(BackCompany_UC.TB_DCompanyImage_UC_ELe.Image);
            c1.RightCompanyImage = ImageToByteArray(RightCompany_UC.TB_DCompanyImage_UC_ELe.Image);
            c1.LeftCompanyImage = ImageToByteArray(LeftCompany_UC.TB_DCompanyImage_UC_ELe.Image);
            c1.UserID = Selected_User_ID;
            c1.FrontCompanyImageURL = FrontCompany_UC.TB_DCompanyImageURL_UC_ELe.Text;
            c1.BackCompanyImageURL = BackCompany_UC.TB_DCompanyImageURL_UC_ELe.Text;
            c1.RightCompanyImageURL = RightCompany_UC.TB_DCompanyImageURL_UC_ELe.Text;
            c1.LeftCompanyImageURL = LeftCompany_UC.TB_DCompanyImageURL_UC_ELe.Text;
            c1.Longitude = 0;
            c1.Latitude = 0;
            c1.CompanyBuisiness = TB_CompanyBuisiness_DT.Text;
            c1.StockVolume = Convert.ToInt32(TB_Stock_DT.Text);
            c1.StockType = TB_StockType_DT.Text;
            c1.CompanyImage = ImageToByteArray(TB_CompanyImage_DT.Image);
            c1.CompanyGeometeryImage = ImageToByteArray(TB_CompanyGeometeryImage_DT.Image);
            c1 = server_Class_Obj.Add_Company(c1);

            for (int i = 0; i < Newbuildings.Count; i++)
            {
                Newbuildings[i].CompanyID = c1.CompanyID;
                Buildings B1 = server_Class_Obj.Add_Building(Newbuildings[i]);
                foreach (var kvp in NewFloors)
                {
                    if (kvp.Key == i)
                    {
                        NewFloors[kvp.Key].BuildingID = B1.BuildingID;
                        server_Class_Obj.Add_Floors(NewFloors[i]);
                    }
                }


                ExitPathways exitPathWay = new ExitPathways();
                exitPathWay.BuildingID = B1.BuildingID;
                exitPathWay.PathwaysImage = ImageToByteArray(PB_ExitPathWayImage_DT.Image);
                exitPathWay.PathwaysImageURL = "";
                exitPathWay.Description = "";
            }
            DangerousPlaces place = new DangerousPlaces();
            place.Location = DangerouseLocation.Text;
            place.HazardousSubstance = HazardousSubstance.Text;
            place.FireMediator = FireMediator.Text;
            place.Image = imagenu;
            place.ImageURL = "";
            place.CompanyID = c1.CompanyID;
        }

        private void deleteBuildingList_Click(object sender, EventArgs e)
        {
            Newbuildings.Clear();
        }

        private void buildingCB_SelectedIndexChanged_1(object sender, EventArgs e)
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
                    PB_ExitPathWayImage_DT.Image = System.Drawing.Image.FromStream(new System.IO.MemoryStream(buildings[selectedIndex].BuildingExitPaths[0].PathwaysImage));
                BuildingGeoPic_DT.Image = System.Drawing.Image.FromStream(new System.IO.MemoryStream(buildings[selectedIndex].GeometricImage));
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
                    TB_CompanyImage_DT.Image = System.Drawing.Image.FromStream(new System.IO.MemoryStream(img[0].Image));
                    if (img_length > 1)
                    {
                        TB_CompanyGeometeryImage_DT.Image = System.Drawing.Image.FromStream(new System.IO.MemoryStream(img[1].Image));
                        if (img_length > 2)
                            PB_ExitPathWayImage_DT.Image = System.Drawing.Image.FromStream(new System.IO.MemoryStream(img[2].Image));
                    }
                }
            }
        }
        #endregion

        #region Company

        private void DeleteCompany_Click(object sender, EventArgs e)
        {
            server_Class_Obj.Delete_Company(Selected_Company_ID);
        }
        private void EditCompany_Click(object sender, EventArgs e)
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
            c1.FrontCompanyImage = ImageToByteArray(FrontCompany_UC.TB_DCompanyImage_UC_ELe.Image);
            c1.BackCompanyImage = ImageToByteArray(BackCompany_UC.TB_DCompanyImage_UC_ELe.Image);
            c1.RightCompanyImage = ImageToByteArray(RightCompany_UC.TB_DCompanyImage_UC_ELe.Image);
            c1.LeftCompanyImage = ImageToByteArray(LeftCompany_UC.TB_DCompanyImage_UC_ELe.Image);
            c1.UserID = Selected_User_ID;
            c1.FrontCompanyImageURL = FrontCompany_UC.TB_DCompanyImageURL_UC_ELe.Text;
            c1.BackCompanyImageURL = BackCompany_UC.TB_DCompanyImageURL_UC_ELe.Text;
            c1.RightCompanyImageURL = RightCompany_UC.TB_DCompanyImageURL_UC_ELe.Text;
            c1.LeftCompanyImageURL = LeftCompany_UC.TB_DCompanyImageURL_UC_ELe.Text;
            c1.Longitude = 0;
            c1.Latitude = 0;
            c1.CompanyBuisiness = TB_CompanyBuisiness_DT.Text;
            c1.StockVolume = Convert.ToInt32(TB_Stock_DT.Text);
            c1.StockType = TB_StockType_DT.Text;
            c1.CompanyImage = ImageToByteArray(TB_CompanyImage_DT.Image);
            c1.CompanyGeometeryImage = ImageToByteArray(TB_CompanyGeometeryImage_DT.Image);
            c1 = server_Class_Obj.Update_Company(c1);

            Buildings building = new Buildings();
            building.BuildingNumber = Convert.ToInt32(BuildingNumber.Text);
            building.FloorsNumber = Convert.ToInt32(floorNumbers.Text);
            building.CompanyID = c1.CompanyID;
            building.MainWaterTankCapacity = Convert.ToInt32(mainTankCapacity.Text);
            building.GeometricImage = ImageToByteArray(BuildingGeoPic_DT.Image);
            building.GeometricImageURL = GeoPicURL.Text;
            building = server_Class_Obj.Update_Building(building);

            Floors floor = new Floors();
            floor.FloorNumber = (string)DG_Floors_DT.CurrentRow.Cells[0].Value;
            floor.FireHydrantsNumber = (string)DG_Floors_DT.CurrentRow.Cells[1].Value;
            floor.PowderExtinguishersNumber = (string)DG_Floors_DT.CurrentRow.Cells[2].Value;
            floor.PowderExtinguishersWeight = Convert.ToInt32(DG_Floors_DT.CurrentRow.Cells[3].Value);
            floor.CarbonDioxideExtinguishersNumbers = (string)DG_Floors_DT.CurrentRow.Cells[4].Value;
            floor.CarbonDioxideExtinguishersWeight = Convert.ToInt32(DG_Floors_DT.CurrentRow.Cells[5].Value);
            floor.FoamExtinguishersNumbers = (string)DG_Floors_DT.CurrentRow.Cells[6].Value;
            floor.FoamExtinguishersWeight = Convert.ToInt32(DG_Floors_DT.CurrentRow.Cells[7].Value);
            floor.BuildingID = building.BuildingID;
            floor = server_Class_Obj.Update_Floor(floor);

            DangerousPlaces place = new DangerousPlaces();
            place.Location = DangerouseLocation.Text;
            place.HazardousSubstance = HazardousSubstance.Text;
            place.FireMediator = FireMediator.Text;
            place.Image = imagenu;
            place.ImageURL = "";
            place.CompanyID = c1.CompanyID;
            place = server_Class_Obj.Update_DangerousePlaces(place);

            ExitPathways exitPathWay = new ExitPathways();
            exitPathWay.BuildingID = building.BuildingID;
            exitPathWay.PathwaysImage = ImageToByteArray(PB_ExitPathWayImage_DT.Image);
            exitPathWay.PathwaysImageURL = "";
            exitPathWay.Description = "";
            exitPathWay = server_Class_Obj.Update_ExitPathways(exitPathWay);
        }
        #endregion

        #region clear

        private void clearData_Click(object sender, EventArgs e)
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
        private void BuildingGeoPic_DT_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            string filePath = openFileDialog1.FileName;
            BuildingGeoPic_DT.Image = Image.FromFile(filePath);
        }

        private void TB_CompanyImage_DT_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            string filePath = openFileDialog1.FileName;
            TB_CompanyImage_DT.Image = Image.FromFile(filePath);
        }

        private void TB_CompanyGeometeryImage_DT_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            string filePath = openFileDialog1.FileName;
            TB_CompanyGeometeryImage_DT.Image = Image.FromFile(filePath);
        }

        private void PB_ExitPathWayImage_DT_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            string filePath = openFileDialog1.FileName;
            PB_ExitPathWayImage_DT.Image = Image.FromFile(filePath);
        }
        #endregion

        #region Pump
        private void button2_Click(object sender, EventArgs e)
        {
            FF_pumps pump = new FF_pumps();
            pump.Additional_info = pumpInfo.Text;
            pump.Address = pumpAddress.Text;
            pump.Area = pumpArea.Text;
            pump.PumpNumber = PumpNumber.Text;
            pump.Status = Status.Text;
            pump.Signs = pumpSign.Text;
            pump.Sector = pumpSector.Text;
            pump.PumpType = PumpType.Text;
            pump.UserID = Selected_User_ID;
            server_Class_Obj.Add_FFPump(pump);
        }

        private void EditPUMP_Click(object sender, EventArgs e)
        {
            FF_pumps pump = new FF_pumps();
            pump.Additional_info = pumpInfo.Text;
            pump.Address = pumpAddress.Text;
            pump.Area = pumpArea.Text;
            pump.PumpNumber = PumpNumber.Text;
            pump.Status = Status.Text;
            pump.Signs = pumpSign.Text;
            pump.Sector = pumpSector.Text;
            pump.PumpType = PumpType.Text;
            pump.UserID = Selected_User_ID;
            server_Class_Obj.Add_FFPump(pump);
        }
        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            PumpNumber.Text = (string)DG_Pumps_DT.CurrentRow.Cells[0].Value;
            pumpArea.Text = (string)DG_Pumps_DT.CurrentRow.Cells[1].Value;
            pumpSector.Text = (string)DG_Pumps_DT.CurrentRow.Cells[2].Value;
            PumpType.Text = (string)DG_Pumps_DT.CurrentRow.Cells[3].Value;
            Status.Text = (string)DG_Pumps_DT.CurrentRow.Cells[4].Value;
            pumpAddress.Text = (string)DG_Pumps_DT.CurrentRow.Cells[5].Value;
            pumpSign.Text = (string)DG_Pumps_DT.CurrentRow.Cells[6].Value;
            pumpInfo.Text = (string)DG_Pumps_DT.CurrentRow.Cells[7].Value;

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
                }

                user.Info = AccountInfo.Text;
                server_Class_Obj.Add_Account(user);
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
                server_Class_Obj.Update_Account(user);
            }
            catch (Exception exception1)
            {
                Auditing.Error(exception1.Message);
            }
        }

        private void DeleteUser_Click(object sender, EventArgs e)
        {
            server_Class_Obj.Delete_Account(Selected_User_ID);
        }


        #endregion

        
    }

    internal class ComboboxItem
    {
        public string Text { get; set; }
        public object Value { get; set; }
    }
}
