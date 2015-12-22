///anthor: billy huang///
/////////////////////////
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Management;
using System.Windows.Forms;
using System.Drawing;
using System.Runtime.InteropServices;

namespace CheckSKU
{
    class Core
    {
        private Form1 ui;
        private uint minorFlag = 0;
        public Core(Form1 form1)
        {
            this.ui = form1;
        }

        OneBiosInfo[] specInfo;
        string spec = "";
        string current = "";
        string biosVendorString = "";
        static uint OBBIT0 = 0x1;
        static uint OBBIT1 = 0x2;
        static uint OBBIT2 = 0x4;
        static uint OBBIT3 = 0x8;
        static uint OBBIT4_5 = 0x30;
        static uint OBBIT6 = 0x40;
        static uint OBBIT7 = 0x80;

        /// <summary>
        /// 取得目前在smbios中的0xad值
        /// </summary>
        /// <param name="MinorFlag"></param>
        /// <param name="MajorFlag"></param>
        private void getOneBiosRunTimeData(uint MinorFlag, uint MajorFlag, int oneBiosIndex)
        {
            minorFlag = MinorFlag;
            try
            {
                OneBiosInfo obi = new OneBiosInfo();
                obi.bootMenu = MinorFlag & OBBIT0;
                obi.bootFilter = ((MinorFlag & OBBIT1) >> 1);
                obi.csm = (MinorFlag & OBBIT2) >> 2;
                obi.secureBoot = (MinorFlag & OBBIT3) >> 3;
                obi.sataMode = (MinorFlag & OBBIT4_5) >> 4;
                obi.slicTable = (MinorFlag & OBBIT6) >> 6;
                obi.msdmTable = (MinorFlag & OBBIT7) >> 7;

                string bootMenu = (obi.bootMenu == 1) ? "Enable " : "Disable";
                string bootFilter = (obi.bootFilter == 1) ? "Legacy   " : " UEFI    ";
                string csm = (obi.csm == 1) ? "Always" : " Never";
                string secureBoot = (obi.secureBoot == 1) ? "Enable   " : "Disable  ";
                string sataMode = "";
                switch (obi.sataMode)
                {
                    case 0:
                        sataMode = " IDE";
                        break;
                    case 1:
                        sataMode = "AHCI";
                        break;
                    case 2:
                        sataMode = "RAID";
                        break;
                }
                string slicTable = (obi.slicTable == 1) ? "Enable    " : "Disable   ";
                string msdmTable = (obi.msdmTable == 1) ? "Enable " : "Disable";
                current = string.Format("{0:X4}h    {1:X4}h   {2}  {3} {4}     {5}   {6}    {7}       {8}\n", MajorFlag, MinorFlag, msdmTable, slicTable, sataMode, secureBoot, csm, bootFilter, bootMenu);
                ui.CurrentLabel = current;
            }
            catch (Exception e)
            {
                Console.WriteLine("{0} Exception caught.", e);
                ui.Label1.Visible = true;
                ui.Label1.Text = "Fail!";
                ui.Label1.ForeColor = Color.Red;
                ui.CurrentLabel = "No SKUID found!";

                ui.Label4 = "OS SKU: " + " N/A";
            }
            if (oneBiosIndex == 0)
            {
                ui.Label1.Visible = true;
                ui.Label1.Text = "Fail!";
                ui.Label1.ForeColor = Color.Red;
                ui.CurrentLabel = "No SKUID found!";
                ui.Label4 = "OS SKU: " + " N/A";
            }
        }
        /// <summary>
        /// 找spec對應的table
        /// </summary>
        /// <param name="MajorFlag"></param>
        private void getOneBiosSpecData(uint MajorFlag, int oneBiosIndex)
        {
            try
            {
                string spBootMenu = (specInfo[MajorFlag - 1].bootMenu == 1) ? "Enable " : "Disable";
                string spBootFilter = (specInfo[MajorFlag - 1].bootFilter == 1) ? "Legacy   " : " UEFI    ";
                string spCsm = (specInfo[MajorFlag - 1].csm == 1) ? "Always" : " Never";
                string spSecureBoot = (specInfo[MajorFlag - 1].secureBoot == 1) ? "Enable   " : "Disable  ";
                string spSataMode = "";
                switch (specInfo[MajorFlag - 1].sataMode)
                {
                    case 0:
                        spSataMode = " IDE";
                        break;
                    case 1:
                        spSataMode = "AHCI";
                        break;
                    case 2:
                        spSataMode = "RAID";
                        break;
                }
                string spSlicTable = (specInfo[MajorFlag - 1].slicTable == 1) ? "Enable    " : "Disable   ";
                string spMsdmTable = (specInfo[MajorFlag - 1].msdmTable == 1) ? "Enable " : "Disable";
                spec = string.Format("{0:X4}h    {1:X4}h   {2}  {3} {4}     {5}   {6}    {7}       {8}\n", MajorFlag, specInfo[MajorFlag - 1].minorFlag, spMsdmTable, spSlicTable, spSataMode, spSecureBoot, spCsm, spBootFilter, spBootMenu);
                //listBox1.Items.Add(spec);
                ui.SpecLabel = spec;
                ui.Label4 = "OS SKU: " + specInfo[MajorFlag - 1].osString;
            }
            catch (Exception e)
            {
                Console.WriteLine("{0} Exception caught.", e);
                ui.Label1.Visible = true;
                ui.Label1.Text = "Fail!";
                ui.Label1.ForeColor = Color.Red;
                ui.SpecLabel = "No SKUID found!";
                ui.Label4 = "OS SKU: " + " N/A";
            }
            if (oneBiosIndex == 0)
            {
                ui.Label1.Visible = true;
                ui.Label1.Text = "Fail!";
                ui.Label1.ForeColor = Color.Red;
                ui.SpecLabel = "No SKUID found!";
                ui.Label4 = "OS SKU: " + " N/A";
            }
        }

