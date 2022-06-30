using Convers = OpticFiberTest_ver1.Converstions;

namespace OpticFiberTest_ver1.Protocols_classes.Classes_SFF8636
{
    class Length : SFF8636
    {
        public Length()
        {
            m_size = 1; 
        }
        /****************************************************************
        * This function is encoding, comparing and define the value according sff-8636
        ***************************************************************/
        public override void EncodeValue(string name)
        {
            m_storedValue = Convers.HexToFloat.HexToFloadConverter(name) +"m\n";
        }
    }
   
}
