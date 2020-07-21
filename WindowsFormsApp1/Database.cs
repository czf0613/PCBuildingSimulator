using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    class Database
    {
        public string get_info(string name,string value,string key)
        {
            string address = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source = " + name + ".mdb;";
            string sql = "SELECT " + value + " FROM 表1 WHERE ID = " + key;  
            OleDbConnection conn = new OleDbConnection(address);
            conn.Open();
            OleDbCommand cmd = new OleDbCommand(@sql, conn);
            OleDbDataReader dr = cmd.ExecuteReader();
            string ans = "";
            while (dr.Read())
                ans = dr[0].ToString();
            dr.Close();
            conn.Close();
            return ans;
        }
    }
}
