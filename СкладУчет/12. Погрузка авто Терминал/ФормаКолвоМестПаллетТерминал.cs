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
    public partial class ФормаКолвоМестПаллетТерминал : Form
    {

        private Пакеты Обмен;
        private string[][] ОтветСервера;

        private string НомерТС;

        private string ТТННомер;
        private string ТТНСсылка;

        private string ФилиалНаименование;
        private string ФилиалСсылка;


        public ФормаКолвоМестПаллетТерминал(string _НомерТС, string _ТТННомер, string _ТТНСсылка, string _ФилиалНаименование, string _ФилиалСсылка)
        {
            InitializeComponent();

            Обмен              = new Пакеты("ПогрузкаАвтоТерминал");
            НомерТС            = _НомерТС;
            ТТННомер           = _ТТННомер;
            ТТНСсылка          = _ТТНСсылка;
            ФилиалНаименование = _ФилиалНаименование;
            ФилиалСсылка       = _ФилиалСсылка;
        }

        private void ФормаКолвоМестПаллетТерминал_Load(object sender, EventArgs e)
        {
            // заполним подсказку пользователю

            ПодсказкаПользователю.Text = НомерТС + "\n" + ФилиалНаименование + "\nЗАПОЛНИТЕ КОЛ-ВА";

            // получим кол-ва из ТТН

            Cursor.Current = Cursors.WaitCursor;
            ОтветСервера = Обмен.ПослатьСтроку("ПогрузкаПолучитьКолвоМестПаллет", ТТНСсылка, ФилиалСсылка);
            Cursor.Current = Cursors.Default;

            if (ОтветСервера == null) { return; }

            try
            {
                КоличествоМест.Text   = ОтветСервера[0][0];
                КоличествоПаллет.Text = ОтветСервера[0][1];
            }
            catch 
            {
                КоличествоМест.Text   = "0";
                КоличествоПаллет.Text = "0";
                return; 
            }

            // установим курсов в поле Кол-во мест

            КоличествоМест.Focus();
            КоличествоМест.SelectAll();

            УстановитьДоступностьЭлементовФормы();

        }

        private void ФормаКолвоМестПаллетТерминал_KeyDown(object sender, KeyEventArgs e)
        {
            if (РаботаСоСканером.НажатаКлавишаСкан(e))
            {
                // ничего не делаем
            }

            if ((e.KeyCode == System.Windows.Forms.Keys.Enter) || (e.KeyCode == System.Windows.Forms.Keys.Down) || (e.KeyCode == System.Windows.Forms.Keys.Up))
            {
                if (КоличествоМест.Focused)
                {
                    КоличествоПаллет.Focus();
                    КоличествоПаллет.SelectAll();
                    e.Handled = true;
                    return;
                }

                if (КоличествоПаллет.Focused)
                {
                    КоличествоМест.Focus();
                    КоличествоМест.SelectAll();
                    e.Handled = true;
                    return;
                }

                if (!КоличествоМест.Focused && !КоличествоПаллет.Focused)
                {
                    КоличествоМест.Focus();
                    КоличествоМест.SelectAll();
                    e.Handled = true;
                    return;
                }
            } 

            if (РаботаСоСканером.НажатаПраваяПодэкраннаяКлавиша(e))
            {
                Cursor.Current = Cursors.WaitCursor;
                _Далее();
                Cursor.Current = Cursors.Default;
            }

            if (РаботаСоСканером.НажатаЛеваяПодэкраннаяКлавиша(e))
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


        private void КоличествоМест_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar));
        }

        private void КоличествоМест_TextChanged(object sender, EventArgs e)
        {
            УстановитьДоступностьЭлементовФормы();
        }


        private void КоличествоПаллет_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar)); 
        }

        private void КоличествоПаллет_TextChanged(object sender, EventArgs e)
        {
            УстановитьДоступностьЭлементовФормы();
        }


        public virtual void _Назад()
        {
            Form Окно = new ФормаПогрузкаТерминал(НомерТС, ТТННомер, ТТНСсылка, ФилиалНаименование, ФилиалСсылка);
            Окно.Show();

            this.Close();

            return;
        }

        public virtual void _Далее()
        {
            if (!Далее.Enabled)
            {
                return;
            }

            ОтветСервера = Обмен.ПослатьСтроку("ПогрузкаВнестиКолвоМестПаллет", ТТНСсылка, ФилиалСсылка, (String.IsNullOrEmpty(КоличествоМест.Text)) ? "0" : КоличествоМест.Text, (String.IsNullOrEmpty(КоличествоПаллет.Text)) ? "0" : КоличествоПаллет.Text);

            if (ОтветСервера == null) { return; }

            try
            {
                if (ОтветСервера[0][0] == "true") // операция прошла успешно
                {
                    Form Окно = new ФормаВыборФилиалаТерминал(НомерТС, ТТННомер, ТТНСсылка);
                    Окно.Show();

                    this.Close();
                    return;
                }

            }
            catch
            {
                Инфо.Ошибка("Не удалось внести кол-во мест, кол-во паллет в ТТН.");
                return;
            }

        }

        private void УстановитьДоступностьЭлементовФормы()
        {
            Далее.Enabled = !ПустаяСтрока(КоличествоМест.Text) || !ПустаяСтрока(КоличествоПаллет.Text);
        }

        private bool ПустаяСтрока(string _str)
        {
            if (String.IsNullOrEmpty(_str)) 
            {
                return true;
            }

            // проверим, что не все нули

            foreach (var iter in _str)
            {
                if (iter != '0')
                {
                    return false;
                }
            }

            return true;
        }

    }
}