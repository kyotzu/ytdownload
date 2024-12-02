using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoutubeExplode;
using YoutubeExplode.Converter;

namespace ytdownload
{
    public class DownloadVideoCommand : ICommand
    {
        public async Task ExecuteAsync(string[] args)
        {
            if (args.Length < 2)
            {
                Console.WriteLine("Укажите ссылку на видео и путь для сохранения файла.");
                return;
            }

            var videoUrl = args[0];
            var outputPath = args[1];

            var youtube = new YoutubeClient();

            try
            {
                Console.WriteLine("Начинается скачивание...");
                await youtube.Videos.DownloadAsync(
                    videoUrl,
                    outputPath,
                    builder => builder.SetPreset(ConversionPreset.UltraFast)
                );
                Console.WriteLine($"Видео сохранено по пути: {outputPath}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
        }
    }
}
