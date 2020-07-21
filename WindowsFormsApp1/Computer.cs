using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public interface IComputer
    {

        double getPrice();
        bool getOldness();
        int getCapability();
        bool getGoodness();
        int getLevel();
        void setPrice(double p);
        void setOldness(bool o);
        void setCapability(int c);
        void setGoodness(bool g);
        void setLevel(int l);


    }

    public class Computer : IComputer
    {
        private double price;
        private bool old;
        private int capability;
        private bool good;
        private int level;
        public double getPrice() { return price; }
        public bool getOldness() { return old; }
        public int getCapability() { return capability; }
        public bool getGoodness() { return good; }
        public int getLevel() { return level; }
        public void setPrice(double p) { price = p; }
        public void setOldness(bool o) { old = o; }
        public void setCapability(int c) { capability = c; }
        public void setGoodness(bool g) { good = g; }
        public void setLevel(int l) { level = l; }
        public Computer(double d = 0, bool old = true, int c = 0, bool good = true, int l = 0)
        {
            price = d;
            this.old = old;
            capability = c;
            this.good = good;
            level = l;
        }

    }

    public interface ICPU : IComputer
    {
        string getModel();
        double getMainFrequency();
        double getPower();
        void setModel(string s);
        void setFrequency(double d);
        void setPower(double d);
        void setCores(int x);
        void setThreads(int x);
        int getCores();
        int getThreads();
    }

    public class CPU : Computer, ICPU
    {
        private int cores;
        private int threads;
        private string model;
        private double mainFrequency;
        private double power;
        public string getModel() { return model; }
        public double getMainFrequency() { return mainFrequency; }
        public double getPower() { return power; }
        public void setModel(string s) { model = s; }
        public void setFrequency(double d) { mainFrequency = d; }
        public void setPower(double d) { power = d; }
        public CPU(double d = 0, bool old = true, int c = 0, bool good = false, int l = 0, string s = "", double m = 0, double p = 0,int core=0,int th=0) : base(d, old, c, good, l)
        {

            model = s;
            mainFrequency = m;
            power = p;
            cores = core;
            threads = th;
        }
        public void setCores(int x) { cores = x; }
        public void setThreads(int x) { threads = x; }
        public int getCores() { return cores; }
        public int getThreads() { return threads; }
    }

    public interface IMemory : IComputer
    {
        double getCapacity();
        double getFrequency();
        void setCapacity(double d);
        void setFrequency(double d);


    }

    public class Memory : Computer, IMemory
    {
        private double capacity;
        private double frequency;
        public double getCapacity() { return capacity; }
        public double getFrequency() { return frequency; }
        public void setCapacity(double d) { capacity = d; }
        public void setFrequency(double d) { frequency = d; }
        public Memory(double d = 0, bool old = true, int c = 0, bool good = false, int l = 0, double m = 0, double f = 0) : base(d, old, c, good, l)
        {
            capacity = m;
            frequency = f;
        }
    }


    public interface IGPU : IComputer
    {
        string getModel();
        double getVram();
        double getPower();
        void setModel(string s);
        void setVram(double d);
        void setPower(double d);
    }

    public class GPU : Computer, IGPU
    {
        private string model;
        private double vram;
        private double power;
        public virtual string getModel() { return model; }
        public double getVram() { return vram; }
        public double getPower() { return power; }
        public void setModel(string s) { model = s; }
        public void setVram(double d) { vram = d; }
        public void setPower(double d) { power = d; }
        public GPU(double d = 0, bool old = true, int c = 0, bool good = false, int l = 0, string s = "", double m = 0, double f = 0) : base(d, old, c, good, l)
        {
            model = s;
            vram = m;
            power = f;
        }
    }

    public interface IMainboard : IComputer
    {
        bool getCPUInstall();
        bool getPSUInstall();
        bool getHDDInstall();
        int getMemoryNum();
        int getGPUNum();
        string getModel();
        void setCPUInstall(bool b);
        void setPSUInstall(bool b);
        void setHDDInstall(bool b);
        void setMemoryNum(int x);
        void setGPUNum(int x);
        void setModel(String s);
    }

    public class Mainboard : Computer, IMainboard
    {
        private bool CPUInstall;
        private bool PSUInstall;
        private bool HDDInstall;
        private int memoryNum;
        private int GPUNum;
        private string model;
        public bool getCPUInstall() { return CPUInstall; }
        public bool getPSUInstall() { return PSUInstall; }
        public bool getHDDInstall() { return HDDInstall; }
        public int getMemoryNum() { return memoryNum; }
        public int getGPUNum() { return GPUNum; }
        public string getModel() { return model; }
        public void setCPUInstall(bool b) { CPUInstall = b; }
        public void setPSUInstall(bool b) { PSUInstall = b; }
        public void setHDDInstall(bool b) { HDDInstall = b; }
        public void setMemoryNum(int x) { memoryNum = x; }
        public void setGPUNum(int m) { GPUNum = m; }
        public void setModel(string s) { model = s; }
        public Mainboard(double d = 0, bool old = true, int c = 0, bool good = false, int l = 0, bool install = false, int m = 0, int f = 0, string s = "",bool p=true,bool h=true) : base(d, old, c, good, l)
        {
            CPUInstall = install;
            PSUInstall = p;
            HDDInstall = h;
            memoryNum = m;
            GPUNum = f;
            model = s;
        }
    }

    public interface IHarddisk : IComputer
    {
        bool getMechanics();
        double getCapacity();
        void setMechanics(bool b);
        void setCapacity(double d);
    }

    public class Harddisk : Computer, IHarddisk
    {
        private bool mechanics;
        private double capacity;
        public bool getMechanics() { return mechanics; }
        public double getCapacity() { return capacity; }
        public void setMechanics(bool b) { mechanics = b; }
        public void setCapacity(double d) { capacity = d; }
        public Harddisk(double d = 0, bool old = true, int c = 0, bool good = false, int l = 0, bool mechanics = true, double f = 0) : base(d, old, c, good, l)
        {
            capacity = f;
            this.mechanics = mechanics;
        }
    }

    public interface IPSU : IComputer
    {
        double getRatedPower();
        void setRatedPower(double d);
        void setConversionRate(double d);
        double getConversionRate();
    }

    public class PSU : Computer, IPSU
    {
        private double ratedPower;
        private double conversionRate;
        public double getRatedPower() { return ratedPower; }
        public void setRatedPower(double d) { ratedPower = d; }
        public PSU(double d = 0, bool old = true, int c = 0, bool good = false, int l = 0, double f = 0,double con=0) : base(d, old, c, good, l)
        {
            ratedPower = f;
            conversionRate = con;
        }
        public void setConversionRate(double d) { conversionRate = d; }
        public double getConversionRate() { return conversionRate; }
    }


    public interface ISoftware : IComputer
    {
        bool getSystem();
        bool getVirus();
        void setSystem(bool b);
        void setVirus(bool b);
    }

    public class Software : Computer, ISoftware
    {
        private bool system;
        private bool virus;
        public bool getSystem() { return system; }
        public bool getVirus() { return virus; }
        public void setSystem(bool b) { system = b; }
        public void setVirus(bool b) { virus = b; }
        public Software(double d = 0, bool old = true, int c = 0, bool good = false, int l = 0, bool system = true, bool virus = false) : base(d, old, c, good, l)
        {
            this.system = system;
            this.virus = virus;
        }
    }
    public interface ISurpriseGPU : IGPU
    {
        string getModel();
    }

    public class SurpriseGPU : GPU, ISurpriseGPU
    {
        bool hasShown = false;
        public SurpriseGPU(double d = 0, bool old = true, int c = 0, bool good = false, int l = 0, string s = "", double m = 0, double f = 0) : base(d, old, c, good, l, s, m, f) { }
        public override string getModel()
        {
            string s = base.getModel();
            
            if (s == "RTX-2080ti" && hasShown == false)
            {
                hasShown = true;
                PCBS.super = 8;
                surprised window = new surprised();
                window.ShowDialog();
            }
            else if (s == "Titan Xp" && hasShown == false)
            {
                PCBS.super = 7;
                hasShown = true;
                surprised window = new surprised();
                window.ShowDialog();

            }
            else if (s == "GTX-1660ti" && hasShown == false)
            {
                PCBS.super = 6;
                hasShown = true;
                surprised window = new surprised();
                window.ShowDialog();

            }
            else if (s == "Radeon VII" && hasShown == false)
            {
                PCBS.super = 5;
                hasShown = true;
                surprised window = new surprised();
                window.ShowDialog();

            }
            else if (s == "Titan RTX" && hasShown == false)
            {
                PCBS.super = 4;
                hasShown = true;
                surprised window = new surprised();
                window.ShowDialog();

            }
            return s;
        }
    }
}
