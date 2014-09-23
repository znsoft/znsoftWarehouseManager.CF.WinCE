using System;
using System.Linq;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Threading;
using СкладскойУчет.Сеть;
using System.Reflection;
using System.Diagnostics;



namespace СкладскойУчет
{

    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        public static DialogResult РезультатАвторизации;
        [MTAThread]
        static void Main(string[] args)
        {
            СоединениеВебСервис.НомерВерсии = "c#1.4.1";

            Инфо.АргументЗапуска = null;
            if (args != null && args.Count() > 0) Инфо.АргументЗапуска = args[0];
            if (Обновление.ПроверитьОбновление())
            {
                Application.Exit();
                return;
            }

            Обновление.ПотокКопированияФайла(Инфо.ИмяЭтогоФайла, Инфо.АргументЗапуска);

            using (new РаботаСоСканером())
            {
                НачатьРаботуСФормами();
            }
        }

        private static void НачатьРаботуСФормами()
        {
            var ФормаЛогинПароль = new ФормаАвторизации();
            РезультатАвторизации = ФормаЛогинПароль.ShowDialog();
            if (РезультатАвторизации == DialogResult.OK)
            {
                AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);
                Application.Run(new ОсновноеМеню());
            }
        }

        static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            string СтрокаОшибки = Инфо.СчитанныйШтрихКод + "\n\r " + Инфо.Операция + "\n\r " + Инфо.Окно + "\n\r " + e.ExceptionObject.ToString();
            MessageBox.Show(СтрокаОшибки);
            Application.Run(new ОсновноеМеню());
        }
    }
}