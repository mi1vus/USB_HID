namespace Example
{
    partial class MainForm
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
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.Dev_StatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_Dev_PID = new System.Windows.Forms.TextBox();
            this.textBox_Dev_VID = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button_Dev_Connect = new System.Windows.Forms.Button();
            this.button_Dev_Disconnect = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.textBox_Dev_FRL = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.textBox_Dev_ORL = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox_Dev_IRL = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox_Dev_Product = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox_Dev_Vendor = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button10 = new System.Windows.Forms.Button();
            this.button11 = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.button12 = new System.Windows.Forms.Button();
            this.button13 = new System.Windows.Forms.Button();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.button14 = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.textBox8 = new System.Windows.Forms.TextBox();
            this.textBox9 = new System.Windows.Forms.TextBox();
            this.statusStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Dev_StatusLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 422);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(2, 0, 19, 0);
            this.statusStrip1.Size = new System.Drawing.Size(1304, 22);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // Dev_StatusLabel
            // 
            this.Dev_StatusLabel.Name = "Dev_StatusLabel";
            this.Dev_StatusLabel.Size = new System.Drawing.Size(0, 17);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 32);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(126, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "PID (hex-формат):";
            // 
            // textBox_Dev_PID
            // 
            this.textBox_Dev_PID.Location = new System.Drawing.Point(8, 52);
            this.textBox_Dev_PID.Margin = new System.Windows.Forms.Padding(4);
            this.textBox_Dev_PID.MaxLength = 4;
            this.textBox_Dev_PID.Name = "textBox_Dev_PID";
            this.textBox_Dev_PID.Size = new System.Drawing.Size(249, 22);
            this.textBox_Dev_PID.TabIndex = 2;
            this.textBox_Dev_PID.Text = "0100";
            this.textBox_Dev_PID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox_Dev_VID
            // 
            this.textBox_Dev_VID.Location = new System.Drawing.Point(8, 100);
            this.textBox_Dev_VID.Margin = new System.Windows.Forms.Padding(4);
            this.textBox_Dev_VID.MaxLength = 4;
            this.textBox_Dev_VID.Name = "textBox_Dev_VID";
            this.textBox_Dev_VID.Size = new System.Drawing.Size(249, 22);
            this.textBox_Dev_VID.TabIndex = 4;
            this.textBox_Dev_VID.Text = "1D5F";
            this.textBox_Dev_VID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 80);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(126, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "VID (hex-формат):";
            // 
            // button_Dev_Connect
            // 
            this.button_Dev_Connect.Location = new System.Drawing.Point(8, 244);
            this.button_Dev_Connect.Margin = new System.Windows.Forms.Padding(4);
            this.button_Dev_Connect.Name = "button_Dev_Connect";
            this.button_Dev_Connect.Size = new System.Drawing.Size(120, 28);
            this.button_Dev_Connect.TabIndex = 5;
            this.button_Dev_Connect.Text = "Подключиться";
            this.button_Dev_Connect.UseVisualStyleBackColor = true;
            this.button_Dev_Connect.Click += new System.EventHandler(this.button_Dev_Connect_Click);
            // 
            // button_Dev_Disconnect
            // 
            this.button_Dev_Disconnect.Location = new System.Drawing.Point(139, 244);
            this.button_Dev_Disconnect.Margin = new System.Windows.Forms.Padding(4);
            this.button_Dev_Disconnect.Name = "button_Dev_Disconnect";
            this.button_Dev_Disconnect.Size = new System.Drawing.Size(120, 28);
            this.button_Dev_Disconnect.TabIndex = 6;
            this.button_Dev_Disconnect.Text = "Отключиться";
            this.button_Dev_Disconnect.UseVisualStyleBackColor = true;
            this.button_Dev_Disconnect.Click += new System.EventHandler(this.button_Dev_Disconnect_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.button_Dev_Disconnect);
            this.groupBox1.Controls.Add(this.textBox_Dev_PID);
            this.groupBox1.Controls.Add(this.button_Dev_Connect);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.textBox_Dev_VID);
            this.groupBox1.Location = new System.Drawing.Point(16, 14);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(267, 283);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Параметры устройства";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.textBox_Dev_FRL);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.textBox_Dev_ORL);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.textBox_Dev_IRL);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.textBox_Dev_Product);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.textBox_Dev_Vendor);
            this.groupBox2.Location = new System.Drawing.Point(291, 14);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(333, 283);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Прочитанные параметры устройства";
            // 
            // textBox_Dev_FRL
            // 
            this.textBox_Dev_FRL.Location = new System.Drawing.Point(8, 247);
            this.textBox_Dev_FRL.Margin = new System.Windows.Forms.Padding(4);
            this.textBox_Dev_FRL.MaxLength = 4;
            this.textBox_Dev_FRL.Name = "textBox_Dev_FRL";
            this.textBox_Dev_FRL.ReadOnly = true;
            this.textBox_Dev_FRL.Size = new System.Drawing.Size(312, 22);
            this.textBox_Dev_FRL.TabIndex = 11;
            this.textBox_Dev_FRL.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(9, 228);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(201, 17);
            this.label7.TabIndex = 10;
            this.label7.Text = "Feature Report Length (байт):";
            // 
            // textBox_Dev_ORL
            // 
            this.textBox_Dev_ORL.Location = new System.Drawing.Point(8, 199);
            this.textBox_Dev_ORL.Margin = new System.Windows.Forms.Padding(4);
            this.textBox_Dev_ORL.MaxLength = 4;
            this.textBox_Dev_ORL.Name = "textBox_Dev_ORL";
            this.textBox_Dev_ORL.ReadOnly = true;
            this.textBox_Dev_ORL.Size = new System.Drawing.Size(312, 22);
            this.textBox_Dev_ORL.TabIndex = 9;
            this.textBox_Dev_ORL.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(8, 180);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(195, 17);
            this.label6.TabIndex = 8;
            this.label6.Text = "Output Report Length (байт):";
            // 
            // textBox_Dev_IRL
            // 
            this.textBox_Dev_IRL.Location = new System.Drawing.Point(8, 151);
            this.textBox_Dev_IRL.Margin = new System.Windows.Forms.Padding(4);
            this.textBox_Dev_IRL.MaxLength = 4;
            this.textBox_Dev_IRL.Name = "textBox_Dev_IRL";
            this.textBox_Dev_IRL.ReadOnly = true;
            this.textBox_Dev_IRL.Size = new System.Drawing.Size(312, 22);
            this.textBox_Dev_IRL.TabIndex = 7;
            this.textBox_Dev_IRL.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(4, 132);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(183, 17);
            this.label5.TabIndex = 5;
            this.label5.Text = "Input Report Length (байт):";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 32);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 17);
            this.label3.TabIndex = 1;
            this.label3.Text = "Product:";
            // 
            // textBox_Dev_Product
            // 
            this.textBox_Dev_Product.Location = new System.Drawing.Point(8, 52);
            this.textBox_Dev_Product.Margin = new System.Windows.Forms.Padding(4);
            this.textBox_Dev_Product.MaxLength = 4;
            this.textBox_Dev_Product.Name = "textBox_Dev_Product";
            this.textBox_Dev_Product.ReadOnly = true;
            this.textBox_Dev_Product.Size = new System.Drawing.Size(312, 22);
            this.textBox_Dev_Product.TabIndex = 2;
            this.textBox_Dev_Product.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 80);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 17);
            this.label4.TabIndex = 3;
            this.label4.Text = "Vendor:";
            // 
            // textBox_Dev_Vendor
            // 
            this.textBox_Dev_Vendor.Location = new System.Drawing.Point(8, 100);
            this.textBox_Dev_Vendor.Margin = new System.Windows.Forms.Padding(4);
            this.textBox_Dev_Vendor.MaxLength = 4;
            this.textBox_Dev_Vendor.Name = "textBox_Dev_Vendor";
            this.textBox_Dev_Vendor.ReadOnly = true;
            this.textBox_Dev_Vendor.Size = new System.Drawing.Size(312, 22);
            this.textBox_Dev_Vendor.TabIndex = 4;
            this.textBox_Dev_Vendor.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(643, 10);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(113, 62);
            this.button1.TabIndex = 9;
            this.button1.Text = "send";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.send_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(643, 220);
            this.button2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(44, 25);
            this.button2.TabIndex = 10;
            this.button2.Text = "ping";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.ping_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(643, 363);
            this.textBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(448, 22);
            this.textBox1.TabIndex = 11;
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.HorizontalScrollbar = true;
            this.listBox1.ItemHeight = 16;
            this.listBox1.Location = new System.Drawing.Point(762, 10);
            this.listBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(530, 180);
            this.listBox1.TabIndex = 12;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(693, 220);
            this.button3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(44, 25);
            this.button3.TabIndex = 13;
            this.button3.Text = "start";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.startPass_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(743, 220);
            this.button4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(44, 25);
            this.button4.TabIndex = 14;
            this.button4.Text = "poll";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.poll_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(643, 249);
            this.button5.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(54, 25);
            this.button5.TabIndex = 15;
            this.button5.Text = "auth0";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.auth_Click);
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(644, 278);
            this.button7.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(53, 25);
            this.button7.TabIndex = 17;
            this.button7.Text = "read0";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.read_Click);
            // 
            // button10
            // 
            this.button10.Location = new System.Drawing.Point(644, 305);
            this.button10.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(78, 25);
            this.button10.TabIndex = 19;
            this.button10.Text = "write4_44";
            this.button10.UseVisualStyleBackColor = true;
            this.button10.Click += new System.EventHandler(this.write_Click);
            // 
            // button11
            // 
            this.button11.Location = new System.Drawing.Point(643, 334);
            this.button11.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(54, 25);
            this.button11.TabIndex = 21;
            this.button11.Text = "stop";
            this.button11.UseVisualStyleBackColor = true;
            this.button11.Click += new System.EventHandler(this.stopPass_Click);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(785, 249);
            this.textBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(298, 22);
            this.textBox2.TabIndex = 22;
            this.textBox2.Text = "FF FF FF FF FF FF";
            // 
            // button12
            // 
            this.button12.Location = new System.Drawing.Point(643, 76);
            this.button12.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button12.Name = "button12";
            this.button12.Size = new System.Drawing.Size(113, 62);
            this.button12.TabIndex = 23;
            this.button12.Text = "clear";
            this.button12.UseVisualStyleBackColor = true;
            this.button12.Click += new System.EventHandler(this.button12_Click);
            // 
            // button13
            // 
            this.button13.Location = new System.Drawing.Point(703, 334);
            this.button13.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button13.Name = "button13";
            this.button13.Size = new System.Drawing.Size(54, 25);
            this.button13.TabIndex = 24;
            this.button13.Text = "CRC";
            this.button13.UseVisualStyleBackColor = true;
            this.button13.Click += new System.EventHandler(this.button13_Click);
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(763, 334);
            this.textBox3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(434, 22);
            this.textBox3.TabIndex = 25;
            this.textBox3.Text = "01 56 69 56 4F 74 65 63 68 32 00 2C 08 00 12 31 04 44 44 44 44 44 44 44 44 44 44 " +
    "44 44 44 44 44 44";
            // 
            // button14
            // 
            this.button14.Location = new System.Drawing.Point(1159, 210);
            this.button14.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button14.Name = "button14";
            this.button14.Size = new System.Drawing.Size(54, 25);
            this.button14.TabIndex = 26;
            this.button14.Text = "CRC";
            this.button14.UseVisualStyleBackColor = true;
            this.button14.Click += new System.EventHandler(this.button14_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(632, 201);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(61, 17);
            this.label8.TabIndex = 12;
            this.label8.Text = "Product:";
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(703, 278);
            this.textBox4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(34, 22);
            this.textBox4.TabIndex = 27;
            this.textBox4.Text = "8";
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(728, 305);
            this.textBox5.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(29, 22);
            this.textBox5.TabIndex = 28;
            this.textBox5.Text = "4";
            // 
            // textBox6
            // 
            this.textBox6.Location = new System.Drawing.Point(802, 305);
            this.textBox6.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(490, 22);
            this.textBox6.TabIndex = 29;
            this.textBox6.Text = "00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(1204, 334);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(61, 17);
            this.label9.TabIndex = 30;
            this.label9.Text = "Product:";
            // 
            // textBox7
            // 
            this.textBox7.Location = new System.Drawing.Point(703, 249);
            this.textBox7.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new System.Drawing.Size(29, 22);
            this.textBox7.TabIndex = 31;
            this.textBox7.Text = "8";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "A",
            "B"});
            this.comboBox1.Location = new System.Drawing.Point(738, 249);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(41, 24);
            this.comboBox1.TabIndex = 33;
            // 
            // textBox8
            // 
            this.textBox8.Location = new System.Drawing.Point(743, 278);
            this.textBox8.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox8.Name = "textBox8";
            this.textBox8.Size = new System.Drawing.Size(34, 22);
            this.textBox8.TabIndex = 34;
            this.textBox8.Text = "4";
            // 
            // textBox9
            // 
            this.textBox9.Location = new System.Drawing.Point(762, 305);
            this.textBox9.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox9.Name = "textBox9";
            this.textBox9.Size = new System.Drawing.Size(34, 22);
            this.textBox9.TabIndex = 35;
            this.textBox9.Text = "1";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1304, 444);
            this.Controls.Add(this.textBox9);
            this.Controls.Add(this.textBox8);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.textBox7);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.textBox6);
            this.Controls.Add(this.textBox5);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.button14);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.button13);
            this.Controls.Add(this.button12);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.button11);
            this.Controls.Add(this.button10);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.statusStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Main Form";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel Dev_StatusLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_Dev_PID;
        private System.Windows.Forms.TextBox textBox_Dev_VID;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button_Dev_Connect;
        private System.Windows.Forms.Button button_Dev_Disconnect;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox_Dev_Product;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox_Dev_Vendor;
        private System.Windows.Forms.TextBox textBox_Dev_FRL;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBox_Dev_ORL;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBox_Dev_IRL;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.Button button11;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button button12;
        private System.Windows.Forms.Button button13;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Button button14;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox textBox7;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.TextBox textBox8;
        private System.Windows.Forms.TextBox textBox9;
    }
}

