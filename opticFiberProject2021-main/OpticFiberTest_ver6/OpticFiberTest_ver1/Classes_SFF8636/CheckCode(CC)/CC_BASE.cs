namespace OpticFiberTest_ver1.Classes_SFF8636
{
    /****************************************************************
    * only hold details. inherit from CC class and handling there.
    ***************************************************************/
    class CC_BASE : CC
    {
        public CC_BASE()
        {
            m_title = "CC_BASE";
            m_size = 1;
            m_address = 191;
            startIndex = 128; 
        }
    }
}
