using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarDealership
{
    public partial class Form1: Form
    {
        public CarList cars = new CarList();

        public Form1()
        {
            InitializeComponent();
        }

        public void test(CarList cars)
        {
            foreach (Car c in cars)
            {
                listBox1.Items.Add(c.DateAdded.ToShortDateString() + " " + c.Make + " " + c.Model);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            test(cars);
        }
    }
}
