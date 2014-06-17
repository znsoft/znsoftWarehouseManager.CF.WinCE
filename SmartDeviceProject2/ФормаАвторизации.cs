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

namespace SmartDeviceProject2
{

    public partial class ФормаАвторизации : Form
    {
        public ФормаАвторизации()
        {
            
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            //var Соединение = СоединениеВебСервис.ПолучитьСервис();
            //Соединение.Сервис.Url = "http://adm-zheludkov/zheludkov_sklad/ws/TSD.1cws"; //  необходимо считать настройки из файла и применить УРЛ
            var Обмен = new Пакеты("СписокПользователей");
            var СписокПользователей = Обмен.ПослатьСтроку("123", "123", 123);
            foreach (var СтрокаПользователь in СписокПользователей)
            Сотрудник.Items.Add(СтрокаПользователь.Наименование);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var Обмен = new Пакеты("ТСД");
            var Сервис = СоединениеВебСервис.ПолучитьСервис();
            Сервис.Сервис.Credentials = new NetworkCredential(Сотрудник.Text, Пароль.Text);
            try
            {
                var СписокПользователей = Обмен.ПослатьСтроку("Авторизация", "192.168.1.1", 1234);
            }
            catch (WebException o)
            {
                Console.WriteLine("{0}", o.GetBaseException().Message);
                return;
            }
            
            this.DialogResult = DialogResult.OK;
            this.Close();
            
        }



       
        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
            // Application.Exit();
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