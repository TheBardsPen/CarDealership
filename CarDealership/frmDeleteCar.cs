using System;
using System.Collections;
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
    public partial class frmDeleteCar : Form
    {
        public CarList cars = new CarList();

        public void carSelect(CarList cars)
        {
            foreach (Car c in cars)
            {
                lB1.Items.Add(c.DateAdded.ToShortDateString() + " " + c.Make + " " + c.Model);
            }
        }

        public frmDeleteCar()
        {
            InitializeComponent();
        }

        // private CarList GetCars()
        // {
        //   return cars;
        // }

        // private void frmDeleteCar_Load(object sender, EventArgs e, CarList cars)
        // {
        // 

        //   List<string> MyList = new List<string>();
        //  MyList.Add("HELLO");
        //  MyList.Add("WORLD");

        //  lB1.DataSource = MyList;

        // Load carlist from database on form load
        //cars.Load();
        // lB1.DataSource = cars;
        // for (int i = 0; i < cars.Count; i++)
        //  {
        //       lB1.Items.Add(cars.ElementAt(i));
        // }
        //for (int q = 0; q < cars.Count; q++)
        //{
        //   Car c = cars[q];
        //  lB1.Text += c.GetDisplayText();
        // }
        // }

        private void btnCancelDel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Tag = lB1.SelectedIndex;
            DialogResult = DialogResult.OK;
        }

        private void frmDeleteCar_Load(object sender, EventArgs e)
        {
            carSelect(cars);
        }
    }
}
