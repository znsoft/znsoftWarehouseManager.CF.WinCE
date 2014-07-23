using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Xml.Serialization;
using System.Net;
using System.Net.Sockets;
using System.Reflection;
using System.Diagnostics;

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


        string path_ = "НастройкаТСД.xml";
        string СкладскойУчетОбновление = "СкладскойУчетОбновление.exe";
        string СкладскойУчет = "СкладскойУчет.exe";
        string path;
        string ИмяЭтогоФайла;
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
                {"10.2.33","kzn-sql-sklad2"},
                {"10.2.34","kzn-sql-sklad2"},
                {"10.3.1","msk-sql-sklad2"},
                {"10.4.68","tula-sql-sklad2"},
                {"10.4.171","vld-sql-sklad"},
                {"10.5.102","cht-sql-sklad"},
                {"10.10.35","adm-zheludkov"}
                
            };

        public Настройки()
        {
            ИмяЭтогоФайла = Assembly.GetCallingAssembly().ManifestModule.FullyQualifiedName;
            path = ПолучитьПутьКЛокальномуФайлу(path_);
            Хранилище = new ХранилищеНастроек();
        }

        public bool ПроверитьОбновление()
        {
            string АргументыЭтогоПроцесса = Process.GetCurrentProcess().StartInfo.Arguments;
            if (ИмяЭтогоФайла.Contains(СкладскойУчетОбновление))
            {
                АргументыЭтогоПроцесса = ПолучитьПутьКЛокальномуФайлу(СкладскойУчет);
                try
                {
                    File.Delete(АргументыЭтогоПроцесса);
                    File.Copy(ИмяЭтогоФайла, АргументыЭтогоПроцесса);
                    return false;
                }
                catch (Exception) { }
            }
            try
            {
                Пакеты Обмен = new Пакеты("");
                Byte[] Прошивка = Обмен.UpdateFirmware();
                if (Прошивка == null || Прошивка.Count() == 0) return false;
                string НовыйИсполняемыйФайл = ПолучитьПутьКЛокальномуФайлу(СкладскойУчетОбновление);
                СохранитьВФайл(НовыйИсполняемыйФайл, Прошивка);

                var pr = new Process();
                pr.StartInfo.FileName = НовыйИсполняемыйФайл;
                pr.StartInfo.Arguments = ИмяЭтогоФайла;
                pr.Start();
                return true;
            }
            catch (Exception) {}// System.Windows.Forms.MessageBox.Show(e.Message); }
            return false;
        }



        public string ПолучитьПутьКЛокальномуФайлу(string pt)
        {
            string FullDir = Assembly.GetCallingAssembly().ManifestModule.FullyQualifiedName;
            var FI = new FileInfo(FullDir);
            return Path.Combine(FI.Directory.FullName, pt);
        }


        public void СохранитьВФайл(string Файл, Byte[] Данные)
        {
            FileStream file = System.IO.File.Create(Файл);
            file.Write(Данные, 0, Данные.Count());
            file.Close();
        }


        public void Сохранить()
        {

            System.Xml.Serialization.XmlSerializer writer =
                new System.Xml.Serialization.XmlSerializer(typeof(ХранилищеНастроек));
            FileStream file = System.IO.File.Create(path);
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
            try
            {
                if (!Загрузить()) return false;
                if (Хранилище.Сервер == null || Хранилище.Часть3ВебСсылки == null) return false;
                return true;
            }
            catch (Exception) { return false; }
        }

        public string УзнатьСобственныйIP()
        {
            var ИмяЭтойМашины = Dns.GetHostName();
            var IpЭтойМашины = Dns.GetHostEntry(ИмяЭтойМашины).AddressList.First(x => x.AddressFamily == AddressFamily.InterNetwork);
            return IpЭтойМашины.ToString();
        }

        public string ПолучитьПолнуюВебСсылку()
        {
            string МойАдрес = УзнатьСобственныйIP();
            var _Сервер = (from Соответствие
                            in СоостветствиеСервисов
                           where МойАдрес.Contains(Соответствие.Key)
                           select Соответствие.Value).FirstOrDefault();
            if (_Сервер == null)
            {
                Инфо.Ошибка(String.Format("IP Адрес вашей сети {0} не найден в списке настроек, необходимо настроить соединение вручную", МойАдрес));
                Хранилище.Часть3ВебСсылки = "WS_Sklad";
                return null;
            }
            _Сервер = _Сервер + ".partner.ru";

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
