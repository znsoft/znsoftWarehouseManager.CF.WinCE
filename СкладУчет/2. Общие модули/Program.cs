using System;
using System.Linq;
using System.Windows.Forms;
using System.Reflection;
//using СкладскойУчет.Интерактивные;

namespace СкладскойУчет
{
    static class Program
    {
        public static DialogResult РезультатАвторизации;

        [MTAThread]
        static void Main(string[] args)
        {
            СоединениеВебСервис.НомерВерсии = "c#1.4.9";
            Инфо.ИмяЭтогоФайла = Assembly.GetCallingAssembly().ManifestModule.FullyQualifiedName;
            Инфо.АргументЗапуска = null;

            // Получаем аргумент запуска. Если его нет, пытаемся удалить старый файл обновления
            if (args != null && args.Count() > 0) { Инфо.АргументЗапуска = args[0]; } else { Обновление.УдалитьФайлОбновления(); }

            Logs.WriteLog("start:" + СоединениеВебСервис.НомерВерсии + " " + Инфо.АргументЗапуска);

            // Если подан аргумент запуска, вызываем процедуры обновления
            if (!string.IsNullOrEmpty(Инфо.АргументЗапуска)) Обновление.СкопироватьФайлОбновления(Инфо.ИмяЭтогоФайла, Инфо.АргументЗапуска);

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
                // Для обработки необрабатываемых исключений
                //AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);
                Application.Run(new ОсновноеМеню());
            }
        }

        // ???
        //static void currentdomain_unhandledexception(object sender, unhandledexceptioneventargs e)
        //{
        //    string строкаошибки = инфо.считанныйштрихкод + "\n\r " + инфо.операция + "\n\r " + инфо.окно + "\n\r " + e.exceptionobject.tostring();
        //    messagebox.show(строкаошибки);
        //    application.run(new основноеменю());
        //}
    }
}