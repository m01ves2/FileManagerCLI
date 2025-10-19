using FileManagerCLI.Core.Infrastructure;

namespace FileManagerCLI.App.Interfaces
{
    internal interface ICommandHandler
    {
        string Execute(string input);
    }
}
