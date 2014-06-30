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

        public Окно_скан_из_дерева(ПоследовательностьОкон ПоследовательностьОкон)
        {
            InitializeComponent();
            Последовательность = ПоследовательностьОкон;
            Обмен = new Пакеты(ПоследовательностьОкон.Операция + " СканЗадания"); //Сформировали пакет с операцией состоящей например "Подбор СканЗадания"
            Сканер = new РаботаСоСканером();
        }

        public void _Назад()
        {
            this.DialogResult = DialogResult.Abort;
            this.Close();//Нажали назад, необходимо попасть на предыдущее окно, думаю можно и самому решить этот вопрос без обращения к серверу
        
        }

         private void ПриНажатииНаКнопку(object sender, EventArgs Аргументы)
        {
            Button Кнопка = (Button)sender;
            switch (Кнопка.Name)
            {
                case "Назад":
                    _Назад();
                    return;
            }
            MethodInfo method = this.GetType().GetMethod("_" + Кнопка.Name);
             if(method != null) 
            method.Invoke(this, null);
        }

         private void Окно_выбора_из_списка_KeyDown(object sender, KeyEventArgs e)
         {
             if (РаботаСоСканером.НажатаКлавишаСкан(e))
             {
                 string СтрокаСкан = РаботаСоСканером.Scan();
                 if (СтрокаСкан.Length != 0)
                 {

                     Последовательность.ОтветСервера = Обмен.ПослатьСтроку(СтрокаСкан, Последовательность.ТекущееОкно, "СканированВыбор");
                     if (Последовательность.ОтветСервера == null) return; // в случае ошибки остаться в этом же окне
                     this.DialogResult = DialogResult.Retry;
                     this.Close();

                 }
                 return;


             }



             foreach (var ЭлементФормы in this.Controls)
                 if (ЭлементФормы is Button)
                 {
                     Button Кнопка = (Button)ЭлементФормы;
                     if ((char)Кнопка.Text[0] == (char)e.KeyValue)
                     {
                         Кнопка.Focus();
                         ПриНажатииНаКнопку(Кнопка, new EventArgs());
                         return;
                     }
                 }


             if ((e.KeyCode == System.Windows.Forms.Keys.Up))
             {
                 // Up
             }
             if ((e.KeyCode == System.Windows.Forms.Keys.Down))
             {
                 // Down
             }
             if ((e.KeyCode == System.Windows.Forms.Keys.Left))
             {
                 // Left
             }
             if ((e.KeyCode == System.Windows.Forms.Keys.Right))
             {
                 // Right
             }


         }


         private void Окно_выбора_из_списка_Load(object sender, EventArgs e)
         {
             Дерево.Focus();
             
             TreeNode КореньАдрес = null;
             TreeNode ВыбранаСтрока = null;
             ЭлементДерева Корень = null;
             Дерево.CollapseAll();
             bool Раскрыть = false;
             foreach (var Строка in Последовательность.ОтветСервера)
             {
                     
                 if (Строка[0].CompareTo("ЗавершитьЗагрузкуДанных")==0) break;
                 if (Строка[0].CompareTo("ДобавитьКорень")==0) {
                     if (КореньАдрес != null) Дерево.Nodes.Add(КореньАдрес);
                     КореньАдрес = new TreeNode(Строка[1]);
                     if (Строка.Count() == 4 && Строка[3].CompareTo("Раскрыть") == 0){ КореньАдрес.Expand(); }else{ КореньАдрес.Collapse();}
                     Корень = new ЭлементДерева( Строка[1], Строка[1], Строка[2]);
                     КореньАдрес.Tag = Корень.Tag;
                     КореньАдрес.Text = Корень.ПолучитьТекстЭлемента();
                     ПолноеДерево.Add(Корень);
                     continue;
                 }

                 if (КореньАдрес != null && Корень != null)
                 {
                     TreeNode СтрокаСТоваром = new TreeNode(Строка[3]);
                     if (Строка.Count() == 9 && Строка[8].CompareTo("Выбрать") == 0) { ВыбранаСтрока = СтрокаСТоваром;}
                     //                                        string Адрес, EAN, EAN2, GUID, Код, Наименование,     int КоличествоСобрано,  int КоличествоТребуется, int КоличествоОстаток,
                     ЭлементДерева Элемент = new ЭлементДерева(false, Строка[2], Корень.Адрес, Строка[0], Строка[1], Строка[2], Строка[3], Строка[4], Строка[5], Строка[6], Строка[7]);
                     СтрокаСТоваром.Tag = Элемент.Tag;
                     СтрокаСТоваром.Text = Элемент.ПолучитьТекстЭлемента();
                     КореньАдрес.Nodes.Add(СтрокаСТоваром);
                     ПолноеДерево.Add(Элемент);
                     continue;
                 }

             }
             if (КореньАдрес != null) Дерево.Nodes.Add(КореньАдрес);
             if (ВыбранаСтрока != null) Дерево.SelectedNode = ВыбранаСтрока;
             int КолонкаРучногоВыбора;
             ЗаполнениеЭлементовФормы.ЗаполнитьФорму(this,ref Последовательность.ОтветСервера,out КолонкаРучногоВыбора);
         }

         private void Дерево_AfterSelect(object sender, TreeViewEventArgs e)
         {

         }

         private void tabPage2_Click(object sender, EventArgs e)
         {

         }

         private void Выход_Click(object sender, EventArgs e)
         {
             _Назад(); 
         }

    }
}