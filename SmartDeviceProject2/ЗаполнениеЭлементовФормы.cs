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
        private static void ДобавитьКолонку(ListView СписокВыбора, string Колонка, int Ширина)
        {

            var columnHeader = new ColumnHeader();
            columnHeader.Text = Ширина == 0 ? "" : Колонка;
            columnHeader.Width = Ширина;
            СписокВыбора.Columns.Add(columnHeader);
        }



        public static void ЗаполнитьФорму(ЭлементыФормыЗаполнения ЭлементыФормы, ref string[][] ОтветСервера, out int КолонкаВыбора)
        {
            КолонкаВыбора = 0;
            var Авторизован = (NetworkCredential)СоединениеВебСервис.ПолучитьСервис().Сервис.Credentials;
            ListView СписокВыбора = ЭлементыФормы.СписокВыбора;
            Label Инструкция = ЭлементыФормы.Инструкция;// Форма.Find<Label>(b => b.Name == "Инструкция");
            Label ТекстДЯ = ЭлементыФормы.ТекстДЯ;// Форма.Find<Label>(b => b.Name == "ТекстДЯ");
            try
            {
                //Форма.Find<Label>(b => b.Name == "Пользователь").Text = Авторизован.UserName;
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
                    ListViewItem НоваяСтрока = new ListViewItem();
                    НоваяСтрока.Text = Строка[0];

                    for (int i = 1; i < Строка.Count(); i++)
                    {
                        НоваяСтрока.SubItems.Add(Строка[i]);
                    }

                    СписокВыбора.Items.Add(НоваяСтрока);
                    if (ПерваяСтрока) {
                        ПерваяСтрока = false;
                        НоваяСтрока.Selected = true;
                    }
                    continue;
                }

                if (Строка[0] == "ДобавитьКолонкуСписка") { 
                    СписокВыбора.Visible = true;
                    ДобавитьКолонку(СписокВыбора, Строка[1], int.Parse(Строка[2]));
                }
                if (Строка[0] == "ЗаполнитьТаблицу") ЗаполнениеТаблицы = true;
                if (Строка[0] == "КолонкаВыбора") КолонкаВыбора = int.Parse(Строка[1]);
                if (Строка[0] == "ТекстИнструкции") Инструкция.Text = Строка[1];
                if (Строка[0] == "ТекстДЯ") ТекстДЯ.Text = Строка[1];

            }
        }
    }
}











