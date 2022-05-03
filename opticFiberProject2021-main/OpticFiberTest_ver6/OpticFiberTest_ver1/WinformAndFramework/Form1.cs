using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;


//******************ClassesNamespaceSFF8636**********************//
using OpticFiberTest_ver1.Classes_SFF8636;
//******************EndOfClassesNamespaceSFF8636*****************//

namespace OpticFiberTest_ver1
{
    /******************************Winform class*******************************/
    public partial class OpticFiberTest : Form
    {
        bool is_clear = true,   //is_clear will answer about if the board of text is clear
            is_protocol = false,    //is_protocol will answer about if protocol has been choosen
            is_init = false,        //to build dictionary only once
            is_connected = false;



        public OpticFiberTest()
        {
            InitializeComponent();
        }

        /****************************************************************
        * This function building the dictionary of the 256 bytes
        ***************************************************************/
        Dictionary<int, SFF8636> MainDictionary = new Dictionary<int, SFF8636>();
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
            MainDictionary.Add(68, new SupplyVoltageRange());
            MainDictionary.Add(69, new SupplyVoltageWarRange());
            MainDictionary.Add(70, new RxPowerRange());
            MainDictionary.Add(71, new RxPowerWarRange());
            MainDictionary.Add(72, new TxBiasRange());
            MainDictionary.Add(73, new TxBiasWarRange());
            MainDictionary.Add(74, new TxPowerRange());
            MainDictionary.Add(75, new TxPowerWarRange());
            MainDictionary.Add(76, new MaxTxInputEqualization());
            MainDictionary.Add(77, new MaxRxOutputEmphasis());


        }
        /****************************************************************
        * This function reads all the data from I2cData class and validate
        * the value. after that, handling it (encoded functions)
        ***************************************************************/
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

                    string value = Data.I2cData.Geti2cDataSub(address, size,page);
                    current.ValidateVal(value);

