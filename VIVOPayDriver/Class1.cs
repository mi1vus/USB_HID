using System;
using System.Threading.Tasks;
using UsbLibrary;

namespace VIVOPayDriver
{
    public enum Commands : UInt16
    {
        Ping  = 0x1801,
        PingResp  = 0x18FF,
        Pass  = 0x2C01,
        PassResp  = 0x2CFF,
        Poll  = 0x2C02,
        Auth  = 0x2C06,
        Read  = 0x2C07,
        Write = 0x2C08,
    }

    public enum Status : byte
    {
        OK = 0x00,
        Incorrect_Header_Tag = 0x01,
        Unknown_Command = 0x02,
        Unknown_Sub_Command = 0x03,
        CRC_Error_in_Frame = 0x04,
        Incorrect_Parameter = 0x05,
        Parameter_Not_Supported = 0x06,
        Mal_formatted_Data = 0x07,
        Timeout = 0x08,
        Failed_NACK = 0x0A,
        Command_not_Allowed = 0x0B,
        Sub_Command_not_Allowed = 0x0C,
        Buffer_Overflow_Data_Length_too_large_for_reader_buffer = 0x0D,
        User_Interface_Event = 0x0E,
        Communication_type_not_supported,
        _VT_1,
        _burst,
        _etc = 0x11,
        Secure_interface_is_not_functional_or_is_in_an_intermediate_state = 0x12,
        Data_field_is_not_mod_8 = 0x13,
        Pad_0x80_not_found_where_expected = 0x14,
        Specified_key_type_is_invalid = 0x15,
        Could_not_retrieve_key_from_the_SAM_InitSecureComm = 0x16,
        ash_code_problem = 0x17,
        Could_not_store_the_key_into_the_SAM_InstallKey = 0x18,
        Frame_is_too_large = 0x19,
        Unit_powered_up_in_authentication_state_but_POS_must_resend_the_InitSecureComm_command = 0x1A,
        The_EEPROM_may_not_be_initialized_because_SecCommInterface_does_not_make_sense = 0x1B,
        Problem_encoding_APDU_Module_Specific_Status_Codes1 = 0x1C,
        Unsupported_Index_ILM_SAM_Transceiver_error_problem_communicating_with_the_SAM_Key_Mgr = 0x20,

        Unexpected_Sequence_Counter_in_multiple_frames_for_single_bitmap_ILM_Length_error_in_data_returned_from_the_SAM_Key_Mgr
            = 0x21,
        Improper_bit_map_ILM = 0x22,
        Request_Online_Authorization = 0x23,
        ViVOCard3_raw_data_read_successful = 0x24,
        Message_index_not_available_ILM_ViVOcomm_activate_transaction_card_type_ViVOcomm = 0x25,
        Version_Information_Mismatch_ILM = 0x26,
        Not_sending_commands_in_correct_index_message_index_ILM = 0x27,
        Time_out_or_next_expected_message_not_received_ILM = 0x28,
        ILM_languages_not_available_for_viewing_ILM = 0x29,
        Other_language_not_supported_ILM = 0x2A,
        Module_specific_errors_for_Key_Manager_Unknown_Error_from_SAM = 0x41,
        Module_specific_errors_for_Key_Manager_Invalid_data_detected_by_SAM = 0x42,
        Module_specific_errors_for_Key_Manager_Incomplete_data_detected_by_SAM = 0x43,
        Module_specific_errors_for_Key_Manager_Reserved = 0x44,
        Module_specific_errors_for_Key_Manager_Invalid_key_hash_algorithm = 0x45,
        Module_specific_errors_for_Key_Manager_Invalid_key_encryption_algorithm = 0x46,
        Module_specific_errors_for_Key_Manager_Invalid_modulus_length = 0x47,
        Module_specific_errors_for_Key_Manager_Invalid_exponent = 0x48,
        Module_specific_errors_for_Key_Manager_Key_already_exists = 0x49,
        Module_specific_errors_for_Key_Manager_No_space_for_new_RID = 0x4A,
        Module_specific_errors_for_Key_Manager_Key_not_found = 0x4B,
        Module_specific_errors_for_Key_Manager_Crypto_not_responding = 0x4C,
        Module_specific_errors_for_Key_Manager_Crypto_communication_error = 0x4D,
        Module_specific_errors_for_Key_Manager_All_key_slots_are_full_maximum_number_of_keys_has_been_installed = 0x4F,
        Auto_Switch_OK = 0x50,
        Auto_Switch_failed = 0x51,

    }

