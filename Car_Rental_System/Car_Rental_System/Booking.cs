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
    public partial class Booking : Form
    {
        private OleDbConnection connection = new OleDbConnection();
        public Booking()
        {
            InitializeComponent();
            connection.ConnectionString= @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\private\Documents\Car_rental_system.accdb";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                connection.Open();
                OleDbCommand cmd = new OleDbCommand();
                cmd.Connection = connection;
                cmd.CommandText = "insert into Booking(bcar,bdays,brentdate,bamount,breturndate,bcid) Values('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + textBox6.Text.ToString()   + "')";
                // cmd.Connection = con;
                cmd.ExecuteNonQuery();
                MessageBox.Show("Record Submitted", "Congrats");
                connection.Close();
                // con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

            try
            {
                OleDbCommand cmd = new OleDbCommand();
                cmd.Connection = connection;
                cmd.CommandText = "UPDATE Booking SET bcar='" + textBox1.Text + "',bdays='" + textBox3.Text + "',brentdate='" + textBox2.Text + "',bamount='" + textBox4.Text + "',breturndate='" + textBox5.Text + "',bcid='" + textBox6.Text.ToString() +  "'WHERE bID=" + textBox7.Text.ToString();

                connection.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Record Updated");
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

            try
            {
                OleDbCommand cmd = new OleDbCommand();
                cmd.Connection = connection;
                cmd.CommandText = "DELETE FROM Booking WHERE bID=" + textBox7.Text + "";
                //www.csharp-console-example.com
                connection.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show(" Record Deleted");
                connection.Close();


            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string query = "SELECT * FROM Booking WHERE bID LIKE '" + textBox7.Text.ToString() + "%'";
            OleDbDataAdapter dataAdapter = new OleDbDataAdapter(query, connection);
            connection.Open();
            // creating a DataSet object
            DataSet ds = new DataSet();
            // filling table Order  
            dataAdapter.Fill(ds, "Booking");
            DataTable tab = new DataTable();
            tab = ds.Tables["Booking"];
            dataGridView1.DataSource = tab;
            connection.Close();
        }
    }
}
