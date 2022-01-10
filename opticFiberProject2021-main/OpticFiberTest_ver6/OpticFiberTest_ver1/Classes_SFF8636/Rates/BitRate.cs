using System;


namespace OpticFiberTest_ver1.Classes_SFF8636
{
    class BitRate : SFF8636
    {
        public BitRate()
        {
            m_title = "Bit Rate";
            m_size = 2;
            m_address = 140;
        }
        /****************************************************************
        * This function is encoding, comparing and define the value according sff-8636
        ***************************************************************/
        public override void EncodeValue(string name)
        {
            SingalingRate sinRate = new SingalingRate(); //we will take singalingrate value
            sinRate.EncodeValue(Data.I2cData.Geti2cDataSub(sinRate.GetAddress()-128, sinRate.GetSize()-128));
            float dec = sinRate.GetDec();
            if (dec < 25.4)
            {
                m_storedValue = (dec.ToString() + "GBd");
            }
            else
            {
                BaudRate brate = new BaudRate(); //in case dec >= 25.4 we go to baudrate according the document
                brate.EncodeValue(Data.I2cData.Geti2cDataSub(brate.GetAddress()-128, brate.GetSize()-128));
                dec = brate.GetDec();

            }
            m_storedValue = Convert.ToString(dec) + "GBd\n";
        }

    }

}
