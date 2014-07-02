using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Xml.Serialization;
using System.Net;
using System.Net.Sockets;

namespace СкладскойУчет
{
    public class Настройки
    {

        [Serializable]
        public class ХранилищеНастроек
        {
            public string ИмяПользователя;
            public string Сервер;
            public string Часть3ВебСсылки;
        }


        string path_ = "//НастройкаТСД.xml";
        string path;
        public ХранилищеНастроек Хранилище;
        Dictionary<string, string> СоостветствиеСервисов = new Dictionary<string, string>()
            {
                {"10.0.6","art-sql1"},
                {"10.0.30","adm-zheludkov"},
                {"10.0.36","khb-sql-sklad2"},
                {"10.0.94","irk-sql-sklad"},
                {"10.0.98","kras-sql-sklad"},
                {"10.0.138","nsb-sql-sklad2"},
                {"10.1.50","ekb-sql-sklad2"},
                {"10.1.161","rst-sql-sklad2"},
                {"10.2.1","smr-sql-sklad2"},
                {"10.2.34","kzn-sql-sklad2"},
                {"10.3.1","msk-sql-sklad2"},
                {"10.4.68","tula-sql-sklad2"},
                {"10.4.171","vld-sql-sklad"},
                {"10.10.35","adm-zheludkov"},
                {"192.168.","adm-zheludkov"}
            };

        public Настройки()
        {
            path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + path_;
            Хранилище = new ХранилищеНастроек();
        }


        public void Сохранить()
        {

            System.Xml.Serialization.XmlSerializer writer =
                new System.Xml.Serialization.XmlSerializer(typeof(ХранилищеНастроек));
            System.IO.FileStream file = System.IO.File.Create(path);
            writer.Serialize(file, Хранилище);
            file.Close();
        }

        public bool Загрузить()
        {
            if (!File.Exists(path)) return false;
            System.Xml.Serialization.XmlSerializer reader =
                new System.Xml.Serialization.XmlSerializer(typeof(ХранилищеНастроек));
            System.IO.StreamReader file = new System.IO.StreamReader(path);
            Хранилище = (ХранилищеНастроек)reader.Deserialize(file);
            file.Close();
            return true;
        }

        public bool ЗагрузитьСПроверкой()
        {
            if (!Загрузить()) return false;
            if (Хранилище.Сервер == null || Хранилище.Часть3ВебСсылки == null) return false;
            return true;
        }

        public string УзнатьСобственныйIP()
        {
            var ИмяЭтойМашины = Dns.GetHostName();
            var IpЭтойМашины = Dns.GetHostEntry(ИмяЭтойМашины).AddressList.First(x=>x.AddressFamily == AddressFamily.InterNetwork);

            return IpЭтойМашины.ToString();
        }

        public string ПолучитьПолнуюВебСсылку()
        {
            string МойАдрес = УзнатьСобственныйIP();
            var _Сервер = (from Соответствие
                            in СоостветствиеСервисов
                         where МойАдрес.Contains(Соответствие.Key)
                         select Соответствие.Value).FirstOrDefault();
            if (_Сервер == null) {
                (new Ошибка(String.Format("IP Адрес вашей сети {0} не найден в списке настроек, необходимо настроить соединение вручную", МойАдрес))).ShowDialog();
                return null;
            }
            if (!ЗагрузитьСПроверкой())
            {
                Хранилище.Сервер = _Сервер;
                Хранилище.Часть3ВебСсылки = Хранилище.Сервер.Contains("zheludkov") ? "zheludkov_sklad" : "WS_Sklad";
            }
            string Сервер = Хранилище.Сервер;
            string Порт = Сервер.Contains("zheludkov") ? "80" : "52081";
            string ПолнаяВебСсылка = "http://" + Сервер + ":" + Порт + "/" + Хранилище.Часть3ВебСсылки + "/ws/TSD.1cws";
            return ПолнаяВебСсылка;
        }





    }
}
