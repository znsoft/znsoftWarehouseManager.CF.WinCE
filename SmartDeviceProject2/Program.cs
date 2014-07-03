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
            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);
            using (new РаботаСоСканером())
            {
                var ФормаЛогинПароль = new ФормаАвторизации();
                var РезультатАвторизации = ФормаЛогинПароль.ShowDialog();
                if (РезультатАвторизации == DialogResult.OK)
                    Application.Run(new ОсновноеМеню());
            }


        }

        static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            MessageBox.Show(e.ToString());
        }
    }
}