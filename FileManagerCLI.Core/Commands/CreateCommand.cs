using FileManagerCLI.Core.Interfaces;
using FileManagerCLI.Core.Models;
using FileManagerCLI.Core.Services;

namespace FileManagerCLI.Core.Commands
{
    public class CreateCommand : ICommand
    {
        public string Name => "create";
        public string Description => "Creates file or directory";

        public CommandResult Execute(IItem item, string[] args)
        {
            try {
                if (item is FileItem)
                    (new FileService()).CreateFile(item.Path);
                else if (item is DirectoryItem)
                    (new DirectoryService()).CreateDirectory(item.Path);
                else
                    return new CommandResult { Success = false, Message = "Unknown item type" };

                return new CommandResult { Success = true, Message = $"Created {item.Path}" };
            }
            catch (Exception ex) {
                return new CommandResult { Success = false, Message = ex.Message };
            }

        }
    }
}
