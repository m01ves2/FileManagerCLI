using FileManagerCLI.Core.Infrastructure;
using FileManagerCLI.Core.Interfaces;
using FileManagerCLI.Core.Models;
using FileManagerCLI.Core.Services;
using System.IO.IsolatedStorage;

namespace FileManagerCLI.Core.Commands
{
    public class CopyCommand : BaseCommand
    {
        public override string Name => "cp";
        public override string Description => "Copy file or directory";

        public CopyCommand(IFileService fileService, IDirectoryService directoryService) : base(fileService, directoryService)
        {
        }

        public override CommandResult Execute(CommandContext context, string[] args)
        {
            try {
                if (args.Where(t => !t.StartsWith('-')).Count() < 2)
                    return new CommandResult { Status = CommandStatus.Error, Message = "Source and Destination paths required" };

                IEnumerable<string> keysCommand = args.Where(t => t.StartsWith('-'));
                string source = args.Where(t => !t.StartsWith('-')).ElementAt(0);
                string destination = args.Where(t => !t.StartsWith('-')).ElementAt(1);

                //var fullPath = Path.GetFullPath(Path.Combine(context.CurrentDirectory, source));

                if (_fileService.IsFile(source)) {
                    _fileService.CopyFile(source, destination); //TODO: flags, e.g. File.Copy(source, destination, overwrite: true);
                }
                else if(_directoryService.IsDirectory(source)) {
                    _directoryService.CopyDirectory(source, destination); //TODO flags, e.g. Directory.Copy(source, destination, recoursively);
                }
                else {
                    return new CommandResult { Status = CommandStatus.Error, Message = "No such file or directory" };
                }

                    return new CommandResult { Status = CommandStatus.Success, Message = $"Copied to {destination}" };
            }
            catch (Exception ex) {
                return new CommandResult { Status = CommandStatus.Error, Message = ex.Message };
            }
        }

        //private void CopyDirectory(string source, string destination)
        //{
        //    Directory.CreateDirectory(destination);

        //    foreach (var file in Directory.GetFiles(source))
        //        File.Copy(file, Path.Combine(destination, Path.GetFileName(file)), true);

        //    foreach (var dir in Directory.GetDirectories(source))
        //        CopyDirectory(dir, Path.Combine(destination, Path.GetFileName(dir)));
        //}
    }
}
