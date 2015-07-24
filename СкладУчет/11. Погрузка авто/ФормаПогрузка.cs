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

        private СписокСотрудников Сотрудники;
        private DateTime ВремяНачала;

        
        // КОНСТРУКТОРЫ

        public ФормаПогрузка(string _НомерТС, string _ТТННомер, string _ТТНСсылка, string _ФилиалНаименование, string _ФилиалСсылка, СписокСотрудников _Сотрудники, DateTime _ВремяНачала)
        {
            InitializeComponent();

            Обмен              = new Пакеты("ПогрузкаАвто");
            НомерТС            = _НомерТС;
            ТТННомер           = _ТТННомер;
            ТТНСсылка          = _ТТНСсылка;
            ФилиалНаименование = _ФилиалНаименование;
            ФилиалСсылка       = _ФилиалСсылка;
            СписокГрузовыхМест = new List<string> { };

            Сотрудники  = _Сотрудники;
            ВремяНачала = _ВремяНачала;
        }

        
        // ОБРАБОТЧИКИ СОБЫТИЙ ФОРМЫ

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

            if (!e.Handled && e.KeyCode == System.Windows.Forms.Keys.F1) // поиск грузового места
            {
                НайтиГрузовоеМесто();
                e.Handled = true;
            }


            if (e.KeyCode == System.Windows.Forms.Keys.F3) // редактирование списка сотрудников
            {  
                СотрудникиРедактироватьСписок();
                e.Handled = true;
            }

            if (e.KeyCode == System.Windows.Forms.Keys.F8 || e.KeyCode == System.Windows.Forms.Keys.Enter)
            {               
                РучнойВводКоличества();
                e.Handled = true;
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


        // КНОПКИ

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


        // СЛУЖЕБНЫЕ ПРОЦЕДУРЫ

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
            
            Form Окно = new ФормаВыборФилиала(НомерТС, ТТННомер, ТТНСсылка, Сотрудники, ВремяНачала);
            Окно.Show();
            
            this.Close();

            return;
        }

        public virtual void _Далее()
        {
            //////////////////////////////

            // получим количество секунд

            string[][] Параметры = new string[10][];

            // ТТН

            Параметры[0] = new string[2];
            Параметры[0][0] = "ссТТН";
            Параметры[0][1] = ТТНСсылка;

            // Филиал получатель

            Параметры[1] = new string[2];
            Параметры[1][0] = "ссФилиалПолучатель";
            Параметры[1][1] = ФилиалСсылка;

            // чслОргтехника

            Параметры[2] = new string[2];
            Параметры[2][0] = "чслОргтехника";
            Параметры[2][1] = СписокПогрузки.Items[0].SubItems[1].Text;

            // чслНоутбуки

            Параметры[3] = new string[2];
            Параметры[3][0] = "чслНоутбуки";
            Параметры[3][1] = СписокПогрузки.Items[1].SubItems[1].Text;

            // чслТелевизоры

            Параметры[4] = new string[2];
            Параметры[4][0] = "чслТелевизоры";
            Параметры[4][1] = СписокПогрузки.Items[2].SubItems[1].Text;

            // чслДорогойТовар

            Параметры[5] = new string[2];
            Параметры[5][0] = "чслДорогойТовар";
            Параметры[5][1] = СписокПогрузки.Items[3].SubItems[1].Text;

            // чслМешки

            Параметры[6] = new string[2];
            Параметры[6][0] = "чслМешки";
            Параметры[6][1] = СписокПогрузки.Items[4].SubItems[1].Text;

            // мГрузовыеМеста

            Параметры[7] = new string[СписокГрузовыхМест.Count + 1];
            Параметры[7][0] = "мГрузовыеМеста";

            for (int i = 0; i < СписокГрузовыхМест.Count; i++)
            {
                Параметры[7][i + 1] = СписокГрузовыхМест[i];
            }

            // мСотрудники

            Параметры[8] = new string[Сотрудники.Список.Count + 1];
            Параметры[8][0] = "мСотрудники";

            for (int i = 0; i < Сотрудники.Список.Count; i++)
            {
                Параметры[8][i + 1] = Сотрудники.Список[i].Ссылка;
            }

            // 

            TimeSpan РазностьДат = DateTime.Now - ВремяНачала;
            int КоличествоСекунд = Convert.ToInt32(РазностьДат.TotalSeconds);

            // чслКоличествоСекунд

            Параметры[9] = new string[2];
            Параметры[9][0] = "чслКоличествоСекунд";
            Параметры[9][1] = Convert.ToString(КоличествоСекунд);

            // передаем данные на сервер

            Cursor.Current = Cursors.WaitCursor;
            ОтветСервера = Обмен.Послать("ПогрузкаЗавершить", Параметры);
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