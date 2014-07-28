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
    public partial class Окно_сканирования_ТС : Form
    {
        private РаботаСоСканером Сканер;

        Пакеты Обмен;
        public int НомерКонокиГУИД = 0;
        ПоследовательностьОкон Последовательность;

        public Окно_сканирования_ТС(ПоследовательностьОкон ПоследовательностьОкон)
        {
            InitializeComponent();
            Последовательность = ПоследовательностьОкон;
            Обмен = new Пакеты(ПоследовательностьОкон.Операция + " ВыборЗадания"); //Сформировали пакет с операцией состоящей например "Подбор ВыборЗадания"
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

        //private void ПолучениеИнформации(string СтрокаСкан)
        //{

        //    СписокИнформации.Text = "Получение информации...";
        //    var Обмен = new Пакеты("Информация");
        //    var ОтветСервера = Обмен.ПослатьСтроку(СтрокаСкан);

        //    if (ОтветСервера == null || ОтветСервера.Count() == 0)
        //    {
        //        СписокИнформации.Text = "Информация по коду не найдена";
        //        return;
        //    }
        //    string Информация = "";
        //    foreach (var СтрокаОтвета in ОтветСервера)
        //    {
        //        Информация = Информация + СтрокаОтвета[1] + "\r\n" + "\r\n";
        //    }
        //    СписокИнформации.Text = Информация;
        //}

        private void Окно_сканирования_ТС_KeyDown(object sender, KeyEventArgs e)
        {
            if (РаботаСоСканером.НажатаКлавишаСкан(e))
            {
                СканированиеШК(e);
                return;
            }


            if ((e.KeyCode == System.Windows.Forms.Keys.D0)||РаботаСоСканером.НажатаЛеваяПодэкраннаяКлавиша(e))
            {
                _Назад();
            }


            if ((e.KeyCode == System.Windows.Forms.Keys.D1)||(e.KeyCode == System.Windows.Forms.Keys.Left))
            {
                Таб.SelectedIndex = 0;
            }
            if ((e.KeyCode == System.Windows.Forms.Keys.D2)||(e.KeyCode == System.Windows.Forms.Keys.Right))
            {
                Таб.SelectedIndex = 1;
            }


        }

        private void СканированиеШК(KeyEventArgs e)
        {
            string СтрокаСкан = РаботаСоСканером.Scan();
            if (СтрокаСкан.Length != 0)
            {
                e.Handled = true;
                if (Таб.SelectedIndex == 0)
                {

                    СканАдреса(СтрокаСкан);
                    return;
                }

                Инфо.ПолучениеИнформации(СтрокаСкан, СписокИнформации, Таб);
            }
        }

        private void СканАдреса(string СтрокаСкан)
        {
            Последовательность.ОтветСервера = Обмен.ПослатьСтроку(СтрокаСкан, Последовательность.ТекущееОкно, "СканированВыбор");
            if (Последовательность.ОтветСервера == null) return; // в случае ошибки остаться в этом же окне
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
             ЗаполнениеЭлементовФормы.ЗаполнитьФорму(ЭлементыФормы, ref Последовательность.ОтветСервера, ref НомерКонокиГУИД);

        }
    }
}