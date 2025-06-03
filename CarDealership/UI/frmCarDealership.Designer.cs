namespace CarDealership
{
    partial class frmCarDealership
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.cboFilterType = new System.Windows.Forms.ComboBox();
            this.cboFilter = new System.Windows.Forms.ComboBox();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnFilter = new System.Windows.Forms.Button();
            this.btnViewAll = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.mtsAccount = new System.Windows.Forms.ToolStripMenuItem();
            this.msiAddCar = new System.Windows.Forms.ToolStripMenuItem();
            this.msiDeleteCar = new System.Windows.Forms.ToolStripMenuItem();
            this.msiBookmarks = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.msiLogin = new System.Windows.Forms.ToolStripMenuItem();
            this.msiProfile = new System.Windows.Forms.ToolStripMenuItem();
            this.msiLogout = new System.Windows.Forms.ToolStripMenuItem();
            this.mtsHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.mtsNotImplemented = new System.Windows.Forms.ToolStripMenuItem();
            this.lvListings = new System.Windows.Forms.ListView();
            this.clmMake = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmModel = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmYear = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmColor = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmPrice = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.trackMin = new System.Windows.Forms.TrackBar();
            this.lblFilterMin = new System.Windows.Forms.Label();
            this.lblFilterMax = new System.Windows.Forms.Label();
            this.trackMax = new System.Windows.Forms.TrackBar();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackMin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackMax)).BeginInit();
            this.SuspendLayout();
            // 
            // cboFilterType
            // 
            this.cboFilterType.FormattingEnabled = true;
            this.cboFilterType.Items.AddRange(new object[] {
            "Make",
            "Color",
            "Age",
            "Price"});
            this.cboFilterType.Location = new System.Drawing.Point(497, 27);
            this.cboFilterType.Name = "cboFilterType";
            this.cboFilterType.Size = new System.Drawing.Size(126, 21);
            this.cboFilterType.TabIndex = 1;
            this.cboFilterType.Text = "Filter By...";
            this.cboFilterType.SelectedIndexChanged += new System.EventHandler(this.cboFilterType_SelectedIndexChanged);
            // 
            // cboFilter
            // 
            this.cboFilter.Enabled = false;
            this.cboFilter.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboFilter.FormattingEnabled = true;
            this.cboFilter.Location = new System.Drawing.Point(497, 59);
            this.cboFilter.Name = "cboFilter";
            this.cboFilter.Size = new System.Drawing.Size(126, 21);
            this.cboFilter.TabIndex = 2;
            this.cboFilter.SelectedIndexChanged += new System.EventHandler(this.cboFilter_SelectedIndexChanged);
            // 
            // btnExit
            // 
            this.btnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnExit.Location = new System.Drawing.Point(548, 256);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 23);
            this.btnExit.TabIndex = 6;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnFilter
            // 
            this.btnFilter.Enabled = false;
            this.btnFilter.Location = new System.Drawing.Point(548, 195);
            this.btnFilter.Name = "btnFilter";
            this.btnFilter.Size = new System.Drawing.Size(75, 23);
            this.btnFilter.TabIndex = 3;
            this.btnFilter.Text = "Filter";
            this.btnFilter.UseVisualStyleBackColor = true;
            this.btnFilter.Click += new System.EventHandler(this.btnFilter_Click);
            // 
            // btnViewAll
            // 
            this.btnViewAll.Location = new System.Drawing.Point(548, 226);
            this.btnViewAll.Name = "btnViewAll";
            this.btnViewAll.Size = new System.Drawing.Size(75, 23);
            this.btnViewAll.TabIndex = 0;
            this.btnViewAll.Text = "View All";
            this.btnViewAll.UseVisualStyleBackColor = true;
            this.btnViewAll.Click += new System.EventHandler(this.btnViewAll_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mtsAccount,
            this.mtsHelp});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(635, 24);
            this.menuStrip1.TabIndex = 11;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // mtsAccount
            // 
            this.mtsAccount.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.msiAddCar,
            this.msiDeleteCar,
            this.msiBookmarks,
            this.toolStripSeparator1,
            this.msiLogin,
            this.msiProfile,
            this.msiLogout});
            this.mtsAccount.Name = "mtsAccount";
            this.mtsAccount.Size = new System.Drawing.Size(64, 20);
            this.mtsAccount.Text = "Account";
            // 
            // msiAddCar
            // 
            this.msiAddCar.Name = "msiAddCar";
            this.msiAddCar.Size = new System.Drawing.Size(137, 22);
            this.msiAddCar.Text = "Add Car...";
            this.msiAddCar.Click += new System.EventHandler(this.msiAddCar_Click);
            // 
            // msiDeleteCar
            // 
            this.msiDeleteCar.Name = "msiDeleteCar";
            this.msiDeleteCar.Size = new System.Drawing.Size(137, 22);
            this.msiDeleteCar.Text = "Delete Car...";
            this.msiDeleteCar.Click += new System.EventHandler(this.msiDeleteCar_Click);
            // 
            // msiBookmarks
            // 
            this.msiBookmarks.Name = "msiBookmarks";
            this.msiBookmarks.Size = new System.Drawing.Size(137, 22);
            this.msiBookmarks.Text = "Bookmarks";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(134, 6);
            // 
            // msiLogin
            // 
            this.msiLogin.Name = "msiLogin";
            this.msiLogin.Size = new System.Drawing.Size(137, 22);
            this.msiLogin.Text = "Login...";
            this.msiLogin.Click += new System.EventHandler(this.msiLogin_Click);
            // 
            // msiProfile
            // 
            this.msiProfile.Name = "msiProfile";
            this.msiProfile.Size = new System.Drawing.Size(137, 22);
            this.msiProfile.Text = "Profile...";
            this.msiProfile.Click += new System.EventHandler(this.msiProfile_Click);
            // 
            // msiLogout
            // 
            this.msiLogout.Name = "msiLogout";
            this.msiLogout.Size = new System.Drawing.Size(137, 22);
            this.msiLogout.Text = "Logout";
            this.msiLogout.Click += new System.EventHandler(this.msiLogout_Click);
            // 
            // mtsHelp
            // 
            this.mtsHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mtsNotImplemented});
            this.mtsHelp.Name = "mtsHelp";
            this.mtsHelp.Size = new System.Drawing.Size(44, 20);
            this.mtsHelp.Text = "Help";
            // 
            // mtsNotImplemented
            // 
            this.mtsNotImplemented.Name = "mtsNotImplemented";
            this.mtsNotImplemented.Size = new System.Drawing.Size(177, 22);
            this.mtsNotImplemented.Text = "Not Implemented...";
            // 
            // lvListings
            // 
            this.lvListings.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clmMake,
            this.clmModel,
            this.clmYear,
            this.clmColor,
            this.clmPrice,
            this.clmDate});
            this.lvListings.FullRowSelect = true;
            this.lvListings.HideSelection = false;
            this.lvListings.Location = new System.Drawing.Point(12, 27);
            this.lvListings.MultiSelect = false;
            this.lvListings.Name = "lvListings";
            this.lvListings.Size = new System.Drawing.Size(479, 252);
            this.lvListings.TabIndex = 12;
            this.lvListings.UseCompatibleStateImageBehavior = false;
            this.lvListings.View = System.Windows.Forms.View.Details;
            // 
            // clmMake
            // 
            this.clmMake.Tag = "Make";
            this.clmMake.Text = "Make";
            this.clmMake.Width = 74;
            // 
            // clmModel
            // 
            this.clmModel.Tag = "Model";
            this.clmModel.Text = "Model";
            this.clmModel.Width = 89;
            // 
            // clmYear
            // 
            this.clmYear.Tag = "Year";
            this.clmYear.Text = "Year";
            // 
            // clmColor
            // 
            this.clmColor.Tag = "Color";
            this.clmColor.Text = "Color";
            // 
            // clmPrice
            // 
            this.clmPrice.Tag = "Price";
            this.clmPrice.Text = "Price";
            this.clmPrice.Width = 77;
            // 
            // clmDate
            // 
            this.clmDate.Tag = "Date";
            this.clmDate.Text = "Date Added";
            this.clmDate.Width = 115;
            // 
            // trackMin
            // 
            this.trackMin.Enabled = false;
            this.trackMin.Location = new System.Drawing.Point(498, 90);
            this.trackMin.Maximum = 20;
            this.trackMin.Name = "trackMin";
            this.trackMin.Size = new System.Drawing.Size(125, 45);
            this.trackMin.TabIndex = 13;
            this.trackMin.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trackMin.Scroll += new System.EventHandler(this.trackMin_Scroll);
            // 
            // lblFilterMin
            // 
            this.lblFilterMin.AutoSize = true;
            this.lblFilterMin.Location = new System.Drawing.Point(498, 121);
            this.lblFilterMin.Name = "lblFilterMin";
            this.lblFilterMin.Size = new System.Drawing.Size(67, 13);
            this.lblFilterMin.TabIndex = 14;
            this.lblFilterMin.Text = "{Filter}: {min}";
            this.lblFilterMin.Visible = false;
            // 
            // lblFilterMax
            // 
            this.lblFilterMax.AutoSize = true;
            this.lblFilterMax.Location = new System.Drawing.Point(497, 172);
            this.lblFilterMax.Name = "lblFilterMax";
            this.lblFilterMax.Size = new System.Drawing.Size(70, 13);
            this.lblFilterMax.TabIndex = 16;
            this.lblFilterMax.Text = "{Filter}: {max}";
            this.lblFilterMax.Visible = false;
            // 
            // trackMax
            // 
            this.trackMax.Enabled = false;
            this.trackMax.Location = new System.Drawing.Point(497, 141);
            this.trackMax.Maximum = 20;
            this.trackMax.Name = "trackMax";
            this.trackMax.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.trackMax.Size = new System.Drawing.Size(125, 45);
            this.trackMax.TabIndex = 15;
            this.trackMax.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trackMax.Value = 20;
            this.trackMax.Scroll += new System.EventHandler(this.trackMax_Scroll);
            // 
            // frmCarDealership
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnExit;
            this.ClientSize = new System.Drawing.Size(635, 291);
            this.Controls.Add(this.lblFilterMax);
            this.Controls.Add(this.trackMax);
            this.Controls.Add(this.lblFilterMin);
            this.Controls.Add(this.trackMin);
            this.Controls.Add(this.lvListings);
            this.Controls.Add(this.btnFilter);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.cboFilter);
            this.Controls.Add(this.cboFilterType);
            this.Controls.Add(this.btnViewAll);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmCarDealership";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Car Dealership";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmCarDealership_FormClosed);
            this.Load += new System.EventHandler(this.frmCarDealership_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackMin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackMax)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ComboBox cboFilterType;
        private System.Windows.Forms.ComboBox cboFilter;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnFilter;
        private System.Windows.Forms.Button btnViewAll;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mtsAccount;
        private System.Windows.Forms.ToolStripMenuItem msiAddCar;
        private System.Windows.Forms.ToolStripMenuItem msiDeleteCar;
        private System.Windows.Forms.ToolStripMenuItem msiBookmarks;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem msiLogin;
        private System.Windows.Forms.ToolStripMenuItem msiLogout;
        private System.Windows.Forms.ToolStripMenuItem mtsHelp;
        private System.Windows.Forms.ToolStripMenuItem mtsNotImplemented;
        private System.Windows.Forms.ToolStripMenuItem msiProfile;
        private System.Windows.Forms.ListView lvListings;
        private System.Windows.Forms.ColumnHeader clmMake;
        private System.Windows.Forms.ColumnHeader clmModel;
        private System.Windows.Forms.ColumnHeader clmYear;
        private System.Windows.Forms.ColumnHeader clmColor;
        private System.Windows.Forms.ColumnHeader clmPrice;
        private System.Windows.Forms.ColumnHeader clmDate;
        private System.Windows.Forms.TrackBar trackMin;
        private System.Windows.Forms.Label lblFilterMin;
        private System.Windows.Forms.Label lblFilterMax;
        private System.Windows.Forms.TrackBar trackMax;
    }
}

