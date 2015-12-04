using System;
using System.Net;
using System.Windows.Forms;
using System.Collections.Generic;


namespace СкладскойУчет
{
    public partial class ФормаАвторизации : Form
    {
        Настройки ПараметрыСеанса = new Настройки();
        Пакеты Обмен;

        Dictionary<string, string> ДоступныеФилиалы;

        public ФормаАвторизации()
        {
            InitializeComponent();

            ДоступныеФилиалы = new Dictionary<string, string>();
        }

        private void ФормаАвторизации_Load(object sender, EventArgs e)
        {
            // Для начала проверим, есть ли обновление приложения
            if (Обновление.ПроверитьОбновление())
            {
                Logs.WriteLog("Exit for update " + СоединениеВебСервис.НомерВерсии);
                Application.Exit();
                return;
            }

            СоединениеВебСервис.ИдентификаторСоединения = СоединениеВебСервис.ГенерироватьИдентификатор();

            // Получаем параметры сеанса
            ПараметрыСеанса.Загрузить();

            ПолеВводаСервер.Text = ПараметрыСеанса.Хранилище.Сервер;
            ВерсияПрограммы.Text = "Версия " + СоединениеВебСервис.НомерВерсии;

            ПолучитьСписокПользователей();

        }

        private bool ПолучитьСписокПользователей()
        {
            Сотрудник.Items.Clear();

            string Url = ПараметрыСеанса.СформироватьСсылку();
            if (string.IsNullOrEmpty(Url)) return false;

            Обмен = new Пакеты("СписокПользователей");
            Обмен.Соединение.Сервис.Url = Url;

            var СписокПользователей = Обмен.ПослатьСтроку(СоединениеВебСервис.ИдентификаторСоединения);
            if (СписокПользователей == null) return false;

            foreach (var СтрокаПользователь in СписокПользователей)
            {
                Сотрудник.Items.Add(СтрокаПользователь[0]);
            }

            if (ПараметрыСеанса.Хранилище.ИмяПользователя == null)
            {
                Сотрудник.Focus();
            }
            else
            {
                Сотрудник.Text = ПараметрыСеанса.Хранилище.ИмяПользователя;
                Пароль.Focus();
            }

            СписокПользователей = null;
            return true;
        }

        private void КнопкаВойтиНажатие(object sender, EventArgs e)
        {    
            string Url = ПараметрыСеанса.СформироватьСсылку();
            if (string.IsNullOrEmpty(Url)) { Инфо.Ошибка("Неверно заполнены параметры сервера!"); return; }

            Обмен = new Пакеты("Авторизация");
            Обмен.Соединение.Сервис.Url = Url;
            Обмен.Соединение.Сервис.Credentials = new NetworkCredential(Сотрудник.Text, Пароль.Text);

            var ОтветСервера = Обмен.ПослатьСтроку(СоединениеВебСервис.ИдентификаторСоединения, ДоступныеФилиалы[свДоступныеФилиалы.Text]);

            if (ОтветСервера == null)
            {
                ТекстОшибки.Text = "Ошибка логина или пароля";
                return;
            }

            СоединениеВебСервис.СтрокаДоступныхРолей  = ОтветСервера[0][0];
            СоединениеВебСервис.ПодборТовараВМеста    = (ОтветСервера[0][1] == "true");
            СоединениеВебСервис.ЭтоТерминал           = (ОтветСервера[0][2] == "true");
            СоединениеВебСервис.ПодборЗаказовКлиентов = (ОтветСервера[0][3] == "true");
            СоединениеВебСервис.Пользователь          = Сотрудник.Text;

            ПараметрыСеанса.Хранилище.ИмяПользователя = Сотрудник.Text;
            ПараметрыСеанса.Сохранить();

            this.DialogResult = DialogResult.OK;
            this.Close();
            return;
        }

        // Ввод пароля
        private void Пароль_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) { e.Handled = true; КнопкаВойтиНажатие(sender, e); }
        }

        private void ПоказыватьПароль_CheckStateChanged(object sender, EventArgs e)
        {
            Пароль.PasswordChar = ПоказыватьПароль.Checked ? (char)0 : '*';
            Пароль.Update();
        }

        // Ввод имени сервера
        private void ПолеВводаСервер_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) { e.Handled = true; КнопкаОбновить_Click(sender, new EventArgs()); }
        }

        private void КнопкаОбновить_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            КнопкаОбновить.Image = Properties.Resources.КнопкаОбновить2;
            КнопкаОбновить.Update();
            КнопкаОбновить.Refresh();
            ОбработатьВводСервера();
            КнопкаОбновить.Image = Properties.Resources.КнопкаОбновить;
            Cursor.Current = Cursors.Default;

        }

        private void ОбработатьВводСервера() 
        {
            if (string.IsNullOrEmpty(ПолеВводаСервер.Text)) { Инфо.Ошибка("Не заполнено имя сервера"); return; }
            ПараметрыСеанса.Хранилище.Сервер = ПолеВводаСервер.Text;
            string Url = ПараметрыСеанса.СформироватьСсылку();

            if (string.IsNullOrEmpty(Url)) return;
            //Обмен.Соединение.Сервис.Url = Url;
            if (ПолучитьСписокПользователей()) ПараметрыСеанса.Сохранить();
            if (Обновление.ПроверитьОбновление())
            {
                Logs.WriteLog("Exit for update " + СоединениеВебСервис.НомерВерсии);
                Application.Exit();
                return;
            }
        }

        private void Сотрудник_SelectedIndexChanged(object sender, EventArgs e)
        {
             // при изменении сотрудника обновим доступные филиалы

            ДоступныеФилиалы.Clear();

            свДоступныеФилиалы.Items.Clear();

            // получим сотрудника

            if (string.IsNullOrEmpty(Сотрудник.Text))
                return;

            string Url = ПараметрыСеанса.СформироватьСсылку();

            if (string.IsNullOrEmpty(Url)) return;

            Обмен = new Пакеты("ДоступныеФилиалы");
            Обмен.Соединение.Сервис.Url = Url;

            string[][] ОтветСервера = Обмен.ПослатьСтроку(Сотрудник.Text);

            if (ОтветСервера == null)
                return;

            foreach (string[] str in ОтветСервера)
            {
                ДоступныеФилиалы.Add(str[1], str[0]);
                свДоступныеФилиалы.Items.Add(str[1]);
            }

            // спозиционируемя на первой строке списка выбора

            if (свДоступныеФилиалы.Items.Count > 0)
            {
                свДоступныеФилиалы.SelectedIndex = 0;
                свДоступныеФилиалы.Focus();
            }
        }

    }
}