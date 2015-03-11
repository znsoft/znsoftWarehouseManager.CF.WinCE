using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Net;
using System.IO;
using System.Reflection;
using System.Xml.Serialization;

namespace СкладскойУчет
{
    public partial class ПриемГрузовыхМест : Form
    {
        private Пакеты Обмен;
        private string[][] ОтветСервера;
        private ДанныеФормы Данные;

        public ПриемГрузовыхМест()
        {
            Обмен  = new Пакеты("ПриемГрузовыхМест");
            Данные = new ДанныеФормы();

            InitializeComponent();
        }
        
        [Serializable]
        public class СтрокаСпискаГрузовыхМест
        {
            public string НомерМеста;
            public string ЛишнееМесто;

            public СтрокаСпискаГрузовыхМест(string _НомерМеста, string _ЛишнееМесто)
            {
                НомерМеста  = _НомерМеста;
                ЛишнееМесто = _ЛишнееМесто;
            }

            public СтрокаСпискаГрузовыхМест()
            {}
        }

        [Serializable]
        public class ДанныеФормы
        {
            public List<СтрокаСпискаГрузовыхМест> СписокГрузовыхМест;

            [field: NonSerialized]
            private string ПолноеИмяФайла;

            [field: NonSerialized]
            private string ИмяФайла = "ПриемГрузовыхМест.xml";

            public ДанныеФормы()
            {
                ПолноеИмяФайла = ПолучитьПолноеИмяФайла(ИмяФайла);
                СписокГрузовыхМест = new List<СтрокаСпискаГрузовыхМест>();
            }

            public void СписокГрузовыхМестДобавить(string _НомерМеста, string _ЛишнееМесто)
            {
                СписокГрузовыхМест.Add(new СтрокаСпискаГрузовыхМест(_НомерМеста, _ЛишнееМесто));

                СохранитьВФайл();
            }

            public void СписокГрузовыхМестУдалить(string _НомерМеста)
            {
                foreach (var str in СписокГрузовыхМест)
                {
                    if (String.Equals(str.НомерМеста, _НомерМеста))
                    {
                        СписокГрузовыхМест.Remove(str);
                        break;
                    }
                }

                СохранитьВФайл();
            }

            public void СохранитьВФайл()
            {
                XmlSerializer writer = new XmlSerializer(typeof(ДанныеФормы));
                FileStream file      = File.Create(ПолноеИмяФайла);

                writer.Serialize(file, this);

                file.Close();
            }

            public bool ВосстановитьИзФайла()
            {
                try
                {
                    if (!File.Exists(ПолноеИмяФайла)) return false;

                    // запросим подтверждение восстановления данных

                    string message = "Восстановить данные предыдущего сеанса работы?";
                    string caption = "Подтверждение";

                    // отобразить MessageBox.

                    DialogResult result = MessageBox.Show(message, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);

                    if (result != System.Windows.Forms.DialogResult.Yes)
                    {
                        return false;
                    }

                    XmlSerializer reader = new XmlSerializer(typeof(ДанныеФормы));
                    StreamReader file    = new StreamReader(ПолноеИмяФайла);

                    ДанныеФормы tmp = (ДанныеФормы)reader.Deserialize(file);

                    this.СписокГрузовыхМест.Clear();

                    foreach (var str in tmp.СписокГрузовыхМест)
                    {
                        this.СписокГрузовыхМест.Add(str);
                    }

                    file.Close();
                    return true;
                }
                catch 
                {
                    this.СписокГрузовыхМест.Clear();
                    return false; 
                }
            }

            private string ПолучитьПолноеИмяФайла(string _ИмяФайла)
            {
                var Авторизован = (NetworkCredential)СоединениеВебСервис.ПолучитьСервис().Сервис.Credentials;

                string FullDir = Assembly.GetCallingAssembly().ManifestModule.FullyQualifiedName;
                var FI         = new FileInfo(FullDir);

                string pathString = Path.Combine(FI.Directory.FullName, Авторизован.UserName);

                Directory.CreateDirectory(pathString);

                return Path.Combine(pathString, _ИмяФайла);
            }

            public void УдалитьФайл()
            {
                File.Delete(ПолноеИмяФайла);
            }
        }

