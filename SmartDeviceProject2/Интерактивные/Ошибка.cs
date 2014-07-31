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
        public Ошибка(string ОписаниеОшибки)
        {
            InitializeComponent();
            this.ТекстОшибки.Text = ОписаниеОшибки;
            РаботаСоСканером.Звук.Ошибка();
        }

        private void Ошибка_KeyDown(object sender, KeyEventArgs e)
        {
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