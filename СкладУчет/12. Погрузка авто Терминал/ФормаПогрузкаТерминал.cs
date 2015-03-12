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
    public partial class ФормаПогрузкаТерминал: Form
    {

        private Пакеты Обмен;
        private string[][] ОтветСервера;

        private string НомерТС;

        private string ТТННомер;
        private string ТТНСсылка;

        private string ФилиалНаименование;
        private string ФилиалСсылка;

        public ФормаПогрузкаТерминал(string _НомерТС, string _ТТННомер, string _ТТНСсылка, string _ФилиалНаименование, string _ФилиалСсылка)
        {
            InitializeComponent();

            Обмен              = new Пакеты("ПогрузкаАвтоТерминал");
            НомерТС            = _НомерТС;
            ТТННомер           = _ТТННомер;
            ТТНСсылка          = _ТТНСсылка;
            ФилиалНаименование = _ФилиалНаименование;
            ФилиалСсылка       = _ФилиалСсылка;
        }


        private void ФормаПогрузкаТерминал_Load(object sender, EventArgs e)
        {
            // заполним подсказку пользователю

            ПодсказкаПользователю.Text = НомерТС + "\n" + ФилиалНаименование + "\nСКАНИРУЙТЕ ШК ГМ";

            // получим количество уже погруженного

            Cursor.Current = Cursors.WaitCursor;
            ОтветСервера = Обмен.ПослатьСтроку("ПогрузкаПолучитьПогруженное", ТТНСсылка, ФилиалСсылка);
            Cursor.Current = Cursors.Default;

            if (ОтветСервера == null) { return; }

            try
            {
                foreach (var str in ОтветСервера)
                {
                    string[] row = { str[0], str[1] };

                    СписокГрузовыхМест.Items.Add(new ListViewItem(row));
                }
            }
            catch { return; }

            // установим курсор в первую строку

            if (СписокГрузовыхМест.Items.Count > 0)
            {
                СписокГрузовыхМест.Focus();

                СписокГрузовыхМест.Items[0].Focused = true;
                СписокГрузовыхМест.Items[0].Selected = true;

            }
        }

        private void ФормаПогрузкаТерминал_KeyDown(object sender, KeyEventArgs e)
        {
            if (РаботаСоСканером.НажатаКлавишаСкан(e)) // сканирование
            {
                e.Handled = true;
                СканированиеШК(e);
                return;
            }

            if (РаботаСоСканером.НажатаПраваяПодэкраннаяКлавиша(e) || (e.KeyCode == System.Windows.Forms.Keys.Enter))
            {
                Cursor.Current = Cursors.WaitCursor;
                _Далее();
                Cursor.Current = Cursors.Default;
            }

            if (РаботаСоСканером.НажатаЛеваяПодэкраннаяКлавиша(e) || (e.KeyCode == System.Windows.Forms.Keys.Escape))
            {
                Cursor.Current = Cursors.WaitCursor;
                _Назад();
                Cursor.Current = Cursors.Default;
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
            Form Окно = new ФормаВыборФилиалаТерминал(НомерТС, ТТННомер, ТТНСсылка);
            Окно.Show();
            
            this.Close();
            return;
        }

        public virtual void _Далее()
        {
            Form Окно = new ФормаВыборФилиалаТерминал(НомерТС, ТТННомер, ТТНСсылка);
            Окно.Show();

            this.Close();
            return;
        }


        private void СканированиеШК(KeyEventArgs e)
        {
            string СтрокаСкан = РаботаСоСканером.Scan();
            if (СтрокаСкан.Length != 0)
            {
                e.Handled = true;
                ОбработкаВводаМеста(СтрокаСкан);
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

            string ТекущиеМесто = _Данные.Substring(3);

            // проверим, что место еще не добавлено

            foreach (ListViewItem item in СписокГрузовыхМест.Items)
            {
                if (String.Equals(item.SubItems[0].Text, ТекущиеМесто))
                {
                    Инфо.Ошибка("Грузовое место уже присутствует в списке.");

                    // установить курсор на место, которое добавляем повторно
                    СписокГрузовыхМест.EnsureVisible(item.Index);

                    item.Focused = true;

                    return;
                }
            }

            // проверка места на сервере

            Cursor.Current = Cursors.WaitCursor;
            ОтветСервера = Обмен.ПослатьСтроку("ПогрузкаСканированиеГрузовогоМеста", ТекущиеМесто, ТТНСсылка, ФилиалСсылка);
            Cursor.Current = Cursors.Default;

            if (ОтветСервера == null) return;

            if (ОтветСервера[0][0] == "ГрузовоеМестоДобавлено")
            {
                string[] row = { ТекущиеМесто, ОтветСервера[0][1] };

                СписокГрузовыхМест.Items.Add(new ListViewItem(row));
                РаботаСоСканером.Звук.Ок();
            }
        }

    }
}