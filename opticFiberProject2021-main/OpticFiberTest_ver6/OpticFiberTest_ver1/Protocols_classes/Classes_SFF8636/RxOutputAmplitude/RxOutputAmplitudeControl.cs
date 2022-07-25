using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpticFiberTest_ver1.Protocols_classes.Classes_SFF8636
{
    class RxOutputAmplitudeControl : SFF8636
    {
        public RxOutputAmplitudeControl(int chanel, int address, int firstIndex, int lastIndex)
        {
            // the title of byte
            m_title = "Rx Output Amplitude";
            // the size of byte
            m_size = 1;
            // the address of byte
            m_address = (byte)address;
            // locate in page num
            m_page = 3;

            m_Chanel = chanel;
            m_FirstIndex = firstIndex;
            m_LastIndex = lastIndex;

            m_RxOutputAmplitudeSupport = new RxOutputAmplitudeSupport();
            m_DictionaryValidValues = new Dictionary<string, string>
            {
                {"0000","100-400 mV (p-p)" },
                {"0001","300-600 mV (p-p)" },
                {"0010","400-800 mV (p-p)" },
                {"0011","600-1200 mV (p-p)" }
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

            if (!m_RxOutputAmplitudeSupport.GetSupporrtedChanels(m_Chanel-1))
                m_storedValue += "\n\tRx" + m_Chanel.ToString() + " " + "is not supported\n";
            else if (m_DictionaryValidValues.ContainsKey(val))
                m_storedValue += "\n\tRx" + m_Chanel.ToString() + " " + m_DictionaryValidValues[val] + "\n";
            else
            {
                m_storedValue += "\n\tRx" + m_Chanel.ToString() + " value is invalid  ";
                throw new Exception();
            }
        }
        private int m_FirstIndex;
        private int m_LastIndex;
        private int m_Chanel;

        RxOutputAmplitudeSupport m_RxOutputAmplitudeSupport;
        Dictionary<string, string> m_DictionaryValidValues;
    }
}

