using FileManagerCLI.Core.Interfaces;

namespace FileManagerCLI.App.Interfaces
{
    internal interface ICommandFactory
    {
        ICommand GetCommand(string commandName);
    }
}
