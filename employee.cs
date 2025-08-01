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
    public partial class employee : Form
    {
        public employee()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();

            string uname = textBox1.Text;
            string pass = textBox2.Text;
            string type = "employee";

            string errMsg = null;

            if (textBox1.Text.Equals(""))
            {
                errMsg += "\nUsername Requried";
            }
            else
            {
                uname = textBox1.Text;
            }

            if (textBox2.Text.Equals(""))
            {
                errMsg += "\nPassword Requried";
            }
            else
            {
                pass = textBox2.Text;
            }

            if (errMsg == null)
            {
                var conn = Database.ConnectDB();
                conn.Open();

                string query = string.Format("Select * from userInfo where uname='{0}'and pass='{1}' and type='{2}'", uname, pass, type);
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    new empUpdate().Show();
                }
                else
                {
                    MessageBox.Show("Not Valid");
                }
                conn.Close();
                clearTB();
            }
            else
            {
                MessageBox.Show(errMsg);
            }
        }

        void clearTB()
        {
            textBox1.Text = "";
            textBox2.Text = "";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            new Form2().Show();
        }
    }
}
