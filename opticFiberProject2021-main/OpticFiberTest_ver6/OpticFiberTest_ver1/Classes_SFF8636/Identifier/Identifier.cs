using System.Collections.Generic;

namespace OpticFiberTest_ver1.Classes_SFF8636
{
    /****************************************************************
    * This class is for identifier. it holding all of the values we
    * get according the readed value from byte 128. each byte meant to
    * get information from different dict. we iterate the value bytes and
    * take the values from the dictionaries accordinly
    ***************************************************************/
    public class Identifier : SFF8636
    {
        public Identifier()
        {
            m_title = "Identifier";
            m_size = 1;
            m_address = 128;

            values = new Dictionary<string, string>() {
            { "00", "unknowen"},
            { "01", "GBIC"},
            { "02","connector soldered to motherboard"},
            { "03","SFP / SFP+ / SPF28"},
            { "04", "300 pin XBI"},
            { "05", "XENPAK"},
            { "06", "XFP"},
            { "07", "XFF" },
            { "08", "XFP-E"},
            { "09", "XPAK"},
            { "0A", "X2"},
            { "0B", "DWDM-SFP/SFP+"},
            { "0C", "QSFP"},
            { "0D", "QSFP+ or later"},
            { "0E", "CXP or later"},
            { "0F", "Shielded Mini Multilane HD 4X"},
            { "10", "Shielded Mini Multilane HD 8X"},
            { "11", "QSFP28 or later (SFF-8665 et al) *2"},
            { "12", "CXP2 (aka CXP28) or later"},
            { "13", "CDFP (Style 1/Style2)"},
            { "14", "Shielded Mini Multilane HD 4X Fanout Cable\n"},
            { "15", "Shielded Mini Multilane HD 8X Fanout Cable "},
            { "16", "CDFP (Style 3)\n"},
            { "17", "microQSFP\n"},
            { "18", "QSFP-DD Double Density 8X Pluggable Transceiver (INF-8628)"}
            };
        }
        /****************************************************************
        * This function is encoding, comparing and define the value according sff-8636
        ***************************************************************/
        public override void EncodeValue(string name) {
            m_storedValue = values[name] + "\n";
        }

        private Dictionary<string, string> values;  //the Dictionary of the Identifier
    }
}