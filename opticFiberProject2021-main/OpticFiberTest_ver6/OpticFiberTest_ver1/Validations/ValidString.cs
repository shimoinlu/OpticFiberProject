using System.Text.RegularExpressions;
using System.Linq;

namespace OpticFiberTest_ver1.Validations
{
    /****************************************************************
    * This class is Validate a string
    ***************************************************************/
    public abstract class ValidString
    {
        static public bool IsValid(string name)
        {
            bool validStr = name.All(c => char.IsWhiteSpace(c) || char.IsLetter(c) || char.IsNumber(c));
            if (validStr)
                return true;
            return false;
        }
    }
}
