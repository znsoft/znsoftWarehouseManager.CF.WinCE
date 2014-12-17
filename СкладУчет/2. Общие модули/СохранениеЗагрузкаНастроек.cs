using System;
using System.IO;
using System.Reflection;

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

        public string СформироватьСсылку()
        {
            if (String.IsNullOrEmpty(Хранилище.Сервер)) return null;
            string Сервер = Хранилище.Сервер;
            string ПолнаяВебСсылка = "http://" + Сервер + ":52081/WS_Sklad/ws/TSD.1cws";
            return ПолнаяВебСсылка;
        }


    }
}
