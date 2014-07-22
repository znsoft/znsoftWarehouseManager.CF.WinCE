using System;
using System.Linq;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Net;
using System.Text;

namespace СкладскойУчет
{
    public static class Утилиты
    {
        public static T Find<T>(this Control ctrl, Predicate<T> pred) where T : Control
        {
            return FindControl(ctrl, pred).FirstOrDefault();
        }

        private static IEnumerable<T> FindControl<T>(Control ctrl, Predicate<T> pred) where T : Control
        {
            foreach (var c in ctrl.Controls)
                if (c is T && pred(c as T))
                    yield return c as T;
        }

    }
    public class ЗаполнениеЭлементовФормы
    {
        private static void ДобавитьКолонку(ListView СписокВыбора, string Колонка, int Ширина, string[] Строка)
        {

            var columnHeader = new ColumnHeader();
            columnHeader.Text = Ширина == 0 ? "" : Колонка;
            columnHeader.Width = Ширина;
            if (Строка.Count() > 3)
                switch (Строка[3]) {
                    case "Центр":
                        columnHeader.TextAlign = HorizontalAlignment.Center;
                        break;
                    case "Право":
                        columnHeader.TextAlign = HorizontalAlignment.Right;
                        break;
                    case "Лево":
                        columnHeader.TextAlign = HorizontalAlignment.Left;
                        break;
                }
            СписокВыбора.Columns.Add(columnHeader);
        }



        public static void ЗаполнитьФорму(ЭлементыФормыЗаполнения ЭлементыФормы, ref string[][] ОтветСервера, ref int КолонкаВыбора)
        {
            var Авторизован = (NetworkCredential)СоединениеВебСервис.ПолучитьСервис().Сервис.Credentials;
            ListView СписокВыбора = ЭлементыФормы.СписокВыбора;
            if ( СписокВыбора!= null) СписокВыбора.Clear();
            Label Инструкция = ЭлементыФормы.Инструкция;// Форма.Find<Label>(b => b.Name == "Инструкция");
            Label ТекстДЯ = ЭлементыФормы.ТекстДЯ;// Форма.Find<Label>(b => b.Name == "ТекстДЯ");
            try
            {
                ЭлементыФормы.Пользователь.Text = Авторизован.UserName;
            }
            catch (Exception) { }
            bool ЗаполнениеТаблицы = false;
            bool ПерваяСтрока = true;
            foreach (var Строка in ОтветСервера)
            {
                if (ЗаполнениеТаблицы)
                {
                    if (Строка[0].Contains("КонецТаблицы")) { ЗаполнениеТаблицы = false; continue; }
                    ПерваяСтрока = ДобавитьСтрокуСписка(СписокВыбора, ПерваяСтрока, Строка);
                    continue;
                }
                switch (Строка[0]) {
                    case "ДобавитьКолонкуСписка":
                        СписокВыбора.Visible = true;
                        ДобавитьКолонку(СписокВыбора, Строка[1], int.Parse(Строка[2]), Строка);
                        break;
                    case "ЗаполнитьТаблицу":
                        ЗаполнениеТаблицы = true;
                        break;
                    case "КолонкаВыбора":
                        КолонкаВыбора = int.Parse(Строка[1]);
                        break;
                    case "ТекстИнструкции":
                        Инструкция.Text = Строка[1];
                        break;
                    case "ТекстДЯ":
                        ТекстДЯ.Text = Строка[1];
                        break;
                }

            }
        }

        private static bool ДобавитьСтрокуСписка(ListView СписокВыбора, bool ПерваяСтрока, string[] Строка)
        {
            ListViewItem НоваяСтрока = new ListViewItem();
            НоваяСтрока.Text = Строка[0];

            for (int i = 1; i < Строка.Count(); i++)
            {
                НоваяСтрока.SubItems.Add(Строка[i]);
            }

            СписокВыбора.Items.Add(НоваяСтрока);
            if (ПерваяСтрока)
            {
                ПерваяСтрока = false;
                НоваяСтрока.Selected = true;
            }
            return ПерваяСтрока;
        }
    }
}











