using System;
using System.Numerics;
using Convers = OpticFiberTest_ver1.Converstions;

namespace OpticFiberTest_ver1.Classes_SFF8636
{
    abstract class BaseRange : SFF8636
    {
        /****************************************************************
        * This function is encoding, comparing and define the value according sff-8636
        ***************************************************************/
        virtual public bool ValidateValue(int val)
        {
            return val >=m_min && val <= m_max;

        }
        public Double getMin() { return m_min; }
        public Double getMax() { return m_max; }
        protected Double m_min = 0; //hold low 8 bits of the sum of all bytes we counted
                                    //         int startIndex; //the index we start to take the sub string of the string of all the data
        protected Double m_max = 0;
    }

}
