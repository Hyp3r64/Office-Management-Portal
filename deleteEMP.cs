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
    public partial class deleteEMP : Form
    {
        public deleteEMP()
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
            dtDelete.DataSource = dt;
            conn.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
                this.WindowState = FormWindowState.Maximized;
            else
                this.WindowState = FormWindowState.Normal;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void deleteEMP_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'finalDBDataSet.userInfo' table. You can move, or remove it, as needed.
            this.userInfoTableAdapter.Fill(this.finalDBDataSet.userInfo);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form3 f = new Form3();
            this.Hide();
            f.Show();
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
            conn.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string name = textBox2.Text;
            var conn = Database.ConnectDB();
            conn.Open();

            string query = string.Format("DELETE FROM userInfo WHERE name='{0}'", name);
            SqlCommand cmd = new SqlCommand(query, conn);
            int r = cmd.ExecuteNonQuery();
            display_data();
            conn.Close();
        }
    }
}
