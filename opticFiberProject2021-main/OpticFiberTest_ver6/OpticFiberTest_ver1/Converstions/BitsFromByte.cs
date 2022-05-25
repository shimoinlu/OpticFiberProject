using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpticFiberTest_ver1.Converstions
{
    class BitsFromByte
    {
        public static uint getStrBitAsUintFromByte(byte b, int firstIndex, int lastIndex)
        {
            uint mask =  (uint)(2 ^ (lastIndex - firstIndex+1)-1);
            uint res = b & (mask << firstIndex);
            res = res >> firstIndex;
            return res;

        }
        public static string HexToBinaryBytes(string hex)
        {
            return  String.Join(String.Empty,
              hex.Select(
                c => Convert.ToString(Convert.ToInt32(c.ToString(), 16), 2).PadLeft(4, '0')
              )
            );

        }

    }
}
