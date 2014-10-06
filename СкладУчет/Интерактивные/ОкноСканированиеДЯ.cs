using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace СкладскойУчет.Интерактивные
{
    class ОкноСканированиеДЯ:Окно_сканирования_ТС
    {
        public String ВернутьАдресДЯ;
        Пакеты Обмен;
        ПоследовательностьОкон Последовательность;

        public ОкноСканированиеДЯ(ПоследовательностьОкон ПоследовательностьОкон)
            : base(ПоследовательностьОкон)
        {
            Последовательность = ПоследовательностьОкон;
            Обмен = new Пакеты(Последовательность.Операция + " НайтиТовар"); 
        }

        public override void Окно_сканирования_ТС_Load(object sender, EventArgs e)
        {

        }

        public override void СканАдреса(string СтрокаСкан)
        {

            if (!(СтрокаСкан.ToLower().StartsWith("adr")&&СтрокаСкан.Length == 10)) {
                Инфо.ПолучениеИнформации(СтрокаСкан, СписокИнформации, Таб);
                return; }
            Последовательность.ОтветСервера = Обмен.ПослатьСтроку(СтрокаСкан,"","");
            if (Последовательность.ОтветСервера == null) return;
            if (!Последовательность.ОтветСервера[0][0].Contains("ТекстДЯ")) return;
            this.ВернутьАдресДЯ = Последовательность.ОтветСервера[0][1];
            this.DialogResult = DialogResult.Retry;
            this.Close();
            return;
        }

    }
}
