using System;
using Convers = OpticFiberTest_ver1.Converstions;
using System.Text;
using System.Threading.Tasks;

namespace OpticFiberTest_ver1.Classes_SFF8636
{
    class Temperature : SFF8636
    {
        public Temperature()
        {
            m_title = "Temperature";
            m_size = 2;
            m_address = 22;

           

            //max temperature
            m_max = ((SByte)i2cReader.AAI2cEeprom.getByte(128, 3) << 8) + i2cReader.AAI2cEeprom.getByte(129, 3);

            //min temperature
            m_min = ((SByte)i2cReader.AAI2cEeprom.getByte(130, 3) << 8) + i2cReader.AAI2cEeprom.getByte(131, 3);

            m_temp = ((SByte)i2cReader.AAI2cEeprom.getByte(23, 0) << 8) + i2cReader.AAI2cEeprom.getByte(22, 0);
        }
        public override void EncodeValue(string name)
        {

            int checker = Convert.ToInt32(Convers.HexToFloat.ConvertTwosComplementToInteger(Convers.HexToFloat.HexToFloadConverter(Convers.LsbMsb.MergeLsbMsb(name)), 2));

            m_storedValue = Convert.ToString(checker) + "C\n";

            if ((m_temp < m_min || m_temp > m_max))
            {
                throw new Exception();
            }
        }

        public int getMin()
        {
            return m_min;
        }

        public int getMax()
        {
            return m_max;
        }

        public int getTemperature()
        {
            return ((SByte)i2cReader.AAI2cEeprom.getByte(23, 0) << 8) + i2cReader.AAI2cEeprom.getByte(22, 0);
        }


        private int m_min=0;
        private int m_max =0;
        private int m_temp = 0;
    }

}
