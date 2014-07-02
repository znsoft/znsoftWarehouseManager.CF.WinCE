using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Media;

namespace СкладскойУчет
{
    
    public class Звуки
    {
        SoundPlayer Звук;
        public Звуки() {
            Звук = new SoundPlayer();
        }

        public void Ошибка() {
            Звук.SoundLocation = Properties.Resources.Error;
            Звук.Play();
        }

        public void Ок() {
            Звук.SoundLocation = Properties.Resources.Error;
            Звук.Play();
        }

    }
}
