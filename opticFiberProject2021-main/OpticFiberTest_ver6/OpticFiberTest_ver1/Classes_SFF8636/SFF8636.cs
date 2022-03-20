//*********************Classes_SFF8636 Definitions**********************************//
//128 1    Identifier      00
//129 1    ExtIdentifier   00
//130 1    ConnectorType   00


/****************************************************************
 * SFF8636 is abstract class that will be the base class of any 
 * Parameter Class.
 ***************************************************************/
using System;
using System.Collections.Generic;


namespace OpticFiberTest_ver1.Classes_SFF8636
{
    public abstract class SFF8636
    {
        public abstract void EncodeValue(string name); //abstract function to get value
        virtual public void ValidateVal(string name)
        {
            try
            {
                EncodeValue(name);
            }
            catch (Exception e)
            {
                if (e.Message == "Warning")
                    m_textColor = "Black";
                else
                    m_textColor = "Red";
            }
        }
        virtual public void SumAllBits(ref Dictionary<int, SFF8636> MainDictionary) { }
        public string getColor()
        {
            return m_textColor;
        }
 
        public byte GetAddress()
        {
            
            return m_address; ;
        }   //GetAddress will return the address

        public short GetSize()
        {
            return m_size;
        }   //GetSize will return the size

        public string GethasRead()
        {
            return m_storedValue;
        }   //GethasRead will return the value that we read
        public void SethasRead(string x)
        {
            m_storedValue = x;
        }   //SethasRead will set the value that we read

        public string GetTitle() { return m_title; }
        public int GetPage() { return m_page; }


        protected short m_size;   //m_size protected int member for all classes
        protected byte m_address = 0;    //m_address protected int member for all classes
        protected string m_storedValue = ""; //m_storedValue protected int member for all classes
        protected string m_title;
        protected string m_textColor = "Green";
        protected int m_page = 1;

    }

}