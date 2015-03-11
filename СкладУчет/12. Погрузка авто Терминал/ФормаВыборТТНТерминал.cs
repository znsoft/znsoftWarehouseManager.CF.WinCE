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
    public partial class ФормаВыборТТНТерминал : Form
    {

        private Пакеты Обмен;
        private string[][] ОтветСервера;


        public ФормаВыборТТНТерминал()
        {
            Обмен = new Пакеты("ПогрузкаАвтоТерминал");
            InitializeComponent();
        }


        private void ФормаВыборТТНТерминал_Load(object sender, EventArgs e)
        {
            ЗаполнитьСписокТТН();
        }

        private void ФормаВыборТТНТерминал_KeyDown(object sender, KeyEventArgs e)
        {
            if (РаботаСоСканером.НажатаКлавишаСкан(e))
            {
                // ничего не делаем
            }

            if (e.KeyCode == System.Windows.Forms.Keys.F5)
            {
                ЗаполнитьСписокТТН();
                e.Handled = true;
            }

            if (РаботаСоСканером.НажатаПраваяПодэкраннаяКлавиша(e) || (e.KeyCode == System.Windows.Forms.Keys.Enter))
            {
                Cursor.Current = Cursors.WaitCursor;
                _Далее();
                Cursor.Current = Cursors.Default;

                e.Handled = true;
            }

            if (РаботаСоСканером.НажатаЛеваяПодэкраннаяКлавиша(e) || (e.KeyCode == System.Windows.Forms.Keys.Escape))
            {
                Cursor.Current = Cursors.WaitCursor;
                _Назад();
                Cursor.Current = Cursors.Default;

                e.Handled = true;
            }
        }
    

        private void Далее_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            _Далее();
            Cursor.Current = Cursors.Default;
        }

        private void Назад_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            _Назад();
            Cursor.Current = Cursors.Default;
        }

        public virtual void _Назад()
        {
            this.Close();
            return;
        }

        public virtual void _Далее()
        {
            ListViewItem ТекущаяСтрока = СписокТТН.FocusedItem;

            if (ТекущаяСтрока == null)
            {
                return;
            }

            Form Окно = new ФормаВыборФилиалаТерминал(ТекущаяСтрока.SubItems[2].Text, ТекущаяСтрока.SubItems[0].Text, ТекущаяСтрока.SubItems[1].Text);
            Окно.Show();

            this.Close();

            return;
        }

        private void ЗаполнитьСписокТТН()
        {
            // очистим список

            СписокТТН.Items.Clear();

            // получим список ТТН

            Cursor.Current = Cursors.WaitCursor;
            ОтветСервера = Обмен.ПослатьСтроку("ВыборТТНПолучитьСписокТТН");
            Cursor.Current = Cursors.Default;

            if (ОтветСервера == null) { return; }

            // заполним список ТТН

            try
            {
                foreach (string[] str in ОтветСервера)
                {
                    string[] row = { str[0], str[1], str[2] };
                    СписокТТН.Items.Add(new ListViewItem(row));
                }
            }
            catch
            {
                Инфо.Ошибка("Нет заданий на погрузку.");
                this.Close();
                return;
            }

            // установим курсор в первую строку

            if(СписокТТН.Items.Count > 0)
            {
                СписокТТН.Focus();
                
                СписокТТН.Items[0].Focused = true;
                СписокТТН.Items[0].Selected = true;
                
            }
        }
    }
}