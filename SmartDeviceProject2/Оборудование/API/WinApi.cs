using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using System.Drawing;

namespace СкладскойУчет.Оборудование
{
    //http://blogs.msdn.com/b/netcfteam/archive/2005/05/23/421143.aspx
    //http://blogs.msdn.com/b/netcfteam/archive/2005/05/20/420551.aspx
    //
    class WinApi
    {
        #region WM_Const

        public const uint NM_DBLCLK = 0xFFFFFFFF - 3;
        public const uint WM_NOTIFY = 0x4E;
        public const uint NM_CLICK = 0xFFFFFFFE;
        public const uint NM_RCLICK = 0xFFFFFFFB;
        public const uint TV_FIRST = 0x1100;
        public const uint TVM_HITTEST = TV_FIRST + 17;
        public const uint TVHT_NOWHERE = 0x0001;
        public const uint TVHT_ONITEMICON = 0x0002;
        public const uint TVHT_ONITEMLABEL = 0x0004;
        public const uint TVHT_ONITEM = (TVHT_ONITEMICON | TVHT_ONITEMLABEL | TVHT_ONITEMSTATEICON);
        public const uint TVHT_ONITEMINDENT = 0x0008;
        public const uint TVHT_ONITEMBUTTON = 0x0010;
        public const uint TVHT_ONITEMRIGHT = 0x0020;
        public const uint TVHT_ONITEMSTATEICON = 0x0040;
        public const uint TVHT_ABOVE = 0x0100;
        public const uint TVHT_BELOW = 0x0200;
        public const uint TVHT_TORIGHT = 0x0400;
        public const uint TVHT_TOLEFT = 0x0800;
        public const int GWL_WNDPROC = -4;

        #endregion

        /// <summary>
        /// A callback to a Win32 window procedure (wndproc)
        /// </summary>
        /// <param name="hwnd">The handle of the window receiving a message</param>
        /// <param name="msg">The message</param>
        /// <param name="wParam">The message's parameters (part 1)</param>
        /// <param name="lParam">The message's parameters (part 2)</param>
        /// <returns>A integer as described for the given message in MSDN</returns>
        public delegate int WndProc(IntPtr hwnd, uint msg, uint wParam, int lParam);

        [System.Runtime.InteropServices.StructLayout(LayoutKind.Sequential)]
        public class NMHDR
        {
            public IntPtr hwndFrom;
            public uint idFrom;
            public uint code;
        }

        public struct TVHITTESTINFO
        {
            public POINT pt;
            public uint flags;
            public IntPtr hItem;
        }

        #region Win imports
        [DllImport("coredll.dll", EntryPoint = "SendMessage")]
        private static extern IntPtr SendMessageCEPOINT(IntPtr hWnd, int Msg, int wParam, POINT lParam);

        [DllImport("user32.dll", EntryPoint = "SendMessage")]
        private static extern IntPtr SendMessage32POINT(IntPtr hWnd, int Msg, int wParam, POINT lParam);

         //TV_FIRST  0x1100
        //TVM_GETITEMRECT  (TV_FIRST+4)
         //TreeView_GetItemRect(hwnd,hitem,prc,code)  (*(HTREEITEM *)prc = (hitem), (BOOL)SNDMSG((hwnd), TVM_GETITEMRECT, (WPARAM)(code), (LPARAM)(RECT *)(prc)))
        //[DllImport("coredll.dll", EntryPoint = "SendMessage")]
        //public extern static int SendMessageCEHitTest(
        //IntPtr hwnd, uint msg, uint wParam, ref TVHITTESTINFO lParam);

        //[DllImport("user32.dll", EntryPoint = "SendMessage")]
        //public extern static int SendMessage32HitTest(
        //IntPtr hwnd, uint msg, uint wParam, ref TVHITTESTINFO lParam);

        [DllImport("user32.dll", EntryPoint = "GetMessagePos")]
        public extern static uint GetMessagePos32();

        [DllImport("coredll.dll", EntryPoint = "GetMessagePos")]
        public extern static uint GetMessagePosCE();

        [DllImport("coredll.dll", SetLastError = true, EntryPoint = "waveOutSetVolume")]
        protected static extern int waveOutSetVolumeCE(IntPtr device, uint volume);

        [DllImport("user32.dll", SetLastError = true, EntryPoint = "waveOutSetVolume")]
        protected static extern int waveOutSetVolume32(IntPtr device, uint volume);


        [DllImport("user32.dll", SetLastError = true, EntryPoint = "DefWindowProc")]
        public extern static int DefWindowProc32(
            IntPtr hwnd, uint msg, uint wParam, int lParam);


        [DllImport("coredll.dll", SetLastError = true, EntryPoint = "DefWindowProc")]
        public extern static int DefWindowProcCE(
            IntPtr hwnd, uint msg, uint wParam, int lParam);


