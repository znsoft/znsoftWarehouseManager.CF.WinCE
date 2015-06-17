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
    public partial class ФормаВыбораСотрудников : Form
    {
        private Пакеты Обмен;
        private string[][] ОтветСервера;
        public СписокСотрудников Список;

        public ФормаВыбораСотрудников()
        {
            InitializeComponent();
            Обмен = new Пакеты("ВыборСотрудников");
            Список = new СписокСотрудников();
        }

        public ФормаВыбораСотрудников(СписокСотрудников _Список)
        {
            InitializeComponent();
            Обмен = new Пакеты("ВыборСотрудников");
            Список = new СписокСотрудников(_Список.Список);
        }


        private void ФормаВыбораСотрудников_Load(object sender, EventArgs e)
        {
            // отобразим список сотрудников на форме

            foreach (Сотрудник стр in Список.Список)
            {
                string[] row = { стр.Наименование, стр.Код };
                var НоваяСтрока = СписокСотрудников.Items.Add(new ListViewItem(row));
            }
        }

        private void ФормаВыбораСотрудников_KeyDown(object sender, KeyEventArgs e)
        {
            if (РаботаСоСканером.НажатаКлавишаСкан(e)) // сканирование
            {
                СканированиеШК(e);
                e.Handled = true;
                return;
            }

            if ((int)e.KeyCode == 8) // BKSP
            {
                e.Handled = true;
                СписокСотрудниковУдалитьСтроку(СписокСотрудников.FocusedItem);
            }

            if (РаботаСоСканером.НажатаЛеваяПодэкраннаяКлавиша(e))
            {
                e.Handled = true;
                _Назад();
            }

            if (РаботаСоСканером.НажатаПраваяПодэкраннаяКлавиша(e))
            {
                e.Handled = true;
                _Далее();
            }
        }


        private void Далее_Click(object sender, EventArgs e)
        {
            _Далее();
        }

        private void _Далее()
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }


        private void Назад_Click(object sender, EventArgs e)
        {
            _Назад();
        }

        private void _Назад()
        {
            this.Close();
        }

        private void СканированиеШК(KeyEventArgs e)
        {
            string СтрокаСкан = РаботаСоСканером.Scan();
            if (СтрокаСкан.Length != 0)
            {
                e.Handled = true;
                ОбработкаВводаСотрудника(СтрокаСкан);
            }
        }

        private void ОбработкаВводаСотрудника(string _Данные)
        {
            // проверим, что это сотрудник

            if (!_Данные.Substring(0, 3).Equals("vis"))
            {
                Инфо.Ошибка("Необходимо сканировать ШК сотрудника.");
                return;
            }

            string СотрудникКод = _Данные.Substring(3);

            // проверим, что сотрудник еще не добавлен

            foreach (ListViewItem item in СписокСотрудников.Items)
            {
                if (String.Equals(item.SubItems[1].Text, СотрудникКод))
                {
                    Инфо.Ошибка("Сотрудник уже присутствует в списке.");

                    // установить курсор на сотрудника, которого добавляем повторно

                    item.Focused = true;
                    item.Selected = true;
                    return;
                }
            }

            // проверка сотрудника на сервере

            Cursor.Current = Cursors.WaitCursor;
            ОтветСервера = Обмен.ПослатьСтроку("ВыборСотрудниковСканирование", СотрудникКод);
            Cursor.Current = Cursors.Default;

            if (ОтветСервера == null) return;

            if (ОтветСервера[0][0] == "ДобавитьСотрудника")
            {
                // добавим строку и спозиционируемся на ней

                string СотрудникСсылка = ОтветСервера[0][1];
                string СотрудникНаименование = ОтветСервера[0][2];

                string[] row = { СотрудникНаименование, СотрудникКод };
                var НоваяСтрока = СписокСотрудников.Items.Add(new ListViewItem(row));

                НоваяСтрока.Focused = true;
                НоваяСтрока.Selected = true;

                Список.Добавить(СотрудникНаименование, СотрудникКод, СотрудникСсылка);

                // подать сигнал о успешном добавлении

                РаботаСоСканером.Звук.Ок();

            }
        }

        private void СписокСотрудниковУдалитьСтроку(ListViewItem _Строка)
        {
            if (_Строка == null)
            {
                return;
            }

            // запросить подтверждение

            string message = "Вы уверены, что хотите удалить выбранного сотрудника?";
            string caption = "Подтверждение";

            // отобразить MessageBox.

            DialogResult result = MessageBox.Show(message, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);

            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                // удалить место
                СписокСотрудников.Items.Remove(_Строка);

                Список.Удалить(_Строка.SubItems[1].Text);

                // подать сигнал о успешном удалении

                РаботаСоСканером.Звук.Ок();
            }
        }

    }

    [Serializable]
    public class СписокСотрудников
    {
        public List<Сотрудник> Список;

        public СписокСотрудников()
        {
            Список = new List<Сотрудник>();
        }

        public СписокСотрудников(List<Сотрудник> _Список)
        {
            Список = new List<Сотрудник>();

            foreach (Сотрудник str in _Список)
            {
                this.Добавить(str);
            }
        }


        public void Добавить(string _Наименование, string _Код, string _Ссылка)
        {
            Список.Add(new Сотрудник(_Наименование, _Код, _Ссылка));
        }

        public void Добавить(Сотрудник _Сотрудник)
        {
            Список.Add(new Сотрудник(_Сотрудник.Наименование, _Сотрудник.Код, _Сотрудник.Ссылка));
        }


        public void Удалить(string _Код)
        {
            foreach (var str in Список)
            {
                if (String.Equals(str.Код, _Код))
                {
                    Список.Remove(str);
                    break;
                }
            }
        }

    }

    [Serializable]
    public class Сотрудник
    {
        public string Наименование;
        public string Код;
        public string Ссылка;

        public Сотрудник(string _Наименование, string _Код, string _Ссылка)
        {
            Наименование = _Наименование;
            Код = _Код;
            Ссылка = _Ссылка;
        }

        public Сотрудник() // конструктор по умолчанию
        {
            Наименование = "";
            Код = "";
            Ссылка = "";
        }
    }

}