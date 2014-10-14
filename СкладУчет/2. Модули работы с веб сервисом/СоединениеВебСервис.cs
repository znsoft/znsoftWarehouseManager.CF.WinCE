using System;
using System.Collections.Generic;
using System.Net;
using СкладскойУчет.СсылкаНаСервис;

namespace СкладскойУчет
{
    class СоединениеВебСервис
    {
        public static string НомерВерсии;
        public static string СтрокаДоступныхРолей;  //"Отгрузка,Хранение,Подбор,Приемка,Прочие,Администратор"
        public static string ИдентификаторСоединения;
        private static СоединениеВебСервис Экземпляр;
        public forTSD Сервис;
        public static Dictionary<String,bool> Роли;


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

        public static string ГенерироватьИдентификатор()
        {

            var СлучайноеЧисло = new Random();
            return СоединениеВебСервис.НомерВерсии + ":" + СлучайноеЧисло.Next().ToString().Substring(0, 4);
        }

    }
}
