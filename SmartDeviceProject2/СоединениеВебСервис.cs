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
using СкладскойУчет.СсылкаНаСервис;

namespace СкладскойУчет
{
    class СоединениеВебСервис
    {
        public static string НомерВерсии = "c#7";
        public static string СтрокаДоступныхРолей;
        public static string ИдентификаторСоединения;
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
            Сервис = new СуперКлиент();
            Сервис.Credentials = new NetworkCredential("WebConnection", "951");
            Сервис.PreAuthenticate = false;
            Сервис.AllowAutoRedirect = false;
        }

    }
}
