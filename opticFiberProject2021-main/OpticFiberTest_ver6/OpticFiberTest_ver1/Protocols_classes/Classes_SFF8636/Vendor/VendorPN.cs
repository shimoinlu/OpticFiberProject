namespace OpticFiberTest_ver1.Protocols_classes.Classes_SFF8636
{
    /****************************************************************
* This class inherit from vendor and only hold details for it.
***************************************************************/
    class VendorPN : Vendor
    {
        public VendorPN()
        {
            m_title = "Vendor PN";
            m_size = 16;
            m_address = 168;

        }
    }

}
