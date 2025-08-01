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
    public partial class investorUpdate : Form
    {
        public investorUpdate()
        {
            InitializeComponent();
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

        private void investorUpdate_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'finalDBDataSet4.userInfo' table. You can move, or remove it, as needed.
            this.userInfoTableAdapter.Fill(this.finalDBDataSet4.userInfo);

        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1();
            this.Hide();
            f.Show();
        }
    }
}
