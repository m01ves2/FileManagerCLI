using FileManagerCLI.App.Interfaces;
using FileManagerCLI.App.Services;
using FileManagerCLI.Core.Infrastructure;
using FileManagerCLI.Core.Interfaces;

namespace FileManagerCLI.App.Infrastructure
{
    internal class CommandHandler : ICommandHandler
    {
        private readonly CommandContext _commandContext = new CommandContext();
        private readonly CommandRegistry _commandRegistry = new CommandRegistry();
        private readonly CommandFactory _commandFactory;
        private readonly CommandParser _commandParser = new CommandParser();

        public CommandHandler()
        {
            _commandFactory = new CommandFactory(_commandRegistry);
        }

        public string Execute(string input) //TODO: return CommandResult + Implement FormatterCLI/FormatterWeb to adopt output for UI
        {
            (string commandName, string[] args) = _commandParser.Parse(input);
            ICommand command = _commandFactory.GetCommand(commandName);
            CommandResult commandResult = command.Execute(_commandContext, args);
            return commandResult.Message;
        }

        public string GetCLIPrompt()
        {
            return _commandContext.CurrentDirectory + ">";
        }
    }
}
