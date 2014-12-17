using System;
using System.Windows.Forms;

namespace СкладскойУчет
{
    public partial class ОкноВыбораИзСписка : Form
    {
        private Пакеты Обмен; 
        private int НомерКонокиГУИД = 0;
        private ПоследовательностьОкон Последовательность;

        public ОкноВыбораИзСписка(ПоследовательностьОкон ПоследовательностьОкон)
        {
            InitializeComponent();
            Последовательность = ПоследовательностьОкон;
            Обмен = new Пакеты(ПоследовательностьОкон.Операция + " ВыборЗадания"); //Сформировали пакет с операцией состоящей например "Подбор ВыборЗадания"
        }

        public virtual void ОкноВыбораИзСписка_Load(object sender, EventArgs e)
        {
            ЭлементыФормыДляЗаполнения ЭлементыФормы = new ЭлементыФормыДляЗаполнения();
            ЭлементыФормы.Инструкция = this.Инструкция;
            ЭлементыФормы.СписокВыбора = this.СписокВыбора;
            //ЭлементыФормы.ТекстДЯ = this.Пользователь;
            ЭлементыФормы.Пользователь = this.Пользователь;
            ЗаполнениеЭлементовФормы.ЗаполнитьФорму(ЭлементыФормы, ref Последовательность.ОтветСервера, ref НомерКонокиГУИД);
            try
            {
                var ВыбраннаяСтрока = СписокВыбора.Items[0];
                if (ВыбраннаяСтрока == null) return;
                ВыбраннаяСтрока.Selected = true;
                ВыбраннаяСтрока.Focused = true;
            }
            catch (Exception) { }
        }

        private void СписокВыбора_ItemActivate(object sender, EventArgs e)
        {
            _Далее();
        }

        public void ПриНажатииНаКнопку(object sender, EventArgs Аргументы)
        {
            Button Кнопка = (Button)sender;
            switch (Кнопка.Name)
            {
                case "Назад":
                    _Назад();
                    return;
                case "Далее":
                    _Далее();
                    return;
            }
        }

        public virtual void _Назад()
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();//Нажали назад, необходимо попасть на предыдущее окно, думаю можно и самому решить этот вопрос без обращения к серверу       
        }

        public virtual void _Далее()
        {
            var ВыбраннаяСтрока = СписокВыбора.FocusedItem;
            if (ВыбраннаяСтрока == null) { Инфо.Ошибка("Не выбрано ни одной строки"); return; }
            string ВыбранноеЗначение = НомерКонокиГУИД < 1 ? ВыбраннаяСтрока.Text : ВыбраннаяСтрока.SubItems[НомерКонокиГУИД-1].Text;
            Последовательность.ОтветСервера = Обмен.ПослатьСтроку(ВыбранноеЗначение, Последовательность.ТекущееОкно, "РучнойВыбор");
            if (Последовательность.ОтветСервера == null) return; // в случае ошибки остаться в этом же окне
            this.DialogResult = DialogResult.Retry;
            this.Close();
        }

        public virtual void ОкноВыбораИзСписка_KeyDown(object sender, KeyEventArgs e)
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

             foreach (var ЭлементФормы in this.Controls)
                 if (ЭлементФормы is Button)
                 {
                     Button Кнопка = (Button)ЭлементФормы;
                     if ((char)Кнопка.Text[1] == (char)e.KeyValue)
                     {
                         Кнопка.Focus();
                         ПриНажатииНаКнопку(Кнопка, new EventArgs());
                         return;
                     }
                 }


             if (РаботаСоСканером.НажатаПраваяПодэкраннаяКлавиша(e) || (e.KeyCode == System.Windows.Forms.Keys.Enter))
             {
                 _Далее();
             }
             if (РаботаСоСканером.НажатаЛеваяПодэкраннаяКлавиша(e) || (e.KeyCode == System.Windows.Forms.Keys.Escape))
             {
                 _Назад();
             }

         }

    }
}