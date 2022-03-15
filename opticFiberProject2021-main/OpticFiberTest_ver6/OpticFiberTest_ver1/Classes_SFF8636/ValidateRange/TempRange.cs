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
            m_address = 223;
            m_max = ((SByte)i2cReader.AAI2cEeprom.getByte(128, 3) << 8) + i2cReader.AAI2cEeprom.getByte(129, 3);

            //min temperature
            m_min = ((SByte)i2cReader.AAI2cEeprom.getByte(130, 3) << 8) + i2cReader.AAI2cEeprom.getByte(131, 3);
            //m_title = "tamp randge limits";
        }
        override public bool ValidateValue(int val)
        {
            UpdateMinMax();
            return base.ValidateValue(val);
        }
        void UpdateMinMax()
        {
            m_max = ((SByte)i2cReader.AAI2cEeprom.getByte(128, 3) << 8) + i2cReader.AAI2cEeprom.getByte(129, 3);

            //min temperature
            m_min = ((SByte)i2cReader.AAI2cEeprom.getByte(130, 3) << 8) + i2cReader.AAI2cEeprom.getByte(131, 3);

        }


        /****************************************************************
        * This function is encoding, comparing and define the value according sff-8636
        ***************************************************************/

    }
}
