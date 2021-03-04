using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace Car_Rental_System
{
    public partial class ReportMenu : Form
    {
        
        public ReportMenu()
        {
            InitializeComponent();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DisplayEmp obj = new DisplayEmp();
            obj.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            CustomerReport obj = new CustomerReport();
            obj.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            BookingReport obj = new BookingReport();
            obj.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            CarReport obj = new CarReport();
            obj.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            FuelReport obj = new FuelReport();
            obj.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
