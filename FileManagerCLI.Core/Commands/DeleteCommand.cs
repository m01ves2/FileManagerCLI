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
                    return new CommandResult { Success = false, Message = "Source path required" };

                string commandKeys = args.Where(t => t.StartsWith('-')).FirstOrDefault() ?? "";
                string source = args.Where(t => !t.StartsWith('-')).FirstOrDefault() ?? "";

                if (_fileService.IsFile(source)) {
                    _fileService.DeleteFile(source);
                }
                else {
                    _directoryService.DeleteDirectory(source);
                }

                return new CommandResult { Success = true, Message = $"Deleted {source}" };
            }
            catch (Exception ex) {
                return new CommandResult { Success = false, Message = ex.Message };
            }
        }
    }
}
