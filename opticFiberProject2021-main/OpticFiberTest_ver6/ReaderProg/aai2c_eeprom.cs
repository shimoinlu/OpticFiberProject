/*=========================================================================
 this program validate an optical fiber by readind it's upper page and
 compare the values to those in the protocol of this specific optical
 fiber.
 ========================================================================*/

using System;
using TotalPhase;
using System.Collections.Generic;
using System.Text.RegularExpressions;
//using System.Data;

namespace i2cReader
{

    public class AAI2cEeprom
    {
        public const int PAGE_SIZE = 8;
        public const int BUS_TIMEOUT = 150;  // ms
        public const int PORT = 0;
        public const byte DEVICE = 80;
   

       //this function write to the memory to get the permission to read
       static void _writeMemory(int handle, byte device, byte addr)
       {
           short i, n = 0;
           byte[] dataOut = null;

           int size = Math.Min(((addr & (PAGE_SIZE - 1)) ^ (PAGE_SIZE - 1)) + 1, 1);
           size++;  // Add 1 for the address field
           if (dataOut == null || dataOut.Length != size)
               dataOut = new byte[size];

           // Fill the packet with data
           dataOut[0] = addr;

           // Assemble a page of data
           i = 1;
           do
           {
               dataOut[i++] = (byte)0;
               ++addr; ++n;
           } while (n < 1 && (addr & (PAGE_SIZE - 1)) != 0);

           // Write the address and data
           AardvarkApi.aa_i2c_write(handle, device, AardvarkI2cFlags.AA_I2C_NO_FLAGS, (ushort)size, dataOut);
           AardvarkApi.aa_sleep_ms(10);
       }

       //this function read from the memory in a spesific address 
       static string _readMemory(int handle, byte device, byte addr, short length) {
           int count, i;
           byte[] dataOut = { addr };
           byte[] dataIn = new byte[length];

           // Write the address
           AardvarkApi.aa_i2c_write(handle, device, AardvarkI2cFlags.AA_I2C_NO_STOP, (ushort)length, dataOut);

           count = AardvarkApi.aa_i2c_read(handle, device, AardvarkI2cFlags.AA_I2C_NO_FLAGS, (ushort)length, dataIn);
           if (count < 0) {
               Console.WriteLine("error: {0}\n", AardvarkApi.aa_status_string(count));
              // return;
           }
           if (count == 0) {
               Console.WriteLine("error: no bytes read");
               //return;
           }
           else if (count != length) {
               Console.WriteLine("error: read {0} bytes (expected {1})", count, length);
           }

           // Dump the data to the screen
           String data = "";

           for (i = 0; i < count; ++i) {
               if ((i & 0x0f) == 0) 
                   Console.Write("\n{0:x4}:  ", addr + i); //print address
               data += Convert.ToString(dataIn[i] & 0xff); 
               //data += System.Text.Encoding.UTF8.GetString(dataIn[i] & 0xff); 
               Console.Write("{0:x2} ", dataIn[i] & 0xff); //print data pairs

               if (((i + 1) & 0x07) == 0) 
                   Console.Write(" "); //print spaces
           }

           Console.WriteLine();

           return data;
       }

        //main program
        public static string B(string[] args)
        {
            byte addr = Convert.ToByte(args[0]);
            short length = Convert.ToInt16(args[1]);
            int bitrate = 100;

            int handle = AardvarkApi.aa_open(PORT);
            AardvarkApi.aa_configure(handle, AardvarkConfig.AA_CONFIG_SPI_I2C);
            AardvarkApi.aa_i2c_pullup(handle, AardvarkApi.AA_I2C_PULLUP_BOTH);
            AardvarkApi.aa_target_power(handle, AardvarkApi.AA_TARGET_POWER_BOTH);
            bitrate = AardvarkApi.aa_i2c_bitrate(handle, bitrate);     // Set the bitrate
            int bus_timeout = AardvarkApi.aa_i2c_bus_timeout(handle, BUS_TIMEOUT);   // Set the bus lock timeout
            
            //write to device for first reading
            _writeMemory(handle, DEVICE, addr);

            //read the values from the device and validate them
            string data = _readMemory(handle, DEVICE, addr, length);
            
            // Close the device and exit
            AardvarkApi.aa_close(handle);
            return data;
        }
            
    }
}