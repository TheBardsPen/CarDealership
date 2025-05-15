namespace CarDealership
{
    partial class frmDeleteCar
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
            this.lB1 = new System.Windows.Forms.ListBox();
            this.button1 = new System.Windows.Forms.Button();
            this.btnCancelDel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lB1
            // 
            this.lB1.FormattingEnabled = true;
            this.lB1.ItemHeight = 25;
            this.lB1.Location = new System.Drawing.Point(16, 19);
            this.lB1.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.lB1.Name = "lB1";
            this.lB1.Size = new System.Drawing.Size(1232, 829);
            this.lB1.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(1308, 85);
            this.button1.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(270, 202);
            this.button1.TabIndex = 1;
            this.button1.Text = "Delete Car";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnCancelDel
            // 
            this.btnCancelDel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelDel.Location = new System.Drawing.Point(1300, 419);
            this.btnCancelDel.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.btnCancelDel.Name = "btnCancelDel";
            this.btnCancelDel.Size = new System.Drawing.Size(276, 271);
            this.btnCancelDel.TabIndex = 2;
            this.btnCancelDel.Text = "Cancel";
            this.btnCancelDel.UseVisualStyleBackColor = true;
            this.btnCancelDel.Click += new System.EventHandler(this.btnCancelDel_Click);
            // 
            // frmDeleteCar
            // 
            this.AcceptButton = this.button1;
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancelDel;
            this.ClientSize = new System.Drawing.Size(1646, 942);
            this.Controls.Add(this.btnCancelDel);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lB1);
            this.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.Name = "frmDeleteCar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Delete Cars";
            this.Load += new System.EventHandler(this.frmDeleteCar_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lB1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnCancelDel;
    }
}