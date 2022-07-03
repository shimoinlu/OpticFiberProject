
using Convers = OpticFiberTest_ver1.Converstions;


namespace OpticFiberTest_ver1.Protocols_classes.Classes_SFF8636
{
    class BaudRate : SFF8636
    {
        public BaudRate()
        {
            m_size = 1;
            m_address = 222;
        }
        /****************************************************************
        * This function is encoding, comparing and define the value according sff-8636
        ***************************************************************/
        public override void EncodeValue(string name)
        {
            dec = Convers.HexToFloat.HexToFloadConverter(name);
            dec *= (float)0.25;
        }
        public float GetDec() { return dec; }
        private float dec;
    }

}
