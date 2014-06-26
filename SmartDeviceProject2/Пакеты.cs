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

        public Пакеты(string операция)
        {

            this.Операция = операция;
            Соединение = СоединениеВебСервис.ПолучитьСервис();
        }

        string[][] ПодготовитьСтроку(params string[] args)
        {
            return new string[1][] { args };
        }


        string[][] Послать(string Доп, string[][] СписокСтрок)
        {    
            try
            {

                return Соединение.Сервис.Обмен(Операция,Доп, СписокСтрок);

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
