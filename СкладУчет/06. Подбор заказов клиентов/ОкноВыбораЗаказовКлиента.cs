using System;
using System.Windows.Forms;
using System.Drawing;
using System.Linq;
using System.Collections.Generic;

namespace СкладскойУчет
{
    public partial class ОкноВыбораЗаказовКлиента : Form
    {
        private Пакеты Обмен;

        private string[][] ОтветСервера;

        public ОкноВыбораЗаказовКлиента()
        {
            Обмен = new Пакеты("ВыборЗаказовКлиента");
            InitializeComponent();
        }


        // События на форме -----------------------------------------------------------------------------------------------------------------------------------
        public virtual void ОкноВыбораЗаказовКлиента_Load(object sender, EventArgs e)
        {
            ОтветСервера = Обмен.ПослатьСтроку("ПолучениеЗаданий");

            if (ОтветСервера == null) { this.Close(); return; } // в случае ошибки закрываем окно подбора

            if (ОтветСервера[0][0] == "ЗаданияЗаписаны")
            {
                Form Окно = new ОкноЗаказовКлиента();
                this.Close();
                Окно.ShowDialog();
                return;
            }

            if (ОтветСервера[0][0] == "ЗаданияВПодборе")
            {
                Form Окно = new ОкноПодбораЗаказовКлиента();
                this.Close();
                Окно.ShowDialog();
                return;
            }

            // Заполнение таблицы
            ТаблицаДокументов.Items.Clear();
            foreach (var Строка in ОтветСервера)
            {
                ListViewItem НоваяСтрока = new ListViewItem();
                НоваяСтрока.Text = Строка[0];
                НоваяСтрока.SubItems.Add(Строка[1]);
                НоваяСтрока.SubItems.Add(Строка[2]);
                НоваяСтрока.SubItems.Add(Строка[3]);

                ТаблицаДокументов.Items.Add(НоваяСтрока);
            }

            // Блокируем все строки, кроме первой
            var СерыйЦвет = Color.FromArgb(220, 220, 220);
            int КоличествоСтрок = ТаблицаДокументов.Items.Count;
            for (int i = 1; i < КоличествоСтрок; i++)
            {
                ТаблицаДокументов.Items[i].BackColor = СерыйЦвет;
            }

            // Пытаемся выбрать первую строку
            try
            {
                var ВыбраннаяСтрока = ТаблицаДокументов.Items[0];
                if (ВыбраннаяСтрока == null) return;
                ВыбраннаяСтрока.Selected = true;
                ВыбраннаяСтрока.Focused = true;
            }
            catch (Exception) { }     
        }

        public virtual void ОкноВыбораЗаказовКлиента_KeyDown(object sender, KeyEventArgs e)
        {
            if (РаботаСоСканером.НажатаПраваяПодэкраннаяКлавиша(e) || РаботаСоСканером.НажатаКлавишаСкан(e) || (e.KeyCode == System.Windows.Forms.Keys.Enter))
            {
                _Далее();
            }
            if (РаботаСоСканером.НажатаЛеваяПодэкраннаяКлавиша(e) || (e.KeyCode == System.Windows.Forms.Keys.Escape))
            {
                _Назад();
            }
        }

        private void Назад_Click(object sender, EventArgs e)
        {
            _Назад();
        }

        private void Далее_Click(object sender, EventArgs e)
        {
            _Далее();
        }

        public virtual void _Далее()
        {
            var ВыбраннаяСтрока = ТаблицаДокументов.FocusedItem;
            if (ВыбраннаяСтрока == null) { Инфо.Ошибка("Не выбрано ни одной строки"); return; }

            // Запрет на выбор документов, кроме первого
            if (ВыбраннаяСтрока.Index != 0)
            {
                Инфо.Ошибка("Разрешен выбор только первого документа в очереди!");
                return;
            }

            string РН_Гуид = ВыбраннаяСтрока.SubItems[3].Text;

            ОтветСервера = Обмен.ПослатьСтроку(РН_Гуид);

            if (ОтветСервера == null) return; // в случае ошибки остаться в этом же окне

            if (ОтветСервера[0][0] == "ЗаданияЗаписаны")
            {
                Form Окно = new ОкноЗаказовКлиента();
                this.Close();
                Окно.ShowDialog();
                return;
            }

            if (ОтветСервера[0][0] == "ЗаданиеВзято")
            {
                Инфо.Ошибка("Задания по выбранному документу уже взяты!");
                ОкноВыбораЗаказовКлиента_Load(null, new EventArgs());
                return;
            }
        }

        public virtual void _Назад()
        {
              this.Close();
        }
        // ------------------------------------------------------------------------------------------------------------------------------------------------------

    }
}