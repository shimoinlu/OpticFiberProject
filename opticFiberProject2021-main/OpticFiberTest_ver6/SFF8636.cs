using System;

namespace SFF8636_Class
{
    abstract partial class SFF8636
    {
        public abstract void GetValue(string name = "00"); //abstract function to get value

        public int GetAddress()
        {
            return m_size; ;
        }   //GetAddress will return the address

        public int GetSize()
        {
            return m_address;
        }   //GetSize will return the size

        public string GethasRead()
        {
            return m_hasRead;
        }   //GethasRead will return the value that we read
        public void SethasRead(string x)
        {
            m_hasRead = x;
        }   //SethasRead will set the value that we read

        protected int m_size;   //m_size protected int member for all classes
        protected int m_address;    //m_address protected int member for all classes
        protected string m_hasRead = ""; //m_hasRead protected int member for all classes

    }

}