        private void ФормаПриемГрузовыхМест_Load(object sender, EventArgs e)
        {
            if (Данные.ВосстановитьИзФайла())
            {
                foreach (var str in Данные.СписокГрузовыхМест)
                {
                    string[] row = { str.НомерМеста };

                    var НоваяСтрока = СписокГрузовыхМест.Items.Add(new ListViewItem(row));

                    if (str.ЛишнееМесто == "1")
                    {
                        НоваяСтрока.BackColor = Color.LightPink;
                    }
                }

                СписокГрузовыхМест.Focus();
            }

            УстановитьДоступностьЭлементовФормы();
            УстановитьТекстПодсказки();
        }

        private void ФормаПриемГрузовыхМест_KeyDown(object sender, KeyEventArgs e)
        {

            int ИндексТекущейСтраницы = ОсновнаяПанель.SelectedIndex;

            // Обработка нажатия клавиш на странице Места

            if (ИндексТекущейСтраницы == 0) // СтраницаМеста
            {
                if (РаботаСоСканером.НажатаКлавишаСкан(e)) // сканирование
                {
                    e.Handled = true;
                    СканированиеШК(e);
                    return;
                }

                if ((int)e.KeyCode == 8) // BKSP
                {
                    СписокГрузовыхМестУдалитьСтроку(СписокГрузовыхМест.FocusedItem);
                    e.Handled = true;
                }

                if (РаботаСоСканером.НажатаЛеваяПодэкраннаяКлавиша(e))
                {
                    _Назад();
                    e.Handled = true;
                }

                if (РаботаСоСканером.НажатаПраваяПодэкраннаяКлавиша(e))
                {
                    _Завершить();
                    e.Handled = true;
                }

                if ((e.KeyCode == System.Windows.Forms.Keys.Right))
                {
                    ПерейтиНаСтраницу(1);
                    e.Handled = true;
                }
            }

            // Обработка нажатия клавиш на странице Поиск

            if (ИндексТекущейСтраницы == 1) // СтраницаПоиск
            {
                if (e.KeyCode == System.Windows.Forms.Keys.Up)
                {
                    // если фокус на списке мест и находимся на первой строке, 
                    // то переместим его на поле ввода

                    if (СписокНайденныхГрузовыхМест.Focused && (СписокНайденныхГрузовыхМест.FocusedItem.Index == 0))
                    {
                        ТекстДляПоискаМест.Focus();
                        e.Handled = true;
                    }
                }

                if (e.KeyCode == System.Windows.Forms.Keys.Down)
                {
                    // если фокус на поле ввода и список мест не пустой, 
                    // то переместим его на список мест

                    if (ТекстДляПоискаМест.Focused && (СписокНайденныхГрузовыхМест.Items.Count > 0))
                    {
                        СписокНайденныхГрузовыхМест.Focus();
                        e.Handled = true;
                    }
                }

                if (((e.KeyCode == System.Windows.Forms.Keys.Left) && (!ТекстДляПоискаМест.Focused || String.IsNullOrEmpty(ТекстДляПоискаМест.Text))) || РаботаСоСканером.НажатаЛеваяПодэкраннаяКлавиша(e))
                {
                    ПерейтиНаСтраницу(0);
                    e.Handled = true;
                }

                if (РаботаСоСканером.НажатаПраваяПодэкраннаяКлавиша(e))
                {
                    НайтиГрузовыеМеста();
                    e.Handled = true;
                }
            }

        }

        private void Назад_Click(object sender, EventArgs e)
        {
            if (ОсновнаяПанель.SelectedIndex == 1) // СтраницаПоиск 
            {
                ПерейтиНаСтраницу(0);
                return;
            }

            if (ОсновнаяПанель.SelectedIndex == 0) // СтраницаМеста
            {
                _Назад();
            }
        }

        private void Завершить_Click(object sender, EventArgs e)
        {
            _Завершить();
        }

        public void _Назад()
        {
            // проверим, что список мест пустой
            // если не пустой, то запросим подтверждение

            if (СписокГрузовыхМест.Items.Count > 0)
            {
                // запросить подтверждение

                string message = "Внимание! Остались непринятые места. Сохранить данные для восстановления при следующем открытии?";
                string caption = "Подтверждение";

                // отобразить MessageBox.

                DialogResult result = MessageBox.Show(message, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);

                if (result != System.Windows.Forms.DialogResult.Yes)
                {
                    Данные.УдалитьФайл();
                }
            }

            this.Close();
        }

