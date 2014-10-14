using System;
using System.Windows.Forms;

namespace СкладскойУчет
{
    public partial class Ошибка : Form
    {
        DateTime ВремяПриОткрытии;

        public Ошибка(string ОписаниеОшибки)
        {
            InitializeComponent();
            this.ТекстОшибки.Text = ОписаниеОшибки;
            РаботаСоСканером.Звук.Ошибка();
            ВремяПриОткрытии = DateTime.Now;
        }

        private void Ошибка_KeyDown(object sender, KeyEventArgs e)
        {
            // Если прошло меньше секунды, форму не закрываем
            if ((DateTime.Now - ВремяПриОткрытии).Seconds < 1) return;
            this.Close();
        }

        private void Выход_Click(object sender, EventArgs e)
        {
            // Если прошло меньше секунды, форму не закрываем
            if ((DateTime.Now - ВремяПриОткрытии).Seconds < 1) return;
            this.Close();
        }
    }
}