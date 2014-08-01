using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace СкладскойУчет
{
    class Инфо
    {
        public static string СчитанныйШтрихКод;
        public static string Операция;
        public static string Окно;
        public static string ИмяЭтогоФайла;
        public static string АргументЗапуска;

        public static void ПолучениеИнформации(string СтрокаСкан, TextBox СписокИнформации, TabControl Табулятор)
        {

            Табулятор.SelectedIndex = 1;
            СписокИнформации.Text = "Получение информации...";
            Табулятор.Update();

            var Обмен = new Пакеты("Информация");
            var ОтветСервера = Обмен.ПослатьСтроку(СтрокаСкан);

            if (ОтветСервера == null || ОтветСервера.Count() == 0)
            {
                СписокИнформации.Text = "Информация по коду не найдена";
                return;
            }
            string Информация = "";
            foreach (var СтрокаОтвета in ОтветСервера)
            {
                Информация = Информация + СтрокаОтвета[1].Replace("\n\n", "\r\n") + "\r\n";
            }
            СписокИнформации.Text = Информация;
        }

        public static void Ошибка(string ТекстОшибки) {
            (new Ошибка(ТекстОшибки)).ShowDialog();
        
        }

        public static void ОшибкаТоварНеНайден()
        {
            Инфо.Ошибка("Товар не найден на полке");
        }




    }
}
