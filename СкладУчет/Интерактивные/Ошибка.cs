using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace СкладскойУчет
{
    public partial class Ошибка : Form
    {
        DateTime ВременнойПромежуток;

        public Ошибка(string ОписаниеОшибки)
        {
            InitializeComponent();
            this.ТекстОшибки.Text = ОписаниеОшибки;
            РаботаСоСканером.Звук.Ошибка();
            ВременнойПромежуток = DateTime.Now;
        }

        private int ВзятьВремя()
        {
            return (DateTime.Now - ВременнойПромежуток).Seconds;
        }

        private void Ошибка_KeyDown(object sender, KeyEventArgs e)
        {
            if (ВзятьВремя() < 1) return;
            РаботаСоСканером.Звук.МинимальнаяГромкость();
            this.Close();
        }

        private void Выход_Click(object sender, EventArgs e)
        {
            РаботаСоСканером.Звук.МинимальнаяГромкость();
            this.Close();
        }
    }
}