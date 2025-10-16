using FileManagerCLI.Core.Interfaces;
using FileManagerCLI.Core.Models;
using FileManagerCLI.Core.Services;

namespace FileManagerCLI.Core.Commands
{
    public class DeleteCommand : ICommand
    {
        public string Name => "delete";
        public string Description => "Delete file or directory";

        public CommandResult Execute(IItem item, string[] args)
        {
            try {
                if (item is FileItem) {
                    (new FileService()).DeleteFile(item.Path);
                }
                else if (item is DirectoryItem) {
                    (new DirectoryService()).DeleteDirectory(item.Path);
                }
                else
                    return new CommandResult { Success = false, Message = "Unknown item type" };

                return new CommandResult { Success = true, Message = $"Deleted {item.Path}" };
            }
            catch (Exception ex) {
                return new CommandResult { Success = false, Message = ex.Message };
            }
        }
    }
}
