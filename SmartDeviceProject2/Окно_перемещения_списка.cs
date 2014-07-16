using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using СкладскойУчет;
using СкладскойУчет.СсылкаНаСервис;
using System.Net;

namespace СкладскойУчет
{
    public partial class Окно_перемещения_списка : Form
    {
        private Пакеты Обмен;
        public int КолонкаРучногоВыбора = 5; // по умолчанию ГУИД Товара находится в 5 колонке , но при операции Подтоварки он в 7 
        public ПоследовательностьОкон Последовательность;
        //private string АдресКуда = null;
        public List<string[]> КоллекцияСтрок = new List<string[]>();


        public Окно_перемещения_списка(ПоследовательностьОкон ПоследовательностьОкон)
        {
            InitializeComponent();
            Последовательность = ПоследовательностьОкон;
        }



        //-----------------методы для переопределения в наследуемом классе других операций---------
        public virtual ListViewItem ДобавитьТоварВСписок(string[][] Ответ)
        {
            return null;
        }
        public virtual bool ПроверитьКоличество(int Сканировано, int Количество)
        {
            return Сканировано > Количество;
        }

        public virtual void _Назад()
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();//Нажали назад, необходимо попасть на предыдущее окно, думаю можно и самому решить этот вопрос без обращения к серверу

        }

