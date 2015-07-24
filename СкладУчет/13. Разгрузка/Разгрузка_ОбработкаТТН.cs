using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace СкладскойУчет
{
    public partial class Разгрузка_ОбработкаТТН : Form
    {

        public class СтрокаСписокФилиалов
        {
            public string ФилиалСсылка;
            public string ФилиалНаименование;

            public string КоличествоЖдем;
            public string КоличествоПринято;

            public List<string> ГрузовыеМеста;

            public ListViewItem СтрокаСписка;

            public СтрокаСписокФилиалов(string _ФилиалСсылка, string _ФилиалНаименование, string _КоличествоЖдем, string _КоличествоПринято)
            {
                ФилиалСсылка = _ФилиалСсылка;
                ФилиалНаименование = _ФилиалНаименование;
                КоличествоЖдем = _КоличествоЖдем;
                КоличествоПринято = _КоличествоПринято;

                ГрузовыеМеста = new List<string>();

                СтрокаСписка = null;
            }
        }

        public class СписокФилиалов
        {
            public List<СтрокаСписокФилиалов> Список;
            public ListView ЭлементФормы;

            public СписокФилиалов(ListView _ЭлементФормы)
            {
                Список = new List<СтрокаСписокФилиалов>();
                ЭлементФормы = _ЭлементФормы;
            }


            public void Добавить(string _ФилиалСсылка, string _ФилиалНаименование, string _КоличествоЖдем, string _КоличествоПринято)
            {
                // проверим, что в списке нет данного филиала
                bool Добавлено = false;

                foreach (var tmp in Список)
                {
                    if (tmp.ФилиалСсылка == _ФилиалСсылка)
                    {
                        Добавлено = true;
                        break;
                    }
                }

                // добавим если нет
                if (!Добавлено)
                {
                    СтрокаСписокФилиалов Строка = new СтрокаСписокФилиалов(_ФилиалСсылка, _ФилиалНаименование, _КоличествоЖдем, _КоличествоПринято);
                    Список.Add(Строка);


                    string[] row = { Строка.ФилиалНаименование, Строка.КоличествоЖдем, Строка.КоличествоПринято };
                    ListViewItem НоваяСтрока = ЭлементФормы.Items.Add(new ListViewItem(row));

                    Строка.СтрокаСписка = НоваяСтрока;

                    ОтобразитьСтроку(Строка, false);
                }
            }

            public void ДобавитьГрузовоеМесто(string _ФилиалСсылка, string _ГрузовоеМесто)
            {
                foreach (var tmp in Список)
                {
                    if (tmp.ФилиалСсылка == _ФилиалСсылка)
                    { 
                        tmp.ГрузовыеМеста.Add(_ГрузовоеМесто);

                        tmp.КоличествоПринято = Convert.ToString(Convert.ToInt32(tmp.КоличествоПринято) + 1);
                        tmp.СтрокаСписка.SubItems[2].Text = tmp.КоличествоПринято;

                        ОтобразитьСтроку(tmp, true);

                        break;
                    }
                }
            }

            public void УдалитьГрузовоеМесто(string _ФилиалСсылка)
            {
                foreach (var tmp in Список)
                {
                    if (tmp.ФилиалСсылка == _ФилиалСсылка)
                    {
                        tmp.КоличествоПринято = Convert.ToString(Convert.ToInt32(tmp.КоличествоПринято) - 1);
                        tmp.СтрокаСписка.SubItems[2].Text = tmp.КоличествоПринято;

                        ОтобразитьСтроку(tmp, true);

                        break;
                    }
                }
            }


            private void ОтобразитьСтроку(СтрокаСписокФилиалов _Строка, bool _Позиционироваться)
            {

                if (_Строка.КоличествоЖдем == _Строка.КоличествоПринято)
                {
                    _Строка.СтрокаСписка.BackColor = Color.LightGreen;
                }
                else
                {
                    _Строка.СтрокаСписка.BackColor = Color.LightPink;
                }

                if (_Позиционироваться)
                {
                    _Строка.СтрокаСписка.Selected = true;
                    _Строка.СтрокаСписка.Focused = true;
                }

            }
        }


        private Пакеты Обмен;
        private string[][] ОтветСервера;

        private string НомерТС;

        private string ТТННомер;
        private string ТТНСсылка;

        private СписокФилиалов Филиалы;

        private СписокСотрудников Сотрудники;
        private DateTime ВремяНачала;


        // КОНСТРУКТОРЫ

        public Разгрузка_ОбработкаТТН(string _НомерТС, string _ТТННомер, string _ТТНСсылка)
        {
            InitializeComponent();

            Обмен = new Пакеты("Разгрузка");

            НомерТС   = _НомерТС;
            ТТННомер  = _ТТННомер;
            ТТНСсылка = _ТТНСсылка;

            Филиалы = new СписокФилиалов(lvСписокФилиалов);

            Сотрудники  = new СписокСотрудников();
            ВремяНачала = DateTime.Now;
        }


        // ОБРАБОТЧИКИ СОБЫТИЙ ФОРМЫ

        private void Разгрузка_ОбработкаТТН_Load(object sender, EventArgs e)
        {
            // заполним подсказку пользователю

            ПодсказкаПользователю.Text = НомерТС + "\n" + ТТННомер;

            ЗаполнитьСписокФилиалов();

            ЗаполнитьСписокСотрудников();
        }

        private void Разгрузка_ОбработкаТТН_KeyDown(object sender, KeyEventArgs e)
        {
            if (!e.Handled && РаботаСоСканером.НажатаКлавишаСкан(e))
            {
                СканированиеШК(e);
            }

            if (!e.Handled && e.KeyCode == System.Windows.Forms.Keys.F1) // поиск грузового места
            {
                НайтиГрузовоеМесто();
                e.Handled = true;
            }

            if (!e.Handled && e.KeyCode == System.Windows.Forms.Keys.F3) // редактирование списка сотрудников
            {
                СотрудникиРедактироватьСписок();
                e.Handled = true;
            }

            if (!e.Handled && e.KeyCode == System.Windows.Forms.Keys.F5) // обновить данные
            {
                ЗаполнитьСписокФилиалов();
                e.Handled = true;
            }

            if (!e.Handled && (РаботаСоСканером.НажатаПраваяПодэкраннаяКлавиша(e)))
            {
                _Далее();
                e.Handled = true;
            }

            if (!e.Handled && (РаботаСоСканером.НажатаЛеваяПодэкраннаяКлавиша(e)))
            {
                _Назад();
                e.Handled = true;
            }
        }


        // КНОПКИ

        private void Назад_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            _Назад();
            Cursor.Current = Cursors.Default;
        }

        private void Далее_Click(object sender, EventArgs e)
        { 
            _Далее();
        }

  
        // СЛУЖЕБНЫЕ ПРОЦЕДУРЫ

        public virtual void _Назад()
        {
            Form Окно = new Разгрузка_ВыборТТН();
            Окно.Show();

            this.Close();
        }

        public virtual void _Далее()
        {
            // запросить подтверждение

            string message = "Вы уверены, что хотите завершить разгрузку?";
            string caption = "Подтверждение";

            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result;

            // отобразить MessageBox.

            result = MessageBox.Show(message, caption, buttons, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);

            if (result != System.Windows.Forms.DialogResult.Yes)
            {
                return;
            }

           // предложим отредактировать список сотрудников

            СотрудникиРедактироватьСписок();

            // получим количество секунд

            TimeSpan РазностьДат = DateTime.Now - ВремяНачала;
            int КоличествоСекунд = Convert.ToInt32(РазностьДат.TotalSeconds);

            // сформируем параметры для передачи на сервер

            string[][] Параметры = new string[3][];

            // сотрудники

            Параметры[0] = new string[Сотрудники.Список.Count + 1];
            Параметры[0][0] = "мСотрудники"; // зададим наименование массива

            for (int i = 0; i < Сотрудники.Список.Count; i++)
            {
                Параметры[0][i + 1] = Сотрудники.Список[i].Ссылка;
            }

            // количество секунд

            Параметры[1] = new string[2];
            Параметры[1][0] = "чслКоличествоСекунд";
            Параметры[1][1] = Convert.ToString(КоличествоСекунд);

            // ссТТН

            Параметры[2] = new string[2];
            Параметры[2][0] = "ссТТН";
            Параметры[2][1] = ТТНСсылка;


            // передать данные на сервер

            Cursor.Current = Cursors.WaitCursor;
            ОтветСервера = Обмен.Послать("ОбработкаТТН_Завершить", Параметры);
            Cursor.Current = Cursors.Default;

            if (ОтветСервера == null) // ничего не делаем
            {
                return;
            }
            ////////////////////////////////////////////////////////////////

            if (ОтветСервера[0][0] == "ВыполненоУспешно")
            {
                РаботаСоСканером.Звук.Ок();
                this.Close();
            }
            else
            {
                РаботаСоСканером.Звук.Ошибка();
            }
        }

        private void СканированиеШК(KeyEventArgs e)
        {
            string СтрокаСкан = РаботаСоСканером.Scan();
            if (СтрокаСкан.Length != 0)
            {
                ОбработкаВводаМеста(СтрокаСкан);
                e.Handled = true;
            }
        }

        private void ОбработкаВводаМеста(string _Данные)
        {
            // проверим, что это место

            if (!_Данные.Substring(0, 3).Equals("mst"))
            {
                Инфо.Ошибка("Необходимо сосканировать ШК грузового места.");
                return;
            }

            string ТекущееМесто = _Данные.Substring(3);

            // проверим, что место еще не добавлено

            foreach(var tmpФилиал in Филиалы.Список)
            {
                foreach(var tmpМесто in tmpФилиал.ГрузовыеМеста)
                {
                    if (tmpМесто == ТекущееМесто)
                    {
                        // предложить удалить добавленное место
                        // ...

                        Инфо.Ошибка("Грузовое место уже присутствует в списке.");
                        return;
                    }
                }
            }

            // проверка места на сервере
            Cursor.Current = Cursors.WaitCursor;
            ОтветСервера = Обмен.ПослатьСтроку("ОбработкаТТН_Сканирование", ТТНСсылка, ТекущееМесто);
            Cursor.Current = Cursors.Default;

            if (ОтветСервера == null) return;

            // обработка ответа сервера

            foreach (string[] str in ОтветСервера)
            {
                if (str[0] == "Ждем")
                {
                    Филиалы.ДобавитьГрузовоеМесто(str[1], ТекущееМесто);

                    РаботаСоСканером.Звук.Ок();
                }
                else
                {
                    Филиалы.Добавить("", "НЕ ОПРЕДЕЛЕН", "0", "0");

                    Филиалы.ДобавитьГрузовоеМесто("", ТекущееМесто);

                    РаботаСоСканером.Звук.Ошибка();
                }

            }
        }

        private void СотрудникиРедактироватьСписок()
        {            
            ФормаВыбораСотрудников фСотрудники = new ФормаВыбораСотрудников(Сотрудники);

            DialogResult d = фСотрудники.ShowDialog();

            if (d == DialogResult.OK)
            {
                Сотрудники = фСотрудники.Список;

                РаботаСоСканером.Звук.Ок(); // список отредактирован
            }
        }

        private void ЗаполнитьСписокФилиалов()
        {
            // сбросим список филиалов

            lvСписокФилиалов.Items.Clear();

            Филиалы = new СписокФилиалов(lvСписокФилиалов);

            // получим данные сервера

            Cursor.Current = Cursors.WaitCursor;
            ОтветСервера = Обмен.ПослатьСтроку("ОбработкаТТН_ПолучитьФилиалы", ТТНСсылка);
            Cursor.Current = Cursors.Default;

            if (ОтветСервера == null)
            { return; }

            // заполним список Филиалов

            try
            {
                foreach (string[] str in ОтветСервера)
                {
                    Филиалы.Добавить(str[1], str[0], str[2], str[3]);
                }
            }
            catch
            {
                //...
            }
        }

        private void ЗаполнитьСписокСотрудников()
        {
            // сбросим список сотрудников

            Сотрудники.Список.Clear();

            // получим данные сервера

            Cursor.Current = Cursors.WaitCursor;
            ОтветСервера = Обмен.ПослатьСтроку("ОбработкаТТН_ПолучитьСотрудников", ТТНСсылка);
            Cursor.Current = Cursors.Default;

            if (ОтветСервера == null)
            { return; }

            // заполним список сотрудников

            try
            {
                foreach (string[] str in ОтветСервера)
                {
                    Сотрудники.Добавить(str[0], str[1], str[2]);
                }
            }
            catch
            {
                //...
            }
        }

        private void НайтиГрузовоеМесто()
        {
            ФормаПоискаГрузовыхМест фПоискГрузовыхМест = new ФормаПоискаГрузовыхМест();

            DialogResult d = фПоискГрузовыхМест.ShowDialog();

            if (d == DialogResult.OK)
            {
                string НайденноеГрузовоеМесто = фПоискГрузовыхМест.НайденноеГрузовоеМесто;

                ОбработкаВводаМеста("mst" + НайденноеГрузовоеМесто);

            }
        }

    }
}