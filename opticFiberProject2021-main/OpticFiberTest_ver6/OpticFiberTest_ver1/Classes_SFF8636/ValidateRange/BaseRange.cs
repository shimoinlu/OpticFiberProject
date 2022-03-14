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
        public override void EncodeValue(string name)
        {
         BigInteger m_min; //hold low 8 bits of the sum of all bytes we counted
//         int startIndex; //the index we start to take the sub string of the string of all the data
         BigInteger m_max;

        string[] bitsAdrr = name.Split(' '); //split the value
             m_min = Convert.ToInt32(Convers.HexToAsc.Convert2Asc(bitsAdrr[0] + bitsAdrr[1])); //convert to ascii
             m_max = Convert.ToInt32(Convers.HexToAsc.Convert2Asc(bitsAdrr[2] + bitsAdrr[3])); //convect to ascii

            m_storedValue = "max is: " + Convert.ToString(m_max) + "min is: " + Convert.ToString(m_min) + '\n';



        }
    }
}
