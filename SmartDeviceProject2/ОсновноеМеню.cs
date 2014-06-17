using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SmartDeviceProject2
{
    public partial class ОсновноеМеню : Form
    {
        public ОсновноеМеню()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //var Сервис = СоединениеВебСервис.ПолучитьСервис();
        }

        private void ОсновноеМеню_Load(object sender, EventArgs e)
        {

        }

        private void Выход_Click(object sender, EventArgs e)
        {
            Выход.Enabled = false;
            this.Close();
        }

        private void ОсновноеМеню_Closing(object sender, CancelEventArgs e)
        {
           

        }

        private void ОсновноеМеню_Closed(object sender, EventArgs e)
        {

            new Пакеты("Выход").ПослатьСтроку("123", "123", 123);
        }
    }
}