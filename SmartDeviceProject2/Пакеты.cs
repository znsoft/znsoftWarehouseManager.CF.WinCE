using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using СкладскойУчет.СсылкаНаСервис;
namespace СкладскойУчет
{
    class Пакеты
    {
        public СоединениеВебСервис Соединение;
        public string Операция;
        //

        public Пакеты(string операция)
        {

            this.Операция = операция;
            Соединение = СоединениеВебСервис.ПолучитьСервис();
        }





        string[][] ПодготовитьСтроку(params string[] args)
        {
            return new string[1][] { args };
        }

        public string[][] Послать(string Доп, string[][] СписокСтрок)
        {    
            try
            {
                var ОтветСервера = Соединение.Сервис.Обмен(Операция, Доп, СписокСтрок);
                if (ОтветСервера == null) return null;
                var ПоискОшибок = from СтрокаКомманды in ОтветСервера where СтрокаКомманды[0] == "Ошибка" select СтрокаКомманды[1];
                if(ПоискОшибок.Count() == 0) return ОтветСервера;
                string ТекстОшибок = "";
                foreach(string ОшибкаТекст in ПоискОшибок)
                    ТекстОшибок = ТекстОшибок + ОшибкаТекст;
                Ошибка ОкноОшибки = new Ошибка(ТекстОшибок);
                ОкноОшибки.ShowDialog();
                return null;// ОтветСервера;
            }

            catch (System.Exception e)
            {
                Ошибка ОкноОшибки = new Ошибка(e.Message);
                ОкноОшибки.ShowDialog();
                return null;

            }
        }

        public string[][] ПослатьСтроку(string Доп)
        {
            return Послать(Доп, null);
        }


        public string[][] ПослатьСтроку(params string[] args)
        {
            return Послать(null, ПодготовитьСтроку(args));
        }



    }
}
