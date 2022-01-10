using System.Collections.Generic;
using System;
using Convers = OpticFiberTest_ver1.Converstions;

namespace OpticFiberTest_ver1.Classes_SFF8636
{
    /****************************************************************
    * This class is for identifier. it holding all of the values we
    * get according the readed value from byte 128. each byte meant to
    * get information from different dict. we iterate the value bytes and
    * take the values from the dictionaries accordinly
    ***************************************************************/
    public class PciExpess : SFF8636
    {
        public PciExpess()
        {
            m_title = "PCI Express"; // title of byte
            m_size = 2; // size of byte 
            m_address = 111;// addrss of byte 

        }
        /****************************************************************
        * This function is encoding, comparing and define the value according sff-8636
        ***************************************************************/
        public override void EncodeValue(string name)
        {
            if (name == "00 00") // if byte is zero's
                m_storedValue = "Not assigned for use by PCI Express";

            else
                m_storedValue = "assigned for use by PCI Express";

        }

    }
}