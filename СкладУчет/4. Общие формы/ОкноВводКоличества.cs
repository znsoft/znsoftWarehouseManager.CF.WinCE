using System;
using System.Windows.Forms;

namespace СкладскойУчет
{
    public partial class ОкноВводКоличества : Form
    {
        public int Количество_;

        public ОкноВводКоличества(string ТекстИнструкции, int КоличествоСобрано, int КоличествоТребуется, bool Вычерк)
        {
            InitializeComponent();
            this.DialogResult = DialogResult.Cancel;
            
            Количество.TextAlign = HorizontalAlignment.Right;

            Инструкция.Text = ТекстИнструкции;

            if (Вычерк)
            {
                Количество.Enabled = false;
                Количество.Text = (КоличествоТребуется - КоличествоСобрано).ToString();
            }
            else
            {
                if (КоличествоСобрано == 0)
                {
                    Количество.Text = "1";
                }
                else
                {
                    Количество.Text = КоличествоСобрано.ToString();
                }
                Количество.SelectAll();
            }   
                  
        }

        private void Количество_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar));
        }

        private void Количество_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == System.Windows.Forms.Keys.Enter)
            {
                Принять_Click(sender, new EventArgs());
            }
        }

        private void Принять_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Количество.Text))
            {
                Количество_ = 0;
            }
            else
            {
                Количество_ = int.Parse(Количество.Text);
            }
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

    }
}