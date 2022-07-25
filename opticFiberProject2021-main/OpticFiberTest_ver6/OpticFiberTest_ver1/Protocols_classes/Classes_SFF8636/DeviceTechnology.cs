using System;
using System.Collections.Generic;
using Valids = OpticFiberTest_ver1.Validations;

namespace OpticFiberTest_ver1.Protocols_classes.Classes_SFF8636
{
    class DeviceTechnology : SFF8636
    {
        public DeviceTechnology()
        {
            m_title = "Device technology";
            m_size = 1;
            m_address = 147;
            // Device Technology
            dict4 = new Dictionary<string, string>() {
                { "0000", "850 nm VCSEL" },
                { "0001", "1310 nm VCSEL" },
                { "0010", "1550 nm VCSEL" },
                { "0011", "1310 nm FP" },
                { "0100", "1310 nm DFB" },
                { "0101", "1550 nm DFB" },
                { "0110", "1310 nm EML" },
                { "0111", "1550 nm EML" },
                { "1000", "Other / Undefined" },
                { "1001", "1490 nm DFB" },
                { "1010", "Copper cable unequalized" },
                { "1011", "Copper cable passive equalized" },
                { "1100", "Copper cable, near and far end limiting active equalizers" },
                { "1101", "Copper cable, far end limiting active equalizers" },
                { "1110", "Copper cable, near end limiting active equalizers" },
                { "1111", "Copper cable, linear active equalizers" }
            };

            dict3 = new Dictionary<string, string>()
            {
                { "0", "No wavelength control" },
                { "1", "Active wavelength control"}
            };
            
            dict2 = new Dictionary<string, string>()
            {
                { "0", "Uncooled transmitter device" },
                { "1", "Cooled transmitter"}
            };

            dict1 = new Dictionary<string, string>()
            {
                { "0", "Pin detector" },
                { "1", "APD detector"}
            };
            
            dict0 = new Dictionary<string, string>()
            {
                { "0", "Transmitter not tunable" },
                { "1", "Transmitter tunable"}
            };
        }
        /****************************************************************
        * This function is encoding, comparing and define the value according sff-8636
        ***************************************************************/
        public override void EncodeValue(string name) 
        {
            m_storedValue += dict0[getStrBitValue(name, 0)] + "\n\t";
            m_storedValue += dict1[getStrBitValue(name, 1)] + "\n\t";
            m_storedValue += dict2[getStrBitValue(name, 2)] + "\n\t";
            m_storedValue += dict3[getStrBitValue(name, 3)] + "\n\t";
            m_storedValue += dict4[getStrBitValue(name, 4, 1)] + "\n";

        }
        
        public string getStrBitValue(string name, int num, int count = 0)
        {
            int value = Convert.ToInt32(name, 16);
            string val = "";

            val = Convert.ToString(1 & (value >> num));
            if (count == 1) 
            {
                val = Convert.ToString(1 & (value >> ++num)) +
                      Convert.ToString(1 & (value >> ++num)) +
                      Convert.ToString(1 & (value >> ++num)) + val;
            }
            return val;

        }


        private Dictionary<string, string> dict4;  //the Dictionary of the ExtIdentifier
        private Dictionary<string, string> dict0;  //the Dictionary of the ExtIdentifier
        private Dictionary<string, string> dict1;  //the Dictionary of the ExtIdentifier
        private Dictionary<string, string> dict2;  //the Dictionary of the ExtIdentifier
        private Dictionary<string, string> dict3;  //the Dictionary of the ExtIdentifier
        
    }

}
