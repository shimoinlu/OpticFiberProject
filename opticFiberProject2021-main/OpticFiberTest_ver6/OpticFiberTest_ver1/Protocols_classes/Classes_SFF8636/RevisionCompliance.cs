using System.Collections.Generic;
using System;

namespace OpticFiberTest_ver1.Protocols_classes.Classes_SFF8636
{
    /****************************************************************
    * This class is for identifier. it holding all of the values we
    * get according the readed value from byte 128. each byte meant to
    * get information from different dict. we iterate the value bytes and
    * take the values from the dictionaries accordinly
    ***************************************************************/
    public class RevisionCompliance : SFF8636
    {
        public RevisionCompliance()
        {
            m_title = "Revision Compliance";
            m_size = 1;
            m_address = 1;

            // Revision Compliance Options
            values = new Dictionary<string, string>() {
            { "00", "Revision not specified. Do not use for SFF-8636 rev 2.5 or higher."},
            { "01", "SFF-8436 Rev 4.8 or earlier"},
            { "02", "Includes functionality described in revision 4.8 or earlier of SFF-8436,\n except that this byte and Bytes 186-189 are as defined in this document"},
            { "03", "SFF-8636 Rev 1.3 or earlier"},
            { "04", "SFF-8636 Rev 1.4"},
            { "05", "SFF-8636 Rev 1.5"},
            { "06", "SFF-8636 Rev 2.0"},
            { "07", "SFF-8636 Rev 2.5, 2.6 and 2.7" },
            { "08", "SFF-8636 Rev 2.8, 2.9 and 2.10"},
            };
        }
        /****************************************************************
        * This function is encoding, comparing and define the value according sff-8636
        ***************************************************************/
        public override void EncodeValue(string name)
        {
            if (Convert.ToInt32(name) >= 0 && Convert.ToInt32(name) <= 8)
                m_storedValue = values[name] + "\n";
            else
                throw new Exception();
        }

        private Dictionary<string, string> values;  //the Dictionary of the Identifier
    }
}