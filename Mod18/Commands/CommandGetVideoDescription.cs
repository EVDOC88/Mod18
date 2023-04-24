using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoutubeExplode;

namespace Mod18
{    // Определяем отдельный класс, как команду
    class CommandGetVideoDescription : Command

    {// Определяем переменную для логирования
        Receiver receiver;
     // Определяем переменную внутри команды, для храннеия адреса
        string url;

        //Делаем команду в конструктора класса, на входе которого два параметра
        public CommandGetVideoDescription(Receiver receiver, string url)
        {
            this.receiver = receiver; // Присваиваем переменную для лога
            this.url = url; // Присваиваем переменную для адреса
        }

        // Переписываем метод запуска под команду
        public override async void Run()
        {
            receiver.Operation("Получаем информацию о видео");
            var youtube = new YoutubeClient();
            var video = await youtube.Videos.GetAsync(url);
            Console.WriteLine($"Название видео: {video.Title}" );
            Console.WriteLine($"Описание видео: {video.Description}");
            receiver.Operation("Информация получена");
            Console.WriteLine("Вы хотите скачать видео Да или Нет?");
        }

        // Отменить
        public override void Cancel()
        {
            receiver.Operation("Скачивание видео отмененно");
        }
    }
}
