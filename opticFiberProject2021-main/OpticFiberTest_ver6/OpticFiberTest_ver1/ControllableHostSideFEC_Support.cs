using System;
using System.Collections.Generic;

namespace OpticFiberTest_ver1.Classes_SFF8636
{
    class ControllableHostSideFEC_Support : SFF8636
    {
        public ControllableHostSideFEC_Support()
        {
            m_title = "Controllable Host Side FEC Support";
            m_size = 1;
            m_FirstBit = 7;
            m_LastBit = 7;
            m_address = 227;
            m_page = 3;
            m_dict = new Dictionary<uint, string>();

            m_dict.Add(0, "\n\tModule’s host-side FEC, if any, is not controllable by the host\n");
            m_dict.Add(1, "\n\t Module can terminate and generate FEC encoding from and to the host under control of thehost\n");
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
