using FileManagerCLI.App.Interfaces;
using FileManagerCLI.App.Services;
using FileManagerCLI.Core.Infrastructure;
using FileManagerCLI.Core.Interfaces;

namespace FileManagerCLI.App.Infrastructure
{
    public class CommandHandler : ICommandHandler
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

            try {
                (string commandName, string[] args) = _commandParser.Parse(input);
                ICommand command = _commandRegistry.GetCommand(commandName);
                commandResult = command.Execute(_commandContext, args);
            }
            catch(Exception ex) {
                commandResult = new CommandResult() { Status = CommandStatus.Error, Message = ex.Message};
            }

            return commandResult;
        }

        public string GetCLIPrompt()
        {
            return _commandContext.CurrentDirectory + ">";
        }
    }
}

//так, смотри:
//ты писал: "CommandParser.Parse()
//    Если строка пустая или состоит из пробелов — tokens[0] выбросит IndexOutOfRangeException."
//но ведь у нас есть защита в Coordinator.Start:
//if (string.IsNullOrEmpty(input)) {
//    continue;
//}
//так что пустые вводы отсеиваются еще тут
//1.парсер мы защитили
//if (string.IsNullOrWhiteSpace(input))
//    return ("", Array.Empty<string>());
//теперь там не может вылететь Exception
//2. GetCommand мы защитили
// public ICommand GetCommand(string name)
//{
//    if (_registry.ContainsKey(name))
//        return _registry[name];
//    else
//        return new UnknownCommand(name, _fileService, _directoryService);
//}
//там тоже не может вылететь Exception
//3. В Core у нас не может вылететь Exception, они там все обрабатываются
//4. значит, единственное место, которое мы только что добавили, и где вылетают Exception - это конструктор в CommandRegistry:
//            if (commands.Select(c => c.Name).Distinct().Count() != commands.Count)
//    throw new InvalidOperationException("Duplicate command names detected.");
//и получается, мы оборачиваем код внутри CommandResult.Execute только ради этого единственного исключения? не вижу других причин