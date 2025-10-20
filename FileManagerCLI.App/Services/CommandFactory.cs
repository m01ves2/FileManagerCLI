using FileManagerCLI.App.Interfaces;
using FileManagerCLI.Core.Interfaces;

namespace FileManagerCLI.App.Services
{
    internal class CommandFactory : ICommandFactory
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
