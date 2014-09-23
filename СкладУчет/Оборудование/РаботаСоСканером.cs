using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using SDK.English;
using System.Windows.Forms;
using System.Threading;

namespace СкладскойУчет
{
    class РаботаСоСканером : IDisposable
    {



        [DllImport("DeviceAPI.dll", EntryPoint = "Barcode1D_init")]
        private static extern void Barcode1D_init();

        [DllImport("DeviceAPI.dll", EntryPoint = "Barcode1D_scan")]
        private static extern int Barcode1D_scan(byte[] pszData);

        [DllImport("DeviceAPI.dll", EntryPoint = "Barcode1D_free")]
        private static extern void Barcode1D_free();

        public static bool ЭтоСканирование = false;
        public static Звуки Звук;

        public РаботаСоСканером()
        {
            SystemHelper.GetDeviceType();
            if (SystemHelper.DeviceTypeIsKown)
                Barcode1D_init();
            Звук = new Звуки();
        }


        ~РаботаСоСканером()
        {
            if (SystemHelper.DeviceTypeIsKown) Barcode1D_free();

        }


        public static string Scan()
        {


            if (SystemHelper.CurrentDeviceType == DeviceType.UnKown)
            {
                Инфо.СчитанныйШтрихКод = СканироватьКодЧерезБуферОбмена();
            }
            else
            {
                Инфо.СчитанныйШтрихКод = СканироватьЧерезdll();
            }
            return Инфо.СчитанныйШтрихКод;

        }

        private static string СканироватьЧерезdll()
        {
            int ibarLen = 0;
            byte[] pszData = new byte[2048];
            string barcode = string.Empty;
            try
            {
                ibarLen = Barcode1D_scan(pszData);

                if (ibarLen > 0)
                {
                    barcode = Encoding.ASCII.GetString(pszData, 0, ibarLen).Trim();
                    ЭтоСканирование = true;
                    if (barcode.Length > 0) Звук.Ок();

                }
                return barcode;
            }
            catch (System.Exception)
            {

                return string.Empty;
            }
        }

        private static string СканироватьКодЧерезБуферОбмена()
        {
            string barcode = string.Empty;

            for (int i = 20; i > 0; i--)
            {

                barcode = ПолучитьБуферОбмена().Trim();
                if (barcode.Length > 2) break;
                try { Thread.Sleep(100); }
                catch (Exception) { }

            }

            СтеретьБуферОбмена();
            if (barcode.Length < 3) return string.Empty;
            ЭтоСканирование = true;
            Звук.Ок();
            return barcode;
        }

        public static void СтеретьБуферОбмена()
        {
            try
            {
                Clipboard.SetDataObject("");
            }
            catch (Exception)
            {
            }

        }

        public static string ПолучитьБуферОбмена()
        {
            try
            {
                return GetClipboardText();
            }
            catch (Exception)
            {

                return ReadClipboard();

            }
        }



        public static bool НажатаКлавишаСкан(KeyEventArgs e)
        {

            bool S = НажатаКлавишаСкан_(e);
            if (S && SystemHelper.DeviceTypeIsKown)
                Barcode1D_init();
            return S;

        }

        private static bool НажатаКлавишаСкан_(KeyEventArgs e)
        {
            switch (SystemHelper.CurrentDeviceType)
            {
                case DeviceType.C2000:
                    return ((int)e.KeyCode == (int)ConstantKeyValue.Scan || (int)e.KeyCode == (int)ConstantKeyValue.F9 || (int)e.KeyCode == (int)ConstantKeyValue.F10 || (int)e.KeyCode == (int)ConstantKeyValue.F11 || ((int)e.KeyCode == (int)ConstantKeyValue.F12) || ((int)e.KeyCode == (int)ConstantKeyValue.F7) || ((int)e.KeyCode == (int)ConstantKeyValue.F8));
                case DeviceType.C5000:
                    return (((int)e.KeyCode == (int)ConstantKeyValue.Enter) || (int)e.KeyCode == (int)ConstantKeyValue.F9 || (int)e.KeyCode == (int)ConstantKeyValue.F10 || (int)e.KeyCode == (int)ConstantKeyValue.F11 || ((int)e.KeyCode == (int)ConstantKeyValue.F12));
                case DeviceType.UnKown:
                    bool r = ((int)e.KeyCode == 193);
                    r = r || (e.Control && e.KeyCode == System.Windows.Forms.Keys.V);//[CTRL+V]
                    return r;

            }
            return false;
        }


        public static bool НажатаПраваяПодэкраннаяКлавиша(KeyEventArgs e)
        {
            switch (SystemHelper.CurrentDeviceType)
            {
                case DeviceType.C2000:
                    return ((int)e.KeyCode == (int)ConstantKeyValue.Tab);
                case DeviceType.C5000:
                    return ((int)e.KeyCode == (int)ConstantKeyValue.F7);
            }
            return false;
        }

        public static bool НажатаЛеваяПодэкраннаяКлавиша(KeyEventArgs e)
        {
            switch (SystemHelper.CurrentDeviceType)
            {
                case DeviceType.C2000:
                    return ((int)e.KeyCode == (int)ConstantKeyValue.ESC);
                case DeviceType.C5000:
                    return ((int)e.KeyCode == (int)ConstantKeyValue.F6);
            }
            return false;
        }

        public static string GetClipboardText() {
            IDataObject iData = Clipboard.GetDataObject();
            if (iData.GetDataPresent(DataFormats.Text))
                return (String)iData.GetData(DataFormats.Text);
            return String.Empty;
        
        }

       #region PC x86 barcode 
        private static string ReadClipboard()
        {
            var ФормаВвода = new ВводШК();
            ФормаВвода.ShowDialog();
            return ФормаВвода.BarCode;
        }
        #endregion



        #region Члены IDisposable

        public void Dispose()
        {
            if (SystemHelper.DeviceTypeIsKown) Barcode1D_free();
        }

        #endregion

    }


    class CLR_WIFI
    {

        #region API
        //  turn on WIFI Modem
        [DllImport("DeviceAPI.dll", EntryPoint = "WifiOn")]
        private static extern bool WifiOn();


        //  turn off WIFI Modem
        [DllImport("DeviceAPI.dll", EntryPoint = "WifiOff")]
        private static extern bool WifiOff();

        //  Obtain signal value of WIFI
        [DllImport("DeviceAPI.dll", EntryPoint = "WifiDriver_whether_loaded")]
        private static extern bool WifiDriver_whether_loaded();
        #endregion


        public static void ВключитьРадио()
        {

            SystemHelper.GetDeviceType();
            if (SystemHelper.DeviceTypeIsKown) if (!CLR_WIFI.isConnected()) CLR_WIFI.PowerOn();

        }

        //turn on WIFI Modem  
        public static bool PowerOn()
        {
            return WifiOn();
        }


        //turn off WIFI Modem
        public static bool PowerOff()
        {
            return WifiOff();
        }

        public static bool isConnected()
        {
            if (WifiDriver_whether_loaded())
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }



}
