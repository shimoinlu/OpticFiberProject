using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpticFiberTest_ver1.Protocols_classes.Classes_SFF8636
{
    class RxOutputEmphasisControl : SFF8636
    {
        public RxOutputEmphasisControl(int chanel, int address, int firstIndex, int lastIndex)
        {
            // the title of byte
            m_title = "Rx Output Emphasis";
            // the size of byte
            m_size = 1;
            // the address of byte
            m_address = (byte)address;
            // locate in page num
            m_page = 3;

            m_Chanel = chanel;
            m_FirstIndex = firstIndex;
            m_LastIndex = lastIndex;

            m_MaxRxOutputEmphasis = new MaxRxOutputEmphasis();
            m_DictionaryValidValues = new Dictionary<string, string>
            {
                {"0000","no emphasis " },
                {"0001","1 dB" },
                {"0010","2 dB" },
                {"0011","3 dB" },
                {"0100","4 dB" },
                {"0101","5 dB" },
                {"0110","6 dB" },
                {"0111","7 dB" }

            };
        }

        public override void EncodeValue(string name)
        {
            string val = String.Join(String.Empty,
              name.Select(
                c => Convert.ToString(Convert.ToInt32(c.ToString(), 16), 2).PadLeft(4, '0')
              )
            );

            val = val.Substring(m_FirstIndex, m_LastIndex - m_FirstIndex + 1);

            int value = Convert.ToInt32(val, 2);


            if (value <= m_MaxRxOutputEmphasis.GetMax() && m_DictionaryValidValues.ContainsKey(val))
                m_storedValue += "\n\tRx" + m_Chanel.ToString() + " " + m_DictionaryValidValues[val] + "\n";
            else if (value <= m_MaxRxOutputEmphasis.GetMax())
            {
                m_storedValue += "\n\tRx" + m_Chanel.ToString() + " value is invalid  ";
                throw new Exception();
            }
            else
            {
                m_storedValue += "\n\tRx" + m_Chanel.ToString() + " value is Exceeds the maximum  ";
                throw new Exception();
            }
        }
        private int m_FirstIndex;
        private int m_LastIndex;
        private int m_Chanel;

        MaxRxOutputEmphasis m_MaxRxOutputEmphasis;    
        Dictionary<string, string> m_DictionaryValidValues; 
    }
}

