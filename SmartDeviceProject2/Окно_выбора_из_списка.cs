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
    public partial class Окно_выбора_из_списка : Form
    {
        private Пакеты Обмен; 
        private int КолонкаРучногоВыбора = 0;
        private ПоследовательностьОкон Последовательность;

        public Окно_выбора_из_списка(ПоследовательностьОкон ПоследовательностьОкон)
        {
            InitializeComponent();
            Последовательность = ПоследовательностьОкон;
            Обмен = new Пакеты(ПоследовательностьОкон.Операция+" ВыборЗадания"); //Сформировали пакет с операцией состоящей например "Подбор ВыборЗадания"
        }

        public virtual void _Назад()
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();//Нажали назад, необходимо попасть на предыдущее окно, думаю можно и самому решить этот вопрос без обращения к серверу
        
        }

        public virtual void _Далее()
        {
            var ВыбраннаяСтрока = СписокВыбора.FocusedItem;
            if (ВыбраннаяСтрока == null) return;
            string ВыбранноеЗначение = КолонкаРучногоВыбора < 1?ВыбраннаяСтрока.Text:ВыбраннаяСтрока.SubItems[КолонкаРучногоВыбора-1].Text;
            Последовательность.ОтветСервера = Обмен.ПослатьСтроку(ВыбранноеЗначение, Последовательность.ТекущееОкно, "РучнойВыбор");
            if (Последовательность.ОтветСервера == null) return; // в случае ошибки остаться в этом же окне
            this.DialogResult = DialogResult.Retry;
            this.Close();

        }

        public void ПриНажатииНаКнопку(object sender, EventArgs Аргументы)
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

         public virtual void Окно_выбора_из_списка_KeyDown(object sender, KeyEventArgs e)
         {
             if (РаботаСоСканером.НажатаКлавишаСкан(e))
             {
                 string СтрокаСкан = РаботаСоСканером.Scan();
                 if (СтрокаСкан.Length != 0)
                 {
                     e.Handled = true;
                     Последовательность.ОтветСервера = Обмен.ПослатьСтроку(СтрокаСкан, Последовательность.ТекущееОкно, "СканированВыбор");
                     if (Последовательность.ОтветСервера == null) return; // в случае ошибки остаться в этом же окне
                     this.DialogResult = DialogResult.Retry;
                     this.Close();
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
             if ((e.KeyCode == System.Windows.Forms.Keys.Enter))
             {
                 _Далее();
             }

         }

         public virtual void Окно_выбора_из_списка_Load(object sender, EventArgs e)
         {
             ЭлементыФормыЗаполнения ЭлементыФормы = new ЭлементыФормыЗаполнения();
             ЭлементыФормы.Инструкция = this.Инструкция;
             ЭлементыФормы.СписокВыбора = this.СписокВыбора;
             ЭлементыФормы.ТекстДЯ = this.Пользователь;
             ЭлементыФормы.Пользователь = this.Пользователь;
             ЗаполнениеЭлементовФормы.ЗаполнитьФорму(ЭлементыФормы, ref Последовательность.ОтветСервера, ref КолонкаРучногоВыбора);
         }

         private void СписокВыбора_ItemActivate(object sender, EventArgs e)
         {
             _Далее();
         }

    }
}