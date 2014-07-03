using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Media;
using System.Reflection;
using System.IO;

namespace СкладскойУчет
{
    
    public class Звуки
    {
        SoundPlayer Звук;

        public Звуки() {
            Звук = new SoundPlayer();
        }

        public void Ошибка() {
            Звук.Stream = new MemoryStream(Properties.Resources.Error);
            Звук.Play();
            РаботаСоСканером.ЭтоСканирование = false;
        }

        public void Ок() {
            Звук.Stream = new MemoryStream(Properties.Resources.Ok);
            Звук.Play();
            РаботаСоСканером.ЭтоСканирование = false;
        }

    }
}
