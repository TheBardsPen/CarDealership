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
            this.lblUsername = new System.Windows.Forms.Label();
            this.gbListings = new System.Windows.Forms.GroupBox();
            this.lvListings = new System.Windows.Forms.ListView();
            this.clmMake = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmModel = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmYear = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmColor = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmPrice = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.gbListings.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.Font = new System.Drawing.Font("Javanese Text", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsername.Location = new System.Drawing.Point(13, 13);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(99, 36);
            this.lblUsername.TabIndex = 0;
            this.lblUsername.Text = "{username}";
            // 
            // gbListings
            // 
            this.gbListings.Controls.Add(this.lvListings);
            this.gbListings.Location = new System.Drawing.Point(19, 52);
            this.gbListings.Name = "gbListings";
            this.gbListings.Size = new System.Drawing.Size(499, 176);
            this.gbListings.TabIndex = 1;
            this.gbListings.TabStop = false;
            this.gbListings.Text = "Listings";
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
            this.lvListings.Location = new System.Drawing.Point(6, 19);
            this.lvListings.MultiSelect = false;
            this.lvListings.Name = "lvListings";
            this.lvListings.Size = new System.Drawing.Size(487, 151);
            this.lvListings.TabIndex = 13;
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
            // frmProfile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(530, 278);
            this.Controls.Add(this.gbListings);
            this.Controls.Add(this.lblUsername);
            this.Name = "frmProfile";
            this.Text = "Profile";
            this.Load += new System.EventHandler(this.frmProfile_Load);
            this.gbListings.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.GroupBox gbListings;
        private System.Windows.Forms.ListView lvListings;
        private System.Windows.Forms.ColumnHeader clmMake;
        private System.Windows.Forms.ColumnHeader clmModel;
        private System.Windows.Forms.ColumnHeader clmYear;
        private System.Windows.Forms.ColumnHeader clmColor;
        private System.Windows.Forms.ColumnHeader clmPrice;
        private System.Windows.Forms.ColumnHeader clmDate;
    }
}