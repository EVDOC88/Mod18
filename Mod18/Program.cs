using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mod18
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Здраствуйте! Данное приложение поможет Вам скачать видео с YOUTUBE");
            Console.WriteLine("Введите полный URL-адрес видео, пример https://youtu.be/ORkIoaM7ICQ");
            string url = Console.ReadLine();

            var sender = new Sender();

            // создадим получателя
            var receiver = new Receiver();

            // создадим команду
            var CommandGetVideoDescription = new CommandGetVideoDescription(receiver, url);

            // инициализация команды
            sender.SetCommand(CommandGetVideoDescription);

            //  выполнение
            sender.Run();

            // Ожидаем ответ от предыдущей команды
            string otvet = Console.ReadLine();
            if (otvet == "Да")
            { var CommandDownloadVideo = new CommandDownloadVideo(receiver, url);

                // инициализация команды
                sender.SetCommand(CommandDownloadVideo);

                //  выполнение
                sender.Run();
            }
            else
               sender.Cancel();

           Console.ReadKey();

        }
    }
}
