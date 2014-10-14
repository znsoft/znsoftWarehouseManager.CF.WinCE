using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net;

namespace СкладскойУчет
{
    public partial class ОкноНабораАдреса : Form
    {
        Пакеты Обмен;
        public int НомерКонокиГУИД = 0;
        ПоследовательностьОкон Последовательность;
        public bool ВернутьСкан;

        public ОкноНабораАдреса(ПоследовательностьОкон ПоследовательностьОкон)
        {
            InitializeComponent();
            Последовательность = ПоследовательностьОкон;
            Обмен = new Пакеты(ПоследовательностьОкон.Операция + " ВыборЗадания"); //Сформировали пакет с операцией состоящей например "Подбор ВыборЗадания"
            ВернутьСкан = false;
            Далее.Enabled = false;
            ВводАдреса.Focus();
        }

        private void ОкноНабораАдреса_Load(object sender, EventArgs e)
        {
            ЭлементыФормыДляЗаполнения ЭлементыФормы = new ЭлементыФормыДляЗаполнения();
            ЭлементыФормы.Инструкция = this.Инструкция;
            ЭлементыФормы.СписокВыбора = null;
            ЭлементыФормы.ТекстДЯ = this.Пользователь;
            ЭлементыФормы.Пользователь = this.Пользователь;
            ЗаполнениеЭлементовФормы.ЗаполнитьФорму(ЭлементыФормы, ref Последовательность.ОтветСервера, ref НомерКонокиГУИД);
        }

        private void ОкноНабораАдреса_KeyDown(object sender, KeyEventArgs e)
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
            string АдресВведен = "adr" + ВводАдреса.Text;
            if (АдресВведен.Length < 10) return;
            СканАдреса(АдресВведен);
        }

        public void _Назад()
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();//Нажали назад, необходимо попасть на предыдущее окно, думаю можно и самому решить этот вопрос без обращения к серверу
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
            if (!ВернутьСкан)
            {
                Последовательность.ОтветСервера = Обмен.ПослатьСтроку(СтрокаСкан, Последовательность.ТекущееОкно, "СканированВыбор");
                if (Последовательность.ОтветСервера == null) return; // в случае ошибки остаться в этом же окне
            }
            else 
            {
                Последовательность.ОтветСервера = Обмен.ПодготовитьСтроку("ТекстДЯ", СтрокаСкан);
            }
            this.DialogResult = DialogResult.Retry;
            this.Close();
            return;
        }

        private void ВводАдреса_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (string.IsNullOrEmpty(ВводАдреса.Text))
            { ПрефиксАдреса.Visible = true; ВводАдреса.MaxLength = 7; }
            e.Handled = (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar));
        }

        private void ВводАдреса_TextChanged(object sender, EventArgs e)
        {
            
            ПрефиксАдреса.Visible = true;
            ВводАдреса.Text = ВводАдреса.Text.Replace("adr", "");
            ВводАдреса.MaxLength = 7;
            if (string.IsNullOrEmpty(ВводАдреса.Text)) {
                 ПрефиксАдреса.Visible = false; ВводАдреса.MaxLength = 10; 
            }
            Далее.Enabled = ВводАдреса.Text.Length == 7;
        }
    }
}