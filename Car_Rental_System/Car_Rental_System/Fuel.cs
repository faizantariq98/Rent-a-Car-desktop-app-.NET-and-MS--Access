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
    public partial class Fuel : Form
    {
        private OleDbConnection connection = new OleDbConnection();
        public Fuel()
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
                cmd.CommandText = "insert into Fuel(ftype,fquantity) Values('" + listBox1.Text + "','" + textBox2.Text +  "')";
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

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                OleDbCommand cmd = new OleDbCommand();
                cmd.Connection = connection;
                cmd.CommandText = "UPDATE Fuel SET ftype='" + listBox1.Text + "',fquantity='" + textBox2.Text + "'WHERE fID=" + textBox4.Text;

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

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                OleDbCommand cmd = new OleDbCommand();
                cmd.Connection = connection;
                cmd.CommandText = "DELETE FROM Fuel WHERE fID=" + textBox4.Text + "";
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
            string query = "SELECT * FROM Fuel WHERE fID LIKE '" + textBox4.Text.ToString() + "%'";
            OleDbDataAdapter dataAdapter = new OleDbDataAdapter(query, connection);
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
    }
}
