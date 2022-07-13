using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using OpticFiberTest_ver1.Protocols_classes;
using OpticFiberTest_ver1.Protocols_classes.Classes_SFF8636;
using OpticFiberTest_ver1.Protocols_classes.Classes_SFF8472;
using System.Xml.Linq;
using OpticFiberTest_ver1.Utility;

namespace OpticFiberTest_ver1
{
    public partial class OpticFiberTest : Form
    {
        bool is_clear = true,       //is_clear will answer about if the board of text is clear
            is_protocol = false,    //is_protocol will answer about if protocol has been choosen
            is_init = false,        //to build dictionary only once
            //connected_demo = false,
            //connected_real = true;
            is_connected = false;

        private Timer timer1;
        //string[] protocols = {"SFF-8636", "SFF-8472"};
        //string current_protocol = "";
        Protocol_manage current_protocol;
        static Dictionary<int, Protocols> MainDictionary = new Dictionary<int, Protocols>(); //hold all the data from fiber
        Utilities util = new Utilities();

        //=================================== functions ===============================================        
        public OpticFiberTest() { InitializeComponent(); }
//----------------------------------------------------------------------------------------------

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
                    else if (k.getColor() == "Black")
                        details_win.SelectionColor = Color.Black;
                    //else
                    details_win.AppendText(k.GetAddress() + ": " + k.GetTitle() + "\n\t" + k.GethasRead() + "\n");
                }
            }
            else        //if the board is clear now, it means we cleard it.
            {
                //MessageBox.Show("The test has been cleared.");
                details_win.Text = "";
            }
        }
//----------------------------------------------------------------------------------------------
        //This function is the event handler of the "SFFoptions".
        //once we choose a protocol this function is called.
        private void SFFoptions_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(SFFoptions.Text == util.sff8636)
            {
                current_protocol = new SFF8636_manage(util.sff8636);
                is_protocol = true;
            }
            else if (SFFoptions.Text == util.sff8472)
            {
                current_protocol = new SFF8472_manage(util.sff8472);
                is_protocol = true;
            }
            else if (SFFoptions.Text == "")  //if no protocol chosen 
            {
                is_protocol = false;
            }
        }
//----------------------------------------------------------------------------------------------
        //This function is the event handler of the "clear_btn" it called once we click on "Clear"
        private void clear_btn_Click(object sender, EventArgs e)
        {
            clear(); //clear data and board
        }
//----------------------------------------------------------------------------------------------
        //This function is the event handler of the "Connect_btn".
        //it for try to Connect the i2c Connection by read one data.
        //once it connected, the button will be swiched to "Disconnect" Button for disconnection.
        private void Connect_btn_Click(object sender, EventArgs e)
        {
            if (!is_connected)  //connect to real fiber if nothing is connected
            {
                try
                {
                    Data.I2cData.Connect();
                    ConnectedFunc();
                    Connect_btn.Text = util.disconnect_from_fiber;
                }
                catch (Exception x)
                {
                    MessageBox.Show("Could not Connect to fiber \n please check fiber connections and try again");
                }
            }

            else if(!Data.I2cData.demoIsConnected())    //if real fiber connected allready, disconnect it
            {
                DisConnectedFunc();
                Connect_btn.Text = util.connect_to_fiber;
            }

            else    //means the dempo is connected, warn user
            {
                MessageBox.Show("demo mode is connected, please disconnect it first");
            }
        }
//----------------------------------------------------------------------------------------------
        private void ConnectToDemo_btn_Click(object sender, EventArgs e)
        {
            if (!is_connected)  //if is not connected, connect to demo 
            {
                Data.I2cData.connectToDemo();
                ConnectedFunc();
                Demo_btn.Text = util.disconnect_from_demo;
            }

            else if(Data.I2cData.demoIsConnected())  //if connected to demo. disconnect
            {
                Data.I2cData.disConnectToDemo();
                DisConnectedFunc();
                Demo_btn.Text = util.connect_to_demo;
            }

            else    //means it connected to real fiber, warn the user
            {
                MessageBox.Show("fiber is connected, please disconnect it first");
            }
        }
//----------------------------------------------------------------------------------------------
        //This function is the event handler of the "start_btn" it called once we click on "Start",
        //it checks if the board is clear, if we connected (trying to read all the data),
        //if the program is inited and if we choose a protocol.
        private void start_btn_Click(object sender, EventArgs e)
        {
            if (!is_clear)
            {
                MessageBox.Show("To run a new Test, Make sure you clear the board first.\nTo clear the board, just use 'Clear' button.");
                return;
            }

            if (!is_protocol)    //if we chose a protocol we can proceed
            {
                MessageBox.Show("Please select protocol."); //well.. else, we cant proceed.
                return;
            }

            connection_status.Text = "running test";
            connection_status.ForeColor = Color.Red;
            excel_btn.Visible = true;
            XML_btn.Visible = true;
            DB_btn.Visible = true;

            try
            {
                int[] pages = GetProtocolsPagesFromXml();   //read from xml which pages to read
                Data.I2cData.ReadTheData(pages);    //read those pages
            }
            catch (Exception x)
            {
                MessageBox.Show("The Connection has been failed. Try to reconnect!:\n" + x.ToString());
                DisConnectedFunc();
                return;
            }

            if (!is_init)
            {
                current_protocol.fillDictionary(ref MainDictionary);
                is_init = true;
            }

            current_protocol.read(ref MainDictionary);
            is_clear = false;
            details_win_TextChanged(sender, e);
            details_win.Text = "";
            InitTimer(realTimeData);
            richTextBox1_TextChanged(null, null);
            richTextBox2_TextChanged(null, null);
            connection_status.Text = "test done";
            connection_status.ForeColor = Color.Green;
        }
