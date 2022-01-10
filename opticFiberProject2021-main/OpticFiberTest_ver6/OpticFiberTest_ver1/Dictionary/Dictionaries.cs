using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpticFiberTest_ver1.Converstions
{
    class Dictionaries
    {



        public static Dictionary<string, string> getDictionaryByByteNum(byte numOfByte)
        {
            switch (numOfByte)
            {
                case 3:
                    return dictOfByte3;
                case 4:
                    return dictOfByte4;
                case 5:
                    return dictOfByte5;
                case 6:
                    return dictOfByte6;
                case 7:
                    return dictOfByte7;
                case 9:
                    return dictOfByte9;
                case 10:
                    return dictOfByte10;
                case 11:
                    return dictOfByte11;
                case 12:
                    return dictOfByte12;
                case 13:
                    return dictOfByte13;


                case 14:
                    return dictOfByte14;
                default:
                    return dictOfByte14;
            }


        }
        static Dictionary<string, string> dictOfByte14 = new Dictionary<string, string>() {
            { "7", "Latched Tx4 LOS indicator"},
            { "6", "Latched Tx3 LOS indicator"},
            { "5", "Latched Tx2 LOS indicator"},
            { "4", "Latched Tx1 LOS indicator"},
            { "3", "Latched Rx4 LOS indicator"},
            { "2", "Latched Rx3 LOS indicator"},
            { "1", "Latched Rx2 LOS indicator"},
            { "0", "Latched Rx1 LOS indicator" },
        };

        static Dictionary<string, string> dictOfByte13 = new Dictionary<string, string>() {
            { "7", "Latched Tx4 LOS indicator"},
            { "6", "Latched Tx3 LOS indicator"},
            { "5", "Latched Tx2 LOS indicator"},
            { "4", "Latched Tx1 LOS indicator"},
            { "3", "Latched Rx4 LOS indicator"},
            { "2", "Latched Rx3 LOS indicator"},
            { "1", "Latched Rx2 LOS indicator"},
            { "0", "Latched Rx1 LOS indicator" },
        };
        static Dictionary<string, string> dictOfByte12 = new Dictionary<string, string>() {
            { "7", "Latched Tx4 LOS indicator"},
            { "6", "Latched Tx3 LOS indicator"},
            { "5", "Latched Tx2 LOS indicator"},
            { "4", "Latched Tx1 LOS indicator"},
            { "3", "Latched Rx4 LOS indicator"},
            { "2", "Latched Rx3 LOS indicator"},
            { "1", "Latched Rx2 LOS indicator"},
            { "0", "Latched Rx1 LOS indicator" },
        };
        static Dictionary<string, string> dictOfByte11 = new Dictionary<string, string>() {
            { "7", "Latched Tx4 LOS indicator"},
            { "6", "Latched Tx3 LOS indicator"},
            { "5", "Latched Tx2 LOS indicator"},
            { "4", "Latched Tx1 LOS indicator"},
            { "3", "Latched Rx4 LOS indicator"},
            { "2", "Latched Rx3 LOS indicator"},
            { "1", "Latched Rx2 LOS indicator"},
            { "0", "Latched Rx1 LOS indicator" },
        };

        static Dictionary<string, string> dictOfByte10 = new Dictionary<string, string>() {
            { "7", "Latched Tx4 LOS indicator"},
            { "6", "Latched Tx3 LOS indicator"},
            { "5", "Latched Tx2 LOS indicator"},
            { "4", "Latched Tx1 LOS indicator"},
            { "3", "Latched Rx4 LOS indicator"},
            { "2", "Latched Rx3 LOS indicator"},
            { "1", "Latched Rx2 LOS indicator"},
            { "0", "Latched Rx1 LOS indicator" },
        };

        static Dictionary<string, string> dictOfByte9 = new Dictionary<string, string>() {
            { "7", "Latched Tx4 LOS indicator"},
            { "6", "Latched Tx3 LOS indicator"},
            { "5", "Latched Tx2 LOS indicator"},
            { "4", "Latched Tx1 LOS indicator"},
            { "3", "Latched Rx4 LOS indicator"},
            { "2", "Latched Rx3 LOS indicator"},
            { "1", "Latched Rx2 LOS indicator"},
            { "0", "Latched Rx1 LOS indicator" },
        };
        static Dictionary<string, string> dictOfByte7 = new Dictionary<string, string>() {
            { "7", "Latched Tx4 LOS indicator"},
            { "6", "Latched Tx3 LOS indicator"},
            { "5", "Latched Tx2 LOS indicator"},
            { "4", "Latched Tx1 LOS indicator"},
            { "3", "Latched Rx4 LOS indicator"},
            { "2", "Latched Rx3 LOS indicator"},
            { "1", "Latched Rx2 LOS indicator"},
            { "0", "Latched Rx1 LOS indicator" },
        };
        static Dictionary<string, string> dictOfByte6 = new Dictionary<string, string>() {
            { "7", "Latched Tx4 LOS indicator"},
            { "6", "Latched Tx3 LOS indicator"},
            { "5", "Latched Tx2 LOS indicator"},
            { "4", "Latched Tx1 LOS indicator"},
            { "3", "Latched Rx4 LOS indicator"},
            { "2", "Latched Rx3 LOS indicator"},
            { "1", "Latched Rx2 LOS indicator"},
            { "0", "Latched Rx1 LOS indicator" },
        };

        static Dictionary<string, string> dictOfByte5 = new Dictionary<string, string>() {
            { "7", "Latched Tx4 LOS indicator"},
            { "6", "Latched Tx3 LOS indicator"},
            { "5", "Latched Tx2 LOS indicator"},
            { "4", "Latched Tx1 LOS indicator"},
            { "3", "Latched Rx4 LOS indicator"},
            { "2", "Latched Rx3 LOS indicator"},
            { "1", "Latched Rx2 LOS indicator"},
            { "0", "Latched Rx1 LOS indicator" },
        };
        static Dictionary<string, string> dictOfByte4 = new Dictionary<string, string>() {
            { "7", "Latched Tx4 LOS indicator"},
            { "6", "Latched Tx3 LOS indicator"},
            { "5", "Latched Tx2 LOS indicator"},
            { "4", "Latched Tx1 LOS indicator"},
            { "3", "Latched Rx4 LOS indicator"},
            { "2", "Latched Rx3 LOS indicator"},
            { "1", "Latched Rx2 LOS indicator"},
            { "0", "Latched Rx1 LOS indicator" },
        };
        static Dictionary<string, string> dictOfByte3 = new Dictionary<string, string>() {
            { "7", "Latched Tx4 LOS indicator"},
            { "6", "Latched Tx3 LOS indicator"},
            { "5", "Latched Tx2 LOS indicator"},
            { "4", "Latched Tx1 LOS indicator"},
            { "3", "Latched Rx4 LOS indicator"},
            { "2", "Latched Rx3 LOS indicator"},
            { "1", "Latched Rx2 LOS indicator"},
            { "0", "Latched Rx1 LOS indicator" },
        };
    }
}


