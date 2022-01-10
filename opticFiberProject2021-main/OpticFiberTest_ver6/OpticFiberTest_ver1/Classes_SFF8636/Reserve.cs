using System.Collections.Generic;
using System;

namespace OpticFiberTest_ver1.Classes_SFF8636
{
    /****************************************************************
    * This class is for identifier. it holding all of the values we
    * get according the readed value from byte 128. each byte meant to
    * get information from different dict. we iterate the value bytes and
    * take the values from the dictionaries accordinly
    ***************************************************************/
    public class Reserve : SFF8636
    {
        public Reserve(byte address)
        {
            m_title = "Reserve";
            m_size = 1;
            m_address = address;
        }
        /****************************************************************
        * This function is encoding, comparing and define the value according sff-8636
        ***************************************************************/
        public override void EncodeValue(string name)
        {
            m_storedValue = name;

            if (name != "00")
                throw new Exception();
        }
    }
}