using System.Linq;
using System.Xml;
using System.Xml.Linq;

namespace OpticFiberTest_ver1
{
    partial class OpticFiberTest
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }
        private string[] GetProtocolsFromXml()
        {
            string[] protocols;
            int count = 0;
            XmlDocument document = new XmlDocument();
            var xml = XDocument.Load("files/XMLProtocols.xml");


            // Query the data and write out a subset of contacts
            var query = from c in xml.Root.Descendants("Protocol")
                        select c.Element("ProtocolName").Value;
            int q = query.Count();
            protocols = new string[q];
            foreach (string prtcl in query)
                protocols[count++] = prtcl;
            return protocols;
        }
        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OpticFiberTest));
            this.SFFoptions = new System.Windows.Forms.ComboBox();
            this.clear_btn = new System.Windows.Forms.Button();
            this.start_btn = new System.Windows.Forms.Button();
            this.Connect_btn = new System.Windows.Forms.Button();
            this.details_win = new System.Windows.Forms.RichTextBox();
            this.Demo_btn = new System.Windows.Forms.Button();
            this.Temperature_text_box = new System.Windows.Forms.RichTextBox();
            this.Voltage_text_box = new System.Windows.Forms.RichTextBox();
            this.excel_btn = new System.Windows.Forms.Button();
            this.saving_progress_bar = new System.Windows.Forms.ProgressBar();
            this.logo_pic = new System.Windows.Forms.PictureBox();
            this.XML_btn = new System.Windows.Forms.Button();
            this.DB_btn = new System.Windows.Forms.Button();
            this.temperature_label = new System.Windows.Forms.Label();
            this.voltage_label = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.logo_pic)).BeginInit();
            this.SuspendLayout();
            // 
            // SFFoptions
            // 
            this.SFFoptions.FormattingEnabled = true;
            string[] protocols = GetProtocolsFromXml();
            // this.SFFoptions.Items.AddRange(new object[] {
            // "SFF-8636","shimon"});
            this.SFFoptions.Items.AddRange(GetProtocolsFromXml());
            this.SFFoptions.Location = new System.Drawing.Point(608, 81);
            this.SFFoptions.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.SFFoptions.Name = "SFFoptions";
            this.SFFoptions.Size = new System.Drawing.Size(103, 21);
            this.SFFoptions.TabIndex = 1;
            this.SFFoptions.Text = "Select Protocol";
            this.SFFoptions.Visible = false;
            this.SFFoptions.SelectedIndexChanged += new System.EventHandler(this.SFFoptions_SelectedIndexChanged);
            // 
            // clear_btn
            // 
            this.clear_btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.clear_btn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.clear_btn.Location = new System.Drawing.Point(608, 160);
            this.clear_btn.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.clear_btn.Name = "clear_btn";
            this.clear_btn.Size = new System.Drawing.Size(103, 32);
            this.clear_btn.TabIndex = 2;
            this.clear_btn.Text = "Clear";
            this.clear_btn.UseVisualStyleBackColor = false;
            this.clear_btn.Visible = false;
            this.clear_btn.Click += new System.EventHandler(this.clear_btn_Click);
            // 
            // start_btn
            // 
            this.start_btn.BackColor = System.Drawing.Color.PaleGreen;
            this.start_btn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.start_btn.Location = new System.Drawing.Point(608, 117);
            this.start_btn.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.start_btn.Name = "start_btn";
            this.start_btn.Size = new System.Drawing.Size(103, 32);
            this.start_btn.TabIndex = 4;
            this.start_btn.Text = "Start Check";
            this.start_btn.UseVisualStyleBackColor = false;
            this.start_btn.Visible = false;
            this.start_btn.Click += new System.EventHandler(this.start_btn_Click);
            // 
            // Connect_btn
            // 
            this.Connect_btn.BackColor = System.Drawing.Color.PaleTurquoise;
            this.Connect_btn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Connect_btn.Location = new System.Drawing.Point(255, 24);
            this.Connect_btn.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.Connect_btn.Name = "Connect_btn";
            this.Connect_btn.Size = new System.Drawing.Size(103, 43);
            this.Connect_btn.TabIndex = 5;
            this.Connect_btn.Text = "Connect To Fiber";
            this.Connect_btn.UseVisualStyleBackColor = false;
            this.Connect_btn.Click += new System.EventHandler(this.Connect_btn_Click);
            // 
            // details_win
            // 
            this.details_win.AccessibleDescription = "";
            this.details_win.AccessibleName = "";
            this.details_win.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.details_win.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.details_win.BackColor = System.Drawing.Color.WhiteSmoke;
            this.details_win.BulletIndent = 2;
            this.details_win.Location = new System.Drawing.Point(165, 81);
            this.details_win.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.details_win.Name = "details_win";
            this.details_win.ReadOnly = true;
            this.details_win.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.details_win.Size = new System.Drawing.Size(416, 250);
            this.details_win.TabIndex = 0;
            this.details_win.Text = "";
            this.details_win.TextChanged += new System.EventHandler(this.details_win_TextChanged);
            // 
            // Demo_btn
            // 
            this.Demo_btn.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Demo_btn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Demo_btn.Location = new System.Drawing.Point(389, 24);
            this.Demo_btn.Name = "Demo_btn";
            this.Demo_btn.Size = new System.Drawing.Size(103, 43);
            this.Demo_btn.TabIndex = 6;
            this.Demo_btn.Text = "Demo Mode";
            this.Demo_btn.UseVisualStyleBackColor = false;
            this.Demo_btn.Click += new System.EventHandler(this.ConnectToDemo_btn_Click);
            // 
            // Temperature_text_box
            // 
            this.Temperature_text_box.AccessibleDescription = "";
            this.Temperature_text_box.AccessibleName = "";
            this.Temperature_text_box.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.Temperature_text_box.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Temperature_text_box.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Temperature_text_box.BulletIndent = 2;
            this.Temperature_text_box.Font = new System.Drawing.Font("Microsoft JhengHei", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Temperature_text_box.ForeColor = System.Drawing.Color.Green;
            this.Temperature_text_box.Location = new System.Drawing.Point(18, 160);
            this.Temperature_text_box.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.Temperature_text_box.Name = "Temperature_text_box";
            this.Temperature_text_box.ReadOnly = true;
            this.Temperature_text_box.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.Temperature_text_box.Size = new System.Drawing.Size(123, 25);
            this.Temperature_text_box.TabIndex = 7;
            this.Temperature_text_box.Text = "";
            this.Temperature_text_box.TextChanged += new System.EventHandler(this.richTextBox1_TextChanged);
            // 
            // Voltage_text_box
            // 
            this.Voltage_text_box.AccessibleDescription = "";
            this.Voltage_text_box.AccessibleName = "";
            this.Voltage_text_box.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.Voltage_text_box.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Voltage_text_box.BulletIndent = 2;
            this.Voltage_text_box.ForeColor = System.Drawing.Color.Green;
            this.Voltage_text_box.Location = new System.Drawing.Point(18, 218);
            this.Voltage_text_box.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.Voltage_text_box.Name = "Voltage_text_box";
            this.Voltage_text_box.ReadOnly = true;
            this.Voltage_text_box.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.Voltage_text_box.Size = new System.Drawing.Size(123, 25);
            this.Voltage_text_box.TabIndex = 8;
            this.Voltage_text_box.Text = "";
            this.Voltage_text_box.TextChanged += new System.EventHandler(this.richTextBox2_TextChanged);
            // 
            // excel_btn
            // 
            this.excel_btn.BackColor = System.Drawing.Color.Honeydew;
            this.excel_btn.Location = new System.Drawing.Point(608, 240);
            this.excel_btn.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.excel_btn.Name = "excel_btn";
            this.excel_btn.Size = new System.Drawing.Size(103, 27);
            this.excel_btn.TabIndex = 9;
            this.excel_btn.Text = "Save In Excel";
            this.excel_btn.UseVisualStyleBackColor = false;
            this.excel_btn.UseWaitCursor = true;
            this.excel_btn.Visible = false;
            this.excel_btn.Click += new System.EventHandler(this.excelButton_Click);
            // 
            // saving_progress_bar
            // 
            this.saving_progress_bar.Location = new System.Drawing.Point(625, 217);
            this.saving_progress_bar.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.saving_progress_bar.Name = "saving_progress_bar";
            this.saving_progress_bar.Size = new System.Drawing.Size(70, 19);
            this.saving_progress_bar.TabIndex = 10;
            this.saving_progress_bar.Visible = false;
            this.saving_progress_bar.Click += new System.EventHandler(this.progressBar1_Click_1);
            // 
            // logo_pic
            // 
            this.logo_pic.Image = ((System.Drawing.Image)(resources.GetObject("logo_pic.Image")));
            this.logo_pic.Location = new System.Drawing.Point(291, 356);
            this.logo_pic.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.logo_pic.Name = "logo_pic";
            this.logo_pic.Size = new System.Drawing.Size(160, 58);
            this.logo_pic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.logo_pic.TabIndex = 12;
            this.logo_pic.TabStop = false;
            this.logo_pic.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // XML_btn
            // 
            this.XML_btn.BackColor = System.Drawing.Color.Honeydew;
            this.XML_btn.Location = new System.Drawing.Point(608, 272);
            this.XML_btn.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.XML_btn.Name = "XML_btn";
            this.XML_btn.Size = new System.Drawing.Size(103, 27);
            this.XML_btn.TabIndex = 13;
            this.XML_btn.Text = "Save In XML";
            this.XML_btn.UseVisualStyleBackColor = false;
            this.XML_btn.UseWaitCursor = true;
            this.XML_btn.Visible = false;
            this.XML_btn.Click += new System.EventHandler(this.XML_btn_Click);
            // 
            // DB_btn
            // 
            this.DB_btn.BackColor = System.Drawing.Color.Honeydew;
            this.DB_btn.Location = new System.Drawing.Point(608, 304);
            this.DB_btn.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.DB_btn.Name = "DB_btn";
            this.DB_btn.Size = new System.Drawing.Size(103, 27);
            this.DB_btn.TabIndex = 14;
            this.DB_btn.Text = "Save In DB";
            this.DB_btn.UseVisualStyleBackColor = false;
            this.DB_btn.UseWaitCursor = true;
            this.DB_btn.Visible = false;
            this.DB_btn.Click += new System.EventHandler(this.DB_btn_Click);
            // 
            // temperature_label
            // 
            this.temperature_label.AutoSize = true;
            this.temperature_label.Location = new System.Drawing.Point(15, 146);
            this.temperature_label.Name = "temperature_label";
            this.temperature_label.Size = new System.Drawing.Size(70, 13);
            this.temperature_label.TabIndex = 15;
            this.temperature_label.Text = "Temperature:";
            this.temperature_label.Click += new System.EventHandler(this.label1_Click);
            // 
            // voltage_label
            // 
            this.voltage_label.AutoSize = true;
            this.voltage_label.Location = new System.Drawing.Point(15, 206);
            this.voltage_label.Name = "voltage_label";
            this.voltage_label.Size = new System.Drawing.Size(31, 13);
            this.voltage_label.TabIndex = 16;
            this.voltage_label.Text = "VCC:";
            this.voltage_label.Click += new System.EventHandler(this.voltage_label_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 81);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 13);
            this.label1.TabIndex = 17;
            this.label1.Text = "Connection status:";
            // 
            // richTextBox1
            // 
            this.richTextBox1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.richTextBox1.Location = new System.Drawing.Point(18, 97);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(123, 25);
            this.richTextBox1.TabIndex = 18;
            this.richTextBox1.Text = "";
            // 
            // OpticFiberTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.ClientSize = new System.Drawing.Size(733, 426);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.voltage_label);
            this.Controls.Add(this.temperature_label);
            this.Controls.Add(this.DB_btn);
            this.Controls.Add(this.XML_btn);
            this.Controls.Add(this.logo_pic);
            this.Controls.Add(this.saving_progress_bar);
            this.Controls.Add(this.excel_btn);
            this.Controls.Add(this.Voltage_text_box);
            this.Controls.Add(this.Temperature_text_box);
            this.Controls.Add(this.Demo_btn);
            this.Controls.Add(this.Connect_btn);
            this.Controls.Add(this.start_btn);
            this.Controls.Add(this.clear_btn);
            this.Controls.Add(this.SFFoptions);
            this.Controls.Add(this.details_win);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.MaximizeBox = false;
            this.Name = "OpticFiberTest";
            this.Text = "Optical Fiber Test - version 3.0";
            this.Load += new System.EventHandler(this.OpticFiberTest_Load);
            ((System.ComponentModel.ISupportInitialize)(this.logo_pic)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ComboBox SFFoptions;
        private System.Windows.Forms.Button clear_btn;
        private System.Windows.Forms.Button start_btn;
        private System.Windows.Forms.Button Connect_btn;
        private System.Windows.Forms.RichTextBox details_win;
        private System.Windows.Forms.Button Demo_btn;
        private System.Windows.Forms.RichTextBox Temperature_text_box;
        private System.Windows.Forms.RichTextBox Voltage_text_box;
        private System.Windows.Forms.Button excel_btn;
        private System.Windows.Forms.ProgressBar saving_progress_bar;
        private System.Windows.Forms.PictureBox logo_pic;
        private System.Windows.Forms.Button XML_btn;
        private System.Windows.Forms.Button DB_btn;
        private System.Windows.Forms.Label temperature_label;
        private System.Windows.Forms.Label voltage_label;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox richTextBox1;
    }
}

