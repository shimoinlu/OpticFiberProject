using System;
using Convers = OpticFiberTest_ver1.Converstions;

namespace OpticFiberTest_ver1.Classes_SFF8636
{
    class TxPower : SFF8636
    {
        public TxPower(char number, byte address)
        {
            m_title = "Tx" + number + " power";
            m_size = 2;
            m_address = address;
            m_TxPowerErrRangeValidator = new TxPowerRange();
            m_TxPowerWarRangeValidator = new TxPowerWarRange();
        }
        public override void EncodeValue(string name)
        {
            double checker = Convert.ToDouble(Convers.HexToFloat.HexToFloadConverter(Convers.LsbMsb.MergeLsbMsb(name))) / 10000;
            m_storedValue = Convert.ToString(checker) + " mW\n";

            if (!m_TxPowerErrRangeValidator.ValidateValue((float)checker))
            {
                throw new Exception();
            }
            if (!m_TxPowerWarRangeValidator.ValidateValue((float)checker))
            {
                throw new Exception("Warning");
            }
        }
        private TxPowerRange m_TxPowerErrRangeValidator;
        private TxPowerWarRange m_TxPowerWarRangeValidator;

    }

}
