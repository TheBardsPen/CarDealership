namespace CarDealership
{
    partial class frmProfile
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmProfile));
            this.lblUsername = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Label();
            this.tabsProfile = new System.Windows.Forms.TabControl();
            this.tabListings = new System.Windows.Forms.TabPage();
            this.lvListings = new System.Windows.Forms.ListView();
            this.clmMake = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmModel = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmYear = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmColor = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmPrice = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabBookmarks = new System.Windows.Forms.TabPage();
            this.lvBookmarks = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabsProfile.SuspendLayout();
            this.tabListings.SuspendLayout();
            this.tabBookmarks.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.Font = new System.Drawing.Font("Javanese Text", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsername.Location = new System.Drawing.Point(26, 25);
            this.lblUsername.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(196, 73);
            this.lblUsername.TabIndex = 0;
            this.lblUsername.Text = "{username}";
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Location = new System.Drawing.Point(860, 469);
            this.btnClose.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(150, 44);
            this.btnClose.TabIndex = 4;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.AutoSize = true;
            this.btnDelete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.ForeColor = System.Drawing.Color.Red;
            this.btnDelete.Location = new System.Drawing.Point(32, 479);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(160, 26);
            this.btnDelete.TabIndex = 5;
            this.btnDelete.Text = "Delete Account";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // tabsProfile
            // 
            this.tabsProfile.Controls.Add(this.tabListings);
            this.tabsProfile.Controls.Add(this.tabBookmarks);
            this.tabsProfile.Location = new System.Drawing.Point(24, 100);
            this.tabsProfile.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.tabsProfile.Name = "tabsProfile";
            this.tabsProfile.SelectedIndex = 0;
            this.tabsProfile.Size = new System.Drawing.Size(986, 354);
            this.tabsProfile.TabIndex = 6;
            // 
            // tabListings
            // 
            this.tabListings.Controls.Add(this.lvListings);
            this.tabListings.Location = new System.Drawing.Point(8, 39);
            this.tabListings.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.tabListings.Name = "tabListings";
            this.tabListings.Padding = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.tabListings.Size = new System.Drawing.Size(970, 307);
            this.tabListings.TabIndex = 0;
            this.tabListings.Text = "Listings";
            this.tabListings.UseVisualStyleBackColor = true;
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
            this.lvListings.Location = new System.Drawing.Point(6, 6);
            this.lvListings.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.lvListings.MultiSelect = false;
            this.lvListings.Name = "lvListings";
            this.lvListings.Size = new System.Drawing.Size(954, 289);
            this.lvListings.TabIndex = 13;
            this.lvListings.UseCompatibleStateImageBehavior = false;
            this.lvListings.View = System.Windows.Forms.View.Details;
            this.lvListings.DoubleClick += new System.EventHandler(this.lvListings_DoubleClick);
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
            // tabBookmarks
            // 
            this.tabBookmarks.Controls.Add(this.lvBookmarks);
            this.tabBookmarks.Location = new System.Drawing.Point(8, 39);
            this.tabBookmarks.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.tabBookmarks.Name = "tabBookmarks";
            this.tabBookmarks.Padding = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.tabBookmarks.Size = new System.Drawing.Size(970, 307);
            this.tabBookmarks.TabIndex = 1;
            this.tabBookmarks.Text = "Bookmarks";
            this.tabBookmarks.UseVisualStyleBackColor = true;
            // 
            // lvBookmarks
            // 
            this.lvBookmarks.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6});
            this.lvBookmarks.FullRowSelect = true;
            this.lvBookmarks.HideSelection = false;
            this.lvBookmarks.Location = new System.Drawing.Point(6, 6);
            this.lvBookmarks.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.lvBookmarks.MultiSelect = false;
            this.lvBookmarks.Name = "lvBookmarks";
            this.lvBookmarks.Size = new System.Drawing.Size(954, 289);
            this.lvBookmarks.TabIndex = 14;
            this.lvBookmarks.UseCompatibleStateImageBehavior = false;
            this.lvBookmarks.View = System.Windows.Forms.View.Details;
            this.lvBookmarks.DoubleClick += new System.EventHandler(this.lvBookmarks_DoubleClick);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Tag = "Make";
            this.columnHeader1.Text = "Make";
            this.columnHeader1.Width = 74;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Tag = "Model";
            this.columnHeader2.Text = "Model";
            this.columnHeader2.Width = 89;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Tag = "Year";
            this.columnHeader3.Text = "Year";
            // 
            // columnHeader4
            // 
            this.columnHeader4.Tag = "Color";
            this.columnHeader4.Text = "Color";
            // 
            // columnHeader5
            // 
            this.columnHeader5.Tag = "Price";
            this.columnHeader5.Text = "Price";
            this.columnHeader5.Width = 77;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Tag = "Date";
            this.columnHeader6.Text = "Date Added";
            this.columnHeader6.Width = 115;
            // 
            // frmProfile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(1036, 537);
            this.Controls.Add(this.tabsProfile);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lblUsername);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.Name = "frmProfile";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Profile";
            this.Load += new System.EventHandler(this.frmProfile_Load);
            this.tabsProfile.ResumeLayout(false);
            this.tabListings.ResumeLayout(false);
            this.tabBookmarks.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label btnDelete;
        private System.Windows.Forms.TabControl tabsProfile;
        private System.Windows.Forms.TabPage tabListings;
        private System.Windows.Forms.TabPage tabBookmarks;
        private System.Windows.Forms.ListView lvListings;
        private System.Windows.Forms.ColumnHeader clmMake;
        private System.Windows.Forms.ColumnHeader clmModel;
        private System.Windows.Forms.ColumnHeader clmYear;
        private System.Windows.Forms.ColumnHeader clmColor;
        private System.Windows.Forms.ColumnHeader clmPrice;
        private System.Windows.Forms.ColumnHeader clmDate;
        private System.Windows.Forms.ListView lvBookmarks;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
    }
}