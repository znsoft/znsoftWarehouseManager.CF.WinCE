using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using СкладскойУчет.СсылкаНаСервис;
using System.Windows.Forms;
using СкладскойУчет.Сеть;
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
            Инфо.Операция = операция;
            Соединение = СоединениеВебСервис.ПолучитьСервис();
        }

        public Byte[] UpdateFirmware(){
               return Соединение.Сервис.updatefirmware(СоединениеВебСервис.НомерВерсии);
        }



        public string[][] ПодготовитьСтроку(params string[] args)
        {
            return new string[1][] { args };
        }

        public string[][] Послать(string Доп, string[][] СписокСтрок)
        {
            try
            {
                var ОтветСервера = Соединение.Сервис.Обмен(Операция, Доп, СписокСтрок);
                if (ОтветСервера == null) return null;
                var ПоискОшибок = from СтрокаКомманды in ОтветСервера where СтрокаКомманды[0] == "Обновить" || СтрокаКомманды[0] == "Ошибка" || СтрокаКомманды[0] == "ЗавершитьСеанс" select СтрокаКомманды;
                if (ПоискОшибок.Count() == 0) return ОтветСервера;
                string ТекстОшибок = "";
                bool ЗавершитьСеанс = false;
                bool Обновить = false;
                foreach (string[] ОшибкаТекст in ПоискОшибок)
                {
                    if (ОшибкаТекст[0] == "Обновить") Обновить = true;
                    if (ОшибкаТекст[0] == "ЗавершитьСеанс") ЗавершитьСеанс = true;
                    ТекстОшибок = ТекстОшибок + ОшибкаТекст[1];
                }
                Инфо.Ошибка(ТекстОшибок);
                if (Обновить)
                {
                    if (Обновление.ПроверитьОбновление())
                    {
                        Application.Exit();
                        return null;
                    }
                }
                if (ЗавершитьСеанс) Application.Exit();

                return null;// ОтветСервера;
            }
            catch (System.Net.WebException eWeb)
            {
                
                System.Net.HttpWebResponse Resp = eWeb.Response as System.Net.HttpWebResponse;
                string ErrorText = (Resp == null) ? eWeb.Status.ToString() : Resp.StatusDescription;
                if (ErrorText.Contains("Unauthorized"))
                {
                    Инфо.Ошибка("Ошибка соединения, Не удалось пройти авторизацию на сервере.");
                }
                else
                {
                    Инфо.Ошибка("Ошибка сети:" + eWeb.Message + " . " + ErrorText);
                }
                return null;
            }
            catch (System.Exception e)
            {
                Инфо.Ошибка(e.Message );
                return null;

            }
        }

        public string[][] ПослатьСтроку(string Доп)
        {
            return Послать(Доп, null);
        }


        public string[][] ПослатьСтроку(params string[] args)
        {
            return Послать(СоединениеВебСервис.ИдентификаторСоединения, ПодготовитьСтроку(args));
        }



    }
}
