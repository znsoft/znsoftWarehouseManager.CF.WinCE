using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace СкладскойУчет
{
    class Инфо
    {
        public static string СчитанныйШтрихКод;
        public static string Операция;
        public static string ИмяЭтогоФайла;
        public static string АргументЗапуска;

        public static void ПолучениеИнформации(string СтрокаСкан, TextBox СписокИнформации, TabControl Табулятор)
        {

            Табулятор.SelectedIndex = 1;
            СписокИнформации.Text = "Получение информации...";
            Табулятор.Update();

            var Обмен = new Пакеты("Информация");
            var ОтветСервера = Обмен.ПослатьСтроку(СтрокаСкан);

            if (ОтветСервера == null || ОтветСервера.Count() == 0)
            {
                СписокИнформации.Text = "Информация по коду не найдена";
                return;
            }

            // проверим тип полученной информации

            if (ОтветСервера[0][0] == "СписокТовара")
            {
                List<string[]> tmpList;

                tmpList = new List<string[]>();

                foreach (var str in ОтветСервера)
                {
                    if (str[0] == "СписокТовара")
                    {
                        continue;
                    }

                    tmpList.Add(new string[] { str[0], str[1], str[2] }); // код, наименование, гуид
                }

                var ТоварГуид = ВыборТовараИзМножества.ВыбратьТоварИзМножества(tmpList.AsEnumerable());

                if (ТоварГуид == null) return;

                // получим информацию по гуиду товара
                ОтветСервера = Обмен.ПослатьСтроку("Информация_ПолучитьДанныеТовараПоГуиду", ТоварГуид);

                if (ОтветСервера == null || ОтветСервера.Count() == 0)
                {
                    СписокИнформации.Text = "Информация по коду не найдена";
                    return;
                }
            }

            string Информация = "";
            foreach (var СтрокаОтвета in ОтветСервера)
            {
                Информация = Информация + СтрокаОтвета[1] + Environment.NewLine; 
            }
            СписокИнформации.Text = Информация;
        }

        public static void Ошибка(string ТекстОшибки) {
            (new Ошибка(ТекстОшибки)).ShowDialog();     
        }


     //string parms = @"QUERY \\machine\HKEY_USERS";
     //   string output = "";
     //   string error = string.Empty;

     //   ProcessStartInfo psi = new ProcessStartInfo("reg.exe", parms);

     //   psi.RedirectStandardOutput = true;
     //   psi.RedirectStandardError = true;
     //   psi.WindowStyle = System.Diagnostics.ProcessWindowStyle.Normal;
     //   psi.UseShellExecute = false;
     //   System.Diagnostics.Process reg;
     //   reg = System.Diagnostics.Process.Start(psi);
     //   using (System.IO.StreamReader myOutput = reg.StandardOutput)
     //   {
     //       output = myOutput.ReadToEnd();
     //   }
     //   using(System.IO.StreamReader myError = reg.StandardError)
     //   {
     //       error = myError.ReadToEnd();

     //   }


    }
}
