using System;
using System.Linq;
using System.Reflection;
using System.Diagnostics;
using System.IO;
using System.Threading;

namespace СкладскойУчет
{
    class Обновление
    {

        static string СкладскойУчетОбновление = "update.exe";

        static public void СкопироватьФайлОбновления(string ИмяФайлаИсточника, string ИмяФайлаПриемника)
        {
            if (ИмяФайлаПриемника == null || ИмяФайлаПриемника.Length < 3) return;
            Thread staThread = new Thread(new ThreadStart(
                delegate
                {
                    //Thread.Sleep(2000);
                    for (int Попыток = 10; Попыток > 0; Попыток--)

                        try
                        {
                            Logs.WriteLog("copy to " + ИмяФайлаПриемника);
                            File.Copy(ИмяФайлаИсточника, Инфо.АргументЗапуска, true);
                            Logs.WriteLog("ok from " + ИмяФайлаИсточника);
                            break;
                        }
                        // Если копирование не удалось, ждем и пробуем снова
                        catch (Exception) {Thread.Sleep(1500);}
                }
            ));
            staThread.Start();
        }

        public static void УдалитьФайлОбновления() {
            try
            {
                string ПутьДоФайла = Настройки.ПолучитьПутьКЛокальномуФайлу(СкладскойУчетОбновление);
                File.Delete(ПутьДоФайла);
            }
            catch (Exception) { }
        
        }

        public static bool ПроверитьОбновление()
        {

            // Получаем параметры сеанса (сервер) и соответствующую веб ссылку
            Настройки ПараметрыСеанса = new Настройки();
            ПараметрыСеанса.Загрузить();
            string Url = ПараметрыСеанса.СформироватьСсылку();

            if (string.IsNullOrEmpty(Url)) return false;
            Пакеты Обмен = new Пакеты("");           
            Обмен.Соединение.Сервис.Url = Url;

            Инфо.ИмяЭтогоФайла = Assembly.GetCallingAssembly().ManifestModule.FullyQualifiedName;
            string ИмяЭтогоФайла = Инфо.ИмяЭтогоФайла;

            try
            {
                Logs.WriteLog("start update check " + СоединениеВебСервис.НомерВерсии);

                Byte[] Прошивка = Обмен.UpdateFirmware();
                if (Прошивка == null || Прошивка.Count() == 0) return false;
                Logs.WriteLog("is there ");

                string НовыйИсполняемыйФайл = Настройки.ПолучитьПутьКЛокальномуФайлу(СкладскойУчетОбновление);
                СохранитьВФайл(ref НовыйИсполняемыйФайл, Прошивка);
                if (!String.IsNullOrEmpty(Инфо.АргументЗапуска))
                {
                    Инфо.Ошибка("Обновленная версия не совпадает с версией в хранилище, обратитесь в ИТ отдел");
                    return false;
                }
                Logs.WriteLog("Start prog");

                var pr = new Process();
                pr.StartInfo.FileName = НовыйИсполняемыйФайл;
                pr.StartInfo.Arguments = "\"" + ИмяЭтогоФайла + "\"";
                pr.Start();
                return true;
            }
            catch (Exception) { }// System.Windows.Forms.MessageBox.Show(e.Message); }
            return false;
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

        // Вариант обновления через CMD скрипт
        static string СоздатьCMDСкрипт(string СтарыйФайл, string СкачанныйФайл)
        {
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

    }
}
