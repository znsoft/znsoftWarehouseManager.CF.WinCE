using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using СкладскойУчет;
using СкладскойУчет.СсылкаНаСервис;
using System.Net;


namespace СкладскойУчет
{
    public class Окно_Инвентаризации_Списка : Окно_перемещения_списка
    {
        public Окно_Инвентаризации_Списка(ПоследовательностьОкон ПоследовательностьОкон)
            : base(ПоследовательностьОкон)
        {

        }


        public override ListViewItem ДобавитьТоварВСписок(string[][] Ответ)
        {
            var Выборка = from string[] строка in Ответ where строка[0] == "Товар" select строка;
            if (Выборка.Count() > 1) {
                Выборка = ВыбратьТоварИзМножества_(Выборка, Ответ);
                if (Выборка == null) return null;
            }
            string[] Строка = Выборка.FirstOrDefault();
            if (Строка == null) { Инфо.ОшибкаТоварНеНайден(); return null; }

            ListViewItem НоваяСтрока = new ListViewItem();
            НоваяСтрока.Text = "0";
            НоваяСтрока.SubItems.Add("0");
            for (int i = 2; i < Строка.Count(); i++)
            {
                try
                {
                    НоваяСтрока.SubItems.Add(Строка[i]);
                }
                catch (Exception e) {
                    НоваяСтрока.SubItems.Add(e.Message.ToString());
                }
            }

            СписокПеремещения.Items.Add(НоваяСтрока);
            НоваяСтрока.Selected = true;
            
            return НоваяСтрока;
        }


        private string ВыбратьТоварИзМножества(IEnumerable<string[]> Выборка)
        {
            ИнтерактивныйВыборТовара ОкноВыбора = new ИнтерактивныйВыборТовара(Последовательность);
            ListView СписокВыбора = ОкноВыбора.СписокВыбора;
            СписокВыбора.Columns.Add("Код", 70, HorizontalAlignment.Left);
            СписокВыбора.Columns.Add("Товар", 160, HorizontalAlignment.Left);
            ОкноВыбора.Инструкция.Text = "Выберите товар из списка";
            //ОкноВыбора.Пользователь.Text = 
            foreach (string[] Товар in Выборка)
            {
                ListViewItem НоваяСтрока = new ListViewItem();
                НоваяСтрока.Text = Товар[2];//Код
                НоваяСтрока.SubItems.Add(Товар[3]);//Наименование
                НоваяСтрока.SubItems.Add(Товар[1]);//Гуид
                СписокВыбора.Items.Add(НоваяСтрока);
            }
            DialogResult Результат = ОкноВыбора.ShowDialog();
            if (Результат == DialogResult.Cancel) return null;
            return ОкноВыбора.ВыбранГуид;
        }

        private IEnumerable<string[]> ВыбратьТоварИзМножества_(IEnumerable<string[]> Выборка, string[][] Ответ)
        {
            string ВыбранГуид = ВыбратьТоварИзМножества(Выборка);
            return from string[] строка in Ответ where строка[1] == ВыбранГуид select строка;
        }



        public override bool ПроверитьКоличество(int Сканировано, int Количество)
        {
            return false;
        }

        public override void _Далее()
        {
            СформироватьДокументВ1С("");
            if (Последовательность.ОтветСервера == null) return;
            this.DialogResult = DialogResult.Retry;
            this.Close();
        }

        public override void _Назад()
        {
            Пакеты Обмен = new Пакеты("СнятьБлокировкуИнвентаризации");
            Обмен.ПослатьСтроку(ТекстДЯ.Text);
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
        
        
        public override void СформироватьТаблицуОтправки(string АдресКуда)
        {

            КоллекцияСтрок.Clear();
            foreach (ListViewItem l in СписокПеремещения.Items)
            {
                string strCount = l.SubItems[1].Text;
                string GUID = l.SubItems[НомерКонокиГУИД].Text;
                ДобавитьСтроку(GUID, strCount);

            }
        }

    }
}
