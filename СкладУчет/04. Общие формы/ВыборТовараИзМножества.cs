using System;
using System.Windows.Forms;
using System.Collections.Generic;

namespace СкладскойУчет
{
    public partial class ВыборТовараИзМножества : Form
    {
        public string Гуид;

        public ВыборТовараИзМножества()
        {
            InitializeComponent();
        }

        public static string ВыбратьТоварИзМножества(IEnumerable<string[]> МассивТоваров)
        {
            ВыборТовараИзМножества Окно = new ВыборТовараИзМножества();

            var СписокВыбораНаФорме = Окно.СписокВыбора;

            foreach (string[] Товар in МассивТоваров)
            {
                ListViewItem НоваяСтрока = new ListViewItem();
                НоваяСтрока.Text = Товар[0]; // Код
                НоваяСтрока.SubItems.Add(Товар[1]); // Наименование
                НоваяСтрока.SubItems.Add(Товар[2]); // Гуид
                СписокВыбораНаФорме.Items.Add(НоваяСтрока);
            }

            DialogResult Результат = Окно.ShowDialog();
            if (Результат == DialogResult.OK) return Окно.Гуид;
            return null;
        }

        public virtual void ВыборТовараИзМножества_Load(object sender, EventArgs e)
        {
            РаботаСоСканером.Звук.Ошибка();

            // Выбираем первую строку
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

        public void ВыборТовараИзМножества_KeyDown(object sender, KeyEventArgs e)
         {

             foreach (var ЭлементФормы in this.Controls)
                 if (ЭлементФормы is Button)
                 {
                     Button Кнопка = (Button)ЭлементФормы;
                     if ((char)Кнопка.Text[1] == (char)e.KeyValue)
                     {
                         Кнопка.Focus();
                         if (Кнопка.Name == "Далее")
                         {
                             Далее_Click(Кнопка, new EventArgs());
                         }
                         if (Кнопка.Name == "Назад")
                         {
                             Назад_Click(Кнопка, new EventArgs());
                         }
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


        public void _Далее()
        {
            var ВыбраннаяСтрока = СписокВыбора.FocusedItem;
            if (ВыбраннаяСтрока == null) return;
            Гуид = ВыбраннаяСтрока.SubItems[2].Text;
            this.DialogResult = DialogResult.OK;
            this.Close();

        }

        public virtual void _Назад()
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();

        }


        private void Назад_Click(object sender, EventArgs e)
         {
             _Назад();
         }

        private void Далее_Click(object sender, EventArgs e)
         {
             _Далее();
         }


        private void СписокВыбора_ItemActivate(object sender, EventArgs e)
        {
            _Далее();
        }

        private void СписокВыбора_SelectedIndexChanged(object sender, EventArgs e)
        {
            var ВыбраннаяСтрока = СписокВыбора.FocusedItem;
            if (ВыбраннаяСтрока == null) return;
            ДопИнфо.Text = ВыбраннаяСтрока.SubItems[1].Text;
            //СписокВыбора.Update();             
        }

    }
}