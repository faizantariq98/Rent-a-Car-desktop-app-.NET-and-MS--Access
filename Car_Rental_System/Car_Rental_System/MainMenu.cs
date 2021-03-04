using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Car_Rental_System
{
    public partial class MainMenu : Form
    {
        public MainMenu()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Employees obj = new Employees();
           // this.Hide();
            obj.Show();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DisplayEmp obj = new DisplayEmp();
            obj.Show();
        }

        private void MainMenu_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Customer obj = new Customer();
            obj.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Booking obj = new Booking();
            obj.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Fuel obj = new Fuel();
            obj.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Car obj = new Car();
            obj.Show();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            ReportMenu obj = new ReportMenu();
            obj.Show();
        }
    }
}
