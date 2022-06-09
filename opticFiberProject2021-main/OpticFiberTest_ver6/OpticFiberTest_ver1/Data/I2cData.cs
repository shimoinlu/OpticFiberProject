using System;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Xml.Linq;
using OpticFiberTest_ver1.Classes_SFF8636;
using System.Threading.Tasks;
using System.Diagnostics;

namespace OpticFiberTest_ver1.Data
{
    class I2cData {
        private static String myDataLine; //will hold as string all the data that we read, 128 bytes
        private static String myDataLineP3; //will hold as string all the data that we read, 128 bytes
        private static String[] myData; //data will be splited to here
        private static String[] myData1; //data will be splited to here
        private static bool m_demoIsConnected = false;

        static I2cData() {

        }

        static public bool demoIsConnected()
        {
            return m_demoIsConnected;
        }

        static public void Connect()
        {
            if (!m_demoIsConnected)
                i2cReader.AAI2cEeprom.getData(0, 1); //REAL      
            
        }
        static public int getTemp()
        {
            return (new Temperature().getTemperature());
        }
        static public float getVol()
        {

            float vol = (i2cReader.AAI2cEeprom.getByte(26,0) << 8) + i2cReader.AAI2cEeprom.getByte(27, 0);

            vol /= 10000;
            if (vol <= 0 && m_demoIsConnected != false)            
                throw new Exception();
                
            return vol;
        }
        static public void connectToDemo()
        {
            m_demoIsConnected = true;
        }
        static public void disConnectToDemo()
        {
            m_demoIsConnected = false;
        }

        static public void ReadTheData()
        {

            if (!m_demoIsConnected)
            {
                myDataLine = i2cReader.AAI2cEeprom.getData(0, 256); //REAL
                myDataLineP3 = i2cReader.AAI2cEeprom.getData(0, 256,3); //REAL
                Debug.WriteLine("line1 is: "+ myDataLine.ToString()) ;
                Debug.WriteLine("line3 is: "+ myDataLineP3.ToString()) ;
            }
            else
            {
                //demo string, remove commet and put in comment the real thing
                myDataLine = "";
                myDataLineP3 = File.ReadAllText(@"files\dempDataP3.txt");


                
                // Loading from a file, you can also load from a stream
                var xml = XDocument.Load("files/XMLFile1.xml");


                // Query the data and write out a subset of contacts
                var query = from c in xml.Root.Descendants("Byte")
                            select c.Element("ByteVal").Value;


                foreach (string name in query)
                {
                    myDataLine += name + " ";
                }

                myDataLine = myDataLine.Substring(0,767);
                
            }

//            myDataLineP3 = File.ReadAllText(@"files\dempDataP3.txt");
            myData = myDataLine.Split();
            myData1 = myDataLineP3.Split();
            for (int p = 0; p < myData1.Length; ++p)
                Debug.WriteLine(p.ToString() + " " + myData1[p]);
        }


        static public string getPage3Input(int index)
        {
            return myData1[index];  
        }


        //taking part of the data string and return it as substring
        static public String Geti2cDataSub(int index, int buffer,int page = 1)
        {
            String result;
            if (page == 1)
                result = myData[index];
            else
            {
                
                result = myData1[index];
            }

            for (int i = index + 1; i < index + buffer; i++)
            {

                result += ' ';

                if (page == 1)
                    result += myData[i];
                else
                    result += myData1[i];
            }
            return result;
        }
        static public String[] GetData() //get all the data
        {
            return myData;
        }
        /****************************************************************
        * This function counting all the given bytes from startIndex till buffer
        * and return the result.
        ***************************************************************/
        static public BigInteger HexaCounterOfHexString(int startIndex, int buffer) 
        {
            String[] hexValuesSplit = myDataLine.Substring(startIndex, buffer).Split();
            BigInteger sumOfAllBytes = 0;
            for(int i = startIndex; i < startIndex + buffer;++i)
            {
                sumOfAllBytes += Convert.ToInt32(myData[i], 16);

            }


            //foreach (string hex in hexValuesSplit)
            //{
            //    if (hex == "")
            //        continue;
            //    sumOfAllBytes += Convert.ToInt32(hex, 16);
            //}
            return sumOfAllBytes;
        }
    }
}