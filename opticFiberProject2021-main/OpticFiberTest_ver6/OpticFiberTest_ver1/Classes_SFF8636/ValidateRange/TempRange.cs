using System;
using System.Numerics;
namespace OpticFiberTest_ver1.Classes_SFF8636
{
     class TempRange : BaseRange
    {
        /****************************************************************
        * This function summing all the bytes for part of CC_BASE and CC_EXT
        ***************************************************************/

        public TempRange()
        {
            m_title = "CC_EXT";
            m_size = 1;
            m_address = 223;
            //m_title = "tamp randge limits";
        }
        /****************************************************************
        * This function is encoding, comparing and define the value according sff-8636
        ***************************************************************/
 
    }
}
