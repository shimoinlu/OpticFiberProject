using System;
using System.Collections.Generic;

namespace OpticFiberTest_ver1.Classes_SFF8636
{
    class DiagnosticMonitoringType : SFF8636
    {
        public DiagnosticMonitoringType()
        {
            m_title = "Diagnostic Monitoring Type";
            m_size = 1;
            m_address = 220;
            dict1 = new Dictionary<string, string>() {
            { "7-6", "Reserved" },
            { "5", "Temperature monitoring" },
            { "4", "Supply voltage monitoring" },
            { "3", "Received power measurements type" },
            { "2", "Transmitter power measurement." },
            { "1-0", "Reserved" },
            };
        }
        /****************************************************************
        * This function is encoding, comparing and define the value according sff-8636
        ***************************************************************/
        public override void EncodeValue(string name)
        {
            for (int i = 0; i < 8; ++i)
            {

                if (i == 4 || i == 5)
                {
                    if (getStrBitValue(name, i))
                        m_storedValue += dict1[Convert.ToString(i)] + " implemented" + "\n\t";
                    else
                        m_storedValue += dict1[Convert.ToString(i)] + " NOT implemented" + "\n\t";
                }
                else if (i == 3)
                {
                    if (getStrBitValue(name, i))
                        m_storedValue += dict1[Convert.ToString(i)] + " Average Power" + "\n\t";
                    else
                        m_storedValue += dict1[Convert.ToString(i)] + " OMA" + "\n\t";
                }
                else if (i == 2)
                {
                    if (getStrBitValue(name, i))
                        m_storedValue += dict1[Convert.ToString(i)] + " Supported" + "\n\t";
                    else
                        m_storedValue += dict1[Convert.ToString(i)] + " NOT Supported" + "\n\t";
                }
            }
        }
        public bool getStrBitValue(string name, int num)
        {
            int value = Convert.ToInt32(name, 16);
            string val = Convert.ToString(1 & (value >> num));
            if (val == "1")
                return true;
            return false;
        }
        private Dictionary<string, string> dict1;  //the Dictionary of the ExtIdentifier
    }
}
