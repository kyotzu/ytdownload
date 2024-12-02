using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ytdownload
{
    public class CommandDispatcher
    {
        private readonly Dictionary<string, ICommand> _commands = new();

        public void RegisterCommand(string name, ICommand command)
        {
            _commands[name] = command;
        }

        public async Task DispatchAsync(string[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine("Укажите команду (info/download).");
                return;
            }

            var commandName = args[0];
            if (_commands.TryGetValue(commandName, out var command))
            {
                await command.ExecuteAsync(args[1..]);
            }
            else
            {
                Console.WriteLine($"Команда '{commandName}' не найдена.");
            }
        }
    }
}
