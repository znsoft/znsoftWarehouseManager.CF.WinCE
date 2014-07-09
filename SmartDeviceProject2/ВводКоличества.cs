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
        public int Количество_ = 1;
        public ВводКоличества(string Инфо)
        {
            InitializeComponent();
            this.Информация.Text = Инфо;
            Количество.TextAlign = HorizontalAlignment.Right;
            
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

        private void Количество_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == System.Windows.Forms.Keys.Enter) { 
            Принять_Click(sender, new EventArgs());
            } 
        }

        private void ВводКоличества_Load(object sender, EventArgs e)
        {
            Количество.Text = String.Format("{0}", Количество_);
            Количество.SelectAll();
        }
    }
}