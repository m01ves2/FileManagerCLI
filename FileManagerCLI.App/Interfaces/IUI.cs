using FileManagerCLI.Core.Infrastructure;

namespace FileManagerCLI.App.Interfaces
{
    internal interface IUI
    {
        public string ReadInput(string prompt);
        public void PrintResult(CommandResult commandResult);
    }
}
