using System;
using System.Globalization;
using Convers = OpticFiberTest_ver1.Converstions;
namespace OpticFiberTest_ver1.Classes_SFF8636
{
    class SupplyVoltageRange : BaseRange
    {
        public SupplyVoltageRange()
        {
            m_title = "SUPPLY_VOLTAGE_RANGE\n_ERR_VALIDATION";
            m_size = 8;
            m_address = 144;
            m_page = 3;

            int first = m_address + 2;
            int second = m_address + 1;
            UInt32 tmpMin, tmpMax;
            int t;
            sbyte a = new sbyte(0xff);
            t = a;
            //            tmpMax = (Byte)i2cReader.AAI2cEeprom.getByte(m_address, (byte)m_page) << 8) + i2cReader.AAI2cEeprom.getByte((byte)second, (byte)m_page);
            m_max = m_max * 100 / 1000000;
            second += 2;
            //min temperature
            m_min = ((Byte)i2cReader.AAI2cEeprom.getByte((byte)first, (byte)m_page) << 8) + i2cReader.AAI2cEeprom.getByte((byte)second, (byte)m_page);
            m_min = m_min * 100 / 1000000;

            //m_title = "tamp randge limits";
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
        void UpdateMinMax()
        {

        }
        public override void EncodeValue(string name)
        {

            string[] bitsAdrr = name.Split(' '); //split the value
            float MinErr, MaxErr, MinWar, MaxWar;
            //            m_min = Convert.ToInt32(Convers.LsbMsb.MergeLsbMsb(bitsAdrr[0] + " " +bitsAdrr[1]));,
            //uint x;
            //string newX = "0x00A3B43C";

            //if (uint.TryParse(newX.Substring(2), System.Globalization.NumberStyles.HexNumber, CultureInfo.CurrentCulture, out x))
            //{
            //    Console.WriteLine("x = {0}", x); // 10728508
            //}
            //            m_max = Convert.ToInt32(Convers.LsbMsb.MergeLsbMsb(bitsAdrr[2] + " " +bitsAdrr[3]));

            string a = bitsAdrr[0] + bitsAdrr[1];
            uint b = Convert.ToUInt32(a, 16);
            float c = (b * 100) / 1000000;
            //            return;
            MaxErr = (Convert.ToUInt32(bitsAdrr[0] + bitsAdrr[1], 16) * 100) / 1000000;
            MinErr = (Convert.ToUInt32(bitsAdrr[2] + bitsAdrr[3], 16) * 100) / 1000000;
            MaxWar = (Convert.ToUInt32(bitsAdrr[4] + bitsAdrr[5], 16) * 100) / 1000000;
            MinWar = (Convert.ToUInt32(bitsAdrr[6] + bitsAdrr[7], 16) * 100) / 1000000;
            m_storedValue = "max is: " + Convert.ToString(MaxErr) + " min is: " + Convert.ToString(MinWar) + '\n';
            base.ValidateMinMax((float)MinErr, (float)MaxErr);
            if (MaxWar > MaxErr || MinWar < MinErr)
            {
                m_storedValue += "Warning domain not contained in error domain\n";
                throw new Exception();
            }
            //            string s = e.Message;
            //m_min = Convert.ToInt32(Convers.HexToAsc.Convert2Asc(bitsAdrr[0] + " " +bitsAdrr[1])); //convert to ascii
            //     m_max = Convert.ToInt32(Convers.HexToAsc.Convert2Asc(bitsAdrr[2] + bitsAdrr[3])); //convect to ascii
            //121212121



        }


        /****************************************************************
        * This function is encoding, comparing and define the value according sff-8636
        ***************************************************************/


    }

}
