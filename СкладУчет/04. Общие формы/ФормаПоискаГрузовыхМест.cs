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
    public partial class ФормаПоискаГрузовыхМест : Form
    {
        public string НайденноеГрузовоеМесто;
        private Пакеты Обмен;
        private string[][] ОтветСервера;


        // КОНСТРУКТОРЫ        

        public ФормаПоискаГрузовыхМест()
        {
            InitializeComponent();
            Обмен = new Пакеты("ПоискГрузовыхМест");
        }


        // ОБРАБОТЧИКИ СОБЫТИЙ ФОРМЫ

        private void ФормаПоискаГрузовыхМест_KeyDown(object sender, KeyEventArgs e)
        {
            if (!e.Handled && e.KeyCode == System.Windows.Forms.Keys.Up)
            {
                // если фокус на списке мест и находимся на первой строке, 
                // то переместим его на поле ввода

                if (СписокНайденныхГрузовыхМест.Focused && (СписокНайденныхГрузовыхМест.FocusedItem.Index == 0))
                {
                    ТекстДляПоискаМест.Focus();
                    e.Handled = true;
                }
            }

            if (!e.Handled && e.KeyCode == System.Windows.Forms.Keys.Down)
            {
                // если фокус на поле ввода и список мест не пустой, 
                // то переместим его на список мест

                if (ТекстДляПоискаМест.Focused && (СписокНайденныхГрузовыхМест.Items.Count > 0))
                {
                    СписокНайденныхГрузовыхМест.Focus();
                    e.Handled = true;
                }
            }

            if (!e.Handled && РаботаСоСканером.НажатаПраваяПодэкраннаяКлавиша(e))
            {
                _Завершить();
                e.Handled = true;
            }

            if (!e.Handled && РаботаСоСканером.НажатаЛеваяПодэкраннаяКлавиша(e))
            {
                _Назад();
                e.Handled = true;

            }
        }

        // ОБРАБОТЧИКИ ЭФ ТекстДляПоискаМест

        private void ТекстДляПоискаМест_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                НайтиГрузовыеМеста();
                e.Handled = true;
            }
        }


        // ОБРАБОТЧИКИ ЭФ СписокНайденныхГрузовыхМест

        private void СписокНайденныхГрузовыхМест_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                СписокНайденныхГрузовыхМестОбработкаВыбора();
                e.Handled = true;
            }
        }


        // КНОПКИ

        private void КнопкаНайтиГрузовыеМеста_Click(object sender, EventArgs e)
        {
            НайтиГрузовыеМеста();
        }

        private void Назад_Click(object sender, EventArgs e)
        {
            _Назад();
        }

        private void Завершить_Click(object sender, EventArgs e)
        {
            _Завершить();
        }


        // СЛУЖЕБНЫЕ ПРОЦЕДУРЫ

        public void _Назад()
        {
            this.Close();
        }

        public void _Завершить()
        {
            НайтиГрузовыеМеста();
        }

        private void НайтиГрузовыеМеста()
        {
            if (ТекстДляПоискаМест.Text.Length <= 4)
            {
                Инфо.Ошибка("Укажите более 4-х подряд цифр номера места.");
                return;
            }

            // очистить список найденных грузовых мест

            СписокНайденныхГрузовыхМест.Items.Clear();

            // передать условие поиска на сервер

            Cursor.Current = Cursors.WaitCursor;
            ОтветСервера = Обмен.ПослатьСтроку("Найти", ТекстДляПоискаМест.Text);
            Cursor.Current = Cursors.Default;

            if (ОтветСервера == null) return;

            // добавляем найденные места

            foreach (string[] str in ОтветСервера)
            {
                string[] row = { str[0] };
                СписокНайденныхГрузовыхМест.Items.Add(new ListViewItem(row));
            }

            // переведем фокус на список мест

            if (СписокНайденныхГрузовыхМест.Items.Count > 0)
            {
                СписокНайденныхГрузовыхМест.Focus();

                // сфокусируемся на первой строке в списке и выделим ее

                СписокНайденныхГрузовыхМест.Items[0].Focused = true;
                СписокНайденныхГрузовыхМест.Items[0].Selected = true;
            }
        }

        private void СписокНайденныхГрузовыхМестОбработкаВыбора()
        {
            ListViewItem ТекущаяСтрока = СписокНайденныхГрузовыхМест.FocusedItem;

            if (ТекущаяСтрока == null)
            {
                return;
            }

            НайденноеГрузовоеМесто = ТекущаяСтрока.SubItems[0].Text;

            // передаем значение выбранного места

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

 

    }
}