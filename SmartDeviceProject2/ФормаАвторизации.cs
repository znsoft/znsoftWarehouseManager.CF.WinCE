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
        public ФормаАвторизации()
        {
            
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var СлучайноеЧисло = new Random();
            СоединениеВебСервис.ИдентификаторСоединения = СлучайноеЧисло.Next().ToString();
            var Обмен = new Пакеты("СписокПользователей");
            var СписокПользователей = Обмен.ПослатьСтроку("1", СоединениеВебСервис.ИдентификаторСоединения, 0);
            foreach (var СтрокаПользователь in СписокПользователей)
            Сотрудник.Items.Add(СтрокаПользователь.Наименование);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool УспешнаяАвторизация = false;
            var Обмен = new Пакеты("ТСД");
            
            Обмен.Соединение.Сервис.Credentials = new NetworkCredential(Сотрудник.Text, Пароль.Text);
            var СписокПользователей = Обмен.ПослатьСтроку("Авторизация", СоединениеВебСервис.ИдентификаторСоединения, 0);

            foreach (var СтрокаПользователь in СписокПользователей)
            {
                УспешнаяАвторизация = УспешнаяАвторизация || СтрокаПользователь.Наименование.Contains("Успех");
                СоединениеВебСервис.СтрокаДоступныхРолей = СтрокаПользователь.Код;
            }

                if (УспешнаяАвторизация)
                {
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                    return;
                }
            
            
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
            Пароль.PasswordChar = ПоказыватьПароль.Checked?(char)0:'*';
            Пароль.Update();
        }

        private void ФормаАвторизации_Closing(object sender, CancelEventArgs e)
        {

        }
    }
}