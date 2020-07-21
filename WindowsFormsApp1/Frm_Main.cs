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
    public partial class PCBS : Form
    {
        public PCBS()
        {
            InitializeComponent();
        }
        public static int hardware = 4;
        public static int IDChossen = 2;
        public static int super = 9;
        private void PCBS_Load(object sender, EventArgs e)
        {
            pictureBox1.Image = null;                                       //清空PictuteBox控件
            pictureBox1.Image = Properties.Resources.begin1;                  //显示开始游戏的图片
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.Image = null;                                       //清空PictuteBox控件
            pictureBox2.Image = Properties.Resources.quit1;                //显示退出游戏的图片
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
        }
        public static PictureBox Tem_PictB = new PictureBox();
        public void ImageSwitch(object sender, int n, int ns)
        {
            Tem_PictB = (PictureBox)sender;
            switch (n)                                                  //获取标识
            {
                case 0:                                                 //当前为开始游戏按钮
                    {
                        Tem_PictB.Image = null;                             //清空图片
                        if (ns == 0)                                        //鼠标移入
                            Tem_PictB.Image = Properties.Resources.begin2;
                        else if (ns == 1)                                        //鼠标移出
                            Tem_PictB.Image = Properties.Resources.begin1;
                        break;
                    }
                case 1:                                                 //退出按钮
                    {
                        Tem_PictB.Image = null;
                        if (ns == 0)
                            Tem_PictB.Image = Properties.Resources.quit2;
                        else if (ns == 1)
                            Tem_PictB.Image = Properties.Resources.quit1;
                        break;
                    }
            }
        }
        private void PictureBox1_MouseEnter(object sender, EventArgs e)//鼠标移入事件
        {
            ImageSwitch(sender, Convert.ToInt16(((PictureBox)sender).Tag.ToString()), 0);
        }
        private void PictureBox1_MouseLeave(object sender, EventArgs e)//鼠标移出事件
        {
            ImageSwitch(sender, Convert.ToInt16(((PictureBox)sender).Tag.ToString()), 1);
        }
        private void PictureBox2_MouseEnter(object sender, EventArgs e)
        {
            ImageSwitch(sender, Convert.ToInt16(((PictureBox)sender).Tag.ToString()), 0);
        }
        private void PictureBox2_MouseLeave(object sender, EventArgs e)
        {
            ImageSwitch(sender, Convert.ToInt16(((PictureBox)sender).Tag.ToString()), 1);
        }
        public void FrmClickMeans(Form Frm_Tem, int n)
        {
            switch (n)                                                  //操作样式
            {
                case 0:                                                 //开始游戏
                    Frm_game game = new Frm_game();   //切换到另一个窗体
                    this.Hide();
                    game.Show();
                    break;
                case 1:                                                 //关闭窗体
                    Application.ExitThread();
                    break;
            }
        }
        private void PictureBox1_Click(object sender, EventArgs e)
        {
            FrmClickMeans(this, Convert.ToInt16(((PictureBox)sender).Tag.ToString()));//切换到另一个窗体
        }
        private void PictureBox2_Click(object sender, EventArgs e)
        {
            FrmClickMeans(this, Convert.ToInt16(((PictureBox)sender).Tag.ToString()));//关闭窗体
        }

        private void Panel1_MouseDown(object sender, MouseEventArgs e)
        {
            Win32.ReleaseCapture();                     //用来释放被当前线程中某个窗口捕获的光标
            Win32.SendMessage(this.Handle, Win32.WM_SYSCOMMAND, Win32.SC_MOVE + Win32.HTCAPTION, 0);//向Windows发送拖动窗体的消息
        }
        private void PCBS_SizeChanged(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Normal)         //判断窗体是否为正常状态
                notifyIcon1.Visible = false;                        //隐藏托盘图标
            else if (this.WindowState == FormWindowState.Minimized) //判断窗体是否为最小化状态
            {
                this.Hide();                                        //隐藏当前窗体
                notifyIcon1.Visible = true;                     //显示托盘图标
            }
        }

        private void NotifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)      //判断窗体是否为最小化状态
            {
                this.Show();                                        //显示当前窗体
                this.WindowState = FormWindowState.Normal;          //还原窗体
            }
        }
        private void resumeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NotifyIcon1_MouseDoubleClick(null, null);               //托盘图标快捷菜单
        }
        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.ExitThread();
        }

        private void Panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
