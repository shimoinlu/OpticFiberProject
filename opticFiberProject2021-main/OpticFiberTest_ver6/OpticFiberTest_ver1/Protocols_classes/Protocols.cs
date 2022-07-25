using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpticFiberTest_ver1.Protocols_classes
{
    public abstract class Protocols
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
        virtual public void SumAllBits(ref Dictionary<int, Protocols> MainDictionary) { }
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
            if (m_storedValue != "")
                return m_storedValue;
            else
                return "value not exist";
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
        protected int m_page = 0;

    }
}
