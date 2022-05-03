using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpticFiberTest_ver1.Classes_SFF8636
{
    class MaxRxOutputEmphasis : SFF8636
    {
        public MaxRxOutputEmphasis()
        {
            // the title of byte
            m_title = "Max Rx Output Emphasis";
            // the size of byte
            m_size = 1;
            // the address of byte
            m_address = 224;
            // locate in page num
            m_page = 3;
            m_FirstIndex = 3;
            m_LastIndex = 0;
            byte b = i2cReader.AAI2cEeprom.getByte(m_address, 3);
            m_Max = Converstions.BitsFromByte.getStrBitAsUintFromByte(b, m_FirstIndex, m_LastIndex);

        }

        public override void EncodeValue(string name)
        {
            m_storedValue = "Max is: " + Convert.ToString(m_Max);
        }
        private int m_FirstIndex;
        private int m_LastIndex;
        private uint m_Max;
    }
}
