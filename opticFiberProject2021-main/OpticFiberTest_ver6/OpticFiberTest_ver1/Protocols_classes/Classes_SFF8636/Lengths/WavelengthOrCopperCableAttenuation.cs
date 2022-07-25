using Convers = OpticFiberTest_ver1.Converstions;

namespace OpticFiberTest_ver1.Protocols_classes.Classes_SFF8636
{
    class WavelengthOrCopperCableAttenuation : SFF8636
    {
        public WavelengthOrCopperCableAttenuation()
        {
            m_size = 2;
            m_address = 186;
        }
        /****************************************************************
        * This function is encoding, comparing and define the value according sff-8636
        ***************************************************************/
        public override void EncodeValue(string name)
        {
            name = name.Replace(" ", string.Empty); //removing spaces
            float dec = Convers.HexToFloat.HexToFloadConverter(name); //converting hex to float
            m_WaveLengthOrCooperCableAttenuation = dec; //keep the value
        }
        public float GetWavelength() { return m_WaveLengthOrCooperCableAttenuation; } //returning the value
        private float m_WaveLengthOrCooperCableAttenuation; //the value

    }
}
