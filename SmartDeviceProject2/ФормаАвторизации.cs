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

            var Соединение = СоединениеВебСервис.ПолучитьСервис();
            var Сервис = Соединение.Сервис;
            Сервис.Url = "http://adm-zheludkov/zheludkov_sklad/ws/TSD.1cws";
            List<СсылкаНаСервис.СтрокаНоменклатуры> Список = new List<SmartDeviceProject2.СсылкаНаСервис.СтрокаНоменклатуры>();
            СсылкаНаСервис.СтрокаНоменклатуры СтрокаНоменклатуры = new СсылкаНаСервис.СтрокаНоменклатуры();
            СтрокаНоменклатуры.Код = "423";
            СтрокаНоменклатуры.Количество = "503";
            СтрокаНоменклатуры.Наименование = "123";
            Список.Add(СтрокаНоменклатуры);
            СсылкаНаСервис.СтрокаНоменклатуры[] СписокПользователей = Сервис.ОбменТСД("СписокПользователей",Список.ToArray());
            foreach (var СтрокаПользователь in СписокПользователей)
            Сотрудник.Items.Add(СтрокаПользователь.Наименование);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            
            
            var frm2 = new Form2();
            frm2.Show();
            frm2.Activate();

        }



       
        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
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
    }
}