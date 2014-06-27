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

        Пакеты Обмен; 
        public int КолонкаРучногоВыбора = 0;
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

        private void Окно_сканирования_ТС_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == System.Windows.Forms.Keys.NumPad0))
            {
                _Назад();
            }

        }

        private void Окно_сканирования_ТС_Load(object sender, EventArgs e)
        {
            var Авторизован = (NetworkCredential)СоединениеВебСервис.ПолучитьСервис().Сервис.Credentials;
            Пользователь.Text = Авторизован.UserName;

            foreach (var Строка in Последовательность.ОтветСервера) if (Строка[0].Contains("ТекстИнструкции"))  Инструкция.Text = Строка[1];
        }
    }
}