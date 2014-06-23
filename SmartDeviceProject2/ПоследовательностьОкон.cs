using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace СкладскойУчет
{

    public class ПоследовательностьОкон
    {

        public string Операция;
        Пакеты Обмен = new Пакеты("СледующееОкно");
        public string ТекущееОкно = "";
        public int ТекущийНомерОкна = 0;

        public ПоследовательностьОкон(string Операция)
        {
            this.Операция = Операция;
        }

        public void ЗапуститьСледующееОкно()
        {
            var ОтветСервера = Обмен.ПослатьСтроку(Операция, ТекущееОкно, ТекущийНомерОкна);
            var ОтветСтрока = ОтветСервера[0];
            ТекущееОкно = ОтветСтрока.Наименование;
            ТекущийНомерОкна = int.Parse(ОтветСтрока.Количество);
            Form Окно = new Form();
            switch(ОтветСтрока.Код){
                case "Окно выбора из списка":
                    Окно = (Form)new Окно_выбора_из_списка(this, ОтветСервера);
                    
                    break;
                case "Выход":
                    break;

            }

            var ОтветОкна = Окно.ShowDialog();

            


        }


    }
}
