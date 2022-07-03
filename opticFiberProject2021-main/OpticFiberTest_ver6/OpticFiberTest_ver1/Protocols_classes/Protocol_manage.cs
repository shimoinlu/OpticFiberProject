using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpticFiberTest_ver1.Protocols_classes
{
    interface Protocol_manage
    {
        //this function gets the main dictionary and fill it according to the protocol
        void fillDictionary(ref Dictionary<int, Protocols> MainDictionary);
        
        //This function reads all the data from I2cData class and validate the value.
        //after that, handling it(encoded functions)
        void read(ref Dictionary<int, Protocols> MainDictionary);
    }
}
