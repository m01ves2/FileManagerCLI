using FileManagerCLI.Core.Interfaces;
using System.Text;

namespace FileManagerCLI.App.Services
{
    internal class CommandFactory
    {
        private CommandRegistry _commandRegistry;

        public CommandFactory(CommandRegistry commandRegistry) 
        { 
            _commandRegistry = commandRegistry;
        }

        public ICommand GetCommand(string commandName)
        {
            return _commandRegistry.GetCommand(commandName);
        }
    }
}
