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

namespace СкладскойУчет
{
    public partial class ФормаАвторизации : Form
    {
        Настройки ПараметрыСеанса = new Настройки();

        public ФормаАвторизации()
        {
            InitializeComponent();
        }




        private void Form1_Load(object sender, EventArgs e)
        {
            
            var StartTime = DateTime.Now;
            
            var СлучайноеЧисло = new Random();
            СоединениеВебСервис.ИдентификаторСоединения = СоединениеВебСервис.НомерВерсии + ":" + СлучайноеЧисло.Next().ToString().Substring(0, 4) + "@" + StartTime.Year.ToString().Substring(3,1) + StartTime.Month.ToString() + StartTime.Day.ToString() + StartTime.Second.ToString();
            ПолучитьСписокПользователей();
            ВерсияПрограммы.Text = "Версия " + СоединениеВебСервис.НомерВерсии;

        }

        private void ПолучитьСписокПользователей()
        {
            Сотрудник.Items.Clear();
            var Обмен = new Пакеты("СписокПользователей");
            var Url = ПараметрыСеанса.ПолучитьПолнуюВебСсылку();
            if (Url == null) return;
            Обмен.Соединение.Сервис.Url = Url;
            var СписокПользователей = Обмен.ПослатьСтроку("ВерсияКлиента");
            if (СписокПользователей == null) return;
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
            ТекущийСкладТекст.Text = Текущийсклад;
            СписокПользователей = null;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool УспешнаяАвторизация = false;
            var Обмен = new Пакеты("Авторизация");
            var Url = ПараметрыСеанса.ПолучитьПолнуюВебСсылку();
            Обмен.Соединение.Сервис.Url = Url;

            Обмен.Соединение.Сервис.Credentials = new NetworkCredential(Сотрудник.Text, Пароль.Text);
            var СписокПользователей = Обмен.ПослатьСтроку(СоединениеВебСервис.ИдентификаторСоединения);
            if (СписокПользователей == null){ Инфо.Ошибка("Ошибка соединения, Не удалось пройти авторизацию на сервере."); return;}
            foreach (var СтрокаПользователь in СписокПользователей)
            {
                УспешнаяАвторизация = УспешнаяАвторизация || СтрокаПользователь[1].Contains("Успех");
                СоединениеВебСервис.СтрокаДоступныхРолей = СтрокаПользователь[0];
            }

            if (УспешнаяАвторизация)
            {
                ПараметрыСеанса.Хранилище.ИмяПользователя = Сотрудник.Text;
                ПараметрыСеанса.Сохранить();
                СписокПользователей = null;
                this.DialogResult = DialogResult.OK;
                this.Close();
                return;
            }

            ТекстОшибки.Text = "Ошибка логина или пароля";

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
            if (e.KeyCode == Keys.Enter) { e.Handled = true; button1_Click(sender, e); }
        }

        private void Меню_Click(object sender, EventArgs e)
        {
            var ФормаНастроек = new ФормаНастроек();
            var РезультатНастроек = ФормаНастроек.ShowDialog();
            if (РезультатНастроек == DialogResult.OK) {
                ПолучитьСписокПользователей();
            }
        }
    }
}