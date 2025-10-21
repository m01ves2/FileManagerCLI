using FileManagerCLI.Core.Infrastructure;
using FileManagerCLI.Core.Interfaces;
using FileManagerCLI.Core.Models;
using FileManagerCLI.Core.Services;

namespace FileManagerCLI.Core.Commands
{
    public class DeleteCommand : BaseCommand
    {
        public override string Name => "rm";
        public override string Description => "Delete file or directory";
        public DeleteCommand(IFileService fileService, IDirectoryService directoryService) : base(fileService, directoryService)
        {
        }

        public override CommandResult Execute(CommandContext context, string[] args)
        {
            try {
                if (args.Where(t => !t.StartsWith('-')).Count() < 1)
                    return new CommandResult { Status = CommandStatus.Error, Message = "Source path required" };

                string commandKeys = args.Where(t => t.StartsWith('-')).FirstOrDefault() ?? "";
                string source = args.Where(t => !t.StartsWith('-')).FirstOrDefault() ?? "";

                if (_fileService.IsFile(source)) {
                    _fileService.DeleteFile(source);
                }
                else if (_directoryService.IsDirectory(source)) {
                    _directoryService.DeleteDirectory(source);
                }
                else {
                    return new CommandResult { Status = CommandStatus.Error, Message = "No such file or directory" };
                }

                    return new CommandResult { Status = CommandStatus.Success, Message = $"Deleted {source}" };
            }
            catch (Exception ex) {
                return new CommandResult { Status = CommandStatus.Error, Message = ex.Message };
            }
        }
    }
}
