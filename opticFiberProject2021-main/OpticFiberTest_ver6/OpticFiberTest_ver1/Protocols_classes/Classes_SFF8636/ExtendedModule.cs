using System;
using System.Collections.Generic;
using Valids = OpticFiberTest_ver1.Validations;



namespace OpticFiberTest_ver1.Protocols_classes.Classes_SFF8636
{
    class ExtendedModule : SFF8636
    {
        public ExtendedModule()
        {
            m_title = "Extended Module";
            m_size = 1;
            m_address = 164;
            values = new Dictionary<int, string>() {
                // Extended Module Options
                { 7, "Reserved" },
                { 6, "Reserved" },
                { 5, "HDR" },
                { 4, "EDR" },
                { 3, "FDR" },
                { 2, "QDR" },
                { 1, "DDR" },
                { 0, "SDR" }
            };
        }
        /****************************************************************
        * This function is encoding, comparing and define the value according sff-8636
        ***************************************************************/
        public override void EncodeValue(string name)
        {
            for (int i = 0; i < 6; ++i)
                if (getStrBitValue(name, i))
                    m_storedValue += values[i].ToString() + '\n';

            if (!Valids.ValidBits.IsValid(name))
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

        private Dictionary<int, string> values;  //the Dictionary of the ExtIdentifier

    }

}
