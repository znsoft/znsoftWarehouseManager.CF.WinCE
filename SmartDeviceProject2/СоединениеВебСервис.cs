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

namespace SmartDeviceProject2
{
    class СоединениеВебСервис
    {
        private static СоединениеВебСервис Экземпляр;
        public СсылкаНаСервис.forTSD Сервис; 

        public static СоединениеВебСервис ПолучитьСервис()
        {
            if (Экземпляр == null)
                Экземпляр = new СоединениеВебСервис();
            return Экземпляр;
        }

     
        private СоединениеВебСервис() {
            Сервис = new СсылкаНаСервис.forTSD();
            Сервис.Credentials = new NetworkCredential("WebConnection", "951");
        }
        


        // public void НачатьвебСоединение()
        //{
        //    List<СсылкаНаСервис.СтрокаНоменклатуры> Список = new List<SmartDeviceProject2.СсылкаНаСервис.СтрокаНоменклатуры>();
        //    СсылкаНаСервис.СтрокаНоменклатуры СтрокаНоменклатуры = new СсылкаНаСервис.СтрокаНоменклатуры;
        //    СтрокаНоменклатуры.Код = "423";
        //    СтрокаНоменклатуры.Количество = 503;
        //    СтрокаНоменклатуры.Наименование = "123";
        //    Список.Add(СтрокаНоменклатуры);
        //    СсылкаНаСервис.forTSD Сервис = new СсылкаНаСервис.forTSD();
        //     Сервис.Url =  
        //    Сервис.Credentials = new NetworkCredential("WebConnection", "951");
        //    СсылкаНаСервис.forTSD СписокПользователей = Сервис.ОбменТСД("СписокПользователей",Список.ToArray());

        //}
        



    }
}
