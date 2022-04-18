using System;
using Convers = OpticFiberTest_ver1.Converstions;

namespace OpticFiberTest_ver1.Classes_SFF8636
{
    class Rx : SFF8636 // check the rx bit on SFF8636
    {
        public Rx(char number, byte address)
        {
            m_title = "Rx" + number + " power"; // Title of rx
            m_size = 2; // Rx Size
            m_address = address;// Rx Address
            m_RxPowerRangeValidator = new RxPowerRange();
        }
        // Store the value of rx to print it later on the screen
        public override void EncodeValue(string name) 
        {
            // convert string to msb and lsb then convert it to double to check if the value is valid
            double checker = Convert.ToDouble(Convers.HexToFloat.HexToFloadConverter(Convers.LsbMsb.MergeLsbMsb(name))) / 10000;
            m_storedValue = Convert.ToString(checker) + " mW\n";

            // check if the rx value is valid
            if (!m_RxPowerRangeValidator.ValidateValue((float)checker))
            {
                throw new Exception();
            }
        }
        private RxPowerRange m_RxPowerRangeValidator;
    }
    

}
