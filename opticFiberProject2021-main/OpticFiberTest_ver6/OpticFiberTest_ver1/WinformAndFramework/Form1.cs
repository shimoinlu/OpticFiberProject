using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Linq;
using OpticFiberTest_ver1.Classes_SFF8636;

namespace OpticFiberTest_ver1
{
    public partial class OpticFiberTest : Form
    {
        bool is_clear = true,   //is_clear will answer about if the board of text is clear
            is_protocol = false,    //is_protocol will answer about if protocol has been choosen
            is_init = false,        //to build dictionary only once
            is_connected = false;

        private Timer timer1;

        Dictionary<int, SFF8636> MainDictionary = new Dictionary<int, SFF8636>(); //hold all the data from fiber

//-----------------------------------functions----------------------------------------------------        
        public OpticFiberTest()
        {
            InitializeComponent();
        }


        //This function building the dictionary of the 256 bytes
        public void fillMainDict()
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
            MainDictionary.Add(83, new ReservedBytes(226,1));
            MainDictionary.Add(84, new ControllableHostSideFEC_Support());
            MainDictionary.Add(85, new ControllableMediaSideFEC_Support());
            MainDictionary.Add(86, new ReservedBits(227, 4,5));
            MainDictionary.Add(87, new TxForceSquelchImplemented());
            MainDictionary.Add(88, new RxLOSLFastMode());
            MainDictionary.Add(89, new TxDisFastModeSupport());
            MainDictionary.Add(90, new ReservedBits(227, 0, 0));
            MainDictionary.Add(91, new MaximumTCstabilizationTime());
            MainDictionary.Add(92, new ReservedBits(230, 0, 5));
            MainDictionary.Add(93, new ReservedBits(231, 4, 7));
            MainDictionary.Add(94, new ReservedBytes(232,1));
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