        [DllImport("coredll.dll", SetLastError = true, EntryPoint = "SetWindowLong")]
        public extern static IntPtr SetWindowLongCE(
            IntPtr hwnd, int nIndex, IntPtr dwNewLong);

        [DllImport("user32.dll", SetLastError = true, EntryPoint = "SetWindowLong")]
        public extern static IntPtr SetWindowLong32(
            IntPtr hwnd, int nIndex, IntPtr dwNewLong);



        [DllImport("user32.dll", SetLastError = true, EntryPoint = "CallWindowProc")]
        public extern static int CallWindowProc32(
            IntPtr lpPrevWndFunc, IntPtr hwnd, uint msg, uint wParam, int lParam);

        [DllImport("coredll.dll", SetLastError = true, EntryPoint = "CallWindowProc")]
        public extern static int CallWindowProcCE(
            IntPtr lpPrevWndFunc, IntPtr hwnd, uint msg, uint wParam, int lParam);
        #endregion

        /// <summary>
        /// Истина если это WinCE
        /// </summary>
        /// <returns></returns>
        public static bool isWinCEPlatform()
        {
            return Environment.OSVersion.Platform == PlatformID.WinCE;
        }

        public static int CallWindowProc(
            IntPtr lpPrevWndFunc, IntPtr hwnd, uint msg, uint wParam, int lParam)
               {
            try
            {
                if (isWinCEPlatform())
                    return CallWindowProcCE(
             lpPrevWndFunc, hwnd, msg, wParam, lParam);
                 return CallWindowProc32(
             lpPrevWndFunc, hwnd, msg, wParam, lParam);
            }
            catch (Exception) { }
            return -1;
        }

        /// <summary>
        /// Посылает сообщение ОС для расширения возможностей listView
        /// </summary>
        /// <param name="hWnd"></param>
        /// <param name="Msg"></param>
        /// <param name="wParam"></param>
        /// <param name="lParam"></param>
        /// <returns></returns>
        public static IntPtr SendMessage(IntPtr hWnd, int Msg, int wParam, POINT lParam)
        {
            try
            {
                if (isWinCEPlatform())
                    return SendMessageCEPOINT(hWnd, Msg, wParam, lParam);
                return SendMessage32POINT(hWnd, Msg, wParam, lParam);
            }
            catch (Exception) { }
            return (IntPtr)(-1);
        }
        /// <summary>
        /// Расширение возможностей TreeView 
        /// </summary>
        /// <param name="hwnd"></param>
        /// <param name="msg"></param>
        /// <param name="wParam"></param>
        /// <param name="lParam"></param>
        /// <returns></returns>
        //public static int SendMessage(
        //IntPtr hwnd, uint msg, uint wParam, ref TVHITTESTINFO lParam)
        //{
        //    try
        //    {
        //        if (isWinCEPlatform())
        //            return SendMessageCEHitTest(hwnd, msg, wParam, ref lParam);
        //        return SendMessage32HitTest(hwnd, msg, wParam, ref lParam);
        //    }
        //    catch (Exception e) { }
        //    return -1;
        //}

        public static int waveOutSetVolume(IntPtr device, uint volume)
        {
            try
            {
                if (isWinCEPlatform())
                    return waveOutSetVolumeCE(device, volume);
                return waveOutSetVolume32(device, volume);
            }
            catch (Exception) { }
            return -1;
        }

        public static uint GetMessagePos()
        {
            try
            {
                if (isWinCEPlatform())
                    return GetMessagePosCE();
                return GetMessagePos32();
            }
            catch (Exception) { }
            return 0;
        }

        public static IntPtr SetWindowLong(
            IntPtr hwnd, int nIndex, IntPtr dwNewLong)
        {
            try
            {
                if (isWinCEPlatform())
                    return SetWindowLongCE(
             hwnd, nIndex, dwNewLong);
                return SetWindowLong32(
             hwnd, nIndex, dwNewLong);
            }
            catch (Exception) { }
            return (IntPtr)(-1);
        }

        public static int DefWindowProc(
            IntPtr hwnd, uint msg, uint wParam, int lParam)
        {
            try
            {
                if (isWinCEPlatform())
                    return DefWindowProcCE(
             hwnd, msg, wParam, lParam);
                return DefWindowProc32(
         hwnd, msg, wParam, lParam);
            }
            catch (Exception) { }
            return -1;
        }

        /// <summary>
        /// Helper function to convert a Windows lParam into a Point
        /// </summary>
        /// <param name="lParam">The parameter to convert</param>
        /// <returns>A Point where X is the low 16 bits and Y is the
        /// high 16 bits of the value passed in</returns>
        public static Point LParamToPoint(int lParam)
        {
            uint ulParam = (uint)lParam;
            return new Point(
                (int)(ulParam & 0x0000ffff),
                (int)((ulParam & 0xffff0000) >> 16));
        }

    }
}
