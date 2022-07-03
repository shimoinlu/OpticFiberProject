using System;
using System.Collections.Generic;
using System.Linq;

namespace OpticFiberTest_ver1.Protocols_classes.Classes_SFF8636
{
    class RxOutputAmplitudeSupport : SFF8636
    {
        public RxOutputAmplitudeSupport()
        {
            m_title = "Rx Output Amplitude Support";
            m_size = 1;
            m_FirstBit = 0;
            m_LastBit = 3;
            m_address = 225;
            m_page = 3;
            byte b = i2cReader.AAI2cEeprom.getByte((byte)m_address, (byte)m_page);

            string tm = b.ToString();
            m_SupporrtedChanels = String.Join(String.Empty,
              tm.Select(
                c => Convert.ToString(Convert.ToInt32(c.ToString(), 16), 2).PadLeft(4, '0')
              )
            );
            m_SupporrtedChanels = m_SupporrtedChanels.Substring(0, 4);

            m_dict = new Dictionary<uint, string>[4];

            m_dict[0] = new Dictionary<uint, string>();
            m_dict[0].Add(0, "\n\tAmplitude 0011 not supported or no \n\t informationsupported or no information\n");
            m_dict[0].Add(1, "\n\tAmplitude 0011 supported\n");
            m_dict[1] = new Dictionary<uint, string>();
            m_dict[1].Add(0, "\n\tAmplitude 0010 not supported or no information \n\tsupported or no information\n");
            m_dict[1].Add(1, "\n\tAmplitude 0010 supported\n");
            m_dict[2] = new Dictionary<uint, string>();
            m_dict[2].Add(0, "\n\tAmplitude 0001 not supported or no information \n\tsupported or no information\n");
            m_dict[2].Add(1, "\n\tAmplitude 0001 supported\n");
            m_dict[3] = new Dictionary<uint, string>();
            m_dict[3].Add(0, "\n\tAmplitude 0000 not supported or no information \n\tsupported or no information\n");
            m_dict[3].Add(1, "Amplitude 0000 supported\n");
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
        public bool GetSupporrtedChanels(int c) { return m_SupporrtedChanels[c] == '1'; }
        private uint m_FirstBit;
        private uint m_LastBit;
        private Dictionary<uint, string>[] m_dict;  //the Dictionary of the ExtIdentifier
        string m_SupporrtedChanels;
    }

}
