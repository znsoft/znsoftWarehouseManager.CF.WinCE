using System;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using System.Collections.Generic;
using CodeBetter.Json;

namespace СкладскойУчет
{
    class СоединениеВебСервис
    {
        public static string НомерВерсии;
        public static string Пользователь;
        public static string СтрокаДоступныхРолей;  //"Отгрузка,Хранение,Подбор,Приемка,Прочие"
        public static bool ПодборТовараВМеста;
        public static bool ЭтоТерминал;
        public static bool ПодборЗаказовКлиентов;
        public static string ИдентификаторСоединения;
        private static СоединениеВебСервис Экземпляр;
        public httpссылка Сервис;
        public static Dictionary<String,bool> Роли;


        //Синглтон для работы с классом из всех окон приложения
        public static СоединениеВебСервис ПолучитьСервис()
        {
            if (Экземпляр == null)
                Экземпляр = new СоединениеВебСервис();
            return Экземпляр;
        }

     
        private СоединениеВебСервис() {
            Сервис = new httpссылка();
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

    class httpссылка
    {
        public bool PreAuthenticate;
        public bool AllowAutoRedirect;
        public NetworkCredential Credentials;
        public string Url;

        public Byte[] updatefirmware(string НомерВерсии)
        {

            HttpWebRequest updatefirmwarereq = (HttpWebRequest)HttpWebRequest.Create(Url + "updatefirmware/csharp");

            updatefirmwarereq.Credentials = Credentials;
            updatefirmwarereq.Headers.Add("Authorization", "Basic " + GetEncodedCredentialsString());

            updatefirmwarereq.Method = "POST";

            byte[] sentData = Encoding.UTF8.GetBytes(СоединениеВебСервис.НомерВерсии);
            updatefirmwarereq.ContentLength = sentData.Length;
            Stream sendStream = updatefirmwarereq.GetRequestStream();
            sendStream.Write(sentData, 0, sentData.Length);
            sendStream.Close();

            HttpWebResponse res = (HttpWebResponse)updatefirmwarereq.GetResponse();

            if (res.ContentLength == 0) { return null; }

            byte[] buffer = new byte[res.ContentLength];
            Stream str = res.GetResponseStream();

            int pos = 0;
            int a = 0;

            while (true)
            {
                a = str.Read(buffer, pos, (int)res.ContentLength - 1 - pos);
                if (a == 0) { break; }
                pos = pos + a;

            }

            res.Close();

            return buffer;


        }

        public string[][] Обмен(string Операция, string Доп, string[][] СписокСтрок)
        {
            // подготовка запроса

            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(Url + "exchange");

            request.AllowAutoRedirect = AllowAutoRedirect;
            request.PreAuthenticate = PreAuthenticate;
            request.Method = "POST";
            request.KeepAlive = true;
            request.Credentials = Credentials;
            request.Headers.Add("Authorization", "Basic " + GetEncodedCredentialsString());
            request.Headers.Add("AppID", СоединениеВебСервис.ИдентификаторСоединения);
            request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate; // ответ придет в сжатом виде

            string outputDataString = Converter.Serialize(new ДанныеДляHttpСервисаЗапрос(Операция, Доп, СписокСтрок));

            byte[] outputDadaByte = Encoding.UTF8.GetBytes(outputDataString);

            request.ContentLength = outputDadaByte.Length;

            // отправка запроса на сервер

            using (Stream output = request.GetRequestStream())
            {
                output.Write(outputDadaByte, 0, outputDadaByte.Length);
            }

            // чтение ответа

            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (StreamReader sr = new StreamReader(response.GetResponseStream()))
            {
                string result = sr.ReadToEnd();

                if (result == "null")
                    return null;

                return Converter.Deserialize<string[][]>(result);
            }
        }

        private string GetEncodedCredentialsString()
        {
            return Convert.ToBase64String(Encoding.UTF8.GetBytes(Credentials.UserName + ":" + Credentials.Password));
        }
    }

    public struct ДанныеДляHttpСервисаЗапрос
    {

        public string Опер;
        public string Доп;
        public string[][] Список;

        public ДанныеДляHttpСервисаЗапрос(string Операция, string Допполнительно, string[][] СписокСтрок)
        {
            Список = СписокСтрок;
            Опер = Операция;
            Доп = Допполнительно;

        }

    }

}
