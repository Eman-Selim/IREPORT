﻿namespace Incident_Reporting_App_Server
{
    partial class UserControl1
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserControl1));
            this.TB_DCompanyImage_UC = new C1.Win.C1Input.C1PictureBox();
            this.CompanyName = new System.Windows.Forms.Label();
            this.CompanyBusiness = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.TB_DComapnyName_UC = new System.Windows.Forms.RichTextBox();
            this.TB_DCompanyBuisness_UC = new System.Windows.Forms.RichTextBox();
            this.TB_DCompanyMediator_UC = new System.Windows.Forms.RichTextBox();
            this.TB_DCompanyImageURL_UC = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.TB_DCompanyImage_UC)).BeginInit();
            this.SuspendLayout();
            // 
            // TB_DCompanyImage_UC
            // 
            this.TB_DCompanyImage_UC.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.TB_DCompanyImage_UC.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("TB_DCompanyImage_UC.BackgroundImage")));
            this.TB_DCompanyImage_UC.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.TB_DCompanyImage_UC.Location = new System.Drawing.Point(5, 52);
            this.TB_DCompanyImage_UC.Name = "TB_DCompanyImage_UC";
            this.TB_DCompanyImage_UC.Size = new System.Drawing.Size(276, 193);
            this.TB_DCompanyImage_UC.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.TB_DCompanyImage_UC.TabIndex = 0;
            this.TB_DCompanyImage_UC.TabStop = false;
            this.TB_DCompanyImage_UC.Click += new System.EventHandler(this.c1PictureBox1_Click);
            // 
            // CompanyName
            // 
            this.CompanyName.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.CompanyName.AutoSize = true;
            this.CompanyName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CompanyName.ForeColor = System.Drawing.Color.White;
            this.CompanyName.Location = new System.Drawing.Point(436, 7);
            this.CompanyName.Name = "CompanyName";
            this.CompanyName.Size = new System.Drawing.Size(65, 20);
            this.CompanyName.TabIndex = 1;
            this.CompanyName.Text = "إسم المنشأة";
            this.CompanyName.Click += new System.EventHandler(this.CompanyName_Click);
            // 
            // CompanyBusiness
            // 
            this.CompanyBusiness.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.CompanyBusiness.AutoSize = true;
            this.CompanyBusiness.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CompanyBusiness.ForeColor = System.Drawing.Color.White;
            this.CompanyBusiness.Location = new System.Drawing.Point(430, 75);
            this.CompanyBusiness.Name = "CompanyBusiness";
            this.CompanyBusiness.Size = new System.Drawing.Size(73, 20);
            this.CompanyBusiness.TabIndex = 3;
            this.CompanyBusiness.Text = "نشاط المنشأة";
            this.CompanyBusiness.Click += new System.EventHandler(this.CompanyBusiness_Click);
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(408, 143);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 20);
            this.label2.TabIndex = 8;
            this.label2.Text = "الوسيط الإطفائي";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(100, 17);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 20);
            this.label3.TabIndex = 9;
            this.label3.Text = "صورة المنشأة";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // TB_DComapnyName_UC
            // 
            this.TB_DComapnyName_UC.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.TB_DComapnyName_UC.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(73)))), ((int)(((byte)(105)))));
            this.TB_DComapnyName_UC.ForeColor = System.Drawing.Color.White;
            this.TB_DComapnyName_UC.Location = new System.Drawing.Point(296, 33);
            this.TB_DComapnyName_UC.MaxLength = 300;
            this.TB_DComapnyName_UC.Name = "TB_DComapnyName_UC";
            this.TB_DComapnyName_UC.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.TB_DComapnyName_UC.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.TB_DComapnyName_UC.Size = new System.Drawing.Size(195, 29);
            this.TB_DComapnyName_UC.TabIndex = 18;
            this.TB_DComapnyName_UC.Text = "";
            this.TB_DComapnyName_UC.TextChanged += new System.EventHandler(this.richTextBox1_TextChanged);
            // 
            // TB_DCompanyBuisness_UC
            // 
            this.TB_DCompanyBuisness_UC.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.TB_DCompanyBuisness_UC.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(73)))), ((int)(((byte)(105)))));
            this.TB_DCompanyBuisness_UC.ForeColor = System.Drawing.Color.White;
            this.TB_DCompanyBuisness_UC.Location = new System.Drawing.Point(296, 100);
            this.TB_DCompanyBuisness_UC.MaxLength = 300;
            this.TB_DCompanyBuisness_UC.Name = "TB_DCompanyBuisness_UC";
            this.TB_DCompanyBuisness_UC.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.TB_DCompanyBuisness_UC.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.TB_DCompanyBuisness_UC.Size = new System.Drawing.Size(195, 31);
            this.TB_DCompanyBuisness_UC.TabIndex = 19;
            this.TB_DCompanyBuisness_UC.Text = "";
            this.TB_DCompanyBuisness_UC.TextChanged += new System.EventHandler(this.richTextBox2_TextChanged);
            // 
            // TB_DCompanyMediator_UC
            // 
            this.TB_DCompanyMediator_UC.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.TB_DCompanyMediator_UC.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(73)))), ((int)(((byte)(105)))));
            this.TB_DCompanyMediator_UC.ForeColor = System.Drawing.Color.White;
            this.TB_DCompanyMediator_UC.Location = new System.Drawing.Point(296, 176);
            this.TB_DCompanyMediator_UC.MaxLength = 300;
            this.TB_DCompanyMediator_UC.Name = "TB_DCompanyMediator_UC";
            this.TB_DCompanyMediator_UC.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.TB_DCompanyMediator_UC.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.TB_DCompanyMediator_UC.Size = new System.Drawing.Size(195, 31);
            this.TB_DCompanyMediator_UC.TabIndex = 20;
            this.TB_DCompanyMediator_UC.Text = "";
            this.TB_DCompanyMediator_UC.TextChanged += new System.EventHandler(this.richTextBox3_TextChanged);
            // 
            // TB_DCompanyImageURL_UC
            // 
            this.TB_DCompanyImageURL_UC.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.TB_DCompanyImageURL_UC.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(73)))), ((int)(((byte)(105)))));
            this.TB_DCompanyImageURL_UC.ForeColor = System.Drawing.Color.White;
            this.TB_DCompanyImageURL_UC.Location = new System.Drawing.Point(296, 251);
            this.TB_DCompanyImageURL_UC.MaxLength = 300;
            this.TB_DCompanyImageURL_UC.Name = "TB_DCompanyImageURL_UC";
            this.TB_DCompanyImageURL_UC.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.TB_DCompanyImageURL_UC.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.TB_DCompanyImageURL_UC.Size = new System.Drawing.Size(195, 29);
            this.TB_DCompanyImageURL_UC.TabIndex = 21;
            this.TB_DCompanyImageURL_UC.Text = "";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(391, 225);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 20);
            this.label1.TabIndex = 22;
            this.label1.Text = "رابط صورة المنشأة";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // UserControl1
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(73)))), ((int)(((byte)(105)))));
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TB_DCompanyImageURL_UC);
            this.Controls.Add(this.TB_DCompanyMediator_UC);
            this.Controls.Add(this.TB_DCompanyBuisness_UC);
            this.Controls.Add(this.TB_DComapnyName_UC);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.CompanyBusiness);
            this.Controls.Add(this.CompanyName);
            this.Controls.Add(this.TB_DCompanyImage_UC);
            this.Name = "UserControl1";
            this.Size = new System.Drawing.Size(507, 300);
            ((System.ComponentModel.ISupportInitialize)(this.TB_DCompanyImage_UC)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private C1.Win.C1Input.C1PictureBox TB_DCompanyImage_UC;
        private System.Windows.Forms.Label CompanyName;
        private System.Windows.Forms.Label CompanyBusiness;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RichTextBox TB_DComapnyName_UC;
        private System.Windows.Forms.RichTextBox TB_DCompanyBuisness_UC;
        private System.Windows.Forms.RichTextBox TB_DCompanyMediator_UC;
        private System.Windows.Forms.RichTextBox TB_DCompanyImageURL_UC;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;

        #region PROPERTIES
        public System.Windows.Forms.RichTextBox TB_DComapnyName_UC_ELe
        {
            get
            {
                return TB_DComapnyName_UC;
            }
        }

        public System.Windows.Forms.RichTextBox TB_DCompanyBuisness_UC_ELe
        {
            get
            {
                return TB_DCompanyBuisness_UC;
            }
        }

        public System.Windows.Forms.RichTextBox TB_DCompanyMediator_UC_ELe
        {
            get
            {
                return TB_DCompanyMediator_UC;
            }
        }

        public C1.Win.C1Input.C1PictureBox TB_DCompanyImage_UC_ELe
        {
            get
            {
                return TB_DCompanyImage_UC;
            }
        }

        public System.Windows.Forms.RichTextBox TB_DCompanyImageURL_UC_ELe
        {
            get
            {
                return TB_DCompanyImageURL_UC;
            }
        }

        #endregion

    }
}
