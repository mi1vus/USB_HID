using System;
using System.Globalization;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Interop;
using UsbLibrary;

namespace Example_WPF
{
    public partial class MainWindow : Window
    {
        UsbHidPort usb = new UsbHidPort();

        private UInt16 USBDevProductID = 0x2301;
        private UInt16 USBDevVendorID = 0xC251;
        private string USBDevProduct = "";
        private string USBDevVendor = "";
        private Int32 USBDevIRL = 0;
        private Int32 USBDevORL = 0;
        private Int32 USBDevFRL = 0;

        #region Инициализация и загрузка окна
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            HwndSource src = HwndSource.FromHwnd(new WindowInteropHelper(this).Handle);
            src.AddHook(new HwndSourceHook(WndProc));

            usb.OnSpecifiedDeviceArrived += usb_OnSpecifiedDeviceArrived;
            usb.OnSpecifiedDeviceRemoved += usb_OnSpecifiedDeviceRemoved;
            usb.OnDataRecieved += usb_OnDataRecieved;
        }
        #endregion

        #region Обработка нажатий кнопок
        private void button_Dev_Connect_Click(object sender, RoutedEventArgs e)
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

        private void button_Dev_Disconnect_Click(object sender, RoutedEventArgs e)
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
            Dev_StatusLabel.Content = "Подключено!";
        }

        private void usb_OnSpecifiedDeviceRemoved(object sender, EventArgs e)
        {
            Dev_StatusLabel.Content = "Нет подключения!";
        }

        private void usb_OnDataRecieved(object sender, UsbLibrary.DataRecievedEventArgs args)
        {
            //DataIn = args.data;
        }
        #endregion

        #region Обработка системных событий
        private IntPtr WndProc(IntPtr hwnd, int msg, IntPtr wParam, IntPtr lParam, ref bool handled)
        {
            Message m = new Message();
            m.HWnd = hwnd;
            m.Msg = msg;
            m.WParam = wParam;
            m.LParam = lParam;

            usb.ParseMessages(ref m);
            return IntPtr.Zero;
        }

        protected override void OnSourceInitialized(EventArgs e)
        {
            base.OnSourceInitialized(e);

            var handle = new WindowInteropHelper(this).Handle;

            usb.RegisterHandle(handle);
        }
        #endregion
    }
}
