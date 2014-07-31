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

        static string СкладскойУчетОбновление = "СкладскойУчетОбновление.exe";
        public static bool ПроверитьОбновление(string[] Аргументы)
        {
            Инфо.ИмяЭтогоФайла = Assembly.GetCallingAssembly().ManifestModule.FullyQualifiedName;
            string ИмяЭтогоФайла = Инфо.ИмяЭтогоФайла;

            if (Аргументы.Count() != 0)
                УдалитьСкопировать(ИмяЭтогоФайла, Аргументы[0]);
            try
            {
                Пакеты Обмен = new Пакеты("");
                Byte[] Прошивка = Обмен.UpdateFirmware();
                if (Прошивка == null || Прошивка.Count() == 0) return false;
                string НовыйИсполняемыйФайл = Настройки.ПолучитьПутьКЛокальномуФайлу(СкладскойУчетОбновление);
                СохранитьВФайл(ref НовыйИсполняемыйФайл, Прошивка);
                var pr = new Process();
                pr.StartInfo.FileName = НовыйИсполняемыйФайл;
                pr.StartInfo.Arguments = (Аргументы.Count() != 0) ? Аргументы[0] : ИмяЭтогоФайла;
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
                    File.Delete(АргументыЭтогоПроцесса);
                    File.Copy(ИмяЭтогоФайла, АргументыЭтогоПроцесса, true);
                    break;
                }
                catch (Exception) { Thread.Sleep(500); }
        }

        public static void СохранитьВФайл(ref string Файл, Byte[] Данные)
        {
            for(int НомерОбнов = 0;НомерОбнов < 10;НомерОбнов ++)
            try
            {
                FileStream file = System.IO.File.Create(Файл);
                file.Write(Данные, 0, Данные.Count());
                file.Close();
                break;
            }
            catch (Exception) {
                Файл.Replace(".exe", String.Format("{0}",НомерОбнов)+".exe");
            }
        }
    }
}