        public void _Завершить()
        {
            if(СписокГрузовыхМест.Items.Count == 0)
            {
                return;
            }

            // запросить подтверждение

            string message = "Вы уверены, что хотите завершить прием грузовых мест?";
            string caption = "Подтверждение";

            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result;

            // отобразить MessageBox.

            result = MessageBox.Show(message, caption, buttons, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);

            if (result != System.Windows.Forms.DialogResult.Yes)
            {
                return;
            }

            // передать список грузовых мест на сервер
            
            string[][] Результат = new string[СписокГрузовыхМест.Items.Count][];

            foreach (ListViewItem item in СписокГрузовыхМест.Items)
            {
                Результат[item.Index] = new string[] {item.Text};
            }

            // сервер возвращает места, которые не удалось принять
            Cursor.Current = Cursors.WaitCursor;
            ОтветСервера = Обмен.Послать("ЗавершитьПриемГрузовыхМест", Результат);
            Cursor.Current = Cursors.Default;

            if (ОтветСервера == null) // ничего не делаем
            {
                return;
            }

            if (ОтветСервера[0][0] == "ВыполненоУспешно")
            {
                СписокГрузовыхМест.Items.Clear();
  
                // предупредить о успешном выполнении
                // ...
            }

            if (ОтветСервера[0][0] == "ВыполненоСОшибками")
            {
                // удалим из списка места, которые приняли

                List<ListViewItem> СписокСтрокДляУдаления = new List<ListViewItem> { };

                // надем строки, которые надо удалить
                foreach (ListViewItem item in СписокГрузовыхМест.Items)
                {
                    bool Удалять = true;

                    foreach (string[] str in ОтветСервера)
                    {
                        if (String.Equals(item.SubItems[0].Text, str[0]))
                        {
                            Удалять = false;
                            break;
                        }
                    }

                    if (Удалять)
                    {
                        СписокСтрокДляУдаления.Add(item);
                    }
                }

                // удалим строки
                foreach (ListViewItem item in СписокСтрокДляУдаления)
                {
                    СписокГрузовыхМест.Items.Remove(item);
                    Данные.СписокГрузовыхМестУдалить(item.SubItems[0].Text);
                }

                // оповестим о ошибке

                Инфо.Ошибка(ОтветСервера[0][1]);
            }

            УстановитьДоступностьЭлементовФормы();
            УстановитьТекстПодсказки();

            // если все места приняты, то переходим в основное меню

            if (СписокГрузовыхМест.Items.Count == 0)
            {
                this.Close();
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
            // установим фокус на список мест

            СписокГрузовыхМест.Focus();
            
            // проверим, что это место

            if (!_Данные.Substring(0, 3).Equals("mst"))
            {
                Инфо.Ошибка("Необходимо сосканировать ШК грузового места.");
                return;
            }

            // снять выделение с других строк

            foreach (ListViewItem item in СписокГрузовыхМест.Items)
            {
                item.Selected = false;
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
            ОтветСервера = Обмен.Послать("СканированиеГрузовогоМеста", Обмен.ПодготовитьСтроку(ТекущиеМесто));
            Cursor.Current = Cursors.Default;

            if (ОтветСервера == null) return;

            // обработка ответа сервера

            string ЛишнееМесто = "1"; // истина по умолчанию

            foreach (string[] str in ОтветСервера)
            {
                if (str[0] == "ЛишнееМесто")
                {
                    ЛишнееМесто = str[1];
                }
            }

            // добавим строку и спозиционируемся на ней

            string[] row = {ТекущиеМесто};
            var НоваяСтрока = СписокГрузовыхМест.Items.Add(new ListViewItem(row));

            СписокГрузовыхМест.EnsureVisible(НоваяСтрока.Index);
            НоваяСтрока.Focused = true;

            // подать сигнал о успешном добавлении

            РаботаСоСканером.Звук.Ок();

            if (ЛишнееМесто == "1")
            {
                НоваяСтрока.BackColor = Color.LightPink;

                // подать сигнал, что место не ждем
                РаботаСоСканером.Звук.Ошибка();
            }
            else 
            {
                // подать сигнал, что место наше
                РаботаСоСканером.Звук.Ок();
            }

            УстановитьДоступностьЭлементовФормы();
            УстановитьТекстПодсказки();
            Данные.СписокГрузовыхМестДобавить(ТекущиеМесто, ЛишнееМесто);

        }

        private void УстановитьТекстПодсказки()
        {
            if (ОсновнаяПанель.SelectedIndex == 0) // СтраницаМеста
            {
                ПодсказкаПользователю.Text = "Сосканировано мест: " + СписокГрузовыхМест.Items.Count + " шт.";
                return;
            }

            if (ОсновнаяПанель.SelectedIndex == 1) // СтраницаПоиск
            {
                ПодсказкаПользователю.Text = "Введите номер для поиска";
                return;
            }     
        }

        private void СписокГрузовыхМестУдалитьСтроку(ListViewItem _Строка)
        {
            if (_Строка == null)
            {
                return;
            }

            // запросить подтверждение

            string message = "Вы уверены, что хотите удалить выбранное грузовое место?";
            string caption = "Подтверждение";

            // отобразить MessageBox.

            DialogResult result = MessageBox.Show(message, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);

            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                // удалить место

                СписокГрузовыхМест.Items.Remove(_Строка);

                УстановитьДоступностьЭлементовФормы();
                УстановитьТекстПодсказки();
                Данные.СписокГрузовыхМестУдалить(_Строка.SubItems[0].Text);
            }
        }

        // ПОИСК ГРУЗОВЫХ МЕСТ

        private void КнопкаНайтиГрузовыеМеста_Click(object sender, EventArgs e)
        {
            НайтиГрузовыеМеста();
        }

        private void ТекстДляПоискаМест_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) 
            {
                НайтиГрузовыеМеста();
            }
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
            ОтветСервера = Обмен.Послать("ПоискГрузовыхМест", Обмен.ПодготовитьСтроку(ТекстДляПоискаМест.Text));
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

