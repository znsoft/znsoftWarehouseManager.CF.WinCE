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
    public partial class Окно_выбора_из_дерева : Form
    {
        private Пакеты Обмен;
        private ПоследовательностьОкон Последовательность;
        private List<ЭлементДерева> ПолноеДерево = new List<ЭлементДерева>();//поскольку для работы с sql базами данных с собой необходимо нести .dll я решил использовать linq на List для эмуляции sql
        private string ТекущийАдрес = null;

        public Окно_выбора_из_дерева(ПоследовательностьОкон ПоследовательностьОкон)
        {
            InitializeComponent();
            Последовательность = ПоследовательностьОкон;
        }



        private void РаскрытьАдрес(ЭлементДерева Элемент)
        {
            Дерево.CollapseAll();
            Элемент.Ветвь.Expand();
        }

 
        public void _Назад()
        {
            this.DialogResult = DialogResult.Abort;
            this.Close();
        }

        private void Окно_выбора_из_списка_KeyDown(object sender, KeyEventArgs e)
        {
            if (РаботаСоСканером.НажатаКлавишаСкан(e))
            {
                string СтрокаСкан = РаботаСоСканером.Scan();
                if (СтрокаСкан.Length != 0)
                {
                    e.Handled = true;
                        //ОбработатьСкан(СтрокаСкан);
                }
                return;
            }
            if (РаботаСоСканером.НажатаПраваяПодэкраннаяКлавиша(e)) {
                e.Handled = true;
            }

            if ((e.KeyCode == System.Windows.Forms.Keys.D0))
            {
                e.Handled = true;
            }
            if ((e.KeyCode == System.Windows.Forms.Keys.D1))
            {
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
             ЭлементыФормы.ТекстДЯ = null;
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
            ЭлементДерева Элемент = new ЭлементДерева(false, СтрокаСТоваром, Корень.Адрес, Строка[0], Строка[1], Строка[2], Строка[3], Строка[4], Строка[5], Строка[6], Строка[7]);
            СтрокаСТоваром.Tag = Элемент.GUID;
            СтрокаСТоваром.Text = Элемент.ПолучитьТекстЭлемента();
            КореньАдрес.Nodes.Add(СтрокаСТоваром);
            ПолноеДерево.Add(Элемент);
            return ВыбранаСтрока;
        }



    }
}