/****************************************************************
 * ConnectorType class will manage ConnectorType thing again with bits and 
 * dictionary of values
 ***************************************************************/
using System.Collections.Generic;

namespace OpticFiberTest_ver1.Classes_SFF8636
{
    // Connector Type of SFF8636
    class ConnectorType : SFF8636
    {
        public ConnectorType()
        {
            m_title = "Connector Type";
            m_size = 1; // size of byte
            m_address = 130;
            // all the options for the connector type
            values = new Dictionary<string, string>() {
            { "00", "Unknown or unspecified " },
            { "01", "SC(Subscriber Connector)"},
            { "02", "Fibre Channel Style 1 copper connector"},
            { "03", "Fibre Channel Style 2 copper connector"},
            { "04", "BNC/TNC(Bayonet/Threaded Neill-Concelman)"},
            { "05", "Fibre Channel coax headers"},
            { "06", "Fiber Jack"},
            { "07", "LC(Lucent Connector)"},
            { "08", "MT-RJ(Mechanical Transfer - Registered Jack)"},
            { "09", "MU(Multiple Optical)"},
            { "0A", "SG"},
            { "0B", "Optical Pigtail"},
            { "0C", "MPO 1x12(Multifiber Parallel Optic)"},
            { "0D", "MPO 2x16"},
            { "-1F", "Reserved"},
            { "20", "HSSDC II(High Speed Serial Data Connector)"},
            { "21", "Copper pigtail"},
            { "22", "RJ45(Registered Jack)"},
            { "23", "No separable connector"},
            { "24", "MXC 2x16"},
            { "-7F", "Reserved"},
            { "80-FF", "Vendor specific Note"}
        };
        }
        /****************************************************************
        * This function is encoding, comparing and define the value according sff-8636
        ***************************************************************/
        // get the connector type from dic
        public override void EncodeValue(string name) {
            m_storedValue = values[name] + "\n";
        }

       

        private Dictionary<string, string> values;  //the Dictionary of the ConnectorType

    }

}
