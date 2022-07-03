using System;
using System.Collections.Generic;

namespace OpticFiberTest_ver1.Protocols_classes.Classes_SFF8636
{
    //Enhanced Options ON BYTE 221
    class EnhancedOptions : SFF8636
    {
        public EnhancedOptions()
        {
            m_title = "Enhanced Options";
            m_size = 1;
            m_address = 221;
            // OPTIONS OF Enhanced
            dict1 = new Dictionary<string, string>() {
            { "7-5", "Reserved"},
            { "4", "Initialization Complete Flag"},
            { "3", "Rate Selection Declaration"},
            { "2", "Reserved"},
            { "1", "TC readiness flag"},
            { "0", "Software reset" },
        };
        }
        /****************************************************************
        * This function is encoding, comparing and define the value according sff-8636
        ***************************************************************/
        public override void EncodeValue(string name) {
            for (int i = 0; i < 8; ++i)
            {
                if (i < 5 && i != 2)
                {
                    // IF BIT IS '1'
                    if (getStrBitValue(name, i))
                        m_storedValue += dict1[Convert.ToString(i)] + " implemented" + "\n\t";
                    else
                        m_storedValue += dict1[Convert.ToString(i)] + " NOT implemented" + "\n\t";
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
