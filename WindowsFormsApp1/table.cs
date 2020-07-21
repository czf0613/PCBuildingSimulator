using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;


namespace WindowsFormsApp1
{
    public partial class table : Form
    {
        public table()
        {
            InitializeComponent();
        }
        public static PictureBox Tem_PictB = new PictureBox();
        public void ImageSwitch(object sender, int ns)
        {
            Tem_PictB = (PictureBox)sender;
            Tem_PictB.BackgroundImage = null;                             //清空图片
            if (ns == 0)                                        //鼠标移入
                Tem_PictB.BackgroundImage = Properties.Resources.quit2;
            else if (ns == 1)                                        //鼠标移出
                Tem_PictB.BackgroundImage = Properties.Resources.quit1;
        }



        private void Table_MouseDown(object sender, MouseEventArgs e)
        {
            Win32.ReleaseCapture();                     //用来释放被当前线程中某个窗口捕获的光标
            Win32.SendMessage(this.Handle, Win32.WM_SYSCOMMAND, Win32.SC_MOVE + Win32.HTCAPTION, 0);//向Windows发送拖动窗体的消息
        }

        private void DataGridView1_MouseDown(object sender, MouseEventArgs e)
        {
            Win32.ReleaseCapture();                     //用来释放被当前线程中某个窗口捕获的光标
            Win32.SendMessage(this.Handle, Win32.WM_SYSCOMMAND, Win32.SC_MOVE + Win32.HTCAPTION, 0);//向Windows发送拖动窗体的消息
        }

        private void PictureBox1_MouseEnter(object sender, EventArgs e)
        {
            ImageSwitch(sender, 1);
        }

        private void PictureBox1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void PictureBox1_MouseLeave(object sender, EventArgs e)
        {
            ImageSwitch(sender, 0);
        }

        string name;

        private void Table_Load(object sender, EventArgs e)
        {
            if (PCBS.hardware == 1)
            {
                name = "CPU";
                string address = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + name + ".mdb;";
                OleDbConnection conn = new OleDbConnection(address);
                string sql = "SELECT * FROM 表1";
                OleDbCommand cmd = conn.CreateCommand();
                cmd.CommandText = sql;
                conn.Open();
                OleDbDataReader dr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                if (dr.HasRows)
                {
                    for (int i = 0; i < 8; i++)
                    {
                        dt.Columns.Add(dr.GetName(i));
                    }
                    dt.Rows.Clear();
                }
                while (dr.Read())
                {
                    DataRow row = dt.NewRow();
                    for (int i = 0; i < 8; i++)
                    {
                        row[i] = dr[i];
                    }
                    dt.Rows.Add(row);
                }
                cmd.Dispose();
                conn.Close();
                dataGridView1.DataSource = dt;
            }
            else if (PCBS.hardware == 2)
            {
                name = "Mainboard";
                string address = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + name + ".mdb;";
                OleDbConnection conn = new OleDbConnection(address);
                string sql = "SELECT * FROM 表1";
                OleDbCommand cmd = conn.CreateCommand();
                cmd.CommandText = sql;
                conn.Open();
                OleDbDataReader dr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                if (dr.HasRows)
                {
                    for (int i = 0; i < 6; i++)
                    {
                        dt.Columns.Add(dr.GetName(i));
                    }
                    dt.Rows.Clear();
                }
                while (dr.Read())
                {
                    DataRow row = dt.NewRow();
                    for (int i = 0; i < 6; i++)
                    {
                        row[i] = dr[i];
                    }
                    dt.Rows.Add(row);
                }
                cmd.Dispose();
                conn.Close();
                dataGridView1.DataSource = dt;
            }
            else if (PCBS.hardware == 3)
            {
                name = "GPU";
                string address = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + name + ".mdb;";
                OleDbConnection conn = new OleDbConnection(address);
                string sql = "SELECT * FROM 表1";
                OleDbCommand cmd = conn.CreateCommand();
                cmd.CommandText = sql;
                conn.Open();
                OleDbDataReader dr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                if (dr.HasRows)
                {
                    for (int i = 0; i < 6; i++)
                    {
                        dt.Columns.Add(dr.GetName(i));
                    }
                    dt.Rows.Clear();
                }
                while (dr.Read())
                {
                    DataRow row = dt.NewRow();
                    for (int i = 0; i < 6; i++)
                    {
                        row[i] = dr[i];
                    }
                    dt.Rows.Add(row);
                }
                cmd.Dispose();
                conn.Close();
                dataGridView1.DataSource = dt;
            }
            else if (PCBS.hardware == 4)
            {
                name = "Memory";
                string address = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + name + ".mdb;";
                OleDbConnection conn = new OleDbConnection(address);
                string sql = "SELECT * FROM 表1";
                OleDbCommand cmd = conn.CreateCommand();
                cmd.CommandText = sql;
                conn.Open();
                OleDbDataReader dr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                if (dr.HasRows)
                {
                    for (int i = 0; i < 5; i++)
                    {
                        dt.Columns.Add(dr.GetName(i));
                    }
                    dt.Rows.Clear();
                }
                while (dr.Read())
                {
                    DataRow row = dt.NewRow();
                    for (int i = 0; i < 5; i++)
                    {
                        row[i] = dr[i];
                    }
                    dt.Rows.Add(row);
                }
                cmd.Dispose();
                conn.Close();
                dataGridView1.DataSource = dt;
            }
            else if (PCBS.hardware == 5)
            {
                name = "PSU";
                string address = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + name + ".mdb;";
                OleDbConnection conn = new OleDbConnection(address);
                string sql = "SELECT * FROM 表1";
                OleDbCommand cmd = conn.CreateCommand();
                cmd.CommandText = sql;
                conn.Open();
                OleDbDataReader dr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                if (dr.HasRows)
                {
                    for (int i = 0; i < 4; i++)
                    {
                        dt.Columns.Add(dr.GetName(i));
                    }
                    dt.Rows.Clear();
                }
                while (dr.Read())
                {
                    DataRow row = dt.NewRow();
                    for (int i = 0; i < 4; i++)
                    {
                        row[i] = dr[i];
                    }
                    dt.Rows.Add(row);
                }
                cmd.Dispose();
                conn.Close();
                dataGridView1.DataSource = dt;
            }
            else if (PCBS.hardware == 6)
            {
                name = "Driver";
                string address = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + name + ".mdb;";
                OleDbConnection conn = new OleDbConnection(address);
                string sql = "SELECT * FROM 表1";
                OleDbCommand cmd = conn.CreateCommand();
                cmd.CommandText = sql;
                conn.Open();
                OleDbDataReader dr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                if (dr.HasRows)
                {
                    for (int i = 0; i < 5; i++)
                    {
                        dt.Columns.Add(dr.GetName(i));
                    }
                    dt.Rows.Clear();
                }
                while (dr.Read())
                {
                    DataRow row = dt.NewRow();
                    for (int i = 0; i < 5; i++)
                    {
                        row[i] = dr[i];
                    }
                    dt.Rows.Add(row);
                }
                cmd.Dispose();
                conn.Close();
                dataGridView1.DataSource = dt;
            }
        }

        private void Submit_Click(object sender, EventArgs e)
        {
            PCBS.IDChossen = int.Parse(textBox1.Text);
            this.Hide();
        }

        private void Submit_MouseEnter(object sender, EventArgs e)
        {
            submit.BackgroundImage = Properties.Resources.submit2;
        }

        private void Submit_MouseLeave(object sender, EventArgs e)
        {
            submit.BackgroundImage = Properties.Resources.submit1;
        }
        
    }
}
