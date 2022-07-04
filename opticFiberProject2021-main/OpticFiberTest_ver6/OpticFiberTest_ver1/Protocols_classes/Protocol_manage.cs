using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OpticFiberTest_ver1.Protocols_classes
{
    public abstract class Protocol_manage
    {
        public string protocol_name;
        public Protocol_manage(string name) { protocol_name = name; }

        //this function gets the main dictionary and fill it according to the protocol
        public abstract void fillDictionary(ref Dictionary<int, Protocols> MainDictionary);
        
        //This function reads all the data from I2cData class and validate the value.
        //after that, handling it(encoded functions)
        public abstract void read(ref Dictionary<int, Protocols> MainDictionary);
        public abstract bool CheckTemp(float temp, RichTextBox tx);
        public abstract float GetRealTemp();
    }
}
