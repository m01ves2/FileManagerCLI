using FileManagerCLI.Core.Infrastructure;
using FileManagerCLI.Core.Interfaces;
using FileManagerCLI.Core.Models;
using FileManagerCLI.Core.Services;

namespace FileManagerCLI.Core.Commands
{
    public class DeleteCommand : ICommand
    {
        public string Name => "delete";
        public string Description => "Delete file or directory";

        public CommandResult Execute(CommandContext context, string[] args)
        {
            try {
                if (args.Where(t => !t.StartsWith('-')).Count() < 1)
                    return new CommandResult { Success = false, Message = "Source path required" };

                string commandKeys = args.Where(t => t.StartsWith('-')).FirstOrDefault() ?? "";
                string source = args.Where(t => !t.StartsWith('-')).FirstOrDefault() ?? "";

                bool isFile = ((ICommand)this).IsFile(source);

                if (isFile) {
                    (new FileService()).DeleteFile(source);
                }
                else {
                    (new DirectoryService()).DeleteDirectory(source);
                }

                return new CommandResult { Success = true, Message = $"Deleted {source}" };
            }
            catch (Exception ex) {
                return new CommandResult { Success = false, Message = ex.Message };
            }
        }
    }
}
