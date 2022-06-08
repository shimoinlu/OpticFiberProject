using System;
using System.Globalization;
using Convers = OpticFiberTest_ver1.Converstions;
namespace OpticFiberTest_ver1.Classes_SFF8636
{
    class SupplyVoltageRange : BaseRange
    {
        public SupplyVoltageRange()
        {
            m_title = "SUPPLY VOLTAGE RANGE ERR VALIDATION";
            m_size = 8;
            m_address = 144;
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
        override public bool ValidateValue(float val)
        {
            UpdateMinMax();
            return base.ValidateValue(val);

        }
        override public bool ValidateValue(int val)
        {
            UpdateMinMax();
            return base.ValidateValue(val);
        }
        void UpdateMinMax() {}
        public override void EncodeValue(string name)
        {
            string[] bitsAdrr = name.Split(' '); //split the value

            float MinErr, MaxErr, MinWar, MaxWar;

            MaxErr = Convert.ToSingle(Convert.ToUInt32(bitsAdrr[0] + bitsAdrr[1], 16) *0.0001) ;
            MinErr = Convert.ToSingle(Convert.ToUInt32(bitsAdrr[2] + bitsAdrr[3], 16) *0.0001) ;
            MaxWar = Convert.ToSingle(Convert.ToUInt32(bitsAdrr[4] + bitsAdrr[5], 16) *0.0001) ;
            MinWar = Convert.ToSingle(Convert.ToUInt32(bitsAdrr[6] + bitsAdrr[7], 16) *0.0001) ;
    
            m_storedValue = "max is: " + Convert.ToString(MaxErr) + " V min is: " + Convert.ToString(MinErr) + " V" + '\n';
            base.ValidateMinMax((float)MinErr, (float)MaxErr);
            if (MaxWar > MaxErr || MinWar < MinErr)
            {
                m_storedValue += "Warning domain not contained in error domain\n";
                throw new Exception();
            }
        }
        /****************************************************************
        * This function is encoding, comparing and define the value according sff-8636
        ***************************************************************/
    }

}
