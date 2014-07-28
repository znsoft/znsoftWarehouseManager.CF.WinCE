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
    public partial class ИнтерактивныйВыборТовара : Form
    {
        public string ВыбранГуид;

        public ИнтерактивныйВыборТовара(ПоследовательностьОкон ПоследовательностьОкон)
        {
            InitializeComponent();
        }

        public virtual void _Назад()
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();//Нажали назад, необходимо попасть на предыдущее окно, думаю можно и самому решить этот вопрос без обращения к серверу
        
        }


        public void _Далее()
        {
            var ВыбраннаяСтрока = СписокВыбора.FocusedItem;
            if (ВыбраннаяСтрока == null) return;
            ВыбранГуид = ВыбраннаяСтрока.SubItems[2].Text;
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

        }

         public void Окно_выбора_из_списка_KeyDown(object sender, KeyEventArgs e)
         {

             foreach (var ЭлементФормы in this.Controls)
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
             if (РаботаСоСканером.НажатаКлавишаСкан(e))
             {
                 _Далее();
             }

         }
         public virtual void Окно_выбора_из_списка_Load(object sender, EventArgs e)
         {
             try
             {
                 var ВыбраннаяСтрока = СписокВыбора.Items[0];
                 if (ВыбраннаяСтрока == null) return;
                 ВыбраннаяСтрока.Selected = true;
                 ВыбраннаяСтрока.Focused = true;
                 СписокВыбора_SelectedIndexChanged(this, new EventArgs());
             }
             catch (Exception) { }

         }

         private void СписокВыбора_ItemActivate(object sender, EventArgs e)
         {
             _Далее();
         }

         private void СписокВыбора_SelectedIndexChanged(object sender, EventArgs e)
         {
             var ВыбраннаяСтрока = СписокВыбора.FocusedItem;
            if (ВыбраннаяСтрока == null) return;
            НаименованиеТовара.Text = ВыбраннаяСтрока.SubItems[1].Text;
            СписокВыбора.Update();
                

         }

    }
}