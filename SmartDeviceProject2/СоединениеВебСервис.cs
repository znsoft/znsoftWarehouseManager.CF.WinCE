using System;
using System.Xml;
using System.Xml.Linq;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Net;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.IO;
using SmartDeviceProject2.СсылкаНаСервис;

namespace SmartDeviceProject2
{
    class СоединениеВебСервис
    {
        private static СоединениеВебСервис Экземпляр;
        public forTSD Сервис; 


        //Синглтон для работы с классом из всех окон приложения
        public static СоединениеВебСервис ПолучитьСервис()
        {
            if (Экземпляр == null)
                Экземпляр = new СоединениеВебСервис();
            return Экземпляр;
        }

     
        private СоединениеВебСервис() {
            Сервис = new forTSD();
            Сервис.Credentials = new NetworkCredential("WebConnection", "951");
        }

    }
}
