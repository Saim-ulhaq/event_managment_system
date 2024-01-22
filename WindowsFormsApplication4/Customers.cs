using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace WindowsFormsApplication4
{
    public partial class Customers : Form
    {
        public Customers()
        {
            InitializeComponent();
            ShowCustomers();
        }
        private void ShowCustomers()
        {
            con.Open();
            string Query = "select * from Customer";
            SqlDataAdapter sda = new SqlDataAdapter(Query, con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            dataGridView3.DataSource = ds.Tables[0];
            con.Close();
        }

        private void Clear()
        {
            customerName.Text = "";
            customerphoneno.Text = "";
        }

        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-DIFSIEP\SQLEXPRESS;Initial Catalog=project;Integrated Security=True");
        private void button4_Click(object sender, EventArgs e)
        {
             if(customerName.Text == "" || customerphoneno.Text == "")
            {
                MessageBox.Show("Information is required");
            }
        else
        {
           try
        {
          con.Open();
          SqlCommand cmd = new SqlCommand("Insert into Customer(CustName,CustPhone)values(@CN,@CP)",con);
          cmd.Parameters.AddWithValue("@CN",customerName.Text);
          cmd.Parameters.AddWithValue("@CP",customerphoneno.Text);

          cmd.ExecuteNonQuery();
          MessageBox.Show("Customer information is Added");





          con.Close();
          ShowCustomers();
          Clear();
        }
           catch (Exception Ex)
           {
               MessageBox.Show(Ex.Message);
           }
        }


        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (customerName.Text == "" || customerphoneno.Text == "")
            {
                MessageBox.Show("Information is required");
            }
            else
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("update Customer set CustName=@CN,CustPhone=@CP where CustId=@Ckey", con);
                    cmd.Parameters.AddWithValue("@CN", customerName.Text);
                    cmd.Parameters.AddWithValue("@CP", customerphoneno.Text);
                    cmd.Parameters.AddWithValue("@CKey", key);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Customer information is updated");





                    con.Close();
                    ShowCustomers();
                    Clear();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }
        int key = 0;
        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            customerName.Text = dataGridView3.CurrentRow.Cells[1].Value.ToString();
            customerphoneno.Text = dataGridView3.CurrentRow.Cells[2].Value.ToString();
          
            if (customerName.Text == "")
            {
                key = 0;
            }
            else
            {
                key = Convert.ToInt32(dataGridView3.CurrentRow.Cells[0].Value.ToString());
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {

            if (key == 0)
            {
                MessageBox.Show("Select the Venue");
            }
            else
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("Delete from Customer where CustId=@Ckey", con);
                    cmd.Parameters.AddWithValue("@CKey", key);


                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Customer information is Deleted");





                    con.Close();
                    ShowCustomers();
                    Clear();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }

        }

        private void pictureBox18_Click(object sender, EventArgs e)
        {
            Feedback obj = new Feedback();
            obj.Show();
            this.Hide();
        }

        private void pictureBox16_Click(object sender, EventArgs e)
        {
            Venue obj = new Venue();
            obj.Show();
            this.Hide();
        }

        private void pictureBox17_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox21_Click(object sender, EventArgs e)
        {
            Form1 obj = new Form1();
            obj.Show();
            this.Hide();
        }

        private void pictureBox15_Click(object sender, EventArgs e)
        {
         
        }

        private void pictureBox70_Click(object sender, EventArgs e)
        {
            Dashboard obj = new Dashboard();
            obj.Show();
            this.Hide();
        }
        }
    }

