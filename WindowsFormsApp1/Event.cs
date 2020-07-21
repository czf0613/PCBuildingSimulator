using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    class Event
    {
        public String task;
        public int subject;//0是维修，1是升级，2是装机
        public CPU c;
        public Mainboard m;
        public GPU g;
        public Memory mem;
        public Harddisk h;
        public PSU p;
        public Software s;
        public Database db;
        public Event(int n)
        {
            db = new Database();
            Random rd = new Random();
            int t;
            bool hdd;
            switch (n)
            {
                case 1:
                    t = rd.Next(1, 21);
                    task = "I've got a blue screen and my computer has been restarted over and over again!  Fix it for me!";
                    subject = 0;
                    c = new CPU(int.Parse(db.get_info("CPU", "价格", Convert.ToString(t))), true, int.Parse(db.get_info("CPU", "性能", Convert.ToString(t))), false, int.Parse(db.get_info("CPU", "初始等级", Convert.ToString(t))), db.get_info("CPU", "型号", Convert.ToString(t)), double.Parse(db.get_info("CPU", "主频", Convert.ToString(t))), int.Parse(db.get_info("CPU", "功耗", Convert.ToString(t))), int.Parse(db.get_info("CPU", "核心数", Convert.ToString(t))), int.Parse(db.get_info("CPU", "线程数", Convert.ToString(t))));
                    t = rd.Next(1, 8);
                    m = new Mainboard(100, true, 0, true, 0, true, 1, 1, db.get_info("Mainboard", "型号", Convert.ToString(t)), true, true);
                    t = rd.Next(1, 31);
                    if (t == 20 || t == 28 || t == 8 || t == 16 || t == 26)
                        g = new SurpriseGPU(int.Parse(db.get_info("GPU", "价格", Convert.ToString(t))), true, int.Parse(db.get_info("GPU", "性能", Convert.ToString(t))), true, 0, db.get_info("GPU", "型号", Convert.ToString(t)), int.Parse(db.get_info("GPU", "显存", Convert.ToString(t))), int.Parse(db.get_info("GPU", "功耗", Convert.ToString(t))));
                    else
                        g = new GPU(int.Parse(db.get_info("GPU", "价格", Convert.ToString(t))), true, int.Parse(db.get_info("GPU", "性能", Convert.ToString(t))), true, 0, db.get_info("GPU", "型号", Convert.ToString(t)), int.Parse(db.get_info("GPU", "显存", Convert.ToString(t))), int.Parse(db.get_info("GPU", "功耗", Convert.ToString(t))));
                    t = rd.Next(1, 28);
                    mem = new Memory(int.Parse(db.get_info("Memory", "价格", Convert.ToString(t))), true, int.Parse(db.get_info("Memory", "性能", Convert.ToString(t))), true, 0, int.Parse(db.get_info("Memory", "容量", Convert.ToString(t))), int.Parse(db.get_info("Memory", "频率", Convert.ToString(t))));
                    t = rd.Next(1, 11);

                    if (db.get_info("Driver", "类型", Convert.ToString(t)) == "HDD")
                        hdd = true;
                    else
                        hdd = false;
                    h = new Harddisk(int.Parse(db.get_info("Driver", "价格", Convert.ToString(t))), true, int.Parse(db.get_info("Driver", "性能", Convert.ToString(t))), true, 0, hdd, int.Parse(db.get_info("Driver", "价格", Convert.ToString(t))));
                    t = rd.Next(1, 24);
                    p = new PSU(int.Parse(db.get_info("PSU", "价格", Convert.ToString(t))), true, 0, true, 0, int.Parse(db.get_info("PSU", "额定功率", Convert.ToString(t))), double.Parse(db.get_info("PSU", "转化率", Convert.ToString(t))));
                    s = new Software(0, true, 0, true, 0, true, false);
                    break;
                case 2:
                    t = rd.Next(1, 21);
                    task = "I've received quite a lot of inexplicable popouts recently. I didn't do anything but I am crazy to see those awful ads for loans and purchasing houses and cars! Help me!";
                    subject = 0;
                    c = new CPU(int.Parse(db.get_info("CPU", "价格", Convert.ToString(t))), true, int.Parse(db.get_info("CPU", "性能", Convert.ToString(t))), true, int.Parse(db.get_info("CPU", "初始等级", Convert.ToString(t))), db.get_info("CPU", "型号", Convert.ToString(t)), double.Parse(db.get_info("CPU", "主频", Convert.ToString(t))), int.Parse(db.get_info("CPU", "功耗", Convert.ToString(t))), int.Parse(db.get_info("CPU", "核心数", Convert.ToString(t))), int.Parse(db.get_info("CPU", "线程数", Convert.ToString(t))));
                    t = rd.Next(1, 8);
                    m = new Mainboard(100, true, 0, true, 0, true, 1, 1, db.get_info("Mainboard", "型号", Convert.ToString(t)), true, true);
                    t = rd.Next(1, 31);
                    if (t == 20 || t == 28 || t == 8 || t == 16 || t == 26)
                        g = new SurpriseGPU(int.Parse(db.get_info("GPU", "价格", Convert.ToString(t))), true, int.Parse(db.get_info("GPU", "性能", Convert.ToString(t))), true, 0, db.get_info("GPU", "型号", Convert.ToString(t)), int.Parse(db.get_info("GPU", "显存", Convert.ToString(t))), int.Parse(db.get_info("GPU", "功耗", Convert.ToString(t))));
                    else
                        g = new GPU(int.Parse(db.get_info("GPU", "价格", Convert.ToString(t))), true, int.Parse(db.get_info("GPU", "性能", Convert.ToString(t))), true, 0, db.get_info("GPU", "型号", Convert.ToString(t)), int.Parse(db.get_info("GPU", "显存", Convert.ToString(t))), int.Parse(db.get_info("GPU", "功耗", Convert.ToString(t))));
                    t = rd.Next(1, 28);
                    mem = new Memory(int.Parse(db.get_info("Memory", "价格", Convert.ToString(t))), true, int.Parse(db.get_info("Memory", "性能", Convert.ToString(t))), true, 0, int.Parse(db.get_info("Memory", "容量", Convert.ToString(t))), int.Parse(db.get_info("Memory", "频率", Convert.ToString(t))));
                    t = rd.Next(1, 11);

                    if (db.get_info("Driver", "类型", Convert.ToString(t)) == "HDD")
                        hdd = true;
                    else
                        hdd = false;
                    h = new Harddisk(int.Parse(db.get_info("Driver", "价格", Convert.ToString(t))), true, int.Parse(db.get_info("Driver", "性能", Convert.ToString(t))), true, 0, hdd, int.Parse(db.get_info("Driver", "价格", Convert.ToString(t))));
                    t = rd.Next(1, 24);
                    p = new PSU(int.Parse(db.get_info("PSU", "价格", Convert.ToString(t))), true, 0, true, 0, int.Parse(db.get_info("PSU", "额定功率", Convert.ToString(t))), double.Parse(db.get_info("PSU", "转化率", Convert.ToString(t))));
                    s = new Software(0, true, 0, false, 0, true, true);
                    break;
                case 3:
                    t = rd.Next(1, 14);
                    task = "My old PC can not play Total war:three kindom. I want a better PC with 9 gen i7 CPU, NVIDIA RTX 2060 GPU, 16g memory and larger SSD.";
                    subject = 1;
                    c = new CPU(int.Parse(db.get_info("CPU", "价格", Convert.ToString(t))), true, int.Parse(db.get_info("CPU", "性能", Convert.ToString(t))), true, int.Parse(db.get_info("CPU", "初始等级", Convert.ToString(t))), db.get_info("CPU", "型号", Convert.ToString(t)), double.Parse(db.get_info("CPU", "主频", Convert.ToString(t))), int.Parse(db.get_info("CPU", "功耗", Convert.ToString(t))), int.Parse(db.get_info("CPU", "核心数", Convert.ToString(t))), int.Parse(db.get_info("CPU", "线程数", Convert.ToString(t))));
                    t = rd.Next(1, 8);
                    m = new Mainboard(100, true, 0, true, 0, true, 1, 1, db.get_info("Mainboard", "型号", Convert.ToString(t)), true, true);
                    t = rd.Next(1, 20);
                    if (t == 20 || t == 28 || t == 8 || t == 16 || t == 26)
                        g = new SurpriseGPU(int.Parse(db.get_info("GPU", "价格", Convert.ToString(t))), true, int.Parse(db.get_info("GPU", "性能", Convert.ToString(t))), true, 0, db.get_info("GPU", "型号", Convert.ToString(t)), int.Parse(db.get_info("GPU", "显存", Convert.ToString(t))), int.Parse(db.get_info("GPU", "功耗", Convert.ToString(t))));
                    else
                        g = new GPU(int.Parse(db.get_info("GPU", "价格", Convert.ToString(t))), true, int.Parse(db.get_info("GPU", "性能", Convert.ToString(t))), true, 0, db.get_info("GPU", "型号", Convert.ToString(t)), int.Parse(db.get_info("GPU", "显存", Convert.ToString(t))), int.Parse(db.get_info("GPU", "功耗", Convert.ToString(t))));
                    t = rd.Next(1, 28);
                    mem = new Memory(int.Parse(db.get_info("Memory", "价格", Convert.ToString(t))), true, int.Parse(db.get_info("Memory", "性能", Convert.ToString(t))), true, 0, int.Parse(db.get_info("Memory", "容量", Convert.ToString(t))), int.Parse(db.get_info("Memory", "频率", Convert.ToString(t))));
                    t = rd.Next(1, 11);

                    if (db.get_info("Driver", "类型", Convert.ToString(t)) == "HDD")
                        hdd = true;
                    else
                        hdd = false;
                    h = new Harddisk(int.Parse(db.get_info("Driver", "价格", Convert.ToString(t))), true, int.Parse(db.get_info("Driver", "性能", Convert.ToString(t))), true, 0, hdd, int.Parse(db.get_info("Driver", "价格", Convert.ToString(t))));
                    t = rd.Next(1, 24);
                    p = new PSU(int.Parse(db.get_info("PSU", "价格", Convert.ToString(t))), true, 0, true, 0, int.Parse(db.get_info("PSU", "额定功率", Convert.ToString(t))), double.Parse(db.get_info("PSU", "转化率", Convert.ToString(t))));
                    s = new Software(0, true, 0, false, 0, true, true);
                    break;
                case 4:
                    t = rd.Next(1, 21);
                    task = "When I pressed the bottom to start up my computer...I found a cloud of smoke rising from the chassis! Wow…a smell of malt! Amazing!";
                    subject = 0;
                    c = new CPU(int.Parse(db.get_info("CPU", "价格", Convert.ToString(t))), true, int.Parse(db.get_info("CPU", "性能", Convert.ToString(t))), true, int.Parse(db.get_info("CPU", "初始等级", Convert.ToString(t))), db.get_info("CPU", "型号", Convert.ToString(t)), double.Parse(db.get_info("CPU", "主频", Convert.ToString(t))), int.Parse(db.get_info("CPU", "功耗", Convert.ToString(t))), int.Parse(db.get_info("CPU", "核心数", Convert.ToString(t))), int.Parse(db.get_info("CPU", "线程数", Convert.ToString(t))));
                    t = rd.Next(1, 8);
                    m = new Mainboard(100, true, 0, true, 0, true, 1, 1, db.get_info("Mainboard", "型号", Convert.ToString(t)), true, true);
                    t = rd.Next(1, 31);
                    if (t == 20 || t == 28 || t == 8 || t == 16 || t == 26)
                        g = new SurpriseGPU(int.Parse(db.get_info("GPU", "价格", Convert.ToString(t))), true, int.Parse(db.get_info("GPU", "性能", Convert.ToString(t))), true, 0, db.get_info("GPU", "型号", Convert.ToString(t)), int.Parse(db.get_info("GPU", "显存", Convert.ToString(t))), int.Parse(db.get_info("GPU", "功耗", Convert.ToString(t))));
                    else
                        g = new GPU(int.Parse(db.get_info("GPU", "价格", Convert.ToString(t))), true, int.Parse(db.get_info("GPU", "性能", Convert.ToString(t))), true, 0, db.get_info("GPU", "型号", Convert.ToString(t)), int.Parse(db.get_info("GPU", "显存", Convert.ToString(t))), int.Parse(db.get_info("GPU", "功耗", Convert.ToString(t))));
                    t = rd.Next(1, 28);
                    mem = new Memory(int.Parse(db.get_info("Memory", "价格", Convert.ToString(t))), true, int.Parse(db.get_info("Memory", "性能", Convert.ToString(t))), true, 0, int.Parse(db.get_info("Memory", "容量", Convert.ToString(t))), int.Parse(db.get_info("Memory", "频率", Convert.ToString(t))));
                    t = rd.Next(1, 11);

                    if (db.get_info("Driver", "类型", Convert.ToString(t)) == "HDD")
                        hdd = true;
                    else
                        hdd = false;
                    h = new Harddisk(int.Parse(db.get_info("Driver", "价格", Convert.ToString(t))), true, int.Parse(db.get_info("Driver", "性能", Convert.ToString(t))), true, 0, hdd, int.Parse(db.get_info("Driver", "价格", Convert.ToString(t))));
                    t = rd.Next(1, 24);
                    p = new PSU(int.Parse(db.get_info("PSU", "价格", Convert.ToString(t))), true, 0, false, 0, int.Parse(db.get_info("PSU", "额定功率", Convert.ToString(t))), double.Parse(db.get_info("PSU", "转化率", Convert.ToString(t))));
                    s = new Software(0, true, 0, true, 0, true, false);
                    break;
                case 5:
                    t = rd.Next(1, 21);
                    task = "I failed to start up the computer my son bought for me. It's awful! My son couldn't fix it. Help me please!";
                    subject = 0;
                    c = new CPU(int.Parse(db.get_info("CPU", "价格", Convert.ToString(t))), true, int.Parse(db.get_info("CPU", "性能", Convert.ToString(t))), true, int.Parse(db.get_info("CPU", "初始等级", Convert.ToString(t))), db.get_info("CPU", "型号", Convert.ToString(t)), double.Parse(db.get_info("CPU", "主频", Convert.ToString(t))), int.Parse(db.get_info("CPU", "功耗", Convert.ToString(t))), int.Parse(db.get_info("CPU", "核心数", Convert.ToString(t))), int.Parse(db.get_info("CPU", "线程数", Convert.ToString(t))));
                    t = rd.Next(1, 8);
                    m = new Mainboard(100, true, 0, true, 0, true, 1, 1, db.get_info("Mainboard", "型号", Convert.ToString(t)), true, true);
                    t = rd.Next(1, 31);
                    if (t == 20 || t == 28 || t == 8 || t == 16 || t == 26)
                        g = new SurpriseGPU(int.Parse(db.get_info("GPU", "价格", Convert.ToString(t))), true, int.Parse(db.get_info("GPU", "性能", Convert.ToString(t))), true, 0, db.get_info("GPU", "型号", Convert.ToString(t)), int.Parse(db.get_info("GPU", "显存", Convert.ToString(t))), int.Parse(db.get_info("GPU", "功耗", Convert.ToString(t))));
                    else
                        g = new GPU(int.Parse(db.get_info("GPU", "价格", Convert.ToString(t))), true, int.Parse(db.get_info("GPU", "性能", Convert.ToString(t))), true, 0, db.get_info("GPU", "型号", Convert.ToString(t)), int.Parse(db.get_info("GPU", "显存", Convert.ToString(t))), int.Parse(db.get_info("GPU", "功耗", Convert.ToString(t))));
                    t = rd.Next(1, 28);
                    mem = new Memory(int.Parse(db.get_info("Memory", "价格", Convert.ToString(t))), true, int.Parse(db.get_info("Memory", "性能", Convert.ToString(t))), true, 0, int.Parse(db.get_info("Memory", "容量", Convert.ToString(t))), int.Parse(db.get_info("Memory", "频率", Convert.ToString(t))));
                    t = rd.Next(1, 11);

                    if (db.get_info("Driver", "类型", Convert.ToString(t)) == "HDD")
                        hdd = true;
                    else
                        hdd = false;
                    h = new Harddisk(int.Parse(db.get_info("Driver", "价格", Convert.ToString(t))), true, int.Parse(db.get_info("Driver", "性能", Convert.ToString(t))), true, 0, hdd, int.Parse(db.get_info("Driver", "价格", Convert.ToString(t))));
                    t = rd.Next(1, 24);
                    p = new PSU(int.Parse(db.get_info("PSU", "价格", Convert.ToString(t))), true, 0, false, 0, int.Parse(db.get_info("PSU", "额定功率", Convert.ToString(t))), double.Parse(db.get_info("PSU", "转化率", Convert.ToString(t))));
                    s = new Software(0, true, 0, true, 0, true, false);
                    break;
                case 6:
                    t = rd.Next(1, 21);
                    task = "For the first time in my life that I heard the mainframe beeping when it had no connection with the speaker! The sound was like'di - di'!";
                    subject = 0;
                    c = new CPU(int.Parse(db.get_info("CPU", "价格", Convert.ToString(t))), true, int.Parse(db.get_info("CPU", "性能", Convert.ToString(t))), true, int.Parse(db.get_info("CPU", "初始等级", Convert.ToString(t))), db.get_info("CPU", "型号", Convert.ToString(t)), double.Parse(db.get_info("CPU", "主频", Convert.ToString(t))), int.Parse(db.get_info("CPU", "功耗", Convert.ToString(t))), int.Parse(db.get_info("CPU", "核心数", Convert.ToString(t))), int.Parse(db.get_info("CPU", "线程数", Convert.ToString(t))));
                    t = rd.Next(1, 8);
                    m = new Mainboard(100, true, 0, true, 0, true, 1, 1, db.get_info("Mainboard", "型号", Convert.ToString(t)), true, true);
                    t = rd.Next(1, 31);
                    if (t == 20 || t == 28 || t == 8 || t == 16 || t == 26)
                        g = new SurpriseGPU(int.Parse(db.get_info("GPU", "价格", Convert.ToString(t))), true, int.Parse(db.get_info("GPU", "性能", Convert.ToString(t))), true, 0, db.get_info("GPU", "型号", Convert.ToString(t)), int.Parse(db.get_info("GPU", "显存", Convert.ToString(t))), int.Parse(db.get_info("GPU", "功耗", Convert.ToString(t))));
                    else
                        g = new GPU(int.Parse(db.get_info("GPU", "价格", Convert.ToString(t))), true, int.Parse(db.get_info("GPU", "性能", Convert.ToString(t))), true, 0, db.get_info("GPU", "型号", Convert.ToString(t)), int.Parse(db.get_info("GPU", "显存", Convert.ToString(t))), int.Parse(db.get_info("GPU", "功耗", Convert.ToString(t))));
                    t = rd.Next(1, 28);
                    mem = new Memory(int.Parse(db.get_info("Memory", "价格", Convert.ToString(t))), true, int.Parse(db.get_info("Memory", "性能", Convert.ToString(t))), true, 0, int.Parse(db.get_info("Memory", "容量", Convert.ToString(t))), int.Parse(db.get_info("Memory", "频率", Convert.ToString(t))));
                    t = rd.Next(1, 11);

                    if (db.get_info("Driver", "类型", Convert.ToString(t)) == "HDD")
                        hdd = true;
                    else
                        hdd = false;
                    h = new Harddisk(int.Parse(db.get_info("Driver", "价格", Convert.ToString(t))), true, int.Parse(db.get_info("Driver", "性能", Convert.ToString(t))), true, 0, hdd, int.Parse(db.get_info("Driver", "价格", Convert.ToString(t))));
                    t = rd.Next(1, 24);
                    p = new PSU(int.Parse(db.get_info("PSU", "价格", Convert.ToString(t))), true, 0, true, 0, int.Parse(db.get_info("PSU", "额定功率", Convert.ToString(t))), double.Parse(db.get_info("PSU", "转化率", Convert.ToString(t))));
                    s = new Software(0, true, 0, true, 0, true, false);
                    break;
                case 7:
                    t = rd.Next(1, 21);
                    task = "I don't know why I should put it on so vigorously! Maybe…great efforts make miracles?";
                    subject = 0;
                    c = new CPU(int.Parse(db.get_info("CPU", "价格", Convert.ToString(t))), true, int.Parse(db.get_info("CPU", "性能", Convert.ToString(t))), true, int.Parse(db.get_info("CPU", "初始等级", Convert.ToString(t))), db.get_info("CPU", "型号", Convert.ToString(t)), double.Parse(db.get_info("CPU", "主频", Convert.ToString(t))), int.Parse(db.get_info("CPU", "功耗", Convert.ToString(t))), int.Parse(db.get_info("CPU", "核心数", Convert.ToString(t))), int.Parse(db.get_info("CPU", "线程数", Convert.ToString(t))));
                    t = rd.Next(1, 8);
                    m = new Mainboard(100, true, 0, true, 0, true, 1, 1, db.get_info("Mainboard", "型号", Convert.ToString(t)), true, true);
                    t = rd.Next(1, 31);
                    if (t == 20 || t == 28 || t == 8 || t == 16 || t == 26)
                        g = new SurpriseGPU(int.Parse(db.get_info("GPU", "价格", Convert.ToString(t))), true, int.Parse(db.get_info("GPU", "性能", Convert.ToString(t))), true, 0, db.get_info("GPU", "型号", Convert.ToString(t)), int.Parse(db.get_info("GPU", "显存", Convert.ToString(t))), int.Parse(db.get_info("GPU", "功耗", Convert.ToString(t))));
                    else
                        g = new GPU(int.Parse(db.get_info("GPU", "价格", Convert.ToString(t))), true, int.Parse(db.get_info("GPU", "性能", Convert.ToString(t))), true, 0, db.get_info("GPU", "型号", Convert.ToString(t)), int.Parse(db.get_info("GPU", "显存", Convert.ToString(t))), int.Parse(db.get_info("GPU", "功耗", Convert.ToString(t))));
                    t = rd.Next(1, 28);
                    mem = new Memory(int.Parse(db.get_info("Memory", "价格", Convert.ToString(t))), true, int.Parse(db.get_info("Memory", "性能", Convert.ToString(t))), true, 0, int.Parse(db.get_info("Memory", "容量", Convert.ToString(t))), int.Parse(db.get_info("Memory", "频率", Convert.ToString(t))));
                    t = rd.Next(1, 11);

                    if (db.get_info("Driver", "类型", Convert.ToString(t)) == "HDD")
                        hdd = true;
                    else
                        hdd = false;
                    h = new Harddisk(int.Parse(db.get_info("Driver", "价格", Convert.ToString(t))), true, int.Parse(db.get_info("Driver", "性能", Convert.ToString(t))), true, 0, hdd, int.Parse(db.get_info("Driver", "价格", Convert.ToString(t))));
                    t = rd.Next(1, 24);
                    p = new PSU(int.Parse(db.get_info("PSU", "价格", Convert.ToString(t))), true, 0, true, 0, int.Parse(db.get_info("PSU", "额定功率", Convert.ToString(t))), double.Parse(db.get_info("PSU", "转化率", Convert.ToString(t))));
                    s = new Software(0, true, 0, true, 0, true, false);
                    break;
                case 8:
                    t = rd.Next(1, 21);
                    task = "I was cheated by a guy from the Post Bar and got a mine card in Idelfish. I get a blackscreen when I start up my computer, but my monitor works nomarlly and every other parts of my computer are brand new. Who would have been willing to do that hadn't him be so poor?";
                    subject = 0;
                    c = new CPU(int.Parse(db.get_info("CPU", "价格", Convert.ToString(t))), true, int.Parse(db.get_info("CPU", "性能", Convert.ToString(t))), true, int.Parse(db.get_info("CPU", "初始等级", Convert.ToString(t))), db.get_info("CPU", "型号", Convert.ToString(t)), double.Parse(db.get_info("CPU", "主频", Convert.ToString(t))), int.Parse(db.get_info("CPU", "功耗", Convert.ToString(t))), int.Parse(db.get_info("CPU", "核心数", Convert.ToString(t))), int.Parse(db.get_info("CPU", "线程数", Convert.ToString(t))));
                    t = rd.Next(1, 8);
                    m = new Mainboard(100, true, 0, true, 0, true, 1, 1, db.get_info("Mainboard", "型号", Convert.ToString(t)), true, true);
                    t = rd.Next(1, 31);
                    if (t == 20 || t == 28 || t == 8 || t == 16 || t == 26)
                        g = new SurpriseGPU(int.Parse(db.get_info("GPU", "价格", Convert.ToString(t))), true, int.Parse(db.get_info("GPU", "性能", Convert.ToString(t))), true, 0, db.get_info("GPU", "型号", Convert.ToString(t)), int.Parse(db.get_info("GPU", "显存", Convert.ToString(t))), int.Parse(db.get_info("GPU", "功耗", Convert.ToString(t))));
                    else
                        g = new GPU(int.Parse(db.get_info("GPU", "价格", Convert.ToString(t))), true, int.Parse(db.get_info("GPU", "性能", Convert.ToString(t))), true, 0, db.get_info("GPU", "型号", Convert.ToString(t)), int.Parse(db.get_info("GPU", "显存", Convert.ToString(t))), int.Parse(db.get_info("GPU", "功耗", Convert.ToString(t))));
                    t = rd.Next(1, 28);
                    mem = new Memory(int.Parse(db.get_info("Memory", "价格", Convert.ToString(t))), true, int.Parse(db.get_info("Memory", "性能", Convert.ToString(t))), true, 0, int.Parse(db.get_info("Memory", "容量", Convert.ToString(t))), int.Parse(db.get_info("Memory", "频率", Convert.ToString(t))));
                    t = rd.Next(1, 11);

                    if (db.get_info("Driver", "类型", Convert.ToString(t)) == "HDD")
                        hdd = true;
                    else
                        hdd = false;
                    h = new Harddisk(int.Parse(db.get_info("Driver", "价格", Convert.ToString(t))), true, int.Parse(db.get_info("Driver", "性能", Convert.ToString(t))), true, 0, hdd, int.Parse(db.get_info("Driver", "价格", Convert.ToString(t))));
                    t = rd.Next(1, 24);
                    p = new PSU(int.Parse(db.get_info("PSU", "价格", Convert.ToString(t))), true, 0, true, 0, int.Parse(db.get_info("PSU", "额定功率", Convert.ToString(t))), double.Parse(db.get_info("PSU", "转化率", Convert.ToString(t))));
                    s = new Software(0, true, 0, true, 0, true, false);
                    break;
                case 9:
                    t = rd.Next(1, 21);
                    task = "My computer works extremely slowly, even after I reinstall the system. Who told that reinstalling the system can solve 90% problems? I have been tossing about with it  for all day!";
                    subject = 0;
                    c = new CPU(int.Parse(db.get_info("CPU", "价格", Convert.ToString(t))), true, int.Parse(db.get_info("CPU", "性能", Convert.ToString(t))), true, int.Parse(db.get_info("CPU", "初始等级", Convert.ToString(t))), db.get_info("CPU", "型号", Convert.ToString(t)), double.Parse(db.get_info("CPU", "主频", Convert.ToString(t))), int.Parse(db.get_info("CPU", "功耗", Convert.ToString(t))), int.Parse(db.get_info("CPU", "核心数", Convert.ToString(t))), int.Parse(db.get_info("CPU", "线程数", Convert.ToString(t))));
                    t = rd.Next(1, 8);
                    m = new Mainboard(100, true, 0, true, 0, true, 1, 1, db.get_info("Mainboard", "型号", Convert.ToString(t)), true, true);
                    t = rd.Next(1, 31);
                    if (t == 20 || t == 28 || t == 8 || t == 16 || t == 26)
                        g = new SurpriseGPU(int.Parse(db.get_info("GPU", "价格", Convert.ToString(t))), true, int.Parse(db.get_info("GPU", "性能", Convert.ToString(t))), true, 0, db.get_info("GPU", "型号", Convert.ToString(t)), int.Parse(db.get_info("GPU", "显存", Convert.ToString(t))), int.Parse(db.get_info("GPU", "功耗", Convert.ToString(t))));
                    else
                        g = new GPU(int.Parse(db.get_info("GPU", "价格", Convert.ToString(t))), true, int.Parse(db.get_info("GPU", "性能", Convert.ToString(t))), true, 0, db.get_info("GPU", "型号", Convert.ToString(t)), int.Parse(db.get_info("GPU", "显存", Convert.ToString(t))), int.Parse(db.get_info("GPU", "功耗", Convert.ToString(t))));
                    t = rd.Next(1, 28);
                    mem = new Memory(int.Parse(db.get_info("Memory", "价格", Convert.ToString(t))), true, int.Parse(db.get_info("Memory", "性能", Convert.ToString(t))), true, 0, int.Parse(db.get_info("Memory", "容量", Convert.ToString(t))), int.Parse(db.get_info("Memory", "频率", Convert.ToString(t))));
                    t = rd.Next(1, 11);

                    if (db.get_info("Driver", "类型", Convert.ToString(t)) == "HDD")
                        hdd = true;
                    else
                        hdd = false;
                    h = new Harddisk(int.Parse(db.get_info("Driver", "价格", Convert.ToString(t))), true, int.Parse(db.get_info("Driver", "性能", Convert.ToString(t))), true, 0, hdd, int.Parse(db.get_info("Driver", "价格", Convert.ToString(t))));
                    t = rd.Next(1, 24);
                    p = new PSU(int.Parse(db.get_info("PSU", "价格", Convert.ToString(t))), true, 0, true, 0, int.Parse(db.get_info("PSU", "额定功率", Convert.ToString(t))), double.Parse(db.get_info("PSU", "转化率", Convert.ToString(t))));
                    s = new Software(0, true, 0, true, 0, true, false);
                    break;
                case 10:
                    t = rd.Next(1, 21);
                    task = "My child accidentally kicked down the computer, then the hard disk made a strange noise, and then my child began to learn how to scream like the hard disk! I am afraid that he has learnt how to talk with the hard disk…that's terrible! Can you change another kid...eer, another hard disk for me?";
                    subject = 0;
                    c = new CPU(int.Parse(db.get_info("CPU", "价格", Convert.ToString(t))), true, int.Parse(db.get_info("CPU", "性能", Convert.ToString(t))), true, int.Parse(db.get_info("CPU", "初始等级", Convert.ToString(t))), db.get_info("CPU", "型号", Convert.ToString(t)), double.Parse(db.get_info("CPU", "主频", Convert.ToString(t))), int.Parse(db.get_info("CPU", "功耗", Convert.ToString(t))), int.Parse(db.get_info("CPU", "核心数", Convert.ToString(t))), int.Parse(db.get_info("CPU", "线程数", Convert.ToString(t))));
                    t = rd.Next(1, 8);
                    m = new Mainboard(100, true, 0, true, 0, true, 1, 1, db.get_info("Mainboard", "型号", Convert.ToString(t)), true, true);
                    t = rd.Next(1, 31);
                    if (t == 20 || t == 28 || t == 8 || t == 16 || t == 26)
                        g = new SurpriseGPU(int.Parse(db.get_info("GPU", "价格", Convert.ToString(t))), true, int.Parse(db.get_info("GPU", "性能", Convert.ToString(t))), true, 0, db.get_info("GPU", "型号", Convert.ToString(t)), int.Parse(db.get_info("GPU", "显存", Convert.ToString(t))), int.Parse(db.get_info("GPU", "功耗", Convert.ToString(t))));
                    else
                        g = new GPU(int.Parse(db.get_info("GPU", "价格", Convert.ToString(t))), true, int.Parse(db.get_info("GPU", "性能", Convert.ToString(t))), true, 0, db.get_info("GPU", "型号", Convert.ToString(t)), int.Parse(db.get_info("GPU", "显存", Convert.ToString(t))), int.Parse(db.get_info("GPU", "功耗", Convert.ToString(t))));
                    t = rd.Next(1, 28);
                    mem = new Memory(int.Parse(db.get_info("Memory", "价格", Convert.ToString(t))), true, int.Parse(db.get_info("Memory", "性能", Convert.ToString(t))), true, 0, int.Parse(db.get_info("Memory", "容量", Convert.ToString(t))), int.Parse(db.get_info("Memory", "频率", Convert.ToString(t))));
                    t = rd.Next(1, 11);

                    if (db.get_info("Driver", "类型", Convert.ToString(t)) == "HDD")
                        hdd = true;
                    else
                        hdd = false;
                    h = new Harddisk(int.Parse(db.get_info("Driver", "价格", Convert.ToString(t))), true, int.Parse(db.get_info("Driver", "性能", Convert.ToString(t))), true, 0, hdd, int.Parse(db.get_info("Driver", "价格", Convert.ToString(t))));
                    t = rd.Next(1, 24);
                    p = new PSU(int.Parse(db.get_info("PSU", "价格", Convert.ToString(t))), true, 0, true, 0, int.Parse(db.get_info("PSU", "额定功率", Convert.ToString(t))), double.Parse(db.get_info("PSU", "转化率", Convert.ToString(t))));
                    s = new Software(0, true, 0, true, 0, true, false);
                    break;
                case 11:
                    t = rd.Next(1, 21);
                    task = "I suddenly got a blue screen today. What can I do? I'm going to submit my report next Monday. My files are all there! Please help me!";
                    subject = 0;
                    c = new CPU(int.Parse(db.get_info("CPU", "价格", Convert.ToString(t))), true, int.Parse(db.get_info("CPU", "性能", Convert.ToString(t))), true, int.Parse(db.get_info("CPU", "初始等级", Convert.ToString(t))), db.get_info("CPU", "型号", Convert.ToString(t)), double.Parse(db.get_info("CPU", "主频", Convert.ToString(t))), int.Parse(db.get_info("CPU", "功耗", Convert.ToString(t))), int.Parse(db.get_info("CPU", "核心数", Convert.ToString(t))), int.Parse(db.get_info("CPU", "线程数", Convert.ToString(t))));
                    t = rd.Next(1, 8);
                    m = new Mainboard(100, true, 0, true, 0, true, 1, 1, db.get_info("Mainboard", "型号", Convert.ToString(t)), true, true);
                    t = rd.Next(1, 31);
                    if (t == 20 || t == 28 || t == 8 || t == 16 || t == 26)
                        g = new SurpriseGPU(int.Parse(db.get_info("GPU", "价格", Convert.ToString(t))), true, int.Parse(db.get_info("GPU", "性能", Convert.ToString(t))), true, 0, db.get_info("GPU", "型号", Convert.ToString(t)), int.Parse(db.get_info("GPU", "显存", Convert.ToString(t))), int.Parse(db.get_info("GPU", "功耗", Convert.ToString(t))));
                    else
                        g = new GPU(int.Parse(db.get_info("GPU", "价格", Convert.ToString(t))), true, int.Parse(db.get_info("GPU", "性能", Convert.ToString(t))), true, 0, db.get_info("GPU", "型号", Convert.ToString(t)), int.Parse(db.get_info("GPU", "显存", Convert.ToString(t))), int.Parse(db.get_info("GPU", "功耗", Convert.ToString(t))));
                    t = rd.Next(1, 28);
                    mem = new Memory(int.Parse(db.get_info("Memory", "价格", Convert.ToString(t))), true, int.Parse(db.get_info("Memory", "性能", Convert.ToString(t))), true, 0, int.Parse(db.get_info("Memory", "容量", Convert.ToString(t))), int.Parse(db.get_info("Memory", "频率", Convert.ToString(t))));
                    t = rd.Next(1, 11);

                    if (db.get_info("Driver", "类型", Convert.ToString(t)) == "HDD")
                        hdd = true;
                    else
                        hdd = false;
                    h = new Harddisk(int.Parse(db.get_info("Driver", "价格", Convert.ToString(t))), true, int.Parse(db.get_info("Driver", "性能", Convert.ToString(t))), true, 0, hdd, int.Parse(db.get_info("Driver", "价格", Convert.ToString(t))));
                    t = rd.Next(1, 24);
                    p = new PSU(int.Parse(db.get_info("PSU", "价格", Convert.ToString(t))), true, 0, true, 0, int.Parse(db.get_info("PSU", "额定功率", Convert.ToString(t))), double.Parse(db.get_info("PSU", "转化率", Convert.ToString(t))));
                    s = new Software(0, true, 0, true, 0, true, false);
                    break;
                case 12:
                    t = rd.Next(1, 21);
                    task = "I finally found out where my pet hamster is…but!!! My computer doesn't work today! Believe it or not, it is ruined by my hamster that defecates everywhere. If you want that main board, just take it… Anyway I don't want to look at it anymore. Change another one for me.";
                    subject = 0;
                    c = new CPU(int.Parse(db.get_info("CPU", "价格", Convert.ToString(t))), true, int.Parse(db.get_info("CPU", "性能", Convert.ToString(t))), true, int.Parse(db.get_info("CPU", "初始等级", Convert.ToString(t))), db.get_info("CPU", "型号", Convert.ToString(t)), double.Parse(db.get_info("CPU", "主频", Convert.ToString(t))), int.Parse(db.get_info("CPU", "功耗", Convert.ToString(t))), int.Parse(db.get_info("CPU", "核心数", Convert.ToString(t))), int.Parse(db.get_info("CPU", "线程数", Convert.ToString(t))));
                    t = rd.Next(1, 8);
                    m = new Mainboard(100, true, 0, false, 0, true, 1, 1, db.get_info("Mainboard", "型号", Convert.ToString(t)), true, true);
                    t = rd.Next(1, 31);
                    if (t == 20 || t == 28 || t == 8 || t == 16 || t == 26)
                        g = new SurpriseGPU(int.Parse(db.get_info("GPU", "价格", Convert.ToString(t))), true, int.Parse(db.get_info("GPU", "性能", Convert.ToString(t))), true, 0, db.get_info("GPU", "型号", Convert.ToString(t)), int.Parse(db.get_info("GPU", "显存", Convert.ToString(t))), int.Parse(db.get_info("GPU", "功耗", Convert.ToString(t))));
                    else
                        g = new GPU(int.Parse(db.get_info("GPU", "价格", Convert.ToString(t))), true, int.Parse(db.get_info("GPU", "性能", Convert.ToString(t))), true, 0, db.get_info("GPU", "型号", Convert.ToString(t)), int.Parse(db.get_info("GPU", "显存", Convert.ToString(t))), int.Parse(db.get_info("GPU", "功耗", Convert.ToString(t))));
                    t = rd.Next(1, 28);
                    mem = new Memory(int.Parse(db.get_info("Memory", "价格", Convert.ToString(t))), true, int.Parse(db.get_info("Memory", "性能", Convert.ToString(t))), true, 0, int.Parse(db.get_info("Memory", "容量", Convert.ToString(t))), int.Parse(db.get_info("Memory", "频率", Convert.ToString(t))));
                    t = rd.Next(1, 11);

                    if (db.get_info("Driver", "类型", Convert.ToString(t)) == "HDD")
                        hdd = true;
                    else
                        hdd = false;
                    h = new Harddisk(int.Parse(db.get_info("Driver", "价格", Convert.ToString(t))), true, int.Parse(db.get_info("Driver", "性能", Convert.ToString(t))), true, 0, hdd, int.Parse(db.get_info("Driver", "价格", Convert.ToString(t))));
                    t = rd.Next(1, 24);
                    p = new PSU(int.Parse(db.get_info("PSU", "价格", Convert.ToString(t))), true, 0, true, 0, int.Parse(db.get_info("PSU", "额定功率", Convert.ToString(t))), double.Parse(db.get_info("PSU", "转化率", Convert.ToString(t))));
                    s = new Software(0, true, 0, true, 0, true, false);
                    break;
                case 13:
                    t = rd.Next(1, 21);
                    task = "I got a mouse inside my computer. It even smokes when I turn it on today! I am at a loss. Help me repair it please.";
                    subject = 0;
                    c = new CPU(int.Parse(db.get_info("CPU", "价格", Convert.ToString(t))), true, int.Parse(db.get_info("CPU", "性能", Convert.ToString(t))), true, int.Parse(db.get_info("CPU", "初始等级", Convert.ToString(t))), db.get_info("CPU", "型号", Convert.ToString(t)), double.Parse(db.get_info("CPU", "主频", Convert.ToString(t))), int.Parse(db.get_info("CPU", "功耗", Convert.ToString(t))), int.Parse(db.get_info("CPU", "核心数", Convert.ToString(t))), int.Parse(db.get_info("CPU", "线程数", Convert.ToString(t))));
                    t = rd.Next(1, 8);
                    m = new Mainboard(100, true, 0, false, 0, true, 1, 1, db.get_info("Mainboard", "型号", Convert.ToString(t)), true, true);
                    t = rd.Next(1, 31);
                    if (t == 20 || t == 28 || t == 8 || t == 16 || t == 26)
                        g = new SurpriseGPU(int.Parse(db.get_info("GPU", "价格", Convert.ToString(t))), true, int.Parse(db.get_info("GPU", "性能", Convert.ToString(t))), true, 0, db.get_info("GPU", "型号", Convert.ToString(t)), int.Parse(db.get_info("GPU", "显存", Convert.ToString(t))), int.Parse(db.get_info("GPU", "功耗", Convert.ToString(t))));
                    else
                        g = new GPU(int.Parse(db.get_info("GPU", "价格", Convert.ToString(t))), true, int.Parse(db.get_info("GPU", "性能", Convert.ToString(t))), true, 0, db.get_info("GPU", "型号", Convert.ToString(t)), int.Parse(db.get_info("GPU", "显存", Convert.ToString(t))), int.Parse(db.get_info("GPU", "功耗", Convert.ToString(t))));
                    t = rd.Next(1, 28);
                    mem = new Memory(int.Parse(db.get_info("Memory", "价格", Convert.ToString(t))), true, int.Parse(db.get_info("Memory", "性能", Convert.ToString(t))), true, 0, int.Parse(db.get_info("Memory", "容量", Convert.ToString(t))), int.Parse(db.get_info("Memory", "频率", Convert.ToString(t))));
                    t = rd.Next(1, 11);

                    if (db.get_info("Driver", "类型", Convert.ToString(t)) == "HDD")
                        hdd = true;
                    else
                        hdd = false;
                    h = new Harddisk(int.Parse(db.get_info("Driver", "价格", Convert.ToString(t))), true, int.Parse(db.get_info("Driver", "性能", Convert.ToString(t))), true, 0, hdd, int.Parse(db.get_info("Driver", "价格", Convert.ToString(t))));
                    t = rd.Next(1, 24);
                    p = new PSU(int.Parse(db.get_info("PSU", "价格", Convert.ToString(t))), true, 0, true, 0, int.Parse(db.get_info("PSU", "额定功率", Convert.ToString(t))), double.Parse(db.get_info("PSU", "转化率", Convert.ToString(t))));
                    s = new Software(0, true, 0, true, 0, true, false);
                    break;
                case 14:
                    t = rd.Next(1, 21);
                    task = "My computer died again toady. I got a blue screen. I could not even get into the BIOS. I don't know what happened. Please help me fix it.";
                    subject = 0;
                    c = new CPU(int.Parse(db.get_info("CPU", "价格", Convert.ToString(t))), true, int.Parse(db.get_info("CPU", "性能", Convert.ToString(t))), true, int.Parse(db.get_info("CPU", "初始等级", Convert.ToString(t))), db.get_info("CPU", "型号", Convert.ToString(t)), double.Parse(db.get_info("CPU", "主频", Convert.ToString(t))), int.Parse(db.get_info("CPU", "功耗", Convert.ToString(t))), int.Parse(db.get_info("CPU", "核心数", Convert.ToString(t))), int.Parse(db.get_info("CPU", "线程数", Convert.ToString(t))));
                    t = rd.Next(1, 8);
                    m = new Mainboard(100, true, 0, false, 0, true, 1, 1, db.get_info("Mainboard", "型号", Convert.ToString(t)), true, true);
                    t = rd.Next(1, 31);
                    if (t == 20 || t == 28 || t == 8 || t == 16 || t == 26)
                        g = new SurpriseGPU(int.Parse(db.get_info("GPU", "价格", Convert.ToString(t))), true, int.Parse(db.get_info("GPU", "性能", Convert.ToString(t))), true, 0, db.get_info("GPU", "型号", Convert.ToString(t)), int.Parse(db.get_info("GPU", "显存", Convert.ToString(t))), int.Parse(db.get_info("GPU", "功耗", Convert.ToString(t))));
                    else
                        g = new GPU(int.Parse(db.get_info("GPU", "价格", Convert.ToString(t))), true, int.Parse(db.get_info("GPU", "性能", Convert.ToString(t))), true, 0, db.get_info("GPU", "型号", Convert.ToString(t)), int.Parse(db.get_info("GPU", "显存", Convert.ToString(t))), int.Parse(db.get_info("GPU", "功耗", Convert.ToString(t))));
                    t = rd.Next(1, 28);
                    mem = new Memory(int.Parse(db.get_info("Memory", "价格", Convert.ToString(t))), true, int.Parse(db.get_info("Memory", "性能", Convert.ToString(t))), true, 0, int.Parse(db.get_info("Memory", "容量", Convert.ToString(t))), int.Parse(db.get_info("Memory", "频率", Convert.ToString(t))));
                    t = rd.Next(1, 11);

                    if (db.get_info("Driver", "类型", Convert.ToString(t)) == "HDD")
                        hdd = true;
                    else
                        hdd = false;
                    h = new Harddisk(int.Parse(db.get_info("Driver", "价格", Convert.ToString(t))), true, int.Parse(db.get_info("Driver", "性能", Convert.ToString(t))), true, 0, hdd, int.Parse(db.get_info("Driver", "价格", Convert.ToString(t))));
                    t = rd.Next(1, 24);
                    p = new PSU(int.Parse(db.get_info("PSU", "价格", Convert.ToString(t))), true, 0, true, 0, int.Parse(db.get_info("PSU", "额定功率", Convert.ToString(t))), double.Parse(db.get_info("PSU", "转化率", Convert.ToString(t))));
                    s = new Software(0, true, 0, true, 0, true, false);
                    break;
            }
        }
        public int get_subject()
        {
            return subject;
        }
        public String get_task()
        {
            return task;
        }
    }
}
