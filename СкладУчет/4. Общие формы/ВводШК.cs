using System;
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

        private void ВводШК_ПриОткрытии(object sender, EventArgs e)
        {
            РучнойШК.Focus();
        }

        private void РучнойШК_KeyDown(object sender, KeyEventArgs e)
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

    }
}