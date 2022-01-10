namespace OpticFiberTest_ver1.Classes_SFF8636
{
    /****************************************************************
* This class inherit from vendor and only hold details for it.
***************************************************************/
    class VendorOUI : Vendor
    {
        public VendorOUI()
        {
            m_title = "Vendor OUI";
            m_size = 3;
            m_address = 165;

        }
        public override void EncodeValue(string name)
        {
            m_storedValue = name + "\n";
        }

    }

}
