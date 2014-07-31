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
    public partial class ВводШК : Form
    {
        public string BarCode = string.Empty;
        public ВводШК()
        {
            InitializeComponent();
            РучнойШК.TextAlign = HorizontalAlignment.Right;
            this.DialogResult = DialogResult.Cancel;
        }

        private void Принять_Click(object sender, EventArgs e)
        {

        }

        private void Количество_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == System.Windows.Forms.Keys.Enter){
                BarCode = РучнойШК.Text;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            if (e.KeyCode == System.Windows.Forms.Keys.Escape)
            {
                BarCode = string.Empty;
                this.Close();
            }
        }

        private void ВводКоличества_Load(object sender, EventArgs e)
        {
            РучнойШК.Focus();
        }
    }
}