using FileManagerCLI.Core.Infrastructure;

namespace FileManagerCLI.App.Interfaces
{
    internal interface IUI
    {
        public string ReadInput();
        public void PrintResult(CommandResult commandResult);
    }
}
