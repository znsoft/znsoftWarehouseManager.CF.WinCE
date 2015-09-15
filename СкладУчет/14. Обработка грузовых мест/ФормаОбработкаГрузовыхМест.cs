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
    public partial class ОбработкаГрузовыхМест : Form
    {

        private Пакеты Обмен;
        private string[][] ОтветСервера;
        private ДанныеФормы Данные;

        [Serializable]
        public class СтрокаСпискаГрузовыхМест
        {
            public string МестоНомер;
            public string МестоАналог;
            public string ДатаДобавления;

            public СтрокаСпискаГрузовыхМест(string _МестоНомер, string _МестоАналог, string _ДатаДобавления)
            {
                МестоНомер = _МестоНомер;
                МестоАналог = _МестоАналог;
                ДатаДобавления = _ДатаДобавления;
            }

            public СтрокаСпискаГрузовыхМест()
            { }
        }

        [Serializable]
        public class ДанныеФормы
        {
            public List<СтрокаСпискаГрузовыхМест> СписокГрузовыхМест;

            public DateTime ВремяНачала;

            public СписокСотрудников Сотрудники;

            [field: NonSerialized]
            private string ПолноеИмяФайла;

            [field: NonSerialized]
            private string ИмяФайла = "ОбработкаГрузовыхМест.xml";

            public ДанныеФормы()
            {
                ПолноеИмяФайла = ПолучитьПолноеИмяФайла(ИмяФайла);
                СписокГрузовыхМест = new List<СтрокаСпискаГрузовыхМест>();
                Сотрудники = new СписокСотрудников();
                ВремяНачала = DateTime.Now;
            }

            public void СписокГрузовыхМестДобавить(string _МестоНомер, string _МестоАналог, string _ДатаДобавления)
            {
                СписокГрузовыхМест.Add(new СтрокаСпискаГрузовыхМест(_МестоНомер, _МестоАналог, _ДатаДобавления));

                СохранитьВФайл();
            }

            public void СписокГрузовыхМестУдалить(string _МестоНомер)
            {
                foreach (var str in СписокГрузовыхМест)
                {
                    if (String.Equals(str.МестоНомер, _МестоНомер))
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
                FileStream file = File.Create(ПолноеИмяФайла);

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

                    // заполним список грузовых мест

                    XmlSerializer reader = new XmlSerializer(typeof(ДанныеФормы));
                    StreamReader file = new StreamReader(ПолноеИмяФайла);

                    ДанныеФормы tmp = (ДанныеФормы)reader.Deserialize(file);

                    this.СписокГрузовыхМест.Clear();

                    foreach (var str in tmp.СписокГрузовыхМест)
                    {
                        this.СписокГрузовыхМест.Add(str);
                    }

                    // заполним список сотрудников

                    this.Сотрудники.Список.Clear();

                    foreach (var str in tmp.Сотрудники.Список)
                    {
                        this.Сотрудники.Добавить(str);
                    }

                    // заполним время начала

                    this.ВремяНачала = tmp.ВремяНачала;

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
                var FI = new FileInfo(FullDir);

                string pathString = Path.Combine(FI.Directory.FullName, Авторизован.UserName);

                Directory.CreateDirectory(pathString);

                return Path.Combine(pathString, _ИмяФайла);
            }

            public void УдалитьФайл()
            {
                File.Delete(ПолноеИмяФайла);
            }
        }

        public ОбработкаГрузовыхМест()
        {
            Обмен = new Пакеты("ОбработкаГрузовыхМест");
            Данные = new ДанныеФормы();

            InitializeComponent();
        }

        private void ОбработкаГрузовыхМест_Load(object sender, EventArgs e)
        {
            if (Данные.ВосстановитьИзФайла())
            {
                foreach (var str in Данные.СписокГрузовыхМест)
                {
                    string[] row = { str.МестоНомер, str.МестоАналог };

                    var НоваяСтрока = СписокГрузовыхМест.Items.Add(new ListViewItem(row));

                }

                СписокГрузовыхМест.Focus();
            }

            УстановитьДоступностьЭлементовФормы();
            УстановитьТекстПодсказки();
        }

        private void ОбработкаГрузовыхМест_KeyDown(object sender, KeyEventArgs e)
        {

            if (РаботаСоСканером.НажатаКлавишаСкан(e)) // сканирование
            {
                e.Handled = true;
                СканированиеШК(e);
                return;
            }

            if (e.KeyCode == System.Windows.Forms.Keys.F3) // редактирование списка сотрудников
            {
                СотрудникиРедактироватьСписок();
                e.Handled = true;
                return;
            }

            if (e.KeyCode == System.Windows.Forms.Keys.F1) // поиск грузового места
            {
                НайтиГрузовоеМесто();
                e.Handled = true;
                return;
            }

            if ((int)e.KeyCode == 8) // BKSP
            {
                СписокГрузовыхМестУдалитьСтроку(СписокГрузовыхМест.FocusedItem);
                e.Handled = true;
                return;
            }

            if (РаботаСоСканером.НажатаЛеваяПодэкраннаяКлавиша(e))
            {
                _Назад();
                e.Handled = true;
                return;
            }

            if (РаботаСоСканером.НажатаПраваяПодэкраннаяКлавиша(e))
            {
                _Завершить();
                e.Handled = true;
                return;
            }

        }

        private void Назад_Click(object sender, EventArgs e)
        {
            _Назад();
        }

        private void Далее_Click(object sender, EventArgs e)
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

                string message = "Внимание! Остались необработанные места. Сохранить данные для восстановления при следующем открытии?";
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
            if (СписокГрузовыхМест.Items.Count == 0)
            {
                return;
            }

            if (Данные.Сотрудники.Список.Count == 0)
            {
                Инфо.Ошибка("Заполните список сотрудников.");
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

            // получим количество секунд

            TimeSpan РазностьДат = DateTime.Now - Данные.ВремяНачала;
            int КоличествоСекунд = Convert.ToInt32(РазностьДат.TotalSeconds);

            // сформируем параметры для передачи на сервер

            string[][] Параметры = new string[3][];

            // грузовые места

            Параметры[0] = new string[Данные.СписокГрузовыхМест.Count + 1];
            Параметры[0][0] = "тзГрузовыеМеста"; // зададим наименование таблицы

            int index = 1;

            foreach (var tmp in Данные.СписокГрузовыхМест)
            {
                Параметры[0][index++] = tmp.МестоНомер + "\t" + tmp.ДатаДобавления;
            }

            // сотрудники

            Параметры[1] = new string[Данные.Сотрудники.Список.Count + 1];
            Параметры[1][0] = "мСотрудники"; // зададим наименование массива

            for (int i = 0; i < Данные.Сотрудники.Список.Count; i++)
            {
                Параметры[1][i + 1] = Данные.Сотрудники.Список[i].Ссылка;
            }

            // количество секунд

            Параметры[2] = new string[2];
            Параметры[2][0] = "чслКоличествоСекунд";
            Параметры[2][1] = Convert.ToString(КоличествоСекунд);

            // передать список грузовых мест на сервер

            // сервер возвращает места, которые не удалось принять
            Cursor.Current = Cursors.WaitCursor;
            ОтветСервера = Обмен.Послать("ОбработкаГрузовыхМест_Завершить", Параметры);
            Cursor.Current = Cursors.Default;

            if (ОтветСервера == null) // ничего не делаем
            {
                return;
            }

            if (ОтветСервера[0][0] == "ВыполненоУспешно")
            {       
                // удалим временные файлы

                Данные.УдалитьФайл();

                РаботаСоСканером.Звук.Ок(); // успешное завершение
                this.Close();
            }
        }


        private void УстановитьДоступностьЭлементовФормы()
        {
            Завершить.Enabled = (СписокГрузовыхМест.Items.Count != 0);
        }

        private void УстановитьТекстПодсказки()
        {
            if (СписокГрузовыхМест.Items.Count == 0)
            {
                ПодсказкаПользователю.Text = "СКАНИРУЙТЕ ШК ГМ";
            }
            else
            {
                ПодсказкаПользователю.Text = "Сканировано мест: " + СписокГрузовыхМест.Items.Count + " шт.";
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
                Инфо.Ошибка("Необходимо сканировать ШК грузового места.");
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
                    item.Selected = true;

                    return;
                }
            }

            // проверка места на сервере

            Cursor.Current = Cursors.WaitCursor;
            ОтветСервера = Обмен.ПослатьСтроку("ОбработкаГрузовыхМест_Сканирование", ТекущиеМесто);
            Cursor.Current = Cursors.Default;

            if (ОтветСервера == null) return;

            if (ОтветСервера[0][0] == "ГрузовоеМестоДобавлено")
            {
                string[] row = { ТекущиеМесто, ОтветСервера[0][1] };

                ListViewItem item = СписокГрузовыхМест.Items.Add(new ListViewItem(row));

                Данные.СписокГрузовыхМестДобавить(ТекущиеМесто, ОтветСервера[0][1], ОтветСервера[0][2]);

                СписокГрузовыхМест.EnsureVisible(item.Index);

                item.Focused = true;
                item.Selected = true;
   
                РаботаСоСканером.Звук.Ок();
            }

            УстановитьДоступностьЭлементовФормы();
            УстановитьТекстПодсказки();
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

        private void СотрудникиРедактироватьСписок()
        {
            ФормаВыбораСотрудников фСотрудники = new ФормаВыбораСотрудников(Данные.Сотрудники);

            DialogResult d = фСотрудники.ShowDialog();

            if (d == DialogResult.OK)
            {
                Данные.Сотрудники = фСотрудники.Список;

                Данные.СохранитьВФайл();

                РаботаСоСканером.Звук.Ок(); // список отредактирован
            }
        }


    }
}