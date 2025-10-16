using FileManagerCLI.Core.Interfaces;
using FileManagerCLI.Core.Models;
using FileManagerCLI.Core.Services;

namespace FileManagerCLI.Core.Commands
{
    internal class MoveCommand : ICommand
    {
        public string Name => "move";
        public string Description => "Move file or directory";
        public CommandResult Execute(IItem item, string[] args)
        {
            try {
                if (args.Length < 1)
                    return new CommandResult { Success = false, Message = "Destination path required" };

                string destination = args[0];

                if (item is FileItem)
                    (new FileService()).MoveFile(item.Path, destination);
                else if (item is DirectoryItem)
                    (new DirectoryService()).MoveDirectory(item.Path, destination);
                else
                    return new CommandResult { Success = false, Message = "Unknown item type" };

                return new CommandResult { Success = true, Message = $"Moved to {destination}" };
            }
            catch (Exception ex) {
                return new CommandResult { Success = false, Message = ex.Message };
            }
        }
    }
}
