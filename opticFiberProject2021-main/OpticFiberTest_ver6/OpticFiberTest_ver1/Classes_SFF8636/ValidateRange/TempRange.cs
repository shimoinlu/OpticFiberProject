using System;
using System.Numerics;
namespace OpticFiberTest_ver1.Classes_SFF8636
{
     class TempRange : BaseRange
    {
        /****************************************************************
        * This function summing all the bytes for part of CC_BASE and CC_EXT
        ***************************************************************/

        public TempRange()
        {
            m_title = "CC_EXT";
            m_size = 1;
            m_address = 128;
            m_page = 3;

            int first = m_address + 2;
            int second = m_address + 1;

            m_max = ((SByte)i2cReader.AAI2cEeprom.getByte(m_address, (byte)m_page) << 8) + i2cReader.AAI2cEeprom.getByte((byte)second, (byte)m_page);
            second += 2;
            //min temperature
            m_min = ((SByte)i2cReader.AAI2cEeprom.getByte((byte)first, (byte)m_page) << 8) + i2cReader.AAI2cEeprom.getByte((byte)second, (byte)m_page);

            //m_title = "tamp randge limits";
        }
        override public bool ValidateValue(int val)
        {
            UpdateMinMax();
            return base.ValidateValue(val);
        }
        void UpdateMinMax()
        {

        }


        /****************************************************************
        * This function is encoding, comparing and define the value according sff-8636
        ***************************************************************/

    }
}
