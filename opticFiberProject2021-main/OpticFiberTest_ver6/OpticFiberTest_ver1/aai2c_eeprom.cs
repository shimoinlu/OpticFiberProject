/*=========================================================================
 this program validate an optical fiber by readind it's upper page and
 compare the values to those in the protocol of this specific optical
 fiber.
 ========================================================================*/

using System;
using System.Diagnostics;
using TotalPhase;
using I2C = OpticFiberTest_ver1.Data;

//using System.Data;

namespace i2cReader
{

    public class AAI2cEeprom
    {
        public const int PAGE_SIZE = 8;
        public const int BUS_TIMEOUT = 150;  // ms
        public const int PORT = 0;
        public const byte DEVICE = 0x50;
        public const byte PAGE_SELECTOR = 0x7F;
        private static bool is_open = false;


        //this function read from the memory in a spesific address 
        static string _readMemory(int handle, byte device, byte addr, short length,int page)
        {
            byte[] dataOut = { addr };
            byte[] dataIn = new byte[length];
            byte[] page_select = { PAGE_SELECTOR };
            byte[] page_num = { (byte)page };
            int count, i;

            // Write the address
            //tmprary
            int a, b, c;
            a = AardvarkApi.aa_i2c_write(handle, DEVICE, AardvarkI2cFlags.AA_I2C_NO_FLAGS, (ushort)1, page_select);

            b = AardvarkApi.aa_i2c_write(handle, DEVICE, AardvarkI2cFlags.AA_I2C_NO_STOP, (ushort)1, page_num);

            b = AardvarkApi.aa_i2c_write(handle, DEVICE, AardvarkI2cFlags.AA_I2C_NO_STOP, (ushort)1, dataOut);

            count = AardvarkApi.aa_i2c_read(handle, DEVICE, AardvarkI2cFlags.AA_I2C_NO_FLAGS, (ushort)length, dataIn);

            int[] data = new int[length];
            


            // Dump the data to the screen
            for (i = 0; i < count; ++i)
                data[i] = (dataIn[i] & 0xff);

            //convert to string
            string result = "";
            for (i = 0; i < length; ++i)
            {
                result += DecimalToHexadecimal(data[i]);
                if (i < length - 1)
                    result += " ";
            }

            return result;
        }


        //check if there is an attached device connected to the computer
        public static bool CheckIfDevicesAttached()
        {
            ushort[] ports = new ushort[16];
            uint[] uniqueIds = new uint[16];
            int numElem = 16;
            int count = AardvarkApi.aa_find_devices_ext(numElem, ports,
                                                numElem, uniqueIds);
            
            if (count < 1)
                return false;
            return true;
        }

        //get data from device
        public static string getData(byte addr, short length,int page = 0)
        {
            //int bitrate = 100;
            int handle = AardvarkApi.aa_open(PORT);
            if (handle < 0)
                throw new Exception();

            //read the values from the device and validate them
            string data = _readMemory(handle, DEVICE, addr, length, page);
           



            // Close the device and exit
            AardvarkApi.aa_close(handle);
            return data;
        }


            public static string DecimalToHexadecimal(int dec)
        {
            if (dec < 1) return "00";

            int hex = dec;
            string hexStr = string.Empty;

            while (dec > 0)
            {
                hex = dec % 16;

                if (hex < 10)
                    hexStr = hexStr.Insert(0, Convert.ToChar(hex + 48).ToString());
                else
                    hexStr = hexStr.Insert(0, Convert.ToChar(hex + 55).ToString());

                dec /= 16;
            }

            //add 0 in the begining if the length is odd
            if (hexStr.Length % 2 != 0)
                hexStr = "0" + hexStr;

            return hexStr;
        }
        public static byte getByte(Byte address, byte pageNumber)
        {
            if (I2C.I2cData.demoIsConnected())
            {
                    return Convert.ToByte(I2C.I2cData.Geti2cDataSub(address,pageNumber),16);
            }

            int handle = 0;


            handle = AardvarkApi.aa_open(PORT);


            byte[] dataOut = { address };
            byte[] dataIn = new byte[1];
            byte[] page_select = { PAGE_SELECTOR };
            byte[] page_num = { pageNumber };

            // Write the address
            //tmprary
            int a, b, c;
            a = AardvarkApi.aa_i2c_write(handle, DEVICE, AardvarkI2cFlags.AA_I2C_NO_FLAGS, (ushort)1, page_select);

            b = AardvarkApi.aa_i2c_write(handle, DEVICE, AardvarkI2cFlags.AA_I2C_NO_STOP, (ushort)1, page_num);

            b = AardvarkApi.aa_i2c_write(handle, DEVICE, AardvarkI2cFlags.AA_I2C_NO_STOP, (ushort)1, dataOut);

            c = AardvarkApi.aa_i2c_read(handle, DEVICE, AardvarkI2cFlags.AA_I2C_NO_FLAGS, (ushort)1, dataIn);







            AardvarkApi.aa_close(handle);

            return Convert.ToByte(dataIn[0] & 0xff);

        }


        
    }
}