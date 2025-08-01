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
    public partial class addemp : Form
    {
        public addemp()
        {
            InitializeComponent();
        }

        public void display_data()
        {
            var conn = Database.ConnectDB();
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from userInfo";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            conn.Close();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void min_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void max_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
                this.WindowState = FormWindowState.Maximized;
            else
                this.WindowState = FormWindowState.Normal;
        }

        private void close_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void addemp_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'finalDBDataSet2.userInfo' table. You can move, or remove it, as needed.
            this.userInfoTableAdapter.Fill(this.finalDBDataSet2.userInfo);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string name = textBox1.Text;
            string uname = textBox2.Text;
            string email = textBox3.Text;
            var gender = gbGender.Controls.OfType<RadioButton>().FirstOrDefault(rb => rb.Checked).Text;
            string pass = textBox4.Text;
            string type = "employee";
            string salary = textBox5.Text;

            var conn = Database.ConnectDB();
            conn.Open();

            string query = string.Format("Insert into userInfo values ('{0}','{1}','{2}','{3}','{4}','{5}','{6}')", name, uname, email, gender, pass, type, salary);
            SqlCommand cmd = new SqlCommand(query, conn);
            int r = cmd.ExecuteNonQuery();
            if (r > 0)
            {
                MessageBox.Show("New Manager Added");
            }
            else
            {
                MessageBox.Show("Error");
            }
            
            conn.Close();
            display_data();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            string sss = "NULL";

            if (radioButton1.Checked == true)
            {
                sss = "NULL";
            }
            else if (radioButton2.Checked == true)
            {
                sss = "NULL";
            }
            textBox4.Text = "";
            textBox5.Text = "";
        }
    }
}
