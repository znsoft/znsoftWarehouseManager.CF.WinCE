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
    public partial class Окно_сканирования_адреса : Form
    {
        private РаботаСоСканером Сканер;
        Пакеты Обмен;
        public int КолонкаРучногоВыбора = 0;
        ПоследовательностьОкон Последовательность;
        public bool ВернутьСкан;

        public Окно_сканирования_адреса(ПоследовательностьОкон ПоследовательностьОкон)
        {
            InitializeComponent();
            Последовательность = ПоследовательностьОкон;
            Обмен = new Пакеты(ПоследовательностьОкон.Операция + " ВыборЗадания"); //Сформировали пакет с операцией состоящей например "Подбор ВыборЗадания"
            ВернутьСкан = false;
        }

        public void _Назад()
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();//Нажали назад, необходимо попасть на предыдущее окно, думаю можно и самому решить этот вопрос без обращения к серверу
        }

        private void Назад_Click(object sender, EventArgs e)
        {
            _Назад();
        }

        private void Окно_сканирования_ТС_KeyDown(object sender, KeyEventArgs e)
        {
            if (РаботаСоСканером.НажатаКлавишаСкан(e))
            {
                e.Handled = true;
                СканированиеШК(e);
                return;
            }


            if ((e.KeyCode == System.Windows.Forms.Keys.D0)||РаботаСоСканером.НажатаЛеваяПодэкраннаяКлавиша(e))
            {
                _Назад();
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

        private void Окно_сканирования_ТС_Load(object sender, EventArgs e)
        {
            СписокВыбора.Focus();
             ЭлементыФормыЗаполнения ЭлементыФормы = new ЭлементыФормыЗаполнения();
             ЭлементыФормы.Инструкция = this.Инструкция;
             ЭлементыФормы.СписокВыбора = this.СписокВыбора;
             ЭлементыФормы.ТекстДЯ = this.Пользователь;
             ЭлементыФормы.Пользователь = this.Пользователь;
             ЗаполнениеЭлементовФормы.ЗаполнитьФорму(ЭлементыФормы, ref Последовательность.ОтветСервера, ref КолонкаРучногоВыбора);

        }
    }
}