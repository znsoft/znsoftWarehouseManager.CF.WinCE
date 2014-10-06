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


namespace СкладскойУчет
{
    public partial class ОсновноеМеню : Form
    {
        public ОсновноеМеню()
        {
            new РаботаСоСканером();
            InitializeComponent();

            this.KeyPreview = true;
            Подбор.Focus();
            string стрРоли = СоединениеВебСервис.СтрокаДоступныхРолей;
        
            
            СоединениеВебСервис.Роли = "Отгрузка,Хранение,Подбор,Приемка,Прочие,Администратор".Split(',').ToDictionary(s => s, s => стрРоли.IndexOf(s) > 0);
            var Роли = СоединениеВебСервис.Роли;
            if (Роли["Администратор"]) return;
            Подбор.Enabled = Роли["Подбор"];
            Инвентаризация.Enabled = Роли["Хранение"];
            Перемещение.Enabled = Роли["Приемка"] || Роли["Подбор"];
            Подтоварка.Enabled = Роли["Хранение"];

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
            ПоследовательностьОкон Окна = new ПоследовательностьОкон("Перемещение");
            Окна.ЗапуститьСледующееОкно();
        }



        public void _Инвентаризация()
        {
            ПоследовательностьОкон Окна = new ПоследовательностьОкон("Инвентаризация");
            Окна.ЗапуститьСледующееОкно();

        }

        public void _Подтоварка()
        {
            ПоследовательностьОкон Окна = new ПоследовательностьОкон("Подтоварка");
            Окна.ЗапуститьСледующееОкно();

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
                case "Подтоварка":
                    _Подтоварка();
                    return;
            
            }

            //MethodInfo method = this.GetType().GetMethod("_" + Кнопка.Name);
            //method.Invoke(this, null);

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
                    e.Handled = true;
                    Инфо.ПолучениеИнформации(СтрокаСкан, СписокИнформации, Табулятор);
                }
                return;
            }

            foreach (var ЭлементФормы in Панель)
                if (ЭлементФормы is Button)
                {
                    Button Кнопка = (Button)ЭлементФормы;
                    if ((char)Кнопка.Text[1] == (char)e.KeyValue)
                    {
                        Кнопка.Focus();
                        ПриНажатииНаКнопку(Кнопка, new EventArgs());
                        return;
                    }
                }

            if (!РучнойКод.Focused)
            {
                if ((e.KeyCode == System.Windows.Forms.Keys.D1))
                {
                    Табулятор.SelectedIndex = 0;
                }
                if ((e.KeyCode == System.Windows.Forms.Keys.D2))
                {
                    Табулятор.SelectedIndex = 1;
                }
            }
            else {
                if ((e.KeyCode == System.Windows.Forms.Keys.Enter) || ((int)e.KeyCode == 119) )
                {

                    ИнформацияВРучномРежиме();

                }
            
            
            }

            if ((e.KeyCode == System.Windows.Forms.Keys.Left))
            {
                Табулятор.SelectedIndex = 0;
            }
            if ((e.KeyCode == System.Windows.Forms.Keys.Right))
            {
                Табулятор.SelectedIndex = 1;
            }

        }

        private void РучнойКод_LostFocus(object sender, EventArgs e)
        {
            ИнформацияВРучномРежиме();
        }

        private void ИнформацияВРучномРежиме()
        {
            if (РучнойКод.Text.Length > 3)
            {
                Инфо.ПолучениеИнформации(РучнойКод.Text, СписокИнформации, Табулятор);
                РучнойКод.Text = "";
                СписокИнформации.Focus();
            }
        }

        private void РучнойКод_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == System.Windows.Forms.Keys.Enter))
            {

                ИнформацияВРучномРежиме();

            }
        }




    }
}