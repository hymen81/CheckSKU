using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckSKU
{
    public class OneBiosInfo
    {
        public uint bootMenu;
        public uint bootFilter;
        public uint csm;
        public uint secureBoot;
        public uint sataMode;
        public uint slicTable;
        public uint msdmTable;
        public uint reserved;
        public uint minorFlag;
        public string osString = "";
    }
}
