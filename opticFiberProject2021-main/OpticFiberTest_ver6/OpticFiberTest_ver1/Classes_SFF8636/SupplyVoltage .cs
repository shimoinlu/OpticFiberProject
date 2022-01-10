using System;
using Convers = OpticFiberTest_ver1.Converstions;
using Voltage = OpticFiberTest_ver1.Utility;

namespace OpticFiberTest_ver1.Classes_SFF8636
{
    class SupplyVoltage : SFF8636
    {
        public SupplyVoltage()
        {
            m_title = "Supply Voltage";
            m_size = 2;
            m_address = 26;

            //min V
            m_max = (i2cReader.AAI2cEeprom.getByte(132, 3) << 8) + i2cReader.AAI2cEeprom.getByte(133, 3);
            //max V
            m_min = (i2cReader.AAI2cEeprom.getByte(134, 3) << 8) + i2cReader.AAI2cEeprom.getByte(135, 3);


        }
        public override void EncodeValue(string name)
        {
            double checker = Convert.ToDouble(Convers.HexToFloat.HexToFloadConverter(name)) / Voltage.Utilities.Devide;
            m_storedValue = Convert.ToString(checker) + "\n";

            if ((checker < m_min || checker > m_max))
            {
                throw new Exception();
            }
        }

        public float getMin() { return m_min; }
        public float getMax() { return m_max; }

        public int getVolt()
        {
            return (i2cReader.AAI2cEeprom.getByte(26, 0) << 8) + i2cReader.AAI2cEeprom.getByte(27, 0);
        }

        private float m_min = 0;
        private float m_max = 0;
    }

}
