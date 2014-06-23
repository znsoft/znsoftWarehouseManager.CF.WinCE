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
        Пакеты Обмен = new Пакеты("ВыборЗадания");
        СтрокаНоменклатуры[] Строки;


        public Окно_выбора_из_списка(ПоследовательностьОкон ПоследовательностьОкон, СтрокаНоменклатуры[] Строки)
        {
            InitializeComponent();
            //this.Строки = Строки;
        }

        public void _Назад()
        {
            MessageBox.Show("Test");
        
        
        
        }

         private void ПриНажатииНаКнопку(object sender, EventArgs Аргументы)
        {
            Button Кнопка = (Button)sender;
            MethodInfo method = this.GetType().GetMethod("_" + Кнопка.Name);
             if(method == null) 
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

    }
}