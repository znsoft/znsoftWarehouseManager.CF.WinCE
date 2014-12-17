using System;
using System.Windows.Forms;

namespace СкладскойУчет
{
    public partial class ОкноПереходаНаСекцию : Form
    {
        public string Филиал;
        public string ФилиалГуид;
        public string Ряд;
        public string Секция;

        public ОкноПереходаНаСекцию(string _Филиал, string _ФилиалГуид, string _Ряд, string _Секция)
        {
            Филиал = _Филиал;
            ФилиалГуид = _ФилиалГуид;
            Ряд = _Ряд;
            Секция = _Секция;
            InitializeComponent();         
        }

        public virtual void ОкноПереходаНаСекцию_Load(object sender, EventArgs e)
        {
            НадписьСекция.Text = Секция;
        }

        public virtual void _Да()
        {
            Form Окно = new ОкноВыбораЗаданийНаПодбор("ПодборВыборАдреса", Филиал, ФилиалГуид, Ряд, Секция);
            this.Close();
            Окно.ShowDialog();
            return;
        }

        public virtual void _Нет()
        {
            Form Окно = new ОкноВыбораЗаданийНаПодбор("ПодборВыборСекции", Филиал, ФилиалГуид, Ряд, "");
            this.Close();
            Окно.ShowDialog();
            return;

        }

        private void Нет_Click(object sender, EventArgs e)
        {
            _Нет();
        }

        private void Да_Click(object sender, EventArgs e)
        {
            _Да();
        }

        public virtual void ОкноПереходаНаСекцию_KeyDown(object sender, KeyEventArgs e)
        {
             foreach (var ЭлементФормы in this.Controls)
                 if (ЭлементФормы is Button)
                 {
                     Button Кнопка = (Button)ЭлементФормы;
                     if ((char)Кнопка.Text[1] == (char)e.KeyValue)
                     {
                         Кнопка.Focus();
                         if (Кнопка.Name == "Да")
                         {
                             Да_Click(Кнопка, new EventArgs());
                         }
                         if (Кнопка.Name == "Нет")
                         {
                             Нет_Click(Кнопка, new EventArgs());
                         }
                         return;
                     }
                 }


             if (РаботаСоСканером.НажатаПраваяПодэкраннаяКлавиша(e) || (e.KeyCode == System.Windows.Forms.Keys.Enter))
             {
                 _Да();
             }
             if (РаботаСоСканером.НажатаЛеваяПодэкраннаяКлавиша(e) || (e.KeyCode == System.Windows.Forms.Keys.Escape))
             {
                 _Нет();
             }

         }

    }
}