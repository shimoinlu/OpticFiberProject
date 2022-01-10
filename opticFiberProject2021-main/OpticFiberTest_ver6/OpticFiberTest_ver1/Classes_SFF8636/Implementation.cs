using System;
using System.Collections.Generic;
using Convers = OpticFiberTest_ver1.Converstions;

namespace OpticFiberTest_ver1.Classes_SFF8636
{
    class Implementation : SFF8636
    {
        public Implementation()
        {
            m_title = "Enhanced Options";
            m_size = 1;
            m_address = 113;

        }
        /****************************************************************
        * This function is encoding, comparing and define the value according sff-8636
        ***************************************************************/
        public override void EncodeValue(string name) {



            m_storedValue += "Near-End Implementation:";
            for (int i = 0; i < 4; ++i)
            {

                    m_storedValue += "\n\t\tChannel " + (i + 1).ToString();

                // if bit is 1
                    if (getStrBitValue(name, i))
                        m_storedValue += " implemented";
                    else
                        m_storedValue += " NOT implemented";

            }

            string temp1 = Convers.HexToBinary.convert(name);
            string temp2 = "";

            for (int i = 0; i < 8 - temp1.Length; i++)
                temp2 += "0";

            string binary = temp1 + temp2;
       
            binary = binary.Substring(4,3);

            m_storedValue += "\n\tFar-End Implementation:\n\t\t";
            // switch case for all the options of Implementations
            switch (Convert.ToInt32(binary, 2))
            {
                case 0:
                    m_storedValue += "end is unspecified";
                    break;
                case 1:
                    m_storedValue += "Cable with single far-end with 4 channels implemented,\n\t or separable module with a 4 -channel connector";
                    break;
                case 2:
                    m_storedValue += "Cable with single far-end with 2 channels implemented,\n\t or separable module with a 2 -channel connector";
                    break;
                case 3:
                    m_storedValue += "Cable with single far-end with 1 channel implemented, or separable module with a 1 -channel connector";
                    break;
                case 4:
                    m_storedValue += "4 far - ends with 1 channel implemented in each(i.e. 4x1 break out)";
                    break;
                case 5:
                    m_storedValue += "2 far - ends with 2 channels implemented in each(i.e. 2x2 break out)";
                    break;
                case 6:
                    m_storedValue += "2 far - ends with 1 channel implemented in each(i.e. 2x1 break out)";
                    break;
            }
         

        }

        public bool getStrBitValue(string name, int num)
        {
            int value = Convert.ToInt32(name, 16);
            string val = Convert.ToString(1 & (value >> num));
            if (val == "1")
                return true;
            return false;
        }


        private Dictionary<string, string> dict1;  //the Dictionary of the ExtIdentifier

    }

}
