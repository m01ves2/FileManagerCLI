using FileManagerCLI.App.Interfaces;
using FileManagerCLI.App.Services;
using FileManagerCLI.Core.Infrastructure;
using FileManagerCLI.Core.Interfaces;

namespace FileManagerCLI.App.Infrastructure
{
    internal class CommandHandler : ICommandHandler
    {
        private readonly CommandContext _commandContext;
        private readonly CommandRegistry _commandRegistry;
        private readonly CommandParser _commandParser;
        public CommandHandler(CommandContext commandContext, CommandRegistry commandRegistry, CommandParser commandParser)
        {
            _commandContext = commandContext;
            _commandRegistry = commandRegistry;
            _commandParser = commandParser;
        }

        public CommandResult Execute(string input)
        {
            CommandResult commandResult;
            (string commandName, string[] args) = _commandParser.Parse(input);
            ICommand command = _commandRegistry.GetCommand(commandName);
            commandResult = command.Execute(_commandContext, args);
            return commandResult;
        }

        public string GetCLIPrompt()
        {
            return _commandContext.CurrentDirectory + ">";
        }
    }
}