                    //saving data for DB
                    DB.SaveData.addNode(address, value);
                }
                else
                    MainDictionary[i + 1].ValidateVal("00");
            }
            DB.SaveData.save();

        }
        /****************************************************************
         * This function is the event handler of the "details win". it called
         * once the text is change.
         ***************************************************************/
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



        /****************************************************************
         * This function is the event handler of the "SFFoptions". once we choose
         * a protocol this function is called.
         ***************************************************************/
        private void SFFoptions_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (SFFoptions.Text == "SFF-8636")  //if we choose "SFF-8636" 
            {
                is_protocol = true;
            }
            else if (SFFoptions.Text == "Choose protocol")  //if no protocol chosen 
            {
                is_protocol = false;
            }
        }
        /****************************************************************
         * This function is the event handler of the "clear_btn" it called once
         * we click on "Clear"
         ***************************************************************/
        private void clear_btn_Click(object sender, EventArgs e)
        {
          
            excelButton.Visible = false;

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
        /****************************************************************
        * This function is the event handler of the "Connect_btn". it for try to
        * Connect the i2c Connection by read one data. once it connected, the button
        * will be swiched to "Disconnect" Button for disconnection.
        ***************************************************************/
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

                Connect_btn.Text = "Connect";
                DisConnectedFunc();
            }
        }

        /****************************************************************
         * This function is the event handler of the "export_btn" it called once
         * we click on "Export"
         ***************************************************************/
        private void export_btn_Click(object sender, EventArgs e)
        {
            if (!is_clear)  //if the board is not clear that means we can export
            {
                MessageBox.Show("Fiber Check Logs Exported to XML file.");
            }
            else
                MessageBox.Show("No test logs to export.");


        }

        private void OpticFiberTest_Load(object sender, EventArgs e)
        {

        }

        private void ConnectToDemo_btn_Click(object sender, EventArgs e)
        {
            Data.I2cData.connectToDemo();
            ConnectedFunc();

        }

        /****************************************************************
* This function is the event handler of the "start_btn" it called once
* we click on "Start". it checks if the board is clear, if we connected (trying to
* read all the data), if the program is inited and if we choose a protocol.
***************************************************************/
        private void start_btn_Click(object sender, EventArgs e)
        {
            excelButton.Visible = true;
            if (!is_clear)
            {
                MessageBox.Show("To run a new Test, Make sure you clear the board first.\nTo clear the board, just use 'Clear' button.");
                return;
            }
            
            try
            {
                Data.I2cData.ReadTheData();
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
                MessageBox.Show("Please choose Protocol."); //well.. else, we cant proceed.
            }
        }
        private void realTimeData(object sender, EventArgs e)
        {
            richTextBox1_TextChanged(sender, e);
           richTextBox2_TextChanged(sender, e);
        }
        /****************************************************************
        * This function is to show Disconnected values on the winform.
        * It will hide all the test buttons and change the Disconnected 
        * button to connect button
        ***************************************************************/
        private void DisConnectedFunc()
        {
            timer1.Stop();
            is_connected = false;
            MessageBox.Show("Disconnected. Connect to run more tests.");
            Connect_btn.Text = "Connect";
            start_btn.Visible = false;
            excelButton.Visible = false;
            SFFoptions.Visible = false;
            SFFoptions.Text = "Choose protocol";
            richTextBox1.Visible = false;
            richTextBox2.Visible = false;
            is_connected = false;

            Data.I2cData.disConnectToDemo();
            

        }
        /****************************************************************
        * This function is to show Connected values on the winform.
        * It will show buttons for the test and change the connect button
        * to Disconnect button.
        ***************************************************************/
        private void ConnectedFunc()
        {
            is_connected = true;
            //MessageBox.Show("Connected. Choose 'Protocol' and Start the test.");
            Connect_btn.Text = "Disconnect";
            details_win.Visible = true;
            start_btn.Visible = true;
            clear_btn.Visible = true;
            SFFoptions.Visible = true;
            richTextBox1.Visible = true;
            richTextBox2.Visible = true;

        }


        private Timer timer1;

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        public void InitTimer(EventHandler fun)
        {
            timer1 = new Timer();
            timer1.Tick += new EventHandler(fun);
            timer1.Interval = 20000; // in miliseconds
            timer1.Start();

        }
        private void WriteToExcel()
        {

        }

        private void richTextBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }

        private void progressBar1_Click_1(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            float temp = Data.I2cData.getTemp();

            Temperature t = new Temperature();
            richTextBox1.ForeColor = System.Drawing.Color.Green;
            if (temp < t.getMin() || temp > t.getMax())
            {
                richTextBox1.ForeColor = System.Drawing.Color.Red;

            }
            string tempStr = "Temperature: " + Convert.ToString(temp) + " °C";


            richTextBox1.Text = tempStr;

        }

        private void richTextBox2_TextChanged(object sender, EventArgs e)
        {
            float temp = Data.I2cData.getVol();
            SupplyVoltage t = new SupplyVoltage();
            if (temp < t.getMin() || temp > t.getMax())
            {
                richTextBox2.ForeColor = System.Drawing.Color.Red;

            }
            richTextBox2.Text = "VCC: " + Data.I2cData.getVol().ToString() + " V";
        }





        private void excelButton_Click(object sender, EventArgs e)
        {

            FolderBrowserDialog folderBrowserDialog1 = new FolderBrowserDialog();
            DialogResult result = folderBrowserDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                progressBar1.Maximum = 200;
                progressBar1.Visible = true;

                string folderName = folderBrowserDialog1.SelectedPath;

                Excel.Application xlApp;
                Excel.Workbook xlWorkBook;
                Excel.Worksheet xlWorkSheet;
                object misValue = System.Reflection.Missing.Value;
                string file_to_save = "Page_" + "Page" + ".xls";

                xlApp = new Excel.Application();
                xlWorkBook = xlApp.Workbooks.Add(misValue);
                xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);


                xlWorkSheet.Cells[1, 1] = "Byte";
                xlWorkSheet.Cells[1, 2] = "Name";
                xlWorkSheet.Cells[1, 3] = "Data";
                xlWorkSheet.Cells[1, 4] = "Id";
                xlWorkSheet.Cells[1, 5] = "PageId";
                xlWorkSheet.Cells[1, 6] = "testPassed";



                int row = 2;
                progressBar1.Visible = true;
                for (int i = 0; i < MainDictionary.Keys.Count(); i++)
                {
                    int col = 1;
                    progressBar1.Value = i * progressBar1.Maximum / (MainDictionary.Keys.Count() - 1);

                    xlWorkSheet.Cells[row, col++].Value = MainDictionary[i + 1].GetAddress();
                    xlWorkSheet.Cells[row, col++].Value = MainDictionary[i + 1].GetTitle();
                    xlWorkSheet.Cells[row, col++].Value = MainDictionary[i + 1].GethasRead();
                    xlWorkSheet.Cells[row, col++].Value = "sff_8636";
                    xlWorkSheet.Cells[row, col++].Value = "page_0";

                    if (MainDictionary[i + 1].getColor() == "Green")
                    {
                        xlWorkSheet.Cells[row, col].Value = "Passed";
                    }
                    else
                    {
                        xlWorkSheet.Cells[row, col].Value = "Test Failed";
                    }


                    row++;
                }
                progressBar1.Visible = false;
                try
                {
                    xlWorkBook.SaveAs(folderName + "\\" + file_to_save, Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlNoChange, misValue, misValue, misValue, misValue, misValue);
                }
                catch
                {
                    progressBar1.Visible = false;
                    MessageBox.Show("The file is not saved");
                    return;
                }
                xlWorkBook.Close(true, misValue, misValue);
                xlApp.Quit();
                progressBar1.Visible = false;
                MessageBox.Show("Excel file created , you can find the file " + folderName + "\\" + file_to_save);

            }

        }
    }
}