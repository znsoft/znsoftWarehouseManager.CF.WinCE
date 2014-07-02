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
    public partial class ВводКоличества : Form
    {
        public int Количество_ = 0;
        public ВводКоличества(string Инфо)
        {
            InitializeComponent();
            this.Информация.Text = Инфо;
            Количество.TextAlign = HorizontalAlignment.Right;
            Количество.Text = "1";
            this.DialogResult = DialogResult.Cancel;
        }

        private void Количество_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar));
        }

        private void Принять_Click(object sender, EventArgs e)
        {
            Количество_ = int.Parse(Количество.Text);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void Вычерк_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Abort;
            this.Close();
        }
    }
}