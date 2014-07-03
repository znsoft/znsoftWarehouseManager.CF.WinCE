using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using SDK.English;
using System.Windows.Forms;

namespace СкладскойУчет
{
    class РаботаСоСканером:IDisposable
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


         ~РаботаСоСканером() {
            if (SystemHelper.DeviceTypeIsKown) Barcode1D_free();

        }


        public static string Scan()
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

        public static bool НажатаКлавишаСкан(KeyEventArgs e)
        {
            if (SystemHelper.DeviceTypeIsKown)
                Barcode1D_init();
            return НажатаКлавишаСкан_(e);

        }

        private static bool НажатаКлавишаСкан_(KeyEventArgs e)
        {
            switch (SystemHelper.CurrentDeviceType)
            {
                case DeviceType.C2000:
                    return ((int)e.KeyCode == (int)ConstantKeyValue.Scan || (int)e.KeyCode == (int)ConstantKeyValue.F9 || (int)e.KeyCode == (int)ConstantKeyValue.F10 || (int)e.KeyCode == (int)ConstantKeyValue.F11 || ((int)e.KeyCode == (int)ConstantKeyValue.F12) || ((int)e.KeyCode == (int)ConstantKeyValue.F7) || ((int)e.KeyCode == (int)ConstantKeyValue.F8));
                case DeviceType.C5000:
                    return (((int)e.KeyCode == (int)ConstantKeyValue.Enter) || (int)e.KeyCode == (int)ConstantKeyValue.F9 || (int)e.KeyCode == (int)ConstantKeyValue.F10 || (int)e.KeyCode == (int)ConstantKeyValue.F11 || ((int)e.KeyCode == (int)ConstantKeyValue.F12));
            }
            return false;
        }


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


        public static void ВключитьРадио() {

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
