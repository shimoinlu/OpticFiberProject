using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpticFiberTest_ver1.Protocols_classes.Classes_SFF8472
{
    public class SFF8472_manage: Protocol_manage
    {
        public SFF8472_manage(string name) : base(name) { }

        public override int CheckTemp(float temp)
        {
            return 1;
        }

        public override int GetRealTemp()
        {
            return 23;
        }

        public override int CheckVol(float vol)
        {
            return 1;
        }

        public override float GetVol()
        {
            return 5.332f;
        }

        public override void fillDictionary(ref Dictionary<int, Protocols> MainDictionary)
        {

        }

        public override void read(ref Dictionary<int, Protocols> MainDictionary)
        {

        }
    }
}
