using System;
using Convers = OpticFiberTest_ver1.Converstions;


namespace OpticFiberTest_ver1.Protocols_classes.Classes_SFF8636
{
    class MaxCaseTemp : SFF8636
    {
        public MaxCaseTemp()
        {
            m_title = "Max case temp.";
            m_size = 1;
            m_address = 190;
            
        }
        /****************************************************************
* This function is encoding, comparing and define the value according sff-8636
***************************************************************/
        public override void EncodeValue(string name)
        {
            m_storedValue = Convert.ToString(Convert.ToInt32(Convers.HexToFloat.HexToFloadConverter(name)) + 70) +"C\n";
        }



}

}
