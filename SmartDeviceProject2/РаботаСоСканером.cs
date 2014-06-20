using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using SDK.English;
using System.Windows.Forms;

namespace СкладскойУчет
{
    class РаботаСоСканером
    {

        [DllImport("DeviceAPI.dll", EntryPoint = "Barcode1D_init")]
        private static extern void Barcode1D_init();

        [DllImport("DeviceAPI.dll", EntryPoint = "Barcode1D_scan")]
        private static extern int Barcode1D_scan(byte[] pszData);

        [DllImport("DeviceAPI.dll", EntryPoint = "Barcode1D_free")]
        private static extern void Barcode1D_free();

        public РаботаСоСканером()
        {
            SystemHelper.GetDeviceType();
            if (SystemHelper.DeviceTypeIsKown) Barcode1D_init();
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
                }
                return barcode;
            }
            catch (System.Exception ex)
            {
                return string.Empty;
            }

        }

        public static bool НажатаКлавишаСкан(KeyEventArgs e) {
            switch(SystemHelper.CurrentDeviceType){
                case DeviceType.C2000:
                    return ((int)e.KeyCode == (int)ConstantKeyValue.Scan);
                case DeviceType.C5000:
                    return ((int)e.KeyCode == (int)ConstantKeyValue.Enter);
            }
            return false;
        }

    }
}
