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

            this.Close();
            
            if ((e.KeyCode == System.Windows.Forms.Keys.Up))
            {
                // Up
            }
            if ((e.KeyCode == System.Windows.Forms.Keys.Down))
            {
                // Down
            }
            if ((e.KeyCode == System.Windows.Forms.Keys.Left))
            {
                // Left
            }
            if ((e.KeyCode == System.Windows.Forms.Keys.Right))
            {
                // Right
            }
            if ((e.KeyCode == System.Windows.Forms.Keys.Enter))
            {
                // Enter
            }

        }

        private void Выход_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}