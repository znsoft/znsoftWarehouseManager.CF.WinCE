using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Reflection;
using СкладскойУчет;
using СкладскойУчет.СсылкаНаСервис;
using System.Net;
using СкладскойУчет.Оборудование;

namespace СкладскойУчет
{
    public partial class Окно_перемещения_списка : Form
    {

 

        private Пакеты Обмен;
        public List<ЭлементДерева> ПолныйСписок = new List<ЭлементДерева>();
        public Dictionary<string, int> СоответствиеКолонок = new Dictionary<string, int>();
        public int НомерКонокиГУИД = 5; // по умолчанию ГУИД Товара находится в 5 колонке , но при операции Подтоварки он в 7 
        public ПоследовательностьОкон Последовательность;
        //private string АдресКуда = null;
        public bool СписокПустой = true;

        public List<string[]> КоллекцияСтрок = new List<string[]>();


        public Окно_перемещения_списка(ПоследовательностьОкон ПоследовательностьОкон)
        {
            InitializeComponent();
            Последовательность = ПоследовательностьОкон;

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

        //-----------------методы для переопределения в наследуемом классе других операций---------
        public virtual ListViewItem ДобавитьТоварВСписок(string[][] Ответ)
        {
            if (!СписокПустой) return null;//Случай с А01-01-1 идем добавлять товар 
            var Выборка = from string[] строка in Ответ where строка[0] == "Товар" select строка;
            if (Выборка.Count() > 1)
            {
                Выборка = ВыбратьТоварИзМножества_(Выборка, Ответ);
                if (Выборка == null) return null;
            }
            string[] Строка = Выборка.FirstOrDefault();
            if (Строка == null) { Инфо.ОшибкаТоварНеНайден(); return null; }

            ListViewItem НоваяСтрока = new ListViewItem();
            НоваяСтрока.Text = Строка[4];
            НоваяСтрока.SubItems.Add("0");
            for (int i = 2; i < Строка.Count(); i++)
            {
                try
                {
                    if (i == 4) НоваяСтрока.SubItems.Add(Строка[2]); else НоваяСтрока.SubItems.Add(Строка[i]);
                }
                catch (Exception e)
                {
                    НоваяСтрока.SubItems.Add(e.Message.ToString());
                }
            }

            СписокПеремещения.Items.Add(НоваяСтрока);
            НоваяСтрока.Selected = true;

            return НоваяСтрока;

            //return null;
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
            this.DialogResult = DialogResult.Retry;
            this.Close();
        }

        public virtual void СформироватьТаблицуОтправки(string АдресКуда)
        {
            КоллекцияСтрок.Clear();
            foreach (ListViewItem l in СписокПеремещения.Items)
            {
                string strCount = l.SubItems[1].Text;
                if (strCount == "0") continue;
                string GUID = l.SubItems[НомерКонокиГУИД].Text;
                ДобавитьСтроку(АдресКуда, GUID, strCount);

            }

        }
        public virtual void ПоказатьИнфооТоваре(ListViewItem НайденСкан)
        {
            string ВыбранноеЗначение = НайденСкан.SubItems[СоответствиеКолонок["Товар"]].Text;
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
            //MethodInfo method = this.GetType().GetMethod("_" + Кнопка.Name);
            //if (method != null)
            //    method.Invoke(this, null);
        }

        private void Окно_выбора_из_списка_KeyDown(object sender, KeyEventArgs e)
        {
            if (ПолеВвода.Visible) {


                if ((e.KeyCode == System.Windows.Forms.Keys.Enter) || РаботаСоСканером.НажатаКлавишаСкан(e))
                {
                    СписокПеремещения.Focus();
    
                }
                return; }

            if (РаботаСоСканером.НажатаКлавишаСкан(e))
            {
                Сканировать(e);
                return;
            }



            foreach (var ЭлементФормы in this.Controls)
                if (ЭлементФормы is Button)
                {
                    Button Кнопка = (Button)ЭлементФормы;
                    if ((char)Кнопка.Text[1] == (char)e.KeyValue)
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

        private void Сканировать(KeyEventArgs e)
        {
            e.Handled = true;
            string СтрокаСкан = РаботаСоСканером.Scan();
            if (СтрокаСкан.Length != 0)
            {
                СканТовара(СтрокаСкан);
            }
        }

        private void СканТовара(string СтрокаСкан)
        {
            ListViewItem НайденСкан = НайтиСкан(СтрокаСкан);
            if (НайденСкан == null && СтрокаСкан.Length == 8) НайденСкан = НайтиСкан(СтрокаСкан.Substring(0,7));//скан кода товара по базе без контрольной суммы, костыль
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
                    try
                    {
                        НайденСкан.SubItems.Add(СтрокаСкан);
                    }
                    catch (Exception) { }
                }
                else
                {
                    НайденСкан = ДобавитьТоварВСписок(Ответ);
                }
            }
            if (НайденСкан == null) { Инфо.ОшибкаТоварНеНайден(); return; }

            СделатьВидимым(НайденСкан);
            ПоказатьИнфооТоваре(НайденСкан);
            ПрибавитьКоличество(НайденСкан, 1, true);

        }

        private void СделатьВидимым(ListViewItem НайденСкан)
        {
            СписокПеремещения.EnsureVisible(НайденСкан.Index);
            НайденСкан.Selected = true;

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


        private string ВыбратьТоварИзМножества(IEnumerable<ListViewItem> Выборка)
        {
            ИнтерактивныйВыборТовара ОкноВыбора = new ИнтерактивныйВыборТовара(Последовательность);
            ListView СписокВыбора = ОкноВыбора.СписокВыбора;
            СписокВыбора.Columns.Add("Код", 70, HorizontalAlignment.Left);
            СписокВыбора.Columns.Add("Товар", 160, HorizontalAlignment.Left);
            ОкноВыбора.Инструкция.Text = "Выберите товар из списка";
            foreach (ListViewItem Товар in Выборка)
            {
                ListViewItem НоваяСтрока = new ListViewItem();
                НоваяСтрока.Text = Товар.SubItems[СоответствиеКолонок["Код"]].Text;//Код
                НоваяСтрока.SubItems.Add(Товар.SubItems[СоответствиеКолонок["Товар"]].Text);//Наименование
                НоваяСтрока.SubItems.Add(Товар.SubItems[НомерКонокиГУИД].Text);//Гуид
                СписокВыбора.Items.Add(НоваяСтрока);
            }
            DialogResult Результат = ОкноВыбора.ShowDialog();
            if (Результат == DialogResult.Cancel) return null;
            return ОкноВыбора.ВыбранГуид;
        }


        private ListViewItem НайтиСкан(string СтрокаСкан)
        {
            var Поиск = НайтиEANGUID(СтрокаСкан);
            if (Поиск.Count() > 1) Поиск = ВыбратьТоварИзМножества_(Поиск);
            if (Поиск == null)return null;
            return Поиск.FirstOrDefault();
        }

        private IEnumerable<ListViewItem> НайтиEANGUID(string СтрокаСкан)
        {
            var Поиск = from ListViewItem s in СписокПеремещения.Items where СовпадаетEAN(СтрокаСкан, s) select s;
            return Поиск;
        }

        private IEnumerable<ListViewItem> ВыбратьТоварИзМножества_(IEnumerable<ListViewItem> Поиск)
        {
            string ВыбранГуид = ВыбратьТоварИзМножества(Поиск);
            return НайтиEANGUID(ВыбранГуид);

        }

        private bool СовпадаетEAN(string СтрокаСкан, ListViewItem s)
        {

            for (int НомерКолонки = НомерКонокиГУИД - 1 ; НомерКолонки < s.SubItems.Count; НомерКолонки++)
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
            ЗаполнениеЭлементовФормы.ЗаполнитьФорму(ЭлементыФормы, ref Последовательность.ОтветСервера, ref НомерКонокиГУИД, ref СоответствиеКолонок, ref ПолныйСписок);
            СписокПустой = СписокПеремещения.Items.Count == 0;//на случай работы в режиме А01-01-1

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
            ВвестиКоличествоВручную(ВыбраннаяСтрока,e );
        }

        private void ВвестиКоличествоВручную(ListViewItem ВыбраннаяСтрока, EventArgs e)
        {
            int r = СписокПеремещения.Columns[0].Width;
            int l = СписокПеремещения.Columns[1].Width;
            Point p = РасширениеСписка.GetItemPosition(СписокПеремещения.Handle, ВыбраннаяСтрока.Index);
            p.X += r;
            ПолеВвода.Location = p;
            ПолеВвода.Width = l;
            ПолеВвода.Visible = true;
            ПолеВвода.Text = ВыбраннаяСтрока.SubItems[1].Text;
            ПолеВвода.Focus();
            ПолеВвода.SelectAll();
 
        }

        private void ПолеВвода_LostFocus(object sender, EventArgs e)
        {
            
            ПолеВвода.Visible = false;
            var ВыбраннаяСтрока = СписокПеремещения.FocusedItem;
            if (ВыбраннаяСтрока == null) return;
            int Количество = int.Parse(ПолеВвода.Text);
            ПрибавитьКоличество(ВыбраннаяСтрока, Количество, false);

        }

        private void ПолеВвода_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar));
        }

    
    }



}