        //This function reads all the data from I2cData class and validate the value.
        //after that, handling it (encoded functions)
        public void ReadAll()
        {
            for (int i = 0; i < MainDictionary.Keys.Count(); i++)
            {
                SFF8636 current = MainDictionary[i + 1];
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


        //This function is the event handler of the "details win". it called once the text is change.
        private void details_win_TextChanged(object sender, EventArgs e)
        {
            if (!is_clear)  //if the board now is not clear (prevent extra calls)
            {
                foreach (var k in MainDictionary.Values)   //a loop that run over "Mydict" and copy the details to the board
                {
                    details_win.SelectionColor = Color.Green;

                    if (k.getColor() == "Red")
                        details_win.SelectionColor = Color.Red;
                    else if(k.getColor() == "Black")
                        details_win.SelectionColor = Color.Black;
                    //else
                    details_win.AppendText(k.GetAddress() + ": " + k.GetTitle() + "\n\t" + k.GethasRead() + "\n");
                }
            }
            else   //if the board is clear now, it means we cleard it.
                MessageBox.Show("The test has been cleared.");
        }


        //This function is the event handler of the "SFFoptions".
        //once we choose a protocol this function is called.
        private void SFFoptions_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (SFFoptions.Text == "SFF-8636")  //if we choose "SFF-8636" 
            {
                is_protocol = true;
            }
            else if (SFFoptions.Text == "Select protocol")  //if no protocol chosen 
            {
                is_protocol = false;
            }
        }


        //This function is the event handler of the "clear_btn" it called once we click on "Clear"
        private void clear_btn_Click(object sender, EventArgs e)
        {
          
            excel_btn.Visible = false;

            if (is_clear)
            {
                MessageBox.Show("The board is already cleared.");
                return;
            }
            is_clear = true;
            is_init = false;
            details_win.Text = "";  //clearing the board. it will call it's handler so we changed
                                    //the value of "is_clear"
        }


        //This function is the event handler of the "Connect_btn".
        //it for try to Connect the i2c Connection by read one data.
        //once it connected, the button will be swiched to "Disconnect" Button for disconnection.
        private void Connect_btn_Click(object sender, EventArgs e)
        {
            if (!is_connected)
            {
                try
                {
                    Data.I2cData.Connect();
                    Data.I2cData.getVol();
                    is_connected = true;
                    ConnectedFunc();
                    
                }
                catch (Exception x)
                {
                    MessageBox.Show("Could not Connect to fiber \n please check fiber connections and try again");
                }


            }
            else
            {
                Connect_btn.Text = "Connect To Fiber";
                DisConnectedFunc();
            }
        }


        //This function is the event handler of the "export_btn" it called once we click on "Export"
        private void export_btn_Click(object sender, EventArgs e)
        {
            if (!is_clear)  //if the board is not clear that means we can export
            {
                MessageBox.Show("Fiber Check Logs Exported to XML file.");
            }
            else
                MessageBox.Show("No test logs to export.");


        }

        private void ConnectToDemo_btn_Click(object sender, EventArgs e)
        {
            Data.I2cData.connectToDemo();
            ConnectedFunc();

        }


        //This function is the event handler of the "start_btn" it called once we click on "Start",
        //it checks if the board is clear, if we connected (trying to read all the data),
        //if the program is inited and if we choose a protocol.
        private void start_btn_Click(object sender, EventArgs e)
        {
            excel_btn.Visible = true;
            XML_btn.Visible = true;
            DB_btn.Visible = true;

            if (!is_clear)
            {
                MessageBox.Show("To run a new Test, Make sure you clear the board first.\nTo clear the board, just use 'Clear' button.");
                return;
            }
            
            try
            {
                int[] pages = GetProtocolsPagesFromXml();
                Data.I2cData.ReadTheData(pages);
            }
            catch (Exception x)
            {
                MessageBox.Show("The Connection has been failed. Try to reconnect!:\n" + x.ToString());
                DisConnectedFunc();
                return;
            }
            if (!is_init)
            {
                fillMainDict();
                is_init = true;
            }
            if (is_protocol)    //if we chose a protocol we can proceed
            {
                InitTimer(realTimeData);
                richTextBox1_TextChanged(null, null);
                richTextBox2_TextChanged(null, null);

                ReadAll(); //real function
                WriteToExcel();
                is_clear = false;
                details_win_TextChanged(sender, e);
                details_win.Text = "";
            }
            else
            {
                MessageBox.Show("Please select protocol."); //well.. else, we cant proceed.
            }
        }
        private int[] GetProtocolsPagesFromXml()
        {
            int[] protocolsPages;
            int count = 0;
            var xml = XDocument.Load("files/XMLProtocols.xml");


            // Query the data and write out a subset of contacts
            var query = from c in xml.Root.Descendants("Protocol")
                        select c.Element("ProtocolPages").Value;
//            string[] p  = query;
            protocolsPages = new int[query.Count()];
            string[] p;
            foreach (string prtcl in query)
                protocolsPages[count++] = Convert.ToInt32( prtcl);
            return protocolsPages;
        }


        private void realTimeData(object sender, EventArgs e)
        {
            richTextBox1_TextChanged(sender, e);
           richTextBox2_TextChanged(sender, e);
        }


        //This function is to show Disconnected values on the winform.
        //It will hide all the test buttons and change the Disconnected button to connect button
        private void DisConnectedFunc()
        {
            timer1.Stop();
            is_connected = false;
            MessageBox.Show("Disconnected. Connect to run more tests.");
            Connect_btn.Text = "Connect To Fiber";
            start_btn.Visible = false;
            excel_btn.Visible = false;
            SFFoptions.Visible = false;
            SFFoptions.Text = "Select protocol";
            Temperature_text_box.Visible = false;
            Voltage_text_box.Visible = false;
            is_connected = false;

            Data.I2cData.disConnectToDemo();
            

        }


        //This function is to show Connected values on the winform.
        //It will show buttons for the test and change the connect button to Disconnect button.
        private void ConnectedFunc()
        {
            is_connected = true;
            //MessageBox.Show("Connected. Choose 'Protocol' and Start the test.");
            if (Data.I2cData.demoIsConnected()) {
                Demo_btn.Text = "disconnect";}
            else{ 
                Connect_btn.Text = "disconnect"; }
            //details_win.Visible = true;
            start_btn.Visible = true;
            clear_btn.Visible = true;
            SFFoptions.Visible = true;
            Temperature_text_box.Visible = true;
            Voltage_text_box.Visible = true;

        }

        public void InitTimer(EventHandler fun)
        {
            timer1 = new Timer();
            timer1.Tick += new EventHandler(fun);
            timer1.Interval = 20000; // in miliseconds
            timer1.Start();

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            float temp = Data.I2cData.getTemp();

            Temperature t = new Temperature();
            Temperature_text_box.ForeColor = System.Drawing.Color.Green;
            if (temp < t.getMin() || temp > t.getMax())
            {
                Temperature_text_box.ForeColor = System.Drawing.Color.Red;

            }
            string tempStr = Convert.ToString(temp) + " °C";


            Temperature_text_box.Text = tempStr;

        }

        private void richTextBox2_TextChanged(object sender, EventArgs e)
        {
            float temp = Data.I2cData.getVol();
            SupplyVoltage t = new SupplyVoltage();
            if (temp < t.getMin() || temp > t.getMax())
            {
                Voltage_text_box.ForeColor = System.Drawing.Color.Red;

            }
            Voltage_text_box.Text = Data.I2cData.getVol().ToString() + " V";
        }


//-----------------------------save data functions-----------------------------------
        private void excelButton_Click(object sender, EventArgs e)
        {
            string str = SaveData.SaveExcel.createExcel(MainDictionary);//send dictionary of results to save it in XML
            MessageBox.Show(str);
        }

        private void XML_btn_Click(object sender, EventArgs e)
        {
            string str = SaveData.SaveXML.createXML(MainDictionary);//send dictionary of results to save it in XML
            MessageBox.Show(str);
        }

        private void DB_btn_Click(object sender, EventArgs e)
        {
            string str = SaveData.SaveDB.createDB(MainDictionary);//send dictionary of results to save it in DB
            MessageBox.Show(str);
        }

//----------------------------unused functions---------------------------------------------------

        private void OpticFiberTest_Load(object sender, EventArgs e) { }
        private void dateTimePicker1_ValueChanged(object sender, EventArgs e) { }
        private void textBox1_TextChanged(object sender, EventArgs e) { }
        private void WriteToExcel() { }
        private void richTextBox3_TextChanged(object sender, EventArgs e) { }
        private void progressBar1_Click(object sender, EventArgs e) { }
        private void progressBar1_Click_1(object sender, EventArgs e) { }
        private void pictureBox2_Click(object sender, EventArgs e) { }
        private void label1_Click(object sender, EventArgs e) { }
        private void voltage_label_Click(object sender, EventArgs e) { }
    }
}