//----------------------------------------------------------------------------------------------
        private int[] GetProtocolsPagesFromXml()
        {
            int[] protocolsPages = {};
            var xml = XDocument.Load("files/XMLProtocols.xml");

            var values = xml.Descendants("Protocol");
            foreach (var item in values)
            {
                //var pname = item.Element("ProtocolName")
                if (item.Element("ProtocolName").Value == current_protocol.protocol_name)
                {
                    var pages = item.Element("ProtocolPages").Value;
                    protocolsPages = pages.Split(' ').Select(Int32.Parse).ToArray();
                }
            }
            return protocolsPages;
        }
//----------------------------------------------------------------------------------------------
        private void realTimeData(object sender, EventArgs e)
        {
            richTextBox1_TextChanged(sender, e);
            richTextBox2_TextChanged(sender, e);
        }
//----------------------------------------------------------------------------------------------
        //This function is to show Disconnected values on the winform.
        //It will hide all the test buttons and change the Disconnected button to connect button
        private void DisConnectedFunc()
        {
            clear();    //first clear the board and data
            SFFoptions.Text = "Select Protocol";
            is_protocol = false;
            is_connected = false;
            start_btn.Visible = false;
            clear_btn.Visible = false;
            SFFoptions.Visible = false;
            connection_status.Text = "not connected";
            connection_status.ForeColor = Color.Black;
        }
//----------------------------------------------------------------------------------------------
        //This function clears current test and the data
        //will be called when clear button pressed or disconnection
        private void clear()
        {
            if (is_clear)
            {
                MessageBox.Show("The board is already cleared.");
                return;
            }
            if (timer1 != null)
            {
                timer1.Stop();
            }

            is_clear = true;
            is_init = false;
            excel_btn.Visible = false;
            XML_btn.Visible = false;
            DB_btn.Visible = false;
            Temperature_text_box.Text = "";
            Voltage_text_box.Text = "";
            connection_status.Text = "connected";
            connection_status.ForeColor = Color.Green;
            MainDictionary.Clear();
            details_win.Text = "";  //clearing the board. it will call it's handler so we changed the value of "is_clear"
            MessageBox.Show("The board has been cleared.");
        }
//----------------------------------------------------------------------------------------------
        //This function is to show Connected values on the winform.
        //It will show buttons for the test and change the connect button to Disconnect button.
        private void ConnectedFunc()
        {
            is_connected = true;
            start_btn.Visible = true;
            clear_btn.Visible = true;
            SFFoptions.Visible = true;
            Temperature_text_box.Visible = true;
            Voltage_text_box.Visible = true;
            connection_status.Text = "connected";
            connection_status.ForeColor = Color.Green;
        }
//----------------------------------------------------------------------------------------------
        public void InitTimer(EventHandler fun)
        {
            timer1 = new Timer();
            timer1.Tick += new EventHandler(fun);
            timer1.Interval = 20000; // in miliseconds
            timer1.Start();
        }
//----------------------------------------------------------------------------------------------
        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            if (is_init)
            {
                float temp = current_protocol.GetRealTemp();
                int status = current_protocol.CheckTemp(temp); // -1 means fail, 0 means warrning, 1 means success

                if (status == -1)
                {
                    Temperature_text_box.ForeColor = System.Drawing.Color.Red;
                }
                else if (status == 0)
                {
                    Temperature_text_box.ForeColor = System.Drawing.Color.Black;
                }
                else if (status == 1)
                {
                    Temperature_text_box.ForeColor = System.Drawing.Color.Green;
                }
                string tempStr = Convert.ToString(temp) + " °C";
                Temperature_text_box.Text = tempStr;
            }
            else
            {
                Temperature_text_box.Text = "";
            }

        }
//----------------------------------------------------------------------------------------------
        private void richTextBox2_TextChanged(object sender, EventArgs e)
        {
            if (is_init)
            {
                float vol = current_protocol.GetVol();
                int status = current_protocol.CheckTemp(vol); // -1 means fail, 0 means warrning, 1 means success

                if (status == -1)
                {
                    Voltage_text_box.ForeColor = System.Drawing.Color.Red;
                }
                else if (status == 0)
                {
                    Voltage_text_box.ForeColor = System.Drawing.Color.Black;
                }
                else if (status == 1)
                {
                    Voltage_text_box.ForeColor = System.Drawing.Color.Green;
                }
                Voltage_text_box.Text = vol.ToString() + " V";
            }
            else
            {
                Voltage_text_box.Text = "";
            }
        }
//----------------------------------------------------------------------------------------------
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
// ===================================== save data functions =========================================
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

//========================= unused functions ==========================================

        private void OpticFiberTest_Load(object sender, EventArgs e) { }
        private void dateTimePicker1_ValueChanged(object sender, EventArgs e) { }
        private void textBox1_TextChanged(object sender, EventArgs e) { }
        private void richTextBox3_TextChanged(object sender, EventArgs e) { }
        private void progressBar1_Click(object sender, EventArgs e) { }
        private void progressBar1_Click_1(object sender, EventArgs e) { }
        private void pictureBox2_Click(object sender, EventArgs e) { }
        private void label1_Click(object sender, EventArgs e) { }
        private void voltage_label_Click(object sender, EventArgs e) { }
    }
}