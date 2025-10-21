using FileManagerCLI.Core.Infrastructure;

namespace FileManagerCLI.App.Interfaces
{
    public interface ICommandHandler
    {
        CommandResult Execute(string input);
        string GetCLIPrompt();
    }
}
