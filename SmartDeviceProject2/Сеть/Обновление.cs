using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.Diagnostics;
using System.IO;

namespace СкладскойУчет.Сеть
{
    class Обновление
    {

        static string СкладскойУчетОбновление = "СкладскойУчетОбновление.exe";
        static string СкладскойУчет = "СкладскойУчет.exe";

        public static bool ПроверитьОбновление()
        {
            Инфо.ИмяЭтогоФайла = Assembly.GetCallingAssembly().ManifestModule.FullyQualifiedName;
            string ИмяЭтогоФайла = Инфо.ИмяЭтогоФайла;
            string АргументыЭтогоПроцесса = Process.GetCurrentProcess().StartInfo.Arguments;
            if (ИмяЭтогоФайла.Contains(СкладскойУчетОбновление))
            {
                АргументыЭтогоПроцесса = Настройки.ПолучитьПутьКЛокальномуФайлу(СкладскойУчет);
                try
                {
                    File.Delete(АргументыЭтогоПроцесса);
                    File.Copy(ИмяЭтогоФайла, АргументыЭтогоПроцесса);
                }
                catch (Exception) { }
            }
            try
            {
                Пакеты Обмен = new Пакеты("");
                Byte[] Прошивка = Обмен.UpdateFirmware();
                if (Прошивка == null || Прошивка.Count() == 0) return false;
                string НовыйИсполняемыйФайл = Настройки.ПолучитьПутьКЛокальномуФайлу(СкладскойУчетОбновление);
                СохранитьВФайл(НовыйИсполняемыйФайл, Прошивка);
                var pr = new Process();
                pr.StartInfo.FileName = НовыйИсполняемыйФайл;
                pr.StartInfo.Arguments = ИмяЭтогоФайла;
                pr.Start();
                return true;
            }
            catch (Exception) { }// System.Windows.Forms.MessageBox.Show(e.Message); }
            return false;
        }

        public static void СохранитьВФайл(string Файл, Byte[] Данные)
        {
            FileStream file = System.IO.File.Create(Файл);
            file.Write(Данные, 0, Данные.Count());
            file.Close();
        }
    }
}
