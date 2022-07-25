using System;
using System.Collections.Generic;
using System.Linq;
using Valids = OpticFiberTest_ver1.Validations;

namespace OpticFiberTest_ver1.Protocols_classes.Classes_SFF8636
{
    class SpecificationCompliance : SFF8636
    {
        public SpecificationCompliance()
        {
            m_title = "Specification Compliance";
            m_size = 8;
            m_address = 131;
            dict1 = new Dictionary<string, string>() {
            { "7", "Extended" }, //TODO: extended table (The idea is to get the value "Extended" and put if to refer to the extented table)
            { "6", "10GBASE-LRM"},
            { "5", "10GBASE-LR"},
            { "4", "10GBASE-SR"},
            { "3", "40GBASE-CR4"},
            { "2", "40GBASE-SR4"},
            { "1", "40GBASE-LR4"},
            { "0", "40G Active Cable (XLPPI)"},
            };
            dict2 = new Dictionary<string, string>() {
            { "3", "Reserved"}, //7-3
            { "2", "OC 48, long reach"},
            { "1", "OC 48, intermediate reach"},
            { "0", "OC 48 short reach"},
            };
            dict3 = new Dictionary<string, string>() {
            { "7", "SAS 24.0 Gbps"},
            { "6", "SAS 12.0 Gbps"}, 
            { "5", "SAS 6.0 Gbps"},
            { "4", "SAS 3.0 Gbps "},
            { "3", "Reserved"}, //3-0
            }; 
            dict4 = new Dictionary<string, string>() {
            { "4", "Reserved"}, //7-4
            { "3", "1000BASE-T"},
            { "2", "1000BASE-CX"},
            { "1", "1000BASE-LX"},
            { "0", "1000BASE-SX"},
            };
            dict5 = new Dictionary<string, string>() {
            { "7", "Very long distance (V)"},
            { "6", "Short distance (S)"},
            { "5", "Intermediate distance (I)"},
            { "4", "Long distance (L)"},
            { "3", "Medium (M)"},
            { "2", "Reserved"},
            { "1", "Longwave laser (LC)"},
            { "0", "Electrical inter-enclosure (EL)"},
            };
            dict6 = new Dictionary<string, string>() {
            { "7", "Electrical intra-enclosure "},
            { "6", "Shortwave laser w/o OFC (SN)"},
            { "5", "Shortwave laser w OFC (SL)"},
            { "4", "Longwave Laser (LL)"},
            { "3", "Reserved"}, //3-0
            };
            dict7 = new Dictionary<string, string>() {
            { "7", "Twin Axial Pair (TW)"},
            { "6", "Shielded Twisted Pair (TP)"},
            { "5", "Miniature Coax (MI)"},
            { "4", "Video Coax (TV)"},
            { "3", "Multi-mode 62.5 um (M6)"},
            { "2", "Multi-mode 50 um (M5)"},
            { "1", "Multi-mode 50 um (OM3)"},
            { "0", "Single Mode (SM)"},
            };
            dict8 = new Dictionary<string, string>() {
            { "7", "1200 MBps (per channel)"},
            { "6", "800 MBps"},
            { "5", "1600 MBps (per channel)"},
            { "4", "400 MBps"},
            { "3", "3200 MBps (per channel)"},
            { "2", "200 MBps"},
            { "1", "Extended"}, //Ask if we need to include the extended table
            { "0", "100 MBps"}
            };
           

        }
        /****************************************************************
        * This function is encoding, comparing and define the value according sff-8636
        ***************************************************************/
        public override void EncodeValue(string name = "00 F0 70 00 00 00 00 00")
        {
            string[] bitsAdrr = name.Split(' ');

            if (getStrBitValue(bitsAdrr[0], 7))
            {
                LinkCodes link = new LinkCodes();
                 m_storedValue += link.GetExtendedSCCValue(Data.I2cData.Geti2cDataSub(linkCodeAddr - 128, m_size)); //FOR REAL RUN
            }
            else
                for (int i = 0; i < dict1.Count() - 1; ++i)
                    if (getStrBitValue(bitsAdrr[0], i))
                        m_storedValue += dict1[Convert.ToString(i)] + "\n\t";

            for (int i = 0; i < dict2.Count(); ++i)
                if (getStrBitValue(bitsAdrr[1], i))
                    m_storedValue += dict2[Convert.ToString(i)] + "\n\t";
            
            for (int i = 3; i < 8; ++i) 
                if (getStrBitValue(bitsAdrr[2], i))
                    m_storedValue += dict3[Convert.ToString(i)] + "\n\t";
            
            for (int i = 0; i < dict4.Count(); ++i)
                if (getStrBitValue(bitsAdrr[3], i))
                    m_storedValue += dict4[Convert.ToString(i)] + "\n\t";

            for (int i = 0; i < dict5.Count(); ++i)
                if (getStrBitValue(bitsAdrr[4], i))
                    m_storedValue += dict5[Convert.ToString(i)] + "\n\t";

            for (int i = 3; i < 8; ++i)
                if (getStrBitValue(bitsAdrr[5], i))
                    m_storedValue += dict6[Convert.ToString(i)] + "\n\t";

            for (int i = 0; i < dict7.Count(); ++i)
                if (getStrBitValue(bitsAdrr[6], i))
                    m_storedValue += dict7[Convert.ToString(i)] + "\n\t";

            for (int i = 0; i < dict8.Count(); ++i)
                if (getStrBitValue(bitsAdrr[7], i))
                    m_storedValue += dict8[Convert.ToString(i)] + "\n\t";


            if (!Valids.ValidBits.IsValid(bitsAdrr[2]))
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

        private byte linkCodeAddr = 192;

        //private Dictionary<string, string> ExtendedSCC_Dict;  //the Dictionary of the ExtIdentifier
        private Dictionary<string, string> dict8;  //the Dictionary of the ExtIdentifier
        private Dictionary<string, string> dict7;  //the Dictionary of the ExtIdentifier
        private Dictionary<string, string> dict6;  //the Dictionary of the ExtIdentifier
        private Dictionary<string, string> dict5;  //the Dictionary of the ExtIdentifier
        private Dictionary<string, string> dict4;  //the Dictionary of the ExtIdentifier
        private Dictionary<string, string> dict3;  //the Dictionary of the ExtIdentifier
        private Dictionary<string, string> dict2;  //the Dictionary of the ExtIdentifier
        private Dictionary<string, string> dict1;  //the Dictionary of the ExtIdentifier

    }

}
