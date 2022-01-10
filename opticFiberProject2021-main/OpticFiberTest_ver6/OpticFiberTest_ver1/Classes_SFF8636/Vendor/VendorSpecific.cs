namespace OpticFiberTest_ver1.Classes_SFF8636
{
    /****************************************************************
* This class inherit from vendor and only hold details for it.
***************************************************************/
    class VendorSpecific : Vendor
    {
        public VendorSpecific()
        {
            m_title = "Vendor Specific";
            m_size = 32;
            m_address = 224;
        }
    }

}
