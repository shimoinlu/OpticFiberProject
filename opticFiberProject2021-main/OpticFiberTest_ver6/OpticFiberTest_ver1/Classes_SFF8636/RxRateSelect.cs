using System;
using System.Collections.Generic;
using dic = OpticFiberTest_ver1.Dictionary;
using con = OpticFiberTest_ver1.Converstions;


namespace OpticFiberTest_ver1.Classes_SFF8636
{
    class RxRateSelect : SFF8636
    {
        public RxRateSelect()
        {
            m_title = "Rx Rate Select";
            m_size = 1;
            m_address = 87;



        }


        /****************************************************************
        * This function is encoding, comparing and define the value according sff-8636
        ***************************************************************/
        public override void EncodeValue(string name)
        {
            int num = 0;
            string beg = "The Rate of the channel Rx";
            for (int i = 0; i < 8; i+=2)
            {
                m_storedValue += beg + Convert.ToString((i / 2) + 1) + " is: ";

                if (con.BitToStr.getStrBitValue(name, i))
                {
                    num += 1;
                }
                if(con.BitToStr.getStrBitValue(name, i + 1)){
                    num += 2;
                }

                m_storedValue += num.ToString() + "\n\t";
                num = 0;
            }



        }


    }

}
