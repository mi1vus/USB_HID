using System;
using System.Drawing;
using System.Globalization;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using UsbLibrary;
using VIVOPayDriver;

namespace Example
{
    public partial class MainForm : Form
    {
        private UInt16 USBDevProductID = 0x0100;
        private UInt16 USBDevVendorID = 0x1D5F;
        private string USBDevProduct = "";
        private string USBDevVendor = "";
        private Int32 USBDevIRL = 0;
        private Int32 USBDevORL = 0;
        private Int32 USBDevFRL = 0;
        private bool waitNextResponse = false;
        private byte[] tempData;
        private static Object lockObjMain = new Object();

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
            //VIVOReader.usb.OnSpecifiedDeviceRemoved += new System.EventHandler(this.usb_OnSpecifiedDeviceRemoved);
            //VIVOReader.usb.OnSpecifiedDeviceArrived += new System.EventHandler(this.usb_OnSpecifiedDeviceArrived);
            //VIVOReader.usb.OnDeviceArrived += new System.EventHandler(this.usb_OnDeviceArrived);
            //VIVOReader.usb.OnDeviceRemoved += new System.EventHandler(this.usb_OnDeviceRemoved);
            //VIVOReader.usb.OnDataRecieved += new UsbLibrary.DataRecievedEventHandler(this.usb_OnDataRecieved);
            //VIVOReader.usb.OnDataSend += new System.EventHandler(this.usb_OnDataSend);
            comboBox1.SelectedIndex = 0;
        }
        #endregion

        #region Обработка нажатий кнопок
        private void button_Dev_Connect_Click(object sender, EventArgs e)
        {
            VIVOReader.usb.OnSpecifiedDeviceRemoved += new System.EventHandler(usb_OnSpecifiedDeviceRemoved);
            VIVOReader.usb.OnSpecifiedDeviceArrived += new System.EventHandler(usb_OnSpecifiedDeviceArrived);
            VIVOReader.usb.OnDeviceArrived += new System.EventHandler(usb_OnDeviceArrived);
            VIVOReader.usb.OnDeviceRemoved += new System.EventHandler(usb_OnDeviceRemoved);
            VIVOReader.usb.OnDataRecieved += new UsbLibrary.DataRecievedEventHandler(usb_OnDataRecieved);
            VIVOReader.usb.OnDataSend += new System.EventHandler(usb_OnDataSend);

            USBDevProductID = UInt16.Parse(textBox_Dev_PID.Text, NumberStyles.HexNumber);
            USBDevVendorID = UInt16.Parse(textBox_Dev_VID.Text, NumberStyles.HexNumber);
          
            VIVOReader.usb.ProductId = USBDevProductID;
            VIVOReader.usb.VendorId = USBDevVendorID;

            VIVOReader.Init(USBDevProductID, USBDevVendorID);

            if (VIVOReader.usb.Ready())
            {
                VIVOReader.usb.GetInfoStrings(ref USBDevVendor, ref USBDevProduct);

                USBDevIRL = VIVOReader.usb.SpecifiedDevice.InputReportLength;
                USBDevORL = VIVOReader.usb.SpecifiedDevice.OutputReportLength;
                USBDevFRL = VIVOReader.usb.SpecifiedDevice.FeatureReportLength;

                textBox_Dev_Product.Text = USBDevProduct;
                textBox_Dev_Vendor.Text = USBDevVendor;

                textBox_Dev_IRL.Text = USBDevIRL.ToString();
                textBox_Dev_ORL.Text = USBDevORL.ToString();
                textBox_Dev_FRL.Text = USBDevFRL.ToString();
            }
        }

