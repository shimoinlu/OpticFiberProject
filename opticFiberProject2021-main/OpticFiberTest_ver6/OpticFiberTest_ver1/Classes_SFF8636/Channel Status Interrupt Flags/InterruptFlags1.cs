using System;
using System.Collections.Generic;
using dic = OpticFiberTest_ver1.Dictionary;
using con = OpticFiberTest_ver1.Converstions;


namespace OpticFiberTest_ver1.Classes_SFF8636
{
    class InterruptFlags1 : SFF8636 // InterruptFlags1 in SFF8636 LowerPage
    {
        public InterruptFlags1(byte adress,byte mask)
        {
            m_title = "Interrupt Flags " + Convert.ToString(adress);
            m_size = 1;
            m_address = adress;
            m_dic = dic.Dicts.getDictionaryByByteNum(m_address); // Dictionary for flags
            m_mask = mask.ToString(); // Mask

        }


        /****************************************************************
        * This function is encoding, comparing and define the value according sff-8636
        ***************************************************************/
        public override void EncodeValue(string name)
        {
           
            for (int i = 0; i < 8; ++i)
            {

                  if (con.BitToStr.getStrBitValue(name, i) && !con.BitToStr.getStrBitValue(m_mask, i))
                    m_storedValue += m_dic[Convert.ToString(i)] + "\n\t";
         
            }
            
        }
        /****************************************************************
        * This function serialling the name into bits to read values from the dictionaries
        ***************************************************************/

        private string m_mask;
        private Dictionary<string, string> m_dic;
    }

}