        private void СписокНайденныхГрузовыхМест_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                СписокНайденныхГрузовыхМестОбработкаВыбора();
            }
        }

        private void СписокНайденныхГрузовыхМестОбработкаВыбора()
        {
            ListViewItem ТекущаяСтрока = СписокНайденныхГрузовыхМест.FocusedItem;

            if (ТекущаяСтрока == null)
            {
                return;
            }

            string НомерТекущегоМеста = ТекущаяСтрока.SubItems[0].Text;
            
            // очистка

            СписокНайденныхГрузовыхМест.Items.Clear();
            ТекстДляПоискаМест.Text = "";

            // переводим на страницу Места

            ОсновнаяПанель.SelectedIndex = 0; // страница места
            СписокГрузовыхМест.Focus();

            // добавляем место в список

            ОбработкаВводаМеста("mst" + НомерТекущегоМеста);

        }

        private void УстановитьДоступностьЭлементовФормы()
        {
            if (ОсновнаяПанель.SelectedIndex == 0) // СтраницаМеста
            {
                Назад.Text     = "Назад";
                Завершить.Text = "Завершить";

                Завершить.Enabled = (СписокГрузовыхМест.Items.Count != 0);
                return;
            }

            if (ОсновнаяПанель.SelectedIndex == 1) // СтраницаПоиск
            {
                Назад.Text     = "< Назад";
                Завершить.Text = "Найти";

                Завершить.Enabled = (!String.IsNullOrEmpty(ТекстДляПоискаМест.Text) && ТекстДляПоискаМест.Text.Length > 4);
                return;
            }
        }

        private void ПерейтиНаСтраницу(int _ИндексСтраницы)
        {
            ОсновнаяПанель.SelectedIndex = _ИндексСтраницы;
        }

        private void ОсновнаяПанель_SelectedIndexChanged(object sender, EventArgs e)
        {

            УстановитьДоступностьЭлементовФормы();

            УстановитьТекстПодсказки();

            // Установить фокус

            if (ОсновнаяПанель.SelectedIndex == 0) // СтраницаМеста
            {
                СписокГрузовыхМест.Focus();
            }

            if (ОсновнаяПанель.SelectedIndex == 1) // СтраницаПоиск
            {
                ТекстДляПоискаМест.Focus();
            }
        }

        private void ПриемГрузовыхМест_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (СписокГрузовыхМест.Items.Count == 0)
            {
                Данные.УдалитьФайл();
            }
        }

        private void ПриемГрузовыхМест_Deactivate(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.Default;
        }

        private void ТекстДляПоискаМест_TextChanged(object sender, EventArgs e)
        {
            УстановитьДоступностьЭлементовФормы();
        }

    }
}