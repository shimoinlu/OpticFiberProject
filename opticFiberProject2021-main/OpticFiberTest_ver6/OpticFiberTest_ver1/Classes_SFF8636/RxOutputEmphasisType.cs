using System;
using System.Collections.Generic;

namespace OpticFiberTest_ver1.Classes_SFF8636
{
    class RxOutputEmphasisType : SFF8636
    {
        public RxOutputEmphasisType()
        {
            m_title = "Rx Output Emphasis Type";
            m_size = 1;
            m_FirstBit = 4;
            m_LastBit = 5;
            m_address = 225;
            m_page = 3;
            dict1 = new Dictionary<string, string>() {
                { "00", "=00b Peak-to-peak amplitude stays constant, or not\n\timplemented, or no informationstays\n\tconstant, or not implemented, or no\n\tinformation\n\t" }, //7-2
                { "11", "Reserved"}, //last bits is binary from here (00b 01b 10b 11b) we will use the decimal value
                { "01", "Steady state amplitude stays constant stays\n\tconstant"},
                { "10", "Average of peak-to-peak and steady state amplitudes stays constant and steady state amplitudes stays constant"},
            };
        }
        /****************************************************************
        * This function is encoding, comparing and define the value according sff-8636
        ***************************************************************/
        public override void EncodeValue(string name)
        {
            byte t  = Convert.ToByte(name.Substring(0, 2), 16);
            var r  = Converstions.BitsFromByte.getStrBitAsUintFromByte(t, (int)m_FirstBit, (int)m_LastBit);
            string hexid = $"{r:X2}";
            m_storedValue += dict1[hexid]; 
        }

        private uint m_FirstBit;
        private uint m_LastBit;
        private Dictionary<string, string> dict1;  //the Dictionary of the ExtIdentifier

    }

}
