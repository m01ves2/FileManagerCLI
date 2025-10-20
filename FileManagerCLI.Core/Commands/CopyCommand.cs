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
                    return new CommandResult { Success = false, Message = "Source and Destination paths required" };

                IEnumerable<string> keysCommand = args.Where(t => t.StartsWith('-'));
                string source = args.Where(t => !t.StartsWith('-')).ElementAt(0);
                string destination = args.Where(t => !t.StartsWith('-')).ElementAt(1);

                //var fullPath = Path.GetFullPath(Path.Combine(context.CurrentDirectory, source));

                if (_fileService.IsFile(source)) {
                    _fileService.CopyFile(source, destination); //TODO: flags, e.g. File.Copy(source, destination, overwrite: true);
                }
                else {
                    _directoryService.CopyDirectory(source, destination); //TODO flags, e.g. Directory.Copy(source, destination, recoursively);
                }

                return new CommandResult { Success = true, Message = $"Copied to {destination}" };
            }
            catch (Exception ex) {
                return new CommandResult { Success = false, Message = ex.Message };
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
