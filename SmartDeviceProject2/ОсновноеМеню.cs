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
        private РаботаСоСканером Сканер;
        
        
        public ОсновноеМеню()
        {
            InitializeComponent();
            this.KeyPreview = true;
            Сканер = new РаботаСоСканером();
            
            Выход.Focus();
        }

        public void _Выход()
        {
            Выход.Enabled = false;
            Выход.Text = "Отключение...";
            this.Close();
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
            MethodInfo method = this.GetType().GetMethod("_" + Кнопка.Name);
            method.Invoke(this, null);
        }

        private void ОсновноеМеню_Closing(object sender, CancelEventArgs e)
        {

        }

        private void ОсновноеМеню_Closed(object sender, EventArgs e)
        {
            new Пакеты("ТСД").ПослатьСтроку("Выход", "Выход", 123);
        }
        
        private void ОсновноеМеню_KeyDown(object sender, KeyEventArgs e)
        {
            var Панель = Табулятор.TabPages[Табулятор.SelectedIndex].Controls;
            if (РаботаСоСканером.НажатаКлавишаСкан(e)) {
                string СтрокаСкан = РаботаСоСканером.Scan();
                if (СтрокаСкан.Length != 0) {
                    Табулятор.SelectedIndex = 1;
                    Информация.Text = "Получение информации...";
                    Табулятор.Update();
                    var Обмен = new Пакеты("Информация");
                    var ОтветСервера = Обмен.ПослатьСтроку(СтрокаСкан, СоединениеВебСервис.ИдентификаторСоединения, 0);
                    Информация.Text = "Информация по коду не найдена, сканируйте снова";
                    foreach (var СтрокаОтвета in ОтветСервера)
                    {
                        if (СтрокаОтвета.Код.Contains("ТекстИСвойства")) { Информация.Text = СтрокаОтвета.Наименование; return; }
                    }
                    return;
                }
            
            
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

    }
}