        private void button_Dev_Disconnect_Click(object sender, EventArgs e)
        {
            if (VIVOReader.usb.Ready())
            {
                VIVOReader.usb.Close();

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
            {
                if (InvokeRequired)
                {
                    try
                    {
                        Invoke(new DataRecievedEventHandler(usb_OnDataRecieved), new object[] {sender, args});
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.ToString());
                    }
                }
                else
                  lock (lockObjMain)
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

                    var currentDataPos = tempData?.Length ?? 0;

                    if (args.data[0] == 0x1 || args.data[0] == 0x2)
                    {
                        tempData = new byte[args.data.Length];
                    }
                    if (args.data[0] == 0x2)
                    {
                        waitNextResponse = true;
                    }
                    if ((args.data[0] == 0x3 || args.data[0] == 0x4) && waitNextResponse)
                    {
                        Array.Resize(ref tempData, currentDataPos + args.data.Length);
                    }
                    if ((args.data[0] == 0x4 && waitNextResponse) || args.data[0] == 0x1)
                    {
                        waitNextResponse = false;
                    }
                    Array.Copy(args.data, currentDataPos == 0 ? 0 : 1, tempData, currentDataPos, args.data.Length - (currentDataPos == 0 ? 0 : 1));

                    if (!waitNextResponse)
                    {
                        byte comm = 0;
                        Status stat = Status.OK;
                        bool crcOK = false;
                        byte[] responseData = { };

                        if (VIVOReader.parseResponse(tempData, ref comm, ref stat, ref crcOK, ref responseData))
                        {
                            Commands c = (Commands)(comm*256 + 0xFF);
                            label8.Text = $"res: {c}: {stat} CRC:{(crcOK ? "ОК" : "error") }";
                            this.listBox1.Items.Insert(0, "commData:" + (responseData.Length != 0 ? BitConverter.ToString(responseData) : " empty"));
                            if (Commands.PassResp == c && responseData.Length != 0)
                            {
                                label8.Text += $" Card: {(CardType)responseData[0]}";
                                VIVOReader.cardType = (CardType) responseData[0];
                            }
                        }
                        else
                            label8.Text = $"wrong parsing response!";

                        tempData = null;
                    }
                    else
                        label8.Text = $"wait next response";
                  }
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
            VIVOReader.usb.RegisterHandle(Handle);
        }

