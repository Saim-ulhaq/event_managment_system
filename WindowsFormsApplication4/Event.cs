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
    public partial class Event : Form
    {
        public Event()
        {
            InitializeComponent();
            ShowEvents();
            GetVenue();
            GetCustomer();
        }
        private void ShowEvents()
        {
            con.Open();
            string Query = "select * from Event";
            SqlDataAdapter sda = new SqlDataAdapter(Query, con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            dataGridView9.DataSource = ds.Tables[0];

            con.Close();
        }
        private void Clear()
        {
            EvName.Text = "";
            custname.Text = "";
            Evduration.Text = "";
            Evstatuscb.SelectedIndex = -1;
            Vname.Text = "";

 }

        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-DIFSIEP\SQLEXPRESS;Initial Catalog=project;Integrated Security=True");
        private void GetCustomer()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select CustId from Customer", con);
            SqlDataReader Rdr;
            Rdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("CustId", typeof(int));
            dt.Load(Rdr);
            custidcb.ValueMember = "CustId";
            custidcb.DataSource = dt;
            con.Close();
        }
        private void GetCustomerName()
        {
            //con.Open();
            string Query = "select * from Customer where CustId =" + custidcb.SelectedValue.ToString() + "";
            SqlCommand cmd = new SqlCommand(Query, con);
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                custname.Text = dr["CustName"].ToString();
            }
            con.Close();
        }
        private void GetVenue()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select VenueId from Venue", con);
            SqlDataReader Rdr;
            Rdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("VenueId", typeof(int));
            dt.Load(Rdr);
            Venueidcb.ValueMember = "VenueId";
            Venueidcb.DataSource = dt;
            con.Close();
        }
        private void GetVenueName()
        {
            
            //con.Open();
            string Query = "select * from Venue where VenueId =" + Venueidcb.SelectedValue.ToString() + "";
            SqlCommand cmd = new SqlCommand(Query, con);
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                Vname.Text = dr["VenueName"].ToString();
            }
            con.Close();
        }
        private void button37_Click(object sender, EventArgs e)
        {
             if(EvName.Text == "" || Vname.Text == "" || custname.Text == "" || Evduration.Text == "" || Evstatuscb.SelectedIndex == -1)

            {
                MessageBox.Show("Information is required");
            }
        else
        {
           try
        {
          con.Open();
          SqlCommand cmd = new SqlCommand("Insert into Event(EvName,EvDate,VenueId,EvVenue,EvDuration,EvCustId,EvCustName,EvStatus)values(@EN,@ED,@VI,@EV,@EDU,@ECI,@ECN,@ES)",con);
          cmd.Parameters.AddWithValue("@EN",EvName.Text);
          cmd.Parameters.AddWithValue("@ED",dateTimePicker1.Value.Date);
          cmd.Parameters.AddWithValue("@VI",Venueidcb.SelectedValue.ToString());
          cmd.Parameters.AddWithValue("@EV",Vname.Text);
          cmd.Parameters.AddWithValue("@EDU",Evduration.Text);
          cmd.Parameters.AddWithValue("@ECI", custidcb.SelectedValue.ToString());
          cmd.Parameters.AddWithValue("@ECN", custname.Text);
          cmd.Parameters.AddWithValue("@ES", Evstatuscb.SelectedItem.ToString());

          cmd.ExecuteNonQuery();
          MessageBox.Show("Event is Added");





          con.Close();
          ShowEvents();
          Clear();
        }
           catch (Exception Ex)
           {
               MessageBox.Show(Ex.Message);
           }
        }


        }
        

        private void Venueidcb_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetVenueName();
        }

        private void custidcb_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetCustomerName();
        }

        private void button35_Click(object sender, EventArgs e)
        {
            if (EvName.Text == "" || Vname.Text == "" || custname.Text == "" || Evduration.Text == "" || Evstatuscb.SelectedIndex == -1)
            {
                MessageBox.Show("Information is required");
            }
            else
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("update Event set EvName=@EN,EvDate=@ED,VenueId=@VI,EvVenue=@EV,EvDuration=@EDU,EvCustId=@ECI,EvCustName=@ECN,EvStatus=@ES where EvId=@Ekey", con);
                    cmd.Parameters.AddWithValue("@EN", EvName.Text);
                    cmd.Parameters.AddWithValue("@ED", dateTimePicker1.Value.Date);
                    cmd.Parameters.AddWithValue("@VI", Venueidcb.SelectedValue.ToString());
                    cmd.Parameters.AddWithValue("@EV", Vname.Text);
                    cmd.Parameters.AddWithValue("@EDU", Evduration.Text);
                    cmd.Parameters.AddWithValue("@ECI", custidcb.SelectedValue.ToString());
                    cmd.Parameters.AddWithValue("@ECN", custname.Text);
                    cmd.Parameters.AddWithValue("@ES", Evstatuscb.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@Ekey", key);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Event is updated");





                    con.Close();
                    ShowEvents();
                    Clear();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
            

        }
        int key = 0;
        private void dataGridView9_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            EvName.Text = dataGridView9.CurrentRow.Cells[1].Value.ToString();
            dateTimePicker1.Text = dataGridView9.CurrentRow.Cells[2].Value.ToString();
            Venueidcb.SelectedValue = dataGridView9.CurrentRow.Cells[3].Value.ToString();
            Vname.Text = dataGridView9.CurrentRow.Cells[4].Value.ToString();
            Evduration.Text = dataGridView9.CurrentRow.Cells[5].Value.ToString();
            custidcb.SelectedValue = dataGridView9.CurrentRow.Cells[6].Value.ToString();
            custname.Text = dataGridView9.CurrentRow.Cells[7].Value.ToString();
            Evstatuscb.SelectedItem = dataGridView9.CurrentRow.Cells[8].Value.ToString();
            if (EvName.Text == "")
            {
                key = 0;
            }
            else
            {
                key = Convert.ToInt32(dataGridView9.CurrentRow.Cells[0].Value.ToString());
            }
        }

        private void button36_Click(object sender, EventArgs e)
        {
            if (key == 0)
            {
                MessageBox.Show("Select the Event");
            }
            else
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("Delete from Event where EvId=@Ekey", con);
                    cmd.Parameters.AddWithValue("@EKey", key);


                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Event is Deleted");





                    con.Close();
                    ShowEvents();
                    Clear();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Feedback obj = new Feedback();
            obj.Show();
            this.Hide();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Customers obj = new Customers();
            obj.Show();
            this.Hide();
        }

        private void pictureBox21_Click(object sender, EventArgs e)
        {
            Form1 obj = new Form1();
            obj.Show();
            this.Hide();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Venue obj = new Venue();
            obj.Show();
            this.Hide();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
           
        }

        private void pictureBox68_Click(object sender, EventArgs e)
        {
            Dashboard obj = new Dashboard();
            obj.Show();
            this.Hide();
        }
    }
}
