using System;
using System.Windows.Forms;

namespace СкладскойУчет
{
    public class ЭлементДерева 
    {
        public bool ЭтоКорень;
        public string Адрес;
        public string EAN; //в будущем его необходимо перенести в EANs
        public string GUID;
        public string Код;
        public string Наименование;
        public int КоличествоСобрано;
        public int КоличествоТребуется;
        public int КоличествоОстаток;
        public int КоличествоВычерк = 0;
        
        public TreeNode Ветвь; // в форме с деревом тут хранится ветвь дерева
        public ListViewItem СтрокаСписка; //в формах со списком товаров тут будет храниться элемент/строка списка
        public int СекундПодбора = 0;
        public int СекундВычерк = 0;
        public string[] EANs; // куча Ean товаров



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

        public override string ToString() {
            return ПолучитьТекстЭлемента();
        }

        public void ОбновитьТекстЭлемента()
        {
            if (ЭтоКорень) { Ветвь.Text = Адрес; return; }
            if (Ветвь != null){ Ветвь.Text = String.Format("({0}/{1})({2})({3}){4}", КоличествоСобрано, КоличествоТребуется, КоличествоОстаток, Код, Наименование);
            
            Ветвь.TreeView.Update();}
        }


    }
}
