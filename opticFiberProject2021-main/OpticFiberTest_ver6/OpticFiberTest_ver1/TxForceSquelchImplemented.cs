using System;
using System.Collections.Generic;

namespace OpticFiberTest_ver1.Protocols_classes.Classes_SFF8636
{
    class TxForceSquelchImplemented : SFF8636
    {
        public TxForceSquelchImplemented()
        {
            m_title = "Tx Force Squelch Implemented";
            m_size = 1;
            m_FirstBit = 3;
            m_LastBit = 3;
            m_address = 227;
            m_page = 3;
            m_dict = new Dictionary<uint, string>();

            m_dict.Add(0, "\n\tTx Force Squelch not  implemented\n");
            m_dict.Add(1, "\n\tTx Force Squelch implemented\n");
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
