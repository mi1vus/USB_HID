using System;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using UsbLibrary;

namespace Example
{
    public partial class MainForm : Form
    {
        UsbHidPort usb = new UsbHidPort();

        private UInt16 USBDevProductID = 0x0100;
        private UInt16 USBDevVendorID = 0x1D5F;
        private string USBDevProduct = "";
        private string USBDevVendor = "";
        private Int32 USBDevIRL = 0;
        private Int32 USBDevORL = 0;
        private Int32 USBDevFRL = 0;

        #region Инициализация и загрузка окна
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            //usb.OnSpecifiedDeviceArrived += usb_OnSpecifiedDeviceArrived;
            //usb.OnSpecifiedDeviceRemoved += usb_OnSpecifiedDeviceRemoved;
            //usb.OnDataRecieved += usb_OnDataRecieved;
            //usb.OnDataSend += usb_OnDataSend;
            usb.OnSpecifiedDeviceRemoved += new System.EventHandler(this.usb_OnSpecifiedDeviceRemoved);
            usb.OnSpecifiedDeviceArrived += new System.EventHandler(this.usb_OnSpecifiedDeviceArrived);
            usb.OnDeviceArrived += new System.EventHandler(this.usb_OnDeviceArrived);
            usb.OnDeviceRemoved += new System.EventHandler(this.usb_OnDeviceRemoved);
            usb.OnDataRecieved += new UsbLibrary.DataRecievedEventHandler(this.usb_OnDataRecieved);
            usb.OnDataSend += new System.EventHandler(this.usb_OnDataSend);

        }
        #endregion

        #region Обработка нажатий кнопок
        private void button_Dev_Connect_Click(object sender, EventArgs e)
        {
            if (usb.Ready())
            {
                usb.Close();
            }

            USBDevProductID = UInt16.Parse(textBox_Dev_PID.Text, NumberStyles.HexNumber);
            USBDevVendorID = UInt16.Parse(textBox_Dev_VID.Text, NumberStyles.HexNumber);
          
            usb.ProductId = USBDevProductID;
            usb.VendorId = USBDevVendorID;

            usb.Open(true);

            if (usb.Ready())
            {
                usb.GetInfoStrings(ref USBDevVendor, ref USBDevProduct);

                USBDevIRL = usb.SpecifiedDevice.InputReportLength;
                USBDevORL = usb.SpecifiedDevice.OutputReportLength;
                USBDevFRL = usb.SpecifiedDevice.FeatureReportLength;

                textBox_Dev_Product.Text = USBDevProduct;
                textBox_Dev_Vendor.Text = USBDevVendor;

                textBox_Dev_IRL.Text = USBDevIRL.ToString();
                textBox_Dev_ORL.Text = USBDevORL.ToString();
                textBox_Dev_FRL.Text = USBDevFRL.ToString();
            }
        }

        private void button_Dev_Disconnect_Click(object sender, EventArgs e)
        {
            if (usb.Ready())
            {
                usb.Close();

                USBDevVendor = USBDevProduct = "";
                USBDevIRL = USBDevORL = USBDevFRL = 0;

                textBox_Dev_Product.Clear();
                textBox_Dev_Vendor.Clear();

                textBox_Dev_IRL.Clear();
                textBox_Dev_ORL.Clear();
                textBox_Dev_FRL.Clear();
            }
        }
        #endregion

        #region События USB
        private void usb_OnSpecifiedDeviceArrived(object sender, EventArgs e)
        {
            if (InvokeRequired)
            {
                Invoke(new EventHandler(usb_OnSpecifiedDeviceArrived), new object[] {sender, e});
            }
            else
            {
                Dev_StatusLabel.Text = "Подключено!";
                Dev_StatusLabel.BackColor = Color.LightBlue;
            }
        }

        private void usb_OnSpecifiedDeviceRemoved(object sender, EventArgs e)
        {
            if (InvokeRequired)
            {
                Invoke(new EventHandler(usb_OnSpecifiedDeviceRemoved), new object[] {sender, e});
            }
            else
            {
                Dev_StatusLabel.Text = "Нет подключения!";
                Dev_StatusLabel.BackColor = Color.LightYellow;
            }
        }

        private void usb_OnDeviceArrived(object sender, EventArgs e)
        {
            this.listBox1.Items.Add("Found a Device");
        }

        private void usb_OnDeviceRemoved(object sender, EventArgs e)
        {
            if (InvokeRequired)
            {
                Invoke(new EventHandler(usb_OnDeviceRemoved), new object[] { sender, e });
            }
            else
            {
                this.listBox1.Items.Add("Device was removed");
            }
        }

