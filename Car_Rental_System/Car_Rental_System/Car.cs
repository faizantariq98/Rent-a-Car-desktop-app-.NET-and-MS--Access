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
    public partial class Car : Form
    {
        private OleDbConnection connection = new OleDbConnection(); 
        public Car()
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
                cmd.CommandText = "insert into Cars(caname,cacategory,caedailyprice,cacolor,camilage,canumber,cahorsepower,cacompany) Values('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + textBox6.Text + "','" + textBox7.Text +"','"+textBox8.Text+ "')";
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
                cmd.CommandText = "UPDATE Cars SET caname='" + textBox1.Text + "',cacategory='" + textBox2.Text + "',caedailyprice='" + textBox3.Text + "',cacolor='" + textBox4.Text + "',camilage='" + textBox5.Text + "',canumber='" + textBox6.Text + "',cahorsepower='" + textBox7.Text +"',cacompany='"+textBox8.Text+"'WHERE caID=" + textBox9.Text;

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
                cmd.CommandText = "DELETE FROM Cars WHERE caID=" + textBox9.Text + "";
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
            string query = "SELECT * FROM Cars WHERE caID LIKE '" + textBox9.Text.ToString() + "%'";
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
