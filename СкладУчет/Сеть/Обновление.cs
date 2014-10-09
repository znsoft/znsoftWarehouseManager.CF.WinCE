using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.Diagnostics;
using System.IO;
using System.Threading;

namespace СкладскойУчет.Сеть
{
    class Обновление
    {

        static string СкладскойУчетОбновление = "update.exe";

        static public void ПотокКопированияФайла(string ИмяФайлаИсточника, string ИмяФайлаПриемника)
        {
            if (ИмяФайлаПриемника == null || ИмяФайлаПриемника.Length < 3) return;
            Thread staThread = new Thread(new ThreadStart(
                delegate
                {
                    УдалитьСкопировать(ИмяФайлаИсточника, ИмяФайлаПриемника);
                }
            ));
            staThread.Start();
        }

        static string СоздатьCMDСкрипт(string СтарыйФайл, string СкачанныйФайл) {
            string ПутьДоСкрипта = Настройки.ПолучитьПутьКЛокальномуФайлу("runme.cmd");
            var FI = new FileInfo(СтарыйФайл);
            var FA = new FileInfo(СкачанныйФайл);

            StreamWriter sw = new StreamWriter(ПутьДоСкрипта);
                sw.WriteLine("del /Q %1");
                sw.WriteLine("move " + FA.Name + " %1");
                sw.WriteLine("%1 Update");
                sw.WriteLine("rem del /Q %0");
                sw.WriteLine("pause");
                sw.Close();
            return ПутьДоСкрипта;
        }


        public static bool ПроверитьОбновление()
        {
            Инфо.ИмяЭтогоФайла = Assembly.GetCallingAssembly().ManifestModule.FullyQualifiedName;
            string ИмяЭтогоФайла = Инфо.ИмяЭтогоФайла;
            Настройки ПараметрыСеанса = new Настройки();
            string Url = ПараметрыСеанса.ПолучитьПолнуюВебСсылку();
            Пакеты Обмен = new Пакеты("");
            if (string.IsNullOrEmpty(Url)) return false;
            Обмен.Соединение.Сервис.Url = Url;
            try
            {
                Byte[] Прошивка = Обмен.UpdateFirmware();
                if (Прошивка == null || Прошивка.Count() == 0) return false;
                string НовыйИсполняемыйФайл = Настройки.ПолучитьПутьКЛокальномуФайлу(СкладскойУчетОбновление);
                СохранитьВФайл(ref НовыйИсполняемыйФайл, Прошивка);
                if (!String.IsNullOrEmpty(Инфо.АргументЗапуска))
                {
                    Инфо.Ошибка("Обновленная версия не совпадает с версией в хранилище, обратитесь в ИТ отдел");
                    return false;
                }
                var скрипт = СоздатьCMDСкрипт(ИмяЭтогоФайла, НовыйИсполняемыйФайл);

                var pr = new Process();
                pr.StartInfo.FileName = НовыйИсполняемыйФайл;
                pr.StartInfo.Arguments = (Инфо.АргументЗапуска != null) ? Инфо.АргументЗапуска : ИмяЭтогоФайла;
                //pr.StartInfo.FileName = скрипт;//НовыйИсполняемыйФайл;
                //pr.StartInfo.Arguments = "\""+ИмяЭтогоФайла+"\"";
                pr.Start();
                return true;
            }
            catch (Exception) { }// System.Windows.Forms.MessageBox.Show(e.Message); }
            return false;
        }

        private static void УдалитьСкопировать(string ИмяЭтогоФайла, string АргументыЭтогоПроцесса)
        {
            for (int Попыток = 10; Попыток > 0; Попыток--)
                try
                {
                    //File.Delete(АргументыЭтогоПроцесса);
                    File.Copy(ИмяЭтогоФайла, АргументыЭтогоПроцесса, true);
                    break;
                }
                catch (Exception) { Thread.Sleep(1500); }
        }

        public static void СохранитьВФайл(ref string Файл, Byte[] Данные)
        {
            for (int НомерОбнов = 0; НомерОбнов < 10; НомерОбнов++)
                try
                {
                    FileStream file = System.IO.File.Create(Файл);
                    file.Write(Данные, 0, Данные.Count());
                    file.Close();
                    break;
                }
                catch (Exception)
                {
                    Файл.Replace(".exe", String.Format("{0}", НомерОбнов) + ".exe");
                }
        }
    }
}
