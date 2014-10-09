using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace СкладскойУчет.Интерактивные
{
    static class Logs
    {
        public static void WriteLog(string textlog){
            try
            {
                if (string.IsNullOrEmpty(textlog)) textlog = "null";
                string ПутьДоФайла = Настройки.ПолучитьПутьКЛокальномуФайлу("update.txt");
                StreamWriter sw = new StreamWriter(ПутьДоФайла, true, Encoding.GetEncoding(1251));
                sw.WriteLine(textlog);
                sw.Close();
            }
            catch (Exception) { }
        
        }

        public static void DeleteLog(){
            try
            {
        string ПутьДоФайла = Настройки.ПолучитьПутьКЛокальномуФайлу("update.txt");

            File.Delete(ПутьДоФайла);
            }
            catch (Exception) { }
        }
    }
}
