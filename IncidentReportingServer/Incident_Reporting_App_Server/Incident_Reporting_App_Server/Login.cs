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
    public partial class Login : Form
    {
        ServerClass server_Class_Obj = new ServerClass();
        private bool form_status;
        public Login()
        {
            InitializeComponent();
            
        }
        public bool workdone { get; set; }
        public delegate void txt_log_Update_Delegate(string text);



        #region loading bar
        public delegate void Change_loading_bar_percentage(int value);
        public void change_loadingbar_percentage(int value)
        {
            try
            {
                if (prog_bar.InvokeRequired)
                {
                    prog_bar.Invoke(new Change_loading_bar_percentage(change_loadingbar_percentage), new object[] { value });
                }
                else
                {
                    prog_bar.Value = value;
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
                prg_Value = prg_Value >= 10 ? 0 : prg_Value;
                change_loadingbar_percentage(prg_Value);

                
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
                if (prog_bar.InvokeRequired)
                {
                    prog_bar.Invoke(new start_delegate(startserver));
                }
                else
                {
                    workdone = server_Class_Obj.Start_Server(Login_txt_Username.Text, Login_txt_Password.Text);
                    if (workdone)
                    {
                        Main f2 = new Main();
                        f2.Show();
                    }
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
                while (!workdone)
                {
                    startserver();
                    Thread.Sleep(100);
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

        private void Header_pic_Close_Click(object sender, EventArgs e)
        {
            try
            {
                this.Close();
            }
            catch (Exception ex)
            {
                Auditing.Error(ex.Message);
            }
        }

        private void Maxmized_btn_Click(object sender, EventArgs e)
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

        private void button2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
