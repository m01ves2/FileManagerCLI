using FileManagerCLI.App.Interfaces;
using FileManagerCLI.Core.Infrastructure;

namespace FileManagerCLI.App.Infrastructure
{
    internal class Coordinator
    {
        private readonly ICommandHandler _commandHandler;
        private readonly IUI _uI;

        public Coordinator(IUI uI, ICommandHandler commandHandler)
        {
            _commandHandler = commandHandler;
            _uI = uI;
        }

        internal void Start()
        {

            while (true) {
                string prompt = _commandHandler.GetCLIPrompt();
                string input = _uI.ReadInput(prompt);

                if (string.IsNullOrEmpty(input)) {
                    continue;
                }

                CommandResult commandResult = _commandHandler.Execute(input);
                _uI.PrintResult(commandResult);

                if(commandResult.Status == CommandStatus.Exit) {
                    break;
                }
            }
        }
    }
}
