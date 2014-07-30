using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Runtime.InteropServices;

namespace СкладскойУчет.Оборудование
{
    class РасширениеСписка
    {
        
        public static Point GetItemPosition(IntPtr Handle,int index)
        {
            try
            {
                POINT pt = new POINT();
                WinApi.SendMessage(Handle, (0x1000 + 16), index, pt);
                return new Point(pt.x, pt.y);
            }
            catch (Exception) { 
            }
            return new Point(10, 10);

        }

    }
}
