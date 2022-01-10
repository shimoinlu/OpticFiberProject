using System;
using System.Numerics;
namespace OpticFiberTest_ver1.Classes_SFF8636
{
    abstract class CC : SFF8636
    {
        /****************************************************************
        * This function summing all the bytes for part of CC_BASE and CC_EXT
        ***************************************************************/
        protected void SumAllBits()
        {
            ReadValue = Data.I2cData.HexaCounterOfHexString(startIndex, m_address - startIndex );
            low8bits = ReadValue & 0xFF;
        }
        /****************************************************************
        * This function is encoding, comparing and define the value according sff-8636
        ***************************************************************/
        public override void EncodeValue(string name)
        {
            SumAllBits();
            if (low8bits == Convert.ToInt32(name, 16))
                //CC_BASE (Check Code) on bytes 128-190 Positive.
                m_storedValue = "CC: " + low8bits + " = " + ReadValue + " XOR " + "0xFF = " + name + " GOOD\n";
            else
            {
                //CC_BASE (Check Code) on bytes 128-190 Negative.
                m_storedValue = "CC: " + low8bits + " = " + ReadValue + " XOR " + "0xFF, NOT EQUAL TO: " + name + " BAD\n";
                throw new Exception();
            }
        }

        private BigInteger low8bits; //hold low 8 bits of the sum of all bytes we counted
        protected int startIndex; //the index we start to take the sub string of the string of all the data
        private BigInteger ReadValue;
    }
}
