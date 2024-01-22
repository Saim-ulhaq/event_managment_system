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
    public partial class Feedback : Form
    {
        public Feedback()
        {
            InitializeComponent();
            Showfeedback();
            GetEvent();
        }
        private void Showfeedback()
        {
            con.Open();
            string Query = "select * from FeedBack";
            SqlDataAdapter sda = new SqlDataAdapter(Query, con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            dataGridView4.DataSource = ds.Tables[0];

            con.Close();
        }
        private void Clear()
        {
            Evname.Text = "";
            hospitalitycb.SelectedIndex = -1;
            punctualitycb.SelectedIndex = -1;
            venuecb.SelectedIndex = -1;


        }

        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-DIFSIEP\SQLEXPRESS;Initial Catalog=project;Integrated Security=True");
        private void GetEvent()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select EvId from Event", con);
            SqlDataReader Rdr;
            Rdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("EvId", typeof(int));
            dt.Load(Rdr);
            Evidcb.ValueMember = "EvId";
            Evidcb.DataSource = dt;
            con.Close();
        }
        private void GetEventName()
        {
            //con.Open();
            string Query = "select * from Event where EvId = " + Evidcb.SelectedValue.ToString() + "";
            SqlCommand cmd = new SqlCommand(Query, con);
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                Evname.Text = dr["EvName"].ToString();
            }
            con.Close();
        }
        private void button10_Click(object sender, EventArgs e)
        {
             if(Evname.Text == "" || venuecb.SelectedIndex == -1 || hospitalitycb.SelectedIndex == -1 || punctualitycb.SelectedIndex == -1)
            {
                MessageBox.Show("Information is required");
            }
        else
        {
           try
        {
            int OverAll = (hospitalitycb.SelectedIndex + venuecb.SelectedIndex + punctualitycb.SelectedIndex+3)/3;
          con.Open();
          SqlCommand cmd = new SqlCommand("Insert into FeedBack(EvId,EvName,Venue,Punctuality,Hospitality,OverAll)values(@EI,@EN,@V,@P,@H,@OA)",con);
          cmd.Parameters.AddWithValue("@EI",Evidcb.SelectedValue.ToString());
          cmd.Parameters.AddWithValue("@EN", Evname.Text);
          cmd.Parameters.AddWithValue("@V",venuecb.SelectedIndex+1);
          cmd.Parameters.AddWithValue("@P",punctualitycb.SelectedIndex+1);
          cmd.Parameters.AddWithValue("@H",hospitalitycb.SelectedIndex+1);
          cmd.Parameters.AddWithValue("@OA",OverAll);

          cmd.ExecuteNonQuery();
          MessageBox.Show("Feedback is submitted");





          con.Close();
          Showfeedback();
          Clear();
        }
           catch (Exception Ex)
           {
               MessageBox.Show(Ex.Message);
           }
        }


        
        }

        private void Evidcb_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetEventName();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            Customers obj = new Customers();
            obj.Show();
            this.Hide();

        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            Venue obj = new Venue();
            obj.Show();
            this.Hide();
        }

        private void pictureBox24_Click(object sender, EventArgs e)
        {
            Form1 obj = new Form1();
            obj.Show();
            this.Hide();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            
        }

        private void pictureBox69_Click(object sender, EventArgs e)
        {
            Dashboard obj = new Dashboard();
            obj.Show();
            this.Hide();
        }
    }
}
