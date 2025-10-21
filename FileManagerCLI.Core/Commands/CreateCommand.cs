using FileManagerCLI.Core.Infrastructure;
using FileManagerCLI.Core.Interfaces;
using FileManagerCLI.Core.Models;
using FileManagerCLI.Core.Services;

namespace FileManagerCLI.Core.Commands
{
    public class CreateCommand : BaseCommand, ICommand
    {

        public override string Name => "mk";
        public override string Description => "Creates file or directory";

        public CreateCommand(IFileService fileService, IDirectoryService directoryService) : base(fileService, directoryService)
        {
        }

        public override CommandResult Execute(CommandContext context, string[] args)
        {
            try {
                if (args.Where(t => !t.StartsWith('-')).Count() < 1)
                    return new CommandResult { Status = CommandStatus.Error, Message = "Source path required" };

                IEnumerable<string> commandKeys = args.Where(t => t.StartsWith('-'));
                string source = args.Where(t => !t.StartsWith('-')).FirstOrDefault() ?? "";

                bool isFile = (commandKeys.Count() == 0) || !(commandKeys.Contains("-d") || commandKeys.ElementAt(0).Contains('d'));

                if (isFile) {
                    _fileService.CreateFile(source);
                }
                else {
                    _directoryService.CreateDirectory(source);
                }

                return new CommandResult { Status = CommandStatus.Success, Message = $"Created {source}" };
            }
            catch (Exception ex) {
                return new CommandResult { Status = CommandStatus.Error, Message = ex.Message };
            }

        }
    }
}
