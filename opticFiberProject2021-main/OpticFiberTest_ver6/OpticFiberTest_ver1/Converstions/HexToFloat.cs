using System;
using System.Linq;

namespace OpticFiberTest_ver1.Converstions
{

    /****************************************************************
    * This class is converter from hex to float
    ***************************************************************/
    class HexToFloat
    {
        const double BASE = 16;

        public static float ConvertTwosComplementToInteger(float rawValue, int numOfByte)
        {

            float max = (float)Math.Pow(BASE, numOfByte*2);

            // If a positive value, return it
            if (rawValue < max/2)
            {
                return rawValue;
            }

            return rawValue - max;
        }

        static public float HexToFloadConverter(string hex)
        {
            string T = String.Concat(hex.Where(c => !Char.IsWhiteSpace(c)));

            return ulong.Parse(T, System.Globalization.NumberStyles.AllowHexSpecifier);

        }
    }
}
