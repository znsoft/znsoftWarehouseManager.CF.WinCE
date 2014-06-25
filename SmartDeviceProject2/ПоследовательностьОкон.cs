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
            var ОтветСервера = Обмен.ПослатьСтроку(Операция, ТекущееОкно, "");

            var ОтветСтрока = ОтветСервера[0];
            ТекущееОкно = ОтветСтрока.П2;
            //ТекущийНомерОкна = int.Parse(ОтветСтрока.П3);
            Form Окно = new Form();
            switch(ОтветСтрока.П1){
                case "Окно выбора из списка":
                    Окно = new Окно_выбора_из_списка(this, ОтветСервера);
                    break;
                case "Выход":
                    return;

            }

            var ОтветОкна = Окно.ShowDialog();

            


        }


    }
}
