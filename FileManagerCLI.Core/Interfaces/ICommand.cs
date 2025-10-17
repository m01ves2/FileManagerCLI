using FileManagerCLI.Core.Infrastructure;

namespace FileManagerCLI.Core.Interfaces
{
    public interface ICommand
    {
        string Name { get; }
        string Description { get; }
        CommandResult Execute(CommandContext context, string[] args);

        public bool IsFile(string source)
        {
            if (File.Exists(source)) return true;
            else if (Directory.Exists(source)) return false;
            else throw new InvalidOperationException("Unknown item type");
        }
    }
}
