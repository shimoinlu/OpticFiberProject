using System;
using System.Collections.Generic;
using Valids = OpticFiberTest_ver1.Validations;


namespace OpticFiberTest_ver1.Classes_SFF8636
{
    class Options : SFF8636
    {
        public Options()
        {
            m_title = "Options";
            m_size = 3;
            m_address = 193;
            dict1 = new Dictionary<string, string>() {
            { "7", "Memory Page 02 provided"},
            { "6", "Complicated"},
            { "5", "Complicated"},
            { "4", "Tx input adaptive equalizers freeze capable"},
            { "3", "Tx input equalizers auto-adaptive capable"},
            { "2", "Tx input equalizers fixed-programmable settings"},
            { "1", "Rx output emphasis fixed-programmable settings"},
            { "0", "Rx output amplitude fixed-programmable settings" },
        };
            dict2 = new Dictionary<string, string>()
            {
            { "7", "Tx CDR On/Off Control" },
            { "6", "Rx CDR On/Off Control" },
            { "5", "Tx CDR Loss of Lock (LOL) flag" },
            { "4", "Rx CDR Loss of Lock (LOL) flag" },
            { "3", "Rx Squelch Disable" },
            { "2", "Rx Output Disable" },
            { "1", "Tx Squelch Disable" },
            { "0", "Tx Squelch" },

            };
            dict3 = new Dictionary<string, string>()
            {
            { "7", "Memory Page 02 provided" },
            { "6", "Memory Page 01h provided" },
            { "5", "Rate select" },
            { "4", "Tx_Disable" },
            { "3", "Tx_Fault signal" },
            { "2.5", "Tx Squelch implemented to reduce Pave coded" },
            { "2", "Tx Squelch implemented to reduce OMA coded" },
            { "1", "Tx Loss of Signal" },
            { "0", "Pages 20-21h" },

            };
        }
        /****************************************************************
        * This function is encoding, comparing and define the value according sff-8636
        ***************************************************************/
        public override void EncodeValue(string name) {
            string[] bitsAdrr = name.Split(' ');
            for (int i = 0; i < 8; ++i)
            {
                if (getStrBitValue(bitsAdrr[1], i))
                    m_storedValue += dict2[Convert.ToString(i)] + " implemented" + "\n\t";
                else
                    m_storedValue += dict2[Convert.ToString(i)] + " NOT implemented" + "\n\t";
            }
            for (int i = 0; i < 8; ++i)
                if (i != 2)
                {

                    if (getStrBitValue(bitsAdrr[2], i))
                        m_storedValue += dict3[Convert.ToString(i)] + " implemented" + "\n\t";
                    else
                        m_storedValue += dict3[Convert.ToString(i)] + " NOT implemented" + "\n\t";

                }
                else
                {
                    if (getStrBitValue(bitsAdrr[2], i))
                        m_storedValue += dict3[Convert.ToString(i)] + "\n\t";
                    else
                        m_storedValue += dict3["2.5"] + "\n\t";
                }
            if (!Valids.ValidBits.IsValid(name.Substring(0,1)))
                throw new Exception();
        }
        /****************************************************************
        * This function serialling the name into bits to read values from the dictionaries
        ***************************************************************/
        public bool getStrBitValue(string name, int num)
        {
            int value = Convert.ToInt32(name, 16);
            string val = Convert.ToString(1 & (value >> num));
            if (val == "1")
                return true;
            return false;
        }

        private Dictionary<string, string> dict1;
        private Dictionary<string, string> dict2;
        private Dictionary<string, string> dict3;
    }

}
