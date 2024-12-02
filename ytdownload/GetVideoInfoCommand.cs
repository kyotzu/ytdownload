using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoutubeExplode;

namespace ytdownload
{
    public class GetVideoInfoCommand : ICommand
    {
        public async Task ExecuteAsync(string[] args)
        {
            if (args.Length < 1)
            {
                Console.WriteLine("Укажите ссылку на видео.");
                return;
            }

            var videoUrl = args[0];
            var youtube = new YoutubeClient();

            try
            {
                var video = await youtube.Videos.GetAsync(videoUrl);
                Console.WriteLine($"Название: {video.Title}");
                Console.WriteLine($"Описание: {video.Description}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
        }
    }
}
