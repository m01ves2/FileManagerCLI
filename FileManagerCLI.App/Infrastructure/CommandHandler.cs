using FileManagerCLI.App.Interfaces;
using FileManagerCLI.App.Services;
using FileManagerCLI.Core.Infrastructure;
using FileManagerCLI.Core.Interfaces;

namespace FileManagerCLI.App.Infrastructure
{
    internal class CommandHandler : ICommandHandler
    {
        CommandContext _commandContext;
        CommandRegistry _commandRegistry;
        ICommandFactory _commandFactory;
        CommandParser _commandParser;
        public CommandHandler(CommandContext commandContext, CommandRegistry commandRegistry, ICommandFactory commandFactory, CommandParser commandParser)
        {
            _commandContext = commandContext;
            _commandRegistry = commandRegistry;
            _commandFactory = commandFactory;
            _commandParser = commandParser;
        }

        public CommandResult Execute(string input) //TODO: return CommandResult + Implement FormatterCLI/FormatterWeb to adopt output for UI
        {
            (string commandName, string[] args) = _commandParser.Parse(input);
            ICommand command = _commandFactory.GetCommand(commandName);
            CommandResult commandResult = command.Execute(_commandContext, args);
            return commandResult;
        }

        public string GetCLIPrompt()
        {
            return _commandContext.CurrentDirectory + ">";
        }
    }
}
