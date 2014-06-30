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
        public string Tag;

        public ЭлементДерева(  string Tag, string Адрес ,string EAN)
        {
            this.ЭтоКорень = true;
            this.Tag = Tag;
            this.Адрес = Адрес;
            this.EAN = EAN;
        }



        public ЭлементДерева(bool ЭтоКорень, string Tag, params string[] Параметры)
        {

            this.ЭтоКорень = ЭтоКорень;
            this.Tag = Tag;
            this.Адрес = Параметры[0];
            this.EAN = Параметры[1];
            this.EAN2 = Параметры[2];
            this.GUID = Параметры[3];
            this.Код = Параметры[4];
            this.Наименование = Параметры[5];
            this.КоличествоСобрано = int.Parse(Параметры[6]);
            this.КоличествоТребуется = int.Parse(Параметры[7]);
            this.КоличествоОстаток = int.Parse(Параметры[8]);
        }



        public string ПолучитьТекстЭлемента()
        {
            if (ЭтоКорень) return Адрес;
            return String.Format("({0}/{1})({2})({3}){4}", КоличествоСобрано, КоличествоТребуется, КоличествоОстаток, Код, Наименование);
        }



    }
}
