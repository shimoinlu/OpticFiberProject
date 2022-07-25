using System.Collections.Generic;

namespace OpticFiberTest_ver1.Protocols_classes.Classes_SFF8636
{
    class EncodingSFF : SFF8636
    {
        public EncodingSFF()
        {
            m_title = "Encoding";
            m_size = 1;
            m_address = 139;
            values = new Dictionary<string, string>() {
            { "00", "Unspecified" },
            { "01", "8B/10B"},
            { "02", "4B/5B"},
            { "03", "NRZ"},
            { "04", "SONET Scrambled"},
            { "05", "64B/66B"},
            { "06", "Manchester"},
            { "07", "256B/257B (transcoded FEC-enabled data)"},
            { "-FF", "Reserved"}
        };
        }
        /****************************************************************
        * This function is encoding, comparing and define the value according sff-8636
        ***************************************************************/
        public override void EncodeValue(string name) {
            m_storedValue = values[name] + "\n";
        }


        private Dictionary<string, string> values;  //the Dictionary of the ExtIdentifier

    }

}