        private void usb_OnDataRecieved(object sender, DataRecievedEventArgs args)
        {
            if (InvokeRequired)
            {
                try
                {
                    Invoke(new DataRecievedEventHandler(usb_OnDataRecieved), new object[] { sender, args });
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }
            else
            {

                string rec_data = "Data: ";
                foreach (byte myData in args.data)
                {
                    if (myData.ToString("X2").Length == 1)
                    {
                        rec_data += "0";
                    }

                    rec_data += myData.ToString("X2") + " ";
                }

                this.listBox1.Items.Insert(0, rec_data);
            }
        }

        private void usb_OnDataSend(object sender, EventArgs e)
        {
            this.listBox1.Items.Insert(0, "Some data was send");
        }

        #endregion

        #region Обработка системных событий
        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            usb.RegisterHandle(Handle);
        }

        protected override void WndProc(ref Message m)
        {
            usb.ParseMessages(ref m);
            base.WndProc(ref m);
        }
        #endregion

        private void send_Click(object sender, EventArgs e)
        {
            try
            {
                string text = this.textBox1.Text + " ";
                text.Trim();
                string[] arrText = text.Split(new [] { ' '},StringSplitOptions.RemoveEmptyEntries);
                byte[] data = new byte[arrText.Length];
                for (int i = 0; i < arrText.Length; i++)
                {
                    if (arrText[i] != "")
                    {
                        int value = Int32.Parse(arrText[i], System.Globalization.NumberStyles.HexNumber);
                        data[i] = (byte)Convert.ToByte(value);
                    }
                }

                if (this.usb.SpecifiedDevice != null)
                {
                    this.usb.SpecifiedDevice.SendData(data);
                }
                else
                {
                    MessageBox.Show("Sorry but your device is not present. Plug it in!! ");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void listen_Click(object sender, EventArgs e)
        {
            try
            {
                USBDevProductID = UInt16.Parse(textBox_Dev_PID.Text, NumberStyles.HexNumber);
                USBDevVendorID = UInt16.Parse(textBox_Dev_VID.Text, NumberStyles.HexNumber);

                usb.ProductId = USBDevProductID;
                usb.VendorId = USBDevVendorID;
                usb.CheckDevicePresent();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void ping_Click(object sender, EventArgs e)
        {
            sendByteString("56 69 56 4f 74 65 63 68 32 00 18 01 00 00 b3 cd");
        }

        private void startPass_Click(object sender, EventArgs e)
        {
            sendByteString("56 69 56 4F 74 65 63 68 32 00 2C 01 00 01 01 1D 19");
        }

        private void poll_Click(object sender, EventArgs e)
        {
            sendByteString("56 69 56 4F 74 65 63 68 32 00 2C 02 00 02 00 C8 06 6B");
        }

        private void auth0_Click(object sender, EventArgs e)
        {
            sendByteString($"56 69 56 4F 74 65 63 68 32 00 2C 06 00 08 03 01 {textBox2.Text.Trim()} C4 6E");
        }

        private void auth1_Click(object sender, EventArgs e)
        {
            sendByteString($"56 69 56 4F 74 65 63 68 32 00 2C 06 00 08 07 01 {textBox2.Text.Trim()} CB 03");
        }

        private void read0_Click(object sender, EventArgs e)
        {
            sendByteString("56 69 56 4F 74 65 63 68 32 00 2C 07 00 02 31 00 4B DC");
        }

        private void read1_Click(object sender, EventArgs e)
        {
            sendByteString("56 69 56 4F 74 65 63 68 32 00 2C 07 00 02 31 04 0B 58");
        }

        private void write4_44_Click(object sender, EventArgs e)
        {
            sendByteString("56 69 56 4F 74 65 63 68 32 00 2C 08 00 12 31 04 44 44 44 44 44 44 44 44 44 44 44 44 44 44 44 44 1C 9C");
        }

        private void write4_00_Click(object sender, EventArgs e)
        {
            sendByteString("56 69 56 4F 74 65 63 68 32 00 2C 08 00 12 31 04 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 4C A5");
        }

        private void stopPass_Click(object sender, EventArgs e)
        {
            sendByteString("56 69 56 4F 74 65 63 68 32 00 2C 01 00 01 00 0D 38");
        }
        
        public bool sendByteString(string bytes)
        {
            try
            {
                bytes = ("01 " + bytes).Trim();
                string[] arrText = bytes.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                byte[] data = new byte[arrText.Length];
                for (int i = 0; i < arrText.Length; i++)
                {
                    if (arrText[i] != "")
                    {
                        int value = Int32.Parse(arrText[i], System.Globalization.NumberStyles.HexNumber);
                        data[i] = (byte)Convert.ToByte(value);
                    }
                }

                if (this.usb.SpecifiedDevice != null)
                {
                    this.usb.SpecifiedDevice.SendData(data);
                    return true;
                }
                else
                {
                    MessageBox.Show("Sorry but your device is not present. Plug it in!! ");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return false;
        }

        private void button12_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
        }
    }
}
