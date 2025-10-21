using FileManagerCLI.Core.Infrastructure;

namespace FileManagerCLI.App.Interfaces
{
    public interface IUI
    {
        public string ReadInput(string prompt);
        public void WriteOutput(CommandResult commandResult);
    }
}
