using System.Collections.Generic;
using System;
using Convers = OpticFiberTest_ver1.Converstions;

namespace OpticFiberTest_ver1.Classes_SFF8636
{

    public class CDRControl : SFF8636
    {
        public CDRControl()
        {
            m_title = "CDR Control";
            m_size = 1;
            m_address = 98;

            dict = new Dictionary<string, string>() {
            { "7", "Tx3_CDR_control"},
            { "6", "Tx3_CDR_control"},
            { "5", "Tx2_CDR_control"},
            { "4", "Tx1_CDR_control"},
            { "3", "Rx4_CDR_control"},
            { "2", "Rx3_CDR_control"},
            { "1", "Rx2_CDR_control"},
            { "0", "Rx1_CDR_control" },
        };


        }
        /****************************************************************
        * This function is encoding, comparing and define the value according sff-8636
        ***************************************************************/
        public override void EncodeValue(string name)
        {
         

            for (int i = 0; i < 7; i++)
            {
                if (Convers.BitToStr.getStrBitValue(name, i))
                {
                    dict[Convert.ToString(i)] = "CDR on,";
                }
                else
                {
                    dict[Convert.ToString(i)] = "CDR off,";
                }
            }
            for (int i = 0; i < 7; i++)
                m_storedValue += dict[Convert.ToString(i)] + "\n\t";

         
        }


        private Dictionary<string, string> dict;


    }
}