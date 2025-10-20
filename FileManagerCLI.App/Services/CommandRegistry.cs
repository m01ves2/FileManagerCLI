using FileManagerCLI.Core.Commands;
using FileManagerCLI.Core.Interfaces;
using FileManagerCLI.Core.Services;
using System.Text;

namespace FileManagerCLI.App.Services
{
    internal class CommandRegistry
    {
        private readonly Dictionary<string, ICommand> _registry;
        private readonly IFileService _fileService;
        private readonly IDirectoryService _directoryService;
        public CommandRegistry(IFileService fileService, IDirectoryService directoryService) 
        {
            _fileService = fileService;
            _directoryService = directoryService;

            var commands = new List<ICommand>();

            ICommand copyCommand = new CopyCommand();
            ICommand createCommand = new CreateCommand();
            ICommand deleteCommand = new DeleteCommand();
            ICommand helpCommand = new HelpCommand(commands); // HelpCommand получает уже готовую коллекцию
            ICommand listCommand = new ListCommand();
            ICommand moveCommand = new MoveCommand();

            commands.AddRange(new ICommand[] { 
                listCommand,
                copyCommand,
                createCommand,
                deleteCommand,
                moveCommand,
                helpCommand
            });

            // а потом — уже реестр
            _registry = commands.ToDictionary(c => c.Name, c => c);
        }

        public ICommand GetCommand(string name)
        {
            if (_registry.ContainsKey(name))
                return _registry[name];
            else
                throw new InvalidOperationException("Unsupported command");
        }
    }
}
