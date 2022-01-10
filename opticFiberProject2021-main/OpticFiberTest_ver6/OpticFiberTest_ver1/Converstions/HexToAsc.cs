using System;
using System.Text;

namespace OpticFiberTest_ver1.Converstions
{
/****************************************************************
* This class is converter from hex to ascii
***************************************************************/
    public abstract class HexToAsc
    {
        static public string Convert2Asc(string hex)
        {
            string[] ourHex = hex.Split(' ');
            hex = "";
            foreach (var i in ourHex)
            {
                hex += Encoding.ASCII.GetString(FromHex(i));
                
            }

            return hex;
        }

        private static byte[] FromHex(string hex)
        {
            var result = new byte[hex.Length / 2];
            for (var i = 0; i < result.Length; i++)
            {
                result[i] = Convert.ToByte(hex.Substring(i * 2, 2), 16);
            }
            
            return result;
        }
    }
}
