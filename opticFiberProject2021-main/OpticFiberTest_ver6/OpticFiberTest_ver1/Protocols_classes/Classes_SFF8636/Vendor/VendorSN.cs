namespace OpticFiberTest_ver1.Protocols_classes.Classes_SFF8636
{
    /****************************************************************
* This class inherit from vendor and only hold details for it.
***************************************************************/
    class VendorSN : Vendor
    {
        public VendorSN()
        {
            m_title = "Vendor SN";
            m_size = 16;
            m_address = 196;

        }
    }

}
