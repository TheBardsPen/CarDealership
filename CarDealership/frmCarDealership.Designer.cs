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
            this.lbCarList = new System.Windows.Forms.ListBox();
            this.btnViewAll = new System.Windows.Forms.Button();
            this.cboFilterType = new System.Windows.Forms.ComboBox();
            this.cboFilter = new System.Windows.Forms.ComboBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnFilter = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbCarList
            // 
            this.lbCarList.FormattingEnabled = true;
            this.lbCarList.Location = new System.Drawing.Point(12, 41);
            this.lbCarList.Name = "lbCarList";
            this.lbCarList.Size = new System.Drawing.Size(385, 225);
            this.lbCarList.TabIndex = 7;
            // 
            // btnViewAll
            // 
            this.btnViewAll.Location = new System.Drawing.Point(12, 12);
            this.btnViewAll.Name = "btnViewAll";
            this.btnViewAll.Size = new System.Drawing.Size(75, 23);
            this.btnViewAll.TabIndex = 0;
            this.btnViewAll.Text = "View All";
            this.btnViewAll.UseVisualStyleBackColor = true;
            // 
            // cboFilterType
            // 
            this.cboFilterType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFilterType.FormattingEnabled = true;
            this.cboFilterType.Items.AddRange(new object[] {
            "Make",
            "Color",
            "Age",
            "Price",
            "Mileage",
            "Engine",
            "Trim",
            "Transmission"});
            this.cboFilterType.Location = new System.Drawing.Point(122, 12);
            this.cboFilterType.Name = "cboFilterType";
            this.cboFilterType.Size = new System.Drawing.Size(121, 21);
            this.cboFilterType.TabIndex = 1;
            this.cboFilterType.SelectedIndexChanged += new System.EventHandler(this.cboFilterType_SelectedIndexChanged);
            // 
            // cboFilter
            // 
            this.cboFilter.Enabled = false;
            this.cboFilter.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboFilter.FormattingEnabled = true;
            this.cboFilter.Location = new System.Drawing.Point(249, 12);
            this.cboFilter.Name = "cboFilter";
            this.cboFilter.Size = new System.Drawing.Size(148, 21);
            this.cboFilter.TabIndex = 2;
            this.cboFilter.Text = "Filter...";
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(418, 62);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 4;
            this.btnAdd.Text = "Add Car";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Enabled = false;
            this.btnDelete.Location = new System.Drawing.Point(418, 91);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 5;
            this.btnDelete.Text = "Delete Car";
            this.btnDelete.UseVisualStyleBackColor = true;
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(418, 243);
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
            this.btnFilter.Location = new System.Drawing.Point(418, 12);
            this.btnFilter.Name = "btnFilter";
            this.btnFilter.Size = new System.Drawing.Size(75, 23);
            this.btnFilter.TabIndex = 3;
            this.btnFilter.Text = "Filter";
            this.btnFilter.UseVisualStyleBackColor = true;
            // 
            // frmCarDealership
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(506, 282);
            this.Controls.Add(this.btnFilter);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.cboFilter);
            this.Controls.Add(this.cboFilterType);
            this.Controls.Add(this.btnViewAll);
            this.Controls.Add(this.lbCarList);
            this.Name = "frmCarDealership";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Car Dealership";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lbCarList;
        private System.Windows.Forms.Button btnViewAll;
        private System.Windows.Forms.ComboBox cboFilterType;
        private System.Windows.Forms.ComboBox cboFilter;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnFilter;
    }
}

