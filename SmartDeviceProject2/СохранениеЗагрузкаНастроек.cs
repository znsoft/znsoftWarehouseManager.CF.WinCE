using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Xml.Serialization;

namespace СкладскойУчет
{
    class Настройки
    {

        [Serializable]
        public class ХранилищеНастроек
        {
            public string ИмяПользователя;
            public string Сервер;
            public string ВебСервис;
        }


        string path_ = "//НастройкаТСД.xml";
        string path;
        public ХранилищеНастроек Хранилище;


        public Настройки() {
            path = Environment.GetFolderPath(Environment.SpecialFolder.Personal) + path_;
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

        public void Загрузить()
        {
            if (!File.Exists(path)) return;
            System.Xml.Serialization.XmlSerializer reader =
                new System.Xml.Serialization.XmlSerializer(typeof(ХранилищеНастроек));
            System.IO.StreamReader file = new System.IO.StreamReader(path);
            Хранилище = (ХранилищеНастроек)reader.Deserialize(file);
            file.Close();
        }


    }
}
