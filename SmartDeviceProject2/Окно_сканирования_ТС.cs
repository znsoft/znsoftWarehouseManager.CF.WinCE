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
        public int КолонкаРучногоВыбора = 0;
        ПоследовательностьОкон Последовательность;

        public Окно_сканирования_ТС(ПоследовательностьОкон ПоследовательностьОкон)
        {
            InitializeComponent();
            Последовательность = ПоследовательностьОкон;
            Обмен = new Пакеты(ПоследовательностьОкон.Операция + " ВыборЗадания"); //Сформировали пакет с операцией состоящей например "Подбор ВыборЗадания"
            Сканер = new РаботаСоСканером();

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
                string СтрокаСкан = РаботаСоСканером.Scan();
                if (СтрокаСкан.Length != 0)
                {
                    e.Handled = true;
                    Последовательность.ОтветСервера = Обмен.ПослатьСтроку(СтрокаСкан, Последовательность.ТекущееОкно, "СканированВыбор");
                    if (Последовательность.ОтветСервера == null) return; // в случае ошибки остаться в этом же окне
                    this.DialogResult = DialogResult.Retry;
                    this.Close();

                }
                return;


            }

            if ((e.KeyCode == System.Windows.Forms.Keys.D0))
            {
                _Назад();
            }

        }
        private void Окно_сканирования_ТС_Load(object sender, EventArgs e)
        {
            СписокВыбора.Focus();
            ЗаполнениеЭлементовФормы.ЗаполнитьФорму(this, ref Последовательность.ОтветСервера,out КолонкаРучногоВыбора);

        }
    }
}