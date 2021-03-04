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
    public partial class Employees : Form
    {
        private OleDbConnection connection = new OleDbConnection();
        public Employees()
        {
            InitializeComponent();
            connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\private\Documents\Car_rental_system.accdb";
        }
        public string name="", cont="", address="", cnic="", design="", gender="", id="", salary="";

        private void button5_Click(object sender, EventArgs e)
        {
            string query = "SELECT * FROM Employee WHERE empID LIKE '" + textBox1.Text.ToString() + "%'";
            OleDbDataAdapter dataAdapter = new OleDbDataAdapter(query, connection);
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

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                OleDbCommand cmd = new OleDbCommand();
                cmd.Connection = connection;
                cmd.CommandText = "DELETE FROM Employee WHERE empID=" + textBox1.Text + "";
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

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                OleDbCommand cmd = new OleDbCommand();
                cmd.Connection = connection;
                cmd.CommandText = "UPDATE Employee SET empname='" + textBox2.Text + "',empcnic='" + textBox3.Text + "',empcontact='" + textBox4.Text + "',empdesign='" + textBox5.Text + "',empaddress='" + textBox6.Text + "',empsalary='" + textBox7.Text + "',empgender='" + gender + "'WHERE empID=" + textBox1.Text;

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

        private void button1_Click(object sender, EventArgs e)
        {
            //id = textBox1.Text;
         //   name = textBox2.Text;
           // cnic = textBox3.Text;
            //cont = textBox4.Text;
            //design = textBox5.Text;
            //address = textBox6.Text;
            //salary = textBox7.Text;
            if (radioButton1.Checked)
            {
                gender = "Male";
            }else if (radioButton2.Checked)
            {
                gender = "Female";
            }
            //OleDbConnection con = new OleDbConnection("Provider = Microsoft.ACE.OLEDB.12.0; Data Source =Car_rental_system.accdb");
            try
            {
                connection.Open();
                OleDbCommand cmd = new OleDbCommand();
                cmd.Connection = connection;
                cmd.CommandText = "insert into Employee(empname,empcnic,empcontact,empdesign,empaddress,empsalary,empgender) Values('" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + textBox6.Text + "','" + textBox7.Text + "','" + gender + "')";
               // cmd.Connection = con;
                cmd.ExecuteNonQuery();
                MessageBox.Show("Record Submitted", "Congrats");
                connection.Close();
               // con.Close();
            }catch(Exception ex)
            {
                MessageBox.Show("Error" + ex);
            }
        }

       

        private void Employees_Load(object sender, EventArgs e)
        {
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
