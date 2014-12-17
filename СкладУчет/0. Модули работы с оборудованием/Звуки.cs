using System;
using System.Media;
using System.IO;

namespace СкладскойУчет
{

    public class Звуки 
    {      
        SoundPlayer Звук;
        //MemoryStream ПотокОшибка;
        //MemoryStream ПотокОк;

        public Звуки()
        {
            Звук = new SoundPlayer();
            //ПотокОшибка = new MemoryStream(Properties.Resources.Error);
            //ПотокОк = new MemoryStream(Properties.Resources.Ok);
        }

        public void Ошибка()
        {
            МаксимальнаяГромкость();
            Звук.Stream = new MemoryStream(Properties.Resources.Error);
            //Звук.Stream = ПотокОшибка;
            Звук.PlaySync();
            //Звук.Play();
            МинимальнаяГромкость();
        }

        public void Ок() 
        {
            МаксимальнаяГромкость();
            Звук.Stream = new MemoryStream(Properties.Resources.Ok);
            //Звук.Stream = ПотокОк;
            Звук.PlaySync();
            //Звук.Play();
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
