using System;

namespace OpticFiberTest_ver1.Validations
{
    /****************************************************************
* This class is validates bits of readden data.
***************************************************************/
    public abstract class ValidBits
    {
        static public bool IsValid(string oneByte)
        {
            long longValue = Convert.ToInt64(oneByte, 16);
            string binRepresentation = Convert.ToString(longValue, 2);
            
            int count = 0;
            for (int i = 0; i < 8; i++)
                try
                {
                    if (binRepresentation[i] == '1')
                        ++count;
                }
                catch
                {
                    if (count > 1)
                        return false;
                }
            return true;
        }

        private static int calcLength(string binRepresentation)
        {
            int count = 0;
            while (count < 8)
            {
                try
                {
                    if (binRepresentation[count] == 'a')
                    ++count;
                }
                catch
                {
                    return count;
                }

            }
            return 8;

        }
    }
}
