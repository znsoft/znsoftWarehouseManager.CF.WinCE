﻿using System;
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
        private ПоследовательностьОкон Последовательность;
        private List<ЭлементДерева> ПолноеДерево = new List<ЭлементДерева>();//поскольку для работы с sql базами данных с собой необходимо нести .dll я решил использовать linq на List для эмуляции sql
        private string ТекущийАдрес = null;
        List<string[]> КоллекцияСтрок = new List<string[]>();
        bool KeyIsPressed;

        public Окно_скан_из_дерева(ПоследовательностьОкон ПоследовательностьОкон)
        {
            InitializeComponent();
            Последовательность = ПоследовательностьОкон;
        }



        private string ВыбратьТоварИзМножества(IEnumerable<ЭлементДерева> Выборка)
        {
            ИнтерактивныйВыборТовара ОкноВыбора = new ИнтерактивныйВыборТовара(Последовательность);
            ListView СписокВыбора = ОкноВыбора.СписокВыбора;
            СписокВыбора.Columns.Add("Код", 70, HorizontalAlignment.Left);
            СписокВыбора.Columns.Add("Товар", 160, HorizontalAlignment.Left);
            ОкноВыбора.Инструкция.Text = "Выберите товар из списка";
            foreach (ЭлементДерева Товар in Выборка)
            {
                ListViewItem НоваяСтрока = new ListViewItem();
                НоваяСтрока.Text = Товар.Код;//Код
                НоваяСтрока.SubItems.Add(Товар.Наименование);//Наименование
                НоваяСтрока.SubItems.Add(Товар.GUID);//Гуид
                СписокВыбора.Items.Add(НоваяСтрока);
            }
            DialogResult Результат = ОкноВыбора.ShowDialog();
            if (Результат == DialogResult.Cancel) return null;
            return ОкноВыбора.ВыбранГуид;
        }


        private ЭлементДерева НайтиСкан(string EAN)
        {
            var Элемент = НайтиEANGUID(EAN);

            if (Элемент.Count() > 1)  Элемент = ВыбратьТоварИзМножества_(Элемент);
            if (Элемент == null || Элемент.Count() == 0) return null;
            return Элемент.First();
        }

        private IEnumerable<ЭлементДерева> ВыбратьТоварИзМножества_(IEnumerable<ЭлементДерева> Элементы)
        {
            return НайтиEANGUID(ВыбратьТоварИзМножества(Элементы)); 
        }

        private IEnumerable<ЭлементДерева> НайтиEANGUID(string EAN)
        {
            var Элемент = from Строка in ПолноеДерево
                          where (Строка.EAN == EAN || Строка.Код == EAN || Строка.GUID == EAN || ЕстьДругиеEAN(Строка, EAN))
                          && (Строка.Адрес == ТекущийАдрес || Строка.ЭтоКорень)
                          select Строка;
            return Элемент;
        }

        private bool ЕстьДругиеEAN(ЭлементДерева Строка, string EAN)
        {
            if (Строка.EANs == null) return false;
            var ДругиеEAN = (from string EAN1 in Строка.EANs where EAN1 == EAN select Строка).FirstOrDefault();
            if (ДругиеEAN == null) return false;
            return true;
        }

        private ЭлементДерева НайтиGUID(string GUID)
        {
            var Элемент = from Строка in ПолноеДерево
                          where Строка.GUID == GUID
                          && Строка.Адрес == ТекущийАдрес
                          select Строка;
            if (Элемент.Count() == 0) return null;
            return Элемент.First();
        }

        private ЭлементДерева НайтиЭлемент(string GUID)
        {
            var Элемент = from Строка in ПолноеДерево
                          where Строка.GUID == GUID
                          select Строка;
            if (Элемент.Count() == 0) return null;
            return Элемент.First();
        }

        private ЭлементДерева ОбработатьСкан(string EAN)
        {
            var Элемент = НайтиСкан(EAN);
            if (Элемент == null) { ПолучитьИнфоОт1С(EAN); return null; }
            if (Элемент.Ветвь == null) { ОшибкаТоварНеНайден(); return null; }
            return ОбработатьЭлементДерева(Элемент);
        }

        private ЭлементДерева ОбработатьЭлементДерева(ЭлементДерева Элемент)
        {
            Дерево.SelectedNode = Элемент.Ветвь;
            if (Элемент.ЭтоКорень)
            {
                return РаскрытьАдрес(Элемент);
            }
            Элемент.КоличествоСобрано++;
            ОбработатьКоличествоЭлемента(Элемент);

            return Элемент;
        }

        private void ОбработатьКоличествоЭлемента(ЭлементДерева Элемент)
        {
            if (Элемент.КоличествоСобрано == Элемент.КоличествоТребуется || Элемент.КоличествоВычерк > 0)
            {
                if (Элемент.Ветвь == null) return;
                if (Элемент.Ветвь.Parent.Nodes.Count == 1)
                {
                    УдалитьНаЭкране(Элемент);
                    УдалитьТекущийАдресНаЭкране();
                    ПроверитьЗаданиеИЗавершить();
                    return;
                }
                УдалитьНаЭкране(Элемент);
            }
            Элемент.ОбновитьТекстЭлемента();

        }

        private ЭлементДерева РаскрытьАдрес(ЭлементДерева Элемент)
        {
            Дерево.CollapseAll();
            ТекущийАдрес = Элемент.Адрес;

            Элемент.Ветвь.Expand();

            return Элемент;
        }

        void ДобавитьСтроку(params string[] args)
        {
            КоллекцияСтрок.Add(args);
        }

        private void ПроверитьЗаданиеИЗавершить()
        {
            if (Дерево.Nodes.Count != 0) return;
            if (ТекстДЯ.Text.Length < 8) { Инфо.Ошибка("Необходимо сканировать динамическую ячейку"); return; }
            Обмен = new Пакеты(Последовательность.Операция + " ЗавершениеЗадания");
            ВыслатьВсеДерево(Обмен, false);
            if (Последовательность.ОтветСервера == null) return; // в случае ошибки остаться в этом же окне
            this.DialogResult = DialogResult.Retry;
            this.Close();
        }

        private void ВыслатьВсеДерево(Пакеты Обмен, bool ТолькоСобранное)
        {
            КоллекцияСтрок.Clear();
            foreach (var Строка in ПолноеДерево)
            {
                if (Строка.ЭтоКорень) continue;
                if (ТолькоСобранное && Строка.КоличествоВычерк == 0 && Строка.КоличествоСобрано == 0) continue;
                ДобавитьСтроку(Строка.Адрес, Строка.GUID, Строка.КоличествоСобрано.ToString(), Строка.КоличествоВычерк.ToString());
            }
            if (КоллекцияСтрок.Count() == 0)
            {
                Последовательность.ОтветСервера = Обмен.Послать(ТекстДЯ.Text, null);
                return;
            }
            Последовательность.ОтветСервера = Обмен.Послать(ТекстДЯ.Text, КоллекцияСтрок.ToArray());
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
            Обмен = new Пакеты(Последовательность.Операция + " НайтиТовар");
            Последовательность.ОтветСервера = Обмен.ПослатьСтроку(EAN, ТекущийАдрес, ТекстДЯ.Text);
            if (Последовательность.ОтветСервера == null) return; // в случае ошибки остаться в этом же окне
            foreach (var Строка in Последовательность.ОтветСервера)
            {
                switch (Строка[0])
                {
                    case "ТекстДЯ":
                        СменитьДЯ(Строка[1]);
                        break;
                    case "Товар":
                        ОбработатьТовар(Строка[1]);
                        break;
                }
            }

        }

        private void СменитьДЯ(string Строка)
        {
            if (ТекстДЯ.Text == Строка) return;
            ЗапросСменаДЯ(Строка);
            if (Последовательность.ОтветСервера == null) return;
            if (Последовательность.ОтветСервера.Count() == 0) return;
            ЗаполнитьДерево();
        }

        private void ЗапросСменаДЯ(string Строка)
        {
            Обмен = new Пакеты(Последовательность.Операция + " СменитьДЯ");
            ВыслатьВсеДерево(Обмен, true);
            ТекстДЯ.Text = Строка;
        }

        private void ОбработатьТовар(string Строка)
        {
            var Элемент = НайтиСкан(Строка);
            if (Элемент == null) { ОшибкаТоварНеНайден(); return; }
            if (Элемент.Ветвь == null) { ОшибкаТоварНеНайден(); return; }

            ОбработатьЭлементДерева(Элемент);
        }

        private static void ОшибкаТоварНеНайден()
        {
            Инфо.Ошибка("Товар не найден в задании на подбор с данного адреса");
        }

        private void УдалитьНаЭкране(ЭлементДерева Элемент)
        {
            if (Элемент.Ветвь != null) Элемент.Ветвь.Remove();
            
            Элемент.Ветвь = null;
            Дерево.Update();
        }

        public void _Назад()
        {
            //ЗапросСменаДЯ(ТекстДЯ.Text);
            //if (КоллекцияСтрок.Count() > 0)
            //{
            //    if (Последовательность.ОтветСервера == null) return;
            //    if (Последовательность.ОтветСервера.Count() == 0) return;
            //}
            this.DialogResult = DialogResult.Abort;
            this.Close();

        }

        private void Окно_выбора_из_списка_KeyDown(object sender, KeyEventArgs e)
        {
            KeyIsPressed = true;
            if (РаботаСоСканером.НажатаКлавишаСкан(e))
            {
                string СтрокаСкан = РаботаСоСканером.Scan();
                if (СтрокаСкан.Length != 0)
                {
                    e.Handled = true;
                    if (Таб.SelectedIndex == 0)
                    {
                        ОбработатьСкан(СтрокаСкан);
                    }
                    else Инфо.ПолучениеИнформации(СтрокаСкан, СписокИнформации, Таб); 
                }
                return;
            }
            if (РаботаСоСканером.НажатаПраваяПодэкраннаяКлавиша(e)) {
                e.Handled = true;
                Меню_Click(sender, new EventArgs());
            }

            if ((e.KeyCode == System.Windows.Forms.Keys.D0))
            {
                e.Handled = true;
                Меню_Click(sender,new EventArgs());
            }
            if ((e.KeyCode == System.Windows.Forms.Keys.D1))
            {
                Таб.SelectedIndex = 0;
                Таб.Update();
                e.Handled = true;
            }
            if ((e.KeyCode == System.Windows.Forms.Keys.D2))
            {
                Таб.SelectedIndex = 1;
                Таб.Update();
                e.Handled = true;
            }


        }

        private void Окно_выбора_из_списка_Load(object sender, EventArgs e)
        {
            ЗаполнитьДерево();
            int НомерКонокиГУИД = 0;
                         ЭлементыФормыЗаполнения ЭлементыФормы = new ЭлементыФормыЗаполнения();
             ЭлементыФормы.Инструкция = this.Инструкция;
             ЭлементыФормы.СписокВыбора = null;
             ЭлементыФормы.ТекстДЯ = this.ТекстДЯ;
             ЭлементыФормы.Пользователь = this.Пользователь;
             ЗаполнениеЭлементовФормы.ЗаполнитьФорму(ЭлементыФормы, ref Последовательность.ОтветСервера, ref НомерКонокиГУИД);
        }

        private void ЗаполнитьДерево()
        {
            Дерево.Focus();
            Дерево.Nodes.Clear();
            TreeNode КореньАдрес = null;
            TreeNode ВыбранаСтрока = null;
            ЭлементДерева Корень = null;
            ПолноеДерево.Clear();
            Дерево.CollapseAll();
            foreach (var Строка in Последовательность.ОтветСервера)
            {

                if (Строка[0] == "ЗавершитьЗагрузкуДанных") break;
                if (Строка[0] == "ДобавитьКорень")
                {
                    ДобавитьАдрес(ref КореньАдрес, ref Корень, Строка);
                    continue;
                }

                if (КореньАдрес != null && Корень != null)
                {
                    ВыбранаСтрока = ДобавитьТовар(КореньАдрес, ВыбранаСтрока, Корень, Строка);
                    continue;
                }

            }
            if (КореньАдрес != null) { Дерево.Nodes.Add(КореньАдрес); }
            if (ВыбранаСтрока != null) Дерево.SelectedNode = ВыбранаСтрока;
        }

        private void ДобавитьАдрес(ref TreeNode КореньАдрес, ref ЭлементДерева Корень, string[] Строка)
        {
            if (КореньАдрес != null)
            {
                Дерево.Nodes.Add(КореньАдрес);
            }
            КореньАдрес = new TreeNode(Строка[1]);

            if ((Строка.Count() == 4 && Строка[3] == "Раскрыть") || ТекущийАдрес == Строка[1])
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
        }

        private TreeNode ДобавитьТовар(TreeNode КореньАдрес, TreeNode ВыбранаСтрока, ЭлементДерева Корень, string[] Строка)
        {
            int Строк = Строка.Count();
            TreeNode СтрокаСТоваром = new TreeNode(Строка[3]);
            if (Строк > 8 && Строка[8] == "Выбрать") { ВыбранаСтрока = СтрокаСТоваром; }
            //root , СтрокаСТоваром, Адрес,   EAN , "" ,   GUID,       Код,        Наименование,int КоличествоСобрано,int КоличествоТребуется, int КоличествоОстаток,
            ЭлементДерева Элемент = new ЭлементДерева(false, СтрокаСТоваром, Корень.Адрес, Строка[0], Строка[1], Строка[2], Строка[3], Строка[4], Строка[5], Строка[6], Строка[7]);
            ЗаполнитьОстальныеEAN(Строка, Элемент);
            СтрокаСТоваром.Tag = Элемент.GUID;
            СтрокаСТоваром.Text = Элемент.ПолучитьТекстЭлемента();
            КореньАдрес.Nodes.Add(СтрокаСТоваром);
            ПолноеДерево.Add(Элемент);
            return ВыбранаСтрока;
        }

        private static void ЗаполнитьОстальныеEAN(string[] Строка, ЭлементДерева Элемент)
        {
            int Строк = Строка.Count();
            if (Строк > 9)
            {
                Элемент.EANs = new string[Строк - 9];
                for (int i = 9; i < Строк; i++) Элемент.EANs[i - 9] = Строка[i];
            }
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void Дерево_AfterSelect_1(object sender, TreeViewEventArgs e)
        {
            string Tag = e.Node.Tag as string;
            var Элемент = НайтиЭлемент(Tag);
            if (Элемент == null) return;
            if (Элемент.ЭтоКорень) return;
            ДопИнфоОТоваре.Text = Элемент.Наименование;
            if (!KeyIsPressed)
            {
                //ПроверитьДоступностьМеню();
                //МенюПодбора.Show(Дерево, Дерево.Location);
            }

            if (KeyIsPressed) KeyIsPressed = false;
        }

        private void Подобрать_Click(object sender, EventArgs e)
        {
            var Элемент = ПолучитьЭлементИзДерева();
            if (Элемент == null) { return; }
            if (Элемент.ЭтоКорень) { return; }
            if (Элемент.Адрес != ТекущийАдрес) { Инфо.Ошибка("Необходимо сканировать адрес полки"); return; }
            ВводКоличества УзнатьКоличество = new ВводКоличества(string.Format("Введите необходимое количество {0} для подбора из доступных {1}", Элемент.Наименование, Элемент.КоличествоТребуется));
            DialogResult d = УзнатьКоличество.ShowDialog();
            if (d == DialogResult.OK)
            {
                int Количество = УзнатьКоличество.Количество_;
                if (Количество == 0) Количество = 1;
                if ((Количество + Элемент.КоличествоСобрано) > Элемент.КоличествоТребуется) { Инфо.Ошибка(string.Format("Необходимо ввести количество до {0}", Элемент.КоличествоТребуется - Элемент.КоличествоСобрано)); return; }
                Элемент.КоличествоСобрано += Количество;
                ОбработатьКоличествоЭлемента(Элемент);
            }
        }

        private void Вычерк_Click(object sender, EventArgs e)
        {

            var Элемент = ПолучитьЭлементИзДерева();
            if (Элемент == null) { return; }
            if (Элемент.ЭтоКорень) { return; }
            if (Элемент.Адрес != ТекущийАдрес) { Инфо.Ошибка("Необходимо сканировать адрес полки"); return; }
            Элемент.КоличествоВычерк = Элемент.КоличествоТребуется - Элемент.КоличествоСобрано;
            ОбработатьКоличествоЭлемента(Элемент);


        }

        private void МенюПодбора_Popup(object sender, EventArgs e)
        {

        }

        private ЭлементДерева ПолучитьЭлементИзДерева()
        {

            var Ветвь = Дерево.SelectedNode;
            if (Ветвь == null) return null;
            string Tag = Ветвь.Tag as string;
            var Элемент = НайтиЭлемент(Tag);
            return Элемент;

        }

        private void Завершить_Click(object sender, EventArgs e)
        {

            _Назад();
        }

        private void Меню_Click(object sender, EventArgs e)
        {
            ПроверитьДоступностьМеню();
            МенюПодбора.Show(Дерево, Дерево.Location);
        }

        private void ПроверитьДоступностьМеню() {

            Вычерк.Enabled = false;
            Подобрать.Enabled = false;
            var Элемент = ПолучитьЭлементИзДерева();
            if (Элемент == null)
            {
                return;
            }
            if (Элемент.ЭтоКорень)
            {
                return;

            }
            if (Элемент.Адрес != ТекущийАдрес) { return;  }
            Вычерк.Enabled = true;
            Подобрать.Enabled = true;

        
        }

        private void Дерево_KeyDown(object sender, KeyEventArgs e)
        {
            KeyIsPressed = true;
        }


    }
}