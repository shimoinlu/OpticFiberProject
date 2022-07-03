using System.Collections.Generic;

namespace OpticFiberTest_ver1.Protocols_classes.Classes_SFF8636
{
    //holding the extented value. only read if specification compliments calls it.
    class LinkCodes : SFF8636
    {
        public LinkCodes()
        {
            m_size = 1;
            m_address = 192;

            // all options for link codes
            m_ExtendedSCC_Dict = new Dictionary<string, string>()
            {
                {"00", "Unspecified"},
                {"01", "100G AOC (Active Optical Cable) or 25GAUI C2M AOC. Providing a worst BER of 5 × 10^(-5)"},
                {"02", "100GBASE-SR4 or 25GBASE-SR"},
                {"03", "100GBASE-LR4"},
                {"04", "100GBASE-ER4"},
                {"05", "100GBASE-SR10"},
                {"06", "100G CWDM4 MSA with FEC"},
                {"07", "100G PSM4 Parallel SMF"},
                {"08", "100G ACC (Active Copper Cable) or 25GAUI C2M ACC. Providing a worst BER of 5 × 10^(-5) "},
                {"09", "100G CWDM4 MSA without FEC"},
                {"0A", "Reserved"},
                {"0B", "100GBASE-CR4 or 25GBASE-CR CA-L"},
                {"0C", "25GBASE-CR CA-S"},
                {"0D", "25GBASE-CR CA-N"},
                {"-0F", "Reserved"},
                {"10", "40GBASE-ER4"},
                {"11", "4 x 10GBASE-SR "},
                {"12", "40G PSM4 Parallel SMF "},
                {"13", "G959.1 profile P1I1-2D1 (10709 MBd, 2km, 1310nm SM) "},
                {"14", "G959.1 profile P1S1-2D2 (10709 MBd, 40km, 1550nm SM)"},
                {"15", "G959.1 profile P1L1-2D2 (10709 MBd, 80km, 1550nm SM)"},
                {"16", "10GBASE-T with SFI electrical interface"},
                {"17", "100G CLR4"},
                {"18", "100G AOC or 25GAUI C2M AOC. Providing a worst BER of 10^(-12) or below"},
                {"19", "100G ACC or 25GAUI C2M ACC. Providing a worst BER of 10^(-12) or below"},
                {"-FF", "Reserved"},
            };
        }
        public string GetExtendedSCCValue(string key) { return m_ExtendedSCC_Dict[key]; }
        /****************************************************************
        * This function is encoding, comparing and define the value according sff-8636
        ***************************************************************/
        // add value from dictionry inside sorted value
        public override void EncodeValue(string name) 
        { 
            m_storedValue = m_ExtendedSCC_Dict[name]; 
        
        }
        private Dictionary<string, string> m_ExtendedSCC_Dict;
    }
}
