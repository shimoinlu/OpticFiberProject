using System;
using System.Collections.Generic;

namespace OpticFiberTest_ver1.Protocols_classes.Classes_SFF8636
{
    class RxLOSLFastMode : SFF8636
    {
        public RxLOSLFastMode()
        {
            m_title = "Rx LOSL Fast Mode Supported";
            m_size = 1;
            m_FirstBit = 2;
            m_LastBit = 2;
            m_address = 227;
            m_page = 3;
            m_dict = new Dictionary<uint, string>();

            m_dict.Add(0, "\n\tRxLOSL fast mode is not supported.\n");
            m_dict.Add(1, "\n\tRxLOSL fast mode is not supported.\n");
        }
        /****************************************************************
        * This function is encoding, comparing and define the value according sff-8636
        ***************************************************************/
        public override void EncodeValue(string name)
        {
            byte b = Convert.ToByte(name.Substring(0, 2), 16);
            uint bit;
            bit = Converstions.BitsFromByte.getStrBitAsUintFromByte(b, (int)m_FirstBit, (int)m_LastBit);
            m_storedValue += m_dict[bit];
        }

        private uint m_FirstBit;
        private uint m_LastBit;
        private Dictionary<uint, string> m_dict;  //the Dictionary of the ExtIdentifier

    }
}