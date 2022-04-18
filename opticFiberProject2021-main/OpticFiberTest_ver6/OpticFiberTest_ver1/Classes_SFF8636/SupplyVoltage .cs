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
            m_VccRangeValidator = new SupplyVoltageRange();
            m_VccWarRangeValidator = new SupplyVoltageWarRange();
        }
        public override void EncodeValue(string name)
        {
            double checker = Convert.ToDouble(Convers.HexToFloat.HexToFloadConverter(name)) / Voltage.Utilities.Devide;
            m_storedValue = Convert.ToString(checker) + "\n";
            if (!m_VccRangeValidator.ValidateValue((float)checker))
            {
                throw new Exception();
            }
            if (!m_VccWarRangeValidator.ValidateValue((float)checker))
            {
                throw new Exception("Warning");
            }
        }

        public float getMin() { return Convert.ToSingle(m_VccRangeValidator.getMin()); }
        public float getMax() { return Convert.ToSingle(m_VccRangeValidator.getMax()); }

        public int getVolt()
        {
            return (i2cReader.AAI2cEeprom.getByte(26, 0) << 8) + i2cReader.AAI2cEeprom.getByte(27, 0);
        }

        private SupplyVoltageRange m_VccRangeValidator;
        private SupplyVoltageWarRange m_VccWarRangeValidator;
    }

}
