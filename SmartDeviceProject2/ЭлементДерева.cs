using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace СкладскойУчет
{
    public class ЭлементДерева 
    {
        public bool ЭтоКорень;
        public string Адрес;
        public string EAN;
        public string GUID;
        public string Код;
        public string Наименование;
        public int КоличествоСобрано;
        public int КоличествоТребуется;
        public int КоличествоОстаток;
        public int КоличествоВычерк = 0;
        public TreeNode Ветвь;
        public string[] EANs;

        public ЭлементДерева(TreeNode Ветвь, string Адрес, string EAN)
        {
            this.ЭтоКорень = true;
            this.Ветвь = Ветвь;
            this.Адрес = Адрес;
            this.EAN = EAN;
        }



        public ЭлементДерева(bool ЭтоКорень, TreeNode Ветвь, params string[] Параметры)
        {

            this.ЭтоКорень = ЭтоКорень;
            this.Ветвь = Ветвь;
            this.Адрес = Параметры[0];
            this.EAN = Параметры[1];
            this.GUID = Параметры[3];
            this.Код = Параметры[4];
            this.Наименование = Параметры[5];

            this.КоличествоСобрано = int.Parse("0"+Параметры[6]);
            this.КоличествоТребуется = int.Parse("0"+Параметры[7]);
            this.КоличествоОстаток = int.Parse("0"+Параметры[8]);
        }



        public string ПолучитьТекстЭлемента()
        {
            if (ЭтоКорень) return Адрес;
            return String.Format("({0}/{1})({2})({3}){4}", КоличествоСобрано, КоличествоТребуется, КоличествоОстаток, Код, Наименование);
        }

        public void ОбновитьТекстЭлемента()
        {
            if (ЭтоКорень) { Ветвь.Text = Адрес; return; }
            if (Ветвь != null) Ветвь.Text = String.Format("({0}/{1})({2})({3}){4}", КоличествоСобрано, КоличествоТребуется, КоличествоОстаток, Код, Наименование);
        }


    }
}
