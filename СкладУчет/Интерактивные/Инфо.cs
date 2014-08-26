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


        private static string ВыбратьТоварИзМножества(IEnumerable<String> Выборка)
        {
            ИнтерактивныйВыборТовара ОкноВыбора = new ИнтерактивныйВыборТовара(new ПоследовательностьОкон("ИнтерактивныйВыбор"));
            ListView СписокВыбора = ОкноВыбора.СписокВыбора;
            СписокВыбора.Columns.Add("", 1, HorizontalAlignment.Left);
            СписокВыбора.Columns.Add("Товар", 560, HorizontalAlignment.Left);
            ОкноВыбора.Инструкция.Text = "Выберите товар из списка";
            foreach (String Товар in Выборка)
            {
                ListViewItem НоваяСтрока = new ListViewItem();
                НоваяСтрока.Text = "";
                НоваяСтрока.SubItems.Add(Товар);//Наименование
                НоваяСтрока.SubItems.Add(Товар);//Guid
                СписокВыбора.Items.Add(НоваяСтрока);
            }
            DialogResult Результат = ОкноВыбора.ShowDialog();
            if (Результат == DialogResult.Cancel) return null;
            return ОкноВыбора.ВыбранГуид;
        }


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

            IEnumerable<String[]> ИнфоПоТовару = null;
            var ПоискИнтерактивногоВыбора = from СтрокаКомманды in ОтветСервера where СтрокаКомманды[0] == "ВыборТовара" group СтрокаКомманды by СтрокаКомманды[2] into g select g.Key;
            if (ПоискИнтерактивногоВыбора.Count() > 0)
            {
                string ВыбранТовар = ВыбратьТоварИзМножества(ПоискИнтерактивногоВыбора);
                if (ВыбранТовар != null) {
                    ИнфоПоТовару = from СтрокаКомманды in ОтветСервера where СтрокаКомманды[0] == "ВыборТовара" && СтрокаКомманды[2] == ВыбранТовар select СтрокаКомманды;
                } 
            }
            if (ИнфоПоТовару == null) ИнфоПоТовару = ОтветСервера;
            foreach (var СтрокаОтвета in ИнфоПоТовару)
                    Информация = Информация + СтрокаОтвета[1].Replace("\n\n", "\r\n") + "\r\n";
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
