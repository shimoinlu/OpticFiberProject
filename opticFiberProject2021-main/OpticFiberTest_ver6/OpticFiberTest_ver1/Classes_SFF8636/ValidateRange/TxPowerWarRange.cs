using System;
using Convers = OpticFiberTest_ver1.Converstions;
namespace OpticFiberTest_ver1.Classes_SFF8636
{
    class TxPowerWarRange : BaseRange
    {
        /****************************************************************
        * This function summing all the bytes for part of CC_BASE and CC_EXT
        ***************************************************************/

        public TxPowerWarRange()
        {
            m_title = "Tx POWER RANGE WARNING VALIDATION";
            m_size = 4;
            m_address = 196;
            m_page = 3;

            int first = m_address + 2;
            int second = m_address + 1;

            m_max = i2cReader.AAI2cEeprom.getByte(m_address, 3) << 8;
            m_max += i2cReader.AAI2cEeprom.getByte((byte)second, 3);
            m_max *= 0.0001;
            second += 2;
            //max V
            m_min = i2cReader.AAI2cEeprom.getByte((byte)first, 3) << 8;
            m_min += i2cReader.AAI2cEeprom.getByte((byte)second, 3);
            m_min *= 0.0001;

        }
        override public bool ValidateValue(int val)
        {
            return base.ValidateValue(val);
        }
        public override void EncodeValue(string name)
        {

            string[] bitsAdrr = name.Split(' '); //split the value

            float MinWar, MaxWar;

            MaxWar = Convert.ToSingle(Convert.ToUInt32(bitsAdrr[0] + bitsAdrr[1], 16) * 0.0001);
            MinWar = Convert.ToSingle(Convert.ToUInt32(bitsAdrr[2] + bitsAdrr[3], 16) * 0.0001);

            m_storedValue = "max is: " + Convert.ToString(MaxWar) + " mW min is: " + Convert.ToString(MinWar) + " mW" + '\n';
            base.ValidateMinMax((float)MinWar, (float)MaxWar);
        }

    }
    /****************************************************************
    * This function is encoding, comparing and define the value according sff-8636
    ***************************************************************/

}

