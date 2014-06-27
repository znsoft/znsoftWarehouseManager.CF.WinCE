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
        Пакеты Обмен; //= new Пакеты("ВыборЗадания");
        //public string[][] Строки;
        public int КолонкаРучногоВыбора = 0;
        ПоследовательностьОкон Последовательность;

        public Окно_выбора_из_списка(ПоследовательностьОкон ПоследовательностьОкон)
        {
            InitializeComponent();
            Последовательность = ПоследовательностьОкон;
            Обмен = new Пакеты(ПоследовательностьОкон.Операция+" ВыборЗадания"); //Сформировали пакет с операцией состоящей например "Подбор ВыборЗадания"
           // this.Строки = Строки; //передача ссылки на буфер ответа из предыдущей операции , для заполения табличных даннх на экране
            //Строки = null;
        }

        public void _Назад()
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();//Нажали назад, необходимо попасть на предыдущее окно, думаю можно и самому решить этот вопрос без обращения к серверу
        
        }

        public void _Далее()
        {
            var ВыбраннаяСтрока = СписокВыбора.FocusedItem;
            if (ВыбраннаяСтрока == null) return;
            string ВыбранноеЗначение = КолонкаРучногоВыбора < 1?ВыбраннаяСтрока.Text:ВыбраннаяСтрока.SubItems[КолонкаРучногоВыбора-1].Text;
            Последовательность.ОтветСервера = Обмен.ПослатьСтроку(ВыбранноеЗначение, Последовательность.ТекущееОкно, "РучнойВыбор");
            if (Последовательность.ОтветСервера == null) return; // в случае ошибки остаться в этом же окне
            this.DialogResult = DialogResult.Retry;
            this.Close();

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
                 // Left
             }
             if ((e.KeyCode == System.Windows.Forms.Keys.Right))
             {
                 // Right
             }
             if ((e.KeyCode == System.Windows.Forms.Keys.Enter))
             {
                 _Далее();
             }

         }


         private void ДобавитьКолонку(string Колонка, int Ширина) {

             var columnHeader = new ColumnHeader();
             columnHeader.Text = Ширина == 0?"":Колонка;
             columnHeader.Width = Ширина;
             СписокВыбора.Columns.Add(columnHeader);
         }

         private void Окно_выбора_из_списка_Load(object sender, EventArgs e)
         {
             var Авторизован = (NetworkCredential)СоединениеВебСервис.ПолучитьСервис().Сервис.Credentials;
            Пользователь.Text = Авторизован.UserName;
             bool ЗаполнениеТаблицы = false;
             foreach (var Строка in Последовательность.ОтветСервера)
             {
                 if (ЗаполнениеТаблицы) {
                     if (Строка[0].Contains("КонецТаблицы")) { ЗаполнениеТаблицы = false; continue; }
                     ListViewItem НоваяСтрока = new ListViewItem();
                     НоваяСтрока.Text = Строка[0];
                     for(int i = 1;i<Строка.Count();i++)
                     {
                         НоваяСтрока.SubItems.Add(Строка[i]);
                     }

                     for (int i = 1; i < Строка.Count(); i++)
                     {
                         НоваяСтрока.SubItems.Add(Строка[i]);
                     }

                     СписокВыбора.Items.Add(НоваяСтрока);
                     continue;
                 }
                 if (Строка[0].Contains("ДобавитьКолонкуСписка")) ДобавитьКолонку(Строка[1], int.Parse(Строка[2]));
                 if (Строка[0].Contains("ЗаполнитьТаблицу")) { ЗаполнениеТаблицы = true; }
                 if (Строка[0].Contains("КолонкаРучногоВыбора")) { КолонкаРучногоВыбора = int.Parse(Строка[1]); }
                 if (Строка[0].Contains("ТекстИнструкции")) Инструкция.Text = Строка[1];
             
             
             }
         }

         private void СписокВыбора_ItemActivate(object sender, EventArgs e)
         {
             _Далее();
         }

    }
}