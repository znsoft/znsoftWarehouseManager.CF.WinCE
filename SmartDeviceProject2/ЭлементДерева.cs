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
        public string EAN2;
        public string GUID;
        public string Код;
        public string Наименование;
        public int КоличествоСобрано;
        public int КоличествоТребуется;
        public int КоличествоОстаток;
        public int КоличествоВычерк = 0;
        public TreeNode Ветвь;

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

        public void ОбновитьТекстЭлемента()
        {
            if (ЭтоКорень) { Ветвь.Text = Адрес; return; }
            Ветвь.Text = String.Format("({0}/{1})({2})({3}){4}", КоличествоСобрано, КоличествоТребуется, КоличествоОстаток, Код, Наименование);
            //Ветвь.TreeView.Update();
        }


    }
}
