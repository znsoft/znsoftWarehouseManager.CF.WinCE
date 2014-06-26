using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using СкладскойУчет.СсылкаНаСервис;

namespace СкладскойУчет
{

    public class ПоследовательностьОкон
    {

        public string Операция;
        Пакеты Обмен = new Пакеты("СледующееОкно");
        public string ТекущееОкно = "";
        public int ТекущийНомерОкна = 0;
        string[][] ОтветСервера = null;

        public ПоследовательностьОкон(string Операция)
        {
            this.Операция = Операция;
        }

        public void ЗапуститьСледующееОкно()
        {
            Form Окно = new Form();
            DialogResult ОтветОкна;
            ОтветОкна = DialogResult.Ignore;
            while (true)
            {
                if (ОтветОкна != DialogResult.Retry)
                {
                    ОтветСервера = Обмен.ПослатьСтроку(Операция, ТекущееОкно, (ОтветОкна == DialogResult.Cancel) ? "Назад" : "Далее");
                }
                if (ОтветСервера == null || ОтветСервера.Count() == 0) {
                    Ошибка ОкноОшибки = new Ошибка("Ошибка получения данных от сервера");
                    ОкноОшибки.ShowDialog();
                    return; }
                var Строка = (
                    from Строкаответа in ОтветСервера
                    where Строкаответа[0].Contains("ПоказатьОкно")
                    select new { ВидОкна = Строкаответа[1], ТекущееОкно = Строкаответа[2] }
                              ).First();
                
                ТекущееОкно =
                    Строка.ТекущееОкно;
                switch (Строка.ВидОкна)
                {
                    case "Окно выбора из списка":
                        Окно = new Окно_выбора_из_списка(this, ref ОтветСервера);
                        break;
                    case "Выход":
                        return;
                    default:
                        return;
                }

                ОтветОкна = Окно.ShowDialog();
            }
            


        }


    }
}