        public void startAnimation(Timer t, bool enable)
        {
            t.Interval = 20;
            t.Enabled = true;
            t.Tick += ui.oneBiosTimer;
        }

        public void closeWindow()
        {
            if (MiniAnimation.closeTool())
                ui.Close();
        }

        public void parameterCheck(string[] par, ref bool animaionEnable)//chech /s
        {
            animaionEnable = true;
            try
            {
                if (par.Length > 0)
                    if (par[0] == @"/s")
                    {
                        //ui.Close();
                        animaionEnable = false;
                    }
            }
            catch
            {
            }
        }

        private string getBiosVendor(int oneBiosTypeLength)
        {
            /*const uint biosVendorPos = 24;
            const uint maxVendorLength = 30;
            uint index = 0;
            int bufferSize=20;
            Byte[] biosVendorStr = new Byte[maxVendorLength];
            try
            {
                while (smBiosData[biosVendorPos + index] != 0)
                {
                    biosVendorStr[index] = smBiosData[biosVendorPos + index++];
                }
            }
            catch (Exception e)
            {
                return "Error!!";
            }
            */
            return oneBiosTypeLength.ToString(); ;
        }

        public void getSMBIOSDataAndCheckSKU()
        {
            ManagementScope scope = new ManagementScope("\\\\.\\ROOT\\WMI");
            ObjectQuery query = new ObjectQuery("SELECT * FROM MSSmBios_RawSMBiosTables Where InstanceName=\"SMBiosData\"");
            ManagementObjectSearcher searcher = new ManagementObjectSearcher(scope, query);
            ManagementObjectCollection queryCollection = searcher.Get();

            bool checkType = true;
            int index = 0;
            int typeLength = 0;
            int oneBiosIndex = 0;
            int oneBiosTypeLength = 0;
            foreach (ManagementObject m in queryCollection)
            {
                Byte[] arrSMBiosData = (Byte[])(m["SMBiosData"]);
                ///////////////////////////////////////////////
                /////////search onebios table//////////////////
                ///////////////////////////////////////////////
                while (index < arrSMBiosData.Length)
                {
                    if (checkType)//確認此type是否為0xad
                    {
                        if (arrSMBiosData[index] != 0xad)
                        {
                            typeLength = arrSMBiosData[index + 1];
                            if (typeLength == 0)
                                break;
                            checkType = false;
                        }
                        else//找到0xad的位置
                        {
                            oneBiosTypeLength = arrSMBiosData[index + 1];
                            oneBiosIndex = index;
                            biosVendorString = getBiosVendor(oneBiosTypeLength);
                            //ui.Text = biosVendorString;
                            break;
                        }
                    }
                    else//找此type的字串結尾
                    {
                        index += typeLength;
                        while (true)
                        {
                            if (arrSMBiosData[index] == 0 && arrSMBiosData[index + 1] == 0)
                                break;
                            index++;
                        }
                        index += 2;
                        checkType = true;
                    }
                }

                uint MinorFlag = arrSMBiosData[oneBiosIndex + 6];
                uint MajorFlag = arrSMBiosData[oneBiosIndex + 4];
                specInfo = SpecData.getSpecTable();//給下面的用
                getOneBiosSpecData(MajorFlag, oneBiosIndex);//找spec對應的table
                getOneBiosRunTimeData(MinorFlag, MajorFlag, oneBiosIndex);//取0xad的值
                if (spec == current)
                {
                    ui.Label1.Text = "Pass!";
                    ui.Label1.ForeColor = Color.Green;
                }
                else
                {
                    ui.Label1.Visible = true;
                    ui.Label1.Text = "Fail!";
                    ui.Label1.ForeColor = Color.Red;
                }
            }

        }
        public void genLogFile(List<Label> labels)
        {
            if (biosVendorString == "8")//AMI的bios才做log，原本是字串"AMI"，spec有點問題  所以改方法
            {
                using (System.IO.StreamWriter file = new System.IO.StreamWriter(DateTime.Now.ToString("yyyy_MM_dd_hh_mm_") + "result.log", true))
                {
                    for (int i = 0; i < 7; i++)
                    {
                        if (i == 2 || i == 5)
                            file.WriteLine("SKUID    Value    MSDM    SLIC       SATA     Secure Boot   CSM      Boot Filter    BootMenu");
                        else
                            file.WriteLine(labels[i].Text);
                    }
                    file.WriteLine("");
                    file.WriteLine("Minor flag binary value: " + Convert.ToString(minorFlag, 2));
                    file.WriteLine(DateTime.Now.ToString("tt yyyy:MM:dd:hh:mm ") + "Test result----------" + ui.Label1.Text);
                }
            }
        }
    }
}
