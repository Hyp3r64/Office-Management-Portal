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

namespace OfficeManagement
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit(); 
        }

        private void close_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void max_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
                this.WindowState = FormWindowState.Maximized;
            else
                this.WindowState = FormWindowState.Normal;
        }

        private void min_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1();
            f.Show();
            this.Hide();
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            string name = textBox1.Text;
            string uname = textBox2.Text;
            string email = textBox3.Text;
            var gender = gbGender.Controls.OfType<RadioButton>().FirstOrDefault(rb => rb.Checked).Text;
            string pass = textBox5.Text;
            string type = "employee";
            string salary = "";

            string errMsg = null;

            if (textBox1.Text.Equals(""))
            {
                errMsg += "\nName Requried";
            }
            else
            {
                name = textBox1.Text;
            }

            if (textBox2.Text.Equals(""))
            {
                errMsg += "\nUsername Requried";
            }
            else
            {
                uname = textBox2.Text;
            }

            if (textBox3.Text.Equals(""))
            {
                errMsg += "\nEmail Requried";
            }
            else
            {
                email = textBox3.Text;
            }
            if (textBox5.Text.Equals(""))
            {
                errMsg += "\nPassword Requried";
            }
            else
            {
                pass = textBox5.Text;
            }


            if (errMsg == null)
            {
                var conn = Database.ConnectDB();
                conn.Open();

                string query = string.Format("Insert into userInfo values ('{0}','{1}','{2}','{3}','{4}','{5}','{6}')", name, uname, email, gender, pass, type, salary);
                SqlCommand cmd = new SqlCommand(query, conn);
                int r = cmd.ExecuteNonQuery();
                if (r > 0)
                {
                    MessageBox.Show("New Account Created");
                    new mngemp().Show();        
                }
                else
                {
                    MessageBox.Show("Error");
                    new Form1().Show();
                }
                conn.Close();
                RefreshControls();
            }
            else
            {
                MessageBox.Show(errMsg);
            }
        }
        void RefreshControls()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox5.Text = "";
        }
    }
}
