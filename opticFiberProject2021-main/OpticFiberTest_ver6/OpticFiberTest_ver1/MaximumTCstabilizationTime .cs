using System;
using System.Collections.Generic;

namespace OpticFiberTest_ver1.Classes_SFF8636
{
    class MaximumTCstabilizationTime : SFF8636
    {
        public MaximumTCstabilizationTime()
        {
            m_title = "Maximum TC Stabilization Time";
            m_size = 1;
            m_address = 228;
            m_page = 3;
        }
        /****************************************************************
        * This function is encoding, comparing and define the value according sff-8636
        ***************************************************************/
        public override void EncodeValue(string name)
        {
            Byte b = Convert.ToByte(name);
            m_storedValue += "\n\tMaximum TC stabilization time is: " + b.ToString() + " Seconds";
        }
    }

}
