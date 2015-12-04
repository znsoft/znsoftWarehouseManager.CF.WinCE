using System;
using System.IO;
using System.Reflection;
using System.Xml.Serialization;

namespace СкладскойУчет
{
    public class Настройки
    {

        [Serializable]
        public class ХранилищеНастроек
        {
            public string ИмяПользователя;
            public string Сервер;
        }

        string path_ = "НастройкаТСД.xml";

        string path;
        public ХранилищеНастроек Хранилище;

        public Настройки()
        {
            path = Настройки.ПолучитьПутьКЛокальномуФайлу(path_);
            Хранилище = new ХранилищеНастроек();
        }

        public static string ПолучитьПутьКЛокальномуФайлу(string pt)
        {
            string FullDir = Assembly.GetCallingAssembly().ManifestModule.FullyQualifiedName;
            var FI = new FileInfo(FullDir);
            return Path.Combine(FI.Directory.FullName, pt);
        }

        public void Сохранить()
        {
            using (FileStream file = File.Create(path))
            {
                XmlSerializer writer = new XmlSerializer(typeof(ХранилищеНастроек));
                writer.Serialize(file, Хранилище);
            }
        }

        public bool Загрузить()
        {
            if (!File.Exists(path)) return false;

            using (StreamReader file = new StreamReader(path))
            {
                XmlSerializer reader = new XmlSerializer(typeof(ХранилищеНастроек));
                Хранилище = (ХранилищеНастроек)reader.Deserialize(file);
            }

            return true;
        }

        public string СформироватьСсылку()
        {
            if (String.IsNullOrEmpty(Хранилище.Сервер)) return null;

            string Сервер = Хранилище.Сервер;

            string ПолнаяВебСсылка = "http://" + Сервер + ":52081/WS_Sklad/hs/forTSD/";
            return ПолнаяВебСсылка;
        }

    }
}
