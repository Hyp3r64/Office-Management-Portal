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
    public partial class mngemp : Form
    {
        public mngemp()
        {
            InitializeComponent();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

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

        private void button2_Click(object sender, EventArgs e)
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
            q.CommandText = " update userInfo set name = '" + textBox2.Text + "', uname = '" + textBox3.Text + "' , email ='" + textBox4.Text + "', gender = '" + gen + "', pass = '" + textBox5.Text + "' salary = pass = '" + textBox6.Text + "' where name = '" + textBox1.Text + "'";
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

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void mngemp_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'finalDBDataSet1.userInfo' table. You can move, or remove it, as needed.
            this.userInfoTableAdapter.Fill(this.finalDBDataSet1.userInfo);

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

        }
    }
}
