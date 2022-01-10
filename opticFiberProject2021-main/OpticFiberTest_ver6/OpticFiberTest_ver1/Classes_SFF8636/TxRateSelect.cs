using System;
using con = OpticFiberTest_ver1.Converstions;


namespace OpticFiberTest_ver1.Classes_SFF8636
{
    class TxRateSelect : SFF8636
    {
        public TxRateSelect()
        {
            m_title = "Tx Rate Select";
            m_size = 1;
            m_address = 88;



        }


        /****************************************************************
        * This function is encoding, comparing and define the value according sff-8636
        ***************************************************************/
        public override void EncodeValue(string name)
        {

            int num = 0;
            string beg = "The Rate of the channel Tx";
            for (int i = 0; i < 8; i += 2)
            {
                m_storedValue += beg + Convert.ToString((i/2) + 1) + " is: ";

                if (con.BitToStr.getStrBitValue(name, i))
                {
                    num += 1;
                }
                if (con.BitToStr.getStrBitValue(name, i + 1))
                {
                    num += 2;
                }

                m_storedValue += num.ToString() + "\n\t";
                num = 0;
            }



        }


    }

}
