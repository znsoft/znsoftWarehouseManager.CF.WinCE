using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Text.RegularExpressions;
using System.Reflection;
using SDK.English;
using System.Data.SqlTypes;

namespace СкладскойУчет
{
    public partial class ОсновноеМеню : Form
    {
        private РаботаСоСканером Сканер;


        public ОсновноеМеню()
        {
            InitializeComponent();
            this.KeyPreview = true;
            //Выход.Focus();
        }

        public void _Выход()
        {
            Выход.Enabled = false;
            Выход.Text = "Отключение...";
            this.Close();
        }

        public void _Подбор()
        {
            ПоследовательностьОкон Окна = new ПоследовательностьОкон("Подбор");
            Окна.ЗапуститьСледующееОкно();

        }

        public void _Перемещение()
        {
            //Перемещение.Text = "1."+РаботаСоСканером.Scan();

        }



        public void _Инвентаризация()
        {

        }

        private void ОсновноеМеню_Load(object sender, EventArgs e)
        {
            var Авторизован = (NetworkCredential)СоединениеВебСервис.ПолучитьСервис().Сервис.Credentials;
            Пользователь.Text = Авторизован.UserName;
        }



        private void ПриНажатииНаКнопку(object sender, EventArgs Аргументы)
        {
            Button Кнопка = (Button)sender;
            switch(Кнопка.Name){
                case "Выход":
                    _Выход();
                    return;
                case "Подбор":
                    _Подбор();
                    return;
                case "Перемещение":
                    _Перемещение();
                    return;
                case "Инвентаризация":
                    _Инвентаризация();
                    return;
            
            }

            MethodInfo method = this.GetType().GetMethod("_" + Кнопка.Name);
            method.Invoke(this, null);
        }

        private void ОсновноеМеню_Closing(object sender, CancelEventArgs e)
        {

        }

        private void ОсновноеМеню_Closed(object sender, EventArgs e)
        {
            new Пакеты("Выход").ПослатьСтроку(СоединениеВебСервис.ИдентификаторСоединения);
        }


        private void ОсновноеМеню_KeyDown(object sender, KeyEventArgs e)
        {
            var Панель = Табулятор.TabPages[Табулятор.SelectedIndex].Controls;
            if (РаботаСоСканером.НажатаКлавишаСкан(e))
            {
                string СтрокаСкан = РаботаСоСканером.Scan();
                if (СтрокаСкан.Length != 0)
                {
                    ПолучениеИнформации(СтрокаСкан);
                }
                return;


            }




            foreach (var ЭлементФормы in Панель)
                if (ЭлементФормы is Button)
                {
                    Button Кнопка = (Button)ЭлементФормы;
                    if ((char)Кнопка.Text[0] == (char)e.KeyValue)
                    {
                        Кнопка.Focus();
                        ПриНажатииНаКнопку(Кнопка, new EventArgs());
                        return;
                    }
                }

            if ((e.KeyCode == System.Windows.Forms.Keys.Up))
            {
                // Up
            }
            if ((e.KeyCode == System.Windows.Forms.Keys.Down))
            {
                // Down
            }
            if ((e.KeyCode == System.Windows.Forms.Keys.Left))
            {
                Табулятор.SelectedIndex = 0;
            }
            if ((e.KeyCode == System.Windows.Forms.Keys.Right))
            {
                Табулятор.SelectedIndex = 1;
            }
            if ((e.KeyCode == System.Windows.Forms.Keys.Enter))
            {
                // Enter
            }




        }

        private void ПолучениеИнформации(string СтрокаСкан)
        {

            Табулятор.SelectedIndex = 1;
            СписокИнформации.Text = "Получение информации...";
            Табулятор.Update();

            var Обмен = new Пакеты("Информация");
            var ОтветСервера = Обмен.ПослатьСтроку(СтрокаСкан);

            if (ОтветСервера == null || ОтветСервера.Count() == 0)
            {
                СписокИнформации.Text = "Информация по коду не найдена";
                return;
            }
            string Информация = "";
            foreach (var СтрокаОтвета in ОтветСервера)
            {

                Информация = Информация + СтрокаОтвета[1] + "\r\n" + "\r\n";
                // return;
            }
            СписокИнформации.Text = Информация;
        }


    }
}