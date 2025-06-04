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
            UpdateForm(_listing); // Prevent programmer from using form without a Car
        }

        public void UpdateForm(Car _listing)
        {
            listing = _listing;

            this.Text = $"{listing.Year} {listing.Make} {listing.Model}";
        }
    }
}
