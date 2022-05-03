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


    }
}
