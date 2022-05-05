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
            m_dict = new Dictionary<uint, string>[4];

            m_dict[0] = new Dictionary<uint, string>();
            m_dict[0].Add(0, "\n\tAmplitude 0011 not supported or no \n\t informationsupported or no information");
            m_dict[0].Add(1, "\n\tAmplitude 0011 supported");
            m_dict[1] = new Dictionary<uint, string>();
            m_dict[1].Add(0, "\n\tAmplitude 0010 not supported or no information \n\tsupported or no information");
            m_dict[1].Add(1, "\n\tAmplitude 0010 supported");
            m_dict[2] = new Dictionary<uint, string>();
            m_dict[2].Add(0, "\n\tAmplitude 0001 not supported or no information \n\tsupported or no information");
            m_dict[2].Add(1, "\n\tAmplitude 0001 supported");
            m_dict[3] = new Dictionary<uint, string>();
            m_dict[3].Add(0, "\n\tAmplitude 0000 not supported or no information \n\tsupported or no information");
            m_dict[3].Add(1, "Amplitude 0000 supported");
        }
        /****************************************************************
        * This function is encoding, comparing and define the value according sff-8636
        ***************************************************************/
        public override void EncodeValue(string name)
        {
            byte b = Convert.ToByte(name.Substring(0, 2), 16);
            uint bit;
            for (uint i = m_FirstBit; i <= m_LastBit; ++i)
            {
                bit = Converstions.BitsFromByte.getStrBitAsUintFromByte(b, (int)i, (int)i);
                m_storedValue += m_dict[i][bit];
            }
        }

        private uint m_FirstBit;
        private uint m_LastBit;
        private Dictionary<uint, string>[] m_dict;  //the Dictionary of the ExtIdentifier

    }

}
