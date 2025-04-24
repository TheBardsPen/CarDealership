namespace CarDealership
{
    partial class frmAddCar
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
            this.lblMake = new System.Windows.Forms.Label();
            this.cboMake = new System.Windows.Forms.ComboBox();
            this.lblModel = new System.Windows.Forms.Label();
            this.txtModel = new System.Windows.Forms.TextBox();
            this.txtColor = new System.Windows.Forms.TextBox();
            this.lblColor = new System.Windows.Forms.Label();
            this.txtYear = new System.Windows.Forms.TextBox();
            this.lblYear = new System.Windows.Forms.Label();
            this.txtPrice = new System.Windows.Forms.TextBox();
            this.lblPrice = new System.Windows.Forms.Label();
            this.txtbModelSpecific = new System.Windows.Forms.TextBox();
            this.lblModelSpecific = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblMake
            // 
            this.lblMake.AutoSize = true;
            this.lblMake.Location = new System.Drawing.Point(24, 46);
            this.lblMake.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblMake.Name = "lblMake";
            this.lblMake.Size = new System.Drawing.Size(71, 25);
            this.lblMake.TabIndex = 8;
            this.lblMake.Text = "Make:";
            // 
            // cboMake
            // 
            this.cboMake.FormattingEnabled = true;
            this.cboMake.Location = new System.Drawing.Point(160, 40);
            this.cboMake.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.cboMake.Name = "cboMake";
            this.cboMake.Size = new System.Drawing.Size(238, 33);
            this.cboMake.TabIndex = 0;
            this.cboMake.SelectedIndexChanged += new System.EventHandler(this.cboMake_SelectedIndexChanged);
            // 
            // lblModel
            // 
            this.lblModel.AutoSize = true;
            this.lblModel.Location = new System.Drawing.Point(24, 98);
            this.lblModel.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblModel.Name = "lblModel";
            this.lblModel.Size = new System.Drawing.Size(77, 25);
            this.lblModel.TabIndex = 9;
            this.lblModel.Text = "Model:";
            // 
            // txtModel
            // 
            this.txtModel.Location = new System.Drawing.Point(160, 92);
            this.txtModel.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.txtModel.Name = "txtModel";
            this.txtModel.Size = new System.Drawing.Size(238, 31);
            this.txtModel.TabIndex = 1;
            // 
            // txtColor
            // 
            this.txtColor.Location = new System.Drawing.Point(160, 142);
            this.txtColor.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.txtColor.Name = "txtColor";
            this.txtColor.Size = new System.Drawing.Size(238, 31);
            this.txtColor.TabIndex = 2;
            // 
            // lblColor
            // 
            this.lblColor.AutoSize = true;
            this.lblColor.Location = new System.Drawing.Point(24, 148);
            this.lblColor.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblColor.Name = "lblColor";
            this.lblColor.Size = new System.Drawing.Size(69, 25);
            this.lblColor.TabIndex = 10;
            this.lblColor.Text = "Color:";
            // 
            // txtYear
            // 
            this.txtYear.Location = new System.Drawing.Point(160, 192);
            this.txtYear.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.txtYear.Name = "txtYear";
            this.txtYear.Size = new System.Drawing.Size(238, 31);
            this.txtYear.TabIndex = 3;
            // 
            // lblYear
            // 
            this.lblYear.AutoSize = true;
            this.lblYear.Location = new System.Drawing.Point(24, 198);
            this.lblYear.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblYear.Name = "lblYear";
            this.lblYear.Size = new System.Drawing.Size(64, 25);
            this.lblYear.TabIndex = 11;
            this.lblYear.Text = "Year:";
            // 
            // txtPrice
            // 
            this.txtPrice.Location = new System.Drawing.Point(160, 242);
            this.txtPrice.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Size = new System.Drawing.Size(238, 31);
            this.txtPrice.TabIndex = 4;
            // 
            // lblPrice
            // 
            this.lblPrice.AutoSize = true;
            this.lblPrice.Location = new System.Drawing.Point(24, 248);
            this.lblPrice.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.Size = new System.Drawing.Size(67, 25);
            this.lblPrice.TabIndex = 12;
            this.lblPrice.Text = "Price:";
            // 
            // txtbModelSpecific
            // 
            this.txtbModelSpecific.Enabled = false;
            this.txtbModelSpecific.Location = new System.Drawing.Point(160, 292);
            this.txtbModelSpecific.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.txtbModelSpecific.Name = "txtbModelSpecific";
            this.txtbModelSpecific.Size = new System.Drawing.Size(238, 31);
            this.txtbModelSpecific.TabIndex = 5;
            // 
            // lblModelSpecific
            // 
            this.lblModelSpecific.AutoSize = true;
            this.lblModelSpecific.Location = new System.Drawing.Point(24, 298);
            this.lblModelSpecific.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblModelSpecific.Name = "lblModelSpecific";
            this.lblModelSpecific.Size = new System.Drawing.Size(0, 25);
            this.lblModelSpecific.TabIndex = 13;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(90, 387);
            this.btnSave.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(150, 44);
            this.btnSave.TabIndex = 6;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(252, 387);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(150, 44);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // frmAddCar
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(464, 462);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtbModelSpecific);
            this.Controls.Add(this.lblModelSpecific);
            this.Controls.Add(this.txtPrice);
            this.Controls.Add(this.lblPrice);
            this.Controls.Add(this.txtYear);
            this.Controls.Add(this.lblYear);
            this.Controls.Add(this.txtColor);
            this.Controls.Add(this.lblColor);
            this.Controls.Add(this.txtModel);
            this.Controls.Add(this.lblModel);
            this.Controls.Add(this.cboMake);
            this.Controls.Add(this.lblMake);
            this.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.Name = "frmAddCar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add Car";
            this.Load += new System.EventHandler(this.frmAddCar_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblMake;
        private System.Windows.Forms.ComboBox cboMake;
        private System.Windows.Forms.Label lblModel;
        private System.Windows.Forms.TextBox txtModel;
        private System.Windows.Forms.TextBox txtColor;
        private System.Windows.Forms.Label lblColor;
        private System.Windows.Forms.TextBox txtYear;
        private System.Windows.Forms.Label lblYear;
        private System.Windows.Forms.TextBox txtPrice;
        private System.Windows.Forms.Label lblPrice;
        private System.Windows.Forms.TextBox txtbModelSpecific;
        private System.Windows.Forms.Label lblModelSpecific;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
    }
}