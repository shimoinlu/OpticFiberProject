using System;
//using System.Text;

namespace OpticFiberTest_ver1.Converstions
{
/****************************************************************
* This class is converter from hex "MSB LSB" to one number
***************************************************************/

    class LsbMsb
    {
        public static string MergeLsbMsb(string str)
        {
            string[] temp = str.Split();
            str = temp[1] + temp[0];
            return str;
        }
    }
 
}
