using System;
using System.Xml;
using System.Xml.Linq;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Net;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.IO;
using СкладскойУчет.Сеть;

namespace СкладскойУчет
{
    public partial class ФормаАвторизации : Form
    {
        Настройки ПараметрыСеанса = new Настройки();
        Пакеты Обмен;
        public ФормаАвторизации()
        {
            InitializeComponent();
           
        }



        private void Form1_Load(object sender, EventArgs e)
        {
            СоединениеВебСервис.ИдентификаторСоединения = Инфо.ГенерироватьИдентификатор();
            string Ссылка = ПараметрыСеанса.ПолучитьПолнуюВебСсылку();
            ПолучитьСписокПользователей();
            ПолеВводаСервер.Text = ПараметрыСеанса.Хранилище.Сервер;
            ВерсияПрограммы.Text = "Версия " + СоединениеВебСервис.НомерВерсии;

            if(!string.IsNullOrEmpty(Ссылка))
            if (Обновление.ПроверитьОбновление())
            {
                Application.Exit();
                return;
            }

        }

        private bool ПолучитьСписокПользователей()
        {
            Сотрудник.Items.Clear();
            Обмен = new Пакеты("СписокПользователей");
            if (string.IsNullOrEmpty(ПараметрыСеанса.СформироватьСсылку())) return false;

            var СписокПользователей = Обмен.ПослатьСтроку(СоединениеВебСервис.ИдентификаторСоединения);
            if (СписокПользователей == null) return false;
            string Текущийсклад = "";
            foreach (var СтрокаПользователь in СписокПользователей)
            {
                Текущийсклад = СтрокаПользователь[0];
                Сотрудник.Items.Add(СтрокаПользователь[1]);
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
            //ТекущийСкладТекст.Text = Текущийсклад;
            СписокПользователей = null;
            return true;
        }

        private void кнопкаВойтиНажатие(object sender, EventArgs e)
        {
            Обмен = new Пакеты("Авторизация");
            var Url = ПараметрыСеанса.ПолучитьПолнуюВебСсылку();
            if (string.IsNullOrEmpty(Url)) { Инфо.Ошибка("Неверно заполнены параметры сервера!"); return; } 
            Обмен.Соединение.Сервис.Url = Url;

            Обмен.Соединение.Сервис.Credentials = new NetworkCredential(Сотрудник.Text, Пароль.Text);
            var ОтветАвторизации = Обмен.ПослатьСтроку(СоединениеВебСервис.ИдентификаторСоединения);

            if (ОтветАвторизации == null)
            {
                ТекстОшибки.Text = "Ошибка логина или пароля";
                return;
            }
            СоединениеВебСервис.СтрокаДоступныхРолей = "";
            foreach (var СтрокаОтвета in ОтветАвторизации)
            {
                СоединениеВебСервис.СтрокаДоступныхРолей = СоединениеВебСервис.СтрокаДоступныхРолей + СтрокаОтвета[0];
            }

                ПараметрыСеанса.Хранилище.ИмяПользователя = Сотрудник.Text;
                ПараметрыСеанса.Сохранить();
                ОтветАвторизации = null;
                this.DialogResult = DialogResult.OK;
                this.Close();
                return;
        }




        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void СписокФирм_SelectedIndexChanged(object sender, EventArgs e)
        {



        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void ПоказыватьПароль_CheckStateChanged(object sender, EventArgs e)
        {
            Пароль.PasswordChar = ПоказыватьПароль.Checked ? (char)0 : '*';
            Пароль.Update();
        }

        private void ФормаАвторизации_Closing(object sender, CancelEventArgs e)
        {

        }

        private void Пароль_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) { e.Handled = true; кнопкаВойтиНажатие(sender, e); }
        }

        private void Меню_Click(object sender, EventArgs e)
        {
            var ФормаНастроек = new ФормаНастроек();
            var РезультатНастроек = ФормаНастроек.ShowDialog();
            if (РезультатНастроек == DialogResult.OK) {
                ПолучитьСписокПользователей();
            }
        }

        private void КнопкаОбновить_Click(object sender, EventArgs e)
        {
            КнопкаОбновить.BackColor = Color.Gray;
            КнопкаОбновить.Update();
            КнопкаОбновить.Refresh();
            КнопкаОбновить.BackColor = Color.WhiteSmoke;
            if (string.IsNullOrEmpty(ПолеВводаСервер.Text)) { Инфо.Ошибка("Не заполнено имя сервера"); return; }
            ПараметрыСеанса.Хранилище.Сервер = ПолеВводаСервер.Text;
            string Url = ПараметрыСеанса.СформироватьСсылку();
            
            if (Url == null) return;
            Обмен.Соединение.Сервис.Url = Url;
            if(ПолучитьСписокПользователей()) ПараметрыСеанса.Сохранить();
            if (!string.IsNullOrEmpty(Url))
                if (Обновление.ПроверитьОбновление())
                {
                    Application.Exit();
                    return;
                }

        }
    }
}