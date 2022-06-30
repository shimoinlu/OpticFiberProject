using System.Collections.Generic;
using System;
using Convers = OpticFiberTest_ver1.Converstions;

namespace OpticFiberTest_ver1.Protocols_classes.Classes_SFF8636
{

    public class CtrlInputOutput : SFF8636
    {
        public CtrlInputOutput()
        {
            m_title = "Ctrl";
            m_size = 1; // SIZE OF BYTE
            m_address = 99; // ADRESS OF BYTE

            dict = new Dictionary<string, string>() {

            { "1", "LP/TxDis ctrl"}, // IF WE GET 1 PRINT LP/TxDis ctrl
            { "0", "IntL/LOSL ctrl" }, // ELSE WE PRINT IntL/LOSL ctrl
        };


        }
        /****************************************************************
        * This function is encoding, comparing and define the value according sff-8636
        ***************************************************************/
        public override void EncodeValue(string name)
        {

            // if bit's is '1' Print LOSL
            if (Convers.BitToStr.getStrBitValue(name, 0))
            {
                dict[Convert.ToString(0)] = "LOSL";
            }
            else
            {
                dict[Convert.ToString(0)] = "IntL";
            }

            if (Convers.BitToStr.getStrBitValue(name, 1))
            {
                dict[Convert.ToString(1)] = "TxDIS";
            }
            else
            {
                dict[Convert.ToString(1)] = "LPMode";
            }

            // ADD THE VALUES TO THE DICTIONARY
            for (int i = 0; i < 2; i++)
                m_storedValue += dict[Convert.ToString(i)] + "\n\t";

        }

        private Dictionary<string, string> dict;

    }
}