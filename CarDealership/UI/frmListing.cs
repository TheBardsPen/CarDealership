using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CarDealership.Business_MiddleLayer_;
using CarDealership.Properties;
using ValidationLibrary;

namespace CarDealership.UI
{
    public partial class frmListing : Form
    {
        private Car listing;

        public frmListing(Car _listing)
        {
            InitializeComponent();
            UpdateFormOnLoad(_listing); // Prevent programmer from using form without a Car
        }

        private void UpdateFormOnLoad(Car _listing)
        {
            listing = _listing;

            this.Text = $"{listing.Year} {listing.Make} {listing.Model}";

            gbListing.Text = $"{listing.Make} {listing.Model}";
            lblPriceChange.Text = listing.Price.ToString("c");
            lblColorChange.Text = listing.Color;
            lblYearChange.Text = listing.Year.ToString();
            lblPostedByChange.Text = listing.PostedBy;

            // Handle model specifics
            switch (listing.Make)
            {
                case "Dodge":
                    lblMakeSpecific.Text = "Engine:";
                    lblMakeSpecificChange.Text = listing.ModelSpecificString();

                    break;

                case "Ford":
                    lblMakeSpecific.Text = "Trim:";
                    lblMakeSpecificChange.Text = listing.ModelSpecificString();

                    break;

                case "Nissan":
                    lblMakeSpecific.Text = "Transmission:";
                    lblMakeSpecificChange.Text = listing.ModelSpecificString();

                    break;

                case "Toyota":
                    lblMakeSpecific.Text = "Mileage:";
                    lblMakeSpecificChange.Text = listing.ModelSpecificString();

                    break;

                default:
                    lblMakeSpecific.Visible = false;
                    lblMakeSpecificChange.Visible = false;

                    break;
            }

            if (listing.IsSold)
            {
                MarkSold();
            }

            UpdateComments();

            picBookmark.Visible = User.IsLoggedIn;
            btnSold.Visible = User.IsLoggedIn;
            btnDelete.Visible = User.IsLoggedIn;

            if (listing.PostedBy == User.Username)
            {
                btnDelete.Visible = true;
                btnSold.Visible = true;
            }

            if (User.IsLoggedIn)
            {
                picBookmark.Visible = true;

                picBookmark.BackgroundImage = User.BookmarkIDs.Contains(listing.CarID) ?
                    Resources.Free_Flat_Heart_Filled_Icon :
                    Resources.Free_Flat_Heart_Empty_Icon;
            }
        }

        private void MarkSold()
        {
            Font newFont = new Font(lblPriceChange.Font, lblPriceChange.Font.Style | FontStyle.Strikeout);
            lblPriceChange.Font = newFont;

            lblSold.Visible = true;

            frmCarDealership.cars.MarkSold(listing);
            frmCarDealership.cars.Save();
        }

        private void MarkUnsold()
        {
            Font newFont = new Font(lblPriceChange.Font, Font.Style);
            lblPriceChange.Font = newFont;

            lblSold.Visible = false;

            frmCarDealership.cars.MarkUnsold(listing);
            frmCarDealership.cars.Save();
        }

        private void UpdateComments()
        {
            txtComments.Clear();

            foreach (string[] a in listing.Comments)
            {
                txtComments.Text += listing.GetCommentLine(a) + "\n\n";
            }
        }

        private void btnSold_Click(object sender, EventArgs e)
        {
            if (!listing.IsSold)
            {
                MarkSold();
                this.Tag = "Sold";
            }
            else
            {
                MarkUnsold();
                this.Tag = null;
            }
        }

        private void picComment_Click(object sender, EventArgs e)
        {
            if (Validator.IsRichTextboxString("Comment", txtPost))
            {
                if (User.IsLoggedIn)
                    listing.AddComment(txtPost.Text, User.Username, DateTime.Now);
                else
                    listing.AddComment(txtPost.Text);
            }

            frmCarDealership.cars.Save();
            UpdateComments();
        }

        private void picBookmark_Click(object sender, EventArgs e)
        {
            if (User.BookmarkIDs.Contains(listing.CarID))
                User.BookmarkIDs.Remove(listing.CarID);
            else
                User.BookmarkIDs.Add(listing.CarID);

            User.Save();

            picBookmark.BackgroundImage = User.BookmarkIDs.Contains(listing.CarID) ?
                        Resources.Free_Flat_Heart_Filled_Icon :
                        Resources.Free_Flat_Heart_Empty_Icon;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult confirm = MessageBox.Show("Are you sure you wish to delete this listing?", "Confirm Delete",
                            MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (confirm == DialogResult.OK)
            {
                frmCarDealership.cars.Remove(listing);

                this.Tag = "Delete";
                this.Close();
            }
        }
    }
}