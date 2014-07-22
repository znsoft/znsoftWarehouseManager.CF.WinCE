using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using СкладскойУчет;
using СкладскойУчет.СсылкаНаСервис;
using System.Net;

namespace СкладскойУчет
{
    class ИнтерактивныйВыборТовара : Окно_выбора_из_списка
    {
        public string ВыбранГуид;

        public ИнтерактивныйВыборТовара(ПоследовательностьОкон ПоследовательностьОкон)
            : base(ПоследовательностьОкон)
        {
        }


        public override void _Далее()
        {
            var ВыбраннаяСтрока = СписокВыбора.FocusedItem;
            if (ВыбраннаяСтрока == null) return;
            ВыбранГуид = ВыбраннаяСтрока.SubItems[2].Text;
            this.DialogResult = DialogResult.Retry;
            this.Close();

        }

        public override void Окно_выбора_из_списка_KeyDown(object sender, KeyEventArgs e)
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

        public override void Окно_выбора_из_списка_Load(object sender, EventArgs e)
         {

         }

    }
}
