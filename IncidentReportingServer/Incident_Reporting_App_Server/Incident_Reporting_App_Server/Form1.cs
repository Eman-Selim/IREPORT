using Incident_Reporting_App_Server.Code;
using SDS_Remote_Control_Application_Server.Code;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Incident_Reporting_App_Server
{
    public partial class Form1 : Form
    {
        ServerClass server_Class_Obj = new ServerClass();
        public Form1()
        {
            InitializeComponent();
            server_Class_Obj.log_Handler += log_Handler;
            
        }
        public bool workdone { get; set; }
        public delegate void txt_log_Update_Delegate(string text);

        public void log_Handler(string text)
        {
            try
            {
                if (true)
                {
                    txt_log_Update_Delegate method = new txt_log_Update_Delegate(this.log_Handler);
                    this.txt_log.Invoke(method, new object[] { text });
                }
                else
                {
                    //this.txt_log.AppendText("- " + text + "\r\n");
                }
            }
            catch (Exception exception1)
            {
                Auditing.Error(exception1.Message);
            }
        }

        private void panel3_MouseHover(object sender, EventArgs e)
        {
            panel3.BackgroundImage = Properties.Resources.Fire_FighterSH1;

        }

        private void panel3_MouseLeave(object sender, EventArgs e)
        {
            panel3.BackgroundImage = Properties.Resources.Fire_FighterN1;

        }

        private void panel3_Click(object sender, EventArgs e)
        {
            //tableLayoutPanel2.BackgroundImage = Properties.Resources.Fire_Fighter_S_H;
        }

        private void panel1_MouseHover(object sender, EventArgs e)
        {
            panel2.BackgroundImage = Properties.Resources.BuildingSH1;
        }

        private void panel1_MouseLeave(object sender, EventArgs e)
        {
            panel2.BackgroundImage = Properties.Resources.BuildingN1;
        }

        private void panel2_MouseHover(object sender, EventArgs e)
        {
            panel5.BackgroundImage = Properties.Resources.Phone_BookSH1;
        }

        private void panel2_MouseLeave(object sender, EventArgs e)
        {
            panel5.BackgroundImage = Properties.Resources.Phone_BookN1;
        }

        private void panel4_MouseHover(object sender, EventArgs e)
        {
            panel4.BackgroundImage = Properties.Resources.UsersSH1;
        }

        private void panel4_MouseLeave(object sender, EventArgs e)
        {
            panel4.BackgroundImage = Properties.Resources.UsersN1;
        }

        #region loading bar
        public delegate void Change_loading_bar_percentage(int value);
        public void change_loadingbar_percentage(int value)
        {
            try
            {
                if (txt_log.InvokeRequired)
                {
                    txt_log.Invoke(new Change_loading_bar_percentage(change_loadingbar_percentage), new object[] { value });
                }
                else
                {
                    txt_log.Value = value;
                    //txt_log.Update();
                    //if(workdone)
                    //{
                    //    foreach (Form f in Application.OpenForms)
                    //        if (f.Name == "Form1")
                    //            f.Close();
                    //}
                }
            }
            catch (Exception ex)
            {
                Auditing.Error(ex.Message);
            }
        }
        public void loading_bar_progress_cycle()
        {
            int prg_Value = 0;
            while (workdone == false)
            {
                prg_Value += 1;
                change_loadingbar_percentage(prg_Value);

                prg_Value = prg_Value >= 10 ? 0 : prg_Value;
                Thread.Sleep(100);
            }
            change_loadingbar_percentage(10);
            
        }


        #endregion

        #region start
        public delegate void start_delegate();
        public void startserver()
        {
            try
            {
                if (txt_log.InvokeRequired)
                {
                    txt_log.Invoke(new start_delegate(startserver));
                }
                else
                {
                    workdone = server_Class_Obj.Start_Server(Login_txt_Username.Text, Login_txt_Password.Text);
                }
            }
            catch (Exception ex)
            {
                Auditing.Error(ex.Message);
            }
        }
        public void start()
        {
            try
            {
                if (!workdone)
                {
                    startserver();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Auditing.Error(ex.Message);
            }
        }

        #endregion
        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                
                workdone = false;
                Thread loading_operation_thread = new Thread(loading_bar_progress_cycle);
                loading_operation_thread.Start();

                Thread start_thread = new Thread(start);
                start_thread.Start();
            }
            catch (Exception exception1)
            {
                Auditing.Error(exception1.Message);
            }
        }
    }
}