        protected override void WndProc(ref Message m)
        {
            VIVOReader.usb.ParseMessages(ref m);
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

                if (VIVOReader.usb.SpecifiedDevice != null)
                {
                    VIVOReader.usb.SpecifiedDevice.SendData(data);
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

                VIVOReader.usb.ProductId = USBDevProductID;
                VIVOReader.usb.VendorId = USBDevVendorID;
                VIVOReader.usb.CheckDevicePresent();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void ping_Click(object sender, EventArgs e)
        {
            //sendByteString("56 69 56 4f 74 65 63 68 32 00 18 01 00 00 b3 cd");
            send(Commands.Ping, new byte[] {});
        }

        private void startPass_Click(object sender, EventArgs e)
        {
            //sendByteString("56 69 56 4F 74 65 63 68 32 00 2C 01 00 01 01 1D 19");
            send(Commands.Pass, new byte[] {0x1});
        }

        private void poll_Click(object sender, EventArgs e)
        {
            //sendByteString("56 69 56 4F 74 65 63 68 32 00 2C 02 00 02 00 C8 06 6B");
            send(Commands.Poll, new byte[] { 0x0,0xC8 });
        }

        private void auth_Click(object sender, EventArgs e)
        {
            //sendByteString($"56 69 56 4F 74 65 63 68 32 00 2C 06 00 08 03 01 {textBox2.Text.Trim()} C4 6E");
            //27 A2 9C 10 F8 C7
            //FF FF FF FF FF FF
            byte block = 0;
            KeyType keyT = comboBox1.SelectedIndex == 0 ? KeyType.KeyA: KeyType.KeyB;
            int t;
            if (int.TryParse(textBox7.Text, out t))
                block = (byte)t;

            string[] arrText = textBox2.Text.Trim().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            byte[] key = new byte[arrText.Length];
            for (int i = 0; i < arrText.Length; i++)
            {
                if (arrText[i] != "")
                {
                    int value = Int32.Parse(arrText[i], NumberStyles.HexNumber);
                    key[i] = (byte)Convert.ToByte(value);
                }
            }
            var data = new byte[key.Length + 2];
            data[0] = block;
            data[1] = (byte)keyT;
            Array.Copy(key, 0, data, 2, key.Length);

            send(Commands.Auth, data);
        }

        private void read_Click(object sender, EventArgs e)
        {
            //sendByteString("
            //56 69 56 4F 74 65 63 68 32 00 2C 07 00 02 31 00 4B DC");
            //56 69 56 4F 74 65 63 68 32 00 2C 07 00 02 31 01 5B FD
            //56 69 56 4F 74 65 63 68 32 00 2C 07 00 02 31 02 6B 9E
            //bit 7-4 type 3-0 count of blocks to read
            byte block = 0;
            byte blocks = 0;
            int t;
            if (int.TryParse(textBox4.Text, out t))
                block = (byte)t;
            if (int.TryParse(textBox8.Text, out t))
                blocks = (byte)t;

            var lBitType =  ((int)VIVOReader.cardType << 4) + blocks;//read 2 blacks (max = 15)
            byte card_blocks = BitConverter.GetBytes(lBitType)[0];

            send(Commands.Read, new byte[] { card_blocks , block });
        }
        
        private void write_Click(object sender, EventArgs e)
        {
            //sendByteString("56 69 56 4F 74 65 63 68 32 00 2C 08 00 12 31 04 44 44 44 44 44 44 44 44 44 44 44 44 44 44 44 44 1C 9C");
            byte block = 0;
            byte blocks = 0;
            int t;
            if (int.TryParse(textBox5.Text, out t))
                block = (byte)t;
            if (int.TryParse(textBox9.Text, out t))
                blocks = (byte)t;

            var lBitType = ((int)VIVOReader.cardType << 4) + blocks;//read 2 blacks (max = 15)
            byte card_blocks = BitConverter.GetBytes(lBitType)[0];

            string[] arrText = textBox6.Text.Trim().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            byte[] toWrite = new byte[arrText.Length];
            for (int i = 0; i < arrText.Length; i++)
            {
                if (arrText[i] != "")
                {
                    int value = Int32.Parse(arrText[i], NumberStyles.HexNumber);
                    toWrite[i] = (byte)Convert.ToByte(value);
                }
            }

            var data = new byte[toWrite.Length + 2];
            data[0] = card_blocks;
            data[1] = block;
            Array.Copy(toWrite, 0, data, 2, toWrite.Length);

            send(Commands.Write, data);
        }

        private void write4_00_Click(object sender, EventArgs e)
        {
            //sendByteString("56 69 56 4F 74 65 63 68 32 00 2C 08 00 12 31 04 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 4C A5");
        }

        private void stopPass_Click(object sender, EventArgs e)
        {
            //sendByteString("56 69 56 4F 74 65 63 68 32 00 2C 01 00 01 00 0D 38");
            send(Commands.Pass, new byte[] { 0x0 });
        }

        //private bool sendByteString(string bytes)
        //{
        //    try
        //    {
        //        bytes = ("01 " + bytes).Trim();
        //        string[] arrText = bytes.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        //        byte[] data = new byte[arrText.Length];
        //        for (int i = 0; i < arrText.Length; i++)
        //        {
        //            if (arrText[i] != "")
        //            {
        //                int value = Int32.Parse(arrText[i], System.Globalization.NumberStyles.HexNumber);
        //                data[i] = (byte)Convert.ToByte(value);
        //            }
        //        }

        //        if (VIVOReader.usb.SpecifiedDevice != null)
        //        {
        //            VIVOReader.usb.SpecifiedDevice.SendData(data);
        //            return true;
        //        }
        //        else
        //        {
        //            MessageBox.Show("Sorry but your device is not present. Plug it in!! ");
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.ToString());
        //    }
        //    return false;
        //}

        private void button12_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            string bytes = textBox3.Text.Trim();
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

            var CRC = BitConverter.GetBytes(VIVOReader.CalculateCRC(data, data.Length));
            Array.Reverse(CRC);
            label9.Text = BitConverter.ToString(CRC, 0, 2);
        }

        private void button14_Click(object sender, EventArgs e)
        {
            if (VIVOReader.isResponseReceived)
            {
                listBox1.Items.Clear();
                listBox1.Items.Insert(0, BitConverter.ToString(VIVOReader.lastCommand));
                VIVOReader.isResponseReceived = false;
            }
            else
                listBox1.Items.Insert(0, "no data");
        }

        private bool send(Commands cmd, byte[] data)
        {
            label8.Text = $"sending cmd!";
            if (VIVOReader.sendCmd(cmd, data))
                return true;

            MessageBox.Show("Sorry but your device is not present. Plug it in!! ");
            return false;
        }

    }
}
