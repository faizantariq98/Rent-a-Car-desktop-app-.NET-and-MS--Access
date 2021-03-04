using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Car_Rental_System
{
    public partial class DisplayEmp : Form
    {

        private OleDbConnection connection = new OleDbConnection();
        public DisplayEmp()
        {
            InitializeComponent();
            connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\private\Documents\Car_rental_system.accdb";
        }

        private void DisplayEmp_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            OleDbDataAdapter dataAdapter = new OleDbDataAdapter("SELECT * FROM Employee", connection);
            connection.Open();
            // creating a DataSet object
            DataSet ds = new DataSet();
            // filling table Order  
            dataAdapter.Fill(ds, "Employee");
            DataTable tab = new DataTable();
            tab = ds.Tables["Employee"];
            dataGridView1.DataSource = tab;
            connection.Close();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
