using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class surprised : Form
    {
        public surprised()
        {
            InitializeComponent();
        }

        private void Surprise_Load(object sender, EventArgs e)
        {
            switch (PCBS.super)
            {
                case (8):
                    pictureBox1.Width = 640;
                    pictureBox1.Height = 759;
                    pictureBox1.BackgroundImage = Properties.Resources.gpu2080ti;
                    break;
                case (7):
                    pictureBox1.Width = 900;
                    pictureBox1.Height = 581;
                    pictureBox1.BackgroundImage = Properties.Resources.gputitianxp;
                    break;
                case (6):
                    pictureBox1.Width = 460;
                    pictureBox1.Height = 458;
                    pictureBox1.BackgroundImage = Properties.Resources.gpugtx;
                    break;
                case (5):
                    pictureBox1.Width = 512;
                    pictureBox1.Height = 512;
                    pictureBox1.BackgroundImage = Properties.Resources.gpuradeon;
                    break;
                case (4):
                    pictureBox1.Width = 900;
                    pictureBox1.Height = 581;
                    pictureBox1.BackgroundImage = Properties.Resources.gpurich;
                    break;
            }


        }

        private void Panel1_MouseDown(object sender, MouseEventArgs e)
        {
            Win32.ReleaseCapture();                     //用来释放被当前线程中某个窗口捕获的光标
            Win32.SendMessage(this.Handle, Win32.WM_SYSCOMMAND, Win32.SC_MOVE + Win32.HTCAPTION, 0);//向Windows发送拖动窗体的消息
        }

        private void PictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            Win32.ReleaseCapture();                     //用来释放被当前线程中某个窗口捕获的光标
            Win32.SendMessage(this.Handle, Win32.WM_SYSCOMMAND, Win32.SC_MOVE + Win32.HTCAPTION, 0);//向Windows发送拖动窗体的消息
        }
    }
}