using System;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Xml.Linq;
using OpticFiberTest_ver1.Protocols_classes.Classes_SFF8636;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Collections.Generic;

namespace OpticFiberTest_ver1.Data
{
    class I2cData {
        private static String[] myDataLine; //will hold as string all the data that we read, 128 bytes
        private static String myDataLineP3; //will hold as string all the data that we read, 128 bytes
//        private static String[] myData; //data will be splited to here
        private static Dictionary<int, String[]>myData; //data will be splited to here
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

        static public void ReadTheData(int [] pages)
        {
            myDataLine = new string[pages.Length];

            if (!m_demoIsConnected)
            {
                for (int i = 0; i < pages.Length; ++i)
                    myDataLine[i] = i2cReader.AAI2cEeprom.getData(0, 256, pages[i]); //REAL
            }
            else
            {
                //demo string, remove commet and put in comment the real thing

                // Loading from a file, you can also load from a stream
                for (int i = 0; i < pages.Length; ++i)
                {
                    var xml = XDocument.Load("files/XMLFile1.xml");


                    // Query the data and write out a subset of contacts
                    var query = from c in xml.Root.Descendants("Byte")
                                select c.Element("ByteVal").Value;

                    foreach (string name in query)
                    {
                        myDataLine[i] += name + " ";
                    }
                }
                
            }
            myData = new Dictionary<int, string[]>(pages.Length);
            for (int i = 0; i < pages.Length; ++i)
                myData.Add(pages[i],myDataLine[i].Split());
            //Debug.WriteLine("##################################################################");
            //for (int i = 0; i < myData.Length; ++i)
            //    Debug.WriteLine(i.ToString() + " " + myData[i]);
            //Debug.WriteLine("@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@");
            //for (int i = 0; i < myData1.Length; ++i)
            //    Debug.WriteLine(i.ToString() + " " + myData1[i]);
            //Debug.WriteLine("##################################################################");


        }


        //static public string getPage3Input(int index)
        //{
        //    return myData1[index];  
        //}


        //taking part of the data string and return it as substring
        static public String Geti2cDataSub(int index, int buffer,int page = 0)
        {
            String result = "";
            for (int i = index; i < index + buffer; i++)
            {
                result += myData[page][i];
                result += ' ';
            }

            result = result.Substring(0, result.Length - 1);

            return result;
        }
        //static public String[] GetData() //get all the data
        //{
        //    return myData;
        //}
        /****************************************************************
        * This function counting all the given bytes from startIndex till buffer
        * and return the result.
        ***************************************************************/
        static public BigInteger HexaCounterOfHexString(int startIndex, int buffer,int page = 0) 
        {
//            String[] hexValuesSplit = myDataLine.Substring(startIndex, buffer).Split();
            BigInteger sumOfAllBytes = 0;
            for(int i = startIndex; i < startIndex + buffer;++i)
            {
                sumOfAllBytes += Convert.ToInt32(myData[page][i], 16);

            }


            return sumOfAllBytes;
        }
    }
}