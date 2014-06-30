using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace СкладскойУчет
{
    public class ЭлементДерева
    {
        public bool ЭтоКорень;
        public string Адрес;
        public string EAN;
        public string EAN2;
        public string GUID;
        public string Код;
        public string Наименование;
        public int КоличествоСобрано;
        public int КоличествоТребуется;
        public int КоличествоОстаток;
        public int Index;

        public ЭлементДерева(bool ЭтоКорень, string Адрес, int Index)
        {
            this.ЭтоКорень = ЭтоКорень;
            this.Index = Index;
            this.Адрес = Адрес;
        }



        public ЭлементДерева(bool ЭтоКорень, int Index, params string[] Параметры)
        {

            this.ЭтоКорень = ЭтоКорень;
            this.Index = Index;

            this.Адрес = Параметры[0];
            //if (Параметры.Count() < 2) return;
            this.EAN = Параметры[1];
            this.EAN2 = Параметры[2];
            this.GUID = Параметры[3];
            this.Код = Параметры[4];
            this.КоличествоСобрано = int.Parse(Параметры[5]);
            this.КоличествоТребуется = int.Parse(Параметры[6]);
            this.КоличествоОстаток = int.Parse(Параметры[7]);
        }

        public ЭлементДерева(bool ЭтоКорень,
                            string Адрес,
                            string EAN,
                            string EAN2,
                            string GUID,
                            string Код,
                            string Наименование,
                            int КоличествоСобрано,
                            int КоличествоТребуется,
                            int КоличествоОстаток,
                            int Index)
        {
            this.ЭтоКорень = ЭтоКорень;
            this.Адрес = Адрес;
            this.EAN = EAN;
            this.EAN2 = EAN2;
            this.GUID = GUID;
            this.Код = Код;
            this.Наименование = Наименование;
            this.КоличествоСобрано = КоличествоСобрано;
            this.КоличествоТребуется = КоличествоТребуется;
            this.КоличествоОстаток = КоличествоОстаток;
            this.Index = Index;
        }


        public string ПолучитьТекстЭлемента()
        {
            if (ЭтоКорень) return Адрес;
            return String.Format("({0}/{1})({2})({3}){4}", КоличествоСобрано, КоличествоТребуется, КоличествоОстаток, Код, Наименование);
        }



    }
}
