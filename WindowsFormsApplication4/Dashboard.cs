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
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
            CountEvents();
            CountCustomers();
            CountVenues();
            CountExcellent();
            CountGood();
            CountOkay();
            CountBad();
        }
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-DIFSIEP\SQLEXPRESS;Initial Catalog=project;Integrated Security=True");
        private void CountEvents()
        {
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("select count(*) from Event",con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            EventC.Text = dt.Rows[0][0].ToString();
            con.Close();
        }
        private void CountExcellent()
        {
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("select count(*) from FeedBack where OverAll = "+4+"", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            ExcellentC.Text = dt.Rows[0][0].ToString();
            con.Close();
        }
        private void CountGood()
        {
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("select count(*) from FeedBack where OverAll = " + 3 + "", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            GoodC.Text = dt.Rows[0][0].ToString();
            con.Close();
        }
        private void CountOkay()
        {
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("select count(*) from FeedBack where OverAll = " + 2 + "", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            OkayC.Text = dt.Rows[0][0].ToString();
            con.Close();
        }
        private void CountBad()
        {
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("select count(*) from FeedBack where OverAll = " + 1 + "", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            BadC.Text = dt.Rows[0][0].ToString();
            con.Close();
        }
        private void CountCustomers()
        {
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("select count(*) from Customer", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            CustomerC.Text = dt.Rows[0][0].ToString();
            con.Close();
        }
        private void CountVenues()
        {
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("select count(*) from Venue", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            VenueC.Text = dt.Rows[0][0].ToString();
            con.Close();
        }
        private void Dashboard_Load(object sender, EventArgs e)
        {

        }

        private void label51_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox63_Click(object sender, EventArgs e)
        {
            Form1 obj = new Form1();
            obj.Show();
            this.Hide();
        }

        private void pictureBox65_Click(object sender, EventArgs e)
        {
            Feedback obj = new Feedback();
            obj.Show();
            this.Hide();
        }

        private void pictureBox64_Click(object sender, EventArgs e)
        {
            Customers obj = new Customers();
            obj.Show();
            this.Hide();
        }

        private void pictureBox62_Click(object sender, EventArgs e)
        {
            Venue obj = new Venue();
            obj.Show();
            this.Hide();
        }

        private void pictureBox673_Click(object sender, EventArgs e)
        {
           Event obj = new Event();
            obj.Show();
            this.Hide();
        }
    }
}
