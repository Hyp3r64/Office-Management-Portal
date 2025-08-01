using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace OfficeManagement
{
    class Database
    {
        static SqlConnection conn;
        public static SqlConnection ConnectDB()
        {
            string connString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Arik\Documents\FinalDB.mdf;Integrated Security=True;Connect Timeout=30";
            conn = new SqlConnection(connString);
            return conn;
        }
    }
}
