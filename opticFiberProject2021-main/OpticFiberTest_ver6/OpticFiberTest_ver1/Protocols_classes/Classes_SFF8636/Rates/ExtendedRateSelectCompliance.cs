using System;
using System.Collections.Generic;

namespace OpticFiberTest_ver1.Protocols_classes.Classes_SFF8636
{
    class ExtendedRateSelectCompliance : SFF8636
    {
        public ExtendedRateSelectCompliance()
        {
            m_title = "Extended Rate Select Compliance";
            m_size = 1;
            m_address = 141;

                dict1 = new Dictionary<string, string>() {
                { "00", "Reserved" }, //7-2
                { "11", "Reserved)"}, //last bits is binary from here (00b 01b 10b 11b) we will use the decimal value
                { "01", "Rate Select Version 1"},
                { "10", "Rate Select Version 2"},
            };
        }
        /****************************************************************
        * This function is encoding, comparing and define the value according sff-8636
        ***************************************************************/
        public override void EncodeValue(string name)
        {
            string val = "";
            for (int i = 0; i < 2; ++i)
            {
                if (getStrBitValue(name, i))
                    val += "1";
                else
                    val += "0";

            }
            
            m_storedValue += dict1[strReverse(val)] + "\n";
        }
        private string strReverse(string s) //turning the string -> reverse
        {
            char[] charArray = s.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }
        public bool getStrBitValue(string name, int num) //encoding the bits of the value for reading from dicts
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
