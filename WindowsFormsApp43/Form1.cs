using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Net.Mail;


namespace WindowsFormsApp43
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Home h = new Home();
            h.Show();
            this.Hide();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string constring = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Payment.mdf;Integrated Security=True;Connect Timeout=30";
            string qry = "Select * from Payment";
            SqlDataAdapter ad = new SqlDataAdapter(qry, constring);
            DataSet ds = new DataSet();
            ad.Fill(ds, "Payment");
            dgv1.DataSource = ds.Tables["Payment"];
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SendingEmail mail = new SendingEmail();
            mail.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Payment.mdf;Integrated Security=True;Connect Timeout=30");
            string qry="Update Payment set Fee='"+textBox5.Text+"' where id='"+textBox4.Text+"'";
            SqlCommand cmd = new SqlCommand(qry, con);
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Updated Successfully");
            }
            catch(SqlException se)
            {
                MessageBox.Show("Update Failed " + se);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            int ci;
            int ino;
            string p;
            ci = int.Parse(textBox1.Text);
            ino = int.Parse(textBox2.Text);
            p = textBox6.Text;
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Payment.mdf;Integrated Security=True;Connect Timeout=30");
            string qry = "Insert into Payment values('"+ci+"','"+ino+"','"+ textBox3.Text + "','"+p+"')";
            
            SqlCommand cmd = new SqlCommand(qry, con);
            if(radioButton1.Checked)
            {
                try
                {
                    con.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Inserted Successfully");
                }
             
                catch (SqlException se)
                {
                    MessageBox.Show("" + se);
                }
            
            }
            else
            {
                MessageBox.Show("The Payment hasn't paid");
            }
            
        }

        private void button6_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Payment.mdf;Integrated Security=True;Connect Timeout=30");
            string qry = "Delete From Payment where id='"+textBox7.Text+"'";
            SqlCommand cmd = new SqlCommand(qry, con);
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Deleted Successfully");
            }
            catch (SqlException se)
            {
                MessageBox.Show("Delete Failed " + se);
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            f1.Show();
            this.Hide();
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            string constring = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Payment.mdf;Integrated Security=True;Connect Timeout=30";
            string qry = "Select * from Payment";
            SqlDataAdapter ad = new SqlDataAdapter(qry, constring);
            DataSet ds = new DataSet();
            ad.Fill(ds, "Payment");
            dgv1.DataSource = ds.Tables["Payment"];
        }

        private void button5_Click_1(object sender, EventArgs e)
        {

        }
    }
}
