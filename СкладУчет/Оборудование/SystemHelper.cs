using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Microsoft.Win32;
using System.Windows.Forms;

namespace SDK.English
{
    /// <summary>
    /// DeviceType
    /// </summary>
    public enum DeviceType
    {
        /// <summary>
        /// UnKwon
        /// </summary>
        UnKown = 0,
        /// <summary>
        /// C2000 Device
        /// </summary>
        C2000 = 1,
        /// <summary>
        /// C5000 Device
        /// </summary>
        C5000 = 2
    }



    public class SystemHelper
    {
        /// <summary>
        /// The Device Type is know
        /// </summary>
        public static bool DeviceTypeIsKown = false;
        /// <summary>
        /// Get Device Type(only run after the 2012-5-15 Operate System)
        /// </summary>
        /// <returns></returns>
        public static bool GetDeviceType()
        {
            try
            {
                //read the registrykey
                RegistryKey machine = Registry.LocalMachine;
                RegistryKey control = machine.OpenSubKey("ControlPanel");
                RegistryKey system = control.OpenSubKey("SystemVersion");

                string type = system.GetValue("ProductType").ToString();
                if (type.ToUpper() == "C5")
                {
                    CurrentDeviceType = DeviceType.C5000;
                }
                if (type.ToUpper() == "C2")
                {
                    CurrentDeviceType = DeviceType.C2000;
                }
                DeviceTypeIsKown = true;
                return true;
            }
            catch
            {
                DeviceTypeIsKown = false;
                CurrentDeviceType = DeviceType.UnKown;
                return false;
            }
        }
        /// <summary>
        /// current device type
        /// </summary>
        public static DeviceType CurrentDeviceType = DeviceType.UnKown;
    }
    /// <summary>
    /// The Device Keyboard value
    /// </summary>
    public enum ConstantKeyValue
    {
        #region other key
        /// <summary>
        /// *
        /// </summary>
        Star = 42,
        /// <summary>
        /// #
        /// </summary>
        Sharp = 35,
        /// <summary>
        /// back
        /// </summary>
        Back = 8,
        /// <summary> 
        /// enter
        /// </summary>
        Enter = 13,
        #endregion

        #region up、down、left、right
        /// <summary>
        /// up
        /// </summary>
        Up = 38,
        /// <summary>
        /// down
        /// </summary>
        Down = 40,
        /// <summary>
        /// left
        /// </summary>
        Left = 37,
        /// <summary>
        /// right
        /// </summary>
        Right = 39,
        #endregion

        #region F1,...,F12
        /// <summary>
        /// F1
        /// </summary>
        F1 = 112,
        /// <summary>
        /// F2
        /// </summary>
        F2 = 113,
        /// <summary>
        /// F3
        /// </summary>
        F3 = 114,
        /// <summary>
        /// F4
        /// </summary>
        F4 = 115,
        /// <summary>
        /// F5
        /// </summary>
        F5 = 116,
        /// <summary>
        /// F6
        /// </summary>
        F6 = 117,
        /// <summary>
        /// F7
        /// </summary>
        F7 = 118,
        /// <summary>
        /// F8
        /// </summary>
        F8 = 119,
        /// <summary>
        /// F9
        /// </summary>
        F9 = 120,
        /// <summary>
        /// F10
        /// </summary>
        F10 = 121,
        /// <summary>
        /// F11
        /// </summary>
        F11 = 122,
        /// <summary>
        /// F12
        /// </summary>
        F12 = 123,
        #endregion

        #region Digit 0,...,9
        /// <summary>
        /// 0
        /// </summary>
        Digit0 = 48,
        /// <summary>
        /// 1
        /// </summary>
        Digit1 = 49,
        /// <summary>
        /// 2
        /// </summary>
        Digit2 = 50,
        /// <summary>
        /// 3
        /// </summary>
        Digit3 = 51,
        /// <summary>
        /// 4
        /// </summary>
        Digit4 = 52,
        /// <summary>
        /// 5
        /// </summary>
        Digit5 = 53,
        /// <summary>
        /// 6
        /// </summary>
        Digit6 = 54,
        /// <summary>
        /// 7
        /// </summary>
        Digit7 = 55,
        /// <summary>
        /// 8
        /// </summary>
        Digit8 = 56,
        /// <summary>
        /// 9
        /// </summary>
        Digit9 = 57,
        #endregion

        #region the key only C2000 has
        /// <summary>
        /// C2000 Scan
        /// </summary>
        Scan = 238,
        /// <summary>
        /// C2000 Tab
        /// </summary>
        Tab = 9,
        /// <summary>
        /// C2000 ESC
        /// </summary>
        ESC = 27
        #endregion
    }
}
