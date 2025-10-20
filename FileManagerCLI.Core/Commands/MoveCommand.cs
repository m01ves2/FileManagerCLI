using FileManagerCLI.Core.Infrastructure;
using FileManagerCLI.Core.Interfaces;
using FileManagerCLI.Core.Models;
using FileManagerCLI.Core.Services;

namespace FileManagerCLI.Core.Commands
{
    public class MoveCommand : BaseCommand
    {
        public override string Name => "mv";
        public override string Description => "Move file or directory";
        public MoveCommand(IFileService fileService, IDirectoryService directoryService) : base(fileService, directoryService)
        {
        }
        public override CommandResult Execute(CommandContext context, string[] args)
        {
            try {               
              
                if (args.Where(t => !t.StartsWith('-')).Count() < 2)
                    return new CommandResult { Success = false, Message = "Source and Destination paths required" };

                IEnumerable<string> keysCommand = args.Where(t => t.StartsWith('-'));
                string source = args.Where(t => !t.StartsWith('-')).ElementAt(0);
                string destination = args.Where(t => !t.StartsWith('-')).ElementAt(1);

                if (_fileService.IsFile(source)) {
                    _fileService.MoveFile(source, destination);
                }
                else {
                    _directoryService.MoveDirectory(source, destination);
                }

                return new CommandResult { Success = true, Message = $"Moved to {destination}" };
            }
            catch (Exception ex) {
                return new CommandResult { Success = false, Message = ex.Message };
            }
        }
    }
}
