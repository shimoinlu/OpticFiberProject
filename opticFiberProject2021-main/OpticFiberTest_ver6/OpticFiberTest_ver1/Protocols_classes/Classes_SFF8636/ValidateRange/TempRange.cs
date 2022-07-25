using System;
using Convers = OpticFiberTest_ver1.Converstions;
namespace OpticFiberTest_ver1.Protocols_classes.Classes_SFF8636
{
    class TempRange : BaseRange
    {
        /****************************************************************
        * This function summing all the bytes for part of CC_BASE and CC_EXT
        ***************************************************************/

        public TempRange()
        {
            m_title = "TEMPERATURE RANGE ERR VALIDATION";
            m_size = 8;
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
        public override void EncodeValue(string name)
        {

            string[] bitsAdrr = name.Split(' '); //split the value
            int MinErr, MaxErr, MinWar, MaxWar;                                     //            m_min = Convert.ToInt32(Convers.LsbMsb.MergeLsbMsb(bitsAdrr[0] + " " +bitsAdrr[1]));,
                                                                                    //            m_max = Convert.ToInt32(Convers.LsbMsb.MergeLsbMsb(bitsAdrr[2] + " " +bitsAdrr[3]));
            MaxErr = (int)Convers.HexToFloat.ConvertTwosComplementToInteger(Convers.HexToFloat.HexToFloadConverter(bitsAdrr[0] + bitsAdrr[1]), 2);
            MinErr = (int)Convers.HexToFloat.ConvertTwosComplementToInteger(Convers.HexToFloat.HexToFloadConverter(bitsAdrr[2] + bitsAdrr[3]), 2);
            MaxWar = (int)Convers.HexToFloat.ConvertTwosComplementToInteger(Convers.HexToFloat.HexToFloadConverter(bitsAdrr[4] + bitsAdrr[5]), 2);
            MinWar = (int)Convers.HexToFloat.ConvertTwosComplementToInteger(Convers.HexToFloat.HexToFloadConverter(bitsAdrr[6] + bitsAdrr[7]), 2);
            m_storedValue = "max is: " + Convert.ToString(m_max) + " min is: " + Convert.ToString(m_min) + '\n';
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
