using System;

namespace OpticFiberTest_ver1.Classes_SFF8636
{
    class Wavelength : SFF8636
    {
        public Wavelength()
        {
            m_title = "Wavelength";
        }
        /****************************************************************
        * This function is encoding, comparing and define the value according sff-8636
        ***************************************************************/
        public override void EncodeValue(string name)
        {
            
            WavelengthOrCopperCableAttenuation w1 = new WavelengthOrCopperCableAttenuation();
            WavelengthToleranceOrCopperCableAttenuation w2 = new WavelengthToleranceOrCopperCableAttenuation();

            w1.EncodeValue(Data.I2cData.Geti2cDataSub(w1.GetAddress() - 128, w1.GetSize())); //reading from 186
            w2.EncodeValue(Data.I2cData.Geti2cDataSub(w2.GetAddress() - 128, w2.GetSize())); //reading from 188


            float result = w1.GetWavelength() / w2.GetWavelength(); //divide the first with the second
            m_storedValue = Convert.ToString(result) + "nm\n"; //saving the result

        }
    }

}
