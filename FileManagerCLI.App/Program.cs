using FileManagerCLI.App.Infrastructure;
using FileManagerCLI.App.Interfaces;
using FileManagerCLI.App.Services;
using FileManagerCLI.Core.Infrastructure;
using FileManagerCLI.Core.Interfaces;
using FileManagerCLI.Core.Services;

namespace FileManagerCLI
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            CommandContext commandContext = new CommandContext();
            IFileService fileService = new FileService();
            IDirectoryService directoryService = new DirectoryService();
            CommandRegistry commandRegistry = new CommandRegistry(fileService, directoryService);
            CommandParser commandParser = new CommandParser();

            ICommandHandler commandHandler = new CommandHandler(commandContext, commandRegistry, commandParser);
            IUI uI = new ConsoleUI();

            Coordinator coordinator = new Coordinator(uI, commandHandler);
            coordinator.Start();
        }
    }
}