    public enum CardType : byte
    {
        None_Card_Not_Detected_or_Could_not_Activate = 0x0,
        ISO_14443_Type_A_Supports_ISO_14443_4_Protocol = 0x1,
        ISO_14443_Type_B_Supports_ISO_14443_4_Protocol = 0x2,
        Mifare_Type_A_Standard = 0x3,
        Mifare_Type_A_Ultralight = 0x4,
        ISO_14443_Type_A_Does_not_support_ISO_14443_4_Protocol = 0x5,
        ISO_14443_Type_B_Does_not_support_ISO_14443_4_Protocol = 0x6,
        ISO_14443_Type_A_and_Mifare_NFC_phone = 0x7,
    }

    public enum KeyType : byte
    {
        KeyA = 0x1,
        KeyB = 0x2,
    }

    public static class VIVOReader
    {
        public static UsbHidPort usb = new UsbHidPort();
        private static string USBDevProduct = "";
        private static string USBDevVendor = "";
        private static Int32 USBDevIRL = 0;
        private static Int32 USBDevORL = 0;
        private static Int32 USBDevFRL = 0;

        private static Object lockObj = new Object();
        public static bool status
        {
            get;
            private set;
        }
        public static CardType cardType
        {
            get;
            set;
        }

        public static byte[] initArray
            = { 0x56, 0x69, 0x56, 0x4f, 0x74, 0x65, 0x63, 0x68, 0x32, 0x00 };


        public static byte[] lastCommand;
        public static bool isResponseReceived;
        public static byte[] lastResponse;

        public static void Init(UInt16 pid, UInt16 vid)
        {
            if (usb.Ready())
            {
                usb.Close();
            }

            //var USBDevProductID = UInt16.Parse(pid.ToString().Replace("-", ""), System.Globalization.NumberStyles.HexNumber);
            //var USBDevVendorID = UInt16.Parse(vid.ToString().Replace("-", ""), System.Globalization.NumberStyles.HexNumber);

            usb.ProductId = pid;
            usb.VendorId = vid;

            usb.Open(true);

            if (usb.Ready())
            {
                usb.GetInfoStrings(ref USBDevVendor, ref USBDevProduct);

                USBDevIRL = usb.SpecifiedDevice.InputReportLength;
                USBDevORL = usb.SpecifiedDevice.OutputReportLength;
                USBDevFRL = usb.SpecifiedDevice.FeatureReportLength;

                //textBox_Dev_Product.Text = USBDevProduct;
                //textBox_Dev_Vendor.Text = USBDevVendor;

                //textBox_Dev_IRL.Text = USBDevIRL.ToString();
                //textBox_Dev_ORL.Text = USBDevORL.ToString();
                //textBox_Dev_FRL.Text = USBDevFRL.ToString();

                //usb.OnSpecifiedDeviceRemoved += new System.EventHandler(usb_OnSpecifiedDeviceRemoved);
                //usb.OnSpecifiedDeviceArrived += new System.EventHandler(usb_OnSpecifiedDeviceArrived);
                //usb.OnDeviceArrived += new System.EventHandler(usb_OnDeviceArrived);
                //usb.OnDeviceRemoved += new System.EventHandler(usb_OnDeviceRemoved);
                //usb.OnDataRecieved += new UsbLibrary.DataRecievedEventHandler(usb_OnDataRecieved);
                //usb.OnDataSend += new System.EventHandler(usb_OnDataSend);
                status = true;
            }
        }

        public static bool sendCmd(Commands cmd, byte[] data)
        {
            if (status && usb.SpecifiedDevice != null)
            {
                lock (lockObj)
                {
                    try
                    {
                        var command = BitConverter.GetBytes((UInt16) cmd);
                        Array.Reverse(command);

                        lastCommand = new byte[64];

                        int currCommandPos = 0;
                        Array.Copy(new byte[] {Convert.ToByte(1)}, 0, lastCommand, currCommandPos, 1);
                        currCommandPos += 1;
                        Array.Copy(initArray, 0, lastCommand, currCommandPos, initArray.Length);
                        currCommandPos += initArray.Length;
                        Array.Copy(command, 0, lastCommand, currCommandPos, command.Length);
                        currCommandPos += command.Length;
                        var dataLen = BitConverter.GetBytes((UInt16) data.Length);
                        Array.Reverse(dataLen);
                        Array.Copy(dataLen, 0, lastCommand, currCommandPos, dataLen.Length);
                        currCommandPos += dataLen.Length;
                        if (data.Length > 0)
                        {
                            Array.Copy(data, 0, lastCommand, currCommandPos, data.Length);
                            currCommandPos += data.Length;
                        }
                        var CRC = BitConverter.GetBytes(CalculateCRC(lastCommand, currCommandPos));
                        //if (cmd == Commands.Pass || inPassMode)
                        if (cmd == Commands.Pass || cmd == Commands.Poll ||
                            cmd == Commands.Auth || cmd == Commands.Read || cmd == Commands.Write)
                            Array.Reverse(CRC);//Pass CRC in BIGEndian

                        Array.Copy(CRC, 0, lastCommand, currCommandPos, CRC.Length);
                        currCommandPos += CRC.Length;

                        if (usb.SpecifiedDevice != null)
                        {
                            usb.SpecifiedDevice.SendData(lastCommand);
                            return true;
                        }
                    }
                    catch (Exception ex)
                    {
                        //MessageBox.Show(ex.ToString());
                        return false;
                    }
                    return false;
                }
            }
            return false;
        }

