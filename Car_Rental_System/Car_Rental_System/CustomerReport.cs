﻿using System;
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
    public partial class CustomerReport : Form
    {
        private OleDbConnection connection = new OleDbConnection();
        public CustomerReport()
        {
            InitializeComponent();
            connection.ConnectionString= @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\private\Documents\Car_rental_system.accdb";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OleDbDataAdapter dataAdapter = new OleDbDataAdapter("SELECT * FROM Customer", connection);
            connection.Open();
            // creating a DataSet object
            DataSet ds = new DataSet();
            // filling table Order  
            dataAdapter.Fill(ds, "Customer");
            DataTable tab = new DataTable();
            tab = ds.Tables["Customer"];
            dataGridView1.DataSource = tab;
            connection.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
