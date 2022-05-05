using System;
using System.Collections.Generic;

namespace OpticFiberTest_ver1.Classes_SFF8636
{
    class RxOutputEmphasisSupport : SFF8636
    {
        public RxOutputEmphasisSupport()
        {
            m_title = "Rx Output Emphasis Support";
            m_size = 1;
            m_FirstBit = 0;
            m_LastBit = 3;
            m_address = 225;
            m_page = 3;
            dict = new Dictionary<int, string>[]() {
                { 0, "=00b Peak-to-peak amplitude stays constant, or not\n\timplemented, or no informationstays\n\tconstant, or not implemented, or no\n\tinformation\n\t" }, //7-2
                { 1, "Reserved"} //last bits is binary from here (00b 01b 10b 11b) we will use the decimal value
            };
            dict2 = new Dictionary<int, string>() {
                { 0, "=00b Peak-to-peak amplitude stays constant, or not\n\timplemented, or no informationstays\n\tconstant, or not implemented, or no\n\tinformation\n\t" }, //7-2
                { 1, "Reserved"} //last bits is binary from here (00b 01b 10b 11b) we will use the decimal value
            };
            dict3 = new Dictionary<int, string>() {
                { 0, "=00b Peak-to-peak amplitude stays constant, or not\n\timplemented, or no informationstays\n\tconstant, or not implemented, or no\n\tinformation\n\t" }, //7-2
                { 1, "Reserved"} //last bits is binary from here (00b 01b 10b 11b) we will use the decimal value
            };
            dict4 = new Dictionary<int, string>() {
                { 0, "=00b Peak-to-peak amplitude stays constant, or not\n\timplemented, or no informationstays\n\tconstant, or not implemented, or no\n\tinformation\n\t" }, //7-2
                { 1, "Reserved"} //last bits is binary from here (00b 01b 10b 11b) we will use the decimal value
            };

        }
        /****************************************************************
        * This function is encoding, comparing and define the value according sff-8636
        ***************************************************************/
        public override void EncodeValue(string name)
        {
            byte t = Convert.ToByte(name.Substring(0, 2), 16);
            var r = Converstions.BitsFromByte.getStrBitAsUintFromByte(t, (int)m_FirstBit, (int)m_LastBit);
            string hexid = $"{r:X2}";
        }

        private uint m_FirstBit;
        private uint m_LastBit;
        private Dictionary<int, string>[] dict;  //the Dictionary of the ExtIdentifier
        private Dictionary<int, string> dict2;  //the Dictionary of the ExtIdentifier
        private Dictionary<int, string> dict3;  //the Dictionary of the ExtIdentifier
        private Dictionary<int, string> dict4;  //the Dictionary of the ExtIdentifier

    }

}
