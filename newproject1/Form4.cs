using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Data.SqlClient;
using System.Reflection;
using System.Security.AccessControl;
using System.Security.Cryptography;


namespace newproject1
{
    public partial class Form4 : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-P3H3PCQ\SQLEXPRESS;Initial Catalog=Newdb;Integrated Security=True");
        public Form4()
        {
            InitializeComponent();
        }

        private void Form4_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            Form3 form3 = new Form3();
            this.Hide();
            form3.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBoxScd.Text = String.Empty;
            dateTimePicker2.Text = String.Empty;
            dateTimePicker1.Text = String.Empty;
            LPM.Text = String.Empty;
            textBox5.Clear();
            textBox1.Focus();
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }
        private void button4_Click(object sender, EventArgs e)
        {
            string sqlsearch;
            sqlsearch = "select * from Settings where Setting_ID ='" + textBox1.Text + "'";
            SqlCommand cmd = new SqlCommand(sqlsearch, con);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {

                textBoxScd.Text = dr["Salary_Cycle_Days"].ToString();
                LPM.Text = dr["Leaves_Per_Month"].ToString();
                textBox5.Text = dr["Tax_Rate"].ToString();
                dateTimePicker2.Value = Convert.ToDateTime(dr["Salary_Cycle_Startdate"]);
                dateTimePicker1.Value = Convert.ToDateTime(dr["Salary_Cycle_Enddate"]);
            }
            else
            {
                MessageBox.Show("Employee not found", "", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);


            }
            con.Close();
       }
        private void button5_Click(object sender, EventArgs e)
        {
            try
            {

                string sqlupdate;
                sqlupdate = " update Settings set Setting_ID='" + textBox1.Text + "',Salary_Cycle_Days ='" + textBoxScd.Text + "',Leaves_Per_Month='" + LPM.Text + "',Tax_Rate='" + textBox5.Text + "', Salary_Cycle_Startdate='" + dateTimePicker2.Value + "',Salary_Cycle_Enddate= '" + dateTimePicker1.Value + "' where Setting_ID= '" + textBox1.Text + "'";
                SqlCommand cmd = new SqlCommand(sqlupdate, con);
                con.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Record Updated");

            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message);

            }
            con.Close();
        }
        private void button6_Click(object sender, EventArgs e)
        {

        }
        private void domainUpDown2_SelectedItemChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            this.Close();
            Form2 form3 = new Form2();
            this.Hide();
            form3.Show();
        }
    }
}
