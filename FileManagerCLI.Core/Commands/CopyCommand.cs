using FileManagerCLI.Core.Interfaces;
using FileManagerCLI.Core.Models;
using FileManagerCLI.Core.Services;

namespace FileManagerCLI.Core.Commands
{
    public class CopyCommand : ICommand
    {
        public string Name => "copy";
        public string Description => "Copy file or directory";

        public CommandResult Execute(IItem item, string[] args)
        {
            try {
                if (args.Length < 1)
                    return new CommandResult { Success = false, Message = "Destination path required" };

                string destination = args[0];

                if (item is FileItem)
                    (new FileService()).CopyFile(item.Path, destination);
                else if (item is DirectoryItem)
                    (new DirectoryService()).CopyDirectory(item.Path, destination);
                else
                    return new CommandResult { Success = false, Message = "Unknown item type" };

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
