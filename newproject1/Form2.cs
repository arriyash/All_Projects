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
    public partial class Form2 : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-P3H3PCQ\SQLEXPRESS;Initial Catalog=Newdb;Integrated Security=True");
        public Form2()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btninsert_Click(object sender, EventArgs e)
        {
            try
            {
                int empid = int.Parse(textBox1.Text);
                string fname = txtfname.Text;
                string lname = txtlname.Text;
                int contact = int.Parse(txtcontact.Text);

                string email = txtemail.Text;

                int monthlysalary = int.Parse(txtmsalary.Text);
                int overtime = int.Parse(txtotrate.Text);
                int allowance = int.Parse(txtallowance.Text);


                string query_insert = "INSERT INTO Employee VALUES(" + empid + ", '" + fname + "', '" + lname + "', " + contact + ", '" + email + "', " + monthlysalary + ", " + overtime + ", " + allowance + ")";


                SqlCommand cmd = new SqlCommand(query_insert, con);
                con.Open();
                cmd.ExecuteNonQuery();

                var res = MessageBox.Show("Insert successfully!", "Register Employee", MessageBoxButtons.OK,
               MessageBoxIcon.Information);
                if (res == DialogResult.OK)
                {
                    Form2 frm3 = new Form2();
                    this.Hide();
                    frm3.Show();







                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("error while inserting!" + ex.Message);


            }
            finally
            {
                con.Close();
               


            }

        }

        private void btnback_Click(object sender, EventArgs e)
        {
            this.Close();
            Form3 form3 = new Form3();
            this.Hide();
            form3.Show();




        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void btnclear_Click(object sender, EventArgs e)
        {

            textBox1.Clear();
            txtfname.Clear();
            txtlname.Clear();
            txtcontact.Clear();
            txtemail.Clear();
            txtmsalary.Clear();
            txtallowance.Clear();
            txtotrate.Clear();
            textBox1.Focus();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                int empid = int.Parse(textBox1.Text);
                string query_search = "SELECT * FROM Employee WHERE empid=" + empid;

                SqlCommand cmd = new SqlCommand(query_search, con);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    txtfname.Text = reader["fname"].ToString();
                    txtlname.Text = reader["lname"].ToString();
                    txtcontact.Text = reader["contact"].ToString();
                    txtemail.Text = reader["email"].ToString();
                    txtmsalary.Text = reader["monthlysalary"].ToString();
                    txtallowance.Text = reader["allowance"].ToString();
                    txtotrate.Text = reader["overtime"].ToString();
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

        private void button1_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Are you sure you want to Delete this Record?", "Delete Record", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {

                string empid = textBox1.Text;
                string query_delete = "DELETE FROM employee WHERE empid=" + empid + "  ";

                con.Open();
                SqlCommand cmnd = new SqlCommand(query_delete, con);
                cmnd.ExecuteNonQuery();
                con.Close();

                var res = MessageBox.Show("Record deleted Successfully !", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                if (res == DialogResult.OK)
                {

                    this.Hide();
                    Form2 obj = new Form2();
                    obj.Show();
                }

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                int empid = int.Parse(textBox1.Text);
                string fname = txtfname.Text;
                string lname = txtlname.Text;
                int contact = int.Parse(txtcontact.Text);
                string email = txtemail.Text;
                int monthlysalary = int.Parse(txtmsalary.Text);
                int overtime = int.Parse(txtotrate.Text);
                int allowance = int.Parse(txtallowance.Text);

                string query_update = "UPDATE employee SET empid='" + textBox1.Text + "',fname = '" + txtfname.Text + "', lname = '" + txtlname.Text + "', contact = '" + txtcontact.Text + "', email = '" + txtemail.Text + "', monthlysalary = '" + txtmsalary.Text + "', overtime = '" + txtotrate.Text + "', allowance = '" + txtallowance.Text + "' where empid='" + textBox1.Text + "' ";

                con.Open();
                SqlCommand cmnd = new SqlCommand(query_update, con);
                cmnd.ExecuteNonQuery();
                con.Close();
                var res = MessageBox.Show("Record Updated Successfully!", "Record Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);

                if (res == DialogResult.OK)
                {
                    this.Hide();
                    Form2 obj = new Form2();
                    obj.Show();
                }
            }

            catch
            {
                MessageBox.Show("error while saving!");
            }
            finally
            {
                con.Close();
            }

        }
    }
}
