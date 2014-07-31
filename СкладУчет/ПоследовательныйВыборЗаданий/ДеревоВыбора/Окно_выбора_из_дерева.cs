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
    public partial class Окно_выбора_из_дерева : Form
    {
        private Пакеты Обмен;
        private ПоследовательностьОкон Последовательность;
        private string ТекущийАдрес = null;

        public Окно_выбора_из_дерева(ПоследовательностьОкон ПоследовательностьОкон)
        {
            InitializeComponent();
            Последовательность = ПоследовательностьОкон;
            Обмен = new Пакеты(ПоследовательностьОкон.Операция + " ВыборЗадания"); //Сформировали пакет с операцией состоящей например "Подбор ВыборЗадания"

        }

 
        public void _Назад()
        {
            this.DialogResult = DialogResult.Abort;
            this.Close();
        }


        public virtual void _Далее()
        {
            var ВыбраннаяСтрока = Дерево.SelectedNode;
            if (ВыбраннаяСтрока == null) { Инфо.Ошибка("Не выбрано ни одной строки"); return; }
            string ВыбранноеЗначение = ВыбраннаяСтрока.Tag as string;
            if(ВыбранноеЗначение == null) { Инфо.Ошибка("Выбрана ошибочная строка"); return; }
            Последовательность.ОтветСервера = Обмен.ПослатьСтроку(ВыбранноеЗначение, Последовательность.ТекущееОкно, "РучнойВыбор");
            if (Последовательность.ОтветСервера == null) return; // в случае ошибки остаться в этом же окне
            this.DialogResult = DialogResult.Retry;
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
                    Последовательность.ОтветСервера = Обмен.ПослатьСтроку(СтрокаСкан, Последовательность.ТекущееОкно, "СканированВыбор");
                    if (Последовательность.ОтветСервера == null) return; // в случае ошибки остаться в этом же окне
                    this.DialogResult = DialogResult.Retry;
                    this.Close();
                }
                return;
            }

            if ((e.KeyCode == System.Windows.Forms.Keys.D0) || РаботаСоСканером.НажатаЛеваяПодэкраннаяКлавиша(e))
            {
                e.Handled = true;
                _Назад();
            }
            if ((e.KeyCode == System.Windows.Forms.Keys.D1) || РаботаСоСканером.НажатаПраваяПодэкраннаяКлавиша(e))
            {
                e.Handled = true;
                _Далее();
            }
            if ((e.KeyCode == System.Windows.Forms.Keys.Enter))
            {
                _Далее();
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
            Дерево.CollapseAll();
            foreach (var Строка in Последовательность.ОтветСервера)
            {

                if (Строка[0] == "ЗавершитьЗагрузкуДанных") break;
                if (Строка[0] == "ДобавитьКорень")
                {
                    ДобавитьАдрес(ref КореньАдрес, ref Корень, Строка);
                    continue;
                }

                if (КореньАдрес != null )
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
            КореньАдрес.Tag = Строка[2];
            КореньАдрес.Text = Строка[1];
        }

        private TreeNode ДобавитьТовар(TreeNode КореньАдрес, TreeNode ВыбранаСтрока, ЭлементДерева Корень, string[] Строка)
        {
            int Строк = Строка.Count();
            TreeNode СтрокаСТоваром = new TreeNode(Строка[0]);
            if (Строк > 2 && Строка[2] == "Выбрать") { ВыбранаСтрока = СтрокаСТоваром; }
            СтрокаСТоваром.Tag = Строка[1];
            СтрокаСТоваром.Text = Строка[0];
            КореньАдрес.Nodes.Add(СтрокаСТоваром);
            return ВыбранаСтрока;
        }



        private void Назад_Click(object sender, EventArgs e)
        {
            _Назад();
        }

        private void Далее_Click(object sender, EventArgs e)
        {
            _Далее();
        }

        private void Дерево_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Button == MouseButtons.Middle) _Далее();
        }



    }
}