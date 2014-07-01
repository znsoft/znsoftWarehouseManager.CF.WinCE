using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using СкладскойУчет;
using СкладскойУчет.СсылкаНаСервис;
using System.Net;

namespace СкладскойУчет
{
    public partial class Окно_скан_из_дерева : Form
    {
        private Пакеты Обмен;
        private РаботаСоСканером Сканер;
        private ПоследовательностьОкон Последовательность;
        private List<ЭлементДерева> ПолноеДерево = new List<ЭлементДерева>();//поскольку для работы с sql базами данных с собой необходимо нести .dll я решил использовать linq на List для эмуляции sql
        private string ТекущийАдрес;
        List<string[]> КоллекцияСтрок = new List<string[]>();

        public Окно_скан_из_дерева(ПоследовательностьОкон ПоследовательностьОкон)
        {
            InitializeComponent();
            Последовательность = ПоследовательностьОкон;
            Сканер = new РаботаСоСканером();
        }



        private ЭлементДерева НайтиСкан(string EAN)
        {
            var Элемент = from Строка in ПолноеДерево
                          where (Строка.EAN == EAN || Строка.EAN2 == EAN || Строка.Код == EAN)
                          && (Строка.Адрес == ТекущийАдрес || Строка.ЭтоКорень)
                          select Строка;
            if (Элемент.Count() == 0) return null;
            return Элемент.First();
        }

        private ЭлементДерева ОбработатьСкан(string EAN)
        {
            var Элемент = НайтиСкан(EAN);
            if (Элемент == null) { ПолучитьИнфоОт1С(EAN); return null; }
            Дерево.SelectedNode = Элемент.Ветвь;
            if (Элемент.ЭтоКорень)
            {
                Дерево.CollapseAll();
                ТекущийАдрес = Элемент.Адрес;
                Элемент.Ветвь.Expand();
                return Элемент;
            }
            Элемент.КоличествоСобрано++;
            if (Элемент.КоличествоСобрано == Элемент.КоличествоТребуется)
            {
                УдалитьНаЭкране(Элемент);
                if (Элемент.Ветвь == null) return Элемент;
                if (Элемент.Ветвь.Parent.Nodes.Count == 0)
                {
                    УдалитьТекущийАдресНаЭкране();
                    ПроверитьЗаданиеИЗавершить();
                }
                return Элемент;
            }
            Элемент.ОбновитьТекстЭлемента();
            //Дерево.Update();
            return Элемент;
        }

        void ДобавитьСтроку(params string[] args)
        {
            КоллекцияСтрок.Add(args);
        }

        private void ПроверитьЗаданиеИЗавершить()
        {
            if (Дерево.Nodes.Count != 0) return;

            if(ТекстДЯ.Text.Length < 8){(new Ошибка("Необходимо сканировать динамическую ячейку")).ShowDialog();      return;          }
            
            КоллекцияСтрок.Clear();
            
            foreach(var Строка in ПолноеДерево){
                if(Строка.ЭтоКорень)continue;
                ДобавитьСтроку(Строка.Адрес, Строка.GUID, Строка.КоличествоСобрано.ToString(), Строка.КоличествоВычерк.ToString());
            }

            Обмен = new Пакеты(Последовательность.Операция + " ЗавершениеЗадания");
            Последовательность.ОтветСервера = Обмен.Послать(ТекстДЯ.Text, КоллекцияСтрок.ToArray());
            if (Последовательность.ОтветСервера == null) return; // в случае ошибки остаться в этом же окне
            this.DialogResult = DialogResult.Retry;
            this.Close();
        }

        private void УдалитьТекущийАдресНаЭкране()
        {
            var Элемент_ = from Строка in ПолноеДерево
                           where Строка.Адрес == ТекущийАдрес && Строка.ЭтоКорень
                           select Строка;
            if (Элемент_.Count() == 0) return;
            var Элемент = Элемент_.First();
            УдалитьНаЭкране(Элемент);
        }



