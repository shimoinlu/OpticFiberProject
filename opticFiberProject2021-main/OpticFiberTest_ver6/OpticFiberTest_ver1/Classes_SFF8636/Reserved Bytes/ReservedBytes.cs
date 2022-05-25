using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpticFiberTest_ver1.Classes_SFF8636
{
    class ReservedBytes : SFF8636
    {
        public ReservedBytes(int address, short length)
        {
            // the title of byte
            m_title = "Check Reserved Bytes";
            // the size of byte
            m_size = length;
            // the address of byte
            m_address = (byte)address;
            // locate in page num
            m_page = 3;

        }

        public override void EncodeValue(string name)
        {
            string[] bytes = name.Split(' ');
            Boolean Exception = false;
            for (int i = 0; i < bytes.Length; ++i)
            {
                if (bytes[i] != "00")
                {
                    m_storedValue += "\n\tByte " + (m_address + i).ToString() + "must be reserved.\n\t it cannnot contain " + bytes[i] + '\n';
                    Exception = true;
                }
            }
            if (Exception)
                throw new Exception();
            else
                m_storedValue += "\n\tall bytes in " + m_address.ToString() + " - " + (m_address + m_size-1).ToString() + "is reserved\n";
        }

    }
}

