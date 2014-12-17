using System;
using System.Windows.Forms;

namespace СкладскойУчет
{
    public partial class ОкноВыбораАдреса : Form
    {
        private Пакеты Обмен;
        private string[][] ОтветСервера;

        public ОкноВыбораАдреса()
        {
            Обмен = new Пакеты("ПеремещениеВыборАдреса");
            InitializeComponent();                
        }

        private void ОкноВыбораАдреса_Load(object sender, EventArgs e)
        {
            Далее.Enabled = false;
            ВводАдреса.Focus();
        }

        private void ОкноВыбораАдреса_KeyDown(object sender, KeyEventArgs e)
        {
            if (РаботаСоСканером.НажатаКлавишаСкан(e))
            {
                e.Handled = true;
                СканированиеШК(e);
                return;
            }

            if (РаботаСоСканером.НажатаЛеваяПодэкраннаяКлавиша(e))
            {
                _Назад();
            }
            if (РаботаСоСканером.НажатаПраваяПодэкраннаяКлавиша(e))
            {
                _Далее();
            }
        }


        public void _Назад()
        {
            this.Close();
        }

        public void _Далее()
        {
            string Адрес = "adr" + ВводАдреса.Text;
            if (Адрес.Length == 10)
            {
                СканАдреса(Адрес);
                return;
            }
            {
                Инфо.Ошибка("Адрес введен неверно!");
            }
        }


        private void СканированиеШК(KeyEventArgs e)
        {
            string СтрокаСкан = РаботаСоСканером.Scan();
            if (СтрокаСкан.Length != 0)
            {
                e.Handled = true;
                СканАдреса(СтрокаСкан);
            }
        }

        private void СканАдреса(string СтрокаСкан)
        {
            Cursor.Current = Cursors.WaitCursor;

            ОтветСервера = Обмен.ПослатьСтроку(СтрокаСкан);

            Cursor.Current = Cursors.Default;

            if (ОтветСервера == null) return;

            if (ОтветСервера[0][0] == "НетТоваров")
            {
                Инфо.Ошибка("На адресе " + ОтветСервера[0][1] + " нет товаров!");
                return;
            }

            Form Окно = new ОкноПеремещенияТоваров(ОтветСервера);
            this.Close();
            Окно.Show();         
        }

        private void ВводАдреса_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (string.IsNullOrEmpty(ВводАдреса.Text))
            { 
                ПрефиксАдреса.Visible = true; 
                ВводАдреса.MaxLength = 7; 
            }
            e.Handled = (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar));
        }

        private void ВводАдреса_TextChanged(object sender, EventArgs e)
        {          
            ПрефиксАдреса.Visible = true;
            ВводАдреса.Text = ВводАдреса.Text.Replace("adr", "");
            ВводАдреса.MaxLength = 7;
            if (string.IsNullOrEmpty(ВводАдреса.Text)) {
                ПрефиксАдреса.Visible = false; 
                ВводАдреса.MaxLength = 10; 
            }
            Далее.Enabled = ВводАдреса.Text.Length == 7;
        }

        private void Назад_Click(object sender, EventArgs e)
        {
            _Назад();
        }

        private void Далее_Click(object sender, EventArgs e)
        {
            _Далее();
        }

    }
}