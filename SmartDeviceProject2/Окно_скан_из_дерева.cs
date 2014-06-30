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
        private int КолонкаРучногоВыбора = 0;
        private ПоследовательностьОкон Последовательность;
        private List<ЭлементДерева> ПолноеДерево;

        public Окно_скан_из_дерева(ПоследовательностьОкон ПоследовательностьОкон)
        {
            InitializeComponent();
            Последовательность = ПоследовательностьОкон;
            Обмен = new Пакеты(ПоследовательностьОкон.Операция+" ВыборЗадания"); //Сформировали пакет с операцией состоящей например "Подбор ВыборЗадания"
            Сканер = new РаботаСоСканером();
        }

        public void _Назад()
        {
            this.DialogResult = DialogResult.Cancel;
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
             TreeNode КореньАдрес = null;
             ЭлементДерева Корень = null;
             foreach (var Строка in Последовательность.ОтветСервера)
             {


                 if (Строка[0].Contains("ДобавитьСтрокивКорень")) {
                     КореньАдрес = new TreeNode(Строка[1]);
                     Корень = new ЭлементДерева(true,КореньАдрес.Index,Строка[1]);
                     КореньАдрес.Text = Корень.ПолучитьТекстЭлемента();
                     ПолноеДерево.Add(Корень);
                     continue;
                 }

                 if (КореньАдрес != null && Корень != null)
                 {
                     TreeNode СтрокаСТоваром = new TreeNode(Строка[4]);
                     //                                        string Адрес, EAN, EAN2, GUID, Код, Наименование,  int КоличествоСобрано,  int КоличествоТребуется, int КоличествоОстаток,
                     ЭлементДерева Элемент = new ЭлементДерева(false, СтрокаСТоваром.Index, Корень.Адрес ,Строка[1], Строка[2], Строка[3], Строка[4], Строка[5], Строка[6]);
                     СтрокаСТоваром.Text = Элемент.ПолучитьТекстЭлемента();
                     КореньАдрес.Nodes.Add(СтрокаСТоваром);
                 }


             }
             ЗаполнениеЭлементовФормы.ЗаполнитьФорму(this,ref Последовательность.ОтветСервера,out КолонкаРучногоВыбора);
         }

         private void Дерево_AfterSelect(object sender, TreeViewEventArgs e)
         {

         }

         private void tabPage2_Click(object sender, EventArgs e)
         {

         }

    }
}