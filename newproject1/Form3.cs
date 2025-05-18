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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 Form2 = new Form2();
            this.Hide();
            Form2.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form5 Form5 = new Form5();
            this.Hide();
            Form5.Show();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form4 Form4 = new Form4();
            this.Hide();
            Form4.Show();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
            Form1 form1 = new Form1();
            this.Hide();
            form1.Show();
        }
    }
}