        public static bool parseResponse(byte[] data, ref byte command, ref Status status, ref bool CRCOK, ref byte[] commData)
        {
            var mode = data[0];
            var d1 = BitConverter.ToString(data, 1).Replace("-","");
            var d2 = BitConverter.ToString(initArray).Replace("-", "");
            if (d1.StartsWith(d2))
            {
                var bodyLength = data.Length - (1 + initArray.Length);
                var body = new byte [bodyLength];
                Array.Copy(data, 1 + initArray.Length, body, 0, bodyLength);
                command = body[0];
                status = (Status)body[1];
                var lengthRaw = new byte[2];
                Array.Copy(body, 2, lengthRaw, 0, 2);
                Array.Reverse(lengthRaw);
                var length = BitConverter.ToInt16(lengthRaw, 0);
                commData = new byte[length];
                Array.Copy(body, 4, commData, 0, length);
                var CRCResponse = BitConverter.ToUInt16(body, length + 4);
                var rawCRCCalc = BitConverter.GetBytes(CalculateCRC(data, length + 15));
                Array.Reverse(rawCRCCalc);//Responce  CRC in BIGEndian
                var CRCCalc = BitConverter.ToUInt16(rawCRCCalc, 0);
                CRCOK = CRCResponse == CRCCalc;

                return true;
            }
            return false;
        }

        #region События USB

        private static void usb_OnSpecifiedDeviceArrived(object sender, EventArgs e)
        {
            status = true;
        }

        private static void usb_OnSpecifiedDeviceRemoved(object sender, EventArgs e)
        {
            status = false;
        }

        private static void usb_OnDeviceArrived(object sender, EventArgs e)
        {
            //this.listBox1.Items.Add("Found a Device");
        }

        private static void usb_OnDeviceRemoved(object sender, EventArgs e)
        {
            //if (InvokeRequired)
            //{
            //    Invoke(new EventHandler(usb_OnDeviceRemoved), new object[] { sender, e });
            //}
            //else
            //{
            //    this.listBox1.Items.Add("Device was removed");
            //}
        }

        private static void usb_OnDataRecieved(object sender, DataRecievedEventArgs args)
        {
            lastResponse = new byte[args.data.Length];
            Array.Copy(args.data, lastResponse, args.data.Length);
            isResponseReceived = true;
        }

        private static void usb_OnDataSend(object sender, EventArgs e)
        {
            isResponseReceived = false;
        }

        #endregion

        #region Внутренние методы

