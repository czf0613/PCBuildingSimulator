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
    public partial class Frm_game : Form
    {
        public Frm_game()
        {
            InitializeComponent();
        }
        Event t;
        Check check;
        public string str;
        Database db = new Database();
        public static void change(int n)
        {
            PCBS.hardware = n;
        }
        private void Frm_game_Load(object sender, EventArgs e)
        {
            panel1.BackgroundImage = Properties.Resources.背景;
            #region 创建TreeNode对象作为父节点
            TreeNode tn1 = new TreeNode("CPU");
            TreeNode tn2 = new TreeNode("Mainboard");
            TreeNode tn3 = new TreeNode("GPU");
            TreeNode tn4 = new TreeNode("Memory");
            TreeNode tn5 = new TreeNode("Driver");
            TreeNode tn6 = new TreeNode("PSU");
            TreeNode tn7 = new TreeNode("Case");
            TreeNode tn8 = new TreeNode("Software");
            #endregion
            #region CPU父节点的子节点
            tn1.Nodes.Add("CPU Model Type");
            tn1.Nodes.Add("Clock Speed");
            tn1.Nodes.Add("Cores");
            tn1.Nodes.Add("Threads");
            tn1.Nodes.Add("CPU TDP");
            #endregion
            #region Mainboard父节点的子节点
            tn2.Nodes.Add("Mainboard Model Type");
            tn2.Nodes.Add("BIOS");
            #endregion
            #region GPU父节点的子节点
            tn3.Nodes.Add("GPU Model Type");
            tn3.Nodes.Add("Video Memory");
            tn3.Nodes.Add("GPU TDP");
            #endregion
            #region Memory父节点的子节点
            tn4.Nodes.Add("Memory Size");
            tn4.Nodes.Add("DRAM Frequency");
            #endregion
            #region Driver父节点的子节点
            tn5.Nodes.Add("Capacity");
            tn5.Nodes.Add("Type");
            #endregion
            #region PSU父节点的子节点
            tn6.Nodes.Add("Rated Power");
            tn6.Nodes.Add("Conversion Efficiency");
            #endregion
            #region Software父节点的子节点
            tn8.Nodes.Add("Operating System");
            tn8.Nodes.Add("Virus");
            #endregion
            #region 将创建的父节点添加到树列表中
            items.Nodes.Add(tn1);
            items.Nodes.Add(tn2);
            items.Nodes.Add(tn3);
            items.Nodes.Add(tn4);
            items.Nodes.Add(tn5);
            items.Nodes.Add(tn6);
            items.Nodes.Add(tn7);
            items.Nodes.Add(tn8);
            #endregion     
            Random rd = new Random();
            int n = rd.Next(1, 15);
            t = new Event(n);
            check = new Check(t);
            taskDescription.Text = t.get_task();
            if (t.subject == 1)
                check.savePrevious();
            information.Text = "Please select one item.";
            if (t.get_subject() == 0)
                pictureBox2.BackgroundImage = Properties.Resources.全部装完;
            else if (t.get_subject() == 1)
            {
                pictureBox2.BackgroundImage = Properties.Resources.全部装完;
                check.savePrevious();
            }
            else if (t.get_subject() == 2)
                pictureBox2.BackgroundImage = Properties.Resources.全部拆光;

            install.BackgroundImage = Properties.Resources.install1;//1不可点，2可点
            uninstall.BackgroundImage = Properties.Resources.uninstall2;//1可点，2灰色，不可点
            powerSwitch.BackgroundImage = Properties.Resources.switchon;
            if (t.m.getCPUInstall() == true && (str == "CPU Model Type" || str == "Clock Speed" || str == "Cores" || str == "Threads" || str == "CPU TDP"))
                install.BackgroundImage = Properties.Resources.install1;//灰色，不可点
            else if (t.m.getCPUInstall() == false && (str == "CPU Model Type" || str == "Clock Speed" || str == "Cores" || str == "Threads" || str == "CPU TDP"))
                install.BackgroundImage = Properties.Resources.install2;//可点
            else if (pictureBox2.BackgroundImage == Properties.Resources.全部拆光 && (str == "Mainboard Model Type" || str == "BIOS"))
                install.BackgroundImage = Properties.Resources.install2;
            else if (pictureBox2.BackgroundImage != Properties.Resources.全部拆光 && (str == "Mainboard Model Type" || str == "BIOS"))
                install.BackgroundImage = Properties.Resources.install1;
            else if (t.m.getGPUNum() == 0 && (str == "GPU Model Type" || str == "Video Memory" || str == "GPU TDP"))
                install.BackgroundImage = Properties.Resources.install2;
            else if (t.m.getGPUNum() != 0 && (str == "GPU Model Type" || str == "Video Memory" || str == "GPU TDP"))
                install.BackgroundImage = Properties.Resources.install1;
            else if (t.m.getMemoryNum() < 4 && (str == "Memory Size" || str == "DRAM Frequency"))
                install.BackgroundImage = Properties.Resources.install2;
            else if (t.m.getMemoryNum() == 4 && (str == "Memory Size" || str == "DRAM Frequency"))
                install.BackgroundImage = Properties.Resources.install1;
            else if (t.m.getPSUInstall() == true && (str == "Rated Power" || str == "Conversion Efficiency"))
                install.BackgroundImage = Properties.Resources.install1;
            else if (t.m.getPSUInstall() == false && (str == "Rated Power" || str == "Conversion Efficiency"))
                install.BackgroundImage = Properties.Resources.install1;
            else if (str == "Case")
                install.BackgroundImage = Properties.Resources.install1;
            else if (t.m.getHDDInstall() == true && (str == "Capacity" || str == "Type"))
                install.BackgroundImage = Properties.Resources.install1;
            else if (t.m.getHDDInstall() == false && (str == "Capacity" || str == "Type"))
                install.BackgroundImage = Properties.Resources.install2;
            else if (t.m.getHDDInstall() == true && (str == "Operating System") && t.s.getSystem() == true)
                install.BackgroundImage = Properties.Resources.install1;
            else if (t.m.getHDDInstall() == true && (str == "Operating System") && t.s.getSystem() == false)
                install.BackgroundImage = Properties.Resources.install2;
            else if (t.m.getHDDInstall() == true && (str == "Virus") && t.s.getVirus() == true)
                install.BackgroundImage = Properties.Resources.install2;
            else if (t.m.getHDDInstall() == true && (str == "Virus") && t.s.getVirus() == false)
                install.BackgroundImage = Properties.Resources.install2;
            else if (t.m.getHDDInstall() == false && (str == "Virus" || str == "Operating System"))
                install.BackgroundImage = Properties.Resources.install1;

            if (t.m.getCPUInstall() == true && (str == "CPU Model Type" || str == "Clock Speed" || str == "Cores" || str == "Threads" || str == "CPU TDP"))
                uninstall.BackgroundImage = Properties.Resources.uninstall1;//可点
            else if (t.m.getCPUInstall() == false && (str == "CPU Model Type" || str == "Clock Speed" || str == "Cores" || str == "Threads" || str == "CPU TDP"))
                uninstall.BackgroundImage = Properties.Resources.uninstall2;//不可点
            else if (pictureBox2.BackgroundImage == Properties.Resources.全部拆光 && (str == "Mainboard Model Type" || str == "BIOS"))
                uninstall.BackgroundImage = Properties.Resources.uninstall2;
            else if (pictureBox2.BackgroundImage != Properties.Resources.全部拆光 && (str == "Mainboard Model Type" || str == "BIOS"))
                uninstall.BackgroundImage = Properties.Resources.uninstall1;
            else if (t.m.getGPUNum() == 0 && (str == "GPU Model Type" || str == "Video Memory" || str == "GPU TDP"))
                uninstall.BackgroundImage = Properties.Resources.uninstall2;
            else if (t.m.getGPUNum() != 0 && (str == "GPU Model Type" || str == "Video Memory" || str == "GPU TDP"))
                uninstall.BackgroundImage = Properties.Resources.uninstall1;
            else if (t.m.getMemoryNum() < 4 && (str == "Memory Size" || str == "DRAM Frequency"))
                uninstall.BackgroundImage = Properties.Resources.uninstall2;
            else if (t.m.getMemoryNum() == 4 && (str == "Memory Size" || str == "DRAM Frequency"))
                uninstall.BackgroundImage = Properties.Resources.uninstall1;
            else if (t.m.getPSUInstall() == true && (str == "Rated Power" || str == "Conversion Efficiency"))
                uninstall.BackgroundImage = Properties.Resources.uninstall1;
            else if (t.m.getPSUInstall() == false && (str == "Rated Power" || str == "Conversion Efficiency"))
                uninstall.BackgroundImage = Properties.Resources.uninstall1;
            else if (str == "Case")
                uninstall.BackgroundImage = Properties.Resources.uninstall1;
            else if (t.m.getHDDInstall() == true && (str == "Capacity" || str == "Type"))
                uninstall.BackgroundImage = Properties.Resources.uninstall1;
            else if (t.m.getHDDInstall() == false && (str == "Capacity" || str == "Type"))
                uninstall.BackgroundImage = Properties.Resources.uninstall2;
            else if (t.m.getHDDInstall() == true && (str == "Operating System") && t.s.getSystem() == true)
                uninstall.BackgroundImage = Properties.Resources.uninstall1;
            else if (t.m.getHDDInstall() == true && (str == "Operating System") && t.s.getSystem() == false)
                uninstall.BackgroundImage = Properties.Resources.uninstall2;
            else if (t.m.getHDDInstall() == true && (str == "Virus") && t.s.getVirus() == true)
                uninstall.BackgroundImage = Properties.Resources.uninstall2;
            else if (t.m.getHDDInstall() == true && (str == "Virus") && t.s.getVirus() == false)
                uninstall.BackgroundImage = Properties.Resources.uninstall2;
            else if (t.m.getHDDInstall() == false && (str == "Virus" || str == "Operating System"))
                uninstall.BackgroundImage = Properties.Resources.uninstall1;
        }

        private void Info_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void GetInfo(String node)
        {
            powerSwitch.BackgroundImage = Properties.Resources.switchon;
            if (t.m.getCPUInstall() == true && (str == "CPU Model Type" || str == "Clock Speed" || str == "Cores" || str == "Threads" || str == "CPU TDP"))
                install.BackgroundImage = Properties.Resources.install1;//灰色，不可点
            else if (t.m.getCPUInstall() == false && (str == "CPU Model Type" || str == "Clock Speed" || str == "Cores" || str == "Threads" || str == "CPU TDP"))
                install.BackgroundImage = Properties.Resources.install2;//可点
            else if (pictureBox2.BackgroundImage == Properties.Resources.全部拆光 && (str == "Mainboard Model Type" || str == "BIOS"))
                install.BackgroundImage = Properties.Resources.install2;
            else if (pictureBox2.BackgroundImage != Properties.Resources.全部拆光 && (str == "Mainboard Model Type" || str == "BIOS"))
                install.BackgroundImage = Properties.Resources.install1;
            else if (t.m.getGPUNum() == 0 && (str == "GPU Model Type" || str == "Video Memory" || str == "GPU TDP"))
                install.BackgroundImage = Properties.Resources.install2;
            else if (t.m.getGPUNum() != 0 && (str == "GPU Model Type" || str == "Video Memory" || str == "GPU TDP"))
                install.BackgroundImage = Properties.Resources.install1;
            else if (t.m.getMemoryNum() < 4 && (str == "Memory Size" || str == "DRAM Frequency"))
                install.BackgroundImage = Properties.Resources.install2;
            else if (t.m.getMemoryNum() == 4 && (str == "Memory Size" || str == "DRAM Frequency"))
                install.BackgroundImage = Properties.Resources.install1;
            else if (t.m.getPSUInstall() == true && (str == "Rated Power" || str == "Conversion Efficiency"))
                install.BackgroundImage = Properties.Resources.install1;
            else if (t.m.getPSUInstall() == false && (str == "Rated Power" || str == "Conversion Efficiency"))
                install.BackgroundImage = Properties.Resources.install1;
            else if (str == "Case")
                install.BackgroundImage = Properties.Resources.install1;
            else if (t.m.getHDDInstall() == true && (str == "Capacity" || str == "Type"))
                install.BackgroundImage = Properties.Resources.install1;
            else if (t.m.getHDDInstall() == false && (str == "Capacity" || str == "Type"))
                install.BackgroundImage = Properties.Resources.install2;
            else if (t.m.getHDDInstall() == true && (str == "Operating System") && t.s.getSystem() == true)
                install.BackgroundImage = Properties.Resources.install1;
            else if (t.m.getHDDInstall() == true && (str == "Operating System") && t.s.getSystem() == false)
                install.BackgroundImage = Properties.Resources.install2;
            else if (t.m.getHDDInstall() == true && (str == "Virus") && t.s.getVirus() == true)
                install.BackgroundImage = Properties.Resources.install2;
            else if (t.m.getHDDInstall() == true && (str == "Virus") && t.s.getVirus() == false)
                install.BackgroundImage = Properties.Resources.install2;
            else if (t.m.getHDDInstall() == false && (str == "Virus" || str == "Operating System"))
                install.BackgroundImage = Properties.Resources.install1;

            if (t.m.getCPUInstall() == true && (str == "CPU Model Type" || str == "Clock Speed" || str == "Cores" || str == "Threads" || str == "CPU TDP"))
                uninstall.BackgroundImage = Properties.Resources.uninstall1;//可点
            else if (t.m.getCPUInstall() == false && (str == "CPU Model Type" || str == "Clock Speed" || str == "Cores" || str == "Threads" || str == "CPU TDP"))
                uninstall.BackgroundImage = Properties.Resources.uninstall2;//不可点
            else if (pictureBox2.BackgroundImage == Properties.Resources.全部拆光 && (str == "Mainboard Model Type" || str == "BIOS"))
                uninstall.BackgroundImage = Properties.Resources.uninstall2;
            else if (pictureBox2.BackgroundImage != Properties.Resources.全部拆光 && (str == "Mainboard Model Type" || str == "BIOS"))
                uninstall.BackgroundImage = Properties.Resources.uninstall1;
            else if (t.m.getGPUNum() == 0 && (str == "GPU Model Type" || str == "Video Memory" || str == "GPU TDP"))
                uninstall.BackgroundImage = Properties.Resources.uninstall2;
            else if (t.m.getGPUNum() != 0 && (str == "GPU Model Type" || str == "Video Memory" || str == "GPU TDP"))
                uninstall.BackgroundImage = Properties.Resources.uninstall1;
            else if (t.m.getMemoryNum() < 4 && (str == "Memory Size" || str == "DRAM Frequency"))
                uninstall.BackgroundImage = Properties.Resources.uninstall2;
            else if (t.m.getMemoryNum() == 4 && (str == "Memory Size" || str == "DRAM Frequency"))
                uninstall.BackgroundImage = Properties.Resources.uninstall1;
            else if (t.m.getPSUInstall() == true && (str == "Rated Power" || str == "Conversion Efficiency"))
                uninstall.BackgroundImage = Properties.Resources.uninstall1;
            else if (t.m.getPSUInstall() == false && (str == "Rated Power" || str == "Conversion Efficiency"))
                uninstall.BackgroundImage = Properties.Resources.uninstall1;
            else if (str == "Case")
                uninstall.BackgroundImage = Properties.Resources.uninstall1;
            else if (t.m.getHDDInstall() == true && (str == "Capacity" || str == "Type"))
                uninstall.BackgroundImage = Properties.Resources.uninstall1;
            else if (t.m.getHDDInstall() == false && (str == "Capacity" || str == "Type"))
                uninstall.BackgroundImage = Properties.Resources.uninstall2;
            else if (t.m.getHDDInstall() == true && (str == "Operating System") && t.s.getSystem() == true)
                uninstall.BackgroundImage = Properties.Resources.uninstall1;
            else if (t.m.getHDDInstall() == true && (str == "Operating System") && t.s.getSystem() == false)
                uninstall.BackgroundImage = Properties.Resources.uninstall2;
            else if (t.m.getHDDInstall() == true && (str == "Virus") && t.s.getVirus() == true)
                uninstall.BackgroundImage = Properties.Resources.uninstall2;
            else if (t.m.getHDDInstall() == true && (str == "Virus") && t.s.getVirus() == false)
                uninstall.BackgroundImage = Properties.Resources.uninstall2;
            else if (t.m.getHDDInstall() == false && (str == "Virus" || str == "Operating System"))
                uninstall.BackgroundImage = Properties.Resources.uninstall1;
            switch (node)                       //判断选中的节点名称
            {
                case "CPU Model Type":
                    information.Text = t.c.getModel();
                    break;
                case "Clock Speed":
                    information.Text = Convert.ToString(t.c.getMainFrequency()) + "GHz";
                    break;
                case "Cores":
                    information.Text = Convert.ToString(t.c.getCores()) + " Cores";
                    break;
                case "Threads":
                    information.Text = Convert.ToString(t.c.getThreads()) + " Threads";
                    break;
                case "CPU TDP":
                    information.Text = Convert.ToString(t.c.getPower()) + 'w';
                    break;
                case "Mainboard Model Type":
                    information.Text = t.m.getModel();
                    break;
                case "BIOS":
                    if (information.Text != "label1")
                        information.Text = ("American Megatrends");
                    break;
                case "GPU Model Type":
                    information.Text = t.g.getModel();
                      break;
                case "Video Memory":
                    information.Text = Convert.ToString(t.g.getVram()) + 'G';
                    break;
                case "GPU TDP":
                    information.Text = Convert.ToString(t.g.getPower()) + 'w';
                    break;
                case "Memory Size":
                    information.Text = Convert.ToString(t.mem.getCapacity()) + 'G';
                    break;
                case "DRAM Frequency":
                    information.Text = Convert.ToString(t.mem.getFrequency()) + "MHz";
                    break;
                case "Capacity":
                    information.Text = Convert.ToString(t.h.getCapacity()) + 'G';
                    break;
                case "Type":
                    if (t.h.getMechanics() == true)
                        information.Text = "HDD";
                    else
                        information.Text = "SSD";
                    break;
                case "Rated Power":
                    information.Text = Convert.ToString(t.p.getRatedPower()) + 'w';
                    break;
                case "Conversion Efficiency":
                    information.Text = Convert.ToString(t.p.getConversionRate());
                    break;
                case "Case":
                    information.Text = ("Antec P80");
                    break;
                case "Operating System":
                    information.Text = ("Windows 10 64bit 1903 Version");
                    break;
                case "Virus":
                    if (t.s.getVirus() == true)
                        information.Text = "Virus detected!";
                    else
                        information.Text = "Virus not detected!";
                    break;
                default:
                    information.Text = "Please select an item.";
                    break;
            }
        }
        private void PictureBox1_MouseEnter(object sender, EventArgs e)//鼠标移入事件
        {
            ImageSwitch(sender, 0);
        }
        private void PictureBox1_MouseLeave(object sender, EventArgs e)//鼠标移出事件
        {
            ImageSwitch(sender, 1);
        }
        public static PictureBox Tem_PictB = new PictureBox();
        public void ImageSwitch(object sender,int ns)
        {
            Tem_PictB = (PictureBox)sender;
            Tem_PictB.BackgroundImage = null;                             //清空图片
            if (ns == 0)                                        //鼠标移入
                Tem_PictB.BackgroundImage = Properties.Resources.quit2;
            else if (ns == 1)                                        //鼠标移出
                Tem_PictB.BackgroundImage = Properties.Resources.quit1;
        }
        private void Panel1_MouseDown(object sender, MouseEventArgs e)
        {
            Win32.ReleaseCapture();                     //用来释放被当前线程中某个窗口捕获的光标
            Win32.SendMessage(this.Handle, Win32.WM_SYSCOMMAND, Win32.SC_MOVE + Win32.HTCAPTION, 0);//向Windows发送拖动窗体的消息
        }

        private void PictureBox1_Click(object sender, EventArgs e)
        {
            Application.ExitThread();
        }

        private void Items_AfterSelect(object sender, TreeViewEventArgs e)
        {
            str = items.SelectedNode.Text;
            GetInfo(str);
            if (t.m.getCPUInstall() == true && (str == "CPU Model Type" || str == "Clock Speed" || str == "Cores" || str == "Threads" || str == "CPU TDP"))
                install.BackgroundImage = Properties.Resources.install1;//灰色，不可点
            else if (t.m.getCPUInstall() == false && (str == "CPU Model Type" || str == "Clock Speed" || str == "Cores" || str == "Threads" || str == "CPU TDP"))
                install.BackgroundImage = Properties.Resources.install2;//可点
            else if (pictureBox2.BackgroundImage == Properties.Resources.全部拆光 && (str == "Mainboard Model Type" || str == "BIOS"))
                install.BackgroundImage = Properties.Resources.install2;
            else if (pictureBox2.BackgroundImage != Properties.Resources.全部拆光 && (str == "Mainboard Model Type" || str == "BIOS"))
                install.BackgroundImage = Properties.Resources.install1;
            else if (t.m.getGPUNum() == 0 && (str == "GPU Model Type" || str == "Video Memory" || str == "GPU TDP"))
                install.BackgroundImage = Properties.Resources.install2;
            else if (t.m.getGPUNum() != 0 && (str == "GPU Model Type" || str == "Video Memory" || str == "GPU TDP"))
                install.BackgroundImage = Properties.Resources.install1;
            else if (t.m.getMemoryNum() < 4 && (str == "Memory Size" || str == "DRAM Frequency"))
                install.BackgroundImage = Properties.Resources.install2;
            else if (t.m.getMemoryNum() == 4 && (str == "Memory Size" || str == "DRAM Frequency"))
                install.BackgroundImage = Properties.Resources.install1;
            else if (t.m.getPSUInstall() == true && (str == "Rated Power" || str == "Conversion Efficiency"))
                install.BackgroundImage = Properties.Resources.install1;
            else if (t.m.getPSUInstall() == false && (str == "Rated Power" || str == "Conversion Efficiency"))
                install.BackgroundImage = Properties.Resources.install1;
            else if (str == "Case")
                install.BackgroundImage = Properties.Resources.install1;
            else if (t.m.getHDDInstall() == true && (str == "Capacity" || str == "Type"))
                install.BackgroundImage = Properties.Resources.install1;
            else if (t.m.getHDDInstall() == false && (str == "Capacity" || str == "Type"))
                install.BackgroundImage = Properties.Resources.install2;
            else if (t.m.getHDDInstall() == true && (str == "Operating System") && t.s.getSystem() == true)
                install.BackgroundImage = Properties.Resources.install1;
            else if (t.m.getHDDInstall() == true && (str == "Operating System") && t.s.getSystem() == false)
                install.BackgroundImage = Properties.Resources.install2;
            else if (t.m.getHDDInstall() == true && (str == "Virus") && t.s.getVirus() == true)
                install.BackgroundImage = Properties.Resources.install1;
            else if (t.m.getHDDInstall() == true && (str == "Virus") && t.s.getVirus() == false)
                install.BackgroundImage = Properties.Resources.install1;
            else if (t.m.getHDDInstall() == false && (str == "Virus" || str == "Operating System"))
                install.BackgroundImage = Properties.Resources.install1;

            if (t.m.getCPUInstall() == true && (str == "CPU Model Type" || str == "Clock Speed" || str == "Cores" || str == "Threads" || str == "CPU TDP"))
                uninstall.BackgroundImage = Properties.Resources.uninstall1;//可点
            else if (t.m.getCPUInstall() == false && (str == "CPU Model Type" || str == "Clock Speed" || str == "Cores" || str == "Threads" || str == "CPU TDP"))
                uninstall.BackgroundImage = Properties.Resources.uninstall2;//不可点
            else if (pictureBox2.BackgroundImage == Properties.Resources.全部拆光 && (str == "Mainboard Model Type" || str == "BIOS"))
                uninstall.BackgroundImage = Properties.Resources.uninstall2;
            else if (pictureBox2.BackgroundImage != Properties.Resources.全部拆光 && (str == "Mainboard Model Type" || str == "BIOS"))
                uninstall.BackgroundImage = Properties.Resources.uninstall1;
            else if (t.m.getGPUNum() == 0 && (str == "GPU Model Type" || str == "Video Memory" || str == "GPU TDP"))
                uninstall.BackgroundImage = Properties.Resources.uninstall2;
            else if (t.m.getGPUNum() != 0 && (str == "GPU Model Type" || str == "Video Memory" || str == "GPU TDP"))
                uninstall.BackgroundImage = Properties.Resources.uninstall1;
            else if (t.m.getMemoryNum() == 0 && (str == "Memory Size" || str == "DRAM Frequency"))
                uninstall.BackgroundImage = Properties.Resources.uninstall2;
            else if (t.m.getMemoryNum() < 4 && t.m.getMemoryNum() > 0 && (str == "Memory Size" || str == "DRAM Frequency"))
                uninstall.BackgroundImage = Properties.Resources.uninstall1;
            else if (t.m.getMemoryNum() == 4 && (str == "Memory Size" || str == "DRAM Frequency"))
                uninstall.BackgroundImage = Properties.Resources.uninstall1;
            else if (t.m.getPSUInstall() == true && (str == "Rated Power" || str == "Conversion Efficiency"))
                uninstall.BackgroundImage = Properties.Resources.uninstall1;
            else if (t.m.getPSUInstall() == false && (str == "Rated Power" || str == "Conversion Efficiency"))
                uninstall.BackgroundImage = Properties.Resources.uninstall1;
            else if (str == "Case")
                uninstall.BackgroundImage = Properties.Resources.uninstall1 ;
            else if (t.m.getHDDInstall() == true && (str == "Capacity" || str == "Type"))
                uninstall.BackgroundImage = Properties.Resources.uninstall1;
            else if (t.m.getHDDInstall() == false && (str == "Capacity" || str == "Type"))
                uninstall.BackgroundImage = Properties.Resources.uninstall2;
            else if (t.m.getHDDInstall() == true && (str == "Operating System") && t.s.getSystem() == true)
                uninstall.BackgroundImage = Properties.Resources.uninstall2;
            else if (t.m.getHDDInstall() == true && (str == "Operating System") && t.s.getSystem() == false)
                uninstall.BackgroundImage = Properties.Resources.uninstall2;
            else if (t.m.getHDDInstall() == true && (str == "Virus") && t.s.getVirus() == true)
                uninstall.BackgroundImage = Properties.Resources.uninstall2;
            else if (t.m.getHDDInstall() == true && (str == "Virus") && t.s.getVirus() == false)
                uninstall.BackgroundImage = Properties.Resources.uninstall2;
            else if (t.m.getHDDInstall() == false && (str == "Virus" || str == "Operating System"))
                uninstall.BackgroundImage = Properties.Resources.uninstall2;
        }

        private void PictureBox2_MouseDown(object sender, MouseEventArgs e)
        {
            Win32.ReleaseCapture();                     //用来释放被当前线程中某个窗口捕获的光标
            Win32.SendMessage(this.Handle, Win32.WM_SYSCOMMAND, Win32.SC_MOVE + Win32.HTCAPTION, 0);//向Windows发送拖动窗体的消息
        }

        private void Install_Click(object sender, EventArgs e)
        {
            if (str == "CPU" || str == "CPU Model Type" || str == "Clock Speed" || str == "Cores" || str == "Threads" || str == "CPU TDP")
            {
                change(1);
                table tb = new table();
                tb.ShowDialog();
                t.m.setCPUInstall(true);
                t.c.setModel(db.get_info("CPU", "型号", Convert.ToString(PCBS.IDChossen)));
                t.c.setPrice(int.Parse(db.get_info("CPU", "价格", Convert.ToString(PCBS.IDChossen))));
                t.c.setOldness(false);
                t.c.setGoodness(true);
                t.c.setCapability(int.Parse(db.get_info("CPU", "性能", Convert.ToString(PCBS.IDChossen))));
                t.c.setCores(int.Parse(db.get_info("CPU", "核心数", Convert.ToString(PCBS.IDChossen))));
                t.c.setThreads(int.Parse(db.get_info("CPU", "线程数", Convert.ToString(PCBS.IDChossen))));
                t.c.setFrequency(double.Parse(db.get_info("CPU", "主频", Convert.ToString(PCBS.IDChossen))));
                t.c.setPower(int.Parse(db.get_info("CPU", "功耗", Convert.ToString(PCBS.IDChossen))));
                t.c.setLevel(int.Parse(db.get_info("CPU", "初始等级", Convert.ToString(PCBS.IDChossen))));
                pictureBox2.BackgroundImage = Properties.Resources.装cpu;
                
            }
            else if (str == "Mainboard" || str == "Mainboard Model Type" || str == "BIOS")
            {
                change(2);
                table tb = new table();
                tb.ShowDialog();
                t.m.setModel(db.get_info("Mainboard", "型号", Convert.ToString(PCBS.IDChossen)));
                t.m.setPrice(int.Parse(db.get_info("Mainboard", "价格", Convert.ToString(PCBS.IDChossen))));
                t.m.setOldness(false);
                t.m.setGoodness(true);
                t.m.setPSUInstall(false);
                t.m.setCPUInstall(false);
                t.m.setGPUNum(0);
                t.m.setMemoryNum(0);
                t.m.setHDDInstall(false);
                t.m.setLevel(0);
                pictureBox2.BackgroundImage = Properties.Resources.只装主板;
            }
            else if (str == "GPU" || str == "GPU Model Type" || str == "Video Memory" || str == "GPU TDP")
            {
                change(3);
                table tb = new table();
                tb.ShowDialog();
                t.g.setModel(db.get_info("GPU", "型号", Convert.ToString(PCBS.IDChossen)));
                t.g.setGoodness(true);
                t.g.setCapability(int.Parse(db.get_info("GPU", "性能", Convert.ToString(PCBS.IDChossen))));
                t.g.setLevel(int.Parse(db.get_info("GPU", "解锁等级", Convert.ToString(PCBS.IDChossen))));
                t.g.setOldness(false);
                t.g.setPower(int.Parse(db.get_info("GPU", "功耗", Convert.ToString(PCBS.IDChossen))));
                t.g.setVram(int.Parse(db.get_info("GPU", "显存", Convert.ToString(PCBS.IDChossen))));
                t.m.setGPUNum(1);
                t.g.setPrice(int.Parse(db.get_info("GPU", "价格", Convert.ToString(PCBS.IDChossen))));
                pictureBox2.BackgroundImage = Properties.Resources.装了显卡;
            }
            else if (str == "Memory" || str == "Memory Size" || str == "DRAM Frequency")
            {
                change(4);
                table tb = new table();
                tb.ShowDialog();
                t.mem.setGoodness(true);
                t.mem.setCapability(int.Parse(db.get_info("Memory", "性能", Convert.ToString(PCBS.IDChossen))));
                t.mem.setLevel(0);
                t.mem.setOldness(false);
                t.mem.setPrice(int.Parse(db.get_info("Memory", "价格", Convert.ToString(PCBS.IDChossen))));
                t.mem.setCapacity(int.Parse(db.get_info("Memory", "容量", Convert.ToString(PCBS.IDChossen))));
                t.mem.setFrequency(int.Parse(db.get_info("Memory", "频率", Convert.ToString(PCBS.IDChossen))));
                pictureBox2.BackgroundImage = Properties.Resources.装了内存;
            }
            else if (str == "PSU" || str == "Rated Power" || str == "Conversion Efficiency")
            {
                change(5);
                table tb = new table();
                tb.ShowDialog();
                t.p.setGoodness(true);
                t.p.setCapability(0);
                t.p.setLevel(0);
                t.p.setOldness(false);
                t.p.setPrice(int.Parse(db.get_info("PSU", "价格", Convert.ToString(PCBS.IDChossen))));
                t.p.setRatedPower(int.Parse(db.get_info("PSU", "额定功率", Convert.ToString(PCBS.IDChossen))));
                t.p.setConversionRate(double.Parse(db.get_info("PSU", "转化率", Convert.ToString(PCBS.IDChossen))));
            }
            else if (str == "Drives" || str == "Capacity" || str == "Type")
            {
                change(6);
                table tb = new table();
                tb.ShowDialog();
                t.h.setGoodness(true);
                t.h.setCapability(int.Parse(db.get_info("Driver", "性能", Convert.ToString(PCBS.IDChossen))));
                t.h.setLevel(0);
                t.h.setOldness(false);
                t.h.setPrice(int.Parse(db.get_info("Driver", "价格", Convert.ToString(PCBS.IDChossen))));
                t.h.setCapacity(int.Parse(db.get_info("Driver", "容量", Convert.ToString(PCBS.IDChossen))));
                bool hdd;
                if (db.get_info("Driver", "类型", Convert.ToString(PCBS.IDChossen)) == "HDD")
                    hdd = true;
                else
                    hdd = false;
                t.h.setMechanics(hdd);
            }
            else if (str == "Case")
            {
                pictureBox2.BackgroundImage = Properties.Resources.装了水冷;

                pictureBox2.BackgroundImage = Properties.Resources.接好电源线;

                pictureBox2.BackgroundImage = Properties.Resources.全部装完;
            }
            else if (str == "Virus")
            {

            }
            else if (str == "Operating System")
            {
                t.s.setSystem(true);
            }
            GetInfo(str);
        }

        private void Uninstall_Click(object sender, EventArgs e)
        {
            if (str == "CPU" || str == "CPU Model Type" || str == "Clock Speed" || str == "Cores" || str == "Threads" || str == "CPU TDP")
            {
                t.m.setCPUInstall(false);
                t.c.setModel("");
                t.c.setPrice(0);
                t.c.setOldness(false);
                t.c.setGoodness(false);
                t.c.setCapability(0);
                t.c.setCores(0);
                t.c.setThreads(0);
                t.c.setFrequency(0);
                t.c.setPower(0);
                t.c.setLevel(0);
                pictureBox2.BackgroundImage = Properties.Resources.只装主板;
            }
            else if (str == "Mainboard" || str == "Mainboard Model Type" || str == "BIOS")
            {
                t.m.setModel("");
                t.m.setPrice(0);
                t.m.setOldness(false);
                t.m.setGoodness(true);
                t.m.setPSUInstall(false);
                t.m.setCPUInstall(false);
                t.m.setGPUNum(0);
                t.m.setMemoryNum(0);
                t.m.setHDDInstall(false);
                t.m.setLevel(0);
                t.c.setModel("");
                t.c.setPrice(0);
                t.c.setOldness(false);
                t.c.setGoodness(false);
                t.c.setCapability(0);
                t.c.setCores(0);
                t.c.setThreads(0);
                t.c.setFrequency(0);
                t.c.setPower(0);
                t.c.setLevel(0);
                t.g.setModel("");
                t.g.setGoodness(false);
                t.g.setCapability(0);
                t.g.setLevel(0);
                t.g.setOldness(false);
                t.g.setPower(0);
                t.g.setVram(0);
                t.m.setGPUNum(0);
                t.g.setPrice(0);
                t.mem.setGoodness(false);
                t.mem.setCapability(0);
                t.mem.setLevel(0);
                t.mem.setOldness(false);
                t.mem.setPrice(0);
                t.mem.setCapacity(0);
                t.mem.setFrequency(0);
                t.h.setGoodness(false);
                t.h.setCapability(0);
                t.h.setLevel(0);
                t.h.setOldness(false);
                t.h.setPrice(0);
                t.h.setCapacity(0);
                t.h.setMechanics(false);
                pictureBox2.BackgroundImage = Properties.Resources.全部拆光;
            }
            else if (str == "GPU" || str == "GPU Model Type" || str == "Video Memory" || str == "GPU TDP")
            {
                t.g.setModel("");
                t.g.setGoodness(false);
                t.g.setCapability(0);
                t.g.setLevel(0);
                t.g.setOldness(false);
                t.g.setPower(0);
                t.g.setVram(0);
                t.m.setGPUNum(0);
                t.g.setPrice(0);
                pictureBox2.BackgroundImage = Properties.Resources.装cpu;
            }
            else if (str == "Memory" || str == "Memory Size" || str == "DRAM Frequency")
            {
                t.mem.setGoodness(false);
                t.mem.setCapability(0);
                t.mem.setLevel(0);
                t.mem.setOldness(false);
                t.mem.setPrice(0);
                t.mem.setCapacity(0);
                t.mem.setFrequency(0);
                pictureBox2.BackgroundImage = Properties.Resources.装了内存;
            }
            else if (str == "PSU" || str == "Rated Power" || str == "Conversion Efficiency")
            {
                t.p.setGoodness(false);
                t.p.setCapability(0);
                t.p.setLevel(0);
                t.p.setOldness(false);
                t.p.setPrice(0);
                t.p.setRatedPower(0);
                t.p.setConversionRate(0);
            }
            else if (str == "Drives" || str == "Capacity" || str == "Type")
            {
                t.h.setGoodness(false);
                t.h.setCapability(0);
                t.h.setLevel(0);
                t.h.setOldness(false);
                t.h.setPrice(0);
                t.h.setCapacity(0);
                t.h.setMechanics(false);
            }
            else if (str == "Case")
            {
                uninstall.BackgroundImage = Properties.Resources.uninstall2;
            }
            else if (str == "Virus")
            {
                t.s.setVirus(false);
            }
            else if (str == "Operating System")
            {

            }
            GetInfo(str);
        }

        private void PowerSwitch_Click(object sender, EventArgs e)
        {
            check = new Check(t);
            powerSwitch.BackgroundImage = Properties.Resources.switchon;
            if (t.subject == 0)
            {
                if (check.pass0() >= 1)
                    powerSwitch.BackgroundImage = Properties.Resources.switchoff;
            }
            else if (t.subject == 1)
            {
                if (check.pass1(t) == true)
                    powerSwitch.BackgroundImage = Properties.Resources.switchoff;
            }
            else if (check.pass2(t) == true)
                powerSwitch.BackgroundImage = Properties.Resources.switchoff;
        }

        private void Submit_Click(object sender, EventArgs e)
        {
            panel1.BackgroundImage = Properties.Resources.背景;
            
            Random rd = new Random();
            int n = rd.Next(1, 15);
            t = new Event(n);
            check = new Check(t);
            taskDescription.Text = t.get_task();
            if (t.subject == 1)
                check.savePrevious();
            information.Text = "Please select one item.";
            if (t.get_subject() == 0)
                pictureBox2.BackgroundImage = Properties.Resources.全部装完;
            else if (t.get_subject() == 1)
            {
                pictureBox2.BackgroundImage = Properties.Resources.全部装完;
                check.savePrevious();
            }
            else if (t.get_subject() == 2)
                pictureBox2.BackgroundImage = Properties.Resources.全部拆光;

            install.BackgroundImage = Properties.Resources.install1;//1不可点，2可点
            uninstall.BackgroundImage = Properties.Resources.uninstall2;//1可点，2灰色，不可点
            powerSwitch.BackgroundImage = Properties.Resources.switchon;
            if (t.m.getCPUInstall() == true && (str == "CPU Model Type" || str == "Clock Speed" || str == "Cores" || str == "Threads" || str == "CPU TDP"))
                install.BackgroundImage = Properties.Resources.install1;//灰色，不可点
            else if (t.m.getCPUInstall() == false && (str == "CPU Model Type" || str == "Clock Speed" || str == "Cores" || str == "Threads" || str == "CPU TDP"))
                install.BackgroundImage = Properties.Resources.install2;//可点
            else if (pictureBox2.BackgroundImage == Properties.Resources.全部拆光 && (str == "Mainboard Model Type" || str == "BIOS"))
                install.BackgroundImage = Properties.Resources.install2;
            else if (pictureBox2.BackgroundImage != Properties.Resources.全部拆光 && (str == "Mainboard Model Type" || str == "BIOS"))
                install.BackgroundImage = Properties.Resources.install1;
            else if (t.m.getGPUNum() == 0 && (str == "GPU Model Type" || str == "Video Memory" || str == "GPU TDP"))
                install.BackgroundImage = Properties.Resources.install2;
            else if (t.m.getGPUNum() != 0 && (str == "GPU Model Type" || str == "Video Memory" || str == "GPU TDP"))
                install.BackgroundImage = Properties.Resources.install1;
            else if (t.m.getMemoryNum() < 4 && (str == "Memory Size" || str == "DRAM Frequency"))
                install.BackgroundImage = Properties.Resources.install2;
            else if (t.m.getMemoryNum() == 4 && (str == "Memory Size" || str == "DRAM Frequency"))
                install.BackgroundImage = Properties.Resources.install1;
            else if (t.m.getPSUInstall() == true && (str == "Rated Power" || str == "Conversion Efficiency"))
                install.BackgroundImage = Properties.Resources.install1;
            else if (t.m.getPSUInstall() == false && (str == "Rated Power" || str == "Conversion Efficiency"))
                install.BackgroundImage = Properties.Resources.install1;
            else if (str == "Case")
                install.BackgroundImage = Properties.Resources.install1;
            else if (t.m.getHDDInstall() == true && (str == "Capacity" || str == "Type"))
                install.BackgroundImage = Properties.Resources.install1;
            else if (t.m.getHDDInstall() == false && (str == "Capacity" || str == "Type"))
                install.BackgroundImage = Properties.Resources.install2;
            else if (t.m.getHDDInstall() == true && (str == "Operating System") && t.s.getSystem() == true)
                install.BackgroundImage = Properties.Resources.install1;
            else if (t.m.getHDDInstall() == true && (str == "Operating System") && t.s.getSystem() == false)
                install.BackgroundImage = Properties.Resources.install2;
            else if (t.m.getHDDInstall() == true && (str == "Virus") && t.s.getVirus() == true)
                install.BackgroundImage = Properties.Resources.install2;
            else if (t.m.getHDDInstall() == true && (str == "Virus") && t.s.getVirus() == false)
                install.BackgroundImage = Properties.Resources.install2;
            else if (t.m.getHDDInstall() == false && (str == "Virus" || str == "Operating System"))
                install.BackgroundImage = Properties.Resources.install1;

            if (t.m.getCPUInstall() == true && (str == "CPU Model Type" || str == "Clock Speed" || str == "Cores" || str == "Threads" || str == "CPU TDP"))
                uninstall.BackgroundImage = Properties.Resources.uninstall1;//可点
            else if (t.m.getCPUInstall() == false && (str == "CPU Model Type" || str == "Clock Speed" || str == "Cores" || str == "Threads" || str == "CPU TDP"))
                uninstall.BackgroundImage = Properties.Resources.uninstall2;//不可点
            else if (pictureBox2.BackgroundImage == Properties.Resources.全部拆光 && (str == "Mainboard Model Type" || str == "BIOS"))
                uninstall.BackgroundImage = Properties.Resources.uninstall2;
            else if (pictureBox2.BackgroundImage != Properties.Resources.全部拆光 && (str == "Mainboard Model Type" || str == "BIOS"))
                uninstall.BackgroundImage = Properties.Resources.uninstall1;
            else if (t.m.getGPUNum() == 0 && (str == "GPU Model Type" || str == "Video Memory" || str == "GPU TDP"))
                uninstall.BackgroundImage = Properties.Resources.uninstall2;
            else if (t.m.getGPUNum() != 0 && (str == "GPU Model Type" || str == "Video Memory" || str == "GPU TDP"))
                uninstall.BackgroundImage = Properties.Resources.uninstall1;
            else if (t.m.getMemoryNum() < 4 && (str == "Memory Size" || str == "DRAM Frequency"))
                uninstall.BackgroundImage = Properties.Resources.uninstall2;
            else if (t.m.getMemoryNum() == 4 && (str == "Memory Size" || str == "DRAM Frequency"))
                uninstall.BackgroundImage = Properties.Resources.uninstall1;
            else if (t.m.getPSUInstall() == true && (str == "Rated Power" || str == "Conversion Efficiency"))
                uninstall.BackgroundImage = Properties.Resources.uninstall1;
            else if (t.m.getPSUInstall() == false && (str == "Rated Power" || str == "Conversion Efficiency"))
                uninstall.BackgroundImage = Properties.Resources.uninstall1;
            else if (str == "Case")
                uninstall.BackgroundImage = Properties.Resources.uninstall1;
            else if (t.m.getHDDInstall() == true && (str == "Capacity" || str == "Type"))
                uninstall.BackgroundImage = Properties.Resources.uninstall1;
            else if (t.m.getHDDInstall() == false && (str == "Capacity" || str == "Type"))
                uninstall.BackgroundImage = Properties.Resources.uninstall2;
            else if (t.m.getHDDInstall() == true && (str == "Operating System") && t.s.getSystem() == true)
                uninstall.BackgroundImage = Properties.Resources.uninstall1;
            else if (t.m.getHDDInstall() == true && (str == "Operating System") && t.s.getSystem() == false)
                uninstall.BackgroundImage = Properties.Resources.uninstall2;
            else if (t.m.getHDDInstall() == true && (str == "Virus") && t.s.getVirus() == true)
                uninstall.BackgroundImage = Properties.Resources.uninstall2;
            else if (t.m.getHDDInstall() == true && (str == "Virus") && t.s.getVirus() == false)
                uninstall.BackgroundImage = Properties.Resources.uninstall2;
            else if (t.m.getHDDInstall() == false && (str == "Virus" || str == "Operating System"))
                uninstall.BackgroundImage = Properties.Resources.uninstall1;
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
