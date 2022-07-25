using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpticFiberTest_ver1.Protocols_classes.Classes_SFF8636
{
    class ReservedBits:SFF8636
    {
        public ReservedBits(int address, short firstBit, short lastBit)
        {
            m_title = "Check Reserved Bits";
            fBit = firstBit;
            lBit = lastBit;
            m_address = (byte)address;
            m_size = 1;
            m_page = 3;
        }
        public override void EncodeValue(string name)
        {
            if (CheckBits(name, fBit, lBit) != "")
                m_storedValue += CheckBits(name, fBit, lBit);
        }
        public string CheckBits(string hexByte, short firstBit, short lastBit)
        {
            string reserved = "00000000";
            reserved = reserved.Substring(firstBit, lastBit-firstBit+1);
            string FiberBits = Converstions.BitsFromByte.HexToBinaryBytes(hexByte).Substring(firstBit, lastBit - firstBit + 1);
            if (FiberBits == reserved)
                return "";
            else
                return "\n\t bits " + firstBit.ToString() + " - " + lastBit.ToString() + "\n\t must be " + reserved + " but it is " + FiberBits;
        }
        short fBit;
        short lBit;
    }

}
