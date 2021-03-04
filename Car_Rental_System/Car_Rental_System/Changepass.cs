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
    public partial class Changepass : Form
    {
        private OleDbConnection connection = new OleDbConnection();
        public Changepass()
        {
            InitializeComponent();
            connection.ConnectionString= @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\private\Documents\Car_rental_system.accdb";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                OleDbCommand cmd = new OleDbCommand();
                cmd.Connection = connection;
                cmd.CommandText = "UPDATE login SET userpass='" + textBox2.Text +  "'WHERE ID=" + textBox3.Text;
                if (textBox2.Text.Length != textBox1.Text.Length)
                {
                    MessageBox.Show("Incorrect Passord");
                }
                else
                {
                    connection.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Record Updated");
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex);
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                textBox1.UseSystemPasswordChar = false;
                textBox2.UseSystemPasswordChar = false;
            }
            else
            {
                textBox1.UseSystemPasswordChar = true;
                textBox2.UseSystemPasswordChar = true;
            }
        }
    }
}
