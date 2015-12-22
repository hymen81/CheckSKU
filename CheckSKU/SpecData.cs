using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckSKU
{
    public static class SpecData
    {
        private const int specTableSize = 12;
        private static OneBiosInfo[] specInfo = new OneBiosInfo[specTableSize];
        public static OneBiosInfo[] getSpecTable()
        {
            for (int i = 0; i < specTableSize; i++)
                specInfo[i] = new OneBiosInfo();

            specInfo[0].msdmTable = 0;
            specInfo[0].slicTable = 0;
            specInfo[0].sataMode = 1;
            specInfo[0].secureBoot = 0;
            specInfo[0].csm = 1;
            specInfo[0].bootFilter = 1;
            specInfo[0].bootMenu = 1;
            specInfo[0].osString = "Android or FreeDos";
            specInfo[0].minorFlag = 0x17;

            specInfo[1].msdmTable = 0;
            specInfo[1].slicTable = 1;
            specInfo[1].sataMode = 1;
            specInfo[1].secureBoot = 0;
            specInfo[1].csm = 1;
            specInfo[1].bootFilter = 0;
            specInfo[1].bootMenu = 1;
            specInfo[1].osString = "Win7(64 bit GPT) AHCI";
            specInfo[1].minorFlag = 0x55;

            specInfo[2].msdmTable = 0;
            specInfo[2].slicTable = 1;
            specInfo[2].sataMode = 1;
            specInfo[2].secureBoot = 0;
            specInfo[2].csm = 1;
            specInfo[2].bootFilter = 1;
            specInfo[2].bootMenu = 1;
            specInfo[2].osString = "Win7/Win7(64bit/32bit MBR) or Win7(64 bit MBR) or Win7(32 bit MBR) AHCI";
            specInfo[2].minorFlag = 0x57;

            specInfo[3].msdmTable = 1;
            specInfo[3].slicTable = 0;
            specInfo[3].sataMode = 1;
            specInfo[3].secureBoot = 1;
            specInfo[3].csm = 0;
            specInfo[3].bootFilter = 0;
            specInfo[3].bootMenu = 1;
            specInfo[3].osString = "Win8 or Win10 (64 bit GPT) AHCI";
            specInfo[3].minorFlag = 0x99;

            specInfo[4].msdmTable = 1;
            specInfo[4].slicTable = 1;
            specInfo[4].sataMode = 1;
            specInfo[4].secureBoot = 0;
            specInfo[4].csm = 1;
            specInfo[4].bootFilter = 0;
            specInfo[4].bootMenu = 1;
            specInfo[4].osString = "Win8/Win7 or Win10/Win7 (64bit/64bit GPT) AHCI";
            specInfo[4].minorFlag = 0xd5;

            specInfo[5].msdmTable = 0;
            specInfo[5].slicTable = 1;
            specInfo[5].sataMode = 2;
            specInfo[5].secureBoot = 0;
            specInfo[5].csm = 1;
            specInfo[5].bootFilter = 0;
            specInfo[5].bootMenu = 1;
            specInfo[5].osString = "Win7(64 bit GPT) RAID RAID";
            specInfo[5].minorFlag = 0x65;

            specInfo[6].msdmTable = 0;
            specInfo[6].slicTable = 1;
            specInfo[6].sataMode = 2;
            specInfo[6].secureBoot = 0;
            specInfo[6].csm = 1;
            specInfo[6].bootFilter = 1;
            specInfo[6].bootMenu = 1;
            specInfo[6].osString = "Win7/Win7(64bit/32bit MBR) or Win7(64 bit MBR) or Win7(32 bit MBR) RAID";
            specInfo[6].minorFlag = 0x67;

            specInfo[7].msdmTable = 1;
            specInfo[7].slicTable = 0;
            specInfo[7].sataMode = 2;
            specInfo[7].secureBoot = 1;
            specInfo[7].csm = 0;
            specInfo[7].bootFilter = 0;
            specInfo[7].bootMenu = 1;
            specInfo[7].osString = "Win8 or Win10 (64 bit GPT) RAID";
            specInfo[7].minorFlag = 0xa9;

            specInfo[8].msdmTable = 1;
            specInfo[8].slicTable = 1;
            specInfo[8].sataMode = 2;
            specInfo[8].secureBoot = 0;
            specInfo[8].csm = 1;
            specInfo[8].bootFilter = 0;
            specInfo[8].bootMenu = 1;
            specInfo[8].osString = "Win8/Win7 or Win10/Win7 (64bit/64bit GPT) RAID";
            specInfo[8].minorFlag = 0xe5;

            specInfo[9].msdmTable = 1;
            specInfo[9].slicTable = 1;
            specInfo[9].sataMode = 1;
            specInfo[9].secureBoot = 1;
            specInfo[9].csm = 0;
            specInfo[9].bootFilter = 0;
            specInfo[9].bootMenu = 1;
            specInfo[9].osString = "Win8 or Win10 Pro x64 (64 bit GPT) AHCI";
            specInfo[9].minorFlag = 0xd9;

            specInfo[10].msdmTable = 1;
            specInfo[10].slicTable = 1;
            specInfo[10].sataMode = 2;
            specInfo[10].secureBoot = 1;
            specInfo[10].csm = 0;
            specInfo[10].bootFilter = 0;
            specInfo[10].bootMenu = 1;
            specInfo[10].osString = "Win8 or Win10 Pro x64 (64 bit GPT) RAID";
            specInfo[10].minorFlag = 0xe9;

            specInfo[11].msdmTable = 0;
            specInfo[11].slicTable = 0;
            specInfo[11].sataMode = 1;
            specInfo[11].secureBoot = 0;
            specInfo[11].csm = 1;
            specInfo[11].bootFilter = 0;
            specInfo[11].bootMenu = 1;
            specInfo[11].osString = "Linpus Linux";
            specInfo[11].minorFlag = 0x15;
            return specInfo;
        }

    }
}
