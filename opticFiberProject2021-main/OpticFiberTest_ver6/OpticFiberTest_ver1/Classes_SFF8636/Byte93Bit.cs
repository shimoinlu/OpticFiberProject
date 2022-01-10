using System;
using System.Collections.Generic;
using dic = OpticFiberTest_ver1.Dictionary;
using con = OpticFiberTest_ver1.Converstions;


namespace OpticFiberTest_ver1.Classes_SFF8636
{
    //Checking the bits inside byte 93
    class Byte93Bits : SFF8636
    {
        public Byte93Bits()
        {
            // the title of byte
            m_title = "Byte 93 Bits";
            // the size of byte
            m_size = 1;
            // the address of byte
            m_address = 93;



        }


        /****************************************************************
        * This function is encoding, comparing and define the value according sff-8636
        ***************************************************************/
        public override void EncodeValue(string name)
        {
            string beg = "Bit: ";
            for (int i = 0; i < 8; ++i)
            {
                m_storedValue += beg + Convert.ToString(i) + " = ";
                // check for 1 bit's inside byte 93
                if (con.BitToStr.getStrBitValue(name, i))
                    m_storedValue += "1";
                else
                    m_storedValue += "0";

                m_storedValue += "\n\t";

            }

        }


    }

}
