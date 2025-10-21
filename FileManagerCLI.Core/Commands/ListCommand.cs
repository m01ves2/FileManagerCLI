using FileManagerCLI.Core.Infrastructure;
using FileManagerCLI.Core.Interfaces;
using FileManagerCLI.Core.Models;
using FileManagerCLI.Core.Services;
using System.Text;

namespace FileManagerCLI.Core.Commands
{
    //команды не являются сущностями, но живут в Core, потому что реализуют бизнес-логику работы с сущностями
    public class ListCommand : BaseCommand
    {
        public override string Name => "ls";
        public override string Description => "List files and folders in a directory";

         public ListCommand(IFileService fileService, IDirectoryService directoryService) : base(fileService, directoryService)
        {
        }

        public override CommandResult Execute(CommandContext context, string[] args)
        {
            try {

                string source = ".";
                if (args.Where(t => !t.StartsWith('-')).Count() > 0)
                    source = args.Where(t => !t.StartsWith("-")).FirstOrDefault() ?? ".";

                string commandKeys = args.Where(t => t.StartsWith('-')).FirstOrDefault() ?? "";
                //var path = args.FirstOrDefault() ?? context.CurrentDirectory;

                if (_fileService.IsFile(source)) {
                    FileInfo fileInfo = _fileService.GetFileInfo(source);
                    return new CommandResult()
                    {
                        Status = CommandStatus.Success,
                        Message = $"{fileInfo.CreationTime}\t{fileInfo.Attributes}\t{fileInfo.Length}"
                    };
                }
                else if (_directoryService.IsDirectory(source)) {
                    string[] items = _directoryService.ListDirectory(source);
                    StringBuilder sb = new StringBuilder();
                    foreach (string i in items) {
                        sb.Append(i + "\n");
                    }
                    return new CommandResult() { Status = CommandStatus.Success, Message = sb.ToString() };
                }
                else {
                    return new CommandResult() { Status = CommandStatus.Error, Message = "No such file or directory" };
                }

            }
            catch (Exception ex) {
                return new CommandResult { Status = CommandStatus.Error, Message = ex.Message };
            }
        }
    }
}