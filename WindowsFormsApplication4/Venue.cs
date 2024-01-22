using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace WindowsFormsApplication4
{
    public partial class Venue : Form
    {
        public Venue()
        {
            InitializeComponent();
            ShowVenue();
            
        }

        private void ShowVenue()
        {
            con.Open();
            string Query = "select * from Venue";
            SqlDataAdapter sda = new SqlDataAdapter(Query, con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            dataGridView5.DataSource = ds.Tables[0];

            con.Close();
        }
        private void Clear()
        {
            VenueName.Text = "";
            Vphoneno.Text = "";
            Venuecapacity.Text = "";
            Vaddress.Text = "";
            Vmanager.Text = "";
        }

        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-DIFSIEP\SQLEXPRESS;Initial Catalog=project;Integrated Security=True");
        private void button13_Click(object sender, EventArgs e)
        {
            if(Vaddress.Text =="" || VenueName.Text == "" || Vphoneno.Text == "" || Venuecapacity.Text == "" || Vmanager.Text == "")
            {
                MessageBox.Show("Information is required");
            }
        else
        {
           try
        {
          con.Open();
          SqlCommand cmd = new SqlCommand("Insert into Venue(VenueName,VenueCapacity,Venueaddress,VenueManager,Vphoneno)values(@VN,@VC,@VA,@VM,@VP)",con);
          cmd.Parameters.AddWithValue("@VN",VenueName.Text);
          cmd.Parameters.AddWithValue("@VC",Venuecapacity.Text);
          cmd.Parameters.AddWithValue("@VA",Vaddress.Text);
          cmd.Parameters.AddWithValue("@VM",Vmanager.Text);
          cmd.Parameters.AddWithValue("@VP",Vphoneno.Text);

          cmd.ExecuteNonQuery();
          MessageBox.Show("Venue is Added");





          con.Close();
          ShowVenue();
          Clear();
        }
           catch (Exception Ex)
           {
               MessageBox.Show(Ex.Message);
           }
        }


        }
        int key = 0;
        private void dataGridView5_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            VenueName.Text = dataGridView5.CurrentRow.Cells[1].Value.ToString();
            Venuecapacity.Text = dataGridView5.CurrentRow.Cells[2].Value.ToString();
            Vaddress.Text = dataGridView5.CurrentRow.Cells[3].Value.ToString();
            Vmanager.Text = dataGridView5.CurrentRow.Cells[4].Value.ToString();
            Vphoneno.Text = dataGridView5.CurrentRow.Cells[5].Value.ToString();
            if (VenueName.Text == "")
            {
                key = 0;
            }
            else
            {
                key = Convert.ToInt32(dataGridView5.CurrentRow.Cells[0].Value.ToString());
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            if(key== 0)
            {
                MessageBox.Show("Select the Venue");
            }
        else
        {
           try
        {
          con.Open();
          SqlCommand cmd = new SqlCommand("Delete from Venue where VenueId=@Vkey",con);
          cmd.Parameters.AddWithValue("@VKey", key);
       

          cmd.ExecuteNonQuery();
          MessageBox.Show("Venue is Deleted");





          con.Close();
          ShowVenue();
          Clear();
        }
           catch (Exception Ex)
           {
               MessageBox.Show(Ex.Message);
           }
        }


        }

        private void button14_Click(object sender, EventArgs e)
        {
            if (Vaddress.Text == "" || VenueName.Text == "" || Vphoneno.Text == "" || Venuecapacity.Text == "" || Vmanager.Text == "")
            {
                MessageBox.Show("Information is required");
            }
        else
        {
           try
        {
          con.Open();
          SqlCommand cmd = new SqlCommand("update Venue set VenueName=@VN,VenueCapacity=@VC,Venueaddress=@VA,VenueManager=@VM,Vphoneno=@VP where VenueId=@Vkey",con);
          cmd.Parameters.AddWithValue("@VN",VenueName.Text);
          cmd.Parameters.AddWithValue("@VC",Venuecapacity.Text);
          cmd.Parameters.AddWithValue("@VA",Vaddress.Text);
          cmd.Parameters.AddWithValue("@VM",Vmanager.Text);
          cmd.Parameters.AddWithValue("@VP",Vphoneno.Text);
          cmd.Parameters.AddWithValue("@Vkey",key);
          cmd.ExecuteNonQuery();
          MessageBox.Show("Venue is Updated");





          con.Close();
          ShowVenue();
          Clear();
        }
           catch (Exception Ex)
           {
               MessageBox.Show(Ex.Message);
           }
        }


        }

        private void pictureBox12_Click(object sender, EventArgs e)
        {
            Feedback obj = new Feedback();
            obj.Show();
            this.Hide();
        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {
            Customers obj = new Customers();
            obj.Show();
            this.Hide();
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            Event obj = new Event();
            obj.Show();
            this.Hide();
        }

        private void pictureBox22_Click(object sender, EventArgs e)
        {
            Form1 obj = new Form1();
            obj.Show();
            this.Hide();
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
           
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Dashboard obj = new Dashboard();
            obj.Show();
            this.Hide();
        }
        }
        }
    