        public static UInt16[] CrcTable = new UInt16[] 
        {
          0x0000, 0x1021, 0x2042, 0x3063, 0x4084, 0x50A5, 0x60C6, 0x70E7, 0x8108, 0x9129,
          0xA14A, 0xB16B, 0xC18C, 0xD1AD, 0xE1CE, 0xF1EF, 0x1231, 0x0210, 0x3273, 0x2252,
          0x52B5, 0x4294, 0x72F7, 0x62D6, 0x9339, 0x8318, 0xB37B, 0xA35A, 0xD3BD, 0xC39C,
          0xF3FF, 0xE3DE, 0x2462, 0x3443, 0x0420, 0x1401, 0x64E6, 0x74C7, 0x44A4, 0x5485,
          0xA56A, 0xB54B, 0x8528, 0x9509, 0xE5EE, 0xF5CF, 0xC5AC, 0xD58D, 0x3653, 0x2672,
          0x1611, 0x0630, 0x76D7, 0x66F6, 0x5695, 0x46B4, 0xB75B, 0xA77A, 0x9719, 0x8738,
          0xF7DF, 0xE7FE, 0xD79D, 0xC7BC, 0x48C4, 0x58E5, 0x6886, 0x78A7, 0x0840, 0x1861,
          0x2802, 0x3823, 0xC9CC, 0xD9ED, 0xE98E, 0xF9AF, 0x8948, 0x9969, 0xA90A, 0xB92B,
          0x5AF5, 0x4AD4, 0x7AB7, 0x6A96, 0x1A71, 0x0A50, 0x3A33, 0x2A12, 0xDBFD, 0xCBDC,
          0xFBBF, 0xEB9E, 0x9B79, 0x8B58, 0xBB3B, 0xAB1A, 0x6CA6, 0x7C87, 0x4CE4, 0x5CC5,
          0x2C22, 0x3C03, 0x0C60, 0x1C41, 0xEDAE, 0xFD8F, 0xCDEC, 0xDDCD, 0xAD2A, 0xBD0B,
          0x8D68, 0x9D49, 0x7E97, 0x6EB6, 0x5ED5, 0x4EF4, 0x3E13, 0x2E32, 0x1E51, 0x0E70,
          0xFF9F, 0xEFBE, 0xDFDD, 0xCFFC, 0xBF1B, 0xAF3A, 0x9F59, 0x8F78, 0x9188, 0x81A9,
          0xB1CA, 0xA1EB, 0xD10C, 0xC12D, 0xF14E, 0xE16F, 0x1080, 0x00A1, 0x30C2, 0x20E3,
          0x5004, 0x4025, 0x7046, 0x6067, 0x83B9, 0x9398, 0xA3FB, 0xB3DA, 0xC33D, 0xD31C,
          0xE37F, 0xF35E, 0x02B1, 0x1290, 0x22F3, 0x32D2, 0x4235, 0x5214, 0x6277, 0x7256,
          0xB5EA, 0xA5CB, 0x95A8, 0x8589, 0xF56E, 0xE54F, 0xD52C, 0xC50D, 0x34E2, 0x24C3,
          0x14A0, 0x0481, 0x7466, 0x6447, 0x5424, 0x4405, 0xA7DB, 0xB7FA, 0x8799, 0x97B8,
          0xE75F, 0xF77E, 0xC71D, 0xD73C, 0x26D3, 0x36F2, 0x0691, 0x16B0, 0x6657, 0x7676,
          0x4615, 0x5634, 0xD94C, 0xC96D, 0xF90E, 0xE92F, 0x99C8, 0x89E9, 0xB98A, 0xA9AB,
          0x5844, 0x4865, 0x7806, 0x6827, 0x18C0, 0x08E1, 0x3882, 0x28A3, 0xCB7D, 0xDB5C,
          0xEB3F, 0xFB1E, 0x8BF9, 0x9BD8, 0xABBB, 0xBB9A, 0x4A75, 0x5A54, 0x6A37, 0x7A16,
          0x0AF1, 0x1AD0, 0x2AB3, 0x3A92, 0xFD2E, 0xED0F, 0xDD6C, 0xCD4D, 0xBDAA, 0xAD8B,
          0x9DE8, 0x8DC9, 0x7C26, 0x6C07, 0x5C64, 0x4C45, 0x3CA2, 0x2C83, 0x1CE0, 0x0CC1,
          0xEF1F, 0xFF3E, 0xCF5D, 0xDF7C, 0xAF9B, 0xBFBA, 0x8FD9, 0x9FF8, 0x6E17, 0x7E36,
          0x4E55, 0x5E74, 0x2E93, 0x3EB2, 0x0ED1, 0x1EF0
        };

        public static UInt16 CalculateCRC(byte[] Buffer, int Len)
        {
            UInt16 Crc = 0xffff;
            int buffPos = 1;
            Len -= 1;
            while ((Len--) > 0)
            {
                UInt16 CrcShiftedRight = (UInt16)(Crc >> 8);
                UInt16 CrcShiftedLeft = (UInt16)(Crc << 8);

                Crc = (UInt16)(CrcTable[CrcShiftedRight ^ Buffer[buffPos]] ^ CrcShiftedLeft);
                buffPos++;
            }
            return (Crc);
        }

        private static bool WaitResponse(int timer)
        {
            while (!isResponseReceived && timer > 0)
            {
                timer -= 100;
                System.Threading.Thread.Sleep(100);
            }

            return timer > 0;
        }

        #endregion
    }
}
