using System;
//using System.Text;

namespace OpticFiberTest_ver1.Converstions
{
/****************************************************************
* This class is converter from hex "MSB LSB" to one number
***************************************************************/

    class HexToBinary
    {
        public static string convert(string Hex)
        {
            return Convert.ToString(Convert.ToInt32(Hex, 16), 2);
        }
    }
 
}
