using Convers = OpticFiberTest_ver1.Converstions;

namespace OpticFiberTest_ver1.Protocols_classes.Classes_SFF8636
{
    class WavelengthToleranceOrCopperCableAttenuation : SFF8636
    {
        public WavelengthToleranceOrCopperCableAttenuation()
        {
            m_size = 2;
            m_address = 188;
           
        }
        /****************************************************************
        * This function is encoding, comparing and define the value according sff-8636
        ***************************************************************/
        public override void EncodeValue(string name)
        {
            name = name.Replace(" ", string.Empty); //removing space
            float dec = Convers.HexToFloat.HexToFloadConverter(name); //convert to float
            dec /= 200;  //divide by 200 (as defined in SFF8636 document)
            m_WavelengthToleranceOrCooperCableAttenuation = dec; //keep the value
        }
        public float GetWavelength() { return m_WavelengthToleranceOrCooperCableAttenuation; } //return the value
        private float m_WavelengthToleranceOrCooperCableAttenuation; //the value


    }

}
