using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace newproject1
{
    public partial class Form5 : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-P3H3PCQ\SQLEXPRESS;Initial Catalog=Newdb;Integrated Security=True");
        public Form5()
        {
            InitializeComponent();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.Close();
            Form3 form3 = new Form3();
            this.Hide();
            form3.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            string sqlsearch;
            sqlsearch = "select * from Settings where Setting_ID ='" + textBox17.Text + "'";
            SqlCommand cmd = new SqlCommand(sqlsearch, con);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {

                textBox1.Text = dr["Salary_Cycle_Days"].ToString();
                textBox2.Text = dr["Leaves_Per_Month"].ToString();
                textBox16.Text = dr["Tax_Rate"].ToString();
                dateTimePicker1.Value = Convert.ToDateTime(dr["Salary_Cycle_Startdate"]);
                dateTimePicker2.Value = Convert.ToDateTime(dr["Salary_Cycle_Enddate"]);
            }
            else
            {
                MessageBox.Show("Employee not found", "", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);


            }
            con.Close();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            try
            {
                int empid = int.Parse(textBox3.Text);
                string query_search = "SELECT * FROM Employee WHERE empid=" + empid;

                SqlCommand cmd = new SqlCommand(query_search, con);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    txtfname.Text = reader["fname"].ToString();
                    txtcontact.Text = reader["contact"].ToString();
                    txtemail.Text = reader["email"].ToString();
                    textBox5.Text = reader["monthlysalary"].ToString();
                    textBox7.Text = reader["allowance"].ToString();
                    textBox6.Text = reader["overtime"].ToString();
                }

                else
                {
                    var res = MessageBox.Show("Employee not found.", "Search Result", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    if (res == DialogResult.OK)
                    {

                        this.Hide();
                        Form2 obj = new Form2();
                        obj.Show();
                    }
                }
                reader.Close();

            }

            catch
            {
                MessageBox.Show("Error while searching: ", "Search Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

            finally
            {
                con.Close();
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {


            textBox3.Clear();
            txtfname.Clear();
            txtcontact.Clear();
            txtemail.Clear();
            textBox5.Clear();
            textBox7.Clear();
            textBox6.Clear();
            textBox3.Focus();
        }

        private void button7_Click(object sender, EventArgs e)
        {

            textBox12.Clear();
            textBox11.Clear();
            textBox10.Clear();
            textBox9.Clear();
            textBox8.Clear();
            textBox13.Clear();
            textBox14.Clear();
            textBox15.Clear();
            textBox12.Focus();
        }

        private void button8_Click_1(object sender, EventArgs e)
        {
            this.Close();
            Form3 form3 = new Form3();
            this.Hide();
            form3.Show();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            float monthly_salary, nopayvalue;
            int noabsentDays, Salary_Cycle_Days;
            monthly_salary = float.Parse(textBox5.Text);

            if (int.TryParse(textBox1.Text, out Salary_Cycle_Days) && int.TryParse(textBox11.Text, out noabsentDays))
            {
                nopayvalue = (monthly_salary / Salary_Cycle_Days) * noabsentDays;
                textBox8.Text = nopayvalue.ToString();
            }
            else
            {
                MessageBox.Show("Invalid user input", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {

            float monthly_salary, overtime_rate, allowance, basepayvalue;
            int overtime_hours;

            monthly_salary = float.Parse(textBox5.Text);
            overtime_rate = float.Parse(textBox6.Text);
            allowance = float.Parse(textBox7.Text);
            overtime_hours = int.Parse(textBox9.Text);
            basepayvalue = monthly_salary + allowance + (overtime_rate * overtime_hours);
            textBox13.Text = basepayvalue.ToString();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            float grosspayvalue, nopayvalue, basepayvalue, Tax_rate;
            nopayvalue = float.Parse(textBox8.Text);
            basepayvalue = float.Parse(textBox13.Text);
            Tax_rate = float.Parse(textBox16.Text);
            grosspayvalue = basepayvalue - (nopayvalue + basepayvalue + Tax_rate / 100);
            textBox14.Text = grosspayvalue.ToString();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            float nopayvalue;
            float basepayvalue;
            float total;

            nopayvalue = float.Parse(textBox8.Text);
            basepayvalue = float.Parse(textBox13.Text);
            total = basepayvalue - nopayvalue;
            textBox15.Text = total.ToString();
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void Form5_Load(object sender, EventArgs e)
        {

        }
    }
}
