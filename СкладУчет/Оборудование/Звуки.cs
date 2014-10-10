using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Media;
using System.Reflection;
using System.IO;
using System.Runtime.InteropServices;
using СкладскойУчет.Оборудование;

namespace СкладскойУчет
{


    public class Звуки 
    {
        
        SoundPlayer Звук;

        public Звуки() {
            Звук = new SoundPlayer();
        }



        public void Ошибка()
        {
            МаксимальнаяГромкость();
            Звук.Stream = new MemoryStream(Properties.Resources.Error);
            //Звук.PlaySync();
            Звук.Play();
            МинимальнаяГромкость();
        }

        public void Ок() {
            МаксимальнаяГромкость();
            Звук.Stream = new MemoryStream(Properties.Resources.Ok);
            //Звук.PlaySync();
            Звук.Play();
            МинимальнаяГромкость();
        }

        public void МаксимальнаяГромкость()
        {
            try
            {
                WinApi.waveOutSetVolume(IntPtr.Zero, uint.MaxValue);
            }
            catch (Exception) { }
        }

        public void МинимальнаяГромкость()
        {
            try
            {
                WinApi.waveOutSetVolume(IntPtr.Zero, 0);
            }
            catch (Exception) { }
        }

    }
}