        public virtual void _Далее()
        {
            DialogResult РезультатОкна = ПолучитьАдресКуда();
            if (РезультатОкна == DialogResult.Cancel) return;
            string Адрес = (from string[] s in Последовательность.ОтветСервера where s[0] == "ТекстДЯ" select s[1]).FirstOrDefault();
            if (Адрес == null) return;
            СформироватьДокументВ1С(Адрес);
            if (Последовательность.ОтветСервера == null) return;
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        public virtual void СформироватьТаблицуОтправки(string АдресКуда)
        {
            КоллекцияСтрок.Clear();
            foreach (ListViewItem l in СписокПеремещения.Items)
            {
                string strCount = l.SubItems[1].Text;
                if (strCount == "0") continue;
                string GUID = l.SubItems[КолонкаРучногоВыбора].Text;
                ДобавитьСтроку(АдресКуда, GUID, strCount);

            }

        }
        public virtual void ПоказатьИнфооТоваре(ListViewItem НайденСкан)
        {
            string ВыбранноеЗначение = НайденСкан.SubItems[3].Text;
            Информация.Text = ВыбранноеЗначение;
        }


        //------------------------------------------------------------------------


        public void ДобавитьСтроку(params string[] args)
        {
            КоллекцияСтрок.Add(args);
        }


        public void СформироватьДокументВ1С(string Адрес)
        {
            Обмен = new Пакеты("СформироватьДокумент" + Последовательность.Операция);
            СформироватьТаблицуОтправки(Адрес);
            ОтправитьТаблицу();
        }



        private void ОтправитьТаблицу()
        {
            if (КоллекцияСтрок.Count() == 0)
            {
                Последовательность.ОтветСервера = Обмен.Послать(ТекстДЯ.Text, null);
                return;
            }
            Последовательность.ОтветСервера = Обмен.Послать(ТекстДЯ.Text, КоллекцияСтрок.ToArray());
        }

        private void ПриНажатииНаКнопку(object sender, EventArgs Аргументы)
        {
            Button Кнопка = (Button)sender;
            switch (Кнопка.Name)
            {
                case "Назад":
                    _Назад();
                    return;
                case "Далее":
                    _Далее();
                    return;
            }
            MethodInfo method = this.GetType().GetMethod("_" + Кнопка.Name);
            if (method != null)
                method.Invoke(this, null);
        }

        private void Окно_выбора_из_списка_KeyDown(object sender, KeyEventArgs e)
        {
            if (РаботаСоСканером.НажатаКлавишаСкан(e))
            {
                e.Handled = true;
                string СтрокаСкан = РаботаСоСканером.Scan();
                if (СтрокаСкан.Length != 0)
                {
                    СканТовара(СтрокаСкан);
                }
                return;
            }

            foreach (var ЭлементФормы in this.Controls)
                if (ЭлементФормы is Button)
                {
                    Button Кнопка = (Button)ЭлементФормы;
                    if ((char)Кнопка.Text[0] == (char)e.KeyValue)
                    {
                        Кнопка.Focus();
                        ПриНажатииНаКнопку(Кнопка, new EventArgs());
                        return;
                    }
                }


            if (РаботаСоСканером.НажатаПраваяПодэкраннаяКлавиша(e))
            {
                _Далее();
            }
            if (РаботаСоСканером.НажатаЛеваяПодэкраннаяКлавиша(e))
            {
                _Назад();
            }

        }

        private void СканТовара(string СтрокаСкан)
        {
            ListViewItem НайденСкан = НайтиСкан(СтрокаСкан);
            if (НайденСкан == null)
            {
                Обмен = new Пакеты(Последовательность.Операция + "НайтиТовар");
                var Ответ = Обмен.ПослатьСтроку(СтрокаСкан);
                if (Ответ == null) return;
                string Поиск = (from string[] строка in Ответ where строка[0] == "Товар" select строка[1]).FirstOrDefault();
                if (Поиск == null) { Инфо.ОшибкаТоварНеНайден(); return; }
                НайденСкан = НайтиСкан(Поиск);
                if (НайденСкан != null)
                {
                    НайденСкан.SubItems.Add(СтрокаСкан);
                }
                else
                {
                    НайденСкан = ДобавитьТоварВСписок(Ответ);
                }
            }
            if (НайденСкан == null) { Инфо.ОшибкаТоварНеНайден(); return; }
            НайденСкан.Selected = true;
            ПоказатьИнфооТоваре(НайденСкан);
            ПрибавитьКоличество(НайденСкан, 1, true);

        }

        private DialogResult ПолучитьАдресКуда()
        {
            Обмен = new Пакеты("Нет операции");
            Последовательность.ОтветСервера = Обмен.ПодготовитьСтроку("ТекстИнструкции", "Необходимо сканировать адрес/ячейку для перемещения отсканированного товара с " + ТекстДЯ.Text);
            Окно_сканирования_адреса ОкноАдреса = new Окно_сканирования_адреса(Последовательность);
            ОкноАдреса.ВернутьСкан = true;// не обращаться к вебсервису
            DialogResult РезультатОкна = ОкноАдреса.ShowDialog();
            return РезультатОкна;
        }


        private void ПрибавитьКоличество(ListViewItem НайденСкан, int Прибавить, bool Прибавлять)
        {
            int Сканировано = int.Parse(НайденСкан.SubItems[1].Text);
            int Количество = int.Parse(НайденСкан.SubItems[0].Text);
            Сканировано = Прибавлять ? Сканировано + Прибавить : Прибавить;
            if (ПроверитьКоличество(Сканировано, Количество)) { Инфо.Ошибка("Нехватает количества"); return; }
            НайденСкан.SubItems[1].Text = String.Format("{0}", Сканировано);

        }

        private ListViewItem НайтиСкан(string СтрокаСкан)
        {
            var Поиск = from ListViewItem s in СписокПеремещения.Items where СовпадаетEAN(СтрокаСкан, s) select s;
            return Поиск.FirstOrDefault();
        }

        private bool СовпадаетEAN(string СтрокаСкан, ListViewItem s)
        {

            for (int НомерКолонки = КолонкаРучногоВыбора - 1 ; НомерКолонки < s.SubItems.Count; НомерКолонки++)
            {

                if (s.SubItems[НомерКолонки].Text == СтрокаСкан) return true;

            }
            return false;
        }

        private void Окно_выбора_из_списка_Load(object sender, EventArgs e)
        {
            Информация.Text = "";
            ЭлементыФормыЗаполнения ЭлементыФормы = new ЭлементыФормыЗаполнения();
            ЭлементыФормы.Инструкция = this.Инструкция;
            ЭлементыФормы.СписокВыбора = this.СписокПеремещения;
            ЭлементыФормы.ТекстДЯ = this.ТекстДЯ;
            ЭлементыФормы.Пользователь = this.Пользователь;
            ЗаполнениеЭлементовФормы.ЗаполнитьФорму(ЭлементыФормы, ref Последовательность.ОтветСервера, ref КолонкаРучногоВыбора);
            try
            {
                var ВыбраннаяСтрока = СписокПеремещения.Items[0];
                if (ВыбраннаяСтрока == null) return;
                ПоказатьИнфооТоваре(ВыбраннаяСтрока);
            }
            catch (Exception) { }

        }

        private void СписокПеремещения_SelectedIndexChanged(object sender, EventArgs e)
        {
            var ВыбраннаяСтрока = СписокПеремещения.FocusedItem;
            if (ВыбраннаяСтрока == null) return;
            ПоказатьИнфооТоваре(ВыбраннаяСтрока);
        }

        private void СписокПеремещения_ItemActivate(object sender, EventArgs e)
        {
            var ВыбраннаяСтрока = СписокПеремещения.FocusedItem;
            if (ВыбраннаяСтрока == null) return;
            ПоказатьИнфооТоваре(ВыбраннаяСтрока);
            ВводКоличества ОкноВвода = new ВводКоличества("Введите количество товара");
            ОкноВвода.ShowDialog();
            int Количество = ОкноВвода.Количество_;
            ПрибавитьКоличество(ВыбраннаяСтрока, Количество, false);
        }
    }
}