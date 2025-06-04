using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarDealership.UI
{
    public partial class frmListing: Form
    {
        Car listing;

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

            if (listing.PostedBy == UsersDB.CurrentUser)
            {
                btnDelete.Visible = true;
                btnSold.Visible = true;
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

        }

        private void btnSold_Click(object sender, EventArgs e)
        {
            if (!listing.IsSold)
                MarkSold();
            else
                MarkUnsold();
        }
    }
}
