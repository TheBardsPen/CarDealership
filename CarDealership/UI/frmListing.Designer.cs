namespace CarDealership.UI
{
    partial class frmListing
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmListing));
            this.gbListing = new System.Windows.Forms.GroupBox();
            this.picBookmark = new System.Windows.Forms.PictureBox();
            this.lblSold = new System.Windows.Forms.Label();
            this.lblPostedByChange = new System.Windows.Forms.Label();
            this.lblPostedBy = new System.Windows.Forms.Label();
            this.lblMakeSpecificChange = new System.Windows.Forms.Label();
            this.lblColorChange = new System.Windows.Forms.Label();
            this.lblYearChange = new System.Windows.Forms.Label();
            this.lblMakeSpecific = new System.Windows.Forms.Label();
            this.lblColor = new System.Windows.Forms.Label();
            this.lblYear = new System.Windows.Forms.Label();
            this.lblPriceChange = new System.Windows.Forms.Label();
            this.txtComments = new System.Windows.Forms.RichTextBox();
            this.txtPost = new System.Windows.Forms.RichTextBox();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnSold = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.picComment = new System.Windows.Forms.PictureBox();
            this.gbListing.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBookmark)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picComment)).BeginInit();
            this.SuspendLayout();
            // 
            // gbListing
            // 
            this.gbListing.Controls.Add(this.picBookmark);
            this.gbListing.Controls.Add(this.lblSold);
            this.gbListing.Controls.Add(this.lblPostedByChange);
            this.gbListing.Controls.Add(this.lblPostedBy);
            this.gbListing.Controls.Add(this.lblMakeSpecificChange);
            this.gbListing.Controls.Add(this.lblColorChange);
            this.gbListing.Controls.Add(this.lblYearChange);
            this.gbListing.Controls.Add(this.lblMakeSpecific);
            this.gbListing.Controls.Add(this.lblColor);
            this.gbListing.Controls.Add(this.lblYear);
            this.gbListing.Controls.Add(this.lblPriceChange);
            this.gbListing.Location = new System.Drawing.Point(26, 25);
            this.gbListing.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.gbListing.Name = "gbListing";
            this.gbListing.Padding = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.gbListing.Size = new System.Drawing.Size(384, 344);
            this.gbListing.TabIndex = 0;
            this.gbListing.TabStop = false;
            this.gbListing.Text = "{make + model}";
            // 
            // picBookmark
            // 
            this.picBookmark.BackgroundImage = global::CarDealership.Properties.Resources.Free_Flat_Heart_Empty_Icon;
            this.picBookmark.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picBookmark.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picBookmark.Location = new System.Drawing.Point(308, 23);
            this.picBookmark.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.picBookmark.Name = "picBookmark";
            this.picBookmark.Size = new System.Drawing.Size(64, 62);
            this.picBookmark.TabIndex = 10;
            this.picBookmark.TabStop = false;
            this.picBookmark.Visible = false;
            this.picBookmark.Click += new System.EventHandler(this.picBookmark_Click);
            // 
            // lblSold
            // 
            this.lblSold.AutoSize = true;
            this.lblSold.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSold.Location = new System.Drawing.Point(170, 38);
            this.lblSold.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblSold.Name = "lblSold";
            this.lblSold.Size = new System.Drawing.Size(92, 26);
            this.lblSold.TabIndex = 9;
            this.lblSold.Text = "{SOLD}";
            this.lblSold.Visible = false;
            // 
            // lblPostedByChange
            // 
            this.lblPostedByChange.AutoSize = true;
            this.lblPostedByChange.Location = new System.Drawing.Point(170, 306);
            this.lblPostedByChange.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblPostedByChange.Name = "lblPostedByChange";
            this.lblPostedByChange.Size = new System.Drawing.Size(116, 25);
            this.lblPostedByChange.TabIndex = 8;
            this.lblPostedByChange.Text = "{postedBy}";
            // 
            // lblPostedBy
            // 
            this.lblPostedBy.AutoSize = true;
            this.lblPostedBy.Location = new System.Drawing.Point(20, 308);
            this.lblPostedBy.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblPostedBy.Name = "lblPostedBy";
            this.lblPostedBy.Size = new System.Drawing.Size(116, 25);
            this.lblPostedBy.TabIndex = 7;
            this.lblPostedBy.Text = "Posted By:";
            // 
            // lblMakeSpecificChange
            // 
            this.lblMakeSpecificChange.AutoSize = true;
            this.lblMakeSpecificChange.Location = new System.Drawing.Point(164, 156);
            this.lblMakeSpecificChange.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblMakeSpecificChange.Name = "lblMakeSpecificChange";
            this.lblMakeSpecificChange.Size = new System.Drawing.Size(101, 25);
            this.lblMakeSpecificChange.TabIndex = 6;
            this.lblMakeSpecificChange.Text = "{mileage}";
            // 
            // lblColorChange
            // 
            this.lblColorChange.AutoSize = true;
            this.lblColorChange.Location = new System.Drawing.Point(164, 117);
            this.lblColorChange.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblColorChange.Name = "lblColorChange";
            this.lblColorChange.Size = new System.Drawing.Size(73, 25);
            this.lblColorChange.TabIndex = 5;
            this.lblColorChange.Text = "{color}";
            // 
            // lblYearChange
            // 
            this.lblYearChange.AutoSize = true;
            this.lblYearChange.Location = new System.Drawing.Point(164, 79);
            this.lblYearChange.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblYearChange.Name = "lblYearChange";
            this.lblYearChange.Size = new System.Drawing.Size(68, 25);
            this.lblYearChange.TabIndex = 4;
            this.lblYearChange.Text = "{year}";
            // 
            // lblMakeSpecific
            // 
            this.lblMakeSpecific.AutoSize = true;
            this.lblMakeSpecific.Location = new System.Drawing.Point(14, 156);
            this.lblMakeSpecific.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblMakeSpecific.Name = "lblMakeSpecific";
            this.lblMakeSpecific.Size = new System.Drawing.Size(94, 25);
            this.lblMakeSpecific.TabIndex = 3;
            this.lblMakeSpecific.Text = "Mileage:";
            // 
            // lblColor
            // 
            this.lblColor.AutoSize = true;
            this.lblColor.Location = new System.Drawing.Point(14, 117);
            this.lblColor.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblColor.Name = "lblColor";
            this.lblColor.Size = new System.Drawing.Size(69, 25);
            this.lblColor.TabIndex = 2;
            this.lblColor.Text = "Color:";
            // 
            // lblYear
            // 
            this.lblYear.AutoSize = true;
            this.lblYear.Location = new System.Drawing.Point(14, 79);
            this.lblYear.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblYear.Name = "lblYear";
            this.lblYear.Size = new System.Drawing.Size(64, 25);
            this.lblYear.TabIndex = 1;
            this.lblYear.Text = "Year:";
            // 
            // lblPriceChange
            // 
            this.lblPriceChange.AutoSize = true;
            this.lblPriceChange.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPriceChange.Location = new System.Drawing.Point(14, 40);
            this.lblPriceChange.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblPriceChange.Name = "lblPriceChange";
            this.lblPriceChange.Size = new System.Drawing.Size(73, 26);
            this.lblPriceChange.TabIndex = 0;
            this.lblPriceChange.Text = "{price}";
            // 
            // txtComments
            // 
            this.txtComments.Location = new System.Drawing.Point(422, 135);
            this.txtComments.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.txtComments.Name = "txtComments";
            this.txtComments.ReadOnly = true;
            this.txtComments.Size = new System.Drawing.Size(618, 352);
            this.txtComments.TabIndex = 1;
            this.txtComments.Text = "";
            // 
            // txtPost
            // 
            this.txtPost.Location = new System.Drawing.Point(422, 33);
            this.txtPost.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.txtPost.Name = "txtPost";
            this.txtPost.Size = new System.Drawing.Size(270, 47);
            this.txtPost.TabIndex = 3;
            this.txtPost.Size = new System.Drawing.Size(536, 87);
            this.txtPost.TabIndex = 4;
            this.txtPost.Text = "";
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(26, 381);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(180, 44);
            this.btnDelete.TabIndex = 7;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Visible = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnSold
            // 
            this.btnSold.Location = new System.Drawing.Point(230, 381);
            this.btnSold.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.btnSold.Name = "btnSold";
            this.btnSold.Size = new System.Drawing.Size(180, 44);
            this.btnSold.TabIndex = 8;
            this.btnSold.Text = "Mark Sold";
            this.btnSold.UseVisualStyleBackColor = true;
            this.btnSold.Visible = false;
            this.btnSold.Click += new System.EventHandler(this.btnSold_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(230, 446);
            this.btnClose.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(180, 44);
            this.btnClose.TabIndex = 10;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // picComment
            // 
            this.picComment.BackgroundImage = global::CarDealership.Properties.Resources.Free_Flat_Chat_1_Bars_Icon;
            this.picComment.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picComment.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picComment.Location = new System.Drawing.Point(974, 42);
            this.picComment.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.picComment.Name = "picComment";
            this.picComment.Size = new System.Drawing.Size(70, 67);
            this.picComment.TabIndex = 12;
            this.picComment.TabStop = false;
            this.picComment.Click += new System.EventHandler(this.picComment_Click);
            // 
            // frmListing
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(534, 267);
            this.Controls.Add(this.picComment);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSold);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.txtPost);
            this.Controls.Add(this.txtComments);
            this.Controls.Add(this.gbListing);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.Name = "frmListing";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "{listing}";
            this.gbListing.ResumeLayout(false);
            this.gbListing.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBookmark)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picComment)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbListing;
        private System.Windows.Forms.RichTextBox txtComments;
        private System.Windows.Forms.RichTextBox txtPost;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnSold;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lblMakeSpecific;
        private System.Windows.Forms.Label lblColor;
        private System.Windows.Forms.Label lblYear;
        private System.Windows.Forms.Label lblPriceChange;
        private System.Windows.Forms.Label lblMakeSpecificChange;
        private System.Windows.Forms.Label lblColorChange;
        private System.Windows.Forms.Label lblYearChange;
        private System.Windows.Forms.Label lblSold;
        private System.Windows.Forms.Label lblPostedByChange;
        private System.Windows.Forms.Label lblPostedBy;
        private System.Windows.Forms.PictureBox picComment;
        private System.Windows.Forms.PictureBox picBookmark;
    }
}