        private void ПолучитьИнфоОт1С(string EAN)
        {
            //throw new NotImplementedException();
        }

        private void УдалитьНаЭкране(ЭлементДерева Элемент)
        {
            Дерево.Nodes.Remove(Элемент.Ветвь);
            Элемент.Ветвь = null;
            //Дерево.Update();
        }

        public void _Назад()
        {
            this.DialogResult = DialogResult.Abort;
            this.Close();//Нажали назад, необходимо попасть на предыдущее окно, думаю можно и самому решить этот вопрос без обращения к серверу

        }


        private void Окно_выбора_из_списка_KeyDown(object sender, KeyEventArgs e)
        {
            if (РаботаСоСканером.НажатаКлавишаСкан(e))
            {
                string СтрокаСкан = РаботаСоСканером.Scan();
                if (СтрокаСкан.Length != 0)
                {
                    e.Handled = true;
                    ОбработатьСкан(СтрокаСкан);
                }
                return;
            }

        }


        private void Окно_выбора_из_списка_Load(object sender, EventArgs e)
        {
            Дерево.Focus();

            TreeNode КореньАдрес = null;
            TreeNode ВыбранаСтрока = null;
            ЭлементДерева Корень = null;
            Дерево.CollapseAll();
            foreach (var Строка in Последовательность.ОтветСервера)
            {

                if (Строка[0] == "ЗавершитьЗагрузкуДанных") break;
                if (Строка[0] == "ДобавитьКорень")
                {
                    if (КореньАдрес != null)
                    {
                        Дерево.Nodes.Add(КореньАдрес);
                    }
                    КореньАдрес = new TreeNode(Строка[1]);

                    if (Строка.Count() == 4 && Строка[3] == "Раскрыть")
                    {
                        ТекущийАдрес = Строка[1];
                        КореньАдрес.Expand();
                    }
                    else
                    {
                        КореньАдрес.Collapse();
                    }
                    Корень = new ЭлементДерева(КореньАдрес, Строка[1], Строка[2]);
                    КореньАдрес.Tag = Строка[2];
                    КореньАдрес.Text = Корень.ПолучитьТекстЭлемента();
                    ПолноеДерево.Add(Корень);

                    continue;
                }

                if (КореньАдрес != null && Корень != null)
                {
                    TreeNode СтрокаСТоваром = new TreeNode(Строка[3]);
                    if (Строка.Count() == 9 && Строка[8] == "Выбрать") { ВыбранаСтрока = СтрокаСТоваром; }
                                        //                                        string Адрес,     EAN,        EAN2,   GUID,       Код,        Наименование,int КоличествоСобрано,int КоличествоТребуется, int КоличествоОстаток,
                    ЭлементДерева Элемент = new ЭлементДерева(false, СтрокаСТоваром, Корень.Адрес, Строка[0], Строка[1], Строка[2], Строка[3], Строка[4], Строка[5], Строка[6], Строка[7]);
                    СтрокаСТоваром.Tag = Элемент.GUID;
                    СтрокаСТоваром.Text = Элемент.ПолучитьТекстЭлемента();
                    КореньАдрес.Nodes.Add(СтрокаСТоваром);
                    ПолноеДерево.Add(Элемент);
                    continue;
                }

            }
            if (КореньАдрес != null) { Дерево.Nodes.Add(КореньАдрес); }
            if (ВыбранаСтрока != null) Дерево.SelectedNode = ВыбранаСтрока;
            int КолонкаРучногоВыбора;
            ЗаполнениеЭлементовФормы.ЗаполнитьФорму(this, ref Последовательность.ОтветСервера, out КолонкаРучногоВыбора);
        }


        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void Выход_Click(object sender, EventArgs e)
        {
            _Назад();
        }

        private void Дерево_AfterSelect_1(object sender, TreeViewEventArgs e)
        {


        }

    }
}