namespace ytdownload
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var dispatcher = new CommandDispatcher();

            dispatcher.RegisterCommand("info", new GetVideoInfoCommand());
            dispatcher.RegisterCommand("download", new DownloadVideoCommand());

            await dispatcher.DispatchAsync(args);
        }
    }
}
