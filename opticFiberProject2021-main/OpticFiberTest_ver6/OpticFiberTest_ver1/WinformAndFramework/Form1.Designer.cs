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
            this.ConnectToDemo_btn = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.richTextBox2 = new System.Windows.Forms.RichTextBox();
            this.excelButton = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // SFFoptions
            // 
            this.SFFoptions.FormattingEnabled = true;
            this.SFFoptions.Items.AddRange(new object[] {
            "SFF-8636"});
            this.SFFoptions.Location = new System.Drawing.Point(382, 428);
            this.SFFoptions.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.SFFoptions.Name = "SFFoptions";
            this.SFFoptions.Size = new System.Drawing.Size(152, 28);
            this.SFFoptions.TabIndex = 1;
            this.SFFoptions.Text = "Choose Protocol";
            this.SFFoptions.Visible = false;
            this.SFFoptions.SelectedIndexChanged += new System.EventHandler(this.SFFoptions_SelectedIndexChanged);
            // 
            // clear_btn
            // 
            this.clear_btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.clear_btn.Location = new System.Drawing.Point(156, 491);
            this.clear_btn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.clear_btn.Name = "clear_btn";
            this.clear_btn.Size = new System.Drawing.Size(84, 29);
            this.clear_btn.TabIndex = 2;
            this.clear_btn.Text = "Clear";
            this.clear_btn.UseVisualStyleBackColor = false;
            this.clear_btn.Visible = false;
            this.clear_btn.Click += new System.EventHandler(this.clear_btn_Click);
            // 
            // start_btn
            // 
            this.start_btn.BackColor = System.Drawing.Color.Lime;
            this.start_btn.Location = new System.Drawing.Point(611, 502);
            this.start_btn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.start_btn.Name = "start_btn";
            this.start_btn.Size = new System.Drawing.Size(84, 29);
            this.start_btn.TabIndex = 4;
            this.start_btn.Text = "Start";
            this.start_btn.UseVisualStyleBackColor = false;
            this.start_btn.Visible = false;
            this.start_btn.Click += new System.EventHandler(this.start_btn_Click);
            // 
            // Connect_btn
            // 
            this.Connect_btn.BackColor = System.Drawing.Color.LightSeaGreen;
            this.Connect_btn.Location = new System.Drawing.Point(789, 34);
            this.Connect_btn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Connect_btn.Name = "Connect_btn";
            this.Connect_btn.Size = new System.Drawing.Size(105, 42);
            this.Connect_btn.TabIndex = 5;
            this.Connect_btn.Text = "Connect";
            this.Connect_btn.UseVisualStyleBackColor = false;
            this.Connect_btn.Click += new System.EventHandler(this.Connect_btn_Click);
            // 
            // details_win
            // 
            this.details_win.AccessibleDescription = "";
            this.details_win.AccessibleName = "";
            this.details_win.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.details_win.BackColor = System.Drawing.Color.WhiteSmoke;
            this.details_win.BulletIndent = 2;
            this.details_win.Location = new System.Drawing.Point(136, 34);
            this.details_win.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.details_win.Name = "details_win";
            this.details_win.ReadOnly = true;
            this.details_win.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.details_win.Size = new System.Drawing.Size(624, 359);
            this.details_win.TabIndex = 0;
            this.details_win.Text = "";
            this.details_win.TextChanged += new System.EventHandler(this.details_win_TextChanged);
            // 
            // ConnectToDemo_btn
            // 
            this.ConnectToDemo_btn.BackColor = System.Drawing.Color.LawnGreen;
            this.ConnectToDemo_btn.Location = new System.Drawing.Point(789, 112);
            this.ConnectToDemo_btn.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ConnectToDemo_btn.Name = "ConnectToDemo_btn";
            this.ConnectToDemo_btn.Size = new System.Drawing.Size(204, 35);
            this.ConnectToDemo_btn.TabIndex = 6;
            this.ConnectToDemo_btn.Text = "Connect To Demo";
            this.ConnectToDemo_btn.UseVisualStyleBackColor = false;
            this.ConnectToDemo_btn.Click += new System.EventHandler(this.ConnectToDemo_btn_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.AccessibleDescription = "";
            this.richTextBox1.AccessibleName = "";
            this.richTextBox1.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.richTextBox1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.richTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.richTextBox1.BulletIndent = 2;
            this.richTextBox1.Font = new System.Drawing.Font("Microsoft JhengHei", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBox1.ForeColor = System.Drawing.Color.Green;
            this.richTextBox1.Location = new System.Drawing.Point(780, 225);
            this.richTextBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.richTextBox1.Size = new System.Drawing.Size(193, 36);
            this.richTextBox1.TabIndex = 7;
            this.richTextBox1.Text = "";
            this.richTextBox1.Visible = false;
            this.richTextBox1.TextChanged += new System.EventHandler(this.richTextBox1_TextChanged);
            // 
            // richTextBox2
            // 
            this.richTextBox2.AccessibleDescription = "";
            this.richTextBox2.AccessibleName = "";
            this.richTextBox2.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.richTextBox2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.richTextBox2.BulletIndent = 2;
            this.richTextBox2.ForeColor = System.Drawing.Color.Green;
            this.richTextBox2.Location = new System.Drawing.Point(780, 308);
            this.richTextBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.richTextBox2.Name = "richTextBox2";
            this.richTextBox2.ReadOnly = true;
            this.richTextBox2.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.richTextBox2.Size = new System.Drawing.Size(193, 36);
            this.richTextBox2.TabIndex = 8;
            this.richTextBox2.Text = "";
            this.richTextBox2.Visible = false;
            this.richTextBox2.TextChanged += new System.EventHandler(this.richTextBox2_TextChanged);
            // 
            // excelButton
            // 
            this.excelButton.BackColor = System.Drawing.Color.Green;
            this.excelButton.Location = new System.Drawing.Point(835, 478);
            this.excelButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.excelButton.Name = "excelButton";
            this.excelButton.Size = new System.Drawing.Size(138, 42);
            this.excelButton.TabIndex = 9;
            this.excelButton.Text = "Export To Excel";
            this.excelButton.UseVisualStyleBackColor = false;
            this.excelButton.UseWaitCursor = true;
            this.excelButton.Visible = false;
            this.excelButton.Click += new System.EventHandler(this.excelButton_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(847, 429);
            this.progressBar1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(112, 29);
            this.progressBar1.TabIndex = 10;
            this.progressBar1.Visible = false;
            this.progressBar1.Click += new System.EventHandler(this.progressBar1_Click_1);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(368, 478);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(183, 70);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 12;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // OpticFiberTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1041, 562);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.excelButton);
            this.Controls.Add(this.richTextBox2);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.ConnectToDemo_btn);
            this.Controls.Add(this.Connect_btn);
            this.Controls.Add(this.start_btn);
            this.Controls.Add(this.clear_btn);
            this.Controls.Add(this.SFFoptions);
            this.Controls.Add(this.details_win);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.Name = "OpticFiberTest";
            this.Text = "Optical Fiber Test - version 3.0";
            this.Load += new System.EventHandler(this.OpticFiberTest_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ComboBox SFFoptions;
        private System.Windows.Forms.Button clear_btn;
        private System.Windows.Forms.Button start_btn;
        private System.Windows.Forms.Button Connect_btn;
        private System.Windows.Forms.RichTextBox details_win;
        private System.Windows.Forms.Button ConnectToDemo_btn;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.RichTextBox richTextBox2;
        private System.Windows.Forms.Button excelButton;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.PictureBox pictureBox2;
    }
}

