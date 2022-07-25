using System;
using System.Collections.Generic;
using dic = OpticFiberTest_ver1.Dictionary;
using con = OpticFiberTest_ver1.Converstions;


namespace OpticFiberTest_ver1.Protocols_classes.Classes_SFF8636
{
    class Tx1Disable : SFF8636
    {
        // check tx is able/disable
        public Tx1Disable()
        {
            m_title = "Tx Able/Disable"  ; 
            m_size = 1; // tx1 size
            m_address = 86;// tx1 address



        }


        /****************************************************************
        * This function is encoding, comparing and define the value according sff-8636
        ***************************************************************/
        public override void EncodeValue(string name)
        {
            string beg = "The laser of the channel Tx";
            // loop to read the byte
            for (int i = 1; i < 5; ++i)
            {
                m_storedValue += beg + Convert.ToString(i) +" is" ;

                // check if we get '1' on name
                if (con.BitToStr.getStrBitValue(name, i))
                    m_storedValue += " disable";
                else
                    m_storedValue += " able";

                m_storedValue += "\n\t";

            }

        }


    }

}
