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
using System.Collections;

namespace OfficeManagement
{
    public partial class empUpdate : Form
    {
        public empUpdate()
        {
            InitializeComponent();
        }

        private void empUpdate_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'finalDBDataSet3.userInfo' table. You can move, or remove it, as needed.
            this.userInfoTableAdapter.Fill(this.finalDBDataSet3.userInfo);
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

        private void button5_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            this.Hide();
            f1.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string searchName = textBox1.Text;

            var conn = Database.ConnectDB();
            conn.Open();

            string query = string.Format("Select * from userInfo where name='{0}'", searchName);
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataReader reader = cmd.ExecuteReader();
            empType m = new empType();

            while (reader.Read())
            {
                m.Id = reader.GetInt32(reader.GetOrdinal("Id"));
                m.Name = reader.GetString(reader.GetOrdinal("Name"));
                m.Uname = reader.GetString(reader.GetOrdinal("Uname"));
                m.Email = reader.GetString(reader.GetOrdinal("Email"));
            }
            textBox2.Text = m.Name;
            textBox3.Text = m.Uname;
            textBox4.Text = m.Email;
            textBox5.Text = m.Pass;
            textBox6.Text = m.Salary;
            conn.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            int searchId = 0;
            Int32.TryParse(textBox1.Text, out searchId);

            //string name = textBox2.Text;
            //string uname = textBox3.Text;
            //string email = textBox4.Text;
            //var gender = gbGender.Controls.OfType<RadioButton>().FirstOrDefault(rb => rb.Checked).Text;
            //string pass = textBox5.Text;
            //string salary = textBox6.Text;

            string gen = "";

            if (radioButton1.Checked == true)
            {
                gen = radioButton1.Text;
            }
            else
            {
                gen = radioButton2.Text;
            }

            var conn = Database.ConnectDB();
            conn.Open();

            SqlCommand q = conn.CreateCommand();
            q.CommandType = CommandType.Text;
            q.CommandText = " update userInfo set name = '" + textBox2.Text + "', uname = '" + textBox3.Text + "' , email ='" + textBox4.Text + "', gender = '" + gen + "', pass = '" + textBox5.Text + "', salary = '" + textBox6.Text + "' where name = '" + textBox1.Text + "'";
            int r = q.ExecuteNonQuery();

            //string query = string.Format("Update userInfo set name='{0}',uname='{1}',email='{2}',gender='{3}',pass='{4}',salary='{5}' where id={6}", name, uname, email, gender, pass, salary, searchId);
            //SqlCommand cmd = new SqlCommand(query, conn);
            //int r = cmd.ExecuteNonQuery();
            if (r > 0)
            {
                MessageBox.Show("User Info Updated");
            }
            else
            {
                MessageBox.Show("Error");
            }
            conn.Close();
            display_data();
        }
    }
}
