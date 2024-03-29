﻿using System;
using Convers = OpticFiberTest_ver1.Converstions;

namespace OpticFiberTest_ver1.Protocols_classes.Classes_SFF8636
{
    class TxBias : SFF8636 // Tx Bias on SFF8636
    {
        public TxBias(char number, byte address)
        {
            
            m_title = "Tx" + number + " bias";
            m_size = 2; // The size of Tx bias
            m_address = address; // Thes addrss of Tx bias
            m_TxBiasRange = new TxBiasRange();
            m_TxBiasWarRange = new TxBiasWarRange();
        }
        public override void EncodeValue(string name)
        {
            double checker = Convert.ToDouble(Convers.HexToFloat.HexToFloadConverter(Convers.LsbMsb.MergeLsbMsb(name))) / 500;
            m_storedValue = Convert.ToString(checker) + " mA\n";

            if (!m_TxBiasRange.ValidateValue((float)checker))
            {
                throw new Exception();
            }
            if (!m_TxBiasWarRange.ValidateValue((float)checker))
            {
                throw new Exception("Warning");
            }
        }
        private TxBiasRange m_TxBiasRange;
        private TxBiasWarRange m_TxBiasWarRange;
    }

}
