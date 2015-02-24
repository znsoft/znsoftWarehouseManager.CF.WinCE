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
    public partial class ФормаПогрузка : Form
    {

        private Пакеты Обмен;
        private string[][] ОтветСервера;
        private List<string> СписокГрузовыхМест;

        private string НомерТС;

        private string ТТННомер;
        private string ТТНСсылка;

        private string ФилиалНаименование;
        private string ФилиалСсылка;

        public ФормаПогрузка(string _НомерТС, string _ТТННомер, string _ТТНСсылка, string _ФилиалНаименование, string _ФилиалСсылка)
        {
            InitializeComponent();

            Обмен              = new Пакеты("ПогрузкаАвто");
            НомерТС            = _НомерТС;
            ТТННомер           = _ТТННомер;
            ТТНСсылка          = _ТТНСсылка;
            ФилиалНаименование = _ФилиалНаименование;
            ФилиалСсылка       = _ФилиалСсылка;
            СписокГрузовыхМест = new List<string> { };
        }


        private void ФормаПогрузка_Load(object sender, EventArgs e)
        {
            // заполним подсказку пользователю

            ПодсказкаПользователю.Text = НомерТС + "\n" + ФилиалНаименование;

            // получим количество уже погруженного

            Cursor.Current = Cursors.WaitCursor;
            ОтветСервера = Обмен.ПослатьСтроку("ПогрузкаПолучитьПогруженное", ТТНСсылка, ФилиалСсылка);
            Cursor.Current = Cursors.Default;

            if (ОтветСервера == null) { return; }

            try
            {
                for (int i = 0; i < 5; i++)
                {
                    СписокПогрузки.Items[i].SubItems[1].Text = ОтветСервера[0][i];
                    СписокПогрузки.Items[i].SubItems[2].Text = ОтветСервера[0][i]; 
                }
            }
            catch { return; }

            try
            {
                foreach (var str in ОтветСервера[1])
                {
                    СписокГрузовыхМест.Add(str);
                }
            }
            catch { return; }

            СписокПогрузки.Items[5].SubItems[1].Text = Convert.ToString(СписокГрузовыхМест.Count);
            СписокПогрузки.Items[5].SubItems[2].Text = Convert.ToString(СписокГрузовыхМест.Count);

            // установим курсор в первую строку

            if (СписокПогрузки.Items.Count > 0)
            {
                СписокПогрузки.Focus();

                СписокПогрузки.Items[0].Focused = true;
                СписокПогрузки.Items[0].Selected = true;

            }
        }

        private void ФормаПогрузка_KeyDown(object sender, KeyEventArgs e)
        {
            if (РаботаСоСканером.НажатаКлавишаСкан(e)) // сканирование
            {
                e.Handled = true;
                СканированиеШК(e);
                return;
            }

            if (e.KeyCode == System.Windows.Forms.Keys.F8 || e.KeyCode == System.Windows.Forms.Keys.Enter)
            {
                e.Handled = true;
                РучнойВводКоличества();
            }


            if ((e.KeyCode == System.Windows.Forms.Keys.Right))
            {
                e.Handled = true;

                ListViewItem ТекущаяСтрока = СписокПогрузки.FocusedItem;

                if (ТекущаяСтрока == null)
                {
                    return;
                }

                // работа с перекосами только сканером
                if (ТекущаяСтрока.SubItems[0].Text == "Перекосы") { return; }

                ТекущаяСтрока.SubItems[1].Text = Convert.ToString(Convert.ToInt32(ТекущаяСтрока.SubItems[1].Text) + 1);
               
            }

            if ((e.KeyCode == System.Windows.Forms.Keys.Left))
            {
                e.Handled = true;

                ListViewItem ТекущаяСтрока = СписокПогрузки.FocusedItem;

                if (ТекущаяСтрока == null)
                {
                    return;
                }

                // работа с перекосами только сканером
                if (ТекущаяСтрока.SubItems[0].Text == "Перекосы") { return; }

                // проверим, что не уходим в минус

                int ТекущееКоличество = Convert.ToInt32(ТекущаяСтрока.SubItems[1].Text);

                if (ТекущееКоличество > 0)
                {
                    ТекущаяСтрока.SubItems[1].Text = Convert.ToString(ТекущееКоличество - 1);
                }
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
            bool ЕстьИзменения = false;

            foreach (ListViewItem item in СписокПогрузки.Items)
            {
                if (!String.Equals(item.SubItems[1].Text, item.SubItems[2].Text))
                {
                    ЕстьИзменения = true;
                    break;
                }
            }

            if (ЕстьИзменения)
            {
                string message = "Внимание! В случае закрытия окна все сделанные изменения будут утеряны. Продолжить?";
                string caption = "Подтверждение";

                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result;

                // отобразить MessageBox.

                result = MessageBox.Show(message, caption, buttons, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);

                if (result != System.Windows.Forms.DialogResult.Yes)
                {
                    return;
                }
            }
            
            Form Окно = new ФормаВыборФилиала(НомерТС, ТТННомер, ТТНСсылка);
            Окно.Show();
            
            this.Close();

            return;
        }

        public virtual void _Далее()
        {
            // завершить погрузку филиала

            string[][] tmp = new string[3][];

            tmp[0] = new string[] {ТТНСсылка, ФилиалСсылка};
            tmp[1] = new string[] { СписокПогрузки.Items[0].SubItems[1].Text, СписокПогрузки.Items[1].SubItems[1].Text, СписокПогрузки.Items[2].SubItems[1].Text, СписокПогрузки.Items[3].SubItems[1].Text, СписокПогрузки.Items[4].SubItems[1].Text };

            tmp[2] = new string[СписокГрузовыхМест.Count];

            for (int i = 0; i < СписокГрузовыхМест.Count; i++)
            {
                tmp[2][i] = СписокГрузовыхМест[i];
            }

            Cursor.Current = Cursors.WaitCursor;
            ОтветСервера = Обмен.Послать("ПогрузкаЗавершить", tmp);
            Cursor.Current = Cursors.Default;

            if (ОтветСервера == null) { return; }

            if (ОтветСервера[0][0] == "ПогрузкаЗавершена")
            {
                // переходим в окно выбора филиала

                Form Окно = new ФормаВыборФилиала(НомерТС, ТТННомер, ТТНСсылка);
                Окно.Show();
                
                this.Close();

                return;
            }

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

            if (СписокГрузовыхМест.Contains(ТекущиеМесто))
            {
                // удалить место

                РаботаСоСканером.Звук.Ошибка();

                string message = "Внимание! Место уже добавлено. Удалить место?";
                string caption = "Подтверждение";

                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result;

                // отобразить MessageBox.

                result = MessageBox.Show(message, caption, buttons, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

                if (result == System.Windows.Forms.DialogResult.Yes)
                {
                    СписокГрузовыхМест.Remove(ТекущиеМесто);
                    СписокПогрузки.Items[5].SubItems[1].Text = Convert.ToString(СписокГрузовыхМест.Count);

                    РаботаСоСканером.Звук.Ок();
                }

                return;
                
            }

            // проверка места на сервере

            Cursor.Current = Cursors.WaitCursor;
            ОтветСервера = Обмен.ПослатьСтроку("ПогрузкаСканированиеГрузовогоМеста", ТекущиеМесто, ТТНСсылка);
            Cursor.Current = Cursors.Default;

            if (ОтветСервера == null) return;

            if (ОтветСервера[0][0] == "ДобавитьГрузовоеМесто")
            {
                СписокГрузовыхМест.Add(ТекущиеМесто);
                СписокПогрузки.Items[5].SubItems[1].Text = Convert.ToString(СписокГрузовыхМест.Count);

                РаботаСоСканером.Звук.Ок();
            }
        }

        private void РучнойВводКоличества()
        {

            var ВыбраннаяСтрока = СписокПогрузки.FocusedItem;

            if (ВыбраннаяСтрока == null) return;

            if (ВыбраннаяСтрока.SubItems[0].Text == "Перекосы")
            {
                return;
            }

            string ТекстИнструкции = "Введите необходимое \nколичество";

            ОкноВводКоличества ОкноВводКоличества = new ОкноВводКоличества(ТекстИнструкции, Convert.ToInt32(ВыбраннаяСтрока.SubItems[1].Text), 0, false);

            DialogResult d = ОкноВводКоличества.ShowDialog();

            if (d == DialogResult.OK)
            {
                int Количество = ОкноВводКоличества.Количество_;

                ВыбраннаяСтрока.SubItems[1].Text = Convert.ToString(Количество);

                // Подтверждаем успешный ввод количества звуком
                РаботаСоСканером.Звук.Ок();
            }
        }

    }
}