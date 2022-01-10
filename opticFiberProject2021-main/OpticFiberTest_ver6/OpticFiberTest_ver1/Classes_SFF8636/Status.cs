using System.Collections.Generic;
using System;
using Convers = OpticFiberTest_ver1.Converstions;

namespace OpticFiberTest_ver1.Classes_SFF8636
{
    /****************************************************************
    * This class is for identifier. it holding all of the values we
    * get according the readed value from byte 128. each byte meant to
    * get information from different dict. we iterate the value bytes and
    * take the values from the dictionaries accordinly
    ***************************************************************/
    public class Status : SFF8636
    {
        public Status()
        {
            m_title = "Status";
            m_size = 1;
            m_address = 2;

            dict = new Dictionary<string, string>() {
            { "7", "Memory Page 02 provided"},
            { "6", "Complicated"},
            { "5", "Complicated"},
            { "4", "Tx input adaptive equalizers freeze capable"},
            { "3", "Tx input equalizers auto-adaptive capable"},
            { "2", "Tx input equalizers fixed-programmable settings"},
            { "1", "Rx output emphasis fixed-programmable settings"},
            { "0", "Data_Not_Ready" },
        };

            Proper = new Dictionary<string, string>() {
            { "0", "The data is ready"},
            { "1", "Asserted" },
        };

            notProper = new Dictionary<string, string>() {
            { "0", "The data is not ready"},
            { "1", "Not Asserted" },
        };
        }
        /****************************************************************
        * This function is encoding, comparing and define the value according sff-8636
        ***************************************************************/
        public override void EncodeValue(string name)
        {
            bool valid = true;

            for(int i = 0; i < 2; i++)
            {
                if (Convers.BitToStr.getStrBitValue(name, i))
                {
                    dict[Convert.ToString(i)] = notProper[Convert.ToString(i)];
                    valid = false;
                }
                else

                    dict[Convert.ToString(i)] = Proper[Convert.ToString(i)];
            }

            if (Convers.BitToStr.getStrBitValue(name, 2))
            {
                dict["2"] = "Flat memory (lower and upper pages 00h only)";
            }
            else
            {
                dict["2"] = " Paging (at least upper page 03h implemented)";
            }

            for (int i = 0; i < 3; i++)
                m_storedValue += dict[Convert.ToString(i)] + "\n\t";

            if(!valid)
                throw new Exception();
        }


        private Dictionary<string, string> dict;
        private Dictionary<string, string> Proper;
        private Dictionary<string, string> notProper;

    }
}