using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace newproject1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtusername.Text == "nimal" && txtpassword.Text =="nimal123")
            {
                MessageBox.Show("Login Successfully", "Welcome", MessageBoxButtons.OK, MessageBoxIcon.None);
                Form3 frm2 = new Form3();
                this.Hide();
                frm2.Show();


            }
            else
            {
                MessageBox.Show("Invild Login Credencial,Please Check The Username And Paaword And Try Again", "Invalid Login Details", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
        }

        private void btnclear_Click(object sender, EventArgs e)
        {
            txtusername.Clear();
            txtpassword.Clear();
            txtusername.Focus();
        }

        private void btnexit_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Are You Sure, DO You Really Want To EXIT?....", "EXIT", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            Application.Exit();

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                txtpassword.UseSystemPasswordChar = false;
            }
            else
            {
                txtpassword.UseSystemPasswordChar = true;
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Are You Sure?....", "LOGOUT", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            Application.Exit();
        }
    }
}
