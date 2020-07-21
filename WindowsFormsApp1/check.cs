using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    class Check
    {
        private Event t;
        private int previousPerformance;

        public Check( Event a)
        {
            t = a;
        }
        public int pass0()//0表示没修好，1表示未完全修好，2表示完全修好
        {
            if (t.m.getCPUInstall() != true)
                return 0;
            if (t.m.getPSUInstall() != true)
                return 0;
            if (t.m.getGoodness() != true)
                return 0;
            if (t.m.getGPUNum() == 0 || t.m.getMemoryNum() == 0)
                return 0;
            if (t.c.getGoodness() == false)
                return 0;
            if (t.mem.getGoodness() == false)
                return 0;
            if (t.g.getGoodness() == false)
                return 0;
            if (t.h.getGoodness() == false)
                return 0;
            if (t.s.getSystem() == false)
                return 0;
            if (t.p.getGoodness() == false)
                return 0;
            if (t.c.getPower() + t.g.getPower() + 50 > t.p.getRatedPower())
                return 0;
            if (t.s.getVirus() == true)
                return 1;
            return 2;
        }
        public void savePrevious()
        {
            int sum = 0;
            sum += t.c.getCapability();
            sum += t.g.getCapability();
            sum += t.mem.getCapability();
            sum += t.h.getCapability();
            previousPerformance = sum;
        }
        public bool pass1(Event a)//判断升级是否成功
        {
            t = a;
            int sum = 0;
            sum += t.c.getCapability();
            sum += t.g.getCapability();
            sum += t.mem.getCapability();
            sum += t.h.getCapability();
            if (sum > previousPerformance)
                return true;
            else
                return false;
        }
        public bool pass2(Event a)
        {
            t = a;
            if (t.m.getCPUInstall() != true)
                return false;
            if (t.m.getGPUNum() == 0 || t.m.getMemoryNum() == 0)
                return false;
            if (t.m.getPSUInstall() != true)
                return false;
            if (t.s.getSystem() == false)
                return false;
            return true;
        }
    }
}
