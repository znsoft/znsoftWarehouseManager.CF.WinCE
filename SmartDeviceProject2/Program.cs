using System;
using System.Linq;
using System.Collections.Generic;
using System.Windows.Forms;

namespace СкладскойУчет
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [MTAThread]
        static void Main()
        {
            var ФормаЛогинПароль = new ФормаАвторизации();
            var РезультатАвторизации = ФормаЛогинПароль.ShowDialog();
            if (РезультатАвторизации == DialogResult.OK)
            Application.Run(new ОсновноеМеню());

        }
    }
}