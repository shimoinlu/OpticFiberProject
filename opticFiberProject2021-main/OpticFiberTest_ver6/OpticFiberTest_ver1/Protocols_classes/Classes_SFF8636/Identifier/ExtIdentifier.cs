using System;
using System.Collections.Generic;

namespace OpticFiberTest_ver1.Protocols_classes.Classes_SFF8636
{
    /****************************************************************
    * This class is for extidentifier. it holding all of the values we
    * get according the readed value from byte 129. each byte meant to
    * get information from different dict. we iterate the value bytes and
    * take the values from the dictionaries accordinly
    ***************************************************************/
    class ExtIdentifier : SFF8636
    {
        public ExtIdentifier()
        {
            m_title = "Ext. Identifier";
            m_size = 1;
            m_address = 129;
            dict6 = new Dictionary<string, string>() {
                { "00", "Unknown or unspecified " },
                { "01", "SC(Subscriber Connector)"},
                { "10", "Fibre Channel Style 1 copper connector"},
                { "11", "Fibre Channel Style 2 copper connector"}
            };

            dict5 = "BNC/TNC(Bayonet/Threaded Neill-Concelman)";
            dict4 = new Dictionary<string, string>() {
                { "0", "Fibre Channel coax headers"},
                { "1", "Fiber Jack"}
            };
            dict3 = new Dictionary<string, string>() {
                { "0", "LC(Lucent Connector)"},
                { "1", "MT-RJ(Mechanical Transfer - Registered Jack)"}
            };
            dict2 = new Dictionary<string, string>() {
                { "0", "MU(Multiple Optical)"},
                { "1", "SG"},
            };
            dict1 = new Dictionary<string, string>() {
                { "00", "Optical Pigtail"},
                { "01", "MPO 1x12(Multifiber Parallel Optic)"},
                { "10", "MPO 2x16"},
                { "11", "Reserved"}
            };

        }
        /****************************************************************
        * This function is encoding, comparing and define the value according sff-8636
        ***************************************************************/
        public override void EncodeValue(string name)
        {
            m_storedValue = dict1[getStrBitValue(name, 0, 1)] + "\n\t" +
            dict2[getStrBitValue(name, 2)] + "\n\t" +
            dict3[getStrBitValue(name, 3)] + "\n\t" +
            dict4[getStrBitValue(name, 4)] + "\n\t" +
            dict5 + "\n\t\"" + dict6[getStrBitValue(name, 5, 1)] + "\n";

        }
        /****************************************************************
        * This function gets the but value
        ***************************************************************/
        public string getStrBitValue(string name, int num, int count = 0)
        {
            int value = Convert.ToInt32(name, 16);
            string val = Convert.ToString(1 & value >> num);
            if (count == 1)
                val = Convert.ToString(1 & (value >> num + 1)) + val;
            return val;
        }


        private Dictionary<string, string> dict6;  //the Dictionary of the ExtIdentifier
        string dict5;  //the Dictionary of the ExtIdentifier
        private Dictionary<string, string> dict4;  //the Dictionary of the ExtIdentifier
        private Dictionary<string, string> dict3;  //the Dictionary of the ExtIdentifier
        private Dictionary<string, string> dict2;  //the Dictionary of the ExtIdentifier
        private Dictionary<string, string> dict1;  //the Dictionary of the ExtIdentifier

    }

}
