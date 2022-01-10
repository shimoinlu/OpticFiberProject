using System;
using OpticFiberTest_ver1;


public partial class Identifier : SFF8636
{
    public Identifier()
    {
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
    public override void GetValue(string name) { m_hasRead = values[name]; }



    private Dictionary<string, string> values;  //the Dictionary of the Identifier
}
