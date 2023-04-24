using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoutubeExplode;
using YoutubeExplode.Converter;

namespace Mod18
{ // Определяем отдельный класс, как команду
    class CommandDownloadVideo : Command
    {    // Определяем переменную для логирования
         Receiver receiver;
        // Определяем переменную внутри команды, для храннеия адреса
         string url;
        //Делаем команду в конструктора класса, на входе которого два параметра
        public CommandDownloadVideo(Receiver receiver, string url)
        {
            this.receiver = receiver; // Присваиваем переменную для лога
            this.url = url; // Присваиваем переменную для адреса
        }

        // Переписываем метод запуска под команду
        public override async void Run()
        {
            Console.WriteLine("\n Началось скачивание видео!");
            var youtube = new YoutubeClient();
            // Получаем ссылку на видео
            var video = youtube.Videos.GetAsync(url).Result;
            // Присваиваем название фалу
            string nameVideo = $"{video.Title}.mp4";
            //Скачиваем файл
            youtube.Videos.DownloadAsync(url, nameVideo, builder => builder.SetPreset(ConversionPreset.UltraFast)).AsTask().Wait();
            //Логируем
            receiver.Operation($"Видео скачано и называется: {nameVideo}");
        }


        // Отменить
        public override void Cancel()
        {
            
        }
    }
}
