using FileManagerCLI.App.Infrastructure;
using FileManagerCLI.App.Interfaces;
using FileManagerCLI.App.Services;
using FileManagerCLI.Core.Infrastructure;

namespace FileManagerCLI
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            CommandContext commandContext = new CommandContext();
            CommandRegistry commandRegistry = new CommandRegistry();
            ICommandFactory commandFactory = new CommandFactory(commandRegistry);
            CommandParser commandParser = new CommandParser();

            ICommandHandler commandHandler = new CommandHandler(commandContext, commandRegistry, (ICommandFactory)commandFactory, commandParser);
            ConsoleUI consoleUI = new ConsoleUI(commandHandler);
            consoleUI.Start();
        }
    }
}