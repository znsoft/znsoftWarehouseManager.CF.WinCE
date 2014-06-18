using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Text.RegularExpressions;

namespace СкладскойУчет
{
    public partial class ОсновноеМеню : Form
    {
        public ОсновноеМеню()
        {
            InitializeComponent();
            this.KeyPreview = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //var Сервис = СоединениеВебСервис.ПолучитьСервис();
        }

        private void ОсновноеМеню_Load(object sender, EventArgs e)
        {
            var Авторизован = (NetworkCredential)СоединениеВебСервис.ПолучитьСервис().Сервис.Credentials;
            Пользователь.Text = Авторизован.UserName;
        }

        private void Выход_Click(object sender, EventArgs e)
        {
            Выход.Enabled = false;
            Выход.Text = "Отключение...";
            this.Close();
        }

        private void ОсновноеМеню_Closing(object sender, CancelEventArgs e)
        {
        }

        private void ОсновноеМеню_Closed(object sender, EventArgs e)
        {

            new Пакеты("ТСД").ПослатьСтроку("Выход", "Выход", 123);
        }

        private void ОсновноеМеню_KeyDown(object sender, KeyEventArgs e)
        {

            var button = (from Control c 
                             in this.Controls
                          where c is Button &&
                          Debug_Test(e, c)
                              select c).First();
            
            
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

        private static bool Debug_Test(KeyEventArgs e, Control c)
        {
            return c.Text[0] == (char)e.KeyValue;
        }
    }
}