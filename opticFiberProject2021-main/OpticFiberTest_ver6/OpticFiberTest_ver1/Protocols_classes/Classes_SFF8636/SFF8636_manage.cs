using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpticFiberTest_ver1.Protocols_classes.Classes_SFF8636
{
    //this class manages all functions ralated to sff8636 protocol. like filling dictionary, reading etc.
    public class SFF8636_manage: Protocol_manage
    {
        public SFF8636_manage(string name): base(name) { }
        public bool CheckTemp(float temp) { returm true; }
        public abstract float GetRealTemp();

        public override void fillDictionary(ref Dictionary<int, Protocols> MainDictionary)
        {
            MainDictionary.Clear();
            MainDictionary.Add(1, new LowerPageIdentifier());
            MainDictionary.Add(2, new RevisionCompliance());
            MainDictionary.Add(3, new Status());
            MainDictionary.Add(4, new InterruptFlags1(3, i2cReader.AAI2cEeprom.getByte(100, 0)));
            MainDictionary.Add(5, new InterruptFlags1(4, i2cReader.AAI2cEeprom.getByte(101, 0)));
            MainDictionary.Add(6, new InterruptFlags1(5, i2cReader.AAI2cEeprom.getByte(102, 0)));
            MainDictionary.Add(7, new InterruptFlags1(6, i2cReader.AAI2cEeprom.getByte(103, 0)));
            MainDictionary.Add(8, new InterruptFlags1(7, i2cReader.AAI2cEeprom.getByte(104, 0)));
            MainDictionary.Add(9, new InterruptFlags1(8, 0));
            MainDictionary.Add(10, new InterruptFlags1(9, 0));
            MainDictionary.Add(11, new InterruptFlags1(10, 0));
            MainDictionary.Add(12, new InterruptFlags1(11, 0));
            MainDictionary.Add(13, new InterruptFlags1(12, 0));
            MainDictionary.Add(14, new InterruptFlags1(13, 0));
            MainDictionary.Add(15, new InterruptFlags1(14, 0));
            MainDictionary.Add(16, new Temperature());
            MainDictionary.Add(17, new SupplyVoltage());
            MainDictionary.Add(18, new Rx('1', 34));
            MainDictionary.Add(19, new Rx('2', 36));
            MainDictionary.Add(20, new Rx('3', 38));
            MainDictionary.Add(21, new Rx('4', 40));
            MainDictionary.Add(22, new TxBias('1', 42));
            MainDictionary.Add(23, new TxBias('2', 44));
            MainDictionary.Add(24, new TxBias('3', 46));
            MainDictionary.Add(25, new TxBias('4', 48));
            MainDictionary.Add(26, new TxPower('1', 50));
            MainDictionary.Add(27, new TxPower('2', 52));
            MainDictionary.Add(28, new TxPower('3', 54));
            MainDictionary.Add(29, new TxPower('4', 56));
            MainDictionary.Add(30, new Tx1Disable());
            MainDictionary.Add(31, new RxRateSelect());
            MainDictionary.Add(32, new TxRateSelect());
            MainDictionary.Add(33, new Byte93Bits());
            MainDictionary.Add(34, new CDRControl());
            MainDictionary.Add(35, new CtrlInputOutput());
            MainDictionary.Add(36, new PciExpess());
            MainDictionary.Add(37, new Implementation());
            MainDictionary.Add(38, new Identifier());
            MainDictionary.Add(39, new ExtIdentifier());
            MainDictionary.Add(40, new ConnectorType());
            MainDictionary.Add(41, new SpecificationCompliance());
            MainDictionary.Add(42, new EncodingSFF());
            MainDictionary.Add(43, new BitRate());
            MainDictionary.Add(44, new ExtendedRateSelectCompliance());
            MainDictionary.Add(45, new LengthSMF());
            MainDictionary.Add(46, new LengthOM3_50um());
            MainDictionary.Add(47, new LengthOM2_50um());
            MainDictionary.Add(48, new LengthOM1_62d5um());
            MainDictionary.Add(49, new LengthPassiveCopperOrActiveCableOrOM4_50um());
            MainDictionary.Add(50, new DeviceTechnology());
            MainDictionary.Add(51, new VendorName());
            MainDictionary.Add(52, new ExtendedModule());
            MainDictionary.Add(53, new VendorOUI());
            MainDictionary.Add(54, new VendorPN());
            MainDictionary.Add(55, new VendorRev());
            MainDictionary.Add(56, new Wavelength());
            MainDictionary.Add(57, new MaxCaseTemp());
            MainDictionary.Add(58, new CC_BASE());
            MainDictionary.Add(59, new Options());
            MainDictionary.Add(60, new VendorSN());
            MainDictionary.Add(61, new DateCode());
            MainDictionary.Add(62, new DiagnosticMonitoringType());
            MainDictionary.Add(63, new EnhancedOptions());
            MainDictionary.Add(64, new CC_EXT());
            MainDictionary.Add(65, new VendorSpecific());
            MainDictionary.Add(66, new TempRange());
            MainDictionary.Add(67, new TempWarRange());
            MainDictionary.Add(68, new ReservedBytes(136, 8));
            MainDictionary.Add(69, new SupplyVoltageRange());
            MainDictionary.Add(70, new SupplyVoltageWarRange());
            MainDictionary.Add(71, new ReservedBytes(152, 8));
            MainDictionary.Add(72, new RxPowerRange());
            MainDictionary.Add(73, new RxPowerWarRange());
            MainDictionary.Add(74, new TxBiasRange());
            MainDictionary.Add(75, new TxBiasWarRange());
            MainDictionary.Add(76, new TxPowerRange());
            MainDictionary.Add(77, new TxPowerWarRange());
            MainDictionary.Add(78, new MaxTxInputEqualization());
            MainDictionary.Add(79, new MaxRxOutputEmphasis());
            MainDictionary.Add(80, new ReservedBits(225, 6, 7));
            MainDictionary.Add(81, new RxOutputEmphasisType());
            MainDictionary.Add(82, new RxOutputAmplitudeSupport());
            MainDictionary.Add(83, new ReservedBytes(226, 1));
            MainDictionary.Add(84, new ControllableHostSideFEC_Support());
            MainDictionary.Add(85, new ControllableMediaSideFEC_Support());
            MainDictionary.Add(86, new ReservedBits(227, 4, 5));
            MainDictionary.Add(87, new TxForceSquelchImplemented());
            MainDictionary.Add(88, new RxLOSLFastMode());
            MainDictionary.Add(89, new TxDisFastModeSupport());
            MainDictionary.Add(90, new ReservedBits(227, 0, 0));
            MainDictionary.Add(91, new MaximumTCstabilizationTime());
            MainDictionary.Add(92, new ReservedBits(230, 0, 5));
            MainDictionary.Add(93, new ReservedBits(231, 4, 7));
            MainDictionary.Add(94, new ReservedBytes(232, 1));
            MainDictionary.Add(95, new ReservedBits(233, 4, 7));
            MainDictionary.Add(96, new TxInputEqualizerControl(1, 234, 4, 7));
            MainDictionary.Add(97, new TxInputEqualizerControl(2, 234, 0, 3));
            MainDictionary.Add(98, new TxInputEqualizerControl(3, 235, 4, 7));
            MainDictionary.Add(99, new TxInputEqualizerControl(4, 235, 0, 3));
            MainDictionary.Add(100, new RxOutputEmphasisControl(1, 236, 4, 7));
            MainDictionary.Add(101, new RxOutputEmphasisControl(2, 236, 0, 3));
            MainDictionary.Add(102, new RxOutputEmphasisControl(3, 237, 4, 7));
            MainDictionary.Add(103, new RxOutputEmphasisControl(4, 237, 0, 3));
            MainDictionary.Add(104, new RxOutputAmplitudeControl(1, 238, 4, 7));
            MainDictionary.Add(105, new RxOutputAmplitudeControl(2, 238, 0, 3));
            MainDictionary.Add(106, new RxOutputAmplitudeControl(3, 239, 4, 7));
            MainDictionary.Add(107, new RxOutputAmplitudeControl(4, 239, 0, 3));
        }

        public override void read(ref Dictionary<int, Protocols> MainDictionary)
        {
            for (int i = 0; i < MainDictionary.Keys.Count(); i++)
            {
                Protocols current = MainDictionary[i + 1];
                byte address = current.GetAddress();
                short size = current.GetSize();
                int page = current.GetPage();
                if (address > 0)
                {
                    string value = Data.I2cData.Geti2cDataSub(address, size, page);
                    current.ValidateVal(value);
                }
                else
                    MainDictionary[i + 1].ValidateVal("00");
            }
        }
    }
}
