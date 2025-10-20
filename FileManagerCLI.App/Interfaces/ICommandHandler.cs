using FileManagerCLI.Core.Infrastructure;

namespace FileManagerCLI.App.Interfaces
{
    internal interface ICommandHandler
    {
        CommandResult Execute(string input);
        string GetCLIPrompt();
    }
}
