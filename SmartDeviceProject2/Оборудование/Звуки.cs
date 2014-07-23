using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Media;
using System.Reflection;
using System.IO;
using System.Runtime.InteropServices;

namespace СкладскойУчет
{


    public class Звуки 
    {
        [DllImport("coredll.dll", SetLastError = true)]
        protected static extern int waveOutSetVolume(IntPtr device, uint volume);

        
        SoundPlayer Звук;

        public Звуки() {
            Звук = new SoundPlayer();
        }

        public void Ошибка() {
            МаксимальнаяГромкость();
            Звук.Stream = new MemoryStream(Properties.Resources.Error);
            Звук.Play();
            РаботаСоСканером.ЭтоСканирование = false;
        }

        public void Ок() {
            МаксимальнаяГромкость();
            Звук.Stream = new MemoryStream(Properties.Resources.Ok);
            Звук.Play();
            РаботаСоСканером.ЭтоСканирование = false;
        }

        public void МаксимальнаяГромкость()
        {
            waveOutSetVolume(IntPtr.Zero, uint.MaxValue);
        }



    }
}
