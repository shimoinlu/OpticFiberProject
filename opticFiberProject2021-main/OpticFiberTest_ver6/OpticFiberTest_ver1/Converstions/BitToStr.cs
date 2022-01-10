using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpticFiberTest_ver1.Converstions
{
    class BitToStr
    {
        public static bool getStrBitValue(string name, int num)
        {
            int value = Convert.ToInt32(name, 16);
            string val = Convert.ToString(1 & (value >> num));
            if (val == "1")
                return true;
            return false;
        }

    }
}
