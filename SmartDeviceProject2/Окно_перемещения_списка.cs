using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using СкладскойУчет;
using СкладскойУчет.СсылкаНаСервис;
using System.Net;

namespace СкладскойУчет
{
    public partial class Окно_перемещения_списка : Form
    {
        private Пакеты Обмен; 
        private int КолонкаРучногоВыбора = 0;
        private ПоследовательностьОкон Последовательность;

        public Окно_перемещения_списка(ПоследовательностьОкон ПоследовательностьОкон)
        {
            InitializeComponent();
            Последовательность = ПоследовательностьОкон;
        }

        public void _Назад()
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();//Нажали назад, необходимо попасть на предыдущее окно, думаю можно и самому решить этот вопрос без обращения к серверу
        
        }

        public void _Далее()
        {

        }

         private void ПриНажатииНаКнопку(object sender, EventArgs Аргументы)
        {
            Button Кнопка = (Button)sender;
            switch (Кнопка.Name)
            {
                case "Назад":
                    _Назад();
                    return;
                case "Далее":
                    _Далее();
                    return;
            }
            MethodInfo method = this.GetType().GetMethod("_" + Кнопка.Name);
             if(method != null) 
            method.Invoke(this, null);
        }

         private void Окно_выбора_из_списка_KeyDown(object sender, KeyEventArgs e)
         {
             if (РаботаСоСканером.НажатаКлавишаСкан(e))
             {
                 e.Handled = true;
                 string СтрокаСкан = РаботаСоСканером.Scan();
                 if (СтрокаСкан.Length != 0)
                 {
                     СканТовара(СтрокаСкан);
                 }
                 return;
             }

             foreach (var ЭлементФормы in this.Controls)
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


             if (РаботаСоСканером.НажатаПраваяПодэкраннаяКлавиша(e))
             {
                 _Далее();
             }
             if (РаботаСоСканером.НажатаЛеваяПодэкраннаяКлавиша(e))
             {
                 _Назад();
             }

         }

         private void СканТовара(string СтрокаСкан)
         {
             
         }

         private void Окно_выбора_из_списка_Load(object sender, EventArgs e)
         {
             Информация.Text = "";
             ЭлементыФормыЗаполнения ЭлементыФормы = new ЭлементыФормыЗаполнения();
             ЭлементыФормы.Инструкция = this.Инструкция;
             ЭлементыФормы.СписокВыбора = this.СписокПеремещения;
             ЭлементыФормы.ТекстДЯ = this.Пользователь;
             ЭлементыФормы.Пользователь = this.Пользователь;
             ЗаполнениеЭлементовФормы.ЗаполнитьФорму(ЭлементыФормы, ref Последовательность.ОтветСервера, out КолонкаРучногоВыбора);
         }


    }
}