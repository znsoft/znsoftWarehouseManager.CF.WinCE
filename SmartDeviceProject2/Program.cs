using System;
using System.Linq;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Threading;


namespace СкладскойУчет
{
   
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        ///
        [MTAThread]
        static void Main()
        {

            

            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);

            Настройки ПроверкаОбновления = new Настройки();
            if (ПроверкаОбновления.ПроверитьОбновление())
            {
                Application.Exit();
                return;
            }

            
            
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