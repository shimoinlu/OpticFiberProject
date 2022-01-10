using System;
using Convers = OpticFiberTest_ver1.Converstions;
using Valids = OpticFiberTest_ver1.Validations;


namespace OpticFiberTest_ver1.Classes_SFF8636
{
    class Vendor : SFF8636
    {
        /****************************************************************
        * This function is encoding, comparing and define the value according sff-8636
        ***************************************************************/
        public override void EncodeValue(string name)
        {
            m_storedValue = Convers.HexToAsc.Convert2Asc(name) + "\n";
            if (!Valids.ValidString.IsValid(m_storedValue))
                throw new Exception();
        }
    }
}
