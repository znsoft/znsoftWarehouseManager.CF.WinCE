using System;
using System.Windows.Forms;

namespace СкладскойУчет
{
    public partial class ИнтерактивныйВыборТовара : Form
    {
        public string ВыбранГуид;

        public ИнтерактивныйВыборТовара(ПоследовательностьОкон ПоследовательностьОкон)
        {
            InitializeComponent();
        }

        public virtual void ИнтерактивныйВыборТовара_Load(object sender, EventArgs e)
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

        public void ИнтерактивныйВыборТовара_KeyDown(object sender, KeyEventArgs e)
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


             if (РаботаСоСканером.НажатаПраваяПодэкраннаяКлавиша(e) || РаботаСоСканером.НажатаКлавишаСкан(e) || e.KeyCode == System.Windows.Forms.Keys.Enter)
             {
                 _Далее();
             }

             if (РаботаСоСканером.НажатаЛеваяПодэкраннаяКлавиша(e) || e.KeyCode == System.Windows.Forms.Keys.Escape)
             {
                 _Назад();
             }

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

         public void _Далее()
         {
             var ВыбраннаяСтрока = СписокВыбора.FocusedItem;
             if (ВыбраннаяСтрока == null) return;
             ВыбранГуид = ВыбраннаяСтрока.SubItems[2].Text;
             this.DialogResult = DialogResult.Retry;
             this.Close();

         }

         public virtual void _Назад()
         {
             this.DialogResult = DialogResult.Cancel;
             this.Close();

         }
    }
}