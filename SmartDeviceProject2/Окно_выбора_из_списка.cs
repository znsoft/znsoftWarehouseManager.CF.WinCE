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

namespace СкладскойУчет
{
    public partial class Окно_выбора_из_списка : Form
    {
        Пакеты Обмен; //= new Пакеты("ВыборЗадания");
        public Стр[] Строки;
        public int КолонкаРучногоВыбора = 0;
        ПоследовательностьОкон ПоследовательностьОкон;

        public Окно_выбора_из_списка(ПоследовательностьОкон ПоследовательностьОкон, Стр[] Строки)
        {
            InitializeComponent();
            this.ПоследовательностьОкон = ПоследовательностьОкон;
            Обмен = new Пакеты(ПоследовательностьОкон.Операция+" ВыборЗадания");
            this.Строки = Строки;
        }

        public void _Назад()
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        
        }

        public void _Далее()
        {
            var ВыбраннаяСтрока = СписокВыбора.FocusedItem;
            if (ВыбраннаяСтрока == null) return;
            string ВыбранноеЗначение = КолонкаРучногоВыбора < 1?ВыбраннаяСтрока.Text:ВыбраннаяСтрока.SubItems[КолонкаРучногоВыбора-1].Text;
            Строки = Обмен.ПослатьСтроку(ВыбранноеЗначение, ПоследовательностьОкон.ТекущееОкно, "РучнойВыбор");
            if (Строки == null) return;
            this.DialogResult = DialogResult.OK;
            this.Close();

        }



         private void ПриНажатииНаКнопку(object sender, EventArgs Аргументы)
        {
            Button Кнопка = (Button)sender;
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
                 // Enter
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
             bool ЗаполнениеТаблицы = false;
             foreach (var Строка in Строки) {
                 if (ЗаполнениеТаблицы) {
                     if (Строка.П1.Contains("КонецТаблицы")) { ЗаполнениеТаблицы = false; continue; }
                     ListViewItem НоваяСтрока = new ListViewItem();
                     НоваяСтрока.Text = Строка.П1;
                     НоваяСтрока.SubItems.Add(Строка.П2);
                     НоваяСтрока.SubItems.Add(Строка.П3);
                     НоваяСтрока.SubItems.Add(Строка.П4);
                     НоваяСтрока.SubItems.Add(Строка.П5);
                     СписокВыбора.Items.Add(НоваяСтрока);
                     continue;
                 }
                 if (Строка.П1.Contains("ДобавитьКолонкуСписка")) ДобавитьКолонку(Строка.П2, int.Parse(Строка.П3));
                 if (Строка.П1.Contains("ЗаполнитьТаблицу")) { ЗаполнениеТаблицы = true; }
                 if (Строка.П1.Contains("КолонкаРучногоВыбора")) { КолонкаРучногоВыбора = int.Parse(Строка.П2); }
             
             
             
             }
         }

    }
}