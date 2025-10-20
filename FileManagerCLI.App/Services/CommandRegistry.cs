using FileManagerCLI.Core.Commands;
using FileManagerCLI.Core.Interfaces;
using System.Text;

namespace FileManagerCLI.App.Services
{
    internal class CommandRegistry
    {
        private readonly Dictionary<string, ICommand> _registry;
        public CommandRegistry() 
        {
            _registry = new Dictionary<string, ICommand>()
            {
                { "ls", new ListCommand()},
                { "cp", new CopyCommand()},
                { "mk", new CreateCommand()},
                { "rm", new DeleteCommand()},
                { "help", new HelpCommand()},
                { "mv", new MoveCommand()},
            };
        }

        public ICommand GetCommand(string name)
        {
            return _registry[name];
        }

        public string GetCommandNames()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("--help: \n");
            foreach (var item in _registry) {
                sb.Append(item.Key + " - " + item.Value.Description + "\n");
            }
            return sb.ToString();
        }
    }
}
