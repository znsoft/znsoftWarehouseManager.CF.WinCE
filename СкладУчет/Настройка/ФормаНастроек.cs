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
    public partial class ФормаНастроек : Form
    {
        Настройки ПараметрыСеанса = new Настройки();
        
        public ФормаНастроек()
        {
            InitializeComponent();
        }

        private void Применить_Click(object sender, EventArgs e)
        {
             ПараметрыСеанса.Хранилище.Сервер = Часть1ВебСсылки.Text;
             //ПараметрыСеанса.Хранилище.Часть3ВебСсылки = Часть3ВебСсылки.Text;
             ПараметрыСеанса.Сохранить();
             this.DialogResult = DialogResult.OK;
             this.Close();
        }

        private void ФормаНастроек_Load(object sender, EventArgs e)
        {
            ПараметрыСеанса.ПолучитьПолнуюВебСсылку();
            Часть1ВебСсылки.Text = ПараметрыСеанса.Хранилище.Сервер;

        }

        private void Часть4ВебСсылки_TextChanged(object sender, EventArgs e)
        {

        